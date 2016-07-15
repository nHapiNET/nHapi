using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V26.Group;
using NHapi.Model.V26.Segment;
using NHapi.Model.V26.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V26.Message

{
///<summary>
/// Represents a EHC_E21 message structure (see chapter 16.3.11). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional repeating</li>
///<li>3: IVC (Invoice Segment) </li>
///<li>4: EHC_E21_PSL_ITEM_INFO (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E21 : AbstractMessage  {

	///<summary> 
	/// Creates a new EHC_E21 Group with custom IModelClassFactory.
	///</summary>
	public EHC_E21(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new EHC_E21 Group with DefaultModelClassFactory. 
	///</summary> 
	public EHC_E21() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for EHC_E21.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, true);
	      this.add(typeof(IVC), true, false);
	      this.add(typeof(EHC_E21_PSL_ITEM_INFO), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E21 - this is probably a bug in the source code generator.", e);
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
	/// Returns IVC (Invoice Segment) - creates it if necessary
	///</summary>
	public IVC IVC { 
get{
	   IVC ret = null;
	   try {
	      ret = (IVC)this.GetStructure("IVC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of EHC_E21_PSL_ITEM_INFO (a Group object) - creates it if necessary
	///</summary>
	public EHC_E21_PSL_ITEM_INFO GetPSL_ITEM_INFO() {
	   EHC_E21_PSL_ITEM_INFO ret = null;
	   try {
	      ret = (EHC_E21_PSL_ITEM_INFO)this.GetStructure("PSL_ITEM_INFO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E21_PSL_ITEM_INFO
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E21_PSL_ITEM_INFO GetPSL_ITEM_INFO(int rep) { 
	   return (EHC_E21_PSL_ITEM_INFO)this.GetStructure("PSL_ITEM_INFO", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E21_PSL_ITEM_INFO 
	 */ 
	public int PSL_ITEM_INFORepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PSL_ITEM_INFO").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EHC_E21_PSL_ITEM_INFO results 
	 */ 
	public IEnumerable<EHC_E21_PSL_ITEM_INFO> PSL_ITEM_INFOs 
	{ 
		get
		{
			for (int rep = 0; rep < PSL_ITEM_INFORepetitionsUsed; rep++)
			{
				yield return (EHC_E21_PSL_ITEM_INFO)this.GetStructure("PSL_ITEM_INFO", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E21_PSL_ITEM_INFO
	///</summary>
	public EHC_E21_PSL_ITEM_INFO AddPSL_ITEM_INFO()
	{
		return this.AddStructure("PSL_ITEM_INFO") as EHC_E21_PSL_ITEM_INFO;
	}

	///<summary>
	///Removes the given EHC_E21_PSL_ITEM_INFO
	///</summary>
	public void RemovePSL_ITEM_INFO(EHC_E21_PSL_ITEM_INFO toRemove)
	{
		this.RemoveStructure("PSL_ITEM_INFO", toRemove);
	}

	///<summary>
	///Removes the EHC_E21_PSL_ITEM_INFO at the given index
	///</summary>
	public void RemovePSL_ITEM_INFOAt(int index)
	{
		this.RemoveRepetition("PSL_ITEM_INFO", index);
	}

}
}
