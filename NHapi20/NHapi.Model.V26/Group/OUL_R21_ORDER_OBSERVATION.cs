using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V26.Segment;
using NHapi.Model.V26.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V26.Group
{
///<summary>
///Represents the OUL_R21_ORDER_OBSERVATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OUL_R21_CONTAINER (a Group object) optional </li>
///<li>1: ORC (Common Order) optional </li>
///<li>2: OBR (Observation Request) </li>
///<li>3: NTE (Notes and Comments) optional repeating</li>
///<li>4: OUL_R21_TIMING_QTY (a Group object) optional repeating</li>
///<li>5: OUL_R21_OBSERVATION (a Group object) repeating</li>
///<li>6: CTI (Clinical Trial Identification) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class OUL_R21_ORDER_OBSERVATION : AbstractGroup {

	///<summary> 
	/// Creates a new OUL_R21_ORDER_OBSERVATION Group.
	///</summary>
	public OUL_R21_ORDER_OBSERVATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OUL_R21_CONTAINER), false, false);
	      this.add(typeof(ORC), false, false);
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(OUL_R21_TIMING_QTY), false, true);
	      this.add(typeof(OUL_R21_OBSERVATION), true, true);
	      this.add(typeof(CTI), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OUL_R21_ORDER_OBSERVATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns OUL_R21_CONTAINER (a Group object) - creates it if necessary
	///</summary>
	public OUL_R21_CONTAINER CONTAINER { 
get{
	   OUL_R21_CONTAINER ret = null;
	   try {
	      ret = (OUL_R21_CONTAINER)this.GetStructure("CONTAINER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
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
	/// Returns OBR (Observation Request) - creates it if necessary
	///</summary>
	public OBR OBR { 
get{
	   OBR ret = null;
	   try {
	      ret = (OBR)this.GetStructure("OBR");
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
	/// Returns  first repetition of OUL_R21_TIMING_QTY (a Group object) - creates it if necessary
	///</summary>
	public OUL_R21_TIMING_QTY GetTIMING_QTY() {
	   OUL_R21_TIMING_QTY ret = null;
	   try {
	      ret = (OUL_R21_TIMING_QTY)this.GetStructure("TIMING_QTY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OUL_R21_TIMING_QTY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OUL_R21_TIMING_QTY GetTIMING_QTY(int rep) { 
	   return (OUL_R21_TIMING_QTY)this.GetStructure("TIMING_QTY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OUL_R21_TIMING_QTY 
	 */ 
	public int TIMING_QTYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING_QTY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OUL_R21_TIMING_QTY results 
	 */ 
	public IEnumerable<OUL_R21_TIMING_QTY> TIMING_QTYs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMING_QTYRepetitionsUsed; rep++)
			{
				yield return (OUL_R21_TIMING_QTY)this.GetStructure("TIMING_QTY", rep);
			}
		}
	}

	///<summary>
	///Adds a new OUL_R21_TIMING_QTY
	///</summary>
	public OUL_R21_TIMING_QTY AddTIMING_QTY()
	{
		return this.AddStructure("TIMING_QTY") as OUL_R21_TIMING_QTY;
	}

	///<summary>
	///Removes the given OUL_R21_TIMING_QTY
	///</summary>
	public void RemoveTIMING_QTY(OUL_R21_TIMING_QTY toRemove)
	{
		this.RemoveStructure("TIMING_QTY", toRemove);
	}

	///<summary>
	///Removes the OUL_R21_TIMING_QTY at the given index
	///</summary>
	public void RemoveTIMING_QTYAt(int index)
	{
		this.RemoveRepetition("TIMING_QTY", index);
	}

	///<summary>
	/// Returns  first repetition of OUL_R21_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OUL_R21_OBSERVATION GetOBSERVATION() {
	   OUL_R21_OBSERVATION ret = null;
	   try {
	      ret = (OUL_R21_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OUL_R21_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OUL_R21_OBSERVATION GetOBSERVATION(int rep) { 
	   return (OUL_R21_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OUL_R21_OBSERVATION 
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
	 * Enumerate over the OUL_R21_OBSERVATION results 
	 */ 
	public IEnumerable<OUL_R21_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OUL_R21_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OUL_R21_OBSERVATION
	///</summary>
	public OUL_R21_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as OUL_R21_OBSERVATION;
	}

	///<summary>
	///Removes the given OUL_R21_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(OUL_R21_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OUL_R21_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of CTI (Clinical Trial Identification) - creates it if necessary
	///</summary>
	public CTI GetCTI() {
	   CTI ret = null;
	   try {
	      ret = (CTI)this.GetStructure("CTI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CTI
	/// * (Clinical Trial Identification) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CTI GetCTI(int rep) { 
	   return (CTI)this.GetStructure("CTI", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CTI 
	 */ 
	public int CTIRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CTI").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CTI results 
	 */ 
	public IEnumerable<CTI> CTIs 
	{ 
		get
		{
			for (int rep = 0; rep < CTIRepetitionsUsed; rep++)
			{
				yield return (CTI)this.GetStructure("CTI", rep);
			}
		}
	}

	///<summary>
	///Adds a new CTI
	///</summary>
	public CTI AddCTI()
	{
		return this.AddStructure("CTI") as CTI;
	}

	///<summary>
	///Removes the given CTI
	///</summary>
	public void RemoveCTI(CTI toRemove)
	{
		this.RemoveStructure("CTI", toRemove);
	}

	///<summary>
	///Removes the CTI at the given index
	///</summary>
	public void RemoveCTIAt(int index)
	{
		this.RemoveRepetition("CTI", index);
	}

}
}
