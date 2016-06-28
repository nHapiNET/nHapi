using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V281.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the CCM_I21_RESOURCE_DETAIL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: AIS (Appointment Information) </li>
///<li>1: AIG (Appointment Information - General Resource) </li>
///<li>2: AIL (Appointment Information - Location Resource) </li>
///<li>3: AIP (Appointment Information - Personnel Resource) </li>
///<li>4: CCM_I21_RESOURCE_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCM_I21_RESOURCE_DETAIL : AbstractGroup {

	///<summary> 
	/// Creates a new CCM_I21_RESOURCE_DETAIL Group.
	///</summary>
	public CCM_I21_RESOURCE_DETAIL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(AIS), true, false);
	      this.add(typeof(AIG), true, false);
	      this.add(typeof(AIL), true, false);
	      this.add(typeof(AIP), true, false);
	      this.add(typeof(CCM_I21_RESOURCE_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCM_I21_RESOURCE_DETAIL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns AIS (Appointment Information) - creates it if necessary
	///</summary>
	public AIS AIS { 
get{
	   AIS ret = null;
	   try {
	      ret = (AIS)this.GetStructure("AIS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIG (Appointment Information - General Resource) - creates it if necessary
	///</summary>
	public AIG AIG { 
get{
	   AIG ret = null;
	   try {
	      ret = (AIG)this.GetStructure("AIG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIL (Appointment Information - Location Resource) - creates it if necessary
	///</summary>
	public AIL AIL { 
get{
	   AIL ret = null;
	   try {
	      ret = (AIL)this.GetStructure("AIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIP (Appointment Information - Personnel Resource) - creates it if necessary
	///</summary>
	public AIP AIP { 
get{
	   AIP ret = null;
	   try {
	      ret = (AIP)this.GetStructure("AIP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_RESOURCE_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_RESOURCE_OBSERVATION GetRESOURCE_OBSERVATION() {
	   CCM_I21_RESOURCE_OBSERVATION ret = null;
	   try {
	      ret = (CCM_I21_RESOURCE_OBSERVATION)this.GetStructure("RESOURCE_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_RESOURCE_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_RESOURCE_OBSERVATION GetRESOURCE_OBSERVATION(int rep) { 
	   return (CCM_I21_RESOURCE_OBSERVATION)this.GetStructure("RESOURCE_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_RESOURCE_OBSERVATION 
	 */ 
	public int RESOURCE_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RESOURCE_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

}
}
