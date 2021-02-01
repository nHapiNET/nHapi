/*
  The contents of this file are subject to the Mozilla Public License Version 1.1
  (the "License"); you may not use this file except in compliance with the License.
  You may obtain a copy of the License at http://www.mozilla.org/MPL/
  Software distributed under the License is distributed on an "AS IS" basis,
  WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the
  specific language governing rights and limitations under the License.

  The Original Code is "EncodingCharacters.java".  Description:
  "Represents the set of special characters used to encode traditionally
  encoded HL7 messages"

  The Initial Developer of the Original Code is University Health Network. Copyright (C)
  2001.  All Rights Reserved.

  Contributor(s): ______________________________________.

  Alternatively, the contents of this file may be used under the terms of the
  GNU General Public License (the "GPL"), in which case the provisions of the GPL are
  applicable instead of those above.  If you wish to allow use of your version of this
  file only under the terms of the GPL and not to allow others to use your version
  of this file under the MPL, indicate your decision by deleting  the provisions above
  and replace  them with the notice and other provisions required by the GPL License.
  If you do not delete the provisions above, a recipient may use your version of
  this file under either the MPL or the GPL.
*/

using System;
using System.Text;

namespace NHapi.Base.Parser
{
   /// <summary>
   /// Represents the set of special characters used to encode traditionally
   /// encoded HL7 messages.
   /// </summary>
   /// <author>Bryan Tripp (bryan_tripp@sourceforge.net)</author>
   public class EncodingCharacters : Object, ICloneable
    {
        /// <summary>
        /// Returns the field separator.
        ///
        /// </summary>
        public virtual char FieldSeparator
        {
            get { return fieldSep; }

            set { fieldSep = value; }
        }

        /// <summary>
        /// Returns the component separator.
        ///
        /// </summary>
        public virtual char ComponentSeparator
        {
            get { return encChars[0]; }

            set { encChars[0] = value; }
        }

        /// <summary>
        /// Returns the repetition separator.
        ///
        /// </summary>
        public virtual char RepetitionSeparator
        {
            get { return encChars[1]; }

            set { encChars[1] = value; }
        }

        /// <summary>
        /// Returns the escape character.
        ///
        /// </summary>
        public virtual char EscapeCharacter
        {
            get { return encChars[2]; }

            set { encChars[2] = value; }
        }

        /// <summary>
        /// Returns the subcomponent separator.
        ///
        /// </summary>
        public virtual char SubcomponentSeparator
        {
            get { return encChars[3]; }

            set { encChars[3] = value; }
        }


        private char fieldSep;

        private char[] encChars;


        /// <summary>
        /// Creates new EncodingCharacters object with the given character
        /// values. If the encodingCharacters argument is null, the default
        /// values are used.
        /// </summary>
        /// <param name="fieldSeparator">The field separator.</param>
        /// <param name="encodingCharacters">
        /// Consists of the characters that appear in
        /// MSH-2 (see section 2.8 of the HL7 spec). The characters are
        /// Component Separator, Repetition Separator, Escape Character, and
        /// Subcomponent Separator (in that order).
        /// </param>
        public EncodingCharacters(char fieldSeparator, String encodingCharacters)
        {
            fieldSep = fieldSeparator;

            encChars = new char[4];

            if (encodingCharacters == null)
            {
                encChars[0] = '^';

                encChars[1] = '~';

                encChars[2] = '\\';

                encChars[3] = '&';
            }
            else
            {
                SupportClass.GetCharsFromString(encodingCharacters, 0, 4, encChars, 0);
            }
        }


        public EncodingCharacters(char fieldSeparator, char componentSeparator, char repetitionSeparator, char escapeCharacter,
            char subcomponentSeparator)
            : this(
                fieldSeparator, Convert.ToString(componentSeparator) + repetitionSeparator + escapeCharacter + subcomponentSeparator
                )
        {
        }


        /// <summary>copies contents of "other" </summary>
        public EncodingCharacters(EncodingCharacters other)
        {
            fieldSep = other.FieldSeparator;

            encChars = new char[4];

            encChars[0] = other.ComponentSeparator;

            encChars[1] = other.RepetitionSeparator;

            encChars[2] = other.EscapeCharacter;

            encChars[3] = other.SubcomponentSeparator;
        }

        /// <summary>
        /// Returns the encoding characters (not including field separator)
        ///
        /// as a string.
        ///
        /// </summary>
        public override String ToString()
        {
            StringBuilder ret = new StringBuilder();

            for (int i = 0; i < encChars.Length; i++)
            {
                ret.Append(encChars[i]);
            }

            return ret.ToString();
        }

        public virtual Object Clone()
        {
            return new EncodingCharacters(this);
        }

        public override bool Equals(Object o)
        {
            if (o is EncodingCharacters)
            {
                EncodingCharacters other = (EncodingCharacters)o;
                if (FieldSeparator == other.FieldSeparator && ComponentSeparator == other.ComponentSeparator &&
                     EscapeCharacter == other.EscapeCharacter && RepetitionSeparator == other.RepetitionSeparator &&
                     SubcomponentSeparator == other.SubcomponentSeparator)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return 7 * (int)ComponentSeparator * (int)EscapeCharacter * (int)FieldSeparator * (int)RepetitionSeparator *
                     (int)SubcomponentSeparator;
        }
    }
}