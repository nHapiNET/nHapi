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
///Represents the OML_O21_SPECIMEN Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SPM (Specimen) </li>
///<li>1: OML_O21_SPECIMEN_OBSERVATION (a Group object) optional repeating</li>
///<li>2: OML_O21_CONTAINER (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class OML_O21_SPECIMEN : AbstractGroup {

	///<summary> 
	/// Creates a new OML_O21_SPECIMEN Group.
	///</summary>
	public OML_O21_SPECIMEN(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SPM), true, false);
	      this.add(typeof(OML_O21_SPECIMEN_OBSERVATION), false, true);
	      this.add(typeof(OML_O21_CONTAINER), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OML_O21_SPECIMEN - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of OML_O21_SPECIMEN_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OML_O21_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION() {
	   OML_O21_SPECIMEN_OBSERVATION ret = null;
	   try {
	      ret = (OML_O21_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O21_SPECIMEN_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O21_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION(int rep) { 
	   return (OML_O21_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O21_SPECIMEN_OBSERVATION 
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
	 * Enumerate over the OML_O21_SPECIMEN_OBSERVATION results 
	 */ 
	public IEnumerable<OML_O21_SPECIMEN_OBSERVATION> SPECIMEN_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < SPECIMEN_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OML_O21_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OML_O21_SPECIMEN_OBSERVATION
	///</summary>
	public OML_O21_SPECIMEN_OBSERVATION AddSPECIMEN_OBSERVATION()
	{
		return this.AddStructure("SPECIMEN_OBSERVATION") as OML_O21_SPECIMEN_OBSERVATION;
	}

	///<summary>
	///Removes the given OML_O21_SPECIMEN_OBSERVATION
	///</summary>
	public void RemoveSPECIMEN_OBSERVATION(OML_O21_SPECIMEN_OBSERVATION toRemove)
	{
		this.RemoveStructure("SPECIMEN_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OML_O21_SPECIMEN_OBSERVATION at the given index
	///</summary>
	public void RemoveSPECIMEN_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("SPECIMEN_OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of OML_O21_CONTAINER (a Group object) - creates it if necessary
	///</summary>
	public OML_O21_CONTAINER GetCONTAINER() {
	   OML_O21_CONTAINER ret = null;
	   try {
	      ret = (OML_O21_CONTAINER)this.GetStructure("CONTAINER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O21_CONTAINER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O21_CONTAINER GetCONTAINER(int rep) { 
	   return (OML_O21_CONTAINER)this.GetStructure("CONTAINER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O21_CONTAINER 
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
	 * Enumerate over the OML_O21_CONTAINER results 
	 */ 
	public IEnumerable<OML_O21_CONTAINER> CONTAINERs 
	{ 
		get
		{
			for (int rep = 0; rep < CONTAINERRepetitionsUsed; rep++)
			{
				yield return (OML_O21_CONTAINER)this.GetStructure("CONTAINER", rep);
			}
		}
	}

	///<summary>
	///Adds a new OML_O21_CONTAINER
	///</summary>
	public OML_O21_CONTAINER AddCONTAINER()
	{
		return this.AddStructure("CONTAINER") as OML_O21_CONTAINER;
	}

	///<summary>
	///Removes the given OML_O21_CONTAINER
	///</summary>
	public void RemoveCONTAINER(OML_O21_CONTAINER toRemove)
	{
		this.RemoveStructure("CONTAINER", toRemove);
	}

	///<summary>
	///Removes the OML_O21_CONTAINER at the given index
	///</summary>
	public void RemoveCONTAINERAt(int index)
	{
		this.RemoveRepetition("CONTAINER", index);
	}

}
}
