using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V21.Segment;
using NHapi.Model.V21.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V21.Group
{
///<summary>
///Represents the ORU_R01_PATIENT_RESULT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORU_R01_PATIENT (a Group object) optional </li>
///<li>1: ORU_R01_ORDER_OBSERVATION (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORU_R01_PATIENT_RESULT : AbstractGroup {

	///<summary> 
	/// Creates a new ORU_R01_PATIENT_RESULT Group.
	///</summary>
	public ORU_R01_PATIENT_RESULT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORU_R01_PATIENT), false, false);
	      this.add(typeof(ORU_R01_ORDER_OBSERVATION), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORU_R01_PATIENT_RESULT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORU_R01_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORU_R01_PATIENT PATIENT { 
get{
	   ORU_R01_PATIENT ret = null;
	   try {
	      ret = (ORU_R01_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORU_R01_ORDER_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public ORU_R01_ORDER_OBSERVATION GetORDER_OBSERVATION() {
	   ORU_R01_ORDER_OBSERVATION ret = null;
	   try {
	      ret = (ORU_R01_ORDER_OBSERVATION)this.GetStructure("ORDER_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORU_R01_ORDER_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORU_R01_ORDER_OBSERVATION GetORDER_OBSERVATION(int rep) { 
	   return (ORU_R01_ORDER_OBSERVATION)this.GetStructure("ORDER_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORU_R01_ORDER_OBSERVATION 
	 */ 
	public int ORDER_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORU_R01_ORDER_OBSERVATION results 
	 */ 
	public IEnumerable<ORU_R01_ORDER_OBSERVATION> ORDER_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDER_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (ORU_R01_ORDER_OBSERVATION)this.GetStructure("ORDER_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORU_R01_ORDER_OBSERVATION
	///</summary>
	public ORU_R01_ORDER_OBSERVATION AddORDER_OBSERVATION()
	{
		return this.AddStructure("ORDER_OBSERVATION") as ORU_R01_ORDER_OBSERVATION;
	}

	///<summary>
	///Removes the given ORU_R01_ORDER_OBSERVATION
	///</summary>
	public void RemoveORDER_OBSERVATION(ORU_R01_ORDER_OBSERVATION toRemove)
	{
		this.RemoveStructure("ORDER_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the ORU_R01_ORDER_OBSERVATION at the given index
	///</summary>
	public void RemoveORDER_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("ORDER_OBSERVATION", index);
	}

}
}
