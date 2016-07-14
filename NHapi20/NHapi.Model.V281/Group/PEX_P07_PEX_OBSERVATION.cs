using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the PEX_P07_PEX_OBSERVATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PEO (Product Experience Observation) </li>
///<li>1: PEX_P07_PEX_CAUSE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class PEX_P07_PEX_OBSERVATION : AbstractGroup {

	///<summary> 
	/// Creates a new PEX_P07_PEX_OBSERVATION Group.
	///</summary>
	public PEX_P07_PEX_OBSERVATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PEO), true, false);
	      this.add(typeof(PEX_P07_PEX_CAUSE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PEX_P07_PEX_OBSERVATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PEO (Product Experience Observation) - creates it if necessary
	///</summary>
	public PEO PEO { 
get{
	   PEO ret = null;
	   try {
	      ret = (PEO)this.GetStructure("PEO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PEX_P07_PEX_CAUSE (a Group object) - creates it if necessary
	///</summary>
	public PEX_P07_PEX_CAUSE GetPEX_CAUSE() {
	   PEX_P07_PEX_CAUSE ret = null;
	   try {
	      ret = (PEX_P07_PEX_CAUSE)this.GetStructure("PEX_CAUSE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PEX_P07_PEX_CAUSE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PEX_P07_PEX_CAUSE GetPEX_CAUSE(int rep) { 
	   return (PEX_P07_PEX_CAUSE)this.GetStructure("PEX_CAUSE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PEX_P07_PEX_CAUSE 
	 */ 
	public int PEX_CAUSERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PEX_CAUSE").Length; 
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
