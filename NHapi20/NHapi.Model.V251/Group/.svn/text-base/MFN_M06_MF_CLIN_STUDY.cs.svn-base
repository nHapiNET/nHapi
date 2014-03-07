using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the MFN_M06_MF_CLIN_STUDY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFE (Master File Entry) </li>
///<li>1: CM0 (Clinical Study Master) </li>
///<li>2: MFN_M06_MF_PHASE_SCHED_DETAIL (a Group object) </li>
///</ol>
///</summary>
[Serializable]
public class MFN_M06_MF_CLIN_STUDY : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M06_MF_CLIN_STUDY Group.
	///</summary>
	public MFN_M06_MF_CLIN_STUDY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFE), true, false);
	      this.add(typeof(CM0), true, false);
	      this.add(typeof(MFN_M06_MF_PHASE_SCHED_DETAIL), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M06_MF_CLIN_STUDY - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns MFE (Master File Entry) - creates it if necessary
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
	/// Returns CM0 (Clinical Study Master) - creates it if necessary
	///</summary>
	public CM0 CM0 { 
get{
	   CM0 ret = null;
	   try {
	      ret = (CM0)this.GetStructure("CM0");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns MFN_M06_MF_PHASE_SCHED_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public MFN_M06_MF_PHASE_SCHED_DETAIL MF_PHASE_SCHED_DETAIL { 
get{
	   MFN_M06_MF_PHASE_SCHED_DETAIL ret = null;
	   try {
	      ret = (MFN_M06_MF_PHASE_SCHED_DETAIL)this.GetStructure("MF_PHASE_SCHED_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
