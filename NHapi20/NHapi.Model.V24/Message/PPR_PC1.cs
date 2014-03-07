using System;
using NHapi.Base.Log;
using NHapi.Model.V24.Group;
using NHapi.Model.V24.Segment;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V24.Message

{
///<summary>
/// Represents a PPR_PC1 message structure (see chapter 12). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: PID (Patient identification) </li>
///<li>2: PPR_PC1_PATIENT_VISIT (a Group object) optional </li>
///<li>3: PPR_PC1_PROBLEM (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class PPR_PC1 : AbstractMessage  {

	///<summary> 
	/// Creates a new PPR_PC1 Group with custom IModelClassFactory.
	///</summary>
	public PPR_PC1(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new PPR_PC1 Group with DefaultModelClassFactory. 
	///</summary> 
	public PPR_PC1() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for PPR_PC1.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PPR_PC1_PATIENT_VISIT), false, false);
	      this.add(typeof(PPR_PC1_PROBLEM), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PPR_PC1 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (Message Header) - creates it if necessary
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
	/// Returns PID (Patient identification) - creates it if necessary
	///</summary>
	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PPR_PC1_PATIENT_VISIT (a Group object) - creates it if necessary
	///</summary>
	public PPR_PC1_PATIENT_VISIT PATIENT_VISIT { 
get{
	   PPR_PC1_PATIENT_VISIT ret = null;
	   try {
	      ret = (PPR_PC1_PATIENT_VISIT)this.GetStructure("PATIENT_VISIT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PPR_PC1_PROBLEM (a Group object) - creates it if necessary
	///</summary>
	public PPR_PC1_PROBLEM GetPROBLEM() {
	   PPR_PC1_PROBLEM ret = null;
	   try {
	      ret = (PPR_PC1_PROBLEM)this.GetStructure("PROBLEM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PPR_PC1_PROBLEM
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PPR_PC1_PROBLEM GetPROBLEM(int rep) { 
	   return (PPR_PC1_PROBLEM)this.GetStructure("PROBLEM", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PPR_PC1_PROBLEM 
	 */ 
	public int PROBLEMRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PROBLEM").Length; 
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
