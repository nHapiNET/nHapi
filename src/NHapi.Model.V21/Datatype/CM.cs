using System;
using System.Collections.Generic;
using System.Text;
using NHapi.Base.Model.Primitive;
using NHapi.Base.Model;

namespace NHapi.Model.V21.Datatype
{
    /// <summary>
    /// Composite message
    /// </summary>
    public class CM : GenericComposite
    {

        /// <summary>
        /// Composite message
        /// </summary>
        /// <param name="message"></param>
        public CM(IMessage message)
            : base(message)
        {
        }
    }
}
