using System;
using NHapi.Base.Log;
using NHapi.Model.V22.Group;
using NHapi.Model.V22.Segment;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V22.Message

{
///<summary>
/// Represents a NMD_N01 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MESSAGE HEADER) </li>
///<li>1: NMD_N01_CLOCK_AND_STATS_WITH_NOTES (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class NMD_N01 : AbstractMessage  {

	///<summary> 
	/// Creates a new NMD_N01 Group with custom IModelClassFactory.
	///</summary>
	public NMD_N01(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new NMD_N01 Group with DefaultModelClassFactory. 
	///</summary> 
	public NMD_N01() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for NMD_N01.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(NMD_N01_CLOCK_AND_STATS_WITH_NOTES), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating NMD_N01 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MESSAGE HEADER) - creates it if necessary
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
	/// Returns  first repetition of NMD_N01_CLOCK_AND_STATS_WITH_NOTES (a Group object) - creates it if necessary
	///</summary>
	public NMD_N01_CLOCK_AND_STATS_WITH_NOTES GetCLOCK_AND_STATS_WITH_NOTES() {
	   NMD_N01_CLOCK_AND_STATS_WITH_NOTES ret = null;
	   try {
	      ret = (NMD_N01_CLOCK_AND_STATS_WITH_NOTES)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NMD_N01_CLOCK_AND_STATS_WITH_NOTES
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NMD_N01_CLOCK_AND_STATS_WITH_NOTES GetCLOCK_AND_STATS_WITH_NOTES(int rep) { 
	   return (NMD_N01_CLOCK_AND_STATS_WITH_NOTES)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NMD_N01_CLOCK_AND_STATS_WITH_NOTES 
	 */ 
	public int CLOCK_AND_STATS_WITH_NOTESRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLOCK_AND_STATS_WITH_NOTES").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

}
}
