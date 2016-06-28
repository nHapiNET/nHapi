using System;
using NHapi.Base.Log;
using NHapi.Model.V28.Group;
using NHapi.Model.V28.Segment;
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

}
}
