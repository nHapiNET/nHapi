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
///Represents the CCU_I20_GOAL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: GOL (Goal Detail) </li>
///<li>1: VAR (Variance) optional repeating</li>
///<li>2: CCU_I20_ROLE_GOAL (a Group object) optional repeating</li>
///<li>3: CCU_I20_GOAL_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCU_I20_GOAL : AbstractGroup {

	///<summary> 
	/// Creates a new CCU_I20_GOAL Group.
	///</summary>
	public CCU_I20_GOAL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(GOL), true, false);
	      this.add(typeof(VAR), false, true);
	      this.add(typeof(CCU_I20_ROLE_GOAL), false, true);
	      this.add(typeof(CCU_I20_GOAL_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCU_I20_GOAL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns GOL (Goal Detail) - creates it if necessary
	///</summary>
	public GOL GOL { 
get{
	   GOL ret = null;
	   try {
	      ret = (GOL)this.GetStructure("GOL");
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
	/// Returns  first repetition of CCU_I20_ROLE_GOAL (a Group object) - creates it if necessary
	///</summary>
	public CCU_I20_ROLE_GOAL GetROLE_GOAL() {
	   CCU_I20_ROLE_GOAL ret = null;
	   try {
	      ret = (CCU_I20_ROLE_GOAL)this.GetStructure("ROLE_GOAL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCU_I20_ROLE_GOAL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCU_I20_ROLE_GOAL GetROLE_GOAL(int rep) { 
	   return (CCU_I20_ROLE_GOAL)this.GetStructure("ROLE_GOAL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCU_I20_ROLE_GOAL 
	 */ 
	public int ROLE_GOALRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ROLE_GOAL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of CCU_I20_GOAL_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public CCU_I20_GOAL_OBSERVATION GetGOAL_OBSERVATION() {
	   CCU_I20_GOAL_OBSERVATION ret = null;
	   try {
	      ret = (CCU_I20_GOAL_OBSERVATION)this.GetStructure("GOAL_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCU_I20_GOAL_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCU_I20_GOAL_OBSERVATION GetGOAL_OBSERVATION(int rep) { 
	   return (CCU_I20_GOAL_OBSERVATION)this.GetStructure("GOAL_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCU_I20_GOAL_OBSERVATION 
	 */ 
	public int GOAL_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("GOAL_OBSERVATION").Length; 
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
