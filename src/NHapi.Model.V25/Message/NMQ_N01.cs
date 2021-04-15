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
/// Represents a NMQ_N01 message structure (see chapter 14.3.1). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: NMQ_N01_QRY_WITH_DETAIL (a Group object) optional </li>
///<li>3: NMQ_N01_CLOCK_AND_STATISTICS (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class NMQ_N01 : AbstractMessage  {

	///<summary> 
	/// Creates a new NMQ_N01 Group with custom IModelClassFactory.
	///</summary>
	public NMQ_N01(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new NMQ_N01 Group with DefaultModelClassFactory. 
	///</summary> 
	public NMQ_N01() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for NMQ_N01.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(NMQ_N01_QRY_WITH_DETAIL), false, false);
	      this.add(typeof(NMQ_N01_CLOCK_AND_STATISTICS), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating NMQ_N01 - this is probably a bug in the source code generator.", e);
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
	/// Returns NMQ_N01_QRY_WITH_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public NMQ_N01_QRY_WITH_DETAIL QRY_WITH_DETAIL { 
get{
	   NMQ_N01_QRY_WITH_DETAIL ret = null;
	   try {
	      ret = (NMQ_N01_QRY_WITH_DETAIL)this.GetStructure("QRY_WITH_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NMQ_N01_CLOCK_AND_STATISTICS (a Group object) - creates it if necessary
	///</summary>
	public NMQ_N01_CLOCK_AND_STATISTICS GetCLOCK_AND_STATISTICS() {
	   NMQ_N01_CLOCK_AND_STATISTICS ret = null;
	   try {
	      ret = (NMQ_N01_CLOCK_AND_STATISTICS)this.GetStructure("CLOCK_AND_STATISTICS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NMQ_N01_CLOCK_AND_STATISTICS
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NMQ_N01_CLOCK_AND_STATISTICS GetCLOCK_AND_STATISTICS(int rep) { 
	   return (NMQ_N01_CLOCK_AND_STATISTICS)this.GetStructure("CLOCK_AND_STATISTICS", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NMQ_N01_CLOCK_AND_STATISTICS 
	 */ 
	public int CLOCK_AND_STATISTICSRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLOCK_AND_STATISTICS").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NMQ_N01_CLOCK_AND_STATISTICS results 
	 */ 
	public IEnumerable<NMQ_N01_CLOCK_AND_STATISTICS> CLOCK_AND_STATISTICSs 
	{ 
		get
		{
			for (int rep = 0; rep < CLOCK_AND_STATISTICSRepetitionsUsed; rep++)
			{
				yield return (NMQ_N01_CLOCK_AND_STATISTICS)this.GetStructure("CLOCK_AND_STATISTICS", rep);
			}
		}
	}

	///<summary>
	///Adds a new NMQ_N01_CLOCK_AND_STATISTICS
	///</summary>
	public NMQ_N01_CLOCK_AND_STATISTICS AddCLOCK_AND_STATISTICS()
	{
		return this.AddStructure("CLOCK_AND_STATISTICS") as NMQ_N01_CLOCK_AND_STATISTICS;
	}

	///<summary>
	///Removes the given NMQ_N01_CLOCK_AND_STATISTICS
	///</summary>
	public void RemoveCLOCK_AND_STATISTICS(NMQ_N01_CLOCK_AND_STATISTICS toRemove)
	{
		this.RemoveStructure("CLOCK_AND_STATISTICS", toRemove);
	}

	///<summary>
	///Removes the NMQ_N01_CLOCK_AND_STATISTICS at the given index
	///</summary>
	public void RemoveCLOCK_AND_STATISTICSAt(int index)
	{
		this.RemoveRepetition("CLOCK_AND_STATISTICS", index);
	}

}
}
