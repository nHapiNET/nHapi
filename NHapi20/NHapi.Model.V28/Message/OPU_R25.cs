using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V28.Group;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Message

{
///<summary>
/// Represents a OPU_R25 message structure (see chapter 7.3.11). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: NTE (Notes and Comments) optional </li>
///<li>4: PV1 (Patient Visit) </li>
///<li>5: PV2 (Patient Visit - Additional Information) optional </li>
///<li>6: PRT (Participation Information) optional repeating</li>
///<li>7: OPU_R25_PATIENT_VISIT_OBSERVATION (a Group object) optional repeating</li>
///<li>8: OPU_R25_ACCESSION_DETAIL (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OPU_R25 : AbstractMessage  {

	///<summary> 
	/// Creates a new OPU_R25 Group with custom IModelClassFactory.
	///</summary>
	public OPU_R25(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new OPU_R25 Group with DefaultModelClassFactory. 
	///</summary> 
	public OPU_R25() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for OPU_R25.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(NTE), false, false);
	      this.add(typeof(PV1), true, false);
	      this.add(typeof(PV2), false, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(OPU_R25_PATIENT_VISIT_OBSERVATION), false, true);
	      this.add(typeof(OPU_R25_ACCESSION_DETAIL), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OPU_R25 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (Message Header) - creates it if necessary
	///</summary>
	public MSH MSH { 
get{
	   MSH ret = null;
	   try {
	      ret = (MSH)this.GetStructure("MSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of SFT (Software Segment) - creates it if necessary
	///</summary>
	public SFT GetSFT() {
	   SFT ret = null;
	   try {
	      ret = (SFT)this.GetStructure("SFT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SFT
	/// * (Software Segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SFT GetSFT(int rep) { 
	   return (SFT)this.GetStructure("SFT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SFT 
	 */ 
	public int SFTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SFT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SFT results 
	 */ 
	public IEnumerable<SFT> SFTs 
	{ 
		get
		{
			for (int rep = 0; rep < SFTRepetitionsUsed; rep++)
			{
				yield return (SFT)this.GetStructure("SFT", rep);
			}
		}
	}

	///<summary>
	///Adds a new SFT
	///</summary>
	public SFT AddSFT()
	{
		return this.AddStructure("SFT") as SFT;
	}

	///<summary>
	///Removes the given SFT
	///</summary>
	public void RemoveSFT(SFT toRemove)
	{
		this.RemoveStructure("SFT", toRemove);
	}

	///<summary>
	///Removes the SFT at the given index
	///</summary>
	public void RemoveSFTAt(int index)
	{
		this.RemoveRepetition("SFT", index);
	}

	///<summary>
	/// Returns UAC (User Authentication Credential Segment) - creates it if necessary
	///</summary>
	public UAC UAC { 
get{
	   UAC ret = null;
	   try {
	      ret = (UAC)this.GetStructure("UAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns NTE (Notes and Comments) - creates it if necessary
	///</summary>
	public NTE NTE { 
get{
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PV1 (Patient Visit) - creates it if necessary
	///</summary>
	public PV1 PV1 { 
get{
	   PV1 ret = null;
	   try {
	      ret = (PV1)this.GetStructure("PV1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PV2 (Patient Visit - Additional Information) - creates it if necessary
	///</summary>
	public PV2 PV2 { 
get{
	   PV2 ret = null;
	   try {
	      ret = (PV2)this.GetStructure("PV2");
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
	/// Returns  first repetition of OPU_R25_PATIENT_VISIT_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OPU_R25_PATIENT_VISIT_OBSERVATION GetPATIENT_VISIT_OBSERVATION() {
	   OPU_R25_PATIENT_VISIT_OBSERVATION ret = null;
	   try {
	      ret = (OPU_R25_PATIENT_VISIT_OBSERVATION)this.GetStructure("PATIENT_VISIT_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPU_R25_PATIENT_VISIT_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPU_R25_PATIENT_VISIT_OBSERVATION GetPATIENT_VISIT_OBSERVATION(int rep) { 
	   return (OPU_R25_PATIENT_VISIT_OBSERVATION)this.GetStructure("PATIENT_VISIT_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPU_R25_PATIENT_VISIT_OBSERVATION 
	 */ 
	public int PATIENT_VISIT_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATIENT_VISIT_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPU_R25_PATIENT_VISIT_OBSERVATION results 
	 */ 
	public IEnumerable<OPU_R25_PATIENT_VISIT_OBSERVATION> PATIENT_VISIT_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENT_VISIT_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (OPU_R25_PATIENT_VISIT_OBSERVATION)this.GetStructure("PATIENT_VISIT_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPU_R25_PATIENT_VISIT_OBSERVATION
	///</summary>
	public OPU_R25_PATIENT_VISIT_OBSERVATION AddPATIENT_VISIT_OBSERVATION()
	{
		return this.AddStructure("PATIENT_VISIT_OBSERVATION") as OPU_R25_PATIENT_VISIT_OBSERVATION;
	}

	///<summary>
	///Removes the given OPU_R25_PATIENT_VISIT_OBSERVATION
	///</summary>
	public void RemovePATIENT_VISIT_OBSERVATION(OPU_R25_PATIENT_VISIT_OBSERVATION toRemove)
	{
		this.RemoveStructure("PATIENT_VISIT_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the OPU_R25_PATIENT_VISIT_OBSERVATION at the given index
	///</summary>
	public void RemovePATIENT_VISIT_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("PATIENT_VISIT_OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of OPU_R25_ACCESSION_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public OPU_R25_ACCESSION_DETAIL GetACCESSION_DETAIL() {
	   OPU_R25_ACCESSION_DETAIL ret = null;
	   try {
	      ret = (OPU_R25_ACCESSION_DETAIL)this.GetStructure("ACCESSION_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OPU_R25_ACCESSION_DETAIL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OPU_R25_ACCESSION_DETAIL GetACCESSION_DETAIL(int rep) { 
	   return (OPU_R25_ACCESSION_DETAIL)this.GetStructure("ACCESSION_DETAIL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OPU_R25_ACCESSION_DETAIL 
	 */ 
	public int ACCESSION_DETAILRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ACCESSION_DETAIL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OPU_R25_ACCESSION_DETAIL results 
	 */ 
	public IEnumerable<OPU_R25_ACCESSION_DETAIL> ACCESSION_DETAILs 
	{ 
		get
		{
			for (int rep = 0; rep < ACCESSION_DETAILRepetitionsUsed; rep++)
			{
				yield return (OPU_R25_ACCESSION_DETAIL)this.GetStructure("ACCESSION_DETAIL", rep);
			}
		}
	}

	///<summary>
	///Adds a new OPU_R25_ACCESSION_DETAIL
	///</summary>
	public OPU_R25_ACCESSION_DETAIL AddACCESSION_DETAIL()
	{
		return this.AddStructure("ACCESSION_DETAIL") as OPU_R25_ACCESSION_DETAIL;
	}

	///<summary>
	///Removes the given OPU_R25_ACCESSION_DETAIL
	///</summary>
	public void RemoveACCESSION_DETAIL(OPU_R25_ACCESSION_DETAIL toRemove)
	{
		this.RemoveStructure("ACCESSION_DETAIL", toRemove);
	}

	///<summary>
	///Removes the OPU_R25_ACCESSION_DETAIL at the given index
	///</summary>
	public void RemoveACCESSION_DETAILAt(int index)
	{
		this.RemoveRepetition("ACCESSION_DETAIL", index);
	}

}
}
