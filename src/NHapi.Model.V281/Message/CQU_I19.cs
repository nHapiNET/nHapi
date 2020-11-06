using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V281.Group;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Message

{
///<summary>
/// Represents a CQU_I19 message structure (see chapter 11.7.1). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: MSA (Message Acknowledgment) </li>
///<li>4: ERR (Error) optional repeating</li>
///<li>5: RF1 (Referral Information) </li>
///<li>6: CQU_I19_PROVIDER_CONTACT (a Group object) optional repeating</li>
///<li>7: CQU_I19_PATIENT (a Group object) optional repeating</li>
///<li>8: NK1 (Next of Kin / Associated Parties) optional repeating</li>
///<li>9: CQU_I19_INSURANCE (a Group object) optional repeating</li>
///<li>10: CQU_I19_APPOINTMENT_HISTORY (a Group object) optional repeating</li>
///<li>11: CQU_I19_CLINICAL_HISTORY (a Group object) optional repeating</li>
///<li>12: CQU_I19_PATIENT_VISITS (a Group object) repeating</li>
///<li>13: CQU_I19_MEDICATION_HISTORY (a Group object) optional repeating</li>
///<li>14: CQU_I19_PROBLEM (a Group object) optional repeating</li>
///<li>15: CQU_I19_GOAL (a Group object) optional repeating</li>
///<li>16: CQU_I19_PATHWAY (a Group object) optional repeating</li>
///<li>17: REL (Clinical Relationship Segment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CQU_I19 : AbstractMessage  {

	///<summary> 
	/// Creates a new CQU_I19 Group with custom IModelClassFactory.
	///</summary>
	public CQU_I19(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new CQU_I19 Group with DefaultModelClassFactory. 
	///</summary> 
	public CQU_I19() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for CQU_I19.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(ERR), false, true);
	      this.add(typeof(RF1), true, false);
	      this.add(typeof(CQU_I19_PROVIDER_CONTACT), false, true);
	      this.add(typeof(CQU_I19_PATIENT), false, true);
	      this.add(typeof(NK1), false, true);
	      this.add(typeof(CQU_I19_INSURANCE), false, true);
	      this.add(typeof(CQU_I19_APPOINTMENT_HISTORY), false, true);
	      this.add(typeof(CQU_I19_CLINICAL_HISTORY), false, true);
	      this.add(typeof(CQU_I19_PATIENT_VISITS), true, true);
	      this.add(typeof(CQU_I19_MEDICATION_HISTORY), false, true);
	      this.add(typeof(CQU_I19_PROBLEM), false, true);
	      this.add(typeof(CQU_I19_GOAL), false, true);
	      this.add(typeof(CQU_I19_PATHWAY), false, true);
	      this.add(typeof(REL), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CQU_I19 - this is probably a bug in the source code generator.", e);
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
	/// Returns MSA (Message Acknowledgment) - creates it if necessary
	///</summary>
	public MSA MSA { 
get{
	   MSA ret = null;
	   try {
	      ret = (MSA)this.GetStructure("MSA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ERR (Error) - creates it if necessary
	///</summary>
	public ERR GetERR() {
	   ERR ret = null;
	   try {
	      ret = (ERR)this.GetStructure("ERR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ERR
	/// * (Error) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ERR GetERR(int rep) { 
	   return (ERR)this.GetStructure("ERR", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ERR 
	 */ 
	public int ERRRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ERR").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ERR results 
	 */ 
	public IEnumerable<ERR> ERRs 
	{ 
		get
		{
			for (int rep = 0; rep < ERRRepetitionsUsed; rep++)
			{
				yield return (ERR)this.GetStructure("ERR", rep);
			}
		}
	}

	///<summary>
	///Adds a new ERR
	///</summary>
	public ERR AddERR()
	{
		return this.AddStructure("ERR") as ERR;
	}

	///<summary>
	///Removes the given ERR
	///</summary>
	public void RemoveERR(ERR toRemove)
	{
		this.RemoveStructure("ERR", toRemove);
	}

	///<summary>
	///Removes the ERR at the given index
	///</summary>
	public void RemoveERRAt(int index)
	{
		this.RemoveRepetition("ERR", index);
	}

	///<summary>
	/// Returns RF1 (Referral Information) - creates it if necessary
	///</summary>
	public RF1 RF1 { 
get{
	   RF1 ret = null;
	   try {
	      ret = (RF1)this.GetStructure("RF1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_PROVIDER_CONTACT (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_PROVIDER_CONTACT GetPROVIDER_CONTACT() {
	   CQU_I19_PROVIDER_CONTACT ret = null;
	   try {
	      ret = (CQU_I19_PROVIDER_CONTACT)this.GetStructure("PROVIDER_CONTACT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_PROVIDER_CONTACT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_PROVIDER_CONTACT GetPROVIDER_CONTACT(int rep) { 
	   return (CQU_I19_PROVIDER_CONTACT)this.GetStructure("PROVIDER_CONTACT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_PROVIDER_CONTACT 
	 */ 
	public int PROVIDER_CONTACTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PROVIDER_CONTACT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_PROVIDER_CONTACT results 
	 */ 
	public IEnumerable<CQU_I19_PROVIDER_CONTACT> PROVIDER_CONTACTs 
	{ 
		get
		{
			for (int rep = 0; rep < PROVIDER_CONTACTRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_PROVIDER_CONTACT)this.GetStructure("PROVIDER_CONTACT", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_PROVIDER_CONTACT
	///</summary>
	public CQU_I19_PROVIDER_CONTACT AddPROVIDER_CONTACT()
	{
		return this.AddStructure("PROVIDER_CONTACT") as CQU_I19_PROVIDER_CONTACT;
	}

	///<summary>
	///Removes the given CQU_I19_PROVIDER_CONTACT
	///</summary>
	public void RemovePROVIDER_CONTACT(CQU_I19_PROVIDER_CONTACT toRemove)
	{
		this.RemoveStructure("PROVIDER_CONTACT", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_PROVIDER_CONTACT at the given index
	///</summary>
	public void RemovePROVIDER_CONTACTAt(int index)
	{
		this.RemoveRepetition("PROVIDER_CONTACT", index);
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_PATIENT GetPATIENT() {
	   CQU_I19_PATIENT ret = null;
	   try {
	      ret = (CQU_I19_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_PATIENT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_PATIENT GetPATIENT(int rep) { 
	   return (CQU_I19_PATIENT)this.GetStructure("PATIENT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_PATIENT 
	 */ 
	public int PATIENTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATIENT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_PATIENT results 
	 */ 
	public IEnumerable<CQU_I19_PATIENT> PATIENTs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENTRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_PATIENT)this.GetStructure("PATIENT", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_PATIENT
	///</summary>
	public CQU_I19_PATIENT AddPATIENT()
	{
		return this.AddStructure("PATIENT") as CQU_I19_PATIENT;
	}

	///<summary>
	///Removes the given CQU_I19_PATIENT
	///</summary>
	public void RemovePATIENT(CQU_I19_PATIENT toRemove)
	{
		this.RemoveStructure("PATIENT", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_PATIENT at the given index
	///</summary>
	public void RemovePATIENTAt(int index)
	{
		this.RemoveRepetition("PATIENT", index);
	}

	///<summary>
	/// Returns  first repetition of NK1 (Next of Kin / Associated Parties) - creates it if necessary
	///</summary>
	public NK1 GetNK1() {
	   NK1 ret = null;
	   try {
	      ret = (NK1)this.GetStructure("NK1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NK1
	/// * (Next of Kin / Associated Parties) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NK1 GetNK1(int rep) { 
	   return (NK1)this.GetStructure("NK1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NK1 
	 */ 
	public int NK1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NK1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NK1 results 
	 */ 
	public IEnumerable<NK1> NK1s 
	{ 
		get
		{
			for (int rep = 0; rep < NK1RepetitionsUsed; rep++)
			{
				yield return (NK1)this.GetStructure("NK1", rep);
			}
		}
	}

	///<summary>
	///Adds a new NK1
	///</summary>
	public NK1 AddNK1()
	{
		return this.AddStructure("NK1") as NK1;
	}

	///<summary>
	///Removes the given NK1
	///</summary>
	public void RemoveNK1(NK1 toRemove)
	{
		this.RemoveStructure("NK1", toRemove);
	}

	///<summary>
	///Removes the NK1 at the given index
	///</summary>
	public void RemoveNK1At(int index)
	{
		this.RemoveRepetition("NK1", index);
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_INSURANCE GetINSURANCE() {
	   CQU_I19_INSURANCE ret = null;
	   try {
	      ret = (CQU_I19_INSURANCE)this.GetStructure("INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_INSURANCE GetINSURANCE(int rep) { 
	   return (CQU_I19_INSURANCE)this.GetStructure("INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_INSURANCE 
	 */ 
	public int INSURANCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("INSURANCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_INSURANCE results 
	 */ 
	public IEnumerable<CQU_I19_INSURANCE> INSURANCEs 
	{ 
		get
		{
			for (int rep = 0; rep < INSURANCERepetitionsUsed; rep++)
			{
				yield return (CQU_I19_INSURANCE)this.GetStructure("INSURANCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_INSURANCE
	///</summary>
	public CQU_I19_INSURANCE AddINSURANCE()
	{
		return this.AddStructure("INSURANCE") as CQU_I19_INSURANCE;
	}

	///<summary>
	///Removes the given CQU_I19_INSURANCE
	///</summary>
	public void RemoveINSURANCE(CQU_I19_INSURANCE toRemove)
	{
		this.RemoveStructure("INSURANCE", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_INSURANCE at the given index
	///</summary>
	public void RemoveINSURANCEAt(int index)
	{
		this.RemoveRepetition("INSURANCE", index);
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_APPOINTMENT_HISTORY (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_APPOINTMENT_HISTORY GetAPPOINTMENT_HISTORY() {
	   CQU_I19_APPOINTMENT_HISTORY ret = null;
	   try {
	      ret = (CQU_I19_APPOINTMENT_HISTORY)this.GetStructure("APPOINTMENT_HISTORY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_APPOINTMENT_HISTORY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_APPOINTMENT_HISTORY GetAPPOINTMENT_HISTORY(int rep) { 
	   return (CQU_I19_APPOINTMENT_HISTORY)this.GetStructure("APPOINTMENT_HISTORY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_APPOINTMENT_HISTORY 
	 */ 
	public int APPOINTMENT_HISTORYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("APPOINTMENT_HISTORY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_APPOINTMENT_HISTORY results 
	 */ 
	public IEnumerable<CQU_I19_APPOINTMENT_HISTORY> APPOINTMENT_HISTORYs 
	{ 
		get
		{
			for (int rep = 0; rep < APPOINTMENT_HISTORYRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_APPOINTMENT_HISTORY)this.GetStructure("APPOINTMENT_HISTORY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_APPOINTMENT_HISTORY
	///</summary>
	public CQU_I19_APPOINTMENT_HISTORY AddAPPOINTMENT_HISTORY()
	{
		return this.AddStructure("APPOINTMENT_HISTORY") as CQU_I19_APPOINTMENT_HISTORY;
	}

	///<summary>
	///Removes the given CQU_I19_APPOINTMENT_HISTORY
	///</summary>
	public void RemoveAPPOINTMENT_HISTORY(CQU_I19_APPOINTMENT_HISTORY toRemove)
	{
		this.RemoveStructure("APPOINTMENT_HISTORY", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_APPOINTMENT_HISTORY at the given index
	///</summary>
	public void RemoveAPPOINTMENT_HISTORYAt(int index)
	{
		this.RemoveRepetition("APPOINTMENT_HISTORY", index);
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_CLINICAL_HISTORY (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_CLINICAL_HISTORY GetCLINICAL_HISTORY() {
	   CQU_I19_CLINICAL_HISTORY ret = null;
	   try {
	      ret = (CQU_I19_CLINICAL_HISTORY)this.GetStructure("CLINICAL_HISTORY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_CLINICAL_HISTORY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_CLINICAL_HISTORY GetCLINICAL_HISTORY(int rep) { 
	   return (CQU_I19_CLINICAL_HISTORY)this.GetStructure("CLINICAL_HISTORY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_CLINICAL_HISTORY 
	 */ 
	public int CLINICAL_HISTORYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLINICAL_HISTORY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_CLINICAL_HISTORY results 
	 */ 
	public IEnumerable<CQU_I19_CLINICAL_HISTORY> CLINICAL_HISTORYs 
	{ 
		get
		{
			for (int rep = 0; rep < CLINICAL_HISTORYRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_CLINICAL_HISTORY)this.GetStructure("CLINICAL_HISTORY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_CLINICAL_HISTORY
	///</summary>
	public CQU_I19_CLINICAL_HISTORY AddCLINICAL_HISTORY()
	{
		return this.AddStructure("CLINICAL_HISTORY") as CQU_I19_CLINICAL_HISTORY;
	}

	///<summary>
	///Removes the given CQU_I19_CLINICAL_HISTORY
	///</summary>
	public void RemoveCLINICAL_HISTORY(CQU_I19_CLINICAL_HISTORY toRemove)
	{
		this.RemoveStructure("CLINICAL_HISTORY", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_CLINICAL_HISTORY at the given index
	///</summary>
	public void RemoveCLINICAL_HISTORYAt(int index)
	{
		this.RemoveRepetition("CLINICAL_HISTORY", index);
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_PATIENT_VISITS (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_PATIENT_VISITS GetPATIENT_VISITS() {
	   CQU_I19_PATIENT_VISITS ret = null;
	   try {
	      ret = (CQU_I19_PATIENT_VISITS)this.GetStructure("PATIENT_VISITS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_PATIENT_VISITS
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_PATIENT_VISITS GetPATIENT_VISITS(int rep) { 
	   return (CQU_I19_PATIENT_VISITS)this.GetStructure("PATIENT_VISITS", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_PATIENT_VISITS 
	 */ 
	public int PATIENT_VISITSRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATIENT_VISITS").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_PATIENT_VISITS results 
	 */ 
	public IEnumerable<CQU_I19_PATIENT_VISITS> PATIENT_VISITSs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENT_VISITSRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_PATIENT_VISITS)this.GetStructure("PATIENT_VISITS", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_PATIENT_VISITS
	///</summary>
	public CQU_I19_PATIENT_VISITS AddPATIENT_VISITS()
	{
		return this.AddStructure("PATIENT_VISITS") as CQU_I19_PATIENT_VISITS;
	}

	///<summary>
	///Removes the given CQU_I19_PATIENT_VISITS
	///</summary>
	public void RemovePATIENT_VISITS(CQU_I19_PATIENT_VISITS toRemove)
	{
		this.RemoveStructure("PATIENT_VISITS", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_PATIENT_VISITS at the given index
	///</summary>
	public void RemovePATIENT_VISITSAt(int index)
	{
		this.RemoveRepetition("PATIENT_VISITS", index);
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_MEDICATION_HISTORY (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_MEDICATION_HISTORY GetMEDICATION_HISTORY() {
	   CQU_I19_MEDICATION_HISTORY ret = null;
	   try {
	      ret = (CQU_I19_MEDICATION_HISTORY)this.GetStructure("MEDICATION_HISTORY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_MEDICATION_HISTORY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_MEDICATION_HISTORY GetMEDICATION_HISTORY(int rep) { 
	   return (CQU_I19_MEDICATION_HISTORY)this.GetStructure("MEDICATION_HISTORY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_MEDICATION_HISTORY 
	 */ 
	public int MEDICATION_HISTORYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MEDICATION_HISTORY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_MEDICATION_HISTORY results 
	 */ 
	public IEnumerable<CQU_I19_MEDICATION_HISTORY> MEDICATION_HISTORYs 
	{ 
		get
		{
			for (int rep = 0; rep < MEDICATION_HISTORYRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_MEDICATION_HISTORY)this.GetStructure("MEDICATION_HISTORY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_MEDICATION_HISTORY
	///</summary>
	public CQU_I19_MEDICATION_HISTORY AddMEDICATION_HISTORY()
	{
		return this.AddStructure("MEDICATION_HISTORY") as CQU_I19_MEDICATION_HISTORY;
	}

	///<summary>
	///Removes the given CQU_I19_MEDICATION_HISTORY
	///</summary>
	public void RemoveMEDICATION_HISTORY(CQU_I19_MEDICATION_HISTORY toRemove)
	{
		this.RemoveStructure("MEDICATION_HISTORY", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_MEDICATION_HISTORY at the given index
	///</summary>
	public void RemoveMEDICATION_HISTORYAt(int index)
	{
		this.RemoveRepetition("MEDICATION_HISTORY", index);
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_PROBLEM (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_PROBLEM GetPROBLEM() {
	   CQU_I19_PROBLEM ret = null;
	   try {
	      ret = (CQU_I19_PROBLEM)this.GetStructure("PROBLEM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_PROBLEM
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_PROBLEM GetPROBLEM(int rep) { 
	   return (CQU_I19_PROBLEM)this.GetStructure("PROBLEM", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_PROBLEM 
	 */ 
	public int PROBLEMRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PROBLEM").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_PROBLEM results 
	 */ 
	public IEnumerable<CQU_I19_PROBLEM> PROBLEMs 
	{ 
		get
		{
			for (int rep = 0; rep < PROBLEMRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_PROBLEM)this.GetStructure("PROBLEM", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_PROBLEM
	///</summary>
	public CQU_I19_PROBLEM AddPROBLEM()
	{
		return this.AddStructure("PROBLEM") as CQU_I19_PROBLEM;
	}

	///<summary>
	///Removes the given CQU_I19_PROBLEM
	///</summary>
	public void RemovePROBLEM(CQU_I19_PROBLEM toRemove)
	{
		this.RemoveStructure("PROBLEM", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_PROBLEM at the given index
	///</summary>
	public void RemovePROBLEMAt(int index)
	{
		this.RemoveRepetition("PROBLEM", index);
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_GOAL (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_GOAL GetGOAL() {
	   CQU_I19_GOAL ret = null;
	   try {
	      ret = (CQU_I19_GOAL)this.GetStructure("GOAL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_GOAL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_GOAL GetGOAL(int rep) { 
	   return (CQU_I19_GOAL)this.GetStructure("GOAL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_GOAL 
	 */ 
	public int GOALRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("GOAL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_GOAL results 
	 */ 
	public IEnumerable<CQU_I19_GOAL> GOALs 
	{ 
		get
		{
			for (int rep = 0; rep < GOALRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_GOAL)this.GetStructure("GOAL", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_GOAL
	///</summary>
	public CQU_I19_GOAL AddGOAL()
	{
		return this.AddStructure("GOAL") as CQU_I19_GOAL;
	}

	///<summary>
	///Removes the given CQU_I19_GOAL
	///</summary>
	public void RemoveGOAL(CQU_I19_GOAL toRemove)
	{
		this.RemoveStructure("GOAL", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_GOAL at the given index
	///</summary>
	public void RemoveGOALAt(int index)
	{
		this.RemoveRepetition("GOAL", index);
	}

	///<summary>
	/// Returns  first repetition of CQU_I19_PATHWAY (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_PATHWAY GetPATHWAY() {
	   CQU_I19_PATHWAY ret = null;
	   try {
	      ret = (CQU_I19_PATHWAY)this.GetStructure("PATHWAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_PATHWAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_PATHWAY GetPATHWAY(int rep) { 
	   return (CQU_I19_PATHWAY)this.GetStructure("PATHWAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_PATHWAY 
	 */ 
	public int PATHWAYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATHWAY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CQU_I19_PATHWAY results 
	 */ 
	public IEnumerable<CQU_I19_PATHWAY> PATHWAYs 
	{ 
		get
		{
			for (int rep = 0; rep < PATHWAYRepetitionsUsed; rep++)
			{
				yield return (CQU_I19_PATHWAY)this.GetStructure("PATHWAY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CQU_I19_PATHWAY
	///</summary>
	public CQU_I19_PATHWAY AddPATHWAY()
	{
		return this.AddStructure("PATHWAY") as CQU_I19_PATHWAY;
	}

	///<summary>
	///Removes the given CQU_I19_PATHWAY
	///</summary>
	public void RemovePATHWAY(CQU_I19_PATHWAY toRemove)
	{
		this.RemoveStructure("PATHWAY", toRemove);
	}

	///<summary>
	///Removes the CQU_I19_PATHWAY at the given index
	///</summary>
	public void RemovePATHWAYAt(int index)
	{
		this.RemoveRepetition("PATHWAY", index);
	}

	///<summary>
	/// Returns  first repetition of REL (Clinical Relationship Segment) - creates it if necessary
	///</summary>
	public REL GetREL() {
	   REL ret = null;
	   try {
	      ret = (REL)this.GetStructure("REL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of REL
	/// * (Clinical Relationship Segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public REL GetREL(int rep) { 
	   return (REL)this.GetStructure("REL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of REL 
	 */ 
	public int RELRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("REL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the REL results 
	 */ 
	public IEnumerable<REL> RELs 
	{ 
		get
		{
			for (int rep = 0; rep < RELRepetitionsUsed; rep++)
			{
				yield return (REL)this.GetStructure("REL", rep);
			}
		}
	}

	///<summary>
	///Adds a new REL
	///</summary>
	public REL AddREL()
	{
		return this.AddStructure("REL") as REL;
	}

	///<summary>
	///Removes the given REL
	///</summary>
	public void RemoveREL(REL toRemove)
	{
		this.RemoveStructure("REL", toRemove);
	}

	///<summary>
	///Removes the REL at the given index
	///</summary>
	public void RemoveRELAt(int index)
	{
		this.RemoveRepetition("REL", index);
	}

}
}
