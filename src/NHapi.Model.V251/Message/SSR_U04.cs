using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V251.Group;
using NHapi.Model.V251.Segment;
using NHapi.Model.V251.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V251.Message

{
///<summary>
/// Represents a SSR_U04 message structure (see chapter 13.3.4). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: EQU (Equipment Detail) </li>
///<li>3: SSR_U04_SPECIMEN_CONTAINER (a Group object) repeating</li>
///<li>4: ROL (Role) optional </li>
///</ol>
///</summary>
[Serializable]
public class SSR_U04 : AbstractMessage  {

	///<summary> 
	/// Creates a new SSR_U04 Group with custom IModelClassFactory.
	///</summary>
	public SSR_U04(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new SSR_U04 Group with DefaultModelClassFactory. 
	///</summary> 
	public SSR_U04() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for SSR_U04.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(EQU), true, false);
	      this.add(typeof(SSR_U04_SPECIMEN_CONTAINER), true, true);
	      this.add(typeof(ROL), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SSR_U04 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of SSR_U04_SPECIMEN_CONTAINER (a Group object) - creates it if necessary
	///</summary>
	public SSR_U04_SPECIMEN_CONTAINER GetSPECIMEN_CONTAINER() {
	   SSR_U04_SPECIMEN_CONTAINER ret = null;
	   try {
	      ret = (SSR_U04_SPECIMEN_CONTAINER)this.GetStructure("SPECIMEN_CONTAINER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SSR_U04_SPECIMEN_CONTAINER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SSR_U04_SPECIMEN_CONTAINER GetSPECIMEN_CONTAINER(int rep) { 
	   return (SSR_U04_SPECIMEN_CONTAINER)this.GetStructure("SPECIMEN_CONTAINER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SSR_U04_SPECIMEN_CONTAINER 
	 */ 
	public int SPECIMEN_CONTAINERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SPECIMEN_CONTAINER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SSR_U04_SPECIMEN_CONTAINER results 
	 */ 
	public IEnumerable<SSR_U04_SPECIMEN_CONTAINER> SPECIMEN_CONTAINERs 
	{ 
		get
		{
			for (int rep = 0; rep < SPECIMEN_CONTAINERRepetitionsUsed; rep++)
			{
				yield return (SSR_U04_SPECIMEN_CONTAINER)this.GetStructure("SPECIMEN_CONTAINER", rep);
			}
		}
	}

	///<summary>
	///Adds a new SSR_U04_SPECIMEN_CONTAINER
	///</summary>
	public SSR_U04_SPECIMEN_CONTAINER AddSPECIMEN_CONTAINER()
	{
		return this.AddStructure("SPECIMEN_CONTAINER") as SSR_U04_SPECIMEN_CONTAINER;
	}

	///<summary>
	///Removes the given SSR_U04_SPECIMEN_CONTAINER
	///</summary>
	public void RemoveSPECIMEN_CONTAINER(SSR_U04_SPECIMEN_CONTAINER toRemove)
	{
		this.RemoveStructure("SPECIMEN_CONTAINER", toRemove);
	}

	///<summary>
	///Removes the SSR_U04_SPECIMEN_CONTAINER at the given index
	///</summary>
	public void RemoveSPECIMEN_CONTAINERAt(int index)
	{
		this.RemoveRepetition("SPECIMEN_CONTAINER", index);
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
