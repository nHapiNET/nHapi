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
///Represents the RAS_O17_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: PRT (Participation Information) optional repeating</li>
///<li>2: RAS_O17_TIMING (a Group object) optional repeating</li>
///<li>3: RAS_O17_ORDER_DETAIL (a Group object) optional </li>
///<li>4: RAS_O17_ENCODING (a Group object) optional </li>
///<li>5: RAS_O17_ADMINISTRATION (a Group object) repeating</li>
///<li>6: CTI (Clinical Trial Identification) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RAS_O17_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RAS_O17_ORDER Group.
	///</summary>
	public RAS_O17_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(RAS_O17_TIMING), false, true);
	      this.add(typeof(RAS_O17_ORDER_DETAIL), false, false);
	      this.add(typeof(RAS_O17_ENCODING), false, false);
	      this.add(typeof(RAS_O17_ADMINISTRATION), true, true);
	      this.add(typeof(CTI), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RAS_O17_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of PRT (Participation Information) - creates it if necessary
	///</summary>
	public PRT GetPRT() {
	   PRT ret = null;
	   try {
	      ret = (PRT)this.GetStructure("PRT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRT
	/// * (Participation Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRT GetPRT(int rep) { 
	   return (PRT)this.GetStructure("PRT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRT 
	 */ 
	public int PRTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PRT results 
	 */ 
	public IEnumerable<PRT> PRTs 
	{ 
		get
		{
			for (int rep = 0; rep < PRTRepetitionsUsed; rep++)
			{
				yield return (PRT)this.GetStructure("PRT", rep);
			}
		}
	}

	///<summary>
	///Adds a new PRT
	///</summary>
	public PRT AddPRT()
	{
		return this.AddStructure("PRT") as PRT;
	}

	///<summary>
	///Removes the given PRT
	///</summary>
	public void RemovePRT(PRT toRemove)
	{
		this.RemoveStructure("PRT", toRemove);
	}

	///<summary>
	///Removes the PRT at the given index
	///</summary>
	public void RemovePRTAt(int index)
	{
		this.RemoveRepetition("PRT", index);
	}

	///<summary>
	/// Returns  first repetition of RAS_O17_TIMING (a Group object) - creates it if necessary
	///</summary>
	public RAS_O17_TIMING GetTIMING() {
	   RAS_O17_TIMING ret = null;
	   try {
	      ret = (RAS_O17_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RAS_O17_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RAS_O17_TIMING GetTIMING(int rep) { 
	   return (RAS_O17_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RAS_O17_TIMING 
	 */ 
	public int TIMINGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RAS_O17_TIMING results 
	 */ 
	public IEnumerable<RAS_O17_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (RAS_O17_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new RAS_O17_TIMING
	///</summary>
	public RAS_O17_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as RAS_O17_TIMING;
	}

	///<summary>
	///Removes the given RAS_O17_TIMING
	///</summary>
	public void RemoveTIMING(RAS_O17_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the RAS_O17_TIMING at the given index
	///</summary>
	public void RemoveTIMINGAt(int index)
	{
		this.RemoveRepetition("TIMING", index);
	}

	///<summary>
	/// Returns RAS_O17_ORDER_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public RAS_O17_ORDER_DETAIL ORDER_DETAIL { 
get{
	   RAS_O17_ORDER_DETAIL ret = null;
	   try {
	      ret = (RAS_O17_ORDER_DETAIL)this.GetStructure("ORDER_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RAS_O17_ENCODING (a Group object) - creates it if necessary
	///</summary>
	public RAS_O17_ENCODING ENCODING { 
get{
	   RAS_O17_ENCODING ret = null;
	   try {
	      ret = (RAS_O17_ENCODING)this.GetStructure("ENCODING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RAS_O17_ADMINISTRATION (a Group object) - creates it if necessary
	///</summary>
	public RAS_O17_ADMINISTRATION GetADMINISTRATION() {
	   RAS_O17_ADMINISTRATION ret = null;
	   try {
	      ret = (RAS_O17_ADMINISTRATION)this.GetStructure("ADMINISTRATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RAS_O17_ADMINISTRATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RAS_O17_ADMINISTRATION GetADMINISTRATION(int rep) { 
	   return (RAS_O17_ADMINISTRATION)this.GetStructure("ADMINISTRATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RAS_O17_ADMINISTRATION 
	 */ 
	public int ADMINISTRATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ADMINISTRATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RAS_O17_ADMINISTRATION results 
	 */ 
	public IEnumerable<RAS_O17_ADMINISTRATION> ADMINISTRATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < ADMINISTRATIONRepetitionsUsed; rep++)
			{
				yield return (RAS_O17_ADMINISTRATION)this.GetStructure("ADMINISTRATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new RAS_O17_ADMINISTRATION
	///</summary>
	public RAS_O17_ADMINISTRATION AddADMINISTRATION()
	{
		return this.AddStructure("ADMINISTRATION") as RAS_O17_ADMINISTRATION;
	}

	///<summary>
	///Removes the given RAS_O17_ADMINISTRATION
	///</summary>
	public void RemoveADMINISTRATION(RAS_O17_ADMINISTRATION toRemove)
	{
		this.RemoveStructure("ADMINISTRATION", toRemove);
	}

	///<summary>
	///Removes the RAS_O17_ADMINISTRATION at the given index
	///</summary>
	public void RemoveADMINISTRATIONAt(int index)
	{
		this.RemoveRepetition("ADMINISTRATION", index);
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
