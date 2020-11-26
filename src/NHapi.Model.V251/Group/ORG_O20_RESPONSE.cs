using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V251.Segment;
using NHapi.Model.V251.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the ORG_O20_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORG_O20_PATIENT (a Group object) optional </li>
///<li>1: ORG_O20_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORG_O20_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new ORG_O20_RESPONSE Group.
	///</summary>
	public ORG_O20_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORG_O20_PATIENT), false, false);
	      this.add(typeof(ORG_O20_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORG_O20_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORG_O20_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORG_O20_PATIENT PATIENT { 
get{
	   ORG_O20_PATIENT ret = null;
	   try {
	      ret = (ORG_O20_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORG_O20_ORDER (a Group object) - creates it if necessary
	///</summary>
	public ORG_O20_ORDER GetORDER() {
	   ORG_O20_ORDER ret = null;
	   try {
	      ret = (ORG_O20_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORG_O20_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORG_O20_ORDER GetORDER(int rep) { 
	   return (ORG_O20_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORG_O20_ORDER 
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
	 * Enumerate over the ORG_O20_ORDER results 
	 */ 
	public IEnumerable<ORG_O20_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (ORG_O20_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORG_O20_ORDER
	///</summary>
	public ORG_O20_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as ORG_O20_ORDER;
	}

	///<summary>
	///Removes the given ORG_O20_ORDER
	///</summary>
	public void RemoveORDER(ORG_O20_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the ORG_O20_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
