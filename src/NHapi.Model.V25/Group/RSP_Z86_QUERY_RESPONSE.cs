using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Group
{
///<summary>
///Represents the RSP_Z86_QUERY_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RSP_Z86_PATIENT (a Group object) optional </li>
///<li>1: RSP_Z86_COMMON_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class RSP_Z86_QUERY_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new RSP_Z86_QUERY_RESPONSE Group.
	///</summary>
	public RSP_Z86_QUERY_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RSP_Z86_PATIENT), false, false);
	      this.add(typeof(RSP_Z86_COMMON_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RSP_Z86_QUERY_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RSP_Z86_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z86_PATIENT PATIENT { 
get{
	   RSP_Z86_PATIENT ret = null;
	   try {
	      ret = (RSP_Z86_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RSP_Z86_COMMON_ORDER (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z86_COMMON_ORDER GetCOMMON_ORDER() {
	   RSP_Z86_COMMON_ORDER ret = null;
	   try {
	      ret = (RSP_Z86_COMMON_ORDER)this.GetStructure("COMMON_ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RSP_Z86_COMMON_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RSP_Z86_COMMON_ORDER GetCOMMON_ORDER(int rep) { 
	   return (RSP_Z86_COMMON_ORDER)this.GetStructure("COMMON_ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RSP_Z86_COMMON_ORDER 
	 */ 
	public int COMMON_ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("COMMON_ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RSP_Z86_COMMON_ORDER results 
	 */ 
	public IEnumerable<RSP_Z86_COMMON_ORDER> COMMON_ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < COMMON_ORDERRepetitionsUsed; rep++)
			{
				yield return (RSP_Z86_COMMON_ORDER)this.GetStructure("COMMON_ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new RSP_Z86_COMMON_ORDER
	///</summary>
	public RSP_Z86_COMMON_ORDER AddCOMMON_ORDER()
	{
		return this.AddStructure("COMMON_ORDER") as RSP_Z86_COMMON_ORDER;
	}

	///<summary>
	///Removes the given RSP_Z86_COMMON_ORDER
	///</summary>
	public void RemoveCOMMON_ORDER(RSP_Z86_COMMON_ORDER toRemove)
	{
		this.RemoveStructure("COMMON_ORDER", toRemove);
	}

	///<summary>
	///Removes the RSP_Z86_COMMON_ORDER at the given index
	///</summary>
	public void RemoveCOMMON_ORDERAt(int index)
	{
		this.RemoveRepetition("COMMON_ORDER", index);
	}

}
}
