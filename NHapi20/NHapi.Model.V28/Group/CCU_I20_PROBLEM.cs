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
///Represents the CCU_I20_PROBLEM Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PRB (Problem Details) </li>
///<li>1: VAR (Variance) optional repeating</li>
///<li>2: CCU_I20_ROLE_PROBLEM (a Group object) optional repeating</li>
///<li>3: CCU_I20_PROBLEM_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCU_I20_PROBLEM : AbstractGroup {

	///<summary> 
	/// Creates a new CCU_I20_PROBLEM Group.
	///</summary>
	public CCU_I20_PROBLEM(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PRB), true, false);
	      this.add(typeof(VAR), false, true);
	      this.add(typeof(CCU_I20_ROLE_PROBLEM), false, true);
	      this.add(typeof(CCU_I20_PROBLEM_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCU_I20_PROBLEM - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PRB (Problem Details) - creates it if necessary
	///</summary>
	public PRB PRB { 
get{
	   PRB ret = null;
	   try {
	      ret = (PRB)this.GetStructure("PRB");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of VAR (Variance) - creates it if necessary
	///</summary>
	public VAR GetVAR() {
	   VAR ret = null;
	   try {
	      ret = (VAR)this.GetStructure("VAR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of VAR
	/// * (Variance) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public VAR GetVAR(int rep) { 
	   return (VAR)this.GetStructure("VAR", rep);
	}

	/** 
	 * Returns the number of existing repetitions of VAR 
	 */ 
	public int VARRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("VAR").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of CCU_I20_ROLE_PROBLEM (a Group object) - creates it if necessary
	///</summary>
	public CCU_I20_ROLE_PROBLEM GetROLE_PROBLEM() {
	   CCU_I20_ROLE_PROBLEM ret = null;
	   try {
	      ret = (CCU_I20_ROLE_PROBLEM)this.GetStructure("ROLE_PROBLEM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCU_I20_ROLE_PROBLEM
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCU_I20_ROLE_PROBLEM GetROLE_PROBLEM(int rep) { 
	   return (CCU_I20_ROLE_PROBLEM)this.GetStructure("ROLE_PROBLEM", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCU_I20_ROLE_PROBLEM 
	 */ 
	public int ROLE_PROBLEMRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ROLE_PROBLEM").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of CCU_I20_PROBLEM_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public CCU_I20_PROBLEM_OBSERVATION GetPROBLEM_OBSERVATION() {
	   CCU_I20_PROBLEM_OBSERVATION ret = null;
	   try {
	      ret = (CCU_I20_PROBLEM_OBSERVATION)this.GetStructure("PROBLEM_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCU_I20_PROBLEM_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCU_I20_PROBLEM_OBSERVATION GetPROBLEM_OBSERVATION(int rep) { 
	   return (CCU_I20_PROBLEM_OBSERVATION)this.GetStructure("PROBLEM_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCU_I20_PROBLEM_OBSERVATION 
	 */ 
	public int PROBLEM_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PROBLEM_OBSERVATION").Length; 
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
