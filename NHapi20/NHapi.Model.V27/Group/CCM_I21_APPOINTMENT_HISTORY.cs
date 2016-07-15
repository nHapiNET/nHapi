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
///Represents the CCM_I21_APPOINTMENT_HISTORY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SCH (Scheduling Activity Information) </li>
///<li>1: CCM_I21_RESOURCES (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCM_I21_APPOINTMENT_HISTORY : AbstractGroup {

	///<summary> 
	/// Creates a new CCM_I21_APPOINTMENT_HISTORY Group.
	///</summary>
	public CCM_I21_APPOINTMENT_HISTORY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SCH), true, false);
	      this.add(typeof(CCM_I21_RESOURCES), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCM_I21_APPOINTMENT_HISTORY - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns SCH (Scheduling Activity Information) - creates it if necessary
	///</summary>
	public SCH SCH { 
get{
	   SCH ret = null;
	   try {
	      ret = (SCH)this.GetStructure("SCH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_RESOURCES (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_RESOURCES GetRESOURCES() {
	   CCM_I21_RESOURCES ret = null;
	   try {
	      ret = (CCM_I21_RESOURCES)this.GetStructure("RESOURCES");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_RESOURCES
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_RESOURCES GetRESOURCES(int rep) { 
	   return (CCM_I21_RESOURCES)this.GetStructure("RESOURCES", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_RESOURCES 
	 */ 
	public int RESOURCESRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RESOURCES").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CCM_I21_RESOURCES results 
	 */ 
	public IEnumerable<CCM_I21_RESOURCES> RESOURCESs 
	{ 
		get
		{
			for (int rep = 0; rep < RESOURCESRepetitionsUsed; rep++)
			{
				yield return (CCM_I21_RESOURCES)this.GetStructure("RESOURCES", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCM_I21_RESOURCES
	///</summary>
	public CCM_I21_RESOURCES AddRESOURCES()
	{
		return this.AddStructure("RESOURCES") as CCM_I21_RESOURCES;
	}

	///<summary>
	///Removes the given CCM_I21_RESOURCES
	///</summary>
	public void RemoveRESOURCES(CCM_I21_RESOURCES toRemove)
	{
		this.RemoveStructure("RESOURCES", toRemove);
	}

	///<summary>
	///Removes the CCM_I21_RESOURCES at the given index
	///</summary>
	public void RemoveRESOURCESAt(int index)
	{
		this.RemoveRepetition("RESOURCES", index);
	}

}
}
