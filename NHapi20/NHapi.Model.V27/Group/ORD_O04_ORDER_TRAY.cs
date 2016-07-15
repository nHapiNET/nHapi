using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V27.Segment;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the ORD_O04_ORDER_TRAY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: ORD_O04_TIMING_TRAY (a Group object) optional repeating</li>
///<li>2: ODT (Diet Tray Instructions) optional repeating</li>
///<li>3: NTE (Notes and Comments) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORD_O04_ORDER_TRAY : AbstractGroup {

	///<summary> 
	/// Creates a new ORD_O04_ORDER_TRAY Group.
	///</summary>
	public ORD_O04_ORDER_TRAY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(ORD_O04_TIMING_TRAY), false, true);
	      this.add(typeof(ODT), false, true);
	      this.add(typeof(NTE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORD_O04_ORDER_TRAY - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of ORD_O04_TIMING_TRAY (a Group object) - creates it if necessary
	///</summary>
	public ORD_O04_TIMING_TRAY GetTIMING_TRAY() {
	   ORD_O04_TIMING_TRAY ret = null;
	   try {
	      ret = (ORD_O04_TIMING_TRAY)this.GetStructure("TIMING_TRAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORD_O04_TIMING_TRAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORD_O04_TIMING_TRAY GetTIMING_TRAY(int rep) { 
	   return (ORD_O04_TIMING_TRAY)this.GetStructure("TIMING_TRAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORD_O04_TIMING_TRAY 
	 */ 
	public int TIMING_TRAYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING_TRAY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORD_O04_TIMING_TRAY results 
	 */ 
	public IEnumerable<ORD_O04_TIMING_TRAY> TIMING_TRAYs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMING_TRAYRepetitionsUsed; rep++)
			{
				yield return (ORD_O04_TIMING_TRAY)this.GetStructure("TIMING_TRAY", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORD_O04_TIMING_TRAY
	///</summary>
	public ORD_O04_TIMING_TRAY AddTIMING_TRAY()
	{
		return this.AddStructure("TIMING_TRAY") as ORD_O04_TIMING_TRAY;
	}

	///<summary>
	///Removes the given ORD_O04_TIMING_TRAY
	///</summary>
	public void RemoveTIMING_TRAY(ORD_O04_TIMING_TRAY toRemove)
	{
		this.RemoveStructure("TIMING_TRAY", toRemove);
	}

	///<summary>
	///Removes the ORD_O04_TIMING_TRAY at the given index
	///</summary>
	public void RemoveTIMING_TRAYAt(int index)
	{
		this.RemoveRepetition("TIMING_TRAY", index);
	}

	///<summary>
	/// Returns  first repetition of ODT (Diet Tray Instructions) - creates it if necessary
	///</summary>
	public ODT GetODT() {
	   ODT ret = null;
	   try {
	      ret = (ODT)this.GetStructure("ODT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ODT
	/// * (Diet Tray Instructions) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ODT GetODT(int rep) { 
	   return (ODT)this.GetStructure("ODT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ODT 
	 */ 
	public int ODTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ODT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ODT results 
	 */ 
	public IEnumerable<ODT> ODTs 
	{ 
		get
		{
			for (int rep = 0; rep < ODTRepetitionsUsed; rep++)
			{
				yield return (ODT)this.GetStructure("ODT", rep);
			}
		}
	}

	///<summary>
	///Adds a new ODT
	///</summary>
	public ODT AddODT()
	{
		return this.AddStructure("ODT") as ODT;
	}

	///<summary>
	///Removes the given ODT
	///</summary>
	public void RemoveODT(ODT toRemove)
	{
		this.RemoveStructure("ODT", toRemove);
	}

	///<summary>
	///Removes the ODT at the given index
	///</summary>
	public void RemoveODTAt(int index)
	{
		this.RemoveRepetition("ODT", index);
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

}
}
