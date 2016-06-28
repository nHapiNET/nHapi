using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V271.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V271.Group
{
///<summary>
///Represents the MFN_M11_MF_TEST_CALC_DETAIL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OM6 (Observations that are Calculated from Other Observations) </li>
///<li>1: OM2 (Numeric Observation) </li>
///</ol>
///</summary>
[Serializable]
public class MFN_M11_MF_TEST_CALC_DETAIL : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M11_MF_TEST_CALC_DETAIL Group.
	///</summary>
	public MFN_M11_MF_TEST_CALC_DETAIL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OM6), true, false);
	      this.add(typeof(OM2), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M11_MF_TEST_CALC_DETAIL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns OM6 (Observations that are Calculated from Other Observations) - creates it if necessary
	///</summary>
	public OM6 OM6 { 
get{
	   OM6 ret = null;
	   try {
	      ret = (OM6)this.GetStructure("OM6");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns OM2 (Numeric Observation) - creates it if necessary
	///</summary>
	public OM2 OM2 { 
get{
	   OM2 ret = null;
	   try {
	      ret = (OM2)this.GetStructure("OM2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
