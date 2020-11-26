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
///Represents the OML_O39_SPECIMEN_SHIPMENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SHP (Shipment) </li>
///<li>1: OML_O39_SHIPMENT_OBSERVATION (a Group object) optional repeating</li>
///<li>2: OML_O39_PACKAGE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OML_O39_SPECIMEN_SHIPMENT : AbstractGroup {

	///<summary> 
	/// Creates a new OML_O39_SPECIMEN_SHIPMENT Group.
	///</summary>
	public OML_O39_SPECIMEN_SHIPMENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SHP), true, false);
	      this.add(typeof(OML_O39_SHIPMENT_OBSERVATION), false, true);
	      this.add(typeof(OML_O39_PACKAGE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OML_O39_SPECIMEN_SHIPMENT - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of OML_O39_SHIPMENT_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OML_O39_SHIPMENT_OBSERVATION GetSHIPMENT_OBSERVATION() {
	   OML_O39_SHIPMENT_OBSERVATION ret = null;
	   try {
	      ret = (OML_O39_SHIPMENT_OBSERVATION)this.GetStructure("SHIPMENT_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O39_SHIPMENT_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O39_SHIPMENT_OBSERVATION GetSHIPMENT_OBSERVATION(int rep) { 
	   return (OML_O39_SHIPMENT_OBSERVATION)this.GetStructure("SHIPMENT_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O39_SHIPMENT_OBSERVATION 
	 */ 
	public int SHIPMENT_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SHIPMENT_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OML_O39_SHIPMENT_OBSERVATION results 
	 */ 
	public IEnumerable<OML_O39_SHIPMENT_OBSERVATION> SHIPMENT_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < SHIPMENT_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OML_O39_SHIPMENT_OBSERVATION)this.GetStructure("SHIPMENT_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OML_O39_SHIPMENT_OBSERVATION
	///</summary>
	public OML_O39_SHIPMENT_OBSERVATION AddSHIPMENT_OBSERVATION()
	{
		return this.AddStructure("SHIPMENT_OBSERVATION") as OML_O39_SHIPMENT_OBSERVATION;
	}

	///<summary>
	///Removes the given OML_O39_SHIPMENT_OBSERVATION
	///</summary>
	public void RemoveSHIPMENT_OBSERVATION(OML_O39_SHIPMENT_OBSERVATION toRemove)
	{
		this.RemoveStructure("SHIPMENT_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OML_O39_SHIPMENT_OBSERVATION at the given index
	///</summary>
	public void RemoveSHIPMENT_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("SHIPMENT_OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of OML_O39_PACKAGE (a Group object) - creates it if necessary
	///</summary>
	public OML_O39_PACKAGE GetPACKAGE() {
	   OML_O39_PACKAGE ret = null;
	   try {
	      ret = (OML_O39_PACKAGE)this.GetStructure("PACKAGE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O39_PACKAGE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O39_PACKAGE GetPACKAGE(int rep) { 
	   return (OML_O39_PACKAGE)this.GetStructure("PACKAGE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O39_PACKAGE 
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
	 * Enumerate over the OML_O39_PACKAGE results 
	 */ 
	public IEnumerable<OML_O39_PACKAGE> PACKAGEs 
	{ 
		get
		{
			for (int rep = 0; rep < PACKAGERepetitionsUsed; rep++)
			{
				yield return (OML_O39_PACKAGE)this.GetStructure("PACKAGE", rep);
			}
		}
	}

	///<summary>
	///Adds a new OML_O39_PACKAGE
	///</summary>
	public OML_O39_PACKAGE AddPACKAGE()
	{
		return this.AddStructure("PACKAGE") as OML_O39_PACKAGE;
	}

	///<summary>
	///Removes the given OML_O39_PACKAGE
	///</summary>
	public void RemovePACKAGE(OML_O39_PACKAGE toRemove)
	{
		this.RemoveStructure("PACKAGE", toRemove);
	}

	///<summary>
	///Removes the OML_O39_PACKAGE at the given index
	///</summary>
	public void RemovePACKAGEAt(int index)
	{
		this.RemoveRepetition("PACKAGE", index);
	}

}
}
