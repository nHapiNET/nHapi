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
///Represents the OPL_O37_SPECIMEN Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SPM (Specimen) </li>
///<li>1: OBX (Observation/Result) optional repeating</li>
///<li>2: OPL_O37_CONTAINER (a Group object) optional repeating</li>
///<li>3: OPL_O37_OBSERVATION_REQUEST (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OPL_O37_SPECIMEN : AbstractGroup {

	///<summary> 
	/// Creates a new OPL_O37_SPECIMEN Group.
	///</summary>
	public OPL_O37_SPECIMEN(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SPM), true, false);
	      this.add(typeof(OBX), false, true);
	      this.add(typeof(OPL_O37_CONTAINER), false, true);
	      this.add(typeof(OPL_O37_OBSERVATION_REQUEST), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OPL_O37_SPECIMEN - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns SPM (Specimen) - creates it if necessary
	///</summary>
	public SPM SPM { 
get{
	   SPM ret = null;
	   try {
	      ret = (SPM)this.GetStructure("SPM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of OBX (Observation/Result) - creates it if necessary
	///</summary>
	public OBX GetOBX() {
	   OBX ret = null;
	   try {
	      ret = (OBX)this.GetStructure("OBX");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OBX
	/// * (Observation/Result) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OBX GetOBX(int rep) { 
	   return (OBX)this.GetStructure("OBX", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OBX 
	 */ 
	public int OBXRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBX").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OBX results 
	 */ 
	public IEnumerable<OBX> OBXs 
	{ 
		get
		{
			for (int rep = 0; rep < OBXRepetitionsUsed; rep++)
			{
				yield return (OBX)this.GetStructure("OBX", rep);
			}
		}
	}

	///<summary>
	///Adds a new OBX
	///</summary>
	public OBX AddOBX()
	{
		return this.AddStructure("OBX") as OBX;
	}

	///<summary>
	///Removes the given OBX
	///</summary>
	public void RemoveOBX(OBX toRemove)
	{
		this.RemoveStructure("OBX", toRemove);
	}

	///<summary>
	///Removes the OBX at the given index
	///</summary>
	public void RemoveOBXAt(int index)
	{
		this.RemoveRepetition("OBX", index);
	}

	///<summary>
	/// Returns  first repetition of OPL_O37_CONTAINER (a Group object) - creates it if necessary
	///</summary>
	public OPL_O37_CONTAINER GetCONTAINER() {
	   OPL_O37_CONTAINER ret = null;
	   try {
	      ret = (OPL_O37_CONTAINER)this.GetStructure("CONTAINER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPL_O37_CONTAINER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPL_O37_CONTAINER GetCONTAINER(int rep) { 
	   return (OPL_O37_CONTAINER)this.GetStructure("CONTAINER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPL_O37_CONTAINER 
	 */ 
	public int CONTAINERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CONTAINER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPL_O37_CONTAINER results 
	 */ 
	public IEnumerable<OPL_O37_CONTAINER> CONTAINERs 
	{ 
		get
		{
			for (int rep = 0; rep < CONTAINERRepetitionsUsed; rep++)
			{
				yield return (OPL_O37_CONTAINER)this.GetStructure("CONTAINER", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPL_O37_CONTAINER
	///</summary>
	public OPL_O37_CONTAINER AddCONTAINER()
	{
		return this.AddStructure("CONTAINER") as OPL_O37_CONTAINER;
	}

	///<summary>
	///Removes the given OPL_O37_CONTAINER
	///</summary>
	public void RemoveCONTAINER(OPL_O37_CONTAINER toRemove)
	{
		this.RemoveStructure("CONTAINER", toRemove);
	}

	///<summary>
	///Removes the OPL_O37_CONTAINER at the given index
	///</summary>
	public void RemoveCONTAINERAt(int index)
	{
		this.RemoveRepetition("CONTAINER", index);
	}

	///<summary>
	/// Returns  first repetition of OPL_O37_OBSERVATION_REQUEST (a Group object) - creates it if necessary
	///</summary>
	public OPL_O37_OBSERVATION_REQUEST GetOBSERVATION_REQUEST() {
	   OPL_O37_OBSERVATION_REQUEST ret = null;
	   try {
	      ret = (OPL_O37_OBSERVATION_REQUEST)this.GetStructure("OBSERVATION_REQUEST");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPL_O37_OBSERVATION_REQUEST
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPL_O37_OBSERVATION_REQUEST GetOBSERVATION_REQUEST(int rep) { 
	   return (OPL_O37_OBSERVATION_REQUEST)this.GetStructure("OBSERVATION_REQUEST", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPL_O37_OBSERVATION_REQUEST 
	 */ 
	public int OBSERVATION_REQUESTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION_REQUEST").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPL_O37_OBSERVATION_REQUEST results 
	 */ 
	public IEnumerable<OPL_O37_OBSERVATION_REQUEST> OBSERVATION_REQUESTs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATION_REQUESTRepetitionsUsed; rep++)
			{
				yield return (OPL_O37_OBSERVATION_REQUEST)this.GetStructure("OBSERVATION_REQUEST", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPL_O37_OBSERVATION_REQUEST
	///</summary>
	public OPL_O37_OBSERVATION_REQUEST AddOBSERVATION_REQUEST()
	{
		return this.AddStructure("OBSERVATION_REQUEST") as OPL_O37_OBSERVATION_REQUEST;
	}

	///<summary>
	///Removes the given OPL_O37_OBSERVATION_REQUEST
	///</summary>
	public void RemoveOBSERVATION_REQUEST(OPL_O37_OBSERVATION_REQUEST toRemove)
	{
		this.RemoveStructure("OBSERVATION_REQUEST", toRemove);
	}

	///<summary>
	///Removes the OPL_O37_OBSERVATION_REQUEST at the given index
	///</summary>
	public void RemoveOBSERVATION_REQUESTAt(int index)
	{
		this.RemoveRepetition("OBSERVATION_REQUEST", index);
	}

}
}
