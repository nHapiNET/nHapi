using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Group
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
///<li>4: LDP (Location Department) repeating</li>
///<li>5: LCH (Location Characteristic) optional repeating</li>
///<li>6: LCC (Location Charge Code) optional repeating</li>
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
	      this.add(typeof(LDP), true, true);
	      this.add(typeof(LCH), false, true);
	      this.add(typeof(LCC), false, true);
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
	/// Returns  first repetition of LDP (Location Department) - creates it if necessary
	///</summary>
	public LDP GetLDP() {
	   LDP ret = null;
	   try {
	      ret = (LDP)this.GetStructure("LDP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LDP
	/// * (Location Department) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LDP GetLDP(int rep) { 
	   return (LDP)this.GetStructure("LDP", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LDP 
	 */ 
	public int LDPRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LDP").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the LDP results 
	 */ 
	public IEnumerable<LDP> LDPs 
	{ 
		get
		{
			for (int rep = 0; rep < LDPRepetitionsUsed; rep++)
			{
				yield return (LDP)this.GetStructure("LDP", rep);
			}
		}
	}

	///<summary>
	///Adds a new LDP
	///</summary>
	public LDP AddLDP()
	{
		return this.AddStructure("LDP") as LDP;
	}

	///<summary>
	///Removes the given LDP
	///</summary>
	public void RemoveLDP(LDP toRemove)
	{
		this.RemoveStructure("LDP", toRemove);
	}

	///<summary>
	///Removes the LDP at the given index
	///</summary>
	public void RemoveLDPAt(int index)
	{
		this.RemoveRepetition("LDP", index);
	}

	///<summary>
	/// Returns  first repetition of LCH2 (Location Characteristic) - creates it if necessary
	///</summary>
	public LCH GetLCH2() {
	   LCH ret = null;
	   try {
	      ret = (LCH)this.GetStructure("LCH2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LCH2
	/// * (Location Characteristic) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LCH GetLCH2(int rep) { 
	   return (LCH)this.GetStructure("LCH2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LCH2 
	 */ 
	public int LCH2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LCH2").Length; 
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
	public IEnumerable<LCH> LCH2s 
	{ 
		get
		{
			for (int rep = 0; rep < LCH2RepetitionsUsed; rep++)
			{
				yield return (LCH)this.GetStructure("LCH2", rep);
			}
		}
	}

	///<summary>
	///Adds a new LCH
	///</summary>
	public LCH AddLCH2()
	{
		return this.AddStructure("LCH2") as LCH;
	}

	///<summary>
	///Removes the given LCH
	///</summary>
	public void RemoveLCH2(LCH toRemove)
	{
		this.RemoveStructure("LCH2", toRemove);
	}

	///<summary>
	///Removes the LCH at the given index
	///</summary>
	public void RemoveLCH2At(int index)
	{
		this.RemoveRepetition("LCH2", index);
	}

	///<summary>
	/// Returns  first repetition of LCC (Location Charge Code) - creates it if necessary
	///</summary>
	public LCC GetLCC() {
	   LCC ret = null;
	   try {
	      ret = (LCC)this.GetStructure("LCC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LCC
	/// * (Location Charge Code) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LCC GetLCC(int rep) { 
	   return (LCC)this.GetStructure("LCC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LCC 
	 */ 
	public int LCCRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LCC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the LCC results 
	 */ 
	public IEnumerable<LCC> LCCs 
	{ 
		get
		{
			for (int rep = 0; rep < LCCRepetitionsUsed; rep++)
			{
				yield return (LCC)this.GetStructure("LCC", rep);
			}
		}
	}

	///<summary>
	///Adds a new LCC
	///</summary>
	public LCC AddLCC()
	{
		return this.AddStructure("LCC") as LCC;
	}

	///<summary>
	///Removes the given LCC
	///</summary>
	public void RemoveLCC(LCC toRemove)
	{
		this.RemoveStructure("LCC", toRemove);
	}

	///<summary>
	///Removes the LCC at the given index
	///</summary>
	public void RemoveLCCAt(int index)
	{
		this.RemoveRepetition("LCC", index);
	}

}
}
