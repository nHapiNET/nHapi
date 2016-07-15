using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
///<summary>
///Represents the ORD_O02_ORDER_DIET Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (ORC - common order segment) </li>
///<li>1: ODS (ODS - dietary orders, supplements, and preferences segment) optional repeating</li>
///<li>2: NTE (NTE - notes and comments segment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORD_O02_ORDER_DIET : AbstractGroup {

	///<summary> 
	/// Creates a new ORD_O02_ORDER_DIET Group.
	///</summary>
	public ORD_O02_ORDER_DIET(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(ODS), false, true);
	      this.add(typeof(NTE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORD_O02_ORDER_DIET - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORC (ORC - common order segment) - creates it if necessary
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
	/// Returns  first repetition of ODS (ODS - dietary orders, supplements, and preferences segment) - creates it if necessary
	///</summary>
	public ODS GetODS() {
	   ODS ret = null;
	   try {
	      ret = (ODS)this.GetStructure("ODS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ODS
	/// * (ODS - dietary orders, supplements, and preferences segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ODS GetODS(int rep) { 
	   return (ODS)this.GetStructure("ODS", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ODS 
	 */ 
	public int ODSRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ODS").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ODS results 
	 */ 
	public IEnumerable<ODS> ODSs 
	{ 
		get
		{
			for (int rep = 0; rep < ODSRepetitionsUsed; rep++)
			{
				yield return (ODS)this.GetStructure("ODS", rep);
			}
		}
	}

	///<summary>
	///Adds a new ODS
	///</summary>
	public ODS AddODS()
	{
		return this.AddStructure("ODS") as ODS;
	}

	///<summary>
	///Removes the given ODS
	///</summary>
	public void RemoveODS(ODS toRemove)
	{
		this.RemoveStructure("ODS", toRemove);
	}

	///<summary>
	///Removes the ODS at the given index
	///</summary>
	public void RemoveODSAt(int index)
	{
		this.RemoveRepetition("ODS", index);
	}

	///<summary>
	/// Returns  first repetition of NTE (NTE - notes and comments segment) - creates it if necessary
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
	/// * (NTE - notes and comments segment) - creates it if necessary
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

}
}
