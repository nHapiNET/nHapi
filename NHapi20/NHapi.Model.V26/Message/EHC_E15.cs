using System;
using NHapi.Base.Log;
using NHapi.Model.V26.Group;
using NHapi.Model.V26.Segment;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V26.Message

{
///<summary>
/// Represents a EHC_E15 message structure (see chapter 16.3.9). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional repeating</li>
///<li>3: PMT (Payment Information) </li>
///<li>4: PYE (Payee Information) </li>
///<li>5: EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO (a Group object) optional repeating</li>
///<li>6: EHC_E15_ADJUSTMENT_PAYEE (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E15 : AbstractMessage  {

	///<summary> 
	/// Creates a new EHC_E15 Group with custom IModelClassFactory.
	///</summary>
	public EHC_E15(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new EHC_E15 Group with DefaultModelClassFactory. 
	///</summary> 
	public EHC_E15() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for EHC_E15.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, true);
	      this.add(typeof(PMT), true, false);
	      this.add(typeof(PYE), true, false);
	      this.add(typeof(EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO), false, true);
	      this.add(typeof(EHC_E15_ADJUSTMENT_PAYEE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E15 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of UAC (User Authentication Credential Segment) - creates it if necessary
	///</summary>
	public UAC GetUAC() {
	   UAC ret = null;
	   try {
	      ret = (UAC)this.GetStructure("UAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of UAC
	/// * (User Authentication Credential Segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public UAC GetUAC(int rep) { 
	   return (UAC)this.GetStructure("UAC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of UAC 
	 */ 
	public int UACRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("UAC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns PMT (Payment Information) - creates it if necessary
	///</summary>
	public PMT PMT { 
get{
	   PMT ret = null;
	   try {
	      ret = (PMT)this.GetStructure("PMT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PYE (Payee Information) - creates it if necessary
	///</summary>
	public PYE PYE { 
get{
	   PYE ret = null;
	   try {
	      ret = (PYE)this.GetStructure("PYE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO (a Group object) - creates it if necessary
	///</summary>
	public EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO GetPAYMENT_REMITTANCE_DETAIL_INFO() {
	   EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO ret = null;
	   try {
	      ret = (EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO)this.GetStructure("PAYMENT_REMITTANCE_DETAIL_INFO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO GetPAYMENT_REMITTANCE_DETAIL_INFO(int rep) { 
	   return (EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO)this.GetStructure("PAYMENT_REMITTANCE_DETAIL_INFO", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO 
	 */ 
	public int PAYMENT_REMITTANCE_DETAIL_INFORepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PAYMENT_REMITTANCE_DETAIL_INFO").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of EHC_E15_ADJUSTMENT_PAYEE (a Group object) - creates it if necessary
	///</summary>
	public EHC_E15_ADJUSTMENT_PAYEE GetADJUSTMENT_PAYEE() {
	   EHC_E15_ADJUSTMENT_PAYEE ret = null;
	   try {
	      ret = (EHC_E15_ADJUSTMENT_PAYEE)this.GetStructure("ADJUSTMENT_PAYEE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E15_ADJUSTMENT_PAYEE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E15_ADJUSTMENT_PAYEE GetADJUSTMENT_PAYEE(int rep) { 
	   return (EHC_E15_ADJUSTMENT_PAYEE)this.GetStructure("ADJUSTMENT_PAYEE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E15_ADJUSTMENT_PAYEE 
	 */ 
	public int ADJUSTMENT_PAYEERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ADJUSTMENT_PAYEE").Length; 
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
