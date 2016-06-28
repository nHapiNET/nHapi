using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V27.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the RSP_K31_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RSP_K31_PATIENT (a Group object) optional </li>
///<li>1: RSP_K31_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class RSP_K31_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new RSP_K31_RESPONSE Group.
	///</summary>
	public RSP_K31_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RSP_K31_PATIENT), false, false);
	      this.add(typeof(RSP_K31_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RSP_K31_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RSP_K31_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public RSP_K31_PATIENT PATIENT { 
get{
	   RSP_K31_PATIENT ret = null;
	   try {
	      ret = (RSP_K31_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RSP_K31_ORDER (a Group object) - creates it if necessary
	///</summary>
	public RSP_K31_ORDER GetORDER() {
	   RSP_K31_ORDER ret = null;
	   try {
	      ret = (RSP_K31_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RSP_K31_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RSP_K31_ORDER GetORDER(int rep) { 
	   return (RSP_K31_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RSP_K31_ORDER 
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
