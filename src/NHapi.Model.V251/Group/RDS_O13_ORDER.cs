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
///Represents the RDS_O13_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: RDS_O13_TIMING (a Group object) optional repeating</li>
///<li>2: RDS_O13_ORDER_DETAIL (a Group object) optional </li>
///<li>3: RDS_O13_ENCODING (a Group object) optional </li>
///<li>4: RXD (Pharmacy/Treatment Dispense) </li>
///<li>5: NTE (Notes and Comments) optional repeating</li>
///<li>6: RXR (Pharmacy/Treatment Route) repeating</li>
///<li>7: RXC (Pharmacy/Treatment Component Order) optional repeating</li>
///<li>8: RDS_O13_OBSERVATION (a Group object) optional repeating</li>
///<li>9: FT1 (Financial Transaction) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RDS_O13_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RDS_O13_ORDER Group.
	///</summary>
	public RDS_O13_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(RDS_O13_TIMING), false, true);
	      this.add(typeof(RDS_O13_ORDER_DETAIL), false, false);
	      this.add(typeof(RDS_O13_ENCODING), false, false);
	      this.add(typeof(RXD), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(RXR), true, true);
	      this.add(typeof(RXC), false, true);
	      this.add(typeof(RDS_O13_OBSERVATION), false, true);
	      this.add(typeof(FT1), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RDS_O13_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of RDS_O13_TIMING (a Group object) - creates it if necessary
	///</summary>
	public RDS_O13_TIMING GetTIMING() {
	   RDS_O13_TIMING ret = null;
	   try {
	      ret = (RDS_O13_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RDS_O13_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RDS_O13_TIMING GetTIMING(int rep) { 
	   return (RDS_O13_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RDS_O13_TIMING 
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
	 * Enumerate over the RDS_O13_TIMING results 
	 */ 
	public IEnumerable<RDS_O13_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (RDS_O13_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new RDS_O13_TIMING
	///</summary>
	public RDS_O13_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as RDS_O13_TIMING;
	}

	///<summary>
	///Removes the given RDS_O13_TIMING
	///</summary>
	public void RemoveTIMING(RDS_O13_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the RDS_O13_TIMING at the given index
	///</summary>
	public void RemoveTIMINGAt(int index)
	{
		this.RemoveRepetition("TIMING", index);
	}

	///<summary>
	/// Returns RDS_O13_ORDER_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public RDS_O13_ORDER_DETAIL ORDER_DETAIL { 
get{
	   RDS_O13_ORDER_DETAIL ret = null;
	   try {
	      ret = (RDS_O13_ORDER_DETAIL)this.GetStructure("ORDER_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RDS_O13_ENCODING (a Group object) - creates it if necessary
	///</summary>
	public RDS_O13_ENCODING ENCODING { 
get{
	   RDS_O13_ENCODING ret = null;
	   try {
	      ret = (RDS_O13_ENCODING)this.GetStructure("ENCODING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RXD (Pharmacy/Treatment Dispense) - creates it if necessary
	///</summary>
	public RXD RXD { 
get{
	   RXD ret = null;
	   try {
	      ret = (RXD)this.GetStructure("RXD");
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
	/// Returns  first repetition of RXR (Pharmacy/Treatment Route) - creates it if necessary
	///</summary>
	public RXR GetRXR() {
	   RXR ret = null;
	   try {
	      ret = (RXR)this.GetStructure("RXR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RXR
	/// * (Pharmacy/Treatment Route) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RXR GetRXR(int rep) { 
	   return (RXR)this.GetStructure("RXR", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RXR 
	 */ 
	public int RXRRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RXR").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RXR results 
	 */ 
	public IEnumerable<RXR> RXRs 
	{ 
		get
		{
			for (int rep = 0; rep < RXRRepetitionsUsed; rep++)
			{
				yield return (RXR)this.GetStructure("RXR", rep);
			}
		}
	}

	///<summary>
	///Adds a new RXR
	///</summary>
	public RXR AddRXR()
	{
		return this.AddStructure("RXR") as RXR;
	}

	///<summary>
	///Removes the given RXR
	///</summary>
	public void RemoveRXR(RXR toRemove)
	{
		this.RemoveStructure("RXR", toRemove);
	}

	///<summary>
	///Removes the RXR at the given index
	///</summary>
	public void RemoveRXRAt(int index)
	{
		this.RemoveRepetition("RXR", index);
	}

	///<summary>
	/// Returns  first repetition of RXC (Pharmacy/Treatment Component Order) - creates it if necessary
	///</summary>
	public RXC GetRXC() {
	   RXC ret = null;
	   try {
	      ret = (RXC)this.GetStructure("RXC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RXC
	/// * (Pharmacy/Treatment Component Order) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RXC GetRXC(int rep) { 
	   return (RXC)this.GetStructure("RXC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RXC 
	 */ 
	public int RXCRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RXC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RXC results 
	 */ 
	public IEnumerable<RXC> RXCs 
	{ 
		get
		{
			for (int rep = 0; rep < RXCRepetitionsUsed; rep++)
			{
				yield return (RXC)this.GetStructure("RXC", rep);
			}
		}
	}

	///<summary>
	///Adds a new RXC
	///</summary>
	public RXC AddRXC()
	{
		return this.AddStructure("RXC") as RXC;
	}

	///<summary>
	///Removes the given RXC
	///</summary>
	public void RemoveRXC(RXC toRemove)
	{
		this.RemoveStructure("RXC", toRemove);
	}

	///<summary>
	///Removes the RXC at the given index
	///</summary>
	public void RemoveRXCAt(int index)
	{
		this.RemoveRepetition("RXC", index);
	}

	///<summary>
	/// Returns  first repetition of RDS_O13_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public RDS_O13_OBSERVATION GetOBSERVATION() {
	   RDS_O13_OBSERVATION ret = null;
	   try {
	      ret = (RDS_O13_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RDS_O13_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RDS_O13_OBSERVATION GetOBSERVATION(int rep) { 
	   return (RDS_O13_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RDS_O13_OBSERVATION 
	 */ 
	public int OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RDS_O13_OBSERVATION results 
	 */ 
	public IEnumerable<RDS_O13_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (RDS_O13_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new RDS_O13_OBSERVATION
	///</summary>
	public RDS_O13_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as RDS_O13_OBSERVATION;
	}

	///<summary>
	///Removes the given RDS_O13_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(RDS_O13_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the RDS_O13_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of FT1 (Financial Transaction) - creates it if necessary
	///</summary>
	public FT1 GetFT1() {
	   FT1 ret = null;
	   try {
	      ret = (FT1)this.GetStructure("FT1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of FT1
	/// * (Financial Transaction) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public FT1 GetFT1(int rep) { 
	   return (FT1)this.GetStructure("FT1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of FT1 
	 */ 
	public int FT1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("FT1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the FT1 results 
	 */ 
	public IEnumerable<FT1> FT1s 
	{ 
		get
		{
			for (int rep = 0; rep < FT1RepetitionsUsed; rep++)
			{
				yield return (FT1)this.GetStructure("FT1", rep);
			}
		}
	}

	///<summary>
	///Adds a new FT1
	///</summary>
	public FT1 AddFT1()
	{
		return this.AddStructure("FT1") as FT1;
	}

	///<summary>
	///Removes the given FT1
	///</summary>
	public void RemoveFT1(FT1 toRemove)
	{
		this.RemoveStructure("FT1", toRemove);
	}

	///<summary>
	///Removes the FT1 at the given index
	///</summary>
	public void RemoveFT1At(int index)
	{
		this.RemoveRepetition("FT1", index);
	}

}
}
