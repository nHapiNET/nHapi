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
/// Represents a PMU_B01 message structure (see chapter 15.3.1). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: EVN (Event Type) </li>
///<li>4: STF (Staff Identification) </li>
///<li>5: PRA (Practitioner Detail) optional repeating</li>
///<li>6: ORG (Practitioner Organization Unit) optional repeating</li>
///<li>7: AFF (Professional Affiliation) optional repeating</li>
///<li>8: LAN (Language Detail) optional repeating</li>
///<li>9: EDU (Educational Detail) optional repeating</li>
///<li>10: CER (Certificate Detail) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class PMU_B01 : AbstractMessage  {

	///<summary> 
	/// Creates a new PMU_B01 Group with custom IModelClassFactory.
	///</summary>
	public PMU_B01(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new PMU_B01 Group with DefaultModelClassFactory. 
	///</summary> 
	public PMU_B01() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for PMU_B01.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(EVN), true, false);
	      this.add(typeof(STF), true, false);
	      this.add(typeof(PRA), false, true);
	      this.add(typeof(ORG), false, true);
	      this.add(typeof(AFF), false, true);
	      this.add(typeof(LAN), false, true);
	      this.add(typeof(EDU), false, true);
	      this.add(typeof(CER), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PMU_B01 - this is probably a bug in the source code generator.", e);
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
	/// Returns EVN (Event Type) - creates it if necessary
	///</summary>
	public EVN EVN { 
get{
	   EVN ret = null;
	   try {
	      ret = (EVN)this.GetStructure("EVN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns STF (Staff Identification) - creates it if necessary
	///</summary>
	public STF STF { 
get{
	   STF ret = null;
	   try {
	      ret = (STF)this.GetStructure("STF");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PRA (Practitioner Detail) - creates it if necessary
	///</summary>
	public PRA GetPRA() {
	   PRA ret = null;
	   try {
	      ret = (PRA)this.GetStructure("PRA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRA
	/// * (Practitioner Detail) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRA GetPRA(int rep) { 
	   return (PRA)this.GetStructure("PRA", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRA 
	 */ 
	public int PRARepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRA").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PRA results 
	 */ 
	public IEnumerable<PRA> PRAs 
	{ 
		get
		{
			for (int rep = 0; rep < PRARepetitionsUsed; rep++)
			{
				yield return (PRA)this.GetStructure("PRA", rep);
			}
		}
	}

	///<summary>
	///Adds a new PRA
	///</summary>
	public PRA AddPRA()
	{
		return this.AddStructure("PRA") as PRA;
	}

	///<summary>
	///Removes the given PRA
	///</summary>
	public void RemovePRA(PRA toRemove)
	{
		this.RemoveStructure("PRA", toRemove);
	}

	///<summary>
	///Removes the PRA at the given index
	///</summary>
	public void RemovePRAAt(int index)
	{
		this.RemoveRepetition("PRA", index);
	}

	///<summary>
	/// Returns  first repetition of ORG (Practitioner Organization Unit) - creates it if necessary
	///</summary>
	public ORG GetORG() {
	   ORG ret = null;
	   try {
	      ret = (ORG)this.GetStructure("ORG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORG
	/// * (Practitioner Organization Unit) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORG GetORG(int rep) { 
	   return (ORG)this.GetStructure("ORG", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORG 
	 */ 
	public int ORGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORG").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORG results 
	 */ 
	public IEnumerable<ORG> ORGs 
	{ 
		get
		{
			for (int rep = 0; rep < ORGRepetitionsUsed; rep++)
			{
				yield return (ORG)this.GetStructure("ORG", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORG
	///</summary>
	public ORG AddORG()
	{
		return this.AddStructure("ORG") as ORG;
	}

	///<summary>
	///Removes the given ORG
	///</summary>
	public void RemoveORG(ORG toRemove)
	{
		this.RemoveStructure("ORG", toRemove);
	}

	///<summary>
	///Removes the ORG at the given index
	///</summary>
	public void RemoveORGAt(int index)
	{
		this.RemoveRepetition("ORG", index);
	}

	///<summary>
	/// Returns  first repetition of AFF (Professional Affiliation) - creates it if necessary
	///</summary>
	public AFF GetAFF() {
	   AFF ret = null;
	   try {
	      ret = (AFF)this.GetStructure("AFF");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of AFF
	/// * (Professional Affiliation) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public AFF GetAFF(int rep) { 
	   return (AFF)this.GetStructure("AFF", rep);
	}

	/** 
	 * Returns the number of existing repetitions of AFF 
	 */ 
	public int AFFRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("AFF").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the AFF results 
	 */ 
	public IEnumerable<AFF> AFFs 
	{ 
		get
		{
			for (int rep = 0; rep < AFFRepetitionsUsed; rep++)
			{
				yield return (AFF)this.GetStructure("AFF", rep);
			}
		}
	}

	///<summary>
	///Adds a new AFF
	///</summary>
	public AFF AddAFF()
	{
		return this.AddStructure("AFF") as AFF;
	}

	///<summary>
	///Removes the given AFF
	///</summary>
	public void RemoveAFF(AFF toRemove)
	{
		this.RemoveStructure("AFF", toRemove);
	}

	///<summary>
	///Removes the AFF at the given index
	///</summary>
	public void RemoveAFFAt(int index)
	{
		this.RemoveRepetition("AFF", index);
	}

	///<summary>
	/// Returns  first repetition of LAN (Language Detail) - creates it if necessary
	///</summary>
	public LAN GetLAN() {
	   LAN ret = null;
	   try {
	      ret = (LAN)this.GetStructure("LAN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LAN
	/// * (Language Detail) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LAN GetLAN(int rep) { 
	   return (LAN)this.GetStructure("LAN", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LAN 
	 */ 
	public int LANRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LAN").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the LAN results 
	 */ 
	public IEnumerable<LAN> LANs 
	{ 
		get
		{
			for (int rep = 0; rep < LANRepetitionsUsed; rep++)
			{
				yield return (LAN)this.GetStructure("LAN", rep);
			}
		}
	}

	///<summary>
	///Adds a new LAN
	///</summary>
	public LAN AddLAN()
	{
		return this.AddStructure("LAN") as LAN;
	}

	///<summary>
	///Removes the given LAN
	///</summary>
	public void RemoveLAN(LAN toRemove)
	{
		this.RemoveStructure("LAN", toRemove);
	}

	///<summary>
	///Removes the LAN at the given index
	///</summary>
	public void RemoveLANAt(int index)
	{
		this.RemoveRepetition("LAN", index);
	}

	///<summary>
	/// Returns  first repetition of EDU (Educational Detail) - creates it if necessary
	///</summary>
	public EDU GetEDU() {
	   EDU ret = null;
	   try {
	      ret = (EDU)this.GetStructure("EDU");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EDU
	/// * (Educational Detail) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EDU GetEDU(int rep) { 
	   return (EDU)this.GetStructure("EDU", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EDU 
	 */ 
	public int EDURepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("EDU").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EDU results 
	 */ 
	public IEnumerable<EDU> EDUs 
	{ 
		get
		{
			for (int rep = 0; rep < EDURepetitionsUsed; rep++)
			{
				yield return (EDU)this.GetStructure("EDU", rep);
			}
		}
	}

	///<summary>
	///Adds a new EDU
	///</summary>
	public EDU AddEDU()
	{
		return this.AddStructure("EDU") as EDU;
	}

	///<summary>
	///Removes the given EDU
	///</summary>
	public void RemoveEDU(EDU toRemove)
	{
		this.RemoveStructure("EDU", toRemove);
	}

	///<summary>
	///Removes the EDU at the given index
	///</summary>
	public void RemoveEDUAt(int index)
	{
		this.RemoveRepetition("EDU", index);
	}

	///<summary>
	/// Returns  first repetition of CER (Certificate Detail) - creates it if necessary
	///</summary>
	public CER GetCER() {
	   CER ret = null;
	   try {
	      ret = (CER)this.GetStructure("CER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CER
	/// * (Certificate Detail) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CER GetCER(int rep) { 
	   return (CER)this.GetStructure("CER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CER 
	 */ 
	public int CERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CER results 
	 */ 
	public IEnumerable<CER> CERs 
	{ 
		get
		{
			for (int rep = 0; rep < CERRepetitionsUsed; rep++)
			{
				yield return (CER)this.GetStructure("CER", rep);
			}
		}
	}

	///<summary>
	///Adds a new CER
	///</summary>
	public CER AddCER()
	{
		return this.AddStructure("CER") as CER;
	}

	///<summary>
	///Removes the given CER
	///</summary>
	public void RemoveCER(CER toRemove)
	{
		this.RemoveStructure("CER", toRemove);
	}

	///<summary>
	///Removes the CER at the given index
	///</summary>
	public void RemoveCERAt(int index)
	{
		this.RemoveRepetition("CER", index);
	}

}
}
