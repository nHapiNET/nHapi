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
/// Represents a CCR_I16 message structure (see chapter 11.6.2). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: RF1 (Referral Information) repeating</li>
///<li>4: CCR_I16_PROVIDER_CONTACT (a Group object) repeating</li>
///<li>5: CCR_I16_CLINICAL_ORDER (a Group object) optional repeating</li>
///<li>6: CCR_I16_PATIENT (a Group object) repeating</li>
///<li>7: NK1 (Next of Kin / Associated Parties) optional repeating</li>
///<li>8: CCR_I16_INSURANCE (a Group object) optional repeating</li>
///<li>9: CCR_I16_APPOINTMENT_HISTORY (a Group object) optional repeating</li>
///<li>10: CCR_I16_CLINICAL_HISTORY (a Group object) optional repeating</li>
///<li>11: CCR_I16_PATIENT_VISITS (a Group object) repeating</li>
///<li>12: CCR_I16_MEDICATION_HISTORY (a Group object) optional repeating</li>
///<li>13: CCR_I16_PROBLEM (a Group object) optional repeating</li>
///<li>14: CCR_I16_GOAL (a Group object) optional repeating</li>
///<li>15: CCR_I16_PATHWAY (a Group object) optional repeating</li>
///<li>16: REL (Clinical Relationship Segment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCR_I16 : AbstractMessage  {

	///<summary> 
	/// Creates a new CCR_I16 Group with custom IModelClassFactory.
	///</summary>
	public CCR_I16(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new CCR_I16 Group with DefaultModelClassFactory. 
	///</summary> 
	public CCR_I16() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for CCR_I16.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(RF1), true, true);
	      this.add(typeof(CCR_I16_PROVIDER_CONTACT), true, true);
	      this.add(typeof(CCR_I16_CLINICAL_ORDER), false, true);
	      this.add(typeof(CCR_I16_PATIENT), true, true);
	      this.add(typeof(NK1), false, true);
	      this.add(typeof(CCR_I16_INSURANCE), false, true);
	      this.add(typeof(CCR_I16_APPOINTMENT_HISTORY), false, true);
	      this.add(typeof(CCR_I16_CLINICAL_HISTORY), false, true);
	      this.add(typeof(CCR_I16_PATIENT_VISITS), true, true);
	      this.add(typeof(CCR_I16_MEDICATION_HISTORY), false, true);
	      this.add(typeof(CCR_I16_PROBLEM), false, true);
	      this.add(typeof(CCR_I16_GOAL), false, true);
	      this.add(typeof(CCR_I16_PATHWAY), false, true);
	      this.add(typeof(REL), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCR_I16 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of RF1 (Referral Information) - creates it if necessary
	///</summary>
	public RF1 GetRF1() {
	   RF1 ret = null;
	   try {
	      ret = (RF1)this.GetStructure("RF1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RF1
	/// * (Referral Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RF1 GetRF1(int rep) { 
	   return (RF1)this.GetStructure("RF1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RF1 
	 */ 
	public int RF1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RF1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RF1 results 
	 */ 
	public IEnumerable<RF1> RF1s 
	{ 
		get
		{
			for (int rep = 0; rep < RF1RepetitionsUsed; rep++)
			{
				yield return (RF1)this.GetStructure("RF1", rep);
			}
		}
	}

	///<summary>
	///Adds a new RF1
	///</summary>
	public RF1 AddRF1()
	{
		return this.AddStructure("RF1") as RF1;
	}

	///<summary>
	///Removes the given RF1
	///</summary>
	public void RemoveRF1(RF1 toRemove)
	{
		this.RemoveStructure("RF1", toRemove);
	}

	///<summary>
	///Removes the RF1 at the given index
	///</summary>
	public void RemoveRF1At(int index)
	{
		this.RemoveRepetition("RF1", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_PROVIDER_CONTACT (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_PROVIDER_CONTACT GetPROVIDER_CONTACT() {
	   CCR_I16_PROVIDER_CONTACT ret = null;
	   try {
	      ret = (CCR_I16_PROVIDER_CONTACT)this.GetStructure("PROVIDER_CONTACT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_PROVIDER_CONTACT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_PROVIDER_CONTACT GetPROVIDER_CONTACT(int rep) { 
	   return (CCR_I16_PROVIDER_CONTACT)this.GetStructure("PROVIDER_CONTACT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_PROVIDER_CONTACT 
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
	 * Enumerate over the CCR_I16_PROVIDER_CONTACT results 
	 */ 
	public IEnumerable<CCR_I16_PROVIDER_CONTACT> PROVIDER_CONTACTs 
	{ 
		get
		{
			for (int rep = 0; rep < PROVIDER_CONTACTRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_PROVIDER_CONTACT)this.GetStructure("PROVIDER_CONTACT", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_PROVIDER_CONTACT
	///</summary>
	public CCR_I16_PROVIDER_CONTACT AddPROVIDER_CONTACT()
	{
		return this.AddStructure("PROVIDER_CONTACT") as CCR_I16_PROVIDER_CONTACT;
	}

	///<summary>
	///Removes the given CCR_I16_PROVIDER_CONTACT
	///</summary>
	public void RemovePROVIDER_CONTACT(CCR_I16_PROVIDER_CONTACT toRemove)
	{
		this.RemoveStructure("PROVIDER_CONTACT", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_PROVIDER_CONTACT at the given index
	///</summary>
	public void RemovePROVIDER_CONTACTAt(int index)
	{
		this.RemoveRepetition("PROVIDER_CONTACT", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_CLINICAL_ORDER (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_CLINICAL_ORDER GetCLINICAL_ORDER() {
	   CCR_I16_CLINICAL_ORDER ret = null;
	   try {
	      ret = (CCR_I16_CLINICAL_ORDER)this.GetStructure("CLINICAL_ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_CLINICAL_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_CLINICAL_ORDER GetCLINICAL_ORDER(int rep) { 
	   return (CCR_I16_CLINICAL_ORDER)this.GetStructure("CLINICAL_ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_CLINICAL_ORDER 
	 */ 
	public int CLINICAL_ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLINICAL_ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CCR_I16_CLINICAL_ORDER results 
	 */ 
	public IEnumerable<CCR_I16_CLINICAL_ORDER> CLINICAL_ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < CLINICAL_ORDERRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_CLINICAL_ORDER)this.GetStructure("CLINICAL_ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_CLINICAL_ORDER
	///</summary>
	public CCR_I16_CLINICAL_ORDER AddCLINICAL_ORDER()
	{
		return this.AddStructure("CLINICAL_ORDER") as CCR_I16_CLINICAL_ORDER;
	}

	///<summary>
	///Removes the given CCR_I16_CLINICAL_ORDER
	///</summary>
	public void RemoveCLINICAL_ORDER(CCR_I16_CLINICAL_ORDER toRemove)
	{
		this.RemoveStructure("CLINICAL_ORDER", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_CLINICAL_ORDER at the given index
	///</summary>
	public void RemoveCLINICAL_ORDERAt(int index)
	{
		this.RemoveRepetition("CLINICAL_ORDER", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_PATIENT GetPATIENT() {
	   CCR_I16_PATIENT ret = null;
	   try {
	      ret = (CCR_I16_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_PATIENT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_PATIENT GetPATIENT(int rep) { 
	   return (CCR_I16_PATIENT)this.GetStructure("PATIENT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_PATIENT 
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
	 * Enumerate over the CCR_I16_PATIENT results 
	 */ 
	public IEnumerable<CCR_I16_PATIENT> PATIENTs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENTRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_PATIENT)this.GetStructure("PATIENT", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_PATIENT
	///</summary>
	public CCR_I16_PATIENT AddPATIENT()
	{
		return this.AddStructure("PATIENT") as CCR_I16_PATIENT;
	}

	///<summary>
	///Removes the given CCR_I16_PATIENT
	///</summary>
	public void RemovePATIENT(CCR_I16_PATIENT toRemove)
	{
		this.RemoveStructure("PATIENT", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_PATIENT at the given index
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
	/// Returns  first repetition of CCR_I16_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_INSURANCE GetINSURANCE() {
	   CCR_I16_INSURANCE ret = null;
	   try {
	      ret = (CCR_I16_INSURANCE)this.GetStructure("INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_INSURANCE GetINSURANCE(int rep) { 
	   return (CCR_I16_INSURANCE)this.GetStructure("INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_INSURANCE 
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
	 * Enumerate over the CCR_I16_INSURANCE results 
	 */ 
	public IEnumerable<CCR_I16_INSURANCE> INSURANCEs 
	{ 
		get
		{
			for (int rep = 0; rep < INSURANCERepetitionsUsed; rep++)
			{
				yield return (CCR_I16_INSURANCE)this.GetStructure("INSURANCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_INSURANCE
	///</summary>
	public CCR_I16_INSURANCE AddINSURANCE()
	{
		return this.AddStructure("INSURANCE") as CCR_I16_INSURANCE;
	}

	///<summary>
	///Removes the given CCR_I16_INSURANCE
	///</summary>
	public void RemoveINSURANCE(CCR_I16_INSURANCE toRemove)
	{
		this.RemoveStructure("INSURANCE", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_INSURANCE at the given index
	///</summary>
	public void RemoveINSURANCEAt(int index)
	{
		this.RemoveRepetition("INSURANCE", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_APPOINTMENT_HISTORY (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_APPOINTMENT_HISTORY GetAPPOINTMENT_HISTORY() {
	   CCR_I16_APPOINTMENT_HISTORY ret = null;
	   try {
	      ret = (CCR_I16_APPOINTMENT_HISTORY)this.GetStructure("APPOINTMENT_HISTORY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_APPOINTMENT_HISTORY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_APPOINTMENT_HISTORY GetAPPOINTMENT_HISTORY(int rep) { 
	   return (CCR_I16_APPOINTMENT_HISTORY)this.GetStructure("APPOINTMENT_HISTORY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_APPOINTMENT_HISTORY 
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
	 * Enumerate over the CCR_I16_APPOINTMENT_HISTORY results 
	 */ 
	public IEnumerable<CCR_I16_APPOINTMENT_HISTORY> APPOINTMENT_HISTORYs 
	{ 
		get
		{
			for (int rep = 0; rep < APPOINTMENT_HISTORYRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_APPOINTMENT_HISTORY)this.GetStructure("APPOINTMENT_HISTORY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_APPOINTMENT_HISTORY
	///</summary>
	public CCR_I16_APPOINTMENT_HISTORY AddAPPOINTMENT_HISTORY()
	{
		return this.AddStructure("APPOINTMENT_HISTORY") as CCR_I16_APPOINTMENT_HISTORY;
	}

	///<summary>
	///Removes the given CCR_I16_APPOINTMENT_HISTORY
	///</summary>
	public void RemoveAPPOINTMENT_HISTORY(CCR_I16_APPOINTMENT_HISTORY toRemove)
	{
		this.RemoveStructure("APPOINTMENT_HISTORY", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_APPOINTMENT_HISTORY at the given index
	///</summary>
	public void RemoveAPPOINTMENT_HISTORYAt(int index)
	{
		this.RemoveRepetition("APPOINTMENT_HISTORY", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_CLINICAL_HISTORY (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_CLINICAL_HISTORY GetCLINICAL_HISTORY() {
	   CCR_I16_CLINICAL_HISTORY ret = null;
	   try {
	      ret = (CCR_I16_CLINICAL_HISTORY)this.GetStructure("CLINICAL_HISTORY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_CLINICAL_HISTORY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_CLINICAL_HISTORY GetCLINICAL_HISTORY(int rep) { 
	   return (CCR_I16_CLINICAL_HISTORY)this.GetStructure("CLINICAL_HISTORY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_CLINICAL_HISTORY 
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
	 * Enumerate over the CCR_I16_CLINICAL_HISTORY results 
	 */ 
	public IEnumerable<CCR_I16_CLINICAL_HISTORY> CLINICAL_HISTORYs 
	{ 
		get
		{
			for (int rep = 0; rep < CLINICAL_HISTORYRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_CLINICAL_HISTORY)this.GetStructure("CLINICAL_HISTORY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_CLINICAL_HISTORY
	///</summary>
	public CCR_I16_CLINICAL_HISTORY AddCLINICAL_HISTORY()
	{
		return this.AddStructure("CLINICAL_HISTORY") as CCR_I16_CLINICAL_HISTORY;
	}

	///<summary>
	///Removes the given CCR_I16_CLINICAL_HISTORY
	///</summary>
	public void RemoveCLINICAL_HISTORY(CCR_I16_CLINICAL_HISTORY toRemove)
	{
		this.RemoveStructure("CLINICAL_HISTORY", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_CLINICAL_HISTORY at the given index
	///</summary>
	public void RemoveCLINICAL_HISTORYAt(int index)
	{
		this.RemoveRepetition("CLINICAL_HISTORY", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_PATIENT_VISITS (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_PATIENT_VISITS GetPATIENT_VISITS() {
	   CCR_I16_PATIENT_VISITS ret = null;
	   try {
	      ret = (CCR_I16_PATIENT_VISITS)this.GetStructure("PATIENT_VISITS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_PATIENT_VISITS
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_PATIENT_VISITS GetPATIENT_VISITS(int rep) { 
	   return (CCR_I16_PATIENT_VISITS)this.GetStructure("PATIENT_VISITS", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_PATIENT_VISITS 
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
	 * Enumerate over the CCR_I16_PATIENT_VISITS results 
	 */ 
	public IEnumerable<CCR_I16_PATIENT_VISITS> PATIENT_VISITSs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENT_VISITSRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_PATIENT_VISITS)this.GetStructure("PATIENT_VISITS", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_PATIENT_VISITS
	///</summary>
	public CCR_I16_PATIENT_VISITS AddPATIENT_VISITS()
	{
		return this.AddStructure("PATIENT_VISITS") as CCR_I16_PATIENT_VISITS;
	}

	///<summary>
	///Removes the given CCR_I16_PATIENT_VISITS
	///</summary>
	public void RemovePATIENT_VISITS(CCR_I16_PATIENT_VISITS toRemove)
	{
		this.RemoveStructure("PATIENT_VISITS", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_PATIENT_VISITS at the given index
	///</summary>
	public void RemovePATIENT_VISITSAt(int index)
	{
		this.RemoveRepetition("PATIENT_VISITS", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_MEDICATION_HISTORY (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_MEDICATION_HISTORY GetMEDICATION_HISTORY() {
	   CCR_I16_MEDICATION_HISTORY ret = null;
	   try {
	      ret = (CCR_I16_MEDICATION_HISTORY)this.GetStructure("MEDICATION_HISTORY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_MEDICATION_HISTORY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_MEDICATION_HISTORY GetMEDICATION_HISTORY(int rep) { 
	   return (CCR_I16_MEDICATION_HISTORY)this.GetStructure("MEDICATION_HISTORY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_MEDICATION_HISTORY 
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
	 * Enumerate over the CCR_I16_MEDICATION_HISTORY results 
	 */ 
	public IEnumerable<CCR_I16_MEDICATION_HISTORY> MEDICATION_HISTORYs 
	{ 
		get
		{
			for (int rep = 0; rep < MEDICATION_HISTORYRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_MEDICATION_HISTORY)this.GetStructure("MEDICATION_HISTORY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_MEDICATION_HISTORY
	///</summary>
	public CCR_I16_MEDICATION_HISTORY AddMEDICATION_HISTORY()
	{
		return this.AddStructure("MEDICATION_HISTORY") as CCR_I16_MEDICATION_HISTORY;
	}

	///<summary>
	///Removes the given CCR_I16_MEDICATION_HISTORY
	///</summary>
	public void RemoveMEDICATION_HISTORY(CCR_I16_MEDICATION_HISTORY toRemove)
	{
		this.RemoveStructure("MEDICATION_HISTORY", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_MEDICATION_HISTORY at the given index
	///</summary>
	public void RemoveMEDICATION_HISTORYAt(int index)
	{
		this.RemoveRepetition("MEDICATION_HISTORY", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_PROBLEM (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_PROBLEM GetPROBLEM() {
	   CCR_I16_PROBLEM ret = null;
	   try {
	      ret = (CCR_I16_PROBLEM)this.GetStructure("PROBLEM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_PROBLEM
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_PROBLEM GetPROBLEM(int rep) { 
	   return (CCR_I16_PROBLEM)this.GetStructure("PROBLEM", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_PROBLEM 
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
	 * Enumerate over the CCR_I16_PROBLEM results 
	 */ 
	public IEnumerable<CCR_I16_PROBLEM> PROBLEMs 
	{ 
		get
		{
			for (int rep = 0; rep < PROBLEMRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_PROBLEM)this.GetStructure("PROBLEM", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_PROBLEM
	///</summary>
	public CCR_I16_PROBLEM AddPROBLEM()
	{
		return this.AddStructure("PROBLEM") as CCR_I16_PROBLEM;
	}

	///<summary>
	///Removes the given CCR_I16_PROBLEM
	///</summary>
	public void RemovePROBLEM(CCR_I16_PROBLEM toRemove)
	{
		this.RemoveStructure("PROBLEM", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_PROBLEM at the given index
	///</summary>
	public void RemovePROBLEMAt(int index)
	{
		this.RemoveRepetition("PROBLEM", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_GOAL (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_GOAL GetGOAL() {
	   CCR_I16_GOAL ret = null;
	   try {
	      ret = (CCR_I16_GOAL)this.GetStructure("GOAL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_GOAL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_GOAL GetGOAL(int rep) { 
	   return (CCR_I16_GOAL)this.GetStructure("GOAL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_GOAL 
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
	 * Enumerate over the CCR_I16_GOAL results 
	 */ 
	public IEnumerable<CCR_I16_GOAL> GOALs 
	{ 
		get
		{
			for (int rep = 0; rep < GOALRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_GOAL)this.GetStructure("GOAL", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_GOAL
	///</summary>
	public CCR_I16_GOAL AddGOAL()
	{
		return this.AddStructure("GOAL") as CCR_I16_GOAL;
	}

	///<summary>
	///Removes the given CCR_I16_GOAL
	///</summary>
	public void RemoveGOAL(CCR_I16_GOAL toRemove)
	{
		this.RemoveStructure("GOAL", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_GOAL at the given index
	///</summary>
	public void RemoveGOALAt(int index)
	{
		this.RemoveRepetition("GOAL", index);
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_PATHWAY (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_PATHWAY GetPATHWAY() {
	   CCR_I16_PATHWAY ret = null;
	   try {
	      ret = (CCR_I16_PATHWAY)this.GetStructure("PATHWAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_PATHWAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_PATHWAY GetPATHWAY(int rep) { 
	   return (CCR_I16_PATHWAY)this.GetStructure("PATHWAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_PATHWAY 
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
	 * Enumerate over the CCR_I16_PATHWAY results 
	 */ 
	public IEnumerable<CCR_I16_PATHWAY> PATHWAYs 
	{ 
		get
		{
			for (int rep = 0; rep < PATHWAYRepetitionsUsed; rep++)
			{
				yield return (CCR_I16_PATHWAY)this.GetStructure("PATHWAY", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCR_I16_PATHWAY
	///</summary>
	public CCR_I16_PATHWAY AddPATHWAY()
	{
		return this.AddStructure("PATHWAY") as CCR_I16_PATHWAY;
	}

	///<summary>
	///Removes the given CCR_I16_PATHWAY
	///</summary>
	public void RemovePATHWAY(CCR_I16_PATHWAY toRemove)
	{
		this.RemoveStructure("PATHWAY", toRemove);
	}

	///<summary>
	///Removes the CCR_I16_PATHWAY at the given index
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
