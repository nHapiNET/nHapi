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
///Represents the OPU_R25_SPECIMEN Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SPM (Specimen) </li>
///<li>1: OPU_R25_SPECIMEN_OBSERVATION (a Group object) optional repeating</li>
///<li>2: OPU_R25_CONTAINER (a Group object) optional repeating</li>
///<li>3: OPU_R25_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OPU_R25_SPECIMEN : AbstractGroup {

	///<summary> 
	/// Creates a new OPU_R25_SPECIMEN Group.
	///</summary>
	public OPU_R25_SPECIMEN(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SPM), true, false);
	      this.add(typeof(OPU_R25_SPECIMEN_OBSERVATION), false, true);
	      this.add(typeof(OPU_R25_CONTAINER), false, true);
	      this.add(typeof(OPU_R25_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OPU_R25_SPECIMEN - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of OPU_R25_SPECIMEN_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OPU_R25_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION() {
	   OPU_R25_SPECIMEN_OBSERVATION ret = null;
	   try {
	      ret = (OPU_R25_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPU_R25_SPECIMEN_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPU_R25_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION(int rep) { 
	   return (OPU_R25_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPU_R25_SPECIMEN_OBSERVATION 
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
	 * Enumerate over the OPU_R25_SPECIMEN_OBSERVATION results 
	 */ 
	public IEnumerable<OPU_R25_SPECIMEN_OBSERVATION> SPECIMEN_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < SPECIMEN_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OPU_R25_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPU_R25_SPECIMEN_OBSERVATION
	///</summary>
	public OPU_R25_SPECIMEN_OBSERVATION AddSPECIMEN_OBSERVATION()
	{
		return this.AddStructure("SPECIMEN_OBSERVATION") as OPU_R25_SPECIMEN_OBSERVATION;
	}

	///<summary>
	///Removes the given OPU_R25_SPECIMEN_OBSERVATION
	///</summary>
	public void RemoveSPECIMEN_OBSERVATION(OPU_R25_SPECIMEN_OBSERVATION toRemove)
	{
		this.RemoveStructure("SPECIMEN_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OPU_R25_SPECIMEN_OBSERVATION at the given index
	///</summary>
	public void RemoveSPECIMEN_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("SPECIMEN_OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of OPU_R25_CONTAINER (a Group object) - creates it if necessary
	///</summary>
	public OPU_R25_CONTAINER GetCONTAINER() {
	   OPU_R25_CONTAINER ret = null;
	   try {
	      ret = (OPU_R25_CONTAINER)this.GetStructure("CONTAINER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPU_R25_CONTAINER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPU_R25_CONTAINER GetCONTAINER(int rep) { 
	   return (OPU_R25_CONTAINER)this.GetStructure("CONTAINER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPU_R25_CONTAINER 
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
	 * Enumerate over the OPU_R25_CONTAINER results 
	 */ 
	public IEnumerable<OPU_R25_CONTAINER> CONTAINERs 
	{ 
		get
		{
			for (int rep = 0; rep < CONTAINERRepetitionsUsed; rep++)
			{
				yield return (OPU_R25_CONTAINER)this.GetStructure("CONTAINER", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPU_R25_CONTAINER
	///</summary>
	public OPU_R25_CONTAINER AddCONTAINER()
	{
		return this.AddStructure("CONTAINER") as OPU_R25_CONTAINER;
	}

	///<summary>
	///Removes the given OPU_R25_CONTAINER
	///</summary>
	public void RemoveCONTAINER(OPU_R25_CONTAINER toRemove)
	{
		this.RemoveStructure("CONTAINER", toRemove);
	}

	///<summary>
	///Removes the OPU_R25_CONTAINER at the given index
	///</summary>
	public void RemoveCONTAINERAt(int index)
	{
		this.RemoveRepetition("CONTAINER", index);
	}

	///<summary>
	/// Returns  first repetition of OPU_R25_ORDER (a Group object) - creates it if necessary
	///</summary>
	public OPU_R25_ORDER GetORDER() {
	   OPU_R25_ORDER ret = null;
	   try {
	      ret = (OPU_R25_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPU_R25_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPU_R25_ORDER GetORDER(int rep) { 
	   return (OPU_R25_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPU_R25_ORDER 
	 */ 
	public int ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPU_R25_ORDER results 
	 */ 
	public IEnumerable<OPU_R25_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (OPU_R25_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPU_R25_ORDER
	///</summary>
	public OPU_R25_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as OPU_R25_ORDER;
	}

	///<summary>
	///Removes the given OPU_R25_ORDER
	///</summary>
	public void RemoveORDER(OPU_R25_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the OPU_R25_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
