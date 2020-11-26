using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the OPL_O37_CONTAINER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SAC (Specimen Container detail) </li>
///<li>1: OPL_O37_CONTAINER_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class OPL_O37_CONTAINER : AbstractGroup {

	///<summary> 
	/// Creates a new OPL_O37_CONTAINER Group.
	///</summary>
	public OPL_O37_CONTAINER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SAC), true, false);
	      this.add(typeof(OPL_O37_CONTAINER_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OPL_O37_CONTAINER - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns SAC (Specimen Container detail) - creates it if necessary
	///</summary>
	public SAC SAC { 
get{
	   SAC ret = null;
	   try {
	      ret = (SAC)this.GetStructure("SAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of OPL_O37_CONTAINER_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OPL_O37_CONTAINER_OBSERVATION GetCONTAINER_OBSERVATION() {
	   OPL_O37_CONTAINER_OBSERVATION ret = null;
	   try {
	      ret = (OPL_O37_CONTAINER_OBSERVATION)this.GetStructure("CONTAINER_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPL_O37_CONTAINER_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPL_O37_CONTAINER_OBSERVATION GetCONTAINER_OBSERVATION(int rep) { 
	   return (OPL_O37_CONTAINER_OBSERVATION)this.GetStructure("CONTAINER_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPL_O37_CONTAINER_OBSERVATION 
	 */ 
	public int CONTAINER_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CONTAINER_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPL_O37_CONTAINER_OBSERVATION results 
	 */ 
	public IEnumerable<OPL_O37_CONTAINER_OBSERVATION> CONTAINER_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < CONTAINER_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OPL_O37_CONTAINER_OBSERVATION)this.GetStructure("CONTAINER_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPL_O37_CONTAINER_OBSERVATION
	///</summary>
	public OPL_O37_CONTAINER_OBSERVATION AddCONTAINER_OBSERVATION()
	{
		return this.AddStructure("CONTAINER_OBSERVATION") as OPL_O37_CONTAINER_OBSERVATION;
	}

	///<summary>
	///Removes the given OPL_O37_CONTAINER_OBSERVATION
	///</summary>
	public void RemoveCONTAINER_OBSERVATION(OPL_O37_CONTAINER_OBSERVATION toRemove)
	{
		this.RemoveStructure("CONTAINER_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OPL_O37_CONTAINER_OBSERVATION at the given index
	///</summary>
	public void RemoveCONTAINER_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("CONTAINER_OBSERVATION", index);
	}

}
}
