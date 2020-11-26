using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V24.Segment;
using NHapi.Model.V24.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V24.Group
{
///<summary>
///Represents the RSP_Z88_QUERY_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PID (Patient identification) </li>
///<li>1: PD1 (patient additional demographic) optional </li>
///<li>2: NTE (Notes and Comments) optional repeating</li>
///<li>3: RSP_Z88_ALLERGY (a Group object) optional </li>
///<li>4: RSP_Z88_COMMON_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class RSP_Z88_QUERY_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new RSP_Z88_QUERY_RESPONSE Group.
	///</summary>
	public RSP_Z88_QUERY_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PD1), false, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(RSP_Z88_ALLERGY), false, false);
	      this.add(typeof(RSP_Z88_COMMON_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RSP_Z88_QUERY_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PID (Patient identification) - creates it if necessary
	///</summary>
	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PD1 (patient additional demographic) - creates it if necessary
	///</summary>
	public PD1 PD1 { 
get{
	   PD1 ret = null;
	   try {
	      ret = (PD1)this.GetStructure("PD1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NTE (Notes and Comments) - creates it if necessary
	///</summary>
	public NTE GetNTE() {
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NTE
	/// * (Notes and Comments) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NTE GetNTE(int rep) { 
	   return (NTE)this.GetStructure("NTE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NTE 
	 */ 
	public int NTERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NTE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NTE results 
	 */ 
	public IEnumerable<NTE> NTEs 
	{ 
		get
		{
			for (int rep = 0; rep < NTERepetitionsUsed; rep++)
			{
				yield return (NTE)this.GetStructure("NTE", rep);
			}
		}
	}

	///<summary>
	///Adds a new NTE
	///</summary>
	public NTE AddNTE()
	{
		return this.AddStructure("NTE") as NTE;
	}

	///<summary>
	///Removes the given NTE
	///</summary>
	public void RemoveNTE(NTE toRemove)
	{
		this.RemoveStructure("NTE", toRemove);
	}

	///<summary>
	///Removes the NTE at the given index
	///</summary>
	public void RemoveNTEAt(int index)
	{
		this.RemoveRepetition("NTE", index);
	}

	///<summary>
	/// Returns RSP_Z88_ALLERGY (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z88_ALLERGY ALLERGY { 
get{
	   RSP_Z88_ALLERGY ret = null;
	   try {
	      ret = (RSP_Z88_ALLERGY)this.GetStructure("ALLERGY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RSP_Z88_COMMON_ORDER (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z88_COMMON_ORDER GetCOMMON_ORDER() {
	   RSP_Z88_COMMON_ORDER ret = null;
	   try {
	      ret = (RSP_Z88_COMMON_ORDER)this.GetStructure("COMMON_ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RSP_Z88_COMMON_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RSP_Z88_COMMON_ORDER GetCOMMON_ORDER(int rep) { 
	   return (RSP_Z88_COMMON_ORDER)this.GetStructure("COMMON_ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RSP_Z88_COMMON_ORDER 
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
	 * Enumerate over the RSP_Z88_COMMON_ORDER results 
	 */ 
	public IEnumerable<RSP_Z88_COMMON_ORDER> COMMON_ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < COMMON_ORDERRepetitionsUsed; rep++)
			{
				yield return (RSP_Z88_COMMON_ORDER)this.GetStructure("COMMON_ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new RSP_Z88_COMMON_ORDER
	///</summary>
	public RSP_Z88_COMMON_ORDER AddCOMMON_ORDER()
	{
		return this.AddStructure("COMMON_ORDER") as RSP_Z88_COMMON_ORDER;
	}

	///<summary>
	///Removes the given RSP_Z88_COMMON_ORDER
	///</summary>
	public void RemoveCOMMON_ORDER(RSP_Z88_COMMON_ORDER toRemove)
	{
		this.RemoveStructure("COMMON_ORDER", toRemove);
	}

	///<summary>
	///Removes the RSP_Z88_COMMON_ORDER at the given index
	///</summary>
	public void RemoveCOMMON_ORDERAt(int index)
	{
		this.RemoveRepetition("COMMON_ORDER", index);
	}

}
}
