using System;
using NHapi.Base;
using NHapi.Base.Log;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V251.Segment;

namespace NHapi.Model.V251.Message
{
    [Serializable]
    public class OSU_O51 : AbstractMessage
    {
        private MSH _msh;
        private PID _pid;
        private ORC _orc;

        public MSH MSH => _msh ?? (_msh = (MSH)GetStructure("MSH"));

        public PID PID
        {
            get => _pid ?? (_pid = (PID)GetStructure("PID"));
            set => _pid = value;
        }

        public ORC ORC => _orc ?? (_orc = (ORC)GetStructure("ORC"));

        public OSU_O51(IModelClassFactory theFactory) : base(theFactory)
        {
            init(theFactory);
        }

        public OSU_O51() : base(new DefaultModelClassFactory())
        {
            init(new DefaultModelClassFactory());
        }

        ///<summary>
        /// initalize method for OSU_O51.  This does the segment setup for the message. 
        ///</summary> 
        private void init(IModelClassFactory factory)
        {
            try
            {
                add(typeof(MSH), true, false);
                add(typeof(PID), false, true);
                add(typeof(ORC), false, true);
            }
            catch (HL7Exception e)
            {
                HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OSU_O51 - this is probably a bug in the source code generator.", e);
            }
        }

        public override string Version => Constants.VERSION;
    }
}
