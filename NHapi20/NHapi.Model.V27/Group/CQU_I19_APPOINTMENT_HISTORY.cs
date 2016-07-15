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
///Represents the CQU_I19_APPOINTMENT_HISTORY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SCH (Scheduling Activity Information) </li>
///<li>1: CQU_I19_RESOURCES (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CQU_I19_APPOINTMENT_HISTORY : AbstractGroup {

	///<summary> 
	/// Creates a new CQU_I19_APPOINTMENT_HISTORY Group.
	///</summary>
	public CQU_I19_APPOINTMENT_HISTORY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SCH), true, false);
	      this.add(typeof(CQU_I19_RESOURCES), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CQU_I19_APPOINTMENT_HISTORY - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of CQU_I19_RESOURCES (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_RESOURCES GetRESOURCES() {
	   CQU_I19_RESOURCES ret = null;
	   try {
	      ret = (CQU_I19_RESOURCES)this.GetStructure("RESOURCES");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_RESOURCES
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_RESOURCES GetRESOURCES(int rep) { 
	   return (CQU_I19_RESOURCES)this.GetStructure("RESOURCES", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_RESOURCES 
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
	 * Enumerate over the CQU_I19_RESOURCES results 
	 */ 
	public IEnumerable<CQU_I19_RESOURCES> RESOURCESs 
	{ 
		get
		{
			for (int rep = 0; rep < RESOURCESRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_RESOURCES)this.GetStructure("RESOURCES", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_RESOURCES
	///</summary>
	public CQU_I19_RESOURCES AddRESOURCES()
	{
		return this.AddStructure("RESOURCES") as CQU_I19_RESOURCES;
	}

	///<summary>
	///Removes the given CQU_I19_RESOURCES
	///</summary>
	public void RemoveRESOURCES(CQU_I19_RESOURCES toRemove)
	{
		this.RemoveStructure("RESOURCES", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_RESOURCES at the given index
	///</summary>
	public void RemoveRESOURCESAt(int index)
	{
		this.RemoveRepetition("RESOURCES", index);
	}

}
}
