using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V21.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V21.Group
{
///<summary>
///Represents the ORU_R03_PATIENT_RESULT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORU_R03_PATIENT (a Group object) optional </li>
///<li>1: ORU_R03_ORDER_OBSERVATION (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORU_R03_PATIENT_RESULT : AbstractGroup {

	///<summary> 
	/// Creates a new ORU_R03_PATIENT_RESULT Group.
	///</summary>
	public ORU_R03_PATIENT_RESULT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORU_R03_PATIENT), false, false);
	      this.add(typeof(ORU_R03_ORDER_OBSERVATION), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORU_R03_PATIENT_RESULT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORU_R03_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORU_R03_PATIENT PATIENT { 
get{
	   ORU_R03_PATIENT ret = null;
	   try {
	      ret = (ORU_R03_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORU_R03_ORDER_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public ORU_R03_ORDER_OBSERVATION GetORDER_OBSERVATION() {
	   ORU_R03_ORDER_OBSERVATION ret = null;
	   try {
	      ret = (ORU_R03_ORDER_OBSERVATION)this.GetStructure("ORDER_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORU_R03_ORDER_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORU_R03_ORDER_OBSERVATION GetORDER_OBSERVATION(int rep) { 
	   return (ORU_R03_ORDER_OBSERVATION)this.GetStructure("ORDER_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORU_R03_ORDER_OBSERVATION 
	 */ 
	public int ORDER_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER_OBSERVATION").Length; 
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
