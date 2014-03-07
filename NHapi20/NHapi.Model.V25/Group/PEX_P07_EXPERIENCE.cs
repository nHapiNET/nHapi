using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V25.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V25.Group
{
///<summary>
///Represents the PEX_P07_EXPERIENCE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PES (Product Experience Sender) </li>
///<li>1: PEX_P07_PEX_OBSERVATION (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class PEX_P07_EXPERIENCE : AbstractGroup {

	///<summary> 
	/// Creates a new PEX_P07_EXPERIENCE Group.
	///</summary>
	public PEX_P07_EXPERIENCE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PES), true, false);
	      this.add(typeof(PEX_P07_PEX_OBSERVATION), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PEX_P07_EXPERIENCE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PES (Product Experience Sender) - creates it if necessary
	///</summary>
	public PES PES { 
get{
	   PES ret = null;
	   try {
	      ret = (PES)this.GetStructure("PES");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PEX_P07_PEX_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public PEX_P07_PEX_OBSERVATION GetPEX_OBSERVATION() {
	   PEX_P07_PEX_OBSERVATION ret = null;
	   try {
	      ret = (PEX_P07_PEX_OBSERVATION)this.GetStructure("PEX_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PEX_P07_PEX_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PEX_P07_PEX_OBSERVATION GetPEX_OBSERVATION(int rep) { 
	   return (PEX_P07_PEX_OBSERVATION)this.GetStructure("PEX_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PEX_P07_PEX_OBSERVATION 
	 */ 
	public int PEX_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PEX_OBSERVATION").Length; 
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
