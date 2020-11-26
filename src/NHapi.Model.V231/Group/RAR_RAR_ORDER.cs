using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
///<summary>
///Represents the RAR_RAR_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (ORC - common order segment) </li>
///<li>1: RAR_RAR_ENCODING (a Group object) optional </li>
///<li>2: RXA (RXA - pharmacy/treatment administration segment) repeating</li>
///<li>3: RXR (RXR - pharmacy/treatment route segment) </li>
///</ol>
///</summary>
[Serializable]
public class RAR_RAR_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RAR_RAR_ORDER Group.
	///</summary>
	public RAR_RAR_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(RAR_RAR_ENCODING), false, false);
	      this.add(typeof(RXA), true, true);
	      this.add(typeof(RXR), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RAR_RAR_ORDER - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORC (ORC - common order segment) - creates it if necessary
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
	/// Returns RAR_RAR_ENCODING (a Group object) - creates it if necessary
	///</summary>
	public RAR_RAR_ENCODING ENCODING { 
get{
	   RAR_RAR_ENCODING ret = null;
	   try {
	      ret = (RAR_RAR_ENCODING)this.GetStructure("ENCODING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RXA (RXA - pharmacy/treatment administration segment) - creates it if necessary
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
	/// * (RXA - pharmacy/treatment administration segment) - creates it if necessary
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
	/// Returns RXR (RXR - pharmacy/treatment route segment) - creates it if necessary
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
