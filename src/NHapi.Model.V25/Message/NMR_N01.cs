using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V25.Group;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Message

{
///<summary>
/// Represents a NMR_N01 message structure (see chapter 14.3.1). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: MSA (Message Acknowledgment) </li>
///<li>3: ERR (Error) optional repeating</li>
///<li>4: QRD (Original-Style Query Definition) optional </li>
///<li>5: NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class NMR_N01 : AbstractMessage  {

	///<summary> 
	/// Creates a new NMR_N01 Group with custom IModelClassFactory.
	///</summary>
	public NMR_N01(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new NMR_N01 Group with DefaultModelClassFactory. 
	///</summary> 
	public NMR_N01() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for NMR_N01.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(ERR), false, true);
	      this.add(typeof(QRD), false, false);
	      this.add(typeof(NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating NMR_N01 - this is probably a bug in the source code generator.", e);
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
	/// Returns QRD (Original-Style Query Definition) - creates it if necessary
	///</summary>
	public QRD QRD { 
get{
	   QRD ret = null;
	   try {
	      ret = (QRD)this.GetStructure("QRD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT (a Group object) - creates it if necessary
	///</summary>
	public NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT GetCLOCK_AND_STATS_WITH_NOTES_ALT() {
	   NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT ret = null;
	   try {
	      ret = (NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES_ALT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT GetCLOCK_AND_STATS_WITH_NOTES_ALT(int rep) { 
	   return (NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES_ALT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT 
	 */ 
	public int CLOCK_AND_STATS_WITH_NOTES_ALTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLOCK_AND_STATS_WITH_NOTES_ALT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT results 
	 */ 
	public IEnumerable<NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT> CLOCK_AND_STATS_WITH_NOTES_ALTs 
	{ 
		get
		{
			for (int rep = 0; rep < CLOCK_AND_STATS_WITH_NOTES_ALTRepetitionsUsed; rep++)
			{
				yield return (NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES_ALT", rep);
			}
		}
	}

	///<summary>
	///Adds a new NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT
	///</summary>
	public NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT AddCLOCK_AND_STATS_WITH_NOTES_ALT()
	{
		return this.AddStructure("CLOCK_AND_STATS_WITH_NOTES_ALT") as NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT;
	}

	///<summary>
	///Removes the given NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT
	///</summary>
	public void RemoveCLOCK_AND_STATS_WITH_NOTES_ALT(NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT toRemove)
	{
		this.RemoveStructure("CLOCK_AND_STATS_WITH_NOTES_ALT", toRemove);
	}

	///<summary>
	///Removes the NMR_N01_CLOCK_AND_STATS_WITH_NOTES_ALT at the given index
	///</summary>
	public void RemoveCLOCK_AND_STATS_WITH_NOTES_ALTAt(int index)
	{
		this.RemoveRepetition("CLOCK_AND_STATS_WITH_NOTES_ALT", index);
	}

}
}
