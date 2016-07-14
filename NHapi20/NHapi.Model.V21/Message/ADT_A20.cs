using System;
using NHapi.Base.Log;
using NHapi.Model.V21.Group;
using NHapi.Model.V21.Segment;
using NHapi.Model.V21.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V21.Message

{
///<summary>
/// Represents a ADT_A20 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MESSAGE HEADER) </li>
///<li>1: EVN (EVENT TYPE) </li>
///<li>2: NPU (NON-PATIENT UPDATE) </li>
///</ol>
///</summary>
[Serializable]
public class ADT_A20 : AbstractMessage  {

	///<summary> 
	/// Creates a new ADT_A20 Group with custom IModelClassFactory.
	///</summary>
	public ADT_A20(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new ADT_A20 Group with DefaultModelClassFactory. 
	///</summary> 
	public ADT_A20() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for ADT_A20.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(EVN), true, false);
	      this.add(typeof(NPU), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ADT_A20 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MESSAGE HEADER) - creates it if necessary
	///</summary>
	public MSH MSH { 
get{
	   MSH ret = null;
	   try {
	      ret = (MSH)this.GetStructure("MSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns EVN (EVENT TYPE) - creates it if necessary
	///</summary>
	public EVN EVN { 
get{
	   EVN ret = null;
	   try {
	      ret = (EVN)this.GetStructure("EVN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns NPU (NON-PATIENT UPDATE) - creates it if necessary
	///</summary>
	public NPU NPU { 
get{
	   NPU ret = null;
	   try {
	      ret = (NPU)this.GetStructure("NPU");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
