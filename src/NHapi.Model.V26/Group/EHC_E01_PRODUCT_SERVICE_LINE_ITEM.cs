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
///Represents the EHC_E01_PRODUCT_SERVICE_LINE_ITEM Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSL (Product/Service Line Item) </li>
///<li>1: NTE (Notes and Comments) optional repeating</li>
///<li>2: ADJ (Adjustment) optional repeating</li>
///<li>3: AUT (Authorization Information) optional </li>
///<li>4: LOC (Location Identification) optional repeating</li>
///<li>5: ROL (Role) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E01_PRODUCT_SERVICE_LINE_ITEM : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E01_PRODUCT_SERVICE_LINE_ITEM Group.
	///</summary>
	public EHC_E01_PRODUCT_SERVICE_LINE_ITEM(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSL), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(ADJ), false, true);
	      this.add(typeof(AUT), false, false);
	      this.add(typeof(LOC), false, true);
	      this.add(typeof(ROL), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E01_PRODUCT_SERVICE_LINE_ITEM - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PSL (Product/Service Line Item) - creates it if necessary
	///</summary>
	public PSL PSL { 
get{
	   PSL ret = null;
	   try {
	      ret = (PSL)this.GetStructure("PSL");
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
	/// Returns  first repetition of ADJ (Adjustment) - creates it if necessary
	///</summary>
	public ADJ GetADJ() {
	   ADJ ret = null;
	   try {
	      ret = (ADJ)this.GetStructure("ADJ");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ADJ
	/// * (Adjustment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ADJ GetADJ(int rep) { 
	   return (ADJ)this.GetStructure("ADJ", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ADJ 
	 */ 
	public int ADJRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ADJ").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ADJ results 
	 */ 
	public IEnumerable<ADJ> ADJs 
	{ 
		get
		{
			for (int rep = 0; rep < ADJRepetitionsUsed; rep++)
			{
				yield return (ADJ)this.GetStructure("ADJ", rep);
			}
		}
	}

	///<summary>
	///Adds a new ADJ
	///</summary>
	public ADJ AddADJ()
	{
		return this.AddStructure("ADJ") as ADJ;
	}

	///<summary>
	///Removes the given ADJ
	///</summary>
	public void RemoveADJ(ADJ toRemove)
	{
		this.RemoveStructure("ADJ", toRemove);
	}

	///<summary>
	///Removes the ADJ at the given index
	///</summary>
	public void RemoveADJAt(int index)
	{
		this.RemoveRepetition("ADJ", index);
	}

	///<summary>
	/// Returns AUT (Authorization Information) - creates it if necessary
	///</summary>
	public AUT AUT { 
get{
	   AUT ret = null;
	   try {
	      ret = (AUT)this.GetStructure("AUT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of LOC (Location Identification) - creates it if necessary
	///</summary>
	public LOC GetLOC() {
	   LOC ret = null;
	   try {
	      ret = (LOC)this.GetStructure("LOC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LOC
	/// * (Location Identification) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LOC GetLOC(int rep) { 
	   return (LOC)this.GetStructure("LOC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LOC 
	 */ 
	public int LOCRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LOC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the LOC results 
	 */ 
	public IEnumerable<LOC> LOCs 
	{ 
		get
		{
			for (int rep = 0; rep < LOCRepetitionsUsed; rep++)
			{
				yield return (LOC)this.GetStructure("LOC", rep);
			}
		}
	}

	///<summary>
	///Adds a new LOC
	///</summary>
	public LOC AddLOC()
	{
		return this.AddStructure("LOC") as LOC;
	}

	///<summary>
	///Removes the given LOC
	///</summary>
	public void RemoveLOC(LOC toRemove)
	{
		this.RemoveStructure("LOC", toRemove);
	}

	///<summary>
	///Removes the LOC at the given index
	///</summary>
	public void RemoveLOCAt(int index)
	{
		this.RemoveRepetition("LOC", index);
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

}
}
