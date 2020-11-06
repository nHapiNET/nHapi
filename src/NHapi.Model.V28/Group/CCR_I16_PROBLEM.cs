using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the CCR_I16_PROBLEM Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PRB (Problem Details) </li>
///<li>1: VAR (Variance) optional repeating</li>
///<li>2: CCR_I16_ROLE_PROBLEM (a Group object) optional repeating</li>
///<li>3: CCR_I16_ROLE_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCR_I16_PROBLEM : AbstractGroup {

	///<summary> 
	/// Creates a new CCR_I16_PROBLEM Group.
	///</summary>
	public CCR_I16_PROBLEM(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PRB), true, false);
	      this.add(typeof(VAR), false, true);
	      this.add(typeof(CCR_I16_ROLE_PROBLEM), false, true);
	      this.add(typeof(CCR_I16_ROLE_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCR_I16_PROBLEM - this is probably a bug in the source code generator.", e);
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

	/** 
	 * Enumerate over the VAR results 
	 */ 
	public IEnumerable<VAR> VARs 
	{ 
		get
		{
			for (int rep = 0; rep < VARRepetitionsUsed; rep++)
			{
				yield return (VAR)this.GetStructure("VAR", rep);
			}
		}
	}

	///<summary>
	///Adds a new VAR
	///</summary>
	public VAR AddVAR()
	{
		return this.AddStructure("VAR") as VAR;
	}

	///<summary>
	///Removes the given VAR
	///</summary>
	public void RemoveVAR(VAR toRemove)
	{
		this.RemoveStructure("VAR", toRemove);
	}

	///<summary>
	///Removes the VAR at the given index
	///</summary>
	public void RemoveVARAt(int index)
	{
		this.RemoveRepetition("VAR", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_ROLE_PROBLEM (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_ROLE_PROBLEM GetROLE_PROBLEM() {
	   CCR_I16_ROLE_PROBLEM ret = null;
	   try {
	      ret = (CCR_I16_ROLE_PROBLEM)this.GetStructure("ROLE_PROBLEM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_ROLE_PROBLEM
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_ROLE_PROBLEM GetROLE_PROBLEM(int rep) { 
	   return (CCR_I16_ROLE_PROBLEM)this.GetStructure("ROLE_PROBLEM", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_ROLE_PROBLEM 
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

	/** 
	 * Enumerate over the CCR_I16_ROLE_PROBLEM results 
	 */ 
	public IEnumerable<CCR_I16_ROLE_PROBLEM> ROLE_PROBLEMs 
	{ 
		get
		{
			for (int rep = 0; rep < ROLE_PROBLEMRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_ROLE_PROBLEM)this.GetStructure("ROLE_PROBLEM", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_ROLE_PROBLEM
	///</summary>
	public CCR_I16_ROLE_PROBLEM AddROLE_PROBLEM()
	{
		return this.AddStructure("ROLE_PROBLEM") as CCR_I16_ROLE_PROBLEM;
	}

	///<summary>
	///Removes the given CCR_I16_ROLE_PROBLEM
	///</summary>
	public void RemoveROLE_PROBLEM(CCR_I16_ROLE_PROBLEM toRemove)
	{
		this.RemoveStructure("ROLE_PROBLEM", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_ROLE_PROBLEM at the given index
	///</summary>
	public void RemoveROLE_PROBLEMAt(int index)
	{
		this.RemoveRepetition("ROLE_PROBLEM", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_ROLE_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_ROLE_OBSERVATION GetROLE_OBSERVATION() {
	   CCR_I16_ROLE_OBSERVATION ret = null;
	   try {
	      ret = (CCR_I16_ROLE_OBSERVATION)this.GetStructure("ROLE_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_ROLE_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_ROLE_OBSERVATION GetROLE_OBSERVATION(int rep) { 
	   return (CCR_I16_ROLE_OBSERVATION)this.GetStructure("ROLE_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_ROLE_OBSERVATION 
	 */ 
	public int ROLE_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ROLE_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CCR_I16_ROLE_OBSERVATION results 
	 */ 
	public IEnumerable<CCR_I16_ROLE_OBSERVATION> ROLE_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < ROLE_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_ROLE_OBSERVATION)this.GetStructure("ROLE_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_ROLE_OBSERVATION
	///</summary>
	public CCR_I16_ROLE_OBSERVATION AddROLE_OBSERVATION()
	{
		return this.AddStructure("ROLE_OBSERVATION") as CCR_I16_ROLE_OBSERVATION;
	}

	///<summary>
	///Removes the given CCR_I16_ROLE_OBSERVATION
	///</summary>
	public void RemoveROLE_OBSERVATION(CCR_I16_ROLE_OBSERVATION toRemove)
	{
		this.RemoveStructure("ROLE_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_ROLE_OBSERVATION at the given index
	///</summary>
	public void RemoveROLE_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("ROLE_OBSERVATION", index);
	}

}
}
