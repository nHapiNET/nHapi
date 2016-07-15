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
/// Represents a EHC_E20 message structure (see chapter 16.3.10). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional repeating</li>
///<li>3: IVC (Invoice Segment) </li>
///<li>4: CTD (Contact Data) repeating</li>
///<li>5: LOC (Location Identification) optional repeating</li>
///<li>6: ROL (Role) optional repeating</li>
///<li>7: EHC_E20_PAT_INFO (a Group object) repeating</li>
///<li>8: EHC_E20_PSL_ITEM_INFO (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E20 : AbstractMessage  {

	///<summary> 
	/// Creates a new EHC_E20 Group with custom IModelClassFactory.
	///</summary>
	public EHC_E20(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new EHC_E20 Group with DefaultModelClassFactory. 
	///</summary> 
	public EHC_E20() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for EHC_E20.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, true);
	      this.add(typeof(IVC), true, false);
	      this.add(typeof(CTD), true, true);
	      this.add(typeof(LOC), false, true);
	      this.add(typeof(ROL), false, true);
	      this.add(typeof(EHC_E20_PAT_INFO), true, true);
	      this.add(typeof(EHC_E20_PSL_ITEM_INFO), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E20 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of CTD (Contact Data) - creates it if necessary
	///</summary>
	public CTD GetCTD() {
	   CTD ret = null;
	   try {
	      ret = (CTD)this.GetStructure("CTD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CTD
	/// * (Contact Data) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CTD GetCTD(int rep) { 
	   return (CTD)this.GetStructure("CTD", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CTD 
	 */ 
	public int CTDRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CTD").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CTD results 
	 */ 
	public IEnumerable<CTD> CTDs 
	{ 
		get
		{
			for (int rep = 0; rep < CTDRepetitionsUsed; rep++)
			{
				yield return (CTD)this.GetStructure("CTD", rep);
			}
		}
	}

	///<summary>
	///Adds a new CTD
	///</summary>
	public CTD AddCTD()
	{
		return this.AddStructure("CTD") as CTD;
	}

	///<summary>
	///Removes the given CTD
	///</summary>
	public void RemoveCTD(CTD toRemove)
	{
		this.RemoveStructure("CTD", toRemove);
	}

	///<summary>
	///Removes the CTD at the given index
	///</summary>
	public void RemoveCTDAt(int index)
	{
		this.RemoveRepetition("CTD", index);
	}

	///<summary>
	/// Returns  first repetition of LOC (Location Identification) - creates it if necessary
	///</summary>
	public LOC GetLOC() {
	   LOC ret = null;
	   try {
	      ret = (LOC)this.GetStructure("LOC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LOC
	/// * (Location Identification) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LOC GetLOC(int rep) { 
	   return (LOC)this.GetStructure("LOC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LOC 
	 */ 
	public int LOCRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LOC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the LOC results 
	 */ 
	public IEnumerable<LOC> LOCs 
	{ 
		get
		{
			for (int rep = 0; rep < LOCRepetitionsUsed; rep++)
			{
				yield return (LOC)this.GetStructure("LOC", rep);
			}
		}
	}

	///<summary>
	///Adds a new LOC
	///</summary>
	public LOC AddLOC()
	{
		return this.AddStructure("LOC") as LOC;
	}

	///<summary>
	///Removes the given LOC
	///</summary>
	public void RemoveLOC(LOC toRemove)
	{
		this.RemoveStructure("LOC", toRemove);
	}

	///<summary>
	///Removes the LOC at the given index
	///</summary>
	public void RemoveLOCAt(int index)
	{
		this.RemoveRepetition("LOC", index);
	}

	///<summary>
	/// Returns  first repetition of ROL (Role) - creates it if necessary
	///</summary>
	public ROL GetROL() {
	   ROL ret = null;
	   try {
	      ret = (ROL)this.GetStructure("ROL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ROL
	/// * (Role) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ROL GetROL(int rep) { 
	   return (ROL)this.GetStructure("ROL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ROL 
	 */ 
	public int ROLRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ROL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ROL results 
	 */ 
	public IEnumerable<ROL> ROLs 
	{ 
		get
		{
			for (int rep = 0; rep < ROLRepetitionsUsed; rep++)
			{
				yield return (ROL)this.GetStructure("ROL", rep);
			}
		}
	}

	///<summary>
	///Adds a new ROL
	///</summary>
	public ROL AddROL()
	{
		return this.AddStructure("ROL") as ROL;
	}

	///<summary>
	///Removes the given ROL
	///</summary>
	public void RemoveROL(ROL toRemove)
	{
		this.RemoveStructure("ROL", toRemove);
	}

	///<summary>
	///Removes the ROL at the given index
	///</summary>
	public void RemoveROLAt(int index)
	{
		this.RemoveRepetition("ROL", index);
	}

	///<summary>
	/// Returns  first repetition of EHC_E20_PAT_INFO (a Group object) - creates it if necessary
	///</summary>
	public EHC_E20_PAT_INFO GetPAT_INFO() {
	   EHC_E20_PAT_INFO ret = null;
	   try {
	      ret = (EHC_E20_PAT_INFO)this.GetStructure("PAT_INFO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E20_PAT_INFO
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E20_PAT_INFO GetPAT_INFO(int rep) { 
	   return (EHC_E20_PAT_INFO)this.GetStructure("PAT_INFO", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E20_PAT_INFO 
	 */ 
	public int PAT_INFORepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PAT_INFO").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EHC_E20_PAT_INFO results 
	 */ 
	public IEnumerable<EHC_E20_PAT_INFO> PAT_INFOs 
	{ 
		get
		{
			for (int rep = 0; rep < PAT_INFORepetitionsUsed; rep++)
			{
				yield return (EHC_E20_PAT_INFO)this.GetStructure("PAT_INFO", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E20_PAT_INFO
	///</summary>
	public EHC_E20_PAT_INFO AddPAT_INFO()
	{
		return this.AddStructure("PAT_INFO") as EHC_E20_PAT_INFO;
	}

	///<summary>
	///Removes the given EHC_E20_PAT_INFO
	///</summary>
	public void RemovePAT_INFO(EHC_E20_PAT_INFO toRemove)
	{
		this.RemoveStructure("PAT_INFO", toRemove);
	}

	///<summary>
	///Removes the EHC_E20_PAT_INFO at the given index
	///</summary>
	public void RemovePAT_INFOAt(int index)
	{
		this.RemoveRepetition("PAT_INFO", index);
	}

	///<summary>
	/// Returns  first repetition of EHC_E20_PSL_ITEM_INFO (a Group object) - creates it if necessary
	///</summary>
	public EHC_E20_PSL_ITEM_INFO GetPSL_ITEM_INFO() {
	   EHC_E20_PSL_ITEM_INFO ret = null;
	   try {
	      ret = (EHC_E20_PSL_ITEM_INFO)this.GetStructure("PSL_ITEM_INFO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E20_PSL_ITEM_INFO
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E20_PSL_ITEM_INFO GetPSL_ITEM_INFO(int rep) { 
	   return (EHC_E20_PSL_ITEM_INFO)this.GetStructure("PSL_ITEM_INFO", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E20_PSL_ITEM_INFO 
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
	 * Enumerate over the EHC_E20_PSL_ITEM_INFO results 
	 */ 
	public IEnumerable<EHC_E20_PSL_ITEM_INFO> PSL_ITEM_INFOs 
	{ 
		get
		{
			for (int rep = 0; rep < PSL_ITEM_INFORepetitionsUsed; rep++)
			{
				yield return (EHC_E20_PSL_ITEM_INFO)this.GetStructure("PSL_ITEM_INFO", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E20_PSL_ITEM_INFO
	///</summary>
	public EHC_E20_PSL_ITEM_INFO AddPSL_ITEM_INFO()
	{
		return this.AddStructure("PSL_ITEM_INFO") as EHC_E20_PSL_ITEM_INFO;
	}

	///<summary>
	///Removes the given EHC_E20_PSL_ITEM_INFO
	///</summary>
	public void RemovePSL_ITEM_INFO(EHC_E20_PSL_ITEM_INFO toRemove)
	{
		this.RemoveStructure("PSL_ITEM_INFO", toRemove);
	}

	///<summary>
	///Removes the EHC_E20_PSL_ITEM_INFO at the given index
	///</summary>
	public void RemovePSL_ITEM_INFOAt(int index)
	{
		this.RemoveRepetition("PSL_ITEM_INFO", index);
	}

}
}
