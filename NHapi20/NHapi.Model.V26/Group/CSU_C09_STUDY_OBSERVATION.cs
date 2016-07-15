using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V26.Segment;
using NHapi.Model.V26.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V26.Group
{
///<summary>
///Represents the CSU_C09_STUDY_OBSERVATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) optional </li>
///<li>1: OBR (Observation Request) </li>
///<li>2: ROL (Role) optional repeating</li>
///<li>3: CSU_C09_TIMING_QTY (a Group object) optional repeating</li>
///<li>4: OBX (Observation/Result) repeating</li>
///</ol>
///</summary>
[Serializable]
public class CSU_C09_STUDY_OBSERVATION : AbstractGroup {

	///<summary> 
	/// Creates a new CSU_C09_STUDY_OBSERVATION Group.
	///</summary>
	public CSU_C09_STUDY_OBSERVATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), false, false);
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(ROL), false, true);
	      this.add(typeof(CSU_C09_TIMING_QTY), false, true);
	      this.add(typeof(OBX), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CSU_C09_STUDY_OBSERVATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORC (Common Order) - creates it if necessary
	///</summary>
	public ORC ORC { 
get{
	   ORC ret = null;
	   try {
	      ret = (ORC)this.GetStructure("ORC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns OBR (Observation Request) - creates it if necessary
	///</summary>
	public OBR OBR { 
get{
	   OBR ret = null;
	   try {
	      ret = (OBR)this.GetStructure("OBR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ROL (Role) - creates it if necessary
	///</summary>
	public ROL GetROL() {
	   ROL ret = null;
	   try {
	      ret = (ROL)this.GetStructure("ROL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ROL
	/// * (Role) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ROL GetROL(int rep) { 
	   return (ROL)this.GetStructure("ROL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ROL 
	 */ 
	public int ROLRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ROL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ROL results 
	 */ 
	public IEnumerable<ROL> ROLs 
	{ 
		get
		{
			for (int rep = 0; rep < ROLRepetitionsUsed; rep++)
			{
				yield return (ROL)this.GetStructure("ROL", rep);
			}
		}
	}

	///<summary>
	///Adds a new ROL
	///</summary>
	public ROL AddROL()
	{
		return this.AddStructure("ROL") as ROL;
	}

	///<summary>
	///Removes the given ROL
	///</summary>
	public void RemoveROL(ROL toRemove)
	{
		this.RemoveStructure("ROL", toRemove);
	}

	///<summary>
	///Removes the ROL at the given index
	///</summary>
	public void RemoveROLAt(int index)
	{
		this.RemoveRepetition("ROL", index);
	}

	///<summary>
	/// Returns  first repetition of CSU_C09_TIMING_QTY (a Group object) - creates it if necessary
	///</summary>
	public CSU_C09_TIMING_QTY GetTIMING_QTY() {
	   CSU_C09_TIMING_QTY ret = null;
	   try {
	      ret = (CSU_C09_TIMING_QTY)this.GetStructure("TIMING_QTY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CSU_C09_TIMING_QTY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CSU_C09_TIMING_QTY GetTIMING_QTY(int rep) { 
	   return (CSU_C09_TIMING_QTY)this.GetStructure("TIMING_QTY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CSU_C09_TIMING_QTY 
	 */ 
	public int TIMING_QTYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING_QTY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CSU_C09_TIMING_QTY results 
	 */ 
	public IEnumerable<CSU_C09_TIMING_QTY> TIMING_QTYs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMING_QTYRepetitionsUsed; rep++)
			{
				yield return (CSU_C09_TIMING_QTY)this.GetStructure("TIMING_QTY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CSU_C09_TIMING_QTY
	///</summary>
	public CSU_C09_TIMING_QTY AddTIMING_QTY()
	{
		return this.AddStructure("TIMING_QTY") as CSU_C09_TIMING_QTY;
	}

	///<summary>
	///Removes the given CSU_C09_TIMING_QTY
	///</summary>
	public void RemoveTIMING_QTY(CSU_C09_TIMING_QTY toRemove)
	{
		this.RemoveStructure("TIMING_QTY", toRemove);
	}

	///<summary>
	///Removes the CSU_C09_TIMING_QTY at the given index
	///</summary>
	public void RemoveTIMING_QTYAt(int index)
	{
		this.RemoveRepetition("TIMING_QTY", index);
	}

	///<summary>
	/// Returns  first repetition of OBX (Observation/Result) - creates it if necessary
	///</summary>
	public OBX GetOBX() {
	   OBX ret = null;
	   try {
	      ret = (OBX)this.GetStructure("OBX");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OBX
	/// * (Observation/Result) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OBX GetOBX(int rep) { 
	   return (OBX)this.GetStructure("OBX", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OBX 
	 */ 
	public int OBXRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBX").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OBX results 
	 */ 
	public IEnumerable<OBX> OBXs 
	{ 
		get
		{
			for (int rep = 0; rep < OBXRepetitionsUsed; rep++)
			{
				yield return (OBX)this.GetStructure("OBX", rep);
			}
		}
	}

	///<summary>
	///Adds a new OBX
	///</summary>
	public OBX AddOBX()
	{
		return this.AddStructure("OBX") as OBX;
	}

	///<summary>
	///Removes the given OBX
	///</summary>
	public void RemoveOBX(OBX toRemove)
	{
		this.RemoveStructure("OBX", toRemove);
	}

	///<summary>
	///Removes the OBX at the given index
	///</summary>
	public void RemoveOBXAt(int index)
	{
		this.RemoveRepetition("OBX", index);
	}

}
}
