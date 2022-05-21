using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V251.Segment;
using NHapi.Model.V251.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the SUR_P09_FACILITY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: FAC (Facility) </li>
///<li>1: SUR_P09_PRODUCT (a Group object) repeating</li>
///<li>2: PSH (Product Summary Header) </li>
///<li>3: SUR_P09_FACILITY_DETAIL (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class SUR_P09_FACILITY : AbstractGroup {

	///<summary> 
	/// Creates a new SUR_P09_FACILITY Group.
	///</summary>
	public SUR_P09_FACILITY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(FAC), true, false);
	      this.add(typeof(SUR_P09_PRODUCT), true, true);
	      this.add(typeof(PSH), true, false);
	      this.add(typeof(SUR_P09_FACILITY_DETAIL), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SUR_P09_FACILITY - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns FAC (Facility) - creates it if necessary
	///</summary>
	public FAC FAC { 
get{
	   FAC ret = null;
	   try {
	      ret = (FAC)this.GetStructure("FAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error occurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of SUR_P09_PRODUCT (a Group object) - creates it if necessary
	///</summary>
	public SUR_P09_PRODUCT GetPRODUCT() {
	   SUR_P09_PRODUCT ret = null;
	   try {
	      ret = (SUR_P09_PRODUCT)this.GetStructure("PRODUCT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error occurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SUR_P09_PRODUCT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SUR_P09_PRODUCT GetPRODUCT(int rep) { 
	   return (SUR_P09_PRODUCT)this.GetStructure("PRODUCT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SUR_P09_PRODUCT 
	 */ 
	public int PRODUCTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRODUCT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SUR_P09_PRODUCT results 
	 */ 
	public IEnumerable<SUR_P09_PRODUCT> PRODUCTs 
	{ 
		get
		{
			for (int rep = 0; rep < PRODUCTRepetitionsUsed; rep++)
			{
				yield return (SUR_P09_PRODUCT)this.GetStructure("PRODUCT", rep);
			}
		}
	}

	///<summary>
	///Adds a new SUR_P09_PRODUCT
	///</summary>
	public SUR_P09_PRODUCT AddPRODUCT()
	{
		return this.AddStructure("PRODUCT") as SUR_P09_PRODUCT;
	}

	///<summary>
	///Removes the given SUR_P09_PRODUCT
	///</summary>
	public void RemovePRODUCT(SUR_P09_PRODUCT toRemove)
	{
		this.RemoveStructure("PRODUCT", toRemove);
	}

	///<summary>
	///Removes the SUR_P09_PRODUCT at the given index
	///</summary>
	public void RemovePRODUCTAt(int index)
	{
		this.RemoveRepetition("PRODUCT", index);
	}

	///<summary>
	/// Returns PSH (Product Summary Header) - creates it if necessary
	///</summary>
	public PSH PSH { 
get{
	   PSH ret = null;
	   try {
	      ret = (PSH)this.GetStructure("PSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error occurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of SUR_P09_FACILITY_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public SUR_P09_FACILITY_DETAIL GetFACILITY_DETAIL() {
	   SUR_P09_FACILITY_DETAIL ret = null;
	   try {
	      ret = (SUR_P09_FACILITY_DETAIL)this.GetStructure("FACILITY_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error occurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SUR_P09_FACILITY_DETAIL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SUR_P09_FACILITY_DETAIL GetFACILITY_DETAIL(int rep) { 
	   return (SUR_P09_FACILITY_DETAIL)this.GetStructure("FACILITY_DETAIL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SUR_P09_FACILITY_DETAIL 
	 */ 
	public int FACILITY_DETAILRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("FACILITY_DETAIL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SUR_P09_FACILITY_DETAIL results 
	 */ 
	public IEnumerable<SUR_P09_FACILITY_DETAIL> FACILITY_DETAILs 
	{ 
		get
		{
			for (int rep = 0; rep < FACILITY_DETAILRepetitionsUsed; rep++)
			{
				yield return (SUR_P09_FACILITY_DETAIL)this.GetStructure("FACILITY_DETAIL", rep);
			}
		}
	}

	///<summary>
	///Adds a new SUR_P09_FACILITY_DETAIL
	///</summary>
	public SUR_P09_FACILITY_DETAIL AddFACILITY_DETAIL()
	{
		return this.AddStructure("FACILITY_DETAIL") as SUR_P09_FACILITY_DETAIL;
	}

	///<summary>
	///Removes the given SUR_P09_FACILITY_DETAIL
	///</summary>
	public void RemoveFACILITY_DETAIL(SUR_P09_FACILITY_DETAIL toRemove)
	{
		this.RemoveStructure("FACILITY_DETAIL", toRemove);
	}

	///<summary>
	///Removes the SUR_P09_FACILITY_DETAIL at the given index
	///</summary>
	public void RemoveFACILITY_DETAILAt(int index)
	{
		this.RemoveRepetition("FACILITY_DETAIL", index);
	}

}
}