using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V271.Group;
using NHapi.Model.V271.Segment;
using NHapi.Model.V271.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V271.Message

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

	/** 
	 * Enumerate over the UAC results 
	 */ 
	public IEnumerable<UAC> UACs 
	{ 
		get
		{
			for (int rep = 0; rep < UACRepetitionsUsed; rep++)
			{
				yield return (UAC)this.GetStructure("UAC", rep);
			}
		}
	}

	///<summary>
	///Adds a new UAC
	///</summary>
	public UAC AddUAC()
	{
		return this.AddStructure("UAC") as UAC;
	}

	///<summary>
	///Removes the given UAC
	///</summary>
	public void RemoveUAC(UAC toRemove)
	{
		this.RemoveStructure("UAC", toRemove);
	}

	///<summary>
	///Removes the UAC at the given index
	///</summary>
	public void RemoveUACAt(int index)
	{
		this.RemoveRepetition("UAC", index);
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

	/** 
	 * Enumerate over the EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO results 
	 */ 
	public IEnumerable<EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO> PAYMENT_REMITTANCE_DETAIL_INFOs 
	{ 
		get
		{
			for (int rep = 0; rep < PAYMENT_REMITTANCE_DETAIL_INFORepetitionsUsed; rep++)
			{
				yield return (EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO)this.GetStructure("PAYMENT_REMITTANCE_DETAIL_INFO", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO
	///</summary>
	public EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO AddPAYMENT_REMITTANCE_DETAIL_INFO()
	{
		return this.AddStructure("PAYMENT_REMITTANCE_DETAIL_INFO") as EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO;
	}

	///<summary>
	///Removes the given EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO
	///</summary>
	public void RemovePAYMENT_REMITTANCE_DETAIL_INFO(EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO toRemove)
	{
		this.RemoveStructure("PAYMENT_REMITTANCE_DETAIL_INFO", toRemove);
	}

	///<summary>
	///Removes the EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO at the given index
	///</summary>
	public void RemovePAYMENT_REMITTANCE_DETAIL_INFOAt(int index)
	{
		this.RemoveRepetition("PAYMENT_REMITTANCE_DETAIL_INFO", index);
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

	/** 
	 * Enumerate over the EHC_E15_ADJUSTMENT_PAYEE results 
	 */ 
	public IEnumerable<EHC_E15_ADJUSTMENT_PAYEE> ADJUSTMENT_PAYEEs 
	{ 
		get
		{
			for (int rep = 0; rep < ADJUSTMENT_PAYEERepetitionsUsed; rep++)
			{
				yield return (EHC_E15_ADJUSTMENT_PAYEE)this.GetStructure("ADJUSTMENT_PAYEE", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E15_ADJUSTMENT_PAYEE
	///</summary>
	public EHC_E15_ADJUSTMENT_PAYEE AddADJUSTMENT_PAYEE()
	{
		return this.AddStructure("ADJUSTMENT_PAYEE") as EHC_E15_ADJUSTMENT_PAYEE;
	}

	///<summary>
	///Removes the given EHC_E15_ADJUSTMENT_PAYEE
	///</summary>
	public void RemoveADJUSTMENT_PAYEE(EHC_E15_ADJUSTMENT_PAYEE toRemove)
	{
		this.RemoveStructure("ADJUSTMENT_PAYEE", toRemove);
	}

	///<summary>
	///Removes the EHC_E15_ADJUSTMENT_PAYEE at the given index
	///</summary>
	public void RemoveADJUSTMENT_PAYEEAt(int index)
	{
		this.RemoveRepetition("ADJUSTMENT_PAYEE", index);
	}

}
}
