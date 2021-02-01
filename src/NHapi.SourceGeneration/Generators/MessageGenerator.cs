/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "MessageGenerator.java".  Description:
  "Creates source code for HL7 Message objects, using the normative DB"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s):  Eric Poiseau.

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the  "GPL"), in which case the provisions of the GPL are
  applicable instead of those above.  If you wish to allow use of your version of this
  file only under the terms of the GPL and not to allow others to use your version
  of this file under the MPL, indicate your decision by deleting  the provisions above
  and replace  them with the notice and other provisions required by the GPL License.
  If you do not delete the provisions above, a recipient may use your version of
  this file under either the MPL or the GPL.
*/

namespace NHapi.SourceGeneration.Generators
{
    using System;
    using System.Collections;
    using System.Data.Common;
    using System.Data.Odbc;
    using System.IO;
    using System.Text;
    using NHapi.Base;
    using NHapi.Base.Log;

   /// <summary> Creates source code for HL7 Message objects, using the normative DB.  HL7 Group
   /// objects are also created as a byproduct.
   ///
   /// </summary>
   /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net)
   /// </author>
   /// <author>  Eric Poiseau
   /// </author>
   public class MessageGenerator : object
    {
        /// <summary> If the system property by this name is true, groups are generated to use a ModelClassFactory
        /// for segment class lookup.  This makes segment creation more flexible, but may slow down parsing
        /// substantially.
        /// </summary>
        public static string MODEL_CLASS_FACTORY_KEY = "NHapi.Base.Sourcegen.modelclassfactory";

        private static readonly IHapiLog log;

        /// <summary>Creates new MessageGenerator </summary>
        public MessageGenerator()
        {
        }

        /// <summary> Creates and writes source code for all Messages and Groups.</summary>
        public static void makeAll(string baseDirectory, string version)
        {
            // get list of messages ...
            using (OdbcConnection conn = NormativeDatabase.Instance.Connection)
            {
                string sql = getMessageListQuery(version);
                DbCommand stmt = TransactionManager.manager.CreateStatement(conn);
                DbCommand temp_OleDbCommand;
                temp_OleDbCommand = stmt;
                temp_OleDbCommand.CommandText = sql;
                DbDataReader rs = temp_OleDbCommand.ExecuteReader();
                ArrayList messages = new ArrayList();
                ArrayList chapters = new ArrayList();
                while (rs.Read())
                {
                    messages.Add(Convert.ToString(rs[1 - 1]));
                    chapters.Add(Convert.ToString(rs[2 - 1]));
                }

                rs.Close();
                NormativeDatabase.Instance.returnConnection(conn);

                if (messages.Count == 0)
                {
                    log.Warn("No version " + version + " messages found in database " + conn.Database);
                }

                for (int i = 0; i < messages.Count; i++)
                {
                    string message = (string)messages[i];
                    string chapter = (string)chapters[i];
                    make(message, baseDirectory, chapter, version);
                }
            }
        }

        /// <summary> Returns an SQL query with which to get a list of messages from the normative
        /// database.
        /// </summary>
        private static string getMessageListQuery(string version)
        {
            // UNION because the messages are defined in different tables for different versions.
            return "SELECT distinct  [message_type]+'_'+[event_code] AS msg_struct, '[AAA]'" +
                     " FROM HL7Versions RIGHT JOIN HL7EventMessageTypeSegments ON HL7EventMessageTypeSegments.version_id = HL7Versions.version_id " +
                     "WHERE HL7Versions.hl7_version ='" + version + "' and Not (message_type='ACK') " + "UNION " +
                     "select distinct HL7MsgStructIDs.message_structure, [section] from HL7Versions RIGHT JOIN (HL7MsgStructIDSegments " +
                     " inner join HL7MsgStructIDs on HL7MsgStructIDSegments.message_structure = HL7MsgStructIDs.message_structure " +
                     " and HL7MsgStructIDSegments.version_id = HL7MsgStructIDs.version_id) " +
                     " ON HL7MsgStructIDSegments.version_id = HL7Versions.version_id " + " where HL7Versions.hl7_version = '" +
                     version + "' and HL7MsgStructIDs.message_structure not like 'ACK_%'"; // note: allows "ACK" itself
        }

        /// <summary> Creates source code for a specific message structure and
        /// writes it under the specified directory.
        /// throws IllegalArgumentException if there is no message structure
        /// for this message in the normative database
        /// </summary>
        public static void make(string message, string baseDirectory, string chapter, string version)
        {
            try
            {
                SegmentDef[] segments = getSegments(message, version);

                // System.out.println("Making: " + message + " with " + segments.length + " segments (not writing message code - just groups)");
                GroupDef group = GroupGenerator.getGroupDef(segments, null, baseDirectory, version, message);
                IStructureDef[] contents = group.Structures;

                // make base directory
                if (!(baseDirectory.EndsWith("\\") || baseDirectory.EndsWith("/")))
                {
                    baseDirectory = baseDirectory + "/";
                }

                FileInfo targetDir =
                    SourceGenerator.makeDirectory(baseDirectory + PackageManager.GetVersionPackagePath(version) + "Message");
                Console.Out.WriteLine("Writing " + message + " to " + targetDir.FullName);
                using (StreamWriter out_Renamed = new StreamWriter(targetDir.FullName + "/" + message + ".cs"))
                {
                    out_Renamed.Write(makePreamble(contents, message, chapter, version));
                    out_Renamed.Write(makeConstructor(contents, message, version));
                    for (int i = 0; i < contents.Length; i++)
                    {
                        string groupAccessor = GroupGenerator.makeAccessor(@group, i);
                        out_Renamed.Write(groupAccessor);
                    }

                    // add implementation of model.control interface, if any
                    out_Renamed.Write("}\r\n"); // End class
                    out_Renamed.Write("}\r\n"); // End namespace
                }
            }
            catch (Exception e)
            {
                log.Error("Error while creating source code", e);

                log.Warn("Warning: could not write source code for message structure " + message + " - " + e.GetType().FullName +
                            ": " + e.Message);
            }
        }

        /// <summary> Queries the normative database for a list of segments comprising
        /// the message structure.  The returned list may also contain strings
        /// that denote repetition and optionality.  Choice indicators (i.e. begin choice,
        /// next choice, end choice) for alternative segments are ignored, so that the class
        /// structure allows all choices.  The matter of enforcing that only a single choice is
        /// populated can't be handled by the class structure, and should be handled elsewhere.
        /// </summary>
        private static SegmentDef[] getSegments(string message, string version)
        {
            /*String sql = "select HL7Segments.seg_code, repetitional, optional, description " +
            "from (HL7MsgStructIDSegments inner join HL7Segments on HL7MsgStructIDSegments.seg_code = HL7Segments.seg_code " +
            "and HL7MsgStructIDSegments.version_id = HL7Segments.version_id) " +
            "where HL7Segments.version_id = 6 and message_structure = '" + message + "' order by seq_no";*/
            string sql = getSegmentListQuery(message, version);

            // System.out.println(sql.toString());
            SegmentDef[] segments = new SegmentDef[200]; // presumably there won't be more than 200
            OdbcConnection conn = NormativeDatabase.Instance.Connection;
            DbCommand stmt = TransactionManager.manager.CreateStatement(conn);
            DbCommand temp_OleDbCommand;
            temp_OleDbCommand = stmt;
            temp_OleDbCommand.CommandText = sql;
            DbDataReader rs = temp_OleDbCommand.ExecuteReader();
            int c = -1;
            while (rs.Read())
            {
                string name = SegmentGenerator.altSegName(Convert.ToString(rs[1 - 1]));
                bool repeating = rs.GetBoolean(2 - 1);
                bool optional = rs.GetBoolean(3 - 1);
                string desc = Convert.ToString(rs[4 - 1]);
                string groupName = Convert.ToString(rs[6 - 1]);

                // ignore the "choice" directives ... the message class structure has to include all choices ...
                //  if this is enforced (i.e. exception thrown if >1 choice populated) this will have to be done separately.
                if (!(name.Equals("<") || name.Equals("|") || name.Equals(">")))
                {
                    c++;
                    segments[c] = new SegmentDef(name, groupName, !optional, repeating, desc);
                }
            }

            rs.Close();
            SegmentDef[] ret = new SegmentDef[c + 1];
            Array.Copy(segments, 0, ret, 0, c + 1);
            return ret;
        }

        /// <summary> Returns an SQL query with which to get a list of the segments that
        /// are part of the given message from the normative database.  The query
        /// varies with different versions.  The fields returned are as follows:
        /// segment_code, repetitional, optional, description
        /// </summary>
        private static string getSegmentListQuery(string message, string version)
        {
            string sql = null;

            sql = "SELECT HL7Segments.seg_code, repetitional, optional, HL7Segments.description, seq_no, groupname " +
                    "FROM HL7Versions RIGHT JOIN (HL7Segments INNER JOIN HL7EventMessageTypeSegments ON (HL7Segments.version_id = HL7EventMessageTypeSegments.version_id) " +
                    "AND (HL7Segments.seg_code = HL7EventMessageTypeSegments.seg_code)) " +
                    "ON HL7Segments.version_id = HL7Versions.version_id " + "WHERE (((HL7Versions.hl7_version)= '" + version +
                    "') " + "AND (([message_type]+'_'+[event_code])='" + message + "')) UNION " +
                    "select HL7Segments.seg_code, repetitional, optional, HL7Segments.description, seq_no, groupname  " +
                    "from HL7Versions RIGHT JOIN (HL7MsgStructIDSegments inner join HL7Segments on HL7MsgStructIDSegments.seg_code = HL7Segments.seg_code " +
                    "and HL7MsgStructIDSegments.version_id = HL7Segments.version_id) " +
                    "ON HL7Segments.version_id = HL7Versions.version_id " + "where HL7Versions.hl7_version = '" + version +
                    "' and message_structure = '" + message + "' order by seq_no";
            return sql;
        }

        /// <summary> Returns header material for the source code of a Message class (including
        /// package, imports, JavaDoc, and class declaration).
        /// </summary>
        public static string makePreamble(IStructureDef[] contents, string message, string chapter, string version)
        {
            StringBuilder preamble = new StringBuilder();
            preamble.Append("using System;\r\n");
            preamble.Append("using System.Collections.Generic;\r\n");
            preamble.Append("using NHapi.Base.Log;\r\n");
            preamble.Append("using ");
            preamble.Append((string)PackageManager.GetVersionPackageName(version));
            preamble.Append("Group;\r\n");
            preamble.Append("using ");
            preamble.Append((string)PackageManager.GetVersionPackageName(version));
            preamble.Append("Segment;\r\n");
            preamble.Append("using ");
            preamble.Append((string)PackageManager.GetVersionPackageName(version));
            preamble.Append("Datatype;\r\n");
            preamble.Append("using NHapi.Base;\r\n");
            preamble.Append("using NHapi.Base.Parser;\r\n");
            preamble.Append("using NHapi.Base.Model;\r\n\r\n");

            preamble.Append("namespace ");
            preamble.Append((string)PackageManager.GetVersionPackageName(version));
            preamble.Append("Message\r\n\r\n");
            preamble.Append("{\r\n");
            preamble.Append("///<summary>\r\n");
            preamble.Append("/// Represents a ");
            preamble.Append(message);
            preamble.Append(" message structure (see chapter ");
            preamble.Append(chapter);
            preamble.Append("). This structure contains the \r\n");
            preamble.Append("/// following elements:\r\n");
            preamble.Append(GroupGenerator.makeElementsDoc(contents));
            preamble.Append("///</summary>\r\n");
            preamble.Append("[Serializable]\r\n");
            preamble.Append("public class ");
            preamble.Append(message);
            preamble.Append(" : AbstractMessage ");

            // implement interface from model.control package if required
            /*Class correspondingControlInterface = Control.getInterfaceImplementedBy(message);
            if (correspondingControlInterface != null) {
            preamble.append("implements ");
            preamble.append(correspondingControlInterface.getName());
            }*/

            preamble.Append(" {\r\n\r\n");

            return preamble.ToString();
        }

        /// <summary> Returns source code for the contructor for this Message class.</summary>
        public static string makeConstructor(IStructureDef[] structs, string messageName, string version)
        {
            bool useFactory = ConfigurationSettings.UseFactory;

            StringBuilder source = new StringBuilder();

            source.Append("\t///<summary> \r\n");
            source.Append("\t/// Creates a new ");
            source.Append(messageName);
            source.Append(" Group with custom IModelClassFactory.\r\n");
            source.Append("\t///</summary>\r\n");
            source.Append("\tpublic ");
            source.Append(messageName);
            source.Append("(IModelClassFactory factory) : base(factory){\r\n");
            source.Append("\t   init(factory);\r\n");
            source.Append("\t}\r\n\r\n");
            source.Append("\t///<summary>\r\n");
            source.Append("\t/// Creates a new ");
            source.Append(messageName);
            source.Append(" Group with DefaultModelClassFactory. \r\n");
            source.Append("\t///</summary> \r\n");
            source.Append("\tpublic ");
            source.Append(messageName);
            source.Append("() : base(new DefaultModelClassFactory()) { \r\n");
            source.Append("\t   init(new DefaultModelClassFactory());\r\n");
            source.Append("\t}\r\n\r\n");
            source.Append("\t///<summary>\r\n");
            source.Append("\t/// initalize method for ");
            source.Append(messageName);
            source.Append(".  This does the segment setup for the message. \r\n");
            source.Append("\t///</summary> \r\n");
            source.Append("\tprivate void init(IModelClassFactory factory) {\r\n");
            source.Append("\t   try {\r\n");
            int numStructs = structs.Length;
            for (int i = 0; i < numStructs; i++)
            {
                IStructureDef def = structs[i];
                if (useFactory)
                {
                    source.Append("\t      this.add(factory.get");
                    source.Append((def is GroupDef) ? "Group" : "Segment");
                    source.Append("Class(\"");
                    source.Append(def.Name);
                    source.Append("\", \"");
                    source.Append(version);
                    source.Append("\"), ");
                }
                else
                {
                    source.Append("\t      this.add(typeof(");
                    source.Append(def.Name);
                    source.Append("), ");
                }

                source.Append(def.Required.ToString().ToLower());
                source.Append(", ");
                source.Append(def.Repeating.ToString().ToLower());
                source.Append(");\r\n");
            }

            source.Append("\t   } catch(HL7Exception e) {\r\n");
            source.Append("\t      HapiLogFactory.GetHapiLog(GetType()).Error(\"Unexpected error creating ");
            source.Append(messageName);
            source.Append(" - this is probably a bug in the source code generator.\", e);\r\n");
            source.Append("\t   }\r\n");
            source.Append("\t}\r\n\r\n");
            source.Append(Environment.NewLine);
            source.Append("\tpublic override string Version\r\n");
            source.Append("\t\t{\r\n");
            source.Append("\t\t\tget{\r\n");
            source.Append("\t\t\treturn Constants.VERSION;\r\n");
            source.Append("\t\t\t}\r\n");
            source.Append("\t\t}\r\n");
            return source.ToString();
        }

        static MessageGenerator()
        {
            log = HapiLogFactory.GetHapiLog(typeof(MessageGenerator));
        }
    }
}