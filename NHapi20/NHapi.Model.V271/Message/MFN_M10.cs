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
/// Represents a MFN_M10 message structure (see chapter 8.8.5). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: MFI (Master File Identification) </li>
///<li>4: MFN_M10_MF_TEST_BATTERIES (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M10 : AbstractMessage  {

	///<summary> 
	/// Creates a new MFN_M10 Group with custom IModelClassFactory.
	///</summary>
	public MFN_M10(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new MFN_M10 Group with DefaultModelClassFactory. 
	///</summary> 
	public MFN_M10() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for MFN_M10.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFN_M10_MF_TEST_BATTERIES), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M10 - this is probably a bug in the source code generator.", e);
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
	/// Returns MFI (Master File Identification) - creates it if necessary
	///</summary>
	public MFI MFI { 
get{
	   MFI ret = null;
	   try {
	      ret = (MFI)this.GetStructure("MFI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of MFN_M10_MF_TEST_BATTERIES (a Group object) - creates it if necessary
	///</summary>
	public MFN_M10_MF_TEST_BATTERIES GetMF_TEST_BATTERIES() {
	   MFN_M10_MF_TEST_BATTERIES ret = null;
	   try {
	      ret = (MFN_M10_MF_TEST_BATTERIES)this.GetStructure("MF_TEST_BATTERIES");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M10_MF_TEST_BATTERIES
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M10_MF_TEST_BATTERIES GetMF_TEST_BATTERIES(int rep) { 
	   return (MFN_M10_MF_TEST_BATTERIES)this.GetStructure("MF_TEST_BATTERIES", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M10_MF_TEST_BATTERIES 
	 */ 
	public int MF_TEST_BATTERIESRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_TEST_BATTERIES").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFN_M10_MF_TEST_BATTERIES results 
	 */ 
	public IEnumerable<MFN_M10_MF_TEST_BATTERIES> MF_TEST_BATTERIESs 
	{ 
		get
		{
			for (int rep = 0; rep < MF_TEST_BATTERIESRepetitionsUsed; rep++)
			{
				yield return (MFN_M10_MF_TEST_BATTERIES)this.GetStructure("MF_TEST_BATTERIES", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFN_M10_MF_TEST_BATTERIES
	///</summary>
	public MFN_M10_MF_TEST_BATTERIES AddMF_TEST_BATTERIES()
	{
		return this.AddStructure("MF_TEST_BATTERIES") as MFN_M10_MF_TEST_BATTERIES;
	}

	///<summary>
	///Removes the given MFN_M10_MF_TEST_BATTERIES
	///</summary>
	public void RemoveMF_TEST_BATTERIES(MFN_M10_MF_TEST_BATTERIES toRemove)
	{
		this.RemoveStructure("MF_TEST_BATTERIES", toRemove);
	}

	///<summary>
	///Removes the MFN_M10_MF_TEST_BATTERIES at the given index
	///</summary>
	public void RemoveMF_TEST_BATTERIESAt(int index)
	{
		this.RemoveRepetition("MF_TEST_BATTERIES", index);
	}

}
}
