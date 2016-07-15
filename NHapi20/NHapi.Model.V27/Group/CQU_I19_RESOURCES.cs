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
///Represents the CQU_I19_RESOURCES Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RGS (Resource Group) </li>
///<li>1: CQU_I19_RESOURCE_DETAIL (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CQU_I19_RESOURCES : AbstractGroup {

	///<summary> 
	/// Creates a new CQU_I19_RESOURCES Group.
	///</summary>
	public CQU_I19_RESOURCES(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RGS), true, false);
	      this.add(typeof(CQU_I19_RESOURCE_DETAIL), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CQU_I19_RESOURCES - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RGS (Resource Group) - creates it if necessary
	///</summary>
	public RGS RGS { 
get{
	   RGS ret = null;
	   try {
	      ret = (RGS)this.GetStructure("RGS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_RESOURCE_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_RESOURCE_DETAIL GetRESOURCE_DETAIL() {
	   CQU_I19_RESOURCE_DETAIL ret = null;
	   try {
	      ret = (CQU_I19_RESOURCE_DETAIL)this.GetStructure("RESOURCE_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_RESOURCE_DETAIL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_RESOURCE_DETAIL GetRESOURCE_DETAIL(int rep) { 
	   return (CQU_I19_RESOURCE_DETAIL)this.GetStructure("RESOURCE_DETAIL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_RESOURCE_DETAIL 
	 */ 
	public int RESOURCE_DETAILRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RESOURCE_DETAIL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_RESOURCE_DETAIL results 
	 */ 
	public IEnumerable<CQU_I19_RESOURCE_DETAIL> RESOURCE_DETAILs 
	{ 
		get
		{
			for (int rep = 0; rep < RESOURCE_DETAILRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_RESOURCE_DETAIL)this.GetStructure("RESOURCE_DETAIL", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_RESOURCE_DETAIL
	///</summary>
	public CQU_I19_RESOURCE_DETAIL AddRESOURCE_DETAIL()
	{
		return this.AddStructure("RESOURCE_DETAIL") as CQU_I19_RESOURCE_DETAIL;
	}

	///<summary>
	///Removes the given CQU_I19_RESOURCE_DETAIL
	///</summary>
	public void RemoveRESOURCE_DETAIL(CQU_I19_RESOURCE_DETAIL toRemove)
	{
		this.RemoveStructure("RESOURCE_DETAIL", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_RESOURCE_DETAIL at the given index
	///</summary>
	public void RemoveRESOURCE_DETAILAt(int index)
	{
		this.RemoveRepetition("RESOURCE_DETAIL", index);
	}

}
}
