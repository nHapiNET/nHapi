using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
///<summary>
///Represents the MFN_M10_MF_TEST_BATTERIES Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFE (MFE - master file entry segment) </li>
///<li>1: OM1 (OM1 - general segment (fields that apply to most observations)) </li>
///<li>2: MFN_M10_MF_TEST_BATT_DETAIL (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class MFN_M10_MF_TEST_BATTERIES : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M10_MF_TEST_BATTERIES Group.
	///</summary>
	public MFN_M10_MF_TEST_BATTERIES(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFE), true, false);
	      this.add(typeof(OM1), true, false);
	      this.add(typeof(MFN_M10_MF_TEST_BATT_DETAIL), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M10_MF_TEST_BATTERIES - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns MFE (MFE - master file entry segment) - creates it if necessary
	///</summary>
	public MFE MFE { 
get{
	   MFE ret = null;
	   try {
	      ret = (MFE)this.GetStructure("MFE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns OM1 (OM1 - general segment (fields that apply to most observations)) - creates it if necessary
	///</summary>
	public OM1 OM1 { 
get{
	   OM1 ret = null;
	   try {
	      ret = (OM1)this.GetStructure("OM1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns MFN_M10_MF_TEST_BATT_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public MFN_M10_MF_TEST_BATT_DETAIL MF_TEST_BATT_DETAIL { 
get{
	   MFN_M10_MF_TEST_BATT_DETAIL ret = null;
	   try {
	      ret = (MFN_M10_MF_TEST_BATT_DETAIL)this.GetStructure("MF_TEST_BATT_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
