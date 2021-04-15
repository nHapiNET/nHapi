using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V22.Group;
using NHapi.Model.V22.Segment;
using NHapi.Model.V22.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V22.Message

{
///<summary>
/// Represents a NMR_N02 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MESSAGE HEADER) </li>
///<li>1: MSA (MESSAGE ACKNOWLEDGMENT) </li>
///<li>2: ERR (ERROR) optional </li>
///<li>3: QRD (QUERY DEFINITION) optional </li>
///<li>4: NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class NMR_N02 : AbstractMessage  {

	///<summary> 
	/// Creates a new NMR_N02 Group with custom IModelClassFactory.
	///</summary>
	public NMR_N02(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new NMR_N02 Group with DefaultModelClassFactory. 
	///</summary> 
	public NMR_N02() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for NMR_N02.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(ERR), false, false);
	      this.add(typeof(QRD), false, false);
	      this.add(typeof(NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating NMR_N02 - this is probably a bug in the source code generator.", e);
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
	/// Returns MSA (MESSAGE ACKNOWLEDGMENT) - creates it if necessary
	///</summary>
	public MSA MSA { 
get{
	   MSA ret = null;
	   try {
	      ret = (MSA)this.GetStructure("MSA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ERR (ERROR) - creates it if necessary
	///</summary>
	public ERR ERR { 
get{
	   ERR ret = null;
	   try {
	      ret = (ERR)this.GetStructure("ERR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns QRD (QUERY DEFINITION) - creates it if necessary
	///</summary>
	public QRD QRD { 
get{
	   QRD ret = null;
	   try {
	      ret = (QRD)this.GetStructure("QRD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT (a Group object) - creates it if necessary
	///</summary>
	public NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT GetCLOCK_AND_STATS_WITH_NOTES_ALT() {
	   NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT ret = null;
	   try {
	      ret = (NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES_ALT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT GetCLOCK_AND_STATS_WITH_NOTES_ALT(int rep) { 
	   return (NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES_ALT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT 
	 */ 
	public int CLOCK_AND_STATS_WITH_NOTES_ALTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLOCK_AND_STATS_WITH_NOTES_ALT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT results 
	 */ 
	public IEnumerable<NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT> CLOCK_AND_STATS_WITH_NOTES_ALTs 
	{ 
		get
		{
			for (int rep = 0; rep < CLOCK_AND_STATS_WITH_NOTES_ALTRepetitionsUsed; rep++)
			{
				yield return (NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT)this.GetStructure("CLOCK_AND_STATS_WITH_NOTES_ALT", rep);
			}
		}
	}

	///<summary>
	///Adds a new NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT
	///</summary>
	public NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT AddCLOCK_AND_STATS_WITH_NOTES_ALT()
	{
		return this.AddStructure("CLOCK_AND_STATS_WITH_NOTES_ALT") as NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT;
	}

	///<summary>
	///Removes the given NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT
	///</summary>
	public void RemoveCLOCK_AND_STATS_WITH_NOTES_ALT(NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT toRemove)
	{
		this.RemoveStructure("CLOCK_AND_STATS_WITH_NOTES_ALT", toRemove);
	}

	///<summary>
	///Removes the NMR_N02_CLOCK_AND_STATS_WITH_NOTES_ALT at the given index
	///</summary>
	public void RemoveCLOCK_AND_STATS_WITH_NOTES_ALTAt(int index)
	{
		this.RemoveRepetition("CLOCK_AND_STATS_WITH_NOTES_ALT", index);
	}

}
}
