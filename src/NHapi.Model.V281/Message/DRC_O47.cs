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
/// Represents a DRC_O47 message structure (see chapter 4.16.14). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: DRC_O47_DONOR (a Group object) optional </li>
///<li>4: DRC_O47_OBRNTE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class DRC_O47 : AbstractMessage  {

	///<summary> 
	/// Creates a new DRC_O47 Group with custom IModelClassFactory.
	///</summary>
	public DRC_O47(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new DRC_O47 Group with DefaultModelClassFactory. 
	///</summary> 
	public DRC_O47() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for DRC_O47.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(DRC_O47_DONOR), false, false);
	      this.add(typeof(DRC_O47_OBRNTE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating DRC_O47 - this is probably a bug in the source code generator.", e);
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
	/// Returns DRC_O47_DONOR (a Group object) - creates it if necessary
	///</summary>
	public DRC_O47_DONOR DONOR { 
get{
	   DRC_O47_DONOR ret = null;
	   try {
	      ret = (DRC_O47_DONOR)this.GetStructure("DONOR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of DRC_O47_OBRNTE (a Group object) - creates it if necessary
	///</summary>
	public DRC_O47_OBRNTE GetOBRNTE() {
	   DRC_O47_OBRNTE ret = null;
	   try {
	      ret = (DRC_O47_OBRNTE)this.GetStructure("OBRNTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DRC_O47_OBRNTE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DRC_O47_OBRNTE GetOBRNTE(int rep) { 
	   return (DRC_O47_OBRNTE)this.GetStructure("OBRNTE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DRC_O47_OBRNTE 
	 */ 
	public int OBRNTERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBRNTE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DRC_O47_OBRNTE results 
	 */ 
	public IEnumerable<DRC_O47_OBRNTE> OBRNTEs 
	{ 
		get
		{
			for (int rep = 0; rep < OBRNTERepetitionsUsed; rep++)
			{
				yield return (DRC_O47_OBRNTE)this.GetStructure("OBRNTE", rep);
			}
		}
	}

	///<summary>
	///Adds a new DRC_O47_OBRNTE
	///</summary>
	public DRC_O47_OBRNTE AddOBRNTE()
	{
		return this.AddStructure("OBRNTE") as DRC_O47_OBRNTE;
	}

	///<summary>
	///Removes the given DRC_O47_OBRNTE
	///</summary>
	public void RemoveOBRNTE(DRC_O47_OBRNTE toRemove)
	{
		this.RemoveStructure("OBRNTE", toRemove);
	}

	///<summary>
	///Removes the DRC_O47_OBRNTE at the given index
	///</summary>
	public void RemoveOBRNTEAt(int index)
	{
		this.RemoveRepetition("OBRNTE", index);
	}

}
}
