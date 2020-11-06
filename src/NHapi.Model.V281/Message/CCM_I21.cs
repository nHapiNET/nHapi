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
/// Represents a CCM_I21 message structure (see chapter 11.6.1). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: PID (Patient Identification) </li>
///<li>4: PD1 (Patient Additional Demographic) optional </li>
///<li>5: NK1 (Next of Kin / Associated Parties) optional repeating</li>
///<li>6: CCM_I21_INSURANCE (a Group object) optional repeating</li>
///<li>7: CCM_I21_APPOINTMENT_HISTORY (a Group object) optional repeating</li>
///<li>8: CCM_I21_CLINICAL_HISTORY (a Group object) optional repeating</li>
///<li>9: CCM_I21_PATIENT_VISITS (a Group object) repeating</li>
///<li>10: CCM_I21_MEDICATION_HISTORY (a Group object) optional repeating</li>
///<li>11: CCM_I21_PROBLEM (a Group object) optional repeating</li>
///<li>12: CCM_I21_GOAL (a Group object) optional repeating</li>
///<li>13: CCM_I21_PATHWAY (a Group object) optional repeating</li>
///<li>14: REL (Clinical Relationship Segment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCM_I21 : AbstractMessage  {

	///<summary> 
	/// Creates a new CCM_I21 Group with custom IModelClassFactory.
	///</summary>
	public CCM_I21(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new CCM_I21 Group with DefaultModelClassFactory. 
	///</summary> 
	public CCM_I21() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for CCM_I21.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PD1), false, false);
	      this.add(typeof(NK1), false, true);
	      this.add(typeof(CCM_I21_INSURANCE), false, true);
	      this.add(typeof(CCM_I21_APPOINTMENT_HISTORY), false, true);
	      this.add(typeof(CCM_I21_CLINICAL_HISTORY), false, true);
	      this.add(typeof(CCM_I21_PATIENT_VISITS), true, true);
	      this.add(typeof(CCM_I21_MEDICATION_HISTORY), false, true);
	      this.add(typeof(CCM_I21_PROBLEM), false, true);
	      this.add(typeof(CCM_I21_GOAL), false, true);
	      this.add(typeof(CCM_I21_PATHWAY), false, true);
	      this.add(typeof(REL), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCM_I21 - this is probably a bug in the source code generator.", e);
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
	/// Returns PID (Patient Identification) - creates it if necessary
	///</summary>
	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PD1 (Patient Additional Demographic) - creates it if necessary
	///</summary>
	public PD1 PD1 { 
get{
	   PD1 ret = null;
	   try {
	      ret = (PD1)this.GetStructure("PD1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
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
	/// Returns  first repetition of CCM_I21_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_INSURANCE GetINSURANCE() {
	   CCM_I21_INSURANCE ret = null;
	   try {
	      ret = (CCM_I21_INSURANCE)this.GetStructure("INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_INSURANCE GetINSURANCE(int rep) { 
	   return (CCM_I21_INSURANCE)this.GetStructure("INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_INSURANCE 
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
	 * Enumerate over the CCM_I21_INSURANCE results 
	 */ 
	public IEnumerable<CCM_I21_INSURANCE> INSURANCEs 
	{ 
		get
		{
			for (int rep = 0; rep < INSURANCERepetitionsUsed; rep++)
			{
				yield return (CCM_I21_INSURANCE)this.GetStructure("INSURANCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCM_I21_INSURANCE
	///</summary>
	public CCM_I21_INSURANCE AddINSURANCE()
	{
		return this.AddStructure("INSURANCE") as CCM_I21_INSURANCE;
	}

	///<summary>
	///Removes the given CCM_I21_INSURANCE
	///</summary>
	public void RemoveINSURANCE(CCM_I21_INSURANCE toRemove)
	{
		this.RemoveStructure("INSURANCE", toRemove);
	}

	///<summary>
	///Removes the CCM_I21_INSURANCE at the given index
	///</summary>
	public void RemoveINSURANCEAt(int index)
	{
		this.RemoveRepetition("INSURANCE", index);
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_APPOINTMENT_HISTORY (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_APPOINTMENT_HISTORY GetAPPOINTMENT_HISTORY() {
	   CCM_I21_APPOINTMENT_HISTORY ret = null;
	   try {
	      ret = (CCM_I21_APPOINTMENT_HISTORY)this.GetStructure("APPOINTMENT_HISTORY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_APPOINTMENT_HISTORY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_APPOINTMENT_HISTORY GetAPPOINTMENT_HISTORY(int rep) { 
	   return (CCM_I21_APPOINTMENT_HISTORY)this.GetStructure("APPOINTMENT_HISTORY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_APPOINTMENT_HISTORY 
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
	 * Enumerate over the CCM_I21_APPOINTMENT_HISTORY results 
	 */ 
	public IEnumerable<CCM_I21_APPOINTMENT_HISTORY> APPOINTMENT_HISTORYs 
	{ 
		get
		{
			for (int rep = 0; rep < APPOINTMENT_HISTORYRepetitionsUsed; rep++)
			{
				yield return (CCM_I21_APPOINTMENT_HISTORY)this.GetStructure("APPOINTMENT_HISTORY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCM_I21_APPOINTMENT_HISTORY
	///</summary>
	public CCM_I21_APPOINTMENT_HISTORY AddAPPOINTMENT_HISTORY()
	{
		return this.AddStructure("APPOINTMENT_HISTORY") as CCM_I21_APPOINTMENT_HISTORY;
	}

	///<summary>
	///Removes the given CCM_I21_APPOINTMENT_HISTORY
	///</summary>
	public void RemoveAPPOINTMENT_HISTORY(CCM_I21_APPOINTMENT_HISTORY toRemove)
	{
		this.RemoveStructure("APPOINTMENT_HISTORY", toRemove);
	}

	///<summary>
	///Removes the CCM_I21_APPOINTMENT_HISTORY at the given index
	///</summary>
	public void RemoveAPPOINTMENT_HISTORYAt(int index)
	{
		this.RemoveRepetition("APPOINTMENT_HISTORY", index);
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_CLINICAL_HISTORY (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_CLINICAL_HISTORY GetCLINICAL_HISTORY() {
	   CCM_I21_CLINICAL_HISTORY ret = null;
	   try {
	      ret = (CCM_I21_CLINICAL_HISTORY)this.GetStructure("CLINICAL_HISTORY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_CLINICAL_HISTORY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_CLINICAL_HISTORY GetCLINICAL_HISTORY(int rep) { 
	   return (CCM_I21_CLINICAL_HISTORY)this.GetStructure("CLINICAL_HISTORY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_CLINICAL_HISTORY 
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
	 * Enumerate over the CCM_I21_CLINICAL_HISTORY results 
	 */ 
	public IEnumerable<CCM_I21_CLINICAL_HISTORY> CLINICAL_HISTORYs 
	{ 
		get
		{
			for (int rep = 0; rep < CLINICAL_HISTORYRepetitionsUsed; rep++)
			{
				yield return (CCM_I21_CLINICAL_HISTORY)this.GetStructure("CLINICAL_HISTORY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCM_I21_CLINICAL_HISTORY
	///</summary>
	public CCM_I21_CLINICAL_HISTORY AddCLINICAL_HISTORY()
	{
		return this.AddStructure("CLINICAL_HISTORY") as CCM_I21_CLINICAL_HISTORY;
	}

	///<summary>
	///Removes the given CCM_I21_CLINICAL_HISTORY
	///</summary>
	public void RemoveCLINICAL_HISTORY(CCM_I21_CLINICAL_HISTORY toRemove)
	{
		this.RemoveStructure("CLINICAL_HISTORY", toRemove);
	}

	///<summary>
	///Removes the CCM_I21_CLINICAL_HISTORY at the given index
	///</summary>
	public void RemoveCLINICAL_HISTORYAt(int index)
	{
		this.RemoveRepetition("CLINICAL_HISTORY", index);
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_PATIENT_VISITS (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_PATIENT_VISITS GetPATIENT_VISITS() {
	   CCM_I21_PATIENT_VISITS ret = null;
	   try {
	      ret = (CCM_I21_PATIENT_VISITS)this.GetStructure("PATIENT_VISITS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_PATIENT_VISITS
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_PATIENT_VISITS GetPATIENT_VISITS(int rep) { 
	   return (CCM_I21_PATIENT_VISITS)this.GetStructure("PATIENT_VISITS", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_PATIENT_VISITS 
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
	 * Enumerate over the CCM_I21_PATIENT_VISITS results 
	 */ 
	public IEnumerable<CCM_I21_PATIENT_VISITS> PATIENT_VISITSs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENT_VISITSRepetitionsUsed; rep++)
			{
				yield return (CCM_I21_PATIENT_VISITS)this.GetStructure("PATIENT_VISITS", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCM_I21_PATIENT_VISITS
	///</summary>
	public CCM_I21_PATIENT_VISITS AddPATIENT_VISITS()
	{
		return this.AddStructure("PATIENT_VISITS") as CCM_I21_PATIENT_VISITS;
	}

	///<summary>
	///Removes the given CCM_I21_PATIENT_VISITS
	///</summary>
	public void RemovePATIENT_VISITS(CCM_I21_PATIENT_VISITS toRemove)
	{
		this.RemoveStructure("PATIENT_VISITS", toRemove);
	}

	///<summary>
	///Removes the CCM_I21_PATIENT_VISITS at the given index
	///</summary>
	public void RemovePATIENT_VISITSAt(int index)
	{
		this.RemoveRepetition("PATIENT_VISITS", index);
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_MEDICATION_HISTORY (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_MEDICATION_HISTORY GetMEDICATION_HISTORY() {
	   CCM_I21_MEDICATION_HISTORY ret = null;
	   try {
	      ret = (CCM_I21_MEDICATION_HISTORY)this.GetStructure("MEDICATION_HISTORY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_MEDICATION_HISTORY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_MEDICATION_HISTORY GetMEDICATION_HISTORY(int rep) { 
	   return (CCM_I21_MEDICATION_HISTORY)this.GetStructure("MEDICATION_HISTORY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_MEDICATION_HISTORY 
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
	 * Enumerate over the CCM_I21_MEDICATION_HISTORY results 
	 */ 
	public IEnumerable<CCM_I21_MEDICATION_HISTORY> MEDICATION_HISTORYs 
	{ 
		get
		{
			for (int rep = 0; rep < MEDICATION_HISTORYRepetitionsUsed; rep++)
			{
				yield return (CCM_I21_MEDICATION_HISTORY)this.GetStructure("MEDICATION_HISTORY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCM_I21_MEDICATION_HISTORY
	///</summary>
	public CCM_I21_MEDICATION_HISTORY AddMEDICATION_HISTORY()
	{
		return this.AddStructure("MEDICATION_HISTORY") as CCM_I21_MEDICATION_HISTORY;
	}

	///<summary>
	///Removes the given CCM_I21_MEDICATION_HISTORY
	///</summary>
	public void RemoveMEDICATION_HISTORY(CCM_I21_MEDICATION_HISTORY toRemove)
	{
		this.RemoveStructure("MEDICATION_HISTORY", toRemove);
	}

	///<summary>
	///Removes the CCM_I21_MEDICATION_HISTORY at the given index
	///</summary>
	public void RemoveMEDICATION_HISTORYAt(int index)
	{
		this.RemoveRepetition("MEDICATION_HISTORY", index);
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_PROBLEM (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_PROBLEM GetPROBLEM() {
	   CCM_I21_PROBLEM ret = null;
	   try {
	      ret = (CCM_I21_PROBLEM)this.GetStructure("PROBLEM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_PROBLEM
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_PROBLEM GetPROBLEM(int rep) { 
	   return (CCM_I21_PROBLEM)this.GetStructure("PROBLEM", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_PROBLEM 
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
	 * Enumerate over the CCM_I21_PROBLEM results 
	 */ 
	public IEnumerable<CCM_I21_PROBLEM> PROBLEMs 
	{ 
		get
		{
			for (int rep = 0; rep < PROBLEMRepetitionsUsed; rep++)
			{
				yield return (CCM_I21_PROBLEM)this.GetStructure("PROBLEM", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCM_I21_PROBLEM
	///</summary>
	public CCM_I21_PROBLEM AddPROBLEM()
	{
		return this.AddStructure("PROBLEM") as CCM_I21_PROBLEM;
	}

	///<summary>
	///Removes the given CCM_I21_PROBLEM
	///</summary>
	public void RemovePROBLEM(CCM_I21_PROBLEM toRemove)
	{
		this.RemoveStructure("PROBLEM", toRemove);
	}

	///<summary>
	///Removes the CCM_I21_PROBLEM at the given index
	///</summary>
	public void RemovePROBLEMAt(int index)
	{
		this.RemoveRepetition("PROBLEM", index);
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_GOAL (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_GOAL GetGOAL() {
	   CCM_I21_GOAL ret = null;
	   try {
	      ret = (CCM_I21_GOAL)this.GetStructure("GOAL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_GOAL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_GOAL GetGOAL(int rep) { 
	   return (CCM_I21_GOAL)this.GetStructure("GOAL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_GOAL 
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
	 * Enumerate over the CCM_I21_GOAL results 
	 */ 
	public IEnumerable<CCM_I21_GOAL> GOALs 
	{ 
		get
		{
			for (int rep = 0; rep < GOALRepetitionsUsed; rep++)
			{
				yield return (CCM_I21_GOAL)this.GetStructure("GOAL", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCM_I21_GOAL
	///</summary>
	public CCM_I21_GOAL AddGOAL()
	{
		return this.AddStructure("GOAL") as CCM_I21_GOAL;
	}

	///<summary>
	///Removes the given CCM_I21_GOAL
	///</summary>
	public void RemoveGOAL(CCM_I21_GOAL toRemove)
	{
		this.RemoveStructure("GOAL", toRemove);
	}

	///<summary>
	///Removes the CCM_I21_GOAL at the given index
	///</summary>
	public void RemoveGOALAt(int index)
	{
		this.RemoveRepetition("GOAL", index);
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_PATHWAY (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_PATHWAY GetPATHWAY() {
	   CCM_I21_PATHWAY ret = null;
	   try {
	      ret = (CCM_I21_PATHWAY)this.GetStructure("PATHWAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_PATHWAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_PATHWAY GetPATHWAY(int rep) { 
	   return (CCM_I21_PATHWAY)this.GetStructure("PATHWAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_PATHWAY 
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
	 * Enumerate over the CCM_I21_PATHWAY results 
	 */ 
	public IEnumerable<CCM_I21_PATHWAY> PATHWAYs 
	{ 
		get
		{
			for (int rep = 0; rep < PATHWAYRepetitionsUsed; rep++)
			{
				yield return (CCM_I21_PATHWAY)this.GetStructure("PATHWAY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCM_I21_PATHWAY
	///</summary>
	public CCM_I21_PATHWAY AddPATHWAY()
	{
		return this.AddStructure("PATHWAY") as CCM_I21_PATHWAY;
	}

	///<summary>
	///Removes the given CCM_I21_PATHWAY
	///</summary>
	public void RemovePATHWAY(CCM_I21_PATHWAY toRemove)
	{
		this.RemoveStructure("PATHWAY", toRemove);
	}

	///<summary>
	///Removes the CCM_I21_PATHWAY at the given index
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
