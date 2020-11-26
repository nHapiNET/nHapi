using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the MFN_M04_MF_CDM Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFE (Master File Entry) </li>
///<li>1: NTE (Notes and Comments) optional repeating</li>
///<li>2: CDM (Charge Description Master) </li>
///<li>3: NTE (Notes and Comments) optional repeating</li>
///<li>4: PRC (Pricing) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M04_MF_CDM : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M04_MF_CDM Group.
	///</summary>
	public MFN_M04_MF_CDM(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFE), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(CDM), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(PRC), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M04_MF_CDM - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of NTE (Notes and Comments) - creates it if necessary
	///</summary>
	public NTE GetNTE() {
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NTE
	/// * (Notes and Comments) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NTE GetNTE(int rep) { 
	   return (NTE)this.GetStructure("NTE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NTE 
	 */ 
	public int NTERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NTE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NTE results 
	 */ 
	public IEnumerable<NTE> NTEs 
	{ 
		get
		{
			for (int rep = 0; rep < NTERepetitionsUsed; rep++)
			{
				yield return (NTE)this.GetStructure("NTE", rep);
			}
		}
	}

	///<summary>
	///Adds a new NTE
	///</summary>
	public NTE AddNTE()
	{
		return this.AddStructure("NTE") as NTE;
	}

	///<summary>
	///Removes the given NTE
	///</summary>
	public void RemoveNTE(NTE toRemove)
	{
		this.RemoveStructure("NTE", toRemove);
	}

	///<summary>
	///Removes the NTE at the given index
	///</summary>
	public void RemoveNTEAt(int index)
	{
		this.RemoveRepetition("NTE", index);
	}

	///<summary>
	/// Returns CDM (Charge Description Master) - creates it if necessary
	///</summary>
	public CDM CDM { 
get{
	   CDM ret = null;
	   try {
	      ret = (CDM)this.GetStructure("CDM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NTE2 (Notes and Comments) - creates it if necessary
	///</summary>
	public NTE GetNTE2() {
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NTE2
	/// * (Notes and Comments) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NTE GetNTE2(int rep) { 
	   return (NTE)this.GetStructure("NTE2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NTE2 
	 */ 
	public int NTE2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NTE2").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NTE results 
	 */ 
	public IEnumerable<NTE> NTE2s 
	{ 
		get
		{
			for (int rep = 0; rep < NTE2RepetitionsUsed; rep++)
			{
				yield return (NTE)this.GetStructure("NTE2", rep);
			}
		}
	}

	///<summary>
	///Adds a new NTE
	///</summary>
	public NTE AddNTE2()
	{
		return this.AddStructure("NTE2") as NTE;
	}

	///<summary>
	///Removes the given NTE
	///</summary>
	public void RemoveNTE2(NTE toRemove)
	{
		this.RemoveStructure("NTE2", toRemove);
	}

	///<summary>
	///Removes the NTE at the given index
	///</summary>
	public void RemoveNTE2At(int index)
	{
		this.RemoveRepetition("NTE2", index);
	}

	///<summary>
	/// Returns  first repetition of PRC (Pricing) - creates it if necessary
	///</summary>
	public PRC GetPRC() {
	   PRC ret = null;
	   try {
	      ret = (PRC)this.GetStructure("PRC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRC
	/// * (Pricing) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRC GetPRC(int rep) { 
	   return (PRC)this.GetStructure("PRC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRC 
	 */ 
	public int PRCRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PRC results 
	 */ 
	public IEnumerable<PRC> PRCs 
	{ 
		get
		{
			for (int rep = 0; rep < PRCRepetitionsUsed; rep++)
			{
				yield return (PRC)this.GetStructure("PRC", rep);
			}
		}
	}

	///<summary>
	///Adds a new PRC
	///</summary>
	public PRC AddPRC()
	{
		return this.AddStructure("PRC") as PRC;
	}

	///<summary>
	///Removes the given PRC
	///</summary>
	public void RemovePRC(PRC toRemove)
	{
		this.RemoveStructure("PRC", toRemove);
	}

	///<summary>
	///Removes the PRC at the given index
	///</summary>
	public void RemovePRCAt(int index)
	{
		this.RemoveRepetition("PRC", index);
	}

}
}
