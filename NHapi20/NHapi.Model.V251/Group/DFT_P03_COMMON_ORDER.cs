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
///Represents the DFT_P03_COMMON_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) optional </li>
///<li>1: DFT_P03_TIMING_QUANTITY (a Group object) optional repeating</li>
///<li>2: DFT_P03_ORDER (a Group object) optional </li>
///<li>3: DFT_P03_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class DFT_P03_COMMON_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new DFT_P03_COMMON_ORDER Group.
	///</summary>
	public DFT_P03_COMMON_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), false, false);
	      this.add(typeof(DFT_P03_TIMING_QUANTITY), false, true);
	      this.add(typeof(DFT_P03_ORDER), false, false);
	      this.add(typeof(DFT_P03_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating DFT_P03_COMMON_ORDER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of DFT_P03_TIMING_QUANTITY (a Group object) - creates it if necessary
	///</summary>
	public DFT_P03_TIMING_QUANTITY GetTIMING_QUANTITY() {
	   DFT_P03_TIMING_QUANTITY ret = null;
	   try {
	      ret = (DFT_P03_TIMING_QUANTITY)this.GetStructure("TIMING_QUANTITY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DFT_P03_TIMING_QUANTITY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DFT_P03_TIMING_QUANTITY GetTIMING_QUANTITY(int rep) { 
	   return (DFT_P03_TIMING_QUANTITY)this.GetStructure("TIMING_QUANTITY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DFT_P03_TIMING_QUANTITY 
	 */ 
	public int TIMING_QUANTITYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING_QUANTITY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DFT_P03_TIMING_QUANTITY results 
	 */ 
	public IEnumerable<DFT_P03_TIMING_QUANTITY> TIMING_QUANTITYs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMING_QUANTITYRepetitionsUsed; rep++)
			{
				yield return (DFT_P03_TIMING_QUANTITY)this.GetStructure("TIMING_QUANTITY", rep);
			}
		}
	}

	///<summary>
	///Adds a new DFT_P03_TIMING_QUANTITY
	///</summary>
	public DFT_P03_TIMING_QUANTITY AddTIMING_QUANTITY()
	{
		return this.AddStructure("TIMING_QUANTITY") as DFT_P03_TIMING_QUANTITY;
	}

	///<summary>
	///Removes the given DFT_P03_TIMING_QUANTITY
	///</summary>
	public void RemoveTIMING_QUANTITY(DFT_P03_TIMING_QUANTITY toRemove)
	{
		this.RemoveStructure("TIMING_QUANTITY", toRemove);
	}

	///<summary>
	///Removes the DFT_P03_TIMING_QUANTITY at the given index
	///</summary>
	public void RemoveTIMING_QUANTITYAt(int index)
	{
		this.RemoveRepetition("TIMING_QUANTITY", index);
	}

	///<summary>
	/// Returns DFT_P03_ORDER (a Group object) - creates it if necessary
	///</summary>
	public DFT_P03_ORDER ORDER { 
get{
	   DFT_P03_ORDER ret = null;
	   try {
	      ret = (DFT_P03_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of DFT_P03_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public DFT_P03_OBSERVATION GetOBSERVATION() {
	   DFT_P03_OBSERVATION ret = null;
	   try {
	      ret = (DFT_P03_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DFT_P03_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DFT_P03_OBSERVATION GetOBSERVATION(int rep) { 
	   return (DFT_P03_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DFT_P03_OBSERVATION 
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
	 * Enumerate over the DFT_P03_OBSERVATION results 
	 */ 
	public IEnumerable<DFT_P03_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (DFT_P03_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new DFT_P03_OBSERVATION
	///</summary>
	public DFT_P03_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as DFT_P03_OBSERVATION;
	}

	///<summary>
	///Removes the given DFT_P03_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(DFT_P03_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the DFT_P03_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

}
}
