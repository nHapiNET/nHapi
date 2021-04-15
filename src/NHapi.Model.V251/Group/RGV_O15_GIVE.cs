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
///Represents the RGV_O15_GIVE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RXG (Pharmacy/Treatment Give) </li>
///<li>1: RGV_O15_TIMING_GIVE (a Group object) repeating</li>
///<li>2: RXR (Pharmacy/Treatment Route) repeating</li>
///<li>3: RXC (Pharmacy/Treatment Component Order) optional repeating</li>
///<li>4: RGV_O15_OBSERVATION (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class RGV_O15_GIVE : AbstractGroup {

	///<summary> 
	/// Creates a new RGV_O15_GIVE Group.
	///</summary>
	public RGV_O15_GIVE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RXG), true, false);
	      this.add(typeof(RGV_O15_TIMING_GIVE), true, true);
	      this.add(typeof(RXR), true, true);
	      this.add(typeof(RXC), false, true);
	      this.add(typeof(RGV_O15_OBSERVATION), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RGV_O15_GIVE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RXG (Pharmacy/Treatment Give) - creates it if necessary
	///</summary>
	public RXG RXG { 
get{
	   RXG ret = null;
	   try {
	      ret = (RXG)this.GetStructure("RXG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RGV_O15_TIMING_GIVE (a Group object) - creates it if necessary
	///</summary>
	public RGV_O15_TIMING_GIVE GetTIMING_GIVE() {
	   RGV_O15_TIMING_GIVE ret = null;
	   try {
	      ret = (RGV_O15_TIMING_GIVE)this.GetStructure("TIMING_GIVE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RGV_O15_TIMING_GIVE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RGV_O15_TIMING_GIVE GetTIMING_GIVE(int rep) { 
	   return (RGV_O15_TIMING_GIVE)this.GetStructure("TIMING_GIVE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RGV_O15_TIMING_GIVE 
	 */ 
	public int TIMING_GIVERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING_GIVE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RGV_O15_TIMING_GIVE results 
	 */ 
	public IEnumerable<RGV_O15_TIMING_GIVE> TIMING_GIVEs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMING_GIVERepetitionsUsed; rep++)
			{
				yield return (RGV_O15_TIMING_GIVE)this.GetStructure("TIMING_GIVE", rep);
			}
		}
	}

	///<summary>
	///Adds a new RGV_O15_TIMING_GIVE
	///</summary>
	public RGV_O15_TIMING_GIVE AddTIMING_GIVE()
	{
		return this.AddStructure("TIMING_GIVE") as RGV_O15_TIMING_GIVE;
	}

	///<summary>
	///Removes the given RGV_O15_TIMING_GIVE
	///</summary>
	public void RemoveTIMING_GIVE(RGV_O15_TIMING_GIVE toRemove)
	{
		this.RemoveStructure("TIMING_GIVE", toRemove);
	}

	///<summary>
	///Removes the RGV_O15_TIMING_GIVE at the given index
	///</summary>
	public void RemoveTIMING_GIVEAt(int index)
	{
		this.RemoveRepetition("TIMING_GIVE", index);
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
	/// Returns  first repetition of RGV_O15_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public RGV_O15_OBSERVATION GetOBSERVATION() {
	   RGV_O15_OBSERVATION ret = null;
	   try {
	      ret = (RGV_O15_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RGV_O15_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RGV_O15_OBSERVATION GetOBSERVATION(int rep) { 
	   return (RGV_O15_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RGV_O15_OBSERVATION 
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
	 * Enumerate over the RGV_O15_OBSERVATION results 
	 */ 
	public IEnumerable<RGV_O15_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (RGV_O15_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new RGV_O15_OBSERVATION
	///</summary>
	public RGV_O15_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as RGV_O15_OBSERVATION;
	}

	///<summary>
	///Removes the given RGV_O15_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(RGV_O15_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the RGV_O15_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

}
}
