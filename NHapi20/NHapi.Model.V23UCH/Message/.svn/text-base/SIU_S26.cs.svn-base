using System;
using NHapi.Base.Log;
using NHapi.Model.V23UCH.Group;
using NHapi.Model.V23UCH.Segment;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V23UCH.Message

{
///<summary>
/// Represents a SIU_S26 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: SCH (Schedule Activity Information) </li>
///<li>2: PID (Patient Identification) </li>
///<li>3: SIU_S26_VISIT (a Group object) optional </li>
///<li>4: AIS (Appointment Information - Service) </li>
///<li>5: AIG (Appointment Information - General Resource) </li>
///<li>6: AIL (Appointment Information - Location Resource) </li>
///<li>7: AIP (Appointment Information - Personnel Resource) </li>
///<li>8: SIU_S26_REG_INSURANCE (a Group object) repeating</li>
///<li>9: SIU_S26_VISIT_INSURANCE (a Group object) repeating</li>
///<li>10: ZS1 (Scheduling Custom Segment) </li>
///<li>11: ZEG (Visit Custom Segment) </li>
///</ol>
///</summary>
[Serializable]
public class SIU_S26 : AbstractMessage  {

	///<summary> 
	/// Creates a new SIU_S26 Group with custom IModelClassFactory.
	///</summary>
	public SIU_S26(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new SIU_S26 Group with DefaultModelClassFactory. 
	///</summary> 
	public SIU_S26() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for SIU_S26.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SCH), true, false);
	      this.add(typeof(PID), true, false);
	      this.add(typeof(SIU_S26_VISIT), false, false);
	      this.add(typeof(AIS), true, false);
	      this.add(typeof(AIG), true, false);
	      this.add(typeof(AIL), true, false);
	      this.add(typeof(AIP), true, false);
	      this.add(typeof(SIU_S26_REG_INSURANCE), true, true);
	      this.add(typeof(SIU_S26_VISIT_INSURANCE), true, true);
	      this.add(typeof(ZS1), true, false);
	      this.add(typeof(ZEG), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SIU_S26 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (Message header segment) - creates it if necessary
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
	/// Returns SCH (Schedule Activity Information) - creates it if necessary
	///</summary>
	public SCH SCH { 
get{
	   SCH ret = null;
	   try {
	      ret = (SCH)this.GetStructure("SCH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PID (Patient Identification) - creates it if necessary
	///</summary>
	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns SIU_S26_VISIT (a Group object) - creates it if necessary
	///</summary>
	public SIU_S26_VISIT VISIT { 
get{
	   SIU_S26_VISIT ret = null;
	   try {
	      ret = (SIU_S26_VISIT)this.GetStructure("VISIT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIS (Appointment Information - Service) - creates it if necessary
	///</summary>
	public AIS AIS { 
get{
	   AIS ret = null;
	   try {
	      ret = (AIS)this.GetStructure("AIS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIG (Appointment Information - General Resource) - creates it if necessary
	///</summary>
	public AIG AIG { 
get{
	   AIG ret = null;
	   try {
	      ret = (AIG)this.GetStructure("AIG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIL (Appointment Information - Location Resource) - creates it if necessary
	///</summary>
	public AIL AIL { 
get{
	   AIL ret = null;
	   try {
	      ret = (AIL)this.GetStructure("AIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIP (Appointment Information - Personnel Resource) - creates it if necessary
	///</summary>
	public AIP AIP { 
get{
	   AIP ret = null;
	   try {
	      ret = (AIP)this.GetStructure("AIP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of SIU_S26_REG_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public SIU_S26_REG_INSURANCE GetREG_INSURANCE() {
	   SIU_S26_REG_INSURANCE ret = null;
	   try {
	      ret = (SIU_S26_REG_INSURANCE)this.GetStructure("REG_INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SIU_S26_REG_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SIU_S26_REG_INSURANCE GetREG_INSURANCE(int rep) { 
	   return (SIU_S26_REG_INSURANCE)this.GetStructure("REG_INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SIU_S26_REG_INSURANCE 
	 */ 
	public int REG_INSURANCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("REG_INSURANCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of SIU_S26_VISIT_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public SIU_S26_VISIT_INSURANCE GetVISIT_INSURANCE() {
	   SIU_S26_VISIT_INSURANCE ret = null;
	   try {
	      ret = (SIU_S26_VISIT_INSURANCE)this.GetStructure("VISIT_INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SIU_S26_VISIT_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SIU_S26_VISIT_INSURANCE GetVISIT_INSURANCE(int rep) { 
	   return (SIU_S26_VISIT_INSURANCE)this.GetStructure("VISIT_INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SIU_S26_VISIT_INSURANCE 
	 */ 
	public int VISIT_INSURANCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("VISIT_INSURANCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns ZS1 (Scheduling Custom Segment) - creates it if necessary
	///</summary>
	public ZS1 ZS1 { 
get{
	   ZS1 ret = null;
	   try {
	      ret = (ZS1)this.GetStructure("ZS1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ZEG (Visit Custom Segment) - creates it if necessary
	///</summary>
	public ZEG ZEG { 
get{
	   ZEG ret = null;
	   try {
	      ret = (ZEG)this.GetStructure("ZEG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
