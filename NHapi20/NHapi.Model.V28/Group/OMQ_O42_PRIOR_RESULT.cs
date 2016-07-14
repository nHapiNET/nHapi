using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the OMQ_O42_PRIOR_RESULT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OMQ_O42_PATIENT_PRIOR (a Group object) optional </li>
///<li>1: OMQ_O42_PATIENT_VISIT_PRIOR (a Group object) optional </li>
///<li>2: AL1 (Patient Allergy Information) optional repeating</li>
///<li>3: OMQ_O42_ORDER_PRIOR (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OMQ_O42_PRIOR_RESULT : AbstractGroup {

	///<summary> 
	/// Creates a new OMQ_O42_PRIOR_RESULT Group.
	///</summary>
	public OMQ_O42_PRIOR_RESULT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OMQ_O42_PATIENT_PRIOR), false, false);
	      this.add(typeof(OMQ_O42_PATIENT_VISIT_PRIOR), false, false);
	      this.add(typeof(AL1), false, true);
	      this.add(typeof(OMQ_O42_ORDER_PRIOR), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OMQ_O42_PRIOR_RESULT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns OMQ_O42_PATIENT_PRIOR (a Group object) - creates it if necessary
	///</summary>
	public OMQ_O42_PATIENT_PRIOR PATIENT_PRIOR { 
get{
	   OMQ_O42_PATIENT_PRIOR ret = null;
	   try {
	      ret = (OMQ_O42_PATIENT_PRIOR)this.GetStructure("PATIENT_PRIOR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns OMQ_O42_PATIENT_VISIT_PRIOR (a Group object) - creates it if necessary
	///</summary>
	public OMQ_O42_PATIENT_VISIT_PRIOR PATIENT_VISIT_PRIOR { 
get{
	   OMQ_O42_PATIENT_VISIT_PRIOR ret = null;
	   try {
	      ret = (OMQ_O42_PATIENT_VISIT_PRIOR)this.GetStructure("PATIENT_VISIT_PRIOR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of AL1 (Patient Allergy Information) - creates it if necessary
	///</summary>
	public AL1 GetAL1() {
	   AL1 ret = null;
	   try {
	      ret = (AL1)this.GetStructure("AL1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of AL1
	/// * (Patient Allergy Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public AL1 GetAL1(int rep) { 
	   return (AL1)this.GetStructure("AL1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of AL1 
	 */ 
	public int AL1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("AL1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of OMQ_O42_ORDER_PRIOR (a Group object) - creates it if necessary
	///</summary>
	public OMQ_O42_ORDER_PRIOR GetORDER_PRIOR() {
	   OMQ_O42_ORDER_PRIOR ret = null;
	   try {
	      ret = (OMQ_O42_ORDER_PRIOR)this.GetStructure("ORDER_PRIOR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OMQ_O42_ORDER_PRIOR
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OMQ_O42_ORDER_PRIOR GetORDER_PRIOR(int rep) { 
	   return (OMQ_O42_ORDER_PRIOR)this.GetStructure("ORDER_PRIOR", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OMQ_O42_ORDER_PRIOR 
	 */ 
	public int ORDER_PRIORRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER_PRIOR").Length; 
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
