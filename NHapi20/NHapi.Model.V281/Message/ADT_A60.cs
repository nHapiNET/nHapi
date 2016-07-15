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
/// Represents a ADT_A60 message structure (see chapter 3.3.60). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: EVN (Event Type) </li>
///<li>4: PID (Patient Identification) </li>
///<li>5: ARV (Access Restriction) optional repeating</li>
///<li>6: PV1 (Patient Visit) optional </li>
///<li>7: PV2 (Patient Visit - Additional Information) optional </li>
///<li>8: ARV (Access Restriction) optional repeating</li>
///<li>9: ADT_A60_ADVERSE_REACTION_GROUP (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ADT_A60 : AbstractMessage  {

	///<summary> 
	/// Creates a new ADT_A60 Group with custom IModelClassFactory.
	///</summary>
	public ADT_A60(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new ADT_A60 Group with DefaultModelClassFactory. 
	///</summary> 
	public ADT_A60() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for ADT_A60.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(EVN), true, false);
	      this.add(typeof(PID), true, false);
	      this.add(typeof(ARV), false, true);
	      this.add(typeof(PV1), false, false);
	      this.add(typeof(PV2), false, false);
	      this.add(typeof(ARV), false, true);
	      this.add(typeof(ADT_A60_ADVERSE_REACTION_GROUP), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ADT_A60 - this is probably a bug in the source code generator.", e);
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
	/// Returns PID (Patient Identification) - creates it if necessary
	///</summary>
	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ARV (Access Restriction) - creates it if necessary
	///</summary>
	public ARV GetARV() {
	   ARV ret = null;
	   try {
	      ret = (ARV)this.GetStructure("ARV");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ARV
	/// * (Access Restriction) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ARV GetARV(int rep) { 
	   return (ARV)this.GetStructure("ARV", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ARV 
	 */ 
	public int ARVRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ARV").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ARV results 
	 */ 
	public IEnumerable<ARV> ARVs 
	{ 
		get
		{
			for (int rep = 0; rep < ARVRepetitionsUsed; rep++)
			{
				yield return (ARV)this.GetStructure("ARV", rep);
			}
		}
	}

	///<summary>
	///Adds a new ARV
	///</summary>
	public ARV AddARV()
	{
		return this.AddStructure("ARV") as ARV;
	}

	///<summary>
	///Removes the given ARV
	///</summary>
	public void RemoveARV(ARV toRemove)
	{
		this.RemoveStructure("ARV", toRemove);
	}

	///<summary>
	///Removes the ARV at the given index
	///</summary>
	public void RemoveARVAt(int index)
	{
		this.RemoveRepetition("ARV", index);
	}

	///<summary>
	/// Returns PV1 (Patient Visit) - creates it if necessary
	///</summary>
	public PV1 PV1 { 
get{
	   PV1 ret = null;
	   try {
	      ret = (PV1)this.GetStructure("PV1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PV2 (Patient Visit - Additional Information) - creates it if necessary
	///</summary>
	public PV2 PV2 { 
get{
	   PV2 ret = null;
	   try {
	      ret = (PV2)this.GetStructure("PV2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ARV2 (Access Restriction) - creates it if necessary
	///</summary>
	public ARV GetARV2() {
	   ARV ret = null;
	   try {
	      ret = (ARV)this.GetStructure("ARV2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ARV2
	/// * (Access Restriction) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ARV GetARV2(int rep) { 
	   return (ARV)this.GetStructure("ARV2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ARV2 
	 */ 
	public int ARV2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ARV2").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ARV results 
	 */ 
	public IEnumerable<ARV> ARV2s 
	{ 
		get
		{
			for (int rep = 0; rep < ARV2RepetitionsUsed; rep++)
			{
				yield return (ARV)this.GetStructure("ARV2", rep);
			}
		}
	}

	///<summary>
	///Adds a new ARV
	///</summary>
	public ARV AddARV2()
	{
		return this.AddStructure("ARV2") as ARV;
	}

	///<summary>
	///Removes the given ARV
	///</summary>
	public void RemoveARV2(ARV toRemove)
	{
		this.RemoveStructure("ARV2", toRemove);
	}

	///<summary>
	///Removes the ARV at the given index
	///</summary>
	public void RemoveARV2At(int index)
	{
		this.RemoveRepetition("ARV2", index);
	}

	///<summary>
	/// Returns  first repetition of ADT_A60_ADVERSE_REACTION_GROUP (a Group object) - creates it if necessary
	///</summary>
	public ADT_A60_ADVERSE_REACTION_GROUP GetADVERSE_REACTION_GROUP() {
	   ADT_A60_ADVERSE_REACTION_GROUP ret = null;
	   try {
	      ret = (ADT_A60_ADVERSE_REACTION_GROUP)this.GetStructure("ADVERSE_REACTION_GROUP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ADT_A60_ADVERSE_REACTION_GROUP
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ADT_A60_ADVERSE_REACTION_GROUP GetADVERSE_REACTION_GROUP(int rep) { 
	   return (ADT_A60_ADVERSE_REACTION_GROUP)this.GetStructure("ADVERSE_REACTION_GROUP", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ADT_A60_ADVERSE_REACTION_GROUP 
	 */ 
	public int ADVERSE_REACTION_GROUPRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ADVERSE_REACTION_GROUP").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ADT_A60_ADVERSE_REACTION_GROUP results 
	 */ 
	public IEnumerable<ADT_A60_ADVERSE_REACTION_GROUP> ADVERSE_REACTION_GROUPs 
	{ 
		get
		{
			for (int rep = 0; rep < ADVERSE_REACTION_GROUPRepetitionsUsed; rep++)
			{
				yield return (ADT_A60_ADVERSE_REACTION_GROUP)this.GetStructure("ADVERSE_REACTION_GROUP", rep);
			}
		}
	}

	///<summary>
	///Adds a new ADT_A60_ADVERSE_REACTION_GROUP
	///</summary>
	public ADT_A60_ADVERSE_REACTION_GROUP AddADVERSE_REACTION_GROUP()
	{
		return this.AddStructure("ADVERSE_REACTION_GROUP") as ADT_A60_ADVERSE_REACTION_GROUP;
	}

	///<summary>
	///Removes the given ADT_A60_ADVERSE_REACTION_GROUP
	///</summary>
	public void RemoveADVERSE_REACTION_GROUP(ADT_A60_ADVERSE_REACTION_GROUP toRemove)
	{
		this.RemoveStructure("ADVERSE_REACTION_GROUP", toRemove);
	}

	///<summary>
	///Removes the ADT_A60_ADVERSE_REACTION_GROUP at the given index
	///</summary>
	public void RemoveADVERSE_REACTION_GROUPAt(int index)
	{
		this.RemoveRepetition("ADVERSE_REACTION_GROUP", index);
	}

}
}
