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
///Represents the RSP_Z82_COMMON_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: RSP_Z82_TIMING (a Group object) optional repeating</li>
///<li>2: RSP_Z82_ORDER_DETAIL (a Group object) optional </li>
///<li>3: RSP_Z82_ENCODED_ORDER (a Group object) optional </li>
///<li>4: RXD (Pharmacy/Treatment Dispense) </li>
///<li>5: RXR (Pharmacy/Treatment Route) repeating</li>
///<li>6: RXC (Pharmacy/Treatment Component Order) optional repeating</li>
///<li>7: RSP_Z82_OBSERVATION (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class RSP_Z82_COMMON_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RSP_Z82_COMMON_ORDER Group.
	///</summary>
	public RSP_Z82_COMMON_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(RSP_Z82_TIMING), false, true);
	      this.add(typeof(RSP_Z82_ORDER_DETAIL), false, false);
	      this.add(typeof(RSP_Z82_ENCODED_ORDER), false, false);
	      this.add(typeof(RXD), true, false);
	      this.add(typeof(RXR), true, true);
	      this.add(typeof(RXC), false, true);
	      this.add(typeof(RSP_Z82_OBSERVATION), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RSP_Z82_COMMON_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of RSP_Z82_TIMING (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z82_TIMING GetTIMING() {
	   RSP_Z82_TIMING ret = null;
	   try {
	      ret = (RSP_Z82_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RSP_Z82_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RSP_Z82_TIMING GetTIMING(int rep) { 
	   return (RSP_Z82_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RSP_Z82_TIMING 
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
	 * Enumerate over the RSP_Z82_TIMING results 
	 */ 
	public IEnumerable<RSP_Z82_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (RSP_Z82_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new RSP_Z82_TIMING
	///</summary>
	public RSP_Z82_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as RSP_Z82_TIMING;
	}

	///<summary>
	///Removes the given RSP_Z82_TIMING
	///</summary>
	public void RemoveTIMING(RSP_Z82_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the RSP_Z82_TIMING at the given index
	///</summary>
	public void RemoveTIMINGAt(int index)
	{
		this.RemoveRepetition("TIMING", index);
	}

	///<summary>
	/// Returns RSP_Z82_ORDER_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z82_ORDER_DETAIL ORDER_DETAIL { 
get{
	   RSP_Z82_ORDER_DETAIL ret = null;
	   try {
	      ret = (RSP_Z82_ORDER_DETAIL)this.GetStructure("ORDER_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RSP_Z82_ENCODED_ORDER (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z82_ENCODED_ORDER ENCODED_ORDER { 
get{
	   RSP_Z82_ENCODED_ORDER ret = null;
	   try {
	      ret = (RSP_Z82_ENCODED_ORDER)this.GetStructure("ENCODED_ORDER");
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
	/// Returns  first repetition of RSP_Z82_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z82_OBSERVATION GetOBSERVATION() {
	   RSP_Z82_OBSERVATION ret = null;
	   try {
	      ret = (RSP_Z82_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RSP_Z82_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RSP_Z82_OBSERVATION GetOBSERVATION(int rep) { 
	   return (RSP_Z82_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RSP_Z82_OBSERVATION 
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
	 * Enumerate over the RSP_Z82_OBSERVATION results 
	 */ 
	public IEnumerable<RSP_Z82_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (RSP_Z82_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new RSP_Z82_OBSERVATION
	///</summary>
	public RSP_Z82_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as RSP_Z82_OBSERVATION;
	}

	///<summary>
	///Removes the given RSP_Z82_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(RSP_Z82_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the RSP_Z82_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

}
}
