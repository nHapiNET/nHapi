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
///Represents the OSM_R26_SHIPMENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SHP (Shipment) </li>
///<li>1: PRT (Participation Information) repeating</li>
///<li>2: OSM_R26_SHIPPING_OBSERVATION (a Group object) optional repeating</li>
///<li>3: OSM_R26_PACKAGE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OSM_R26_SHIPMENT : AbstractGroup {

	///<summary> 
	/// Creates a new OSM_R26_SHIPMENT Group.
	///</summary>
	public OSM_R26_SHIPMENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SHP), true, false);
	      this.add(typeof(PRT), true, true);
	      this.add(typeof(OSM_R26_SHIPPING_OBSERVATION), false, true);
	      this.add(typeof(OSM_R26_PACKAGE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OSM_R26_SHIPMENT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns SHP (Shipment) - creates it if necessary
	///</summary>
	public SHP SHP { 
get{
	   SHP ret = null;
	   try {
	      ret = (SHP)this.GetStructure("SHP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PRT (Participation Information) - creates it if necessary
	///</summary>
	public PRT GetPRT() {
	   PRT ret = null;
	   try {
	      ret = (PRT)this.GetStructure("PRT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRT
	/// * (Participation Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRT GetPRT(int rep) { 
	   return (PRT)this.GetStructure("PRT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRT 
	 */ 
	public int PRTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PRT results 
	 */ 
	public IEnumerable<PRT> PRTs 
	{ 
		get
		{
			for (int rep = 0; rep < PRTRepetitionsUsed; rep++)
			{
				yield return (PRT)this.GetStructure("PRT", rep);
			}
		}
	}

	///<summary>
	///Adds a new PRT
	///</summary>
	public PRT AddPRT()
	{
		return this.AddStructure("PRT") as PRT;
	}

	///<summary>
	///Removes the given PRT
	///</summary>
	public void RemovePRT(PRT toRemove)
	{
		this.RemoveStructure("PRT", toRemove);
	}

	///<summary>
	///Removes the PRT at the given index
	///</summary>
	public void RemovePRTAt(int index)
	{
		this.RemoveRepetition("PRT", index);
	}

	///<summary>
	/// Returns  first repetition of OSM_R26_SHIPPING_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OSM_R26_SHIPPING_OBSERVATION GetSHIPPING_OBSERVATION() {
	   OSM_R26_SHIPPING_OBSERVATION ret = null;
	   try {
	      ret = (OSM_R26_SHIPPING_OBSERVATION)this.GetStructure("SHIPPING_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OSM_R26_SHIPPING_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OSM_R26_SHIPPING_OBSERVATION GetSHIPPING_OBSERVATION(int rep) { 
	   return (OSM_R26_SHIPPING_OBSERVATION)this.GetStructure("SHIPPING_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OSM_R26_SHIPPING_OBSERVATION 
	 */ 
	public int SHIPPING_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SHIPPING_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OSM_R26_SHIPPING_OBSERVATION results 
	 */ 
	public IEnumerable<OSM_R26_SHIPPING_OBSERVATION> SHIPPING_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < SHIPPING_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OSM_R26_SHIPPING_OBSERVATION)this.GetStructure("SHIPPING_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OSM_R26_SHIPPING_OBSERVATION
	///</summary>
	public OSM_R26_SHIPPING_OBSERVATION AddSHIPPING_OBSERVATION()
	{
		return this.AddStructure("SHIPPING_OBSERVATION") as OSM_R26_SHIPPING_OBSERVATION;
	}

	///<summary>
	///Removes the given OSM_R26_SHIPPING_OBSERVATION
	///</summary>
	public void RemoveSHIPPING_OBSERVATION(OSM_R26_SHIPPING_OBSERVATION toRemove)
	{
		this.RemoveStructure("SHIPPING_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OSM_R26_SHIPPING_OBSERVATION at the given index
	///</summary>
	public void RemoveSHIPPING_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("SHIPPING_OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of OSM_R26_PACKAGE (a Group object) - creates it if necessary
	///</summary>
	public OSM_R26_PACKAGE GetPACKAGE() {
	   OSM_R26_PACKAGE ret = null;
	   try {
	      ret = (OSM_R26_PACKAGE)this.GetStructure("PACKAGE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OSM_R26_PACKAGE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OSM_R26_PACKAGE GetPACKAGE(int rep) { 
	   return (OSM_R26_PACKAGE)this.GetStructure("PACKAGE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OSM_R26_PACKAGE 
	 */ 
	public int PACKAGERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PACKAGE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OSM_R26_PACKAGE results 
	 */ 
	public IEnumerable<OSM_R26_PACKAGE> PACKAGEs 
	{ 
		get
		{
			for (int rep = 0; rep < PACKAGERepetitionsUsed; rep++)
			{
				yield return (OSM_R26_PACKAGE)this.GetStructure("PACKAGE", rep);
			}
		}
	}

	///<summary>
	///Adds a new OSM_R26_PACKAGE
	///</summary>
	public OSM_R26_PACKAGE AddPACKAGE()
	{
		return this.AddStructure("PACKAGE") as OSM_R26_PACKAGE;
	}

	///<summary>
	///Removes the given OSM_R26_PACKAGE
	///</summary>
	public void RemovePACKAGE(OSM_R26_PACKAGE toRemove)
	{
		this.RemoveStructure("PACKAGE", toRemove);
	}

	///<summary>
	///Removes the OSM_R26_PACKAGE at the given index
	///</summary>
	public void RemovePACKAGEAt(int index)
	{
		this.RemoveRepetition("PACKAGE", index);
	}

}
}
