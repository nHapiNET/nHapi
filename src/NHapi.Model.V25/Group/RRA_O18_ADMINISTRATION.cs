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
///Represents the RRA_O18_ADMINISTRATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RXA (Pharmacy/Treatment Administration) repeating</li>
///<li>1: RXR (Pharmacy/Treatment Route) </li>
///</ol>
///</summary>
[Serializable]
public class RRA_O18_ADMINISTRATION : AbstractGroup {

	///<summary> 
	/// Creates a new RRA_O18_ADMINISTRATION Group.
	///</summary>
	public RRA_O18_ADMINISTRATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RXA), true, true);
	      this.add(typeof(RXR), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RRA_O18_ADMINISTRATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns  first repetition of RXA (Pharmacy/Treatment Administration) - creates it if necessary
	///</summary>
	public RXA GetRXA() {
	   RXA ret = null;
	   try {
	      ret = (RXA)this.GetStructure("RXA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RXA
	/// * (Pharmacy/Treatment Administration) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RXA GetRXA(int rep) { 
	   return (RXA)this.GetStructure("RXA", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RXA 
	 */ 
	public int RXARepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RXA").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RXA results 
	 */ 
	public IEnumerable<RXA> RXAs 
	{ 
		get
		{
			for (int rep = 0; rep < RXARepetitionsUsed; rep++)
			{
				yield return (RXA)this.GetStructure("RXA", rep);
			}
		}
	}

	///<summary>
	///Adds a new RXA
	///</summary>
	public RXA AddRXA()
	{
		return this.AddStructure("RXA") as RXA;
	}

	///<summary>
	///Removes the given RXA
	///</summary>
	public void RemoveRXA(RXA toRemove)
	{
		this.RemoveStructure("RXA", toRemove);
	}

	///<summary>
	///Removes the RXA at the given index
	///</summary>
	public void RemoveRXAAt(int index)
	{
		this.RemoveRepetition("RXA", index);
	}

	///<summary>
	/// Returns RXR (Pharmacy/Treatment Route) - creates it if necessary
	///</summary>
	public RXR RXR { 
get{
	   RXR ret = null;
	   try {
	      ret = (RXR)this.GetStructure("RXR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
