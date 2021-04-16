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
///Represents the ADT_A28_INSURANCE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: IN1 (IN1 - insurance segment) </li>
///<li>1: IN2 (IN2 - insurance additional information segment) optional </li>
///<li>2: IN3 (IN3 - insurance additional information, certification segment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ADT_A28_INSURANCE : AbstractGroup {

	///<summary> 
	/// Creates a new ADT_A28_INSURANCE Group.
	///</summary>
	public ADT_A28_INSURANCE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(IN1), true, false);
	      this.add(typeof(IN2), false, false);
	      this.add(typeof(IN3), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ADT_A28_INSURANCE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns IN1 (IN1 - insurance segment) - creates it if necessary
	///</summary>
	public IN1 IN1 { 
get{
	   IN1 ret = null;
	   try {
	      ret = (IN1)this.GetStructure("IN1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns IN2 (IN2 - insurance additional information segment) - creates it if necessary
	///</summary>
	public IN2 IN2 { 
get{
	   IN2 ret = null;
	   try {
	      ret = (IN2)this.GetStructure("IN2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of IN3 (IN3 - insurance additional information, certification segment) - creates it if necessary
	///</summary>
	public IN3 GetIN3() {
	   IN3 ret = null;
	   try {
	      ret = (IN3)this.GetStructure("IN3");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of IN3
	/// * (IN3 - insurance additional information, certification segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public IN3 GetIN3(int rep) { 
	   return (IN3)this.GetStructure("IN3", rep);
	}

	/** 
	 * Returns the number of existing repetitions of IN3 
	 */ 
	public int IN3RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("IN3").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the IN3 results 
	 */ 
	public IEnumerable<IN3> IN3s 
	{ 
		get
		{
			for (int rep = 0; rep < IN3RepetitionsUsed; rep++)
			{
				yield return (IN3)this.GetStructure("IN3", rep);
			}
		}
	}

	///<summary>
	///Adds a new IN3
	///</summary>
	public IN3 AddIN3()
	{
		return this.AddStructure("IN3") as IN3;
	}

	///<summary>
	///Removes the given IN3
	///</summary>
	public void RemoveIN3(IN3 toRemove)
	{
		this.RemoveStructure("IN3", toRemove);
	}

	///<summary>
	///Removes the IN3 at the given index
	///</summary>
	public void RemoveIN3At(int index)
	{
		this.RemoveRepetition("IN3", index);
	}

}
}
