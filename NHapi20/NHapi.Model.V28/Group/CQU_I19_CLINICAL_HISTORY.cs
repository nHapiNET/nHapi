using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V28.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the CQU_I19_CLINICAL_HISTORY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: CQU_I19_CLINICAL_HISTORY_DETAIL (a Group object) optional repeating</li>
///<li>2: CQU_I19_ROLE_CLINICAL_HISTORY (a Group object) optional repeating</li>
///<li>3: CTI (Clinical Trial Identification) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CQU_I19_CLINICAL_HISTORY : AbstractGroup {

	///<summary> 
	/// Creates a new CQU_I19_CLINICAL_HISTORY Group.
	///</summary>
	public CQU_I19_CLINICAL_HISTORY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(CQU_I19_CLINICAL_HISTORY_DETAIL), false, true);
	      this.add(typeof(CQU_I19_ROLE_CLINICAL_HISTORY), false, true);
	      this.add(typeof(CTI), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CQU_I19_CLINICAL_HISTORY - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of CQU_I19_CLINICAL_HISTORY_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_CLINICAL_HISTORY_DETAIL GetCLINICAL_HISTORY_DETAIL() {
	   CQU_I19_CLINICAL_HISTORY_DETAIL ret = null;
	   try {
	      ret = (CQU_I19_CLINICAL_HISTORY_DETAIL)this.GetStructure("CLINICAL_HISTORY_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_CLINICAL_HISTORY_DETAIL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_CLINICAL_HISTORY_DETAIL GetCLINICAL_HISTORY_DETAIL(int rep) { 
	   return (CQU_I19_CLINICAL_HISTORY_DETAIL)this.GetStructure("CLINICAL_HISTORY_DETAIL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_CLINICAL_HISTORY_DETAIL 
	 */ 
	public int CLINICAL_HISTORY_DETAILRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLINICAL_HISTORY_DETAIL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of CQU_I19_ROLE_CLINICAL_HISTORY (a Group object) - creates it if necessary
	///</summary>
	public CQU_I19_ROLE_CLINICAL_HISTORY GetROLE_CLINICAL_HISTORY() {
	   CQU_I19_ROLE_CLINICAL_HISTORY ret = null;
	   try {
	      ret = (CQU_I19_ROLE_CLINICAL_HISTORY)this.GetStructure("ROLE_CLINICAL_HISTORY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CQU_I19_ROLE_CLINICAL_HISTORY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CQU_I19_ROLE_CLINICAL_HISTORY GetROLE_CLINICAL_HISTORY(int rep) { 
	   return (CQU_I19_ROLE_CLINICAL_HISTORY)this.GetStructure("ROLE_CLINICAL_HISTORY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CQU_I19_ROLE_CLINICAL_HISTORY 
	 */ 
	public int ROLE_CLINICAL_HISTORYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ROLE_CLINICAL_HISTORY").Length; 
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
