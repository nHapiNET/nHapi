using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the OPR_O38_SPECIMEN Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SPM (Specimen) </li>
///<li>1: OPR_O38_SPECIMEN_OBSERVATION (a Group object) optional repeating</li>
///<li>2: SAC (Specimen Container detail) optional repeating</li>
///<li>3: OPR_O38_OBSERVATION_REQUEST (a Group object) optional repeating</li>
///<li>4: OPR_O38_TIMING (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class OPR_O38_SPECIMEN : AbstractGroup {

	///<summary> 
	/// Creates a new OPR_O38_SPECIMEN Group.
	///</summary>
	public OPR_O38_SPECIMEN(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SPM), true, false);
	      this.add(typeof(OPR_O38_SPECIMEN_OBSERVATION), false, true);
	      this.add(typeof(SAC), false, true);
	      this.add(typeof(OPR_O38_OBSERVATION_REQUEST), false, true);
	      this.add(typeof(OPR_O38_TIMING), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OPR_O38_SPECIMEN - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of OPR_O38_SPECIMEN_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OPR_O38_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION() {
	   OPR_O38_SPECIMEN_OBSERVATION ret = null;
	   try {
	      ret = (OPR_O38_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPR_O38_SPECIMEN_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPR_O38_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION(int rep) { 
	   return (OPR_O38_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPR_O38_SPECIMEN_OBSERVATION 
	 */ 
	public int SPECIMEN_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SPECIMEN_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPR_O38_SPECIMEN_OBSERVATION results 
	 */ 
	public IEnumerable<OPR_O38_SPECIMEN_OBSERVATION> SPECIMEN_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < SPECIMEN_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OPR_O38_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPR_O38_SPECIMEN_OBSERVATION
	///</summary>
	public OPR_O38_SPECIMEN_OBSERVATION AddSPECIMEN_OBSERVATION()
	{
		return this.AddStructure("SPECIMEN_OBSERVATION") as OPR_O38_SPECIMEN_OBSERVATION;
	}

	///<summary>
	///Removes the given OPR_O38_SPECIMEN_OBSERVATION
	///</summary>
	public void RemoveSPECIMEN_OBSERVATION(OPR_O38_SPECIMEN_OBSERVATION toRemove)
	{
		this.RemoveStructure("SPECIMEN_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OPR_O38_SPECIMEN_OBSERVATION at the given index
	///</summary>
	public void RemoveSPECIMEN_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("SPECIMEN_OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of SAC (Specimen Container detail) - creates it if necessary
	///</summary>
	public SAC GetSAC() {
	   SAC ret = null;
	   try {
	      ret = (SAC)this.GetStructure("SAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SAC
	/// * (Specimen Container detail) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SAC GetSAC(int rep) { 
	   return (SAC)this.GetStructure("SAC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SAC 
	 */ 
	public int SACRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SAC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SAC results 
	 */ 
	public IEnumerable<SAC> SACs 
	{ 
		get
		{
			for (int rep = 0; rep < SACRepetitionsUsed; rep++)
			{
				yield return (SAC)this.GetStructure("SAC", rep);
			}
		}
	}

	///<summary>
	///Adds a new SAC
	///</summary>
	public SAC AddSAC()
	{
		return this.AddStructure("SAC") as SAC;
	}

	///<summary>
	///Removes the given SAC
	///</summary>
	public void RemoveSAC(SAC toRemove)
	{
		this.RemoveStructure("SAC", toRemove);
	}

	///<summary>
	///Removes the SAC at the given index
	///</summary>
	public void RemoveSACAt(int index)
	{
		this.RemoveRepetition("SAC", index);
	}

	///<summary>
	/// Returns  first repetition of OPR_O38_OBSERVATION_REQUEST (a Group object) - creates it if necessary
	///</summary>
	public OPR_O38_OBSERVATION_REQUEST GetOBSERVATION_REQUEST() {
	   OPR_O38_OBSERVATION_REQUEST ret = null;
	   try {
	      ret = (OPR_O38_OBSERVATION_REQUEST)this.GetStructure("OBSERVATION_REQUEST");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPR_O38_OBSERVATION_REQUEST
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPR_O38_OBSERVATION_REQUEST GetOBSERVATION_REQUEST(int rep) { 
	   return (OPR_O38_OBSERVATION_REQUEST)this.GetStructure("OBSERVATION_REQUEST", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPR_O38_OBSERVATION_REQUEST 
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
	 * Enumerate over the OPR_O38_OBSERVATION_REQUEST results 
	 */ 
	public IEnumerable<OPR_O38_OBSERVATION_REQUEST> OBSERVATION_REQUESTs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATION_REQUESTRepetitionsUsed; rep++)
			{
				yield return (OPR_O38_OBSERVATION_REQUEST)this.GetStructure("OBSERVATION_REQUEST", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPR_O38_OBSERVATION_REQUEST
	///</summary>
	public OPR_O38_OBSERVATION_REQUEST AddOBSERVATION_REQUEST()
	{
		return this.AddStructure("OBSERVATION_REQUEST") as OPR_O38_OBSERVATION_REQUEST;
	}

	///<summary>
	///Removes the given OPR_O38_OBSERVATION_REQUEST
	///</summary>
	public void RemoveOBSERVATION_REQUEST(OPR_O38_OBSERVATION_REQUEST toRemove)
	{
		this.RemoveStructure("OBSERVATION_REQUEST", toRemove);
	}

	///<summary>
	///Removes the OPR_O38_OBSERVATION_REQUEST at the given index
	///</summary>
	public void RemoveOBSERVATION_REQUESTAt(int index)
	{
		this.RemoveRepetition("OBSERVATION_REQUEST", index);
	}

	///<summary>
	/// Returns  first repetition of OPR_O38_TIMING (a Group object) - creates it if necessary
	///</summary>
	public OPR_O38_TIMING GetTIMING() {
	   OPR_O38_TIMING ret = null;
	   try {
	      ret = (OPR_O38_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPR_O38_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPR_O38_TIMING GetTIMING(int rep) { 
	   return (OPR_O38_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPR_O38_TIMING 
	 */ 
	public int TIMINGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPR_O38_TIMING results 
	 */ 
	public IEnumerable<OPR_O38_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (OPR_O38_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPR_O38_TIMING
	///</summary>
	public OPR_O38_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as OPR_O38_TIMING;
	}

	///<summary>
	///Removes the given OPR_O38_TIMING
	///</summary>
	public void RemoveTIMING(OPR_O38_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the OPR_O38_TIMING at the given index
	///</summary>
	public void RemoveTIMINGAt(int index)
	{
		this.RemoveRepetition("TIMING", index);
	}

}
}
