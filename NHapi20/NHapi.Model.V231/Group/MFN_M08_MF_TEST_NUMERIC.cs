using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V231.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
///<summary>
///Represents the MFN_M08_MF_TEST_NUMERIC Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFE (MFE - master file entry segment) </li>
///<li>1: OM1 (OM1 - general segment (fields that apply to most observations)) optional </li>
///<li>2: MFN_M08_MF_NUMERIC_OBSERVATION (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class MFN_M08_MF_TEST_NUMERIC : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M08_MF_TEST_NUMERIC Group.
	///</summary>
	public MFN_M08_MF_TEST_NUMERIC(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFE), true, false);
	      this.add(typeof(OM1), false, false);
	      this.add(typeof(MFN_M08_MF_NUMERIC_OBSERVATION), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M08_MF_TEST_NUMERIC - this is probably a bug in the source code generator.", e);
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
	/// Returns MFN_M08_MF_NUMERIC_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public MFN_M08_MF_NUMERIC_OBSERVATION MF_NUMERIC_OBSERVATION { 
get{
	   MFN_M08_MF_NUMERIC_OBSERVATION ret = null;
	   try {
	      ret = (MFN_M08_MF_NUMERIC_OBSERVATION)this.GetStructure("MF_NUMERIC_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
