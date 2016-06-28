using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V28.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the CCM_I21_CLINICAL_HISTORY_DETAIL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (Observation Request) </li>
///<li>1: ODS (Dietary Orders, Supplements, and Preferences) </li>
///<li>2: PR1 (Procedures) </li>
///<li>3: RF1 (Referral Information) </li>
///<li>4: AL1 (Patient Allergy Information) </li>
///<li>5: IAM (Patient Adverse Reaction Information) </li>
///<li>6: ACC (Accident) </li>
///<li>7: RMI (Risk Management Incident) </li>
///<li>8: DB1 (Disability) </li>
///<li>9: DG1 (Diagnosis) </li>
///<li>10: DRG (Diagnosis Related Group) </li>
///<li>11: PDA (Patient Death and Autopsy) </li>
///<li>12: CCM_I21_CLINICAL_HISTORY_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCM_I21_CLINICAL_HISTORY_DETAIL : AbstractGroup {

	///<summary> 
	/// Creates a new CCM_I21_CLINICAL_HISTORY_DETAIL Group.
	///</summary>
	public CCM_I21_CLINICAL_HISTORY_DETAIL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(ODS), true, false);
	      this.add(typeof(PR1), true, false);
	      this.add(typeof(RF1), true, false);
	      this.add(typeof(AL1), true, false);
	      this.add(typeof(IAM), true, false);
	      this.add(typeof(ACC), true, false);
	      this.add(typeof(RMI), true, false);
	      this.add(typeof(DB1), true, false);
	      this.add(typeof(DG1), true, false);
	      this.add(typeof(DRG), true, false);
	      this.add(typeof(PDA), true, false);
	      this.add(typeof(CCM_I21_CLINICAL_HISTORY_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCM_I21_CLINICAL_HISTORY_DETAIL - this is probably a bug in the source code generator.", e);
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
	/// Returns RF1 (Referral Information) - creates it if necessary
	///</summary>
	public RF1 RF1 { 
get{
	   RF1 ret = null;
	   try {
	      ret = (RF1)this.GetStructure("RF1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AL1 (Patient Allergy Information) - creates it if necessary
	///</summary>
	public AL1 AL1 { 
get{
	   AL1 ret = null;
	   try {
	      ret = (AL1)this.GetStructure("AL1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns IAM (Patient Adverse Reaction Information) - creates it if necessary
	///</summary>
	public IAM IAM { 
get{
	   IAM ret = null;
	   try {
	      ret = (IAM)this.GetStructure("IAM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ACC (Accident) - creates it if necessary
	///</summary>
	public ACC ACC { 
get{
	   ACC ret = null;
	   try {
	      ret = (ACC)this.GetStructure("ACC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RMI (Risk Management Incident) - creates it if necessary
	///</summary>
	public RMI RMI { 
get{
	   RMI ret = null;
	   try {
	      ret = (RMI)this.GetStructure("RMI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns DB1 (Disability) - creates it if necessary
	///</summary>
	public DB1 DB1 { 
get{
	   DB1 ret = null;
	   try {
	      ret = (DB1)this.GetStructure("DB1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns DG1 (Diagnosis) - creates it if necessary
	///</summary>
	public DG1 DG1 { 
get{
	   DG1 ret = null;
	   try {
	      ret = (DG1)this.GetStructure("DG1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns DRG (Diagnosis Related Group) - creates it if necessary
	///</summary>
	public DRG DRG { 
get{
	   DRG ret = null;
	   try {
	      ret = (DRG)this.GetStructure("DRG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PDA (Patient Death and Autopsy) - creates it if necessary
	///</summary>
	public PDA PDA { 
get{
	   PDA ret = null;
	   try {
	      ret = (PDA)this.GetStructure("PDA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CCM_I21_CLINICAL_HISTORY_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public CCM_I21_CLINICAL_HISTORY_OBSERVATION GetCLINICAL_HISTORY_OBSERVATION() {
	   CCM_I21_CLINICAL_HISTORY_OBSERVATION ret = null;
	   try {
	      ret = (CCM_I21_CLINICAL_HISTORY_OBSERVATION)this.GetStructure("CLINICAL_HISTORY_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCM_I21_CLINICAL_HISTORY_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCM_I21_CLINICAL_HISTORY_OBSERVATION GetCLINICAL_HISTORY_OBSERVATION(int rep) { 
	   return (CCM_I21_CLINICAL_HISTORY_OBSERVATION)this.GetStructure("CLINICAL_HISTORY_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCM_I21_CLINICAL_HISTORY_OBSERVATION 
	 */ 
	public int CLINICAL_HISTORY_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CLINICAL_HISTORY_OBSERVATION").Length; 
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
