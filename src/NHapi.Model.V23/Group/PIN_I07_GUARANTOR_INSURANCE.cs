using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V23.Segment;
using NHapi.Model.V23.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V23.Group
{
///<summary>
///Represents the PIN_I07_GUARANTOR_INSURANCE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: GT1 (Guarantor) optional repeating</li>
///<li>1: PIN_I07_INSURANCE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class PIN_I07_GUARANTOR_INSURANCE : AbstractGroup {

	///<summary> 
	/// Creates a new PIN_I07_GUARANTOR_INSURANCE Group.
	///</summary>
	public PIN_I07_GUARANTOR_INSURANCE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(GT1), false, true);
	      this.add(typeof(PIN_I07_INSURANCE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PIN_I07_GUARANTOR_INSURANCE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns  first repetition of GT1 (Guarantor) - creates it if necessary
	///</summary>
	public GT1 GetGT1() {
	   GT1 ret = null;
	   try {
	      ret = (GT1)this.GetStructure("GT1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of GT1
	/// * (Guarantor) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public GT1 GetGT1(int rep) { 
	   return (GT1)this.GetStructure("GT1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of GT1 
	 */ 
	public int GT1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("GT1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the GT1 results 
	 */ 
	public IEnumerable<GT1> GT1s 
	{ 
		get
		{
			for (int rep = 0; rep < GT1RepetitionsUsed; rep++)
			{
				yield return (GT1)this.GetStructure("GT1", rep);
			}
		}
	}

	///<summary>
	///Adds a new GT1
	///</summary>
	public GT1 AddGT1()
	{
		return this.AddStructure("GT1") as GT1;
	}

	///<summary>
	///Removes the given GT1
	///</summary>
	public void RemoveGT1(GT1 toRemove)
	{
		this.RemoveStructure("GT1", toRemove);
	}

	///<summary>
	///Removes the GT1 at the given index
	///</summary>
	public void RemoveGT1At(int index)
	{
		this.RemoveRepetition("GT1", index);
	}

	///<summary>
	/// Returns  first repetition of PIN_I07_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public PIN_I07_INSURANCE GetINSURANCE() {
	   PIN_I07_INSURANCE ret = null;
	   try {
	      ret = (PIN_I07_INSURANCE)this.GetStructure("INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PIN_I07_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PIN_I07_INSURANCE GetINSURANCE(int rep) { 
	   return (PIN_I07_INSURANCE)this.GetStructure("INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PIN_I07_INSURANCE 
	 */ 
	public int INSURANCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("INSURANCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PIN_I07_INSURANCE results 
	 */ 
	public IEnumerable<PIN_I07_INSURANCE> INSURANCEs 
	{ 
		get
		{
			for (int rep = 0; rep < INSURANCERepetitionsUsed; rep++)
			{
				yield return (PIN_I07_INSURANCE)this.GetStructure("INSURANCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new PIN_I07_INSURANCE
	///</summary>
	public PIN_I07_INSURANCE AddINSURANCE()
	{
		return this.AddStructure("INSURANCE") as PIN_I07_INSURANCE;
	}

	///<summary>
	///Removes the given PIN_I07_INSURANCE
	///</summary>
	public void RemoveINSURANCE(PIN_I07_INSURANCE toRemove)
	{
		this.RemoveStructure("INSURANCE", toRemove);
	}

	///<summary>
	///Removes the PIN_I07_INSURANCE at the given index
	///</summary>
	public void RemoveINSURANCEAt(int index)
	{
		this.RemoveRepetition("INSURANCE", index);
	}

}
}
