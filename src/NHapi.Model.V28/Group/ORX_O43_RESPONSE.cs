using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the ORX_O43_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORX_O43_PATIENT (a Group object) optional </li>
///<li>1: ORX_O43_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORX_O43_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new ORX_O43_RESPONSE Group.
	///</summary>
	public ORX_O43_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORX_O43_PATIENT), false, false);
	      this.add(typeof(ORX_O43_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORX_O43_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORX_O43_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORX_O43_PATIENT PATIENT { 
get{
	   ORX_O43_PATIENT ret = null;
	   try {
	      ret = (ORX_O43_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORX_O43_ORDER (a Group object) - creates it if necessary
	///</summary>
	public ORX_O43_ORDER GetORDER() {
	   ORX_O43_ORDER ret = null;
	   try {
	      ret = (ORX_O43_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORX_O43_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORX_O43_ORDER GetORDER(int rep) { 
	   return (ORX_O43_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORX_O43_ORDER 
	 */ 
	public int ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORX_O43_ORDER results 
	 */ 
	public IEnumerable<ORX_O43_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (ORX_O43_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORX_O43_ORDER
	///</summary>
	public ORX_O43_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as ORX_O43_ORDER;
	}

	///<summary>
	///Removes the given ORX_O43_ORDER
	///</summary>
	public void RemoveORDER(ORX_O43_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the ORX_O43_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
