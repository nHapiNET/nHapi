using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Group
{
///<summary>
///Represents the ORL_O34_OBSERVATION_REQUEST Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (Observation Request) </li>
///<li>1: ORL_O34_SPECIMEN (a Group object) optional repeating</li>
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
	      this.add(typeof(ORL_O34_SPECIMEN), false, true);
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
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORL_O34_SPECIMEN (a Group object) - creates it if necessary
	///</summary>
	public ORL_O34_SPECIMEN GetSPECIMEN() {
	   ORL_O34_SPECIMEN ret = null;
	   try {
	      ret = (ORL_O34_SPECIMEN)this.GetStructure("SPECIMEN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORL_O34_SPECIMEN
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORL_O34_SPECIMEN GetSPECIMEN(int rep) { 
	   return (ORL_O34_SPECIMEN)this.GetStructure("SPECIMEN", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORL_O34_SPECIMEN 
	 */ 
	public int SPECIMENRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SPECIMEN").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORL_O34_SPECIMEN results 
	 */ 
	public IEnumerable<ORL_O34_SPECIMEN> SPECIMENs 
	{ 
		get
		{
			for (int rep = 0; rep < SPECIMENRepetitionsUsed; rep++)
			{
				yield return (ORL_O34_SPECIMEN)this.GetStructure("SPECIMEN", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORL_O34_SPECIMEN
	///</summary>
	public ORL_O34_SPECIMEN AddSPECIMEN()
	{
		return this.AddStructure("SPECIMEN") as ORL_O34_SPECIMEN;
	}

	///<summary>
	///Removes the given ORL_O34_SPECIMEN
	///</summary>
	public void RemoveSPECIMEN(ORL_O34_SPECIMEN toRemove)
	{
		this.RemoveStructure("SPECIMEN", toRemove);
	}

	///<summary>
	///Removes the ORL_O34_SPECIMEN at the given index
	///</summary>
	public void RemoveSPECIMENAt(int index)
	{
		this.RemoveRepetition("SPECIMEN", index);
	}

}
}
