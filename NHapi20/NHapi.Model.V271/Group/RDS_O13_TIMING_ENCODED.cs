using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V271.Segment;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V271.Group
{
///<summary>
///Represents the RDS_O13_TIMING_ENCODED Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: TQ1 (Timing/Quantity) </li>
///<li>1: TQ2 (Timing/Quantity Relationship) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RDS_O13_TIMING_ENCODED : AbstractGroup {

	///<summary> 
	/// Creates a new RDS_O13_TIMING_ENCODED Group.
	///</summary>
	public RDS_O13_TIMING_ENCODED(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(TQ1), true, false);
	      this.add(typeof(TQ2), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RDS_O13_TIMING_ENCODED - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns TQ1 (Timing/Quantity) - creates it if necessary
	///</summary>
	public TQ1 TQ1 { 
get{
	   TQ1 ret = null;
	   try {
	      ret = (TQ1)this.GetStructure("TQ1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of TQ2 (Timing/Quantity Relationship) - creates it if necessary
	///</summary>
	public TQ2 GetTQ2() {
	   TQ2 ret = null;
	   try {
	      ret = (TQ2)this.GetStructure("TQ2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of TQ2
	/// * (Timing/Quantity Relationship) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public TQ2 GetTQ2(int rep) { 
	   return (TQ2)this.GetStructure("TQ2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of TQ2 
	 */ 
	public int TQ2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TQ2").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the TQ2 results 
	 */ 
	public IEnumerable<TQ2> TQ2s 
	{ 
		get
		{
			for (int rep = 0; rep < TQ2RepetitionsUsed; rep++)
			{
				yield return (TQ2)this.GetStructure("TQ2", rep);
			}
		}
	}

	///<summary>
	///Adds a new TQ2
	///</summary>
	public TQ2 AddTQ2()
	{
		return this.AddStructure("TQ2") as TQ2;
	}

	///<summary>
	///Removes the given TQ2
	///</summary>
	public void RemoveTQ2(TQ2 toRemove)
	{
		this.RemoveStructure("TQ2", toRemove);
	}

	///<summary>
	///Removes the TQ2 at the given index
	///</summary>
	public void RemoveTQ2At(int index)
	{
		this.RemoveRepetition("TQ2", index);
	}

}
}
