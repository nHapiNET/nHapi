using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the ORF_R04_PIDNTEORCOBRNTETQ1TQ2CTDOBXNTECTI Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORF_R04_PIDNTE (a Group object) optional </li>
///<li>1: ORF_R04_ORCOBRNTETQ1TQ2CTDOBXNTECTI (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORF_R04_PIDNTEORCOBRNTETQ1TQ2CTDOBXNTECTI : AbstractGroup {

	///<summary> 
	/// Creates a new ORF_R04_PIDNTEORCOBRNTETQ1TQ2CTDOBXNTECTI Group.
	///</summary>
	public ORF_R04_PIDNTEORCOBRNTETQ1TQ2CTDOBXNTECTI(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORF_R04_PIDNTE), false, false);
	      this.add(typeof(ORF_R04_ORCOBRNTETQ1TQ2CTDOBXNTECTI), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORF_R04_PIDNTEORCOBRNTETQ1TQ2CTDOBXNTECTI - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORF_R04_PIDNTE (a Group object) - creates it if necessary
	///</summary>
	public ORF_R04_PIDNTE PIDNTE { 
get{
	   ORF_R04_PIDNTE ret = null;
	   try {
	      ret = (ORF_R04_PIDNTE)this.GetStructure("PIDNTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORF_R04_ORCOBRNTETQ1TQ2CTDOBXNTECTI (a Group object) - creates it if necessary
	///</summary>
	public ORF_R04_ORCOBRNTETQ1TQ2CTDOBXNTECTI GetORCOBRNTETQ1TQ2CTDOBXNTECTI() {
	   ORF_R04_ORCOBRNTETQ1TQ2CTDOBXNTECTI ret = null;
	   try {
	      ret = (ORF_R04_ORCOBRNTETQ1TQ2CTDOBXNTECTI)this.GetStructure("ORCOBRNTETQ1TQ2CTDOBXNTECTI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORF_R04_ORCOBRNTETQ1TQ2CTDOBXNTECTI
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORF_R04_ORCOBRNTETQ1TQ2CTDOBXNTECTI GetORCOBRNTETQ1TQ2CTDOBXNTECTI(int rep) { 
	   return (ORF_R04_ORCOBRNTETQ1TQ2CTDOBXNTECTI)this.GetStructure("ORCOBRNTETQ1TQ2CTDOBXNTECTI", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORF_R04_ORCOBRNTETQ1TQ2CTDOBXNTECTI 
	 */ 
	public int ORCOBRNTETQ1TQ2CTDOBXNTECTIRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORCOBRNTETQ1TQ2CTDOBXNTECTI").Length; 
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
