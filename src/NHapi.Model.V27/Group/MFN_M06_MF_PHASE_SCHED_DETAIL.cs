using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V27.Segment;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the MFN_M06_MF_PHASE_SCHED_DETAIL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: CM1 (Clinical Study Phase Master) </li>
///<li>1: CM2 (Clinical Study Schedule Master) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M06_MF_PHASE_SCHED_DETAIL : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M06_MF_PHASE_SCHED_DETAIL Group.
	///</summary>
	public MFN_M06_MF_PHASE_SCHED_DETAIL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(CM1), true, false);
	      this.add(typeof(CM2), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M06_MF_PHASE_SCHED_DETAIL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns CM1 (Clinical Study Phase Master) - creates it if necessary
	///</summary>
	public CM1 CM1 { 
get{
	   CM1 ret = null;
	   try {
	      ret = (CM1)this.GetStructure("CM1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CM2 (Clinical Study Schedule Master) - creates it if necessary
	///</summary>
	public CM2 GetCM2() {
	   CM2 ret = null;
	   try {
	      ret = (CM2)this.GetStructure("CM2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CM2
	/// * (Clinical Study Schedule Master) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CM2 GetCM2(int rep) { 
	   return (CM2)this.GetStructure("CM2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CM2 
	 */ 
	public int CM2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CM2").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CM2 results 
	 */ 
	public IEnumerable<CM2> CM2s 
	{ 
		get
		{
			for (int rep = 0; rep < CM2RepetitionsUsed; rep++)
			{
				yield return (CM2)this.GetStructure("CM2", rep);
			}
		}
	}

	///<summary>
	///Adds a new CM2
	///</summary>
	public CM2 AddCM2()
	{
		return this.AddStructure("CM2") as CM2;
	}

	///<summary>
	///Removes the given CM2
	///</summary>
	public void RemoveCM2(CM2 toRemove)
	{
		this.RemoveStructure("CM2", toRemove);
	}

	///<summary>
	///Removes the CM2 at the given index
	///</summary>
	public void RemoveCM2At(int index)
	{
		this.RemoveRepetition("CM2", index);
	}

}
}
