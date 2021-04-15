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
///Represents the RRG_O16_GIVE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RXG (Pharmacy/Treatment Give) </li>
///<li>1: RRG_O16_TIMING_GIVE (a Group object) repeating</li>
///<li>2: RXR (Pharmacy/Treatment Route) repeating</li>
///<li>3: RXC (Pharmacy/Treatment Component Order) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RRG_O16_GIVE : AbstractGroup {

	///<summary> 
	/// Creates a new RRG_O16_GIVE Group.
	///</summary>
	public RRG_O16_GIVE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RXG), true, false);
	      this.add(typeof(RRG_O16_TIMING_GIVE), true, true);
	      this.add(typeof(RXR), true, true);
	      this.add(typeof(RXC), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RRG_O16_GIVE - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of RRG_O16_TIMING_GIVE (a Group object) - creates it if necessary
	///</summary>
	public RRG_O16_TIMING_GIVE GetTIMING_GIVE() {
	   RRG_O16_TIMING_GIVE ret = null;
	   try {
	      ret = (RRG_O16_TIMING_GIVE)this.GetStructure("TIMING_GIVE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RRG_O16_TIMING_GIVE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RRG_O16_TIMING_GIVE GetTIMING_GIVE(int rep) { 
	   return (RRG_O16_TIMING_GIVE)this.GetStructure("TIMING_GIVE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RRG_O16_TIMING_GIVE 
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
	 * Enumerate over the RRG_O16_TIMING_GIVE results 
	 */ 
	public IEnumerable<RRG_O16_TIMING_GIVE> TIMING_GIVEs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMING_GIVERepetitionsUsed; rep++)
			{
				yield return (RRG_O16_TIMING_GIVE)this.GetStructure("TIMING_GIVE", rep);
			}
		}
	}

	///<summary>
	///Adds a new RRG_O16_TIMING_GIVE
	///</summary>
	public RRG_O16_TIMING_GIVE AddTIMING_GIVE()
	{
		return this.AddStructure("TIMING_GIVE") as RRG_O16_TIMING_GIVE;
	}

	///<summary>
	///Removes the given RRG_O16_TIMING_GIVE
	///</summary>
	public void RemoveTIMING_GIVE(RRG_O16_TIMING_GIVE toRemove)
	{
		this.RemoveStructure("TIMING_GIVE", toRemove);
	}

	///<summary>
	///Removes the RRG_O16_TIMING_GIVE at the given index
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

}
}
