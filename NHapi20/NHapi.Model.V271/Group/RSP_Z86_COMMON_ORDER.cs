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
///Represents the RSP_Z86_COMMON_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: RSP_Z86_TIMING (a Group object) optional repeating</li>
///<li>2: RSP_Z86_ORDER_DETAIL (a Group object) optional </li>
///<li>3: RSP_Z86_ENCODED_ORDER (a Group object) optional </li>
///<li>4: RSP_Z86_DISPENSE (a Group object) optional </li>
///<li>5: RSP_Z86_GIVE (a Group object) optional </li>
///<li>6: RSP_Z86_ADMINISTRATION (a Group object) optional </li>
///<li>7: RSP_Z86_OBSERVATION (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class RSP_Z86_COMMON_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RSP_Z86_COMMON_ORDER Group.
	///</summary>
	public RSP_Z86_COMMON_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(RSP_Z86_TIMING), false, true);
	      this.add(typeof(RSP_Z86_ORDER_DETAIL), false, false);
	      this.add(typeof(RSP_Z86_ENCODED_ORDER), false, false);
	      this.add(typeof(RSP_Z86_DISPENSE), false, false);
	      this.add(typeof(RSP_Z86_GIVE), false, false);
	      this.add(typeof(RSP_Z86_ADMINISTRATION), false, false);
	      this.add(typeof(RSP_Z86_OBSERVATION), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RSP_Z86_COMMON_ORDER - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORC (Common Order) - creates it if necessary
	///</summary>
	public ORC ORC { 
get{
	   ORC ret = null;
	   try {
	      ret = (ORC)this.GetStructure("ORC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RSP_Z86_TIMING (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z86_TIMING GetTIMING() {
	   RSP_Z86_TIMING ret = null;
	   try {
	      ret = (RSP_Z86_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RSP_Z86_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RSP_Z86_TIMING GetTIMING(int rep) { 
	   return (RSP_Z86_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RSP_Z86_TIMING 
	 */ 
	public int TIMINGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RSP_Z86_TIMING results 
	 */ 
	public IEnumerable<RSP_Z86_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (RSP_Z86_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new RSP_Z86_TIMING
	///</summary>
	public RSP_Z86_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as RSP_Z86_TIMING;
	}

	///<summary>
	///Removes the given RSP_Z86_TIMING
	///</summary>
	public void RemoveTIMING(RSP_Z86_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the RSP_Z86_TIMING at the given index
	///</summary>
	public void RemoveTIMINGAt(int index)
	{
		this.RemoveRepetition("TIMING", index);
	}

	///<summary>
	/// Returns RSP_Z86_ORDER_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z86_ORDER_DETAIL ORDER_DETAIL { 
get{
	   RSP_Z86_ORDER_DETAIL ret = null;
	   try {
	      ret = (RSP_Z86_ORDER_DETAIL)this.GetStructure("ORDER_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RSP_Z86_ENCODED_ORDER (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z86_ENCODED_ORDER ENCODED_ORDER { 
get{
	   RSP_Z86_ENCODED_ORDER ret = null;
	   try {
	      ret = (RSP_Z86_ENCODED_ORDER)this.GetStructure("ENCODED_ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RSP_Z86_DISPENSE (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z86_DISPENSE DISPENSE { 
get{
	   RSP_Z86_DISPENSE ret = null;
	   try {
	      ret = (RSP_Z86_DISPENSE)this.GetStructure("DISPENSE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RSP_Z86_GIVE (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z86_GIVE GIVE { 
get{
	   RSP_Z86_GIVE ret = null;
	   try {
	      ret = (RSP_Z86_GIVE)this.GetStructure("GIVE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RSP_Z86_ADMINISTRATION (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z86_ADMINISTRATION ADMINISTRATION { 
get{
	   RSP_Z86_ADMINISTRATION ret = null;
	   try {
	      ret = (RSP_Z86_ADMINISTRATION)this.GetStructure("ADMINISTRATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RSP_Z86_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public RSP_Z86_OBSERVATION GetOBSERVATION() {
	   RSP_Z86_OBSERVATION ret = null;
	   try {
	      ret = (RSP_Z86_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RSP_Z86_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RSP_Z86_OBSERVATION GetOBSERVATION(int rep) { 
	   return (RSP_Z86_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RSP_Z86_OBSERVATION 
	 */ 
	public int OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RSP_Z86_OBSERVATION results 
	 */ 
	public IEnumerable<RSP_Z86_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (RSP_Z86_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new RSP_Z86_OBSERVATION
	///</summary>
	public RSP_Z86_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as RSP_Z86_OBSERVATION;
	}

	///<summary>
	///Removes the given RSP_Z86_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(RSP_Z86_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the RSP_Z86_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

}
}
