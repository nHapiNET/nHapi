using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V231.Group;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Message

{
///<summary>
/// Represents a NMD_N02 message structure (see chapter 14). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MSH - message header segment) </li>
///<li>1: NMD_N02_CLOCK_AND_STATS_WITH_NOTES (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class NMD_N02 : AbstractMessage  {

	///<summary> 
	/// Creates a new NMD_N02 Group with custom IModelClassFactory.
	///</summary>
	public NMD_N02(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new NMD_N02 Group with DefaultModelClassFactory. 
	///</summary> 
	public NMD_N02() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for NMD_N02.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(NMD_N02_CLOCK_AND_STATS_WITH_NOTES), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating NMD_N02 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MSH - message header segment) - creates it if necessary
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
	/// Returns  first repetition of NMD_N02_CLOCK_AND_STATS_WITH_NOTES (a Group object) - creates it if necessary
	///</summary>
	public NMD_N02_CLOCK_AND_STATS_WITH_NOTES GetCLOCK_AND_STATS_WITH_NOTES() {
	   NMD_N02_CLOCK_AND_STATS_WITH_NOTES ret = null;
	   try {
	      ret = (NMD_N02_CLOCK_AND_STATS_WITH_NOTES)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NMD_N02_CLOCK_AND_STATS_WITH_NOTES
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NMD_N02_CLOCK_AND_STATS_WITH_NOTES GetCLOCK_AND_STATS_WITH_NOTES(int rep) { 
	   return (NMD_N02_CLOCK_AND_STATS_WITH_NOTES)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NMD_N02_CLOCK_AND_STATS_WITH_NOTES 
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

	/** 
	 * Enumerate over the NMD_N02_CLOCK_AND_STATS_WITH_NOTES results 
	 */ 
	public IEnumerable<NMD_N02_CLOCK_AND_STATS_WITH_NOTES> CLOCK_AND_STATS_WITH_NOTESs 
	{ 
		get
		{
			for (int rep = 0; rep < CLOCK_AND_STATS_WITH_NOTESRepetitionsUsed; rep++)
			{
				yield return (NMD_N02_CLOCK_AND_STATS_WITH_NOTES)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES", rep);
			}
		}
	}

	///<summary>
	///Adds a new NMD_N02_CLOCK_AND_STATS_WITH_NOTES
	///</summary>
	public NMD_N02_CLOCK_AND_STATS_WITH_NOTES AddCLOCK_AND_STATS_WITH_NOTES()
	{
		return this.AddStructure("CLOCK_AND_STATS_WITH_NOTES") as NMD_N02_CLOCK_AND_STATS_WITH_NOTES;
	}

	///<summary>
	///Removes the given NMD_N02_CLOCK_AND_STATS_WITH_NOTES
	///</summary>
	public void RemoveCLOCK_AND_STATS_WITH_NOTES(NMD_N02_CLOCK_AND_STATS_WITH_NOTES toRemove)
	{
		this.RemoveStructure("CLOCK_AND_STATS_WITH_NOTES", toRemove);
	}

	///<summary>
	///Removes the NMD_N02_CLOCK_AND_STATS_WITH_NOTES at the given index
	///</summary>
	public void RemoveCLOCK_AND_STATS_WITH_NOTESAt(int index)
	{
		this.RemoveRepetition("CLOCK_AND_STATS_WITH_NOTES", index);
	}

}
}
