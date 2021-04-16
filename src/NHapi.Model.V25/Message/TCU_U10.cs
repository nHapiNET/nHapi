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
/// Represents a TCU_U10 message structure (see chapter 13.3.10). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: EQU (Equipment Detail) </li>
///<li>3: TCU_U10_TEST_CONFIGURATION (a Group object) repeating</li>
///<li>4: ROL (Role) optional </li>
///</ol>
///</summary>
[Serializable]
public class TCU_U10 : AbstractMessage  {

	///<summary> 
	/// Creates a new TCU_U10 Group with custom IModelClassFactory.
	///</summary>
	public TCU_U10(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new TCU_U10 Group with DefaultModelClassFactory. 
	///</summary> 
	public TCU_U10() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for TCU_U10.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(EQU), true, false);
	      this.add(typeof(TCU_U10_TEST_CONFIGURATION), true, true);
	      this.add(typeof(ROL), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating TCU_U10 - this is probably a bug in the source code generator.", e);
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
	/// Returns EQU (Equipment Detail) - creates it if necessary
	///</summary>
	public EQU EQU { 
get{
	   EQU ret = null;
	   try {
	      ret = (EQU)this.GetStructure("EQU");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of TCU_U10_TEST_CONFIGURATION (a Group object) - creates it if necessary
	///</summary>
	public TCU_U10_TEST_CONFIGURATION GetTEST_CONFIGURATION() {
	   TCU_U10_TEST_CONFIGURATION ret = null;
	   try {
	      ret = (TCU_U10_TEST_CONFIGURATION)this.GetStructure("TEST_CONFIGURATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of TCU_U10_TEST_CONFIGURATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public TCU_U10_TEST_CONFIGURATION GetTEST_CONFIGURATION(int rep) { 
	   return (TCU_U10_TEST_CONFIGURATION)this.GetStructure("TEST_CONFIGURATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of TCU_U10_TEST_CONFIGURATION 
	 */ 
	public int TEST_CONFIGURATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TEST_CONFIGURATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the TCU_U10_TEST_CONFIGURATION results 
	 */ 
	public IEnumerable<TCU_U10_TEST_CONFIGURATION> TEST_CONFIGURATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < TEST_CONFIGURATIONRepetitionsUsed; rep++)
			{
				yield return (TCU_U10_TEST_CONFIGURATION)this.GetStructure("TEST_CONFIGURATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new TCU_U10_TEST_CONFIGURATION
	///</summary>
	public TCU_U10_TEST_CONFIGURATION AddTEST_CONFIGURATION()
	{
		return this.AddStructure("TEST_CONFIGURATION") as TCU_U10_TEST_CONFIGURATION;
	}

	///<summary>
	///Removes the given TCU_U10_TEST_CONFIGURATION
	///</summary>
	public void RemoveTEST_CONFIGURATION(TCU_U10_TEST_CONFIGURATION toRemove)
	{
		this.RemoveStructure("TEST_CONFIGURATION", toRemove);
	}

	///<summary>
	///Removes the TCU_U10_TEST_CONFIGURATION at the given index
	///</summary>
	public void RemoveTEST_CONFIGURATIONAt(int index)
	{
		this.RemoveRepetition("TEST_CONFIGURATION", index);
	}

	///<summary>
	/// Returns ROL (Role) - creates it if necessary
	///</summary>
	public ROL ROL { 
get{
	   ROL ret = null;
	   try {
	      ret = (ROL)this.GetStructure("ROL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
