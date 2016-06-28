using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V28.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the CCR_I16_CLINICAL_ORDER_DETAIL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (Observation Request) </li>
///<li>1: RXO (Pharmacy/Treatment Order) </li>
///<li>2: ODS (Dietary Orders, Supplements, and Preferences) </li>
///<li>3: PR1 (Procedures) </li>
///<li>4: CCR_I16_CLINICAL_ORDER_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCR_I16_CLINICAL_ORDER_DETAIL : AbstractGroup {

	///<summary> 
	/// Creates a new CCR_I16_CLINICAL_ORDER_DETAIL Group.
	///</summary>
	public CCR_I16_CLINICAL_ORDER_DETAIL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(RXO), true, false);
	      this.add(typeof(ODS), true, false);
	      this.add(typeof(PR1), true, false);
	      this.add(typeof(CCR_I16_CLINICAL_ORDER_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCR_I16_CLINICAL_ORDER_DETAIL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns OBR (Observation Request) - creates it if necessary
	///</summary>
	public OBR OBR { 
get{
	   OBR ret = null;
	   try {
	      ret = (OBR)this.GetStructure("OBR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RXO (Pharmacy/Treatment Order) - creates it if necessary
	///</summary>
	public RXO RXO { 
get{
	   RXO ret = null;
	   try {
	      ret = (RXO)this.GetStructure("RXO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ODS (Dietary Orders, Supplements, and Preferences) - creates it if necessary
	///</summary>
	public ODS ODS { 
get{
	   ODS ret = null;
	   try {
	      ret = (ODS)this.GetStructure("ODS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PR1 (Procedures) - creates it if necessary
	///</summary>
	public PR1 PR1 { 
get{
	   PR1 ret = null;
	   try {
	      ret = (PR1)this.GetStructure("PR1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CCR_I16_CLINICAL_ORDER_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public CCR_I16_CLINICAL_ORDER_OBSERVATION GetCLINICAL_ORDER_OBSERVATION() {
	   CCR_I16_CLINICAL_ORDER_OBSERVATION ret = null;
	   try {
	      ret = (CCR_I16_CLINICAL_ORDER_OBSERVATION)this.GetStructure("CLINICAL_ORDER_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCR_I16_CLINICAL_ORDER_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCR_I16_CLINICAL_ORDER_OBSERVATION GetCLINICAL_ORDER_OBSERVATION(int rep) { 
	   return (CCR_I16_CLINICAL_ORDER_OBSERVATION)this.GetStructure("CLINICAL_ORDER_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCR_I16_CLINICAL_ORDER_OBSERVATION 
	 */ 
	public int CLINICAL_ORDER_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLINICAL_ORDER_OBSERVATION").Length; 
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
