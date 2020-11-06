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
/// Represents a CCQ_I19 message structure (see chapter 11.7.1). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: RF1 (Referral Information) </li>
///<li>4: CCQ_I19_PROVIDER_CONTACT (a Group object) optional repeating</li>
///<li>5: REL (Clinical Relationship Segment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCQ_I19 : AbstractMessage  {

	///<summary> 
	/// Creates a new CCQ_I19 Group with custom IModelClassFactory.
	///</summary>
	public CCQ_I19(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new CCQ_I19 Group with DefaultModelClassFactory. 
	///</summary> 
	public CCQ_I19() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for CCQ_I19.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(RF1), true, false);
	      this.add(typeof(CCQ_I19_PROVIDER_CONTACT), false, true);
	      this.add(typeof(REL), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCQ_I19 - this is probably a bug in the source code generator.", e);
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
	/// Returns RF1 (Referral Information) - creates it if necessary
	///</summary>
	public RF1 RF1 { 
get{
	   RF1 ret = null;
	   try {
	      ret = (RF1)this.GetStructure("RF1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CCQ_I19_PROVIDER_CONTACT (a Group object) - creates it if necessary
	///</summary>
	public CCQ_I19_PROVIDER_CONTACT GetPROVIDER_CONTACT() {
	   CCQ_I19_PROVIDER_CONTACT ret = null;
	   try {
	      ret = (CCQ_I19_PROVIDER_CONTACT)this.GetStructure("PROVIDER_CONTACT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCQ_I19_PROVIDER_CONTACT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCQ_I19_PROVIDER_CONTACT GetPROVIDER_CONTACT(int rep) { 
	   return (CCQ_I19_PROVIDER_CONTACT)this.GetStructure("PROVIDER_CONTACT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCQ_I19_PROVIDER_CONTACT 
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

	/** 
	 * Enumerate over the CCQ_I19_PROVIDER_CONTACT results 
	 */ 
	public IEnumerable<CCQ_I19_PROVIDER_CONTACT> PROVIDER_CONTACTs 
	{ 
		get
		{
			for (int rep = 0; rep < PROVIDER_CONTACTRepetitionsUsed; rep++)
			{
				yield return (CCQ_I19_PROVIDER_CONTACT)this.GetStructure("PROVIDER_CONTACT", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCQ_I19_PROVIDER_CONTACT
	///</summary>
	public CCQ_I19_PROVIDER_CONTACT AddPROVIDER_CONTACT()
	{
		return this.AddStructure("PROVIDER_CONTACT") as CCQ_I19_PROVIDER_CONTACT;
	}

	///<summary>
	///Removes the given CCQ_I19_PROVIDER_CONTACT
	///</summary>
	public void RemovePROVIDER_CONTACT(CCQ_I19_PROVIDER_CONTACT toRemove)
	{
		this.RemoveStructure("PROVIDER_CONTACT", toRemove);
	}

	///<summary>
	///Removes the CCQ_I19_PROVIDER_CONTACT at the given index
	///</summary>
	public void RemovePROVIDER_CONTACTAt(int index)
	{
		this.RemoveRepetition("PROVIDER_CONTACT", index);
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

	/** 
	 * Enumerate over the REL results 
	 */ 
	public IEnumerable<REL> RELs 
	{ 
		get
		{
			for (int rep = 0; rep < RELRepetitionsUsed; rep++)
			{
				yield return (REL)this.GetStructure("REL", rep);
			}
		}
	}

	///<summary>
	///Adds a new REL
	///</summary>
	public REL AddREL()
	{
		return this.AddStructure("REL") as REL;
	}

	///<summary>
	///Removes the given REL
	///</summary>
	public void RemoveREL(REL toRemove)
	{
		this.RemoveStructure("REL", toRemove);
	}

	///<summary>
	///Removes the REL at the given index
	///</summary>
	public void RemoveRELAt(int index)
	{
		this.RemoveRepetition("REL", index);
	}

}
}
