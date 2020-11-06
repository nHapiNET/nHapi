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
///Represents the MFR_M05_MF_QUERY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFE (Master File Entry) </li>
///<li>1: LOC (Location Identification) </li>
///<li>2: LCH (Location Characteristic) optional repeating</li>
///<li>3: LRL (Location Relationship) optional repeating</li>
///<li>4: MFR_M05_MF_LOC_DEPT (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFR_M05_MF_QUERY : AbstractGroup {

	///<summary> 
	/// Creates a new MFR_M05_MF_QUERY Group.
	///</summary>
	public MFR_M05_MF_QUERY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFE), true, false);
	      this.add(typeof(LOC), true, false);
	      this.add(typeof(LCH), false, true);
	      this.add(typeof(LRL), false, true);
	      this.add(typeof(MFR_M05_MF_LOC_DEPT), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFR_M05_MF_QUERY - this is probably a bug in the source code generator.", e);
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
	/// Returns LOC (Location Identification) - creates it if necessary
	///</summary>
	public LOC LOC { 
get{
	   LOC ret = null;
	   try {
	      ret = (LOC)this.GetStructure("LOC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of LCH (Location Characteristic) - creates it if necessary
	///</summary>
	public LCH GetLCH() {
	   LCH ret = null;
	   try {
	      ret = (LCH)this.GetStructure("LCH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LCH
	/// * (Location Characteristic) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LCH GetLCH(int rep) { 
	   return (LCH)this.GetStructure("LCH", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LCH 
	 */ 
	public int LCHRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LCH").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the LCH results 
	 */ 
	public IEnumerable<LCH> LCHs 
	{ 
		get
		{
			for (int rep = 0; rep < LCHRepetitionsUsed; rep++)
			{
				yield return (LCH)this.GetStructure("LCH", rep);
			}
		}
	}

	///<summary>
	///Adds a new LCH
	///</summary>
	public LCH AddLCH()
	{
		return this.AddStructure("LCH") as LCH;
	}

	///<summary>
	///Removes the given LCH
	///</summary>
	public void RemoveLCH(LCH toRemove)
	{
		this.RemoveStructure("LCH", toRemove);
	}

	///<summary>
	///Removes the LCH at the given index
	///</summary>
	public void RemoveLCHAt(int index)
	{
		this.RemoveRepetition("LCH", index);
	}

	///<summary>
	/// Returns  first repetition of LRL (Location Relationship) - creates it if necessary
	///</summary>
	public LRL GetLRL() {
	   LRL ret = null;
	   try {
	      ret = (LRL)this.GetStructure("LRL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LRL
	/// * (Location Relationship) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LRL GetLRL(int rep) { 
	   return (LRL)this.GetStructure("LRL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LRL 
	 */ 
	public int LRLRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LRL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the LRL results 
	 */ 
	public IEnumerable<LRL> LRLs 
	{ 
		get
		{
			for (int rep = 0; rep < LRLRepetitionsUsed; rep++)
			{
				yield return (LRL)this.GetStructure("LRL", rep);
			}
		}
	}

	///<summary>
	///Adds a new LRL
	///</summary>
	public LRL AddLRL()
	{
		return this.AddStructure("LRL") as LRL;
	}

	///<summary>
	///Removes the given LRL
	///</summary>
	public void RemoveLRL(LRL toRemove)
	{
		this.RemoveStructure("LRL", toRemove);
	}

	///<summary>
	///Removes the LRL at the given index
	///</summary>
	public void RemoveLRLAt(int index)
	{
		this.RemoveRepetition("LRL", index);
	}

	///<summary>
	/// Returns  first repetition of MFR_M05_MF_LOC_DEPT (a Group object) - creates it if necessary
	///</summary>
	public MFR_M05_MF_LOC_DEPT GetMF_LOC_DEPT() {
	   MFR_M05_MF_LOC_DEPT ret = null;
	   try {
	      ret = (MFR_M05_MF_LOC_DEPT)this.GetStructure("MF_LOC_DEPT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFR_M05_MF_LOC_DEPT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFR_M05_MF_LOC_DEPT GetMF_LOC_DEPT(int rep) { 
	   return (MFR_M05_MF_LOC_DEPT)this.GetStructure("MF_LOC_DEPT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFR_M05_MF_LOC_DEPT 
	 */ 
	public int MF_LOC_DEPTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_LOC_DEPT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFR_M05_MF_LOC_DEPT results 
	 */ 
	public IEnumerable<MFR_M05_MF_LOC_DEPT> MF_LOC_DEPTs 
	{ 
		get
		{
			for (int rep = 0; rep < MF_LOC_DEPTRepetitionsUsed; rep++)
			{
				yield return (MFR_M05_MF_LOC_DEPT)this.GetStructure("MF_LOC_DEPT", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFR_M05_MF_LOC_DEPT
	///</summary>
	public MFR_M05_MF_LOC_DEPT AddMF_LOC_DEPT()
	{
		return this.AddStructure("MF_LOC_DEPT") as MFR_M05_MF_LOC_DEPT;
	}

	///<summary>
	///Removes the given MFR_M05_MF_LOC_DEPT
	///</summary>
	public void RemoveMF_LOC_DEPT(MFR_M05_MF_LOC_DEPT toRemove)
	{
		this.RemoveStructure("MF_LOC_DEPT", toRemove);
	}

	///<summary>
	///Removes the MFR_M05_MF_LOC_DEPT at the given index
	///</summary>
	public void RemoveMF_LOC_DEPTAt(int index)
	{
		this.RemoveRepetition("MF_LOC_DEPT", index);
	}

}
}
