using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V23UCH.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V23UCH.Group
{
///<summary>
///Represents the SIU_S24_REG_INSURANCE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ZN1 (Registration Insurance Info) </li>
///<li>1: ZN2 (Registration Insurance Info) optional </li>
///<li>2: ZN3 (Registration Insurance Info) optional </li>
///</ol>
///</summary>
[Serializable]
public class SIU_S24_REG_INSURANCE : AbstractGroup {

	///<summary> 
	/// Creates a new SIU_S24_REG_INSURANCE Group.
	///</summary>
	public SIU_S24_REG_INSURANCE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ZN1), true, false);
	      this.add(typeof(ZN2), false, false);
	      this.add(typeof(ZN3), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SIU_S24_REG_INSURANCE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ZN1 (Registration Insurance Info) - creates it if necessary
	///</summary>
	public ZN1 ZN1 { 
get{
	   ZN1 ret = null;
	   try {
	      ret = (ZN1)this.GetStructure("ZN1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ZN2 (Registration Insurance Info) - creates it if necessary
	///</summary>
	public ZN2 ZN2 { 
get{
	   ZN2 ret = null;
	   try {
	      ret = (ZN2)this.GetStructure("ZN2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ZN3 (Registration Insurance Info) - creates it if necessary
	///</summary>
	public ZN3 ZN3 { 
get{
	   ZN3 ret = null;
	   try {
	      ret = (ZN3)this.GetStructure("ZN3");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
