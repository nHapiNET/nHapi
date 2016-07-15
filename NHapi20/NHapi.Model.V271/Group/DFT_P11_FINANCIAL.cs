using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V271.Segment;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V271.Group
{
///<summary>
///Represents the DFT_P11_FINANCIAL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: FT1 (Financial Transaction) </li>
///<li>1: DFT_P11_FINANCIAL_PROCEDURE (a Group object) optional repeating</li>
///<li>2: DFT_P11_FINANCIAL_COMMON_ORDER (a Group object) optional repeating</li>
///<li>3: DG1 (Diagnosis) optional repeating</li>
///<li>4: DRG (Diagnosis Related Group) optional </li>
///<li>5: GT1 (Guarantor) optional repeating</li>
///<li>6: DFT_P11_FINANCIAL_INSURANCE (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class DFT_P11_FINANCIAL : AbstractGroup {

	///<summary> 
	/// Creates a new DFT_P11_FINANCIAL Group.
	///</summary>
	public DFT_P11_FINANCIAL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(FT1), true, false);
	      this.add(typeof(DFT_P11_FINANCIAL_PROCEDURE), false, true);
	      this.add(typeof(DFT_P11_FINANCIAL_COMMON_ORDER), false, true);
	      this.add(typeof(DG1), false, true);
	      this.add(typeof(DRG), false, false);
	      this.add(typeof(GT1), false, true);
	      this.add(typeof(DFT_P11_FINANCIAL_INSURANCE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating DFT_P11_FINANCIAL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns FT1 (Financial Transaction) - creates it if necessary
	///</summary>
	public FT1 FT1 { 
get{
	   FT1 ret = null;
	   try {
	      ret = (FT1)this.GetStructure("FT1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of DFT_P11_FINANCIAL_PROCEDURE (a Group object) - creates it if necessary
	///</summary>
	public DFT_P11_FINANCIAL_PROCEDURE GetFINANCIAL_PROCEDURE() {
	   DFT_P11_FINANCIAL_PROCEDURE ret = null;
	   try {
	      ret = (DFT_P11_FINANCIAL_PROCEDURE)this.GetStructure("FINANCIAL_PROCEDURE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DFT_P11_FINANCIAL_PROCEDURE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DFT_P11_FINANCIAL_PROCEDURE GetFINANCIAL_PROCEDURE(int rep) { 
	   return (DFT_P11_FINANCIAL_PROCEDURE)this.GetStructure("FINANCIAL_PROCEDURE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DFT_P11_FINANCIAL_PROCEDURE 
	 */ 
	public int FINANCIAL_PROCEDURERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("FINANCIAL_PROCEDURE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DFT_P11_FINANCIAL_PROCEDURE results 
	 */ 
	public IEnumerable<DFT_P11_FINANCIAL_PROCEDURE> FINANCIAL_PROCEDUREs 
	{ 
		get
		{
			for (int rep = 0; rep < FINANCIAL_PROCEDURERepetitionsUsed; rep++)
			{
				yield return (DFT_P11_FINANCIAL_PROCEDURE)this.GetStructure("FINANCIAL_PROCEDURE", rep);
			}
		}
	}

	///<summary>
	///Adds a new DFT_P11_FINANCIAL_PROCEDURE
	///</summary>
	public DFT_P11_FINANCIAL_PROCEDURE AddFINANCIAL_PROCEDURE()
	{
		return this.AddStructure("FINANCIAL_PROCEDURE") as DFT_P11_FINANCIAL_PROCEDURE;
	}

	///<summary>
	///Removes the given DFT_P11_FINANCIAL_PROCEDURE
	///</summary>
	public void RemoveFINANCIAL_PROCEDURE(DFT_P11_FINANCIAL_PROCEDURE toRemove)
	{
		this.RemoveStructure("FINANCIAL_PROCEDURE", toRemove);
	}

	///<summary>
	///Removes the DFT_P11_FINANCIAL_PROCEDURE at the given index
	///</summary>
	public void RemoveFINANCIAL_PROCEDUREAt(int index)
	{
		this.RemoveRepetition("FINANCIAL_PROCEDURE", index);
	}

	///<summary>
	/// Returns  first repetition of DFT_P11_FINANCIAL_COMMON_ORDER (a Group object) - creates it if necessary
	///</summary>
	public DFT_P11_FINANCIAL_COMMON_ORDER GetFINANCIAL_COMMON_ORDER() {
	   DFT_P11_FINANCIAL_COMMON_ORDER ret = null;
	   try {
	      ret = (DFT_P11_FINANCIAL_COMMON_ORDER)this.GetStructure("FINANCIAL_COMMON_ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DFT_P11_FINANCIAL_COMMON_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DFT_P11_FINANCIAL_COMMON_ORDER GetFINANCIAL_COMMON_ORDER(int rep) { 
	   return (DFT_P11_FINANCIAL_COMMON_ORDER)this.GetStructure("FINANCIAL_COMMON_ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DFT_P11_FINANCIAL_COMMON_ORDER 
	 */ 
	public int FINANCIAL_COMMON_ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("FINANCIAL_COMMON_ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DFT_P11_FINANCIAL_COMMON_ORDER results 
	 */ 
	public IEnumerable<DFT_P11_FINANCIAL_COMMON_ORDER> FINANCIAL_COMMON_ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < FINANCIAL_COMMON_ORDERRepetitionsUsed; rep++)
			{
				yield return (DFT_P11_FINANCIAL_COMMON_ORDER)this.GetStructure("FINANCIAL_COMMON_ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new DFT_P11_FINANCIAL_COMMON_ORDER
	///</summary>
	public DFT_P11_FINANCIAL_COMMON_ORDER AddFINANCIAL_COMMON_ORDER()
	{
		return this.AddStructure("FINANCIAL_COMMON_ORDER") as DFT_P11_FINANCIAL_COMMON_ORDER;
	}

	///<summary>
	///Removes the given DFT_P11_FINANCIAL_COMMON_ORDER
	///</summary>
	public void RemoveFINANCIAL_COMMON_ORDER(DFT_P11_FINANCIAL_COMMON_ORDER toRemove)
	{
		this.RemoveStructure("FINANCIAL_COMMON_ORDER", toRemove);
	}

	///<summary>
	///Removes the DFT_P11_FINANCIAL_COMMON_ORDER at the given index
	///</summary>
	public void RemoveFINANCIAL_COMMON_ORDERAt(int index)
	{
		this.RemoveRepetition("FINANCIAL_COMMON_ORDER", index);
	}

	///<summary>
	/// Returns  first repetition of DG1 (Diagnosis) - creates it if necessary
	///</summary>
	public DG1 GetDG1() {
	   DG1 ret = null;
	   try {
	      ret = (DG1)this.GetStructure("DG1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DG1
	/// * (Diagnosis) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DG1 GetDG1(int rep) { 
	   return (DG1)this.GetStructure("DG1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DG1 
	 */ 
	public int DG1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DG1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DG1 results 
	 */ 
	public IEnumerable<DG1> DG1s 
	{ 
		get
		{
			for (int rep = 0; rep < DG1RepetitionsUsed; rep++)
			{
				yield return (DG1)this.GetStructure("DG1", rep);
			}
		}
	}

	///<summary>
	///Adds a new DG1
	///</summary>
	public DG1 AddDG1()
	{
		return this.AddStructure("DG1") as DG1;
	}

	///<summary>
	///Removes the given DG1
	///</summary>
	public void RemoveDG1(DG1 toRemove)
	{
		this.RemoveStructure("DG1", toRemove);
	}

	///<summary>
	///Removes the DG1 at the given index
	///</summary>
	public void RemoveDG1At(int index)
	{
		this.RemoveRepetition("DG1", index);
	}

	///<summary>
	/// Returns DRG (Diagnosis Related Group) - creates it if necessary
	///</summary>
	public DRG DRG { 
get{
	   DRG ret = null;
	   try {
	      ret = (DRG)this.GetStructure("DRG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of GT1 (Guarantor) - creates it if necessary
	///</summary>
	public GT1 GetGT1() {
	   GT1 ret = null;
	   try {
	      ret = (GT1)this.GetStructure("GT1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of GT1
	/// * (Guarantor) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public GT1 GetGT1(int rep) { 
	   return (GT1)this.GetStructure("GT1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of GT1 
	 */ 
	public int GT1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("GT1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the GT1 results 
	 */ 
	public IEnumerable<GT1> GT1s 
	{ 
		get
		{
			for (int rep = 0; rep < GT1RepetitionsUsed; rep++)
			{
				yield return (GT1)this.GetStructure("GT1", rep);
			}
		}
	}

	///<summary>
	///Adds a new GT1
	///</summary>
	public GT1 AddGT1()
	{
		return this.AddStructure("GT1") as GT1;
	}

	///<summary>
	///Removes the given GT1
	///</summary>
	public void RemoveGT1(GT1 toRemove)
	{
		this.RemoveStructure("GT1", toRemove);
	}

	///<summary>
	///Removes the GT1 at the given index
	///</summary>
	public void RemoveGT1At(int index)
	{
		this.RemoveRepetition("GT1", index);
	}

	///<summary>
	/// Returns  first repetition of DFT_P11_FINANCIAL_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public DFT_P11_FINANCIAL_INSURANCE GetFINANCIAL_INSURANCE() {
	   DFT_P11_FINANCIAL_INSURANCE ret = null;
	   try {
	      ret = (DFT_P11_FINANCIAL_INSURANCE)this.GetStructure("FINANCIAL_INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DFT_P11_FINANCIAL_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DFT_P11_FINANCIAL_INSURANCE GetFINANCIAL_INSURANCE(int rep) { 
	   return (DFT_P11_FINANCIAL_INSURANCE)this.GetStructure("FINANCIAL_INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DFT_P11_FINANCIAL_INSURANCE 
	 */ 
	public int FINANCIAL_INSURANCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("FINANCIAL_INSURANCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DFT_P11_FINANCIAL_INSURANCE results 
	 */ 
	public IEnumerable<DFT_P11_FINANCIAL_INSURANCE> FINANCIAL_INSURANCEs 
	{ 
		get
		{
			for (int rep = 0; rep < FINANCIAL_INSURANCERepetitionsUsed; rep++)
			{
				yield return (DFT_P11_FINANCIAL_INSURANCE)this.GetStructure("FINANCIAL_INSURANCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new DFT_P11_FINANCIAL_INSURANCE
	///</summary>
	public DFT_P11_FINANCIAL_INSURANCE AddFINANCIAL_INSURANCE()
	{
		return this.AddStructure("FINANCIAL_INSURANCE") as DFT_P11_FINANCIAL_INSURANCE;
	}

	///<summary>
	///Removes the given DFT_P11_FINANCIAL_INSURANCE
	///</summary>
	public void RemoveFINANCIAL_INSURANCE(DFT_P11_FINANCIAL_INSURANCE toRemove)
	{
		this.RemoveStructure("FINANCIAL_INSURANCE", toRemove);
	}

	///<summary>
	///Removes the DFT_P11_FINANCIAL_INSURANCE at the given index
	///</summary>
	public void RemoveFINANCIAL_INSURANCEAt(int index)
	{
		this.RemoveRepetition("FINANCIAL_INSURANCE", index);
	}

}
}
