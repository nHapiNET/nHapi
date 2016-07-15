using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Group
{
///<summary>
///Represents the PEX_P07_ASSOCIATED_RX_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RXE (Pharmacy/Treatment Encoded Order) </li>
///<li>1: PEX_P07_NK1_TIMING_QTY (a Group object) repeating</li>
///<li>2: RXR (Pharmacy/Treatment Route) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class PEX_P07_ASSOCIATED_RX_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new PEX_P07_ASSOCIATED_RX_ORDER Group.
	///</summary>
	public PEX_P07_ASSOCIATED_RX_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RXE), true, false);
	      this.add(typeof(PEX_P07_NK1_TIMING_QTY), true, true);
	      this.add(typeof(RXR), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PEX_P07_ASSOCIATED_RX_ORDER - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RXE (Pharmacy/Treatment Encoded Order) - creates it if necessary
	///</summary>
	public RXE RXE { 
get{
	   RXE ret = null;
	   try {
	      ret = (RXE)this.GetStructure("RXE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PEX_P07_NK1_TIMING_QTY (a Group object) - creates it if necessary
	///</summary>
	public PEX_P07_NK1_TIMING_QTY GetNK1_TIMING_QTY() {
	   PEX_P07_NK1_TIMING_QTY ret = null;
	   try {
	      ret = (PEX_P07_NK1_TIMING_QTY)this.GetStructure("NK1_TIMING_QTY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PEX_P07_NK1_TIMING_QTY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PEX_P07_NK1_TIMING_QTY GetNK1_TIMING_QTY(int rep) { 
	   return (PEX_P07_NK1_TIMING_QTY)this.GetStructure("NK1_TIMING_QTY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PEX_P07_NK1_TIMING_QTY 
	 */ 
	public int NK1_TIMING_QTYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NK1_TIMING_QTY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PEX_P07_NK1_TIMING_QTY results 
	 */ 
	public IEnumerable<PEX_P07_NK1_TIMING_QTY> NK1_TIMING_QTYs 
	{ 
		get
		{
			for (int rep = 0; rep < NK1_TIMING_QTYRepetitionsUsed; rep++)
			{
				yield return (PEX_P07_NK1_TIMING_QTY)this.GetStructure("NK1_TIMING_QTY", rep);
			}
		}
	}

	///<summary>
	///Adds a new PEX_P07_NK1_TIMING_QTY
	///</summary>
	public PEX_P07_NK1_TIMING_QTY AddNK1_TIMING_QTY()
	{
		return this.AddStructure("NK1_TIMING_QTY") as PEX_P07_NK1_TIMING_QTY;
	}

	///<summary>
	///Removes the given PEX_P07_NK1_TIMING_QTY
	///</summary>
	public void RemoveNK1_TIMING_QTY(PEX_P07_NK1_TIMING_QTY toRemove)
	{
		this.RemoveStructure("NK1_TIMING_QTY", toRemove);
	}

	///<summary>
	///Removes the PEX_P07_NK1_TIMING_QTY at the given index
	///</summary>
	public void RemoveNK1_TIMING_QTYAt(int index)
	{
		this.RemoveRepetition("NK1_TIMING_QTY", index);
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

}
}
