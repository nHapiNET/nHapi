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
///Represents the ORL_O34_SPECIMEN Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SPM (Specimen) </li>
///<li>1: ORL_O34_SPECIMEN_OBSERVATION (a Group object) optional repeating</li>
///<li>2: SAC (Specimen Container detail) optional repeating</li>
///<li>3: ORL_O34_ORDER (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORL_O34_SPECIMEN : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O34_SPECIMEN Group.
	///</summary>
	public ORL_O34_SPECIMEN(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SPM), true, false);
	      this.add(typeof(ORL_O34_SPECIMEN_OBSERVATION), false, true);
	      this.add(typeof(SAC), false, true);
	      this.add(typeof(ORL_O34_ORDER), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O34_SPECIMEN - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of ORL_O34_SPECIMEN_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public ORL_O34_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION() {
	   ORL_O34_SPECIMEN_OBSERVATION ret = null;
	   try {
	      ret = (ORL_O34_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORL_O34_SPECIMEN_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORL_O34_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION(int rep) { 
	   return (ORL_O34_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORL_O34_SPECIMEN_OBSERVATION 
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
	 * Enumerate over the ORL_O34_SPECIMEN_OBSERVATION results 
	 */ 
	public IEnumerable<ORL_O34_SPECIMEN_OBSERVATION> SPECIMEN_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < SPECIMEN_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (ORL_O34_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORL_O34_SPECIMEN_OBSERVATION
	///</summary>
	public ORL_O34_SPECIMEN_OBSERVATION AddSPECIMEN_OBSERVATION()
	{
		return this.AddStructure("SPECIMEN_OBSERVATION") as ORL_O34_SPECIMEN_OBSERVATION;
	}

	///<summary>
	///Removes the given ORL_O34_SPECIMEN_OBSERVATION
	///</summary>
	public void RemoveSPECIMEN_OBSERVATION(ORL_O34_SPECIMEN_OBSERVATION toRemove)
	{
		this.RemoveStructure("SPECIMEN_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the ORL_O34_SPECIMEN_OBSERVATION at the given index
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
	/// Returns  first repetition of ORL_O34_ORDER (a Group object) - creates it if necessary
	///</summary>
	public ORL_O34_ORDER GetORDER() {
	   ORL_O34_ORDER ret = null;
	   try {
	      ret = (ORL_O34_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORL_O34_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORL_O34_ORDER GetORDER(int rep) { 
	   return (ORL_O34_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORL_O34_ORDER 
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
	 * Enumerate over the ORL_O34_ORDER results 
	 */ 
	public IEnumerable<ORL_O34_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (ORL_O34_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORL_O34_ORDER
	///</summary>
	public ORL_O34_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as ORL_O34_ORDER;
	}

	///<summary>
	///Removes the given ORL_O34_ORDER
	///</summary>
	public void RemoveORDER(ORL_O34_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the ORL_O34_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
