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
/// Represents a DEO_O45 message structure (see chapter 4.16.12). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: DEO_O45_DONOR (a Group object) optional </li>
///<li>4: DEO_O45_DONOR_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class DEO_O45 : AbstractMessage  {

	///<summary> 
	/// Creates a new DEO_O45 Group with custom IModelClassFactory.
	///</summary>
	public DEO_O45(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new DEO_O45 Group with DefaultModelClassFactory. 
	///</summary> 
	public DEO_O45() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for DEO_O45.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(DEO_O45_DONOR), false, false);
	      this.add(typeof(DEO_O45_DONOR_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating DEO_O45 - this is probably a bug in the source code generator.", e);
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
	/// Returns DEO_O45_DONOR (a Group object) - creates it if necessary
	///</summary>
	public DEO_O45_DONOR DONOR { 
get{
	   DEO_O45_DONOR ret = null;
	   try {
	      ret = (DEO_O45_DONOR)this.GetStructure("DONOR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of DEO_O45_DONOR_ORDER (a Group object) - creates it if necessary
	///</summary>
	public DEO_O45_DONOR_ORDER GetDONOR_ORDER() {
	   DEO_O45_DONOR_ORDER ret = null;
	   try {
	      ret = (DEO_O45_DONOR_ORDER)this.GetStructure("DONOR_ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DEO_O45_DONOR_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DEO_O45_DONOR_ORDER GetDONOR_ORDER(int rep) { 
	   return (DEO_O45_DONOR_ORDER)this.GetStructure("DONOR_ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DEO_O45_DONOR_ORDER 
	 */ 
	public int DONOR_ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DONOR_ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DEO_O45_DONOR_ORDER results 
	 */ 
	public IEnumerable<DEO_O45_DONOR_ORDER> DONOR_ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < DONOR_ORDERRepetitionsUsed; rep++)
			{
				yield return (DEO_O45_DONOR_ORDER)this.GetStructure("DONOR_ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new DEO_O45_DONOR_ORDER
	///</summary>
	public DEO_O45_DONOR_ORDER AddDONOR_ORDER()
	{
		return this.AddStructure("DONOR_ORDER") as DEO_O45_DONOR_ORDER;
	}

	///<summary>
	///Removes the given DEO_O45_DONOR_ORDER
	///</summary>
	public void RemoveDONOR_ORDER(DEO_O45_DONOR_ORDER toRemove)
	{
		this.RemoveStructure("DONOR_ORDER", toRemove);
	}

	///<summary>
	///Removes the DEO_O45_DONOR_ORDER at the given index
	///</summary>
	public void RemoveDONOR_ORDERAt(int index)
	{
		this.RemoveRepetition("DONOR_ORDER", index);
	}

}
}
