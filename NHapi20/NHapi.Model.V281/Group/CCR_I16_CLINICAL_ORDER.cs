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
///Represents the CCR_I16_CLINICAL_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: CCR_I16_CLINICAL_ORDER_TIMING (a Group object) optional repeating</li>
///<li>2: CCR_I16_CLINICAL_ORDER_DETAIL (a Group object) repeating</li>
///<li>3: CTI (Clinical Trial Identification) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCR_I16_CLINICAL_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new CCR_I16_CLINICAL_ORDER Group.
	///</summary>
	public CCR_I16_CLINICAL_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(CCR_I16_CLINICAL_ORDER_TIMING), false, true);
	      this.add(typeof(CCR_I16_CLINICAL_ORDER_DETAIL), true, true);
	      this.add(typeof(CTI), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCR_I16_CLINICAL_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of CCR_I16_CLINICAL_ORDER_TIMING (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_CLINICAL_ORDER_TIMING GetCLINICAL_ORDER_TIMING() {
	   CCR_I16_CLINICAL_ORDER_TIMING ret = null;
	   try {
	      ret = (CCR_I16_CLINICAL_ORDER_TIMING)this.GetStructure("CLINICAL_ORDER_TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_CLINICAL_ORDER_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_CLINICAL_ORDER_TIMING GetCLINICAL_ORDER_TIMING(int rep) { 
	   return (CCR_I16_CLINICAL_ORDER_TIMING)this.GetStructure("CLINICAL_ORDER_TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_CLINICAL_ORDER_TIMING 
	 */ 
	public int CLINICAL_ORDER_TIMINGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLINICAL_ORDER_TIMING").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CCR_I16_CLINICAL_ORDER_TIMING results 
	 */ 
	public IEnumerable<CCR_I16_CLINICAL_ORDER_TIMING> CLINICAL_ORDER_TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < CLINICAL_ORDER_TIMINGRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_CLINICAL_ORDER_TIMING)this.GetStructure("CLINICAL_ORDER_TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_CLINICAL_ORDER_TIMING
	///</summary>
	public CCR_I16_CLINICAL_ORDER_TIMING AddCLINICAL_ORDER_TIMING()
	{
		return this.AddStructure("CLINICAL_ORDER_TIMING") as CCR_I16_CLINICAL_ORDER_TIMING;
	}

	///<summary>
	///Removes the given CCR_I16_CLINICAL_ORDER_TIMING
	///</summary>
	public void RemoveCLINICAL_ORDER_TIMING(CCR_I16_CLINICAL_ORDER_TIMING toRemove)
	{
		this.RemoveStructure("CLINICAL_ORDER_TIMING", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_CLINICAL_ORDER_TIMING at the given index
	///</summary>
	public void RemoveCLINICAL_ORDER_TIMINGAt(int index)
	{
		this.RemoveRepetition("CLINICAL_ORDER_TIMING", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_CLINICAL_ORDER_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_CLINICAL_ORDER_DETAIL GetCLINICAL_ORDER_DETAIL() {
	   CCR_I16_CLINICAL_ORDER_DETAIL ret = null;
	   try {
	      ret = (CCR_I16_CLINICAL_ORDER_DETAIL)this.GetStructure("CLINICAL_ORDER_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_CLINICAL_ORDER_DETAIL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_CLINICAL_ORDER_DETAIL GetCLINICAL_ORDER_DETAIL(int rep) { 
	   return (CCR_I16_CLINICAL_ORDER_DETAIL)this.GetStructure("CLINICAL_ORDER_DETAIL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_CLINICAL_ORDER_DETAIL 
	 */ 
	public int CLINICAL_ORDER_DETAILRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLINICAL_ORDER_DETAIL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CCR_I16_CLINICAL_ORDER_DETAIL results 
	 */ 
	public IEnumerable<CCR_I16_CLINICAL_ORDER_DETAIL> CLINICAL_ORDER_DETAILs 
	{ 
		get
		{
			for (int rep = 0; rep < CLINICAL_ORDER_DETAILRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_CLINICAL_ORDER_DETAIL)this.GetStructure("CLINICAL_ORDER_DETAIL", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_CLINICAL_ORDER_DETAIL
	///</summary>
	public CCR_I16_CLINICAL_ORDER_DETAIL AddCLINICAL_ORDER_DETAIL()
	{
		return this.AddStructure("CLINICAL_ORDER_DETAIL") as CCR_I16_CLINICAL_ORDER_DETAIL;
	}

	///<summary>
	///Removes the given CCR_I16_CLINICAL_ORDER_DETAIL
	///</summary>
	public void RemoveCLINICAL_ORDER_DETAIL(CCR_I16_CLINICAL_ORDER_DETAIL toRemove)
	{
		this.RemoveStructure("CLINICAL_ORDER_DETAIL", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_CLINICAL_ORDER_DETAIL at the given index
	///</summary>
	public void RemoveCLINICAL_ORDER_DETAILAt(int index)
	{
		this.RemoveRepetition("CLINICAL_ORDER_DETAIL", index);
	}

	///<summary>
	/// Returns  first repetition of CTI (Clinical Trial Identification) - creates it if necessary
	///</summary>
	public CTI GetCTI() {
	   CTI ret = null;
	   try {
	      ret = (CTI)this.GetStructure("CTI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CTI
	/// * (Clinical Trial Identification) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CTI GetCTI(int rep) { 
	   return (CTI)this.GetStructure("CTI", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CTI 
	 */ 
	public int CTIRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CTI").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CTI results 
	 */ 
	public IEnumerable<CTI> CTIs 
	{ 
		get
		{
			for (int rep = 0; rep < CTIRepetitionsUsed; rep++)
			{
				yield return (CTI)this.GetStructure("CTI", rep);
			}
		}
	}

	///<summary>
	///Adds a new CTI
	///</summary>
	public CTI AddCTI()
	{
		return this.AddStructure("CTI") as CTI;
	}

	///<summary>
	///Removes the given CTI
	///</summary>
	public void RemoveCTI(CTI toRemove)
	{
		this.RemoveStructure("CTI", toRemove);
	}

	///<summary>
	///Removes the CTI at the given index
	///</summary>
	public void RemoveCTIAt(int index)
	{
		this.RemoveRepetition("CTI", index);
	}

}
}
