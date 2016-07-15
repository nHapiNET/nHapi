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
///Represents the ORL_O40_OBSERVATION_REQUEST Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (Observation Request) </li>
///<li>1: PRT (Participation Information) optional repeating</li>
///<li>2: ORL_O40_SPECIMEN_SHIPMENT (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORL_O40_OBSERVATION_REQUEST : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O40_OBSERVATION_REQUEST Group.
	///</summary>
	public ORL_O40_OBSERVATION_REQUEST(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(ORL_O40_SPECIMEN_SHIPMENT), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O40_OBSERVATION_REQUEST - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of ORL_O40_SPECIMEN_SHIPMENT (a Group object) - creates it if necessary
	///</summary>
	public ORL_O40_SPECIMEN_SHIPMENT GetSPECIMEN_SHIPMENT() {
	   ORL_O40_SPECIMEN_SHIPMENT ret = null;
	   try {
	      ret = (ORL_O40_SPECIMEN_SHIPMENT)this.GetStructure("SPECIMEN_SHIPMENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORL_O40_SPECIMEN_SHIPMENT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORL_O40_SPECIMEN_SHIPMENT GetSPECIMEN_SHIPMENT(int rep) { 
	   return (ORL_O40_SPECIMEN_SHIPMENT)this.GetStructure("SPECIMEN_SHIPMENT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORL_O40_SPECIMEN_SHIPMENT 
	 */ 
	public int SPECIMEN_SHIPMENTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SPECIMEN_SHIPMENT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORL_O40_SPECIMEN_SHIPMENT results 
	 */ 
	public IEnumerable<ORL_O40_SPECIMEN_SHIPMENT> SPECIMEN_SHIPMENTs 
	{ 
		get
		{
			for (int rep = 0; rep < SPECIMEN_SHIPMENTRepetitionsUsed; rep++)
			{
				yield return (ORL_O40_SPECIMEN_SHIPMENT)this.GetStructure("SPECIMEN_SHIPMENT", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORL_O40_SPECIMEN_SHIPMENT
	///</summary>
	public ORL_O40_SPECIMEN_SHIPMENT AddSPECIMEN_SHIPMENT()
	{
		return this.AddStructure("SPECIMEN_SHIPMENT") as ORL_O40_SPECIMEN_SHIPMENT;
	}

	///<summary>
	///Removes the given ORL_O40_SPECIMEN_SHIPMENT
	///</summary>
	public void RemoveSPECIMEN_SHIPMENT(ORL_O40_SPECIMEN_SHIPMENT toRemove)
	{
		this.RemoveStructure("SPECIMEN_SHIPMENT", toRemove);
	}

	///<summary>
	///Removes the ORL_O40_SPECIMEN_SHIPMENT at the given index
	///</summary>
	public void RemoveSPECIMEN_SHIPMENTAt(int index)
	{
		this.RemoveRepetition("SPECIMEN_SHIPMENT", index);
	}

}
}
