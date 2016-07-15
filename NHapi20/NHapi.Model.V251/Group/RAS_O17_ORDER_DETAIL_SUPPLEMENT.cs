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
///Represents the RAS_O17_ORDER_DETAIL_SUPPLEMENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: NTE (Notes and Comments) repeating</li>
///<li>1: RXR (Pharmacy/Treatment Route) repeating</li>
///<li>2: RAS_O17_COMPONENTS (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RAS_O17_ORDER_DETAIL_SUPPLEMENT : AbstractGroup {

	///<summary> 
	/// Creates a new RAS_O17_ORDER_DETAIL_SUPPLEMENT Group.
	///</summary>
	public RAS_O17_ORDER_DETAIL_SUPPLEMENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(NTE), true, true);
	      this.add(typeof(RXR), true, true);
	      this.add(typeof(RAS_O17_COMPONENTS), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RAS_O17_ORDER_DETAIL_SUPPLEMENT - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of RXR (Pharmacy/Treatment Route) - creates it if necessary
	///</summary>
	public RXR GetRXR() {
	   RXR ret = null;
	   try {
	      ret = (RXR)this.GetStructure("RXR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RXR
	/// * (Pharmacy/Treatment Route) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RXR GetRXR(int rep) { 
	   return (RXR)this.GetStructure("RXR", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RXR 
	 */ 
	public int RXRRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RXR").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RXR results 
	 */ 
	public IEnumerable<RXR> RXRs 
	{ 
		get
		{
			for (int rep = 0; rep < RXRRepetitionsUsed; rep++)
			{
				yield return (RXR)this.GetStructure("RXR", rep);
			}
		}
	}

	///<summary>
	///Adds a new RXR
	///</summary>
	public RXR AddRXR()
	{
		return this.AddStructure("RXR") as RXR;
	}

	///<summary>
	///Removes the given RXR
	///</summary>
	public void RemoveRXR(RXR toRemove)
	{
		this.RemoveStructure("RXR", toRemove);
	}

	///<summary>
	///Removes the RXR at the given index
	///</summary>
	public void RemoveRXRAt(int index)
	{
		this.RemoveRepetition("RXR", index);
	}

	///<summary>
	/// Returns  first repetition of RAS_O17_COMPONENTS (a Group object) - creates it if necessary
	///</summary>
	public RAS_O17_COMPONENTS GetCOMPONENTS() {
	   RAS_O17_COMPONENTS ret = null;
	   try {
	      ret = (RAS_O17_COMPONENTS)this.GetStructure("COMPONENTS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RAS_O17_COMPONENTS
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RAS_O17_COMPONENTS GetCOMPONENTS(int rep) { 
	   return (RAS_O17_COMPONENTS)this.GetStructure("COMPONENTS", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RAS_O17_COMPONENTS 
	 */ 
	public int COMPONENTSRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("COMPONENTS").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RAS_O17_COMPONENTS results 
	 */ 
	public IEnumerable<RAS_O17_COMPONENTS> COMPONENTSs 
	{ 
		get
		{
			for (int rep = 0; rep < COMPONENTSRepetitionsUsed; rep++)
			{
				yield return (RAS_O17_COMPONENTS)this.GetStructure("COMPONENTS", rep);
			}
		}
	}

	///<summary>
	///Adds a new RAS_O17_COMPONENTS
	///</summary>
	public RAS_O17_COMPONENTS AddCOMPONENTS()
	{
		return this.AddStructure("COMPONENTS") as RAS_O17_COMPONENTS;
	}

	///<summary>
	///Removes the given RAS_O17_COMPONENTS
	///</summary>
	public void RemoveCOMPONENTS(RAS_O17_COMPONENTS toRemove)
	{
		this.RemoveStructure("COMPONENTS", toRemove);
	}

	///<summary>
	///Removes the RAS_O17_COMPONENTS at the given index
	///</summary>
	public void RemoveCOMPONENTSAt(int index)
	{
		this.RemoveRepetition("COMPONENTS", index);
	}

}
}
