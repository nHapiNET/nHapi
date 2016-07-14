using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the CCM_I21_MEDICATION_HISTORY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: CCM_I21_MEDICATION_ORDER_DETAIL (a Group object) optional </li>
///<li>2: CCM_I21_MEDICATION_ENCODING_DETAIL (a Group object) optional </li>
///<li>3: CCM_I21_MEDICATION_ADMINISTRATION_DETAIL (a Group object) optional repeating</li>
///<li>4: CTI (Clinical Trial Identification) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCM_I21_MEDICATION_HISTORY : AbstractGroup {

	///<summary> 
	/// Creates a new CCM_I21_MEDICATION_HISTORY Group.
	///</summary>
	public CCM_I21_MEDICATION_HISTORY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(CCM_I21_MEDICATION_ORDER_DETAIL), false, false);
	      this.add(typeof(CCM_I21_MEDICATION_ENCODING_DETAIL), false, false);
	      this.add(typeof(CCM_I21_MEDICATION_ADMINISTRATION_DETAIL), false, true);
	      this.add(typeof(CTI), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCM_I21_MEDICATION_HISTORY - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORC (Common Order) - creates it if necessary
	///</summary>
	public ORC ORC { 
get{
	   ORC ret = null;
	   try {
	      ret = (ORC)this.GetStructure("ORC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns CCM_I21_MEDICATION_ORDER_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_MEDICATION_ORDER_DETAIL MEDICATION_ORDER_DETAIL { 
get{
	   CCM_I21_MEDICATION_ORDER_DETAIL ret = null;
	   try {
	      ret = (CCM_I21_MEDICATION_ORDER_DETAIL)this.GetStructure("MEDICATION_ORDER_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns CCM_I21_MEDICATION_ENCODING_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_MEDICATION_ENCODING_DETAIL MEDICATION_ENCODING_DETAIL { 
get{
	   CCM_I21_MEDICATION_ENCODING_DETAIL ret = null;
	   try {
	      ret = (CCM_I21_MEDICATION_ENCODING_DETAIL)this.GetStructure("MEDICATION_ENCODING_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_MEDICATION_ADMINISTRATION_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_MEDICATION_ADMINISTRATION_DETAIL GetMEDICATION_ADMINISTRATION_DETAIL() {
	   CCM_I21_MEDICATION_ADMINISTRATION_DETAIL ret = null;
	   try {
	      ret = (CCM_I21_MEDICATION_ADMINISTRATION_DETAIL)this.GetStructure("MEDICATION_ADMINISTRATION_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_MEDICATION_ADMINISTRATION_DETAIL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_MEDICATION_ADMINISTRATION_DETAIL GetMEDICATION_ADMINISTRATION_DETAIL(int rep) { 
	   return (CCM_I21_MEDICATION_ADMINISTRATION_DETAIL)this.GetStructure("MEDICATION_ADMINISTRATION_DETAIL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_MEDICATION_ADMINISTRATION_DETAIL 
	 */ 
	public int MEDICATION_ADMINISTRATION_DETAILRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MEDICATION_ADMINISTRATION_DETAIL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of CTI (Clinical Trial Identification) - creates it if necessary
	///</summary>
	public CTI GetCTI() {
	   CTI ret = null;
	   try {
	      ret = (CTI)this.GetStructure("CTI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CTI
	/// * (Clinical Trial Identification) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CTI GetCTI(int rep) { 
	   return (CTI)this.GetStructure("CTI", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CTI 
	 */ 
	public int CTIRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CTI").Length; 
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
