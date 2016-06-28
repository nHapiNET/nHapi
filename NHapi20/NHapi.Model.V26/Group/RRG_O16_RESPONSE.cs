using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V26.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V26.Group
{
///<summary>
///Represents the RRG_O16_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RRG_O16_PATIENT (a Group object) optional </li>
///<li>1: RRG_O16_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class RRG_O16_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new RRG_O16_RESPONSE Group.
	///</summary>
	public RRG_O16_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RRG_O16_PATIENT), false, false);
	      this.add(typeof(RRG_O16_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RRG_O16_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RRG_O16_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public RRG_O16_PATIENT PATIENT { 
get{
	   RRG_O16_PATIENT ret = null;
	   try {
	      ret = (RRG_O16_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RRG_O16_ORDER (a Group object) - creates it if necessary
	///</summary>
	public RRG_O16_ORDER GetORDER() {
	   RRG_O16_ORDER ret = null;
	   try {
	      ret = (RRG_O16_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RRG_O16_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RRG_O16_ORDER GetORDER(int rep) { 
	   return (RRG_O16_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RRG_O16_ORDER 
	 */ 
	public int ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER").Length; 
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
