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
///Represents the RQA_I08_GUARANTOR_INSURANCE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: GT1 (GT1 - guarantor segment) optional repeating</li>
///<li>1: RQA_I08_INSURANCE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class RQA_I08_GUARANTOR_INSURANCE : AbstractGroup {

	///<summary> 
	/// Creates a new RQA_I08_GUARANTOR_INSURANCE Group.
	///</summary>
	public RQA_I08_GUARANTOR_INSURANCE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(GT1), false, true);
	      this.add(typeof(RQA_I08_INSURANCE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RQA_I08_GUARANTOR_INSURANCE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns  first repetition of GT1 (GT1 - guarantor segment) - creates it if necessary
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
	/// * (GT1 - guarantor segment) - creates it if necessary
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
	/// Returns  first repetition of RQA_I08_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public RQA_I08_INSURANCE GetINSURANCE() {
	   RQA_I08_INSURANCE ret = null;
	   try {
	      ret = (RQA_I08_INSURANCE)this.GetStructure("INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RQA_I08_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RQA_I08_INSURANCE GetINSURANCE(int rep) { 
	   return (RQA_I08_INSURANCE)this.GetStructure("INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RQA_I08_INSURANCE 
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
	 * Enumerate over the RQA_I08_INSURANCE results 
	 */ 
	public IEnumerable<RQA_I08_INSURANCE> INSURANCEs 
	{ 
		get
		{
			for (int rep = 0; rep < INSURANCERepetitionsUsed; rep++)
			{
				yield return (RQA_I08_INSURANCE)this.GetStructure("INSURANCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new RQA_I08_INSURANCE
	///</summary>
	public RQA_I08_INSURANCE AddINSURANCE()
	{
		return this.AddStructure("INSURANCE") as RQA_I08_INSURANCE;
	}

	///<summary>
	///Removes the given RQA_I08_INSURANCE
	///</summary>
	public void RemoveINSURANCE(RQA_I08_INSURANCE toRemove)
	{
		this.RemoveStructure("INSURANCE", toRemove);
	}

	///<summary>
	///Removes the RQA_I08_INSURANCE at the given index
	///</summary>
	public void RemoveINSURANCEAt(int index)
	{
		this.RemoveRepetition("INSURANCE", index);
	}

}
}
