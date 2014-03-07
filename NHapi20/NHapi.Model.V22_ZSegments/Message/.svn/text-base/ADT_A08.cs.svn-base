using System;
using NHapi.Base.Log;
using NHapi.Model.V22.Group;
using NHapi.Model.V22.Segment;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V22_ZSegments.Segment;

namespace NHapi.Model.V22_ZSegments.Message
{
	/// <summary>
	/// Represents a ADT_A08 message with a custom ZIN segment.
	/// </summary>
	public class ADT_A08 : NHapi.Model.V22.Message.ADT_A08 
	{
		#region Constructor
		
		/** 
		 * Creates a new ADT_A08 Group with custom IModelClassFactory.
		 */
		public ADT_A08(IModelClassFactory factory) : base(factory){
		   init(factory);
		}
	
		/**
		 * Creates a new ADT_A08 Group with DefaultModelClassFactory. 
		 */ 
		public ADT_A08() : base(new DefaultModelClassFactory()) { 
		   init(new DefaultModelClassFactory());
		}
	
		private void init(IModelClassFactory factory) {
		   try 
		   {
		      this.add(typeof(ZIN),false,false);
		   } 
		   catch(HL7Exception e)
		   {
		      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ADT_A08 - this is probably a bug in the source code generator.", e);
		   }
		}				
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Returns ZIN (Additional insurance data) - creates it if necessary
		/// </summary>
		virtual public ZIN ZIN
		{
			get
			{
				ZIN ret = null;
				try
				{
					ret = (ZIN) this.GetStructure("ZIN");
				}
				catch (HL7Exception e)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
					throw new System.Exception("An unexpected error ocurred",e);
				}
				return ret;
			}
		}	
		
		#endregion
	}
}
