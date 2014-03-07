/* <summary>The contents of this file are subject to the Mozilla Public License Version 1.1 
/// (the "License"); you may not use this file except in compliance with the License. 
/// You may obtain a copy of the License at http://www.mozilla.org/MPL/ 
/// Software distributed under the License is distributed on an "AS IS" basis, 
/// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for the 
/// specific language governing rights and limitations under the License. 
/// The Original Code is "AbstractMessage.java".  Description: 
/// "A default implementation of Message" 
/// The Initial Developer of the Original Code is University Health Network. Copyright (C) 
/// 2001.  All Rights Reserved. 
/// Contributor(s): ______________________________________. 
/// Alternatively, the contents of this file may be used under the terms of the 
/// GNU General Public License (the  “GPL”), in which case the provisions of the GPL are 
/// applicable instead of those above.  If you wish to allow use of your version of this 
/// file only under the terms of the GPL and not to allow others to use your version 
/// of this file under the MPL, indicate your decision by deleting  the provisions above 
/// and replace  them with the notice and other provisions required by the GPL License.  
/// If you do not delete the provisions above, a recipient may use your version of 
/// this file under either the MPL or the GPL. 
*/
using System;
using NHapi.Base.Parser;
using NHapi.Base.validation;
using System.Text.RegularExpressions;

namespace NHapi.Base.Model
{

    /// <summary> A default implementation of Message. </summary>
    /// <author>  Bryan Tripp (bryan_tripp@sourceforge.net)
    /// </author>
    public abstract class AbstractMessage : AbstractGroup, IMessage
    {
        /// <summary> Returns this Message object - this is an implementation of the 
        /// abstract method in AbstractGroup.  
        /// </summary>
        override public IMessage Message
        {
            get
            {
                return this;
            }

        }
        /// <summary> Returns the version number.  This default implementation inspects 
        /// this.GetClass().getName().  This should be overridden if you are putting
        /// a custom message definition in your own package, or it will default.  
        /// </summary>
        /// <returns>s 2.4 if not obvious from package name
        /// </returns>
        virtual public System.String Version
        {
            get
            {
                System.String version = null;

                // TODO: Revisit.

                Regex p = new Regex("\\.(V2[0-9][0-9]?)\\.");
                Match m = p.Match(this.GetType().FullName);
                if (m.Success)
                {
                    System.String verFolder = m.Groups[1].Value;
                    if (verFolder.Length > 0)
                    {
                        char[] chars = verFolder.ToCharArray();
                        System.Text.StringBuilder buf = new System.Text.StringBuilder();
                        for (int i = 1; i < chars.Length; i++)
                        {
                            //start at 1 to avoid the 'v'
                            buf.Append(chars[i]);
                            if (i < chars.Length - 1)
                                buf.Append('.');
                        }
                        version = buf.ToString();
                    }
                }

                if (version == null)
                    version = "2.4";

                return version;
            }

        }

        /// <summary>
        /// The validation contect 
        /// </summary>
        virtual public IValidationContext ValidationContext
        {
            get
            {
                return myContext;
            }

            set
            {
                myContext = value;
            }

        }

        private IValidationContext myContext;

        /// <param name="theFactory">factory for model classes (e.g. group, segment) for this message 
        /// </param>
        public AbstractMessage(IModelClassFactory theFactory)
            : base(theFactory)
        {
        }
    }
}