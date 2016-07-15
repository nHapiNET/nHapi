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
/// Represents a PMU_B07 message structure (see chapter 15.3.8). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: EVN (Event Type) </li>
///<li>3: STF (Staff Identification) </li>
///<li>4: PRA (Practitioner Detail) optional </li>
///<li>5: PMU_B07_CERTIFICATE (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class PMU_B07 : AbstractMessage  {

	///<summary> 
	/// Creates a new PMU_B07 Group with custom IModelClassFactory.
	///</summary>
	public PMU_B07(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new PMU_B07 Group with DefaultModelClassFactory. 
	///</summary> 
	public PMU_B07() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for PMU_B07.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(EVN), true, false);
	      this.add(typeof(STF), true, false);
	      this.add(typeof(PRA), false, false);
	      this.add(typeof(PMU_B07_CERTIFICATE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PMU_B07 - this is probably a bug in the source code generator.", e);
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
	/// Returns PRA (Practitioner Detail) - creates it if necessary
	///</summary>
	public PRA PRA { 
get{
	   PRA ret = null;
	   try {
	      ret = (PRA)this.GetStructure("PRA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PMU_B07_CERTIFICATE (a Group object) - creates it if necessary
	///</summary>
	public PMU_B07_CERTIFICATE GetCERTIFICATE() {
	   PMU_B07_CERTIFICATE ret = null;
	   try {
	      ret = (PMU_B07_CERTIFICATE)this.GetStructure("CERTIFICATE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PMU_B07_CERTIFICATE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PMU_B07_CERTIFICATE GetCERTIFICATE(int rep) { 
	   return (PMU_B07_CERTIFICATE)this.GetStructure("CERTIFICATE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PMU_B07_CERTIFICATE 
	 */ 
	public int CERTIFICATERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CERTIFICATE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PMU_B07_CERTIFICATE results 
	 */ 
	public IEnumerable<PMU_B07_CERTIFICATE> CERTIFICATEs 
	{ 
		get
		{
			for (int rep = 0; rep < CERTIFICATERepetitionsUsed; rep++)
			{
				yield return (PMU_B07_CERTIFICATE)this.GetStructure("CERTIFICATE", rep);
			}
		}
	}

	///<summary>
	///Adds a new PMU_B07_CERTIFICATE
	///</summary>
	public PMU_B07_CERTIFICATE AddCERTIFICATE()
	{
		return this.AddStructure("CERTIFICATE") as PMU_B07_CERTIFICATE;
	}

	///<summary>
	///Removes the given PMU_B07_CERTIFICATE
	///</summary>
	public void RemoveCERTIFICATE(PMU_B07_CERTIFICATE toRemove)
	{
		this.RemoveStructure("CERTIFICATE", toRemove);
	}

	///<summary>
	///Removes the PMU_B07_CERTIFICATE at the given index
	///</summary>
	public void RemoveCERTIFICATEAt(int index)
	{
		this.RemoveRepetition("CERTIFICATE", index);
	}

}
}
