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
///Represents the ORL_O34_OBSERVATION_REQUEST Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (Observation Request) </li>
///<li>1: ORL_O34_OBSERVATION_REQUEST_SPECIMEN (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORL_O34_OBSERVATION_REQUEST : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O34_OBSERVATION_REQUEST Group.
	///</summary>
	public ORL_O34_OBSERVATION_REQUEST(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(ORL_O34_OBSERVATION_REQUEST_SPECIMEN), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O34_OBSERVATION_REQUEST - this is probably a bug in the source code generator.", e);
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
	      throw new System.Exception("An unexpected error occurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORL_O34_OBSERVATION_REQUEST_SPECIMEN (a Group object) - creates it if necessary
	///</summary>
	public ORL_O34_OBSERVATION_REQUEST_SPECIMEN GetOBSERVATION_REQUEST_SPECIMEN() {
	   ORL_O34_OBSERVATION_REQUEST_SPECIMEN ret = null;
	   try {
	      ret = (ORL_O34_OBSERVATION_REQUEST_SPECIMEN)this.GetStructure("OBSERVATION_REQUEST_SPECIMEN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error occurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORL_O34_OBSERVATION_REQUEST_SPECIMEN
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORL_O34_OBSERVATION_REQUEST_SPECIMEN GetOBSERVATION_REQUEST_SPECIMEN(int rep) { 
	   return (ORL_O34_OBSERVATION_REQUEST_SPECIMEN)this.GetStructure("OBSERVATION_REQUEST_SPECIMEN", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORL_O34_OBSERVATION_REQUEST_SPECIMEN 
	 */ 
	public int OBSERVATION_REQUEST_SPECIMENRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION_REQUEST_SPECIMEN").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORL_O34_OBSERVATION_REQUEST_SPECIMEN results 
	 */ 
	public IEnumerable<ORL_O34_OBSERVATION_REQUEST_SPECIMEN> OBSERVATION_REQUEST_SPECIMENs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATION_REQUEST_SPECIMENRepetitionsUsed; rep++)
			{
				yield return (ORL_O34_OBSERVATION_REQUEST_SPECIMEN)this.GetStructure("OBSERVATION_REQUEST_SPECIMEN", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORL_O34_OBSERVATION_REQUEST_SPECIMEN
	///</summary>
	public ORL_O34_OBSERVATION_REQUEST_SPECIMEN AddOBSERVATION_REQUEST_SPECIMEN()
	{
		return this.AddStructure("OBSERVATION_REQUEST_SPECIMEN") as ORL_O34_OBSERVATION_REQUEST_SPECIMEN;
	}

	///<summary>
	///Removes the given ORL_O34_OBSERVATION_REQUEST_SPECIMEN
	///</summary>
	public void RemoveOBSERVATION_REQUEST_SPECIMEN(ORL_O34_OBSERVATION_REQUEST_SPECIMEN toRemove)
	{
		this.RemoveStructure("OBSERVATION_REQUEST_SPECIMEN", toRemove);
	}

	///<summary>
	///Removes the ORL_O34_OBSERVATION_REQUEST_SPECIMEN at the given index
	///</summary>
	public void RemoveOBSERVATION_REQUEST_SPECIMENAt(int index)
	{
		this.RemoveRepetition("OBSERVATION_REQUEST_SPECIMEN", index);
	}

}
}