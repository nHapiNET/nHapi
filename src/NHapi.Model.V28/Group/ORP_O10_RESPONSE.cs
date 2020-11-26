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
///Represents the ORP_O10_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORP_O10_PATIENT (a Group object) optional </li>
///<li>1: ORP_O10_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORP_O10_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new ORP_O10_RESPONSE Group.
	///</summary>
	public ORP_O10_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORP_O10_PATIENT), false, false);
	      this.add(typeof(ORP_O10_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORP_O10_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORP_O10_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORP_O10_PATIENT PATIENT { 
get{
	   ORP_O10_PATIENT ret = null;
	   try {
	      ret = (ORP_O10_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORP_O10_ORDER (a Group object) - creates it if necessary
	///</summary>
	public ORP_O10_ORDER GetORDER() {
	   ORP_O10_ORDER ret = null;
	   try {
	      ret = (ORP_O10_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORP_O10_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORP_O10_ORDER GetORDER(int rep) { 
	   return (ORP_O10_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORP_O10_ORDER 
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
	 * Enumerate over the ORP_O10_ORDER results 
	 */ 
	public IEnumerable<ORP_O10_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (ORP_O10_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORP_O10_ORDER
	///</summary>
	public ORP_O10_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as ORP_O10_ORDER;
	}

	///<summary>
	///Removes the given ORP_O10_ORDER
	///</summary>
	public void RemoveORDER(ORP_O10_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the ORP_O10_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
