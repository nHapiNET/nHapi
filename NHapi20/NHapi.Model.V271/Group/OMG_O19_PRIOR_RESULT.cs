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
///Represents the OMG_O19_PRIOR_RESULT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OMG_O19_PATIENT_PRIOR (a Group object) optional </li>
///<li>1: OMG_O19_PATIENT_VISIT_PRIOR (a Group object) optional </li>
///<li>2: AL1 (Patient Allergy Information) optional repeating</li>
///<li>3: OMG_O19_ORDER_PRIOR (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OMG_O19_PRIOR_RESULT : AbstractGroup {

	///<summary> 
	/// Creates a new OMG_O19_PRIOR_RESULT Group.
	///</summary>
	public OMG_O19_PRIOR_RESULT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OMG_O19_PATIENT_PRIOR), false, false);
	      this.add(typeof(OMG_O19_PATIENT_VISIT_PRIOR), false, false);
	      this.add(typeof(AL1), false, true);
	      this.add(typeof(OMG_O19_ORDER_PRIOR), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OMG_O19_PRIOR_RESULT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns OMG_O19_PATIENT_PRIOR (a Group object) - creates it if necessary
	///</summary>
	public OMG_O19_PATIENT_PRIOR PATIENT_PRIOR { 
get{
	   OMG_O19_PATIENT_PRIOR ret = null;
	   try {
	      ret = (OMG_O19_PATIENT_PRIOR)this.GetStructure("PATIENT_PRIOR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns OMG_O19_PATIENT_VISIT_PRIOR (a Group object) - creates it if necessary
	///</summary>
	public OMG_O19_PATIENT_VISIT_PRIOR PATIENT_VISIT_PRIOR { 
get{
	   OMG_O19_PATIENT_VISIT_PRIOR ret = null;
	   try {
	      ret = (OMG_O19_PATIENT_VISIT_PRIOR)this.GetStructure("PATIENT_VISIT_PRIOR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of AL1 (Patient Allergy Information) - creates it if necessary
	///</summary>
	public AL1 GetAL1() {
	   AL1 ret = null;
	   try {
	      ret = (AL1)this.GetStructure("AL1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of AL1
	/// * (Patient Allergy Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public AL1 GetAL1(int rep) { 
	   return (AL1)this.GetStructure("AL1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of AL1 
	 */ 
	public int AL1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("AL1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the AL1 results 
	 */ 
	public IEnumerable<AL1> AL1s 
	{ 
		get
		{
			for (int rep = 0; rep < AL1RepetitionsUsed; rep++)
			{
				yield return (AL1)this.GetStructure("AL1", rep);
			}
		}
	}

	///<summary>
	///Adds a new AL1
	///</summary>
	public AL1 AddAL1()
	{
		return this.AddStructure("AL1") as AL1;
	}

	///<summary>
	///Removes the given AL1
	///</summary>
	public void RemoveAL1(AL1 toRemove)
	{
		this.RemoveStructure("AL1", toRemove);
	}

	///<summary>
	///Removes the AL1 at the given index
	///</summary>
	public void RemoveAL1At(int index)
	{
		this.RemoveRepetition("AL1", index);
	}

	///<summary>
	/// Returns  first repetition of OMG_O19_ORDER_PRIOR (a Group object) - creates it if necessary
	///</summary>
	public OMG_O19_ORDER_PRIOR GetORDER_PRIOR() {
	   OMG_O19_ORDER_PRIOR ret = null;
	   try {
	      ret = (OMG_O19_ORDER_PRIOR)this.GetStructure("ORDER_PRIOR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OMG_O19_ORDER_PRIOR
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OMG_O19_ORDER_PRIOR GetORDER_PRIOR(int rep) { 
	   return (OMG_O19_ORDER_PRIOR)this.GetStructure("ORDER_PRIOR", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OMG_O19_ORDER_PRIOR 
	 */ 
	public int ORDER_PRIORRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER_PRIOR").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OMG_O19_ORDER_PRIOR results 
	 */ 
	public IEnumerable<OMG_O19_ORDER_PRIOR> ORDER_PRIORs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDER_PRIORRepetitionsUsed; rep++)
			{
				yield return (OMG_O19_ORDER_PRIOR)this.GetStructure("ORDER_PRIOR", rep);
			}
		}
	}

	///<summary>
	///Adds a new OMG_O19_ORDER_PRIOR
	///</summary>
	public OMG_O19_ORDER_PRIOR AddORDER_PRIOR()
	{
		return this.AddStructure("ORDER_PRIOR") as OMG_O19_ORDER_PRIOR;
	}

	///<summary>
	///Removes the given OMG_O19_ORDER_PRIOR
	///</summary>
	public void RemoveORDER_PRIOR(OMG_O19_ORDER_PRIOR toRemove)
	{
		this.RemoveStructure("ORDER_PRIOR", toRemove);
	}

	///<summary>
	///Removes the OMG_O19_ORDER_PRIOR at the given index
	///</summary>
	public void RemoveORDER_PRIORAt(int index)
	{
		this.RemoveRepetition("ORDER_PRIOR", index);
	}

}
}
