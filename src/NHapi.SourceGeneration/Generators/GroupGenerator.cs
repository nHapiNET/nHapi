/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "GroupGenerator.java".  Description:
  "Creates source code for Group classes - these are aggregations of
  segments and/or other groups that may repeat together within a message.
  Source code is generated from the normative database"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s):  Eric Poiseau.

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the "GPL"), in which case the provisions of the GPL are
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
    using System.IO;
    using System.Text;

    using NHapi.Base;
    using NHapi.Base.Log;

    /// <summary> Creates source code for Group classes - these are aggregations of
    /// segments and/or other groups that may repeat together within a message.
    /// Source code is generated from the normative database.
    ///
    /// </summary>
    /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net).
    /// </author>
    /// <author>  Eric Poiseau.
    /// </author>
    public class GroupGenerator : object
    {
        private static readonly IHapiLog Log;

        static GroupGenerator()
        {
            Log = HapiLogFactory.GetHapiLog(typeof(GroupGenerator));
        }

        /// <summary>Creates new GroupGenerator. </summary>
        public GroupGenerator()
        {
        }

        /// <summary> Creates source code for a Group and returns a GroupDef object that
        /// describes the Group's name, optionality, repeatability.  The source
        /// code is written under the given directory.
        /// The structures list may contain [] and {} pairs representing
        /// nested groups and their optionality and repeatability.  In these cases
        /// this method is called recursively.
        /// If the given structures list begins and ends with repetition and/or
        /// optionality markers the repetition and optionality of the returned
        /// GroupDef are set accordingly.
        /// <param name="structures">a list of the structures that comprise this group - must
        /// be at least 2 long
        /// </param>
        /// <param name="groupName">The group name</param>
        /// <param name="version">The version of message</param>
        /// <param name="baseDirectory">the directory to which files should be written
        /// </param>
        /// <param name="message">the message to which this group belongs
        /// </param>
        /// <throws>  HL7Exception if the repetition and optionality markers are not  </throws>
        /// </summary>
        public static GroupDef WriteGroup(
            IStructureDef[] structures,
            string groupName,
            string baseDirectory,
            string version,
            string message)
        {
            // make base directory
            if (!(baseDirectory.EndsWith("\\") || baseDirectory.EndsWith("/")))
            {
                baseDirectory = baseDirectory + "/";
            }

            var targetDir =
                SourceGenerator.MakeDirectory(baseDirectory + PackageManager.GetVersionPackagePath(version) + "Group");

            // some group names are troublesome and have "/" which will cause problems when writing files
            groupName = groupName.Replace("/", "_");
            var group = GetGroupDef(structures, groupName, baseDirectory, version, message);

            using (var out_Renamed = new StreamWriter(targetDir.FullName + @"\" + group.Name + ".cs"))
            {
                out_Renamed.Write(MakePreamble(group, version));
                out_Renamed.Write(MakeConstructor(group, version));

                var shallow = group.Structures;
                for (var i = 0; i < shallow.Length; i++)
                {
                    out_Renamed.Write(MakeAccessor(group, i));
                }

                out_Renamed.Write("}\r\n"); // Closing class
                out_Renamed.Write("}\r\n"); // Closing namespace
            }

            return group;
        }

        /// <summary> <p>Given a list of structures defining the deep content of a group (as provided in
        /// the normative database, some being pairs of optionality and repetition markers
        /// and segments nested within) returns a GroupDef including a short list of the shallow contents of the
        /// group (including segments and groups that are immediate children).</p>
        /// <p>For example given MSH [PID PV1] {[ERR NTE]}, short list would be something like
        /// MSH PID_GROUP ERR_GROUP (with PID_GROUP marked as optional and ERR_GROUP marked as
        /// optional and repeating).</p>
        /// <p>This method calls writeGroup(...) where necessary in order to create source code for
        /// any nested groups before returning corresponding GroupDefs.</p>
        /// </summary>
        public static GroupDef GetGroupDef(
            IStructureDef[] structures,
            string groupName,
            string baseDirectory,
            string version,
            string message)
        {
            GroupDef ret = null;
            var required = true;
            var repeating = false;
            var rep_opt = false;

            var len = structures.Length;
            var shortList = new IStructureDef[len]; // place to put final list of groups/segments w/o opt & rep markers
            var currShortListPos = 0;
            var currLongListPos = 0;

            try
            {
                // check for rep and opt (see if start & end elements are [] or {} AND they are each others' pair) ...
                // System.out.println(len + " " + structures[0].getName() +structures[1].getName()+ ".." +structures[len-2].getName() + structures[len-1].getName()+ " " + message);
                if (OptMarkers(structures[0].Name, structures[len - 1].Name) && (FindGroupEnd(structures, 0) == len - 1))
                {
                    required = false;
                }

                if (RepMarkers(structures[0].Name, structures[len - 1].Name) && (FindGroupEnd(structures, 0) == len - 1))
                {
                    repeating = true;
                }

                if (RepoptMarkers(structures[0].Name, structures[len - 1].Name) && (FindGroupEnd(structures, 0) == len - 1))
                {
                    rep_opt = true;
                }

                if (repeating || !required)
                {
                    if (OptMarkers(structures[1].Name, structures[len - 2].Name) && (FindGroupEnd(structures, 1) == len - 2))
                    {
                        required = false;
                    }

                    if (RepMarkers(structures[1].Name, structures[len - 2].Name) && (FindGroupEnd(structures, 1) == len - 2))
                    {
                        repeating = true;
                    }
                }

                // loop through, recurse nested groups, and build short list of structures for this group
                var skip = 0;
                if (!required)
                {
                    skip++;
                }

                if (repeating)
                {
                    skip++;
                }

                if (rep_opt)
                {
                    skip++;
                }

                currLongListPos = skip;
                while (currLongListPos < len - skip)
                {
                    var currSegName = structures[currLongListPos].Name;
                    if (currSegName.Equals("[") || currSegName.Equals("{") || currSegName.Equals("[{"))
                    {
                        // this is the opening of a new group ...
                        var name = ((SegmentDef)structures[currLongListPos]).GroupName;
                        var endOfNewGroup = FindGroupEnd(structures, currLongListPos);
                        var newGroupStructures = new IStructureDef[endOfNewGroup - currLongListPos + 1];
                        Array.Copy(structures, currLongListPos, newGroupStructures, 0, newGroupStructures.Length);
                        shortList[currShortListPos] = WriteGroup(newGroupStructures, name, baseDirectory, version, message);
                        currLongListPos = endOfNewGroup + 1;
                    }
                    else
                    {
                        // copy verbatim into short list ...
                        shortList[currShortListPos] = structures[currLongListPos];
                        currLongListPos++;
                    }

                    currShortListPos++;
                }
            }
            catch (ArgumentException e)
            {
                throw new HL7Exception(
                    "Problem creating nested group: " + e.GetType().FullName + ": " + e.Message,
                    ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            if (rep_opt)
            {
                ret = new GroupDef(message, groupName, false, true, "a Group object");
            }
            else
            {
                ret = new GroupDef(message, groupName, required, repeating, "a Group object");
            }

            var finalList = new IStructureDef[currShortListPos]; // note: incremented after last assignment
            Array.Copy(shortList, 0, finalList, 0, currShortListPos);
            for (var i = 0; i < finalList.Length; i++)
            {
                ret.AddStructure(finalList[i]);
            }

            return ret;
        }

        /// <summary> Returns heading material for class source code (package, imports, JavaDoc, class
        /// declaration).
        /// </summary>
        public static string MakePreamble(GroupDef group, string version)
        {
            var preamble = new StringBuilder();
            preamble.Append("using NHapi.Base.Parser;\r\n");
            preamble.Append("using NHapi.Base;\r\n");
            preamble.Append("using NHapi.Base.Log;\r\n");
            preamble.Append("using System;\r\n");
            preamble.Append("using System.Collections.Generic;\r\n");
            preamble.Append("using ");
            preamble.Append((string)PackageManager.GetVersionPackageName(version));
            preamble.Append("Segment;\r\n");
            preamble.Append("using ");
            preamble.Append((string)PackageManager.GetVersionPackageName(version));
            preamble.Append("Datatype;\r\n");
            preamble.Append("using NHapi.Base.Model;\r\n\r\n");
            preamble.Append("namespace ");
            preamble.Append((string)PackageManager.GetVersionPackageName(version));
            preamble.Append("Group\n");
            preamble.Append("{\r\n");
            preamble.Append("///<summary>\r\n");
            preamble.Append("///Represents the ");
            preamble.Append(group.Name);
            preamble.Append(" Group.  A Group is an ordered collection of message \r\n");
            preamble.Append("/// segments that can repeat together or be optionally in/excluded together.\r\n");
            preamble.Append("/// This Group contains the following elements: \r\n");
            preamble.Append(MakeElementsDoc(group.Structures));
            preamble.Append("///</summary>\r\n");
            preamble.Append("[Serializable]\r\n");
            preamble.Append("public class ");
            preamble.Append(group.Name);
            preamble.Append(" : AbstractGroup {\r\n\r\n");
            return preamble.ToString();
        }

        /// <summary> Returns source code for the constructor for this Group class. </summary>
        public static string MakeConstructor(GroupDef group, string version)
        {
            var useFactory = ConfigurationSettings.UseFactory;

            var source = new StringBuilder();

            source.Append("\t///<summary> \r\n");
            source.Append("\t/// Creates a new ");
            source.Append(group.Name);
            source.Append(" Group.\r\n");
            source.Append("\t///</summary>\r\n");
            source.Append("\tpublic ");
            source.Append(group.Name);
            source.Append("(IGroup parent, IModelClassFactory factory) : base(parent, factory){\r\n");
            source.Append("\t   try {\r\n");
            var structs = group.Structures;
            var numStructs = structs.Length;
            for (var i = 0; i < numStructs; i++)
            {
                var def = structs[i];

                if (def.Name.Equals("?"))
                {
                    source.Append("\t      this.addNonstandardSegment(\"ANY\");\r\n");
                }
                else
                {
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
            }

            source.Append("\t   } catch(HL7Exception e) {\r\n");
            source.Append("\t      HapiLogFactory.GetHapiLog(GetType()).Error(\"Unexpected error creating ");
            source.Append(group.Name);
            source.Append(" - this is probably a bug in the source code generator.\", e);\r\n");
            source.Append("\t   }\r\n");
            source.Append("\t}\r\n\r\n");
            return source.ToString();
        }

        /// <summary> Returns source code for a JavaDoc snippet listing the contents of a Group
        /// or Message.
        /// </summary>
        public static string MakeElementsDoc(IStructureDef[] structures)
        {
            var elements = new StringBuilder();
            elements.Append("///<ol>\r\n");
            for (var i = 0; i < structures.Length; i++)
            {
                var def = structures[i];
                elements.Append("///<li>");
                elements.Append(i);
                elements.Append(": ");
                elements.Append(def.Name);
                elements.Append(" (");
                elements.Append(def.Description);
                elements.Append(") ");
                if (!def.Required)
                {
                    elements.Append("optional ");
                }

                if (def.Repeating)
                {
                    elements.Append("repeating");
                }

                elements.Append("</li>\r\n");
            }

            elements.Append("///</ol>\r\n");
            return elements.ToString();
        }

        /// <summary> Returns source code for an accessor method for a particular Structure. </summary>
        public static string MakeAccessor(GroupDef group, int structure)
        {
            var source = new StringBuilder();

            var def = group.Structures[structure];

            var name = def.Name;
            var indexName = group.GetIndexName(name);
            var getterName = indexName;

            if (def is GroupDef)
            {
                var unqualifiedName = ((GroupDef)def).UnqualifiedName;
                getterName = group.GetIndexName(unqualifiedName);
            }

            // make accessor for first (or only) rep ...
            source.Append("\t///<summary>\r\n");
            source.Append("\t/// Returns ");
            if (def.Repeating)
            {
                source.Append(" first repetition of ");
            }

            source.Append(indexName);
            source.Append(" (");
            source.Append(def.Description);
            source.Append(") - creates it if necessary\r\n");
            source.Append("\t///</summary>\r\n");
            source.Append("\tpublic ");
            source.Append(def.Name);
            source.Append(" ");
            if (def.Repeating)
            {
                source.Append("Get");
                source.Append(getterName);
                source.Append("() {\r\n");
            }
            else
            {
                source.Append(getterName);
                source.Append(" { \r\n");
                source.Append("get{\r\n");
            }

            source.Append("\t   ");
            source.Append(def.Name);
            source.Append(" ret = null;\r\n");
            source.Append("\t   try {\r\n");
            source.Append("\t      ret = (");
            source.Append(def.Name);
            source.Append(")this.GetStructure(\"");
            source.Append(getterName);
            source.Append("\");\r\n");
            source.Append("\t   } catch(HL7Exception e) {\r\n");
            source.Append(
                "\t      HapiLogFactory.GetHapiLog(GetType()).Error(\"Unexpected error accessing data - this is probably a bug in the source code generator.\", e);\r\n");
            source.Append("\t      throw new System.Exception(\"An unexpected error occurred\",e);\r\n");
            source.Append("\t   }\r\n");
            source.Append("\t   return ret;\r\n");
            if (!def.Repeating)
            {
                source.Append("\t}\r\n");
            }

            source.Append("\t}\r\n\r\n");

            if (def.Repeating)
            {
                // make accessor for specific rep ...
                source.Append("\t///<summary>\r\n");
                source.Append("\t///Returns a specific repetition of ");
                source.Append(indexName);
                source.Append("\r\n");
                source.Append("\t/// * (");
                source.Append(def.Description);
                source.Append(") - creates it if necessary\r\n");
                source.Append("\t/// throws HL7Exception if the repetition requested is more than one \r\n");
                source.Append("\t///     greater than the number of existing repetitions.\r\n");
                source.Append("\t///</summary>\r\n");
                source.Append("\tpublic ");
                source.Append(def.Name);
                source.Append(" Get");
                source.Append(getterName);
                source.Append("(int rep) { \r\n");
                source.Append("\t   return (");
                source.Append(def.Name);
                source.Append(")this.GetStructure(\"");
                source.Append(getterName);
                source.Append("\", rep);\r\n");
                source.Append("\t}\r\n\r\n");

                // make accessor for number of reps
                source.Append("\t/** \r\n");
                source.Append("\t * Returns the number of existing repetitions of ");
                source.Append(indexName);
                source.Append(" \r\n");
                source.Append("\t */ \r\n");
                source.Append("\tpublic int ");
                source.Append(getterName);
                source.Append("RepetitionsUsed { \r\n");
                source.Append("get{\r\n");
                source.Append("\t    int reps = -1; \r\n");
                source.Append("\t    try { \r\n");
                source.Append("\t        reps = this.GetAll(\"");
                source.Append(getterName);
                source.Append("\").Length; \r\n");
                source.Append("\t    } catch (HL7Exception e) { \r\n");
                source.Append(
                    "\t        string message = \"Unexpected error accessing data - this is probably a bug in the source code generator.\"; \r\n");
                source.Append("\t        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); \r\n");
                source.Append("\t        throw new System.Exception(message);\r\n");
                source.Append("\t    } \r\n");
                source.Append("\t    return reps; \r\n");
                source.Append("\t}\r\n");
                source.Append("\t} \r\n\r\n");

                // make enumerator
                source.Append("\t/** \r\n");
                source.Append("\t * Enumerate over the " + def.Name + " results \r\n");
                source.Append("\t */ \r\n");
                source.Append("\tpublic IEnumerable<" + def.Name + "> " + getterName + "s \r\n");
                source.Append("\t{ \r\n");
                source.Append("\t\tget\r\n");
                source.Append("\t\t{\r\n");
                source.Append("\t\t\tfor (int rep = 0; rep < " + getterName + "RepetitionsUsed; rep++)\r\n");
                source.Append("\t\t\t{\r\n");
                source.Append("\t\t\t\tyield return (" + def.Name + ")this.GetStructure(\"" + getterName + "\", rep);\r\n");
                source.Append("\t\t\t}\r\n");
                source.Append("\t\t}\r\n");
                source.Append("\t}\r\n\r\n");

                // make Add function
                source.Append("\t///<summary>\r\n");
                source.Append("\t///Adds a new " + def.Name + "\r\n");
                source.Append("\t///</summary>\r\n");
                source.Append("\tpublic " + def.Name + " Add" + getterName + "()\r\n");
                source.Append("\t{\r\n");
                source.Append("\t\treturn this.AddStructure(\"" + getterName + "\") as " + def.Name + ";\r\n");
                source.Append("\t}\r\n");

                source.Append("\r\n");

                // make Remove function
                source.Append("\t///<summary>\r\n");
                source.Append("\t///Removes the given " + def.Name + "\r\n");
                source.Append("\t///</summary>\r\n");
                source.Append("\tpublic void Remove" + getterName + "(" + def.Name + " toRemove)\r\n");
                source.Append("\t{\r\n");
                source.Append("\t\tthis.RemoveStructure(\"" + getterName + "\", toRemove);\r\n");
                source.Append("\t}\r\n");

                source.Append("\r\n");

                // make Remove At function
                source.Append("\t///<summary>\r\n");
                source.Append("\t///Removes the " + def.Name + " at the given index\r\n");
                source.Append("\t///</summary>\r\n");
                source.Append("\tpublic void Remove" + getterName + "At(int index)\r\n");
                source.Append("\t{\r\n");
                source.Append("\t\tthis.RemoveRepetition(\"" + getterName + "\", index);\r\n");
                source.Append("\t}\r\n");

                source.Append("\r\n");
            }

            return source.ToString();
        }

        /// <summary> Given a list of structures and the position of a SegmentDef that
        /// indicates the start of a group (ie "{" or "["), returns the position
        /// of the corresponding end of the group.  Nested group markers are ignored.
        /// </summary>
        /// <throws>  IllegalArgumentException if groupStart is out of range or does not.  </throws>
        /// <summary>      point to a group opening marker.
        /// </summary>
        /// <throws>  HL7Exception if the end of the group is not found or if other pairs.  </throws>
        /// <summary>      are not properly nested inside this one.
        /// </summary>
        public static int FindGroupEnd(IStructureDef[] structures, int groupStart)
        {
            // {} is rep; [] is optionality
            string endMarker = null;
            try
            {
                var startMarker = structures[groupStart].Name;
                if (startMarker.Equals("["))
                {
                    endMarker = "]";
                }
                else if (startMarker.Equals("{"))
                {
                    endMarker = "}";
                }
                else if (startMarker.Equals("[{"))
                {
                    endMarker = "}]";
                }
                else
                {
                    Log.Error("Problem starting at " + groupStart);
                    for (var i = 0; i < structures.Length; i++)
                    {
                        Log.Error("Structure " + i + ": " + structures[i].Name);
                    }

                    throw new ArgumentException("The segment " + startMarker + " does not begin a group - must be [ or {");
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new ArgumentException("The given start location is out of bounds");
            }

            // loop, increment and decrement opening and closing markers until we get back to 0
            string segName = null;
            var offset = 0;
            try
            {
                var nestedInside = 1;
                while (nestedInside > 0)
                {
                    offset++;
                    segName = structures[groupStart + offset].Name;
                    if (segName.Equals("{") || segName.Equals("[") || segName.Equals("[{"))
                    {
                        nestedInside++;
                    }
                    else if (segName.Equals("}") || segName.Equals("]") || segName.Equals("}]"))
                    {
                        nestedInside--;
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new HL7Exception("Couldn't find end of group", ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            if (!endMarker.Equals(segName))
            {
                throw new HL7Exception("Group markers are not nested properly", ErrorCode.APPLICATION_INTERNAL_ERROR);
            }

            return groupStart + offset;
        }

        /// <summary> Returns true if opening is "[{" and closing is "}]".</summary>
        private static bool RepoptMarkers(string opening, string closing)
        {
            var ret = false;
            if (opening.Equals("[{") && closing.Equals("}]"))
            {
                ret = true;
            }

            return ret;
        }

        /// <summary> Returns true if opening is "[" and closing is "]".</summary>
        private static bool OptMarkers(string opening, string closing)
        {
            var ret = false;
            if (opening.Equals("[") && closing.Equals("]"))
            {
                ret = true;
            }

            return ret;
        }

        /// <summary> Returns true if opening is "{" and closing is "}".</summary>
        private static bool RepMarkers(string opening, string closing)
        {
            var ret = false;
            if (opening.Equals("{") && closing.Equals("}"))
            {
                ret = true;
            }

            return ret;
        }
    }
}