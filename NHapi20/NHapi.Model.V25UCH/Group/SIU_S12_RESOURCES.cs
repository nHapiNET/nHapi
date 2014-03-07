using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V25UCH.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V25UCH.Group
{
///<summary>
///Represents the SIU_S12_RESOURCES Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RGS (Resource Group) </li>
///<li>1: AIS (Appointment Information) </li>
///<li>2: NTE (Notes and Comments) optional repeating</li>
///<li>3: SIU_S12_APPOINTMENT_RESOURCE (a Group object) optional repeating</li>
///<li>4: SIU_S12_PERSONNEL_RESOURCE (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class SIU_S12_RESOURCES : AbstractGroup {

	///<summary> 
	/// Creates a new SIU_S12_RESOURCES Group.
	///</summary>
	public SIU_S12_RESOURCES(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RGS), true, false);
	      this.add(typeof(AIS), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(SIU_S12_APPOINTMENT_RESOURCE), false, true);
	      this.add(typeof(SIU_S12_PERSONNEL_RESOURCE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SIU_S12_RESOURCES - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RGS (Resource Group) - creates it if necessary
	///</summary>
	public RGS RGS { 
get{
	   RGS ret = null;
	   try {
	      ret = (RGS)this.GetStructure("RGS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIS (Appointment Information) - creates it if necessary
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
	/// Returns  first repetition of NTE (Notes and Comments) - creates it if necessary
	///</summary>
	public NTE GetNTE() {
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NTE
	/// * (Notes and Comments) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NTE GetNTE(int rep) { 
	   return (NTE)this.GetStructure("NTE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NTE 
	 */ 
	public int NTERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NTE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of SIU_S12_APPOINTMENT_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SIU_S12_APPOINTMENT_RESOURCE GetAPPOINTMENT_RESOURCE() {
	   SIU_S12_APPOINTMENT_RESOURCE ret = null;
	   try {
	      ret = (SIU_S12_APPOINTMENT_RESOURCE)this.GetStructure("APPOINTMENT_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SIU_S12_APPOINTMENT_RESOURCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SIU_S12_APPOINTMENT_RESOURCE GetAPPOINTMENT_RESOURCE(int rep) { 
	   return (SIU_S12_APPOINTMENT_RESOURCE)this.GetStructure("APPOINTMENT_RESOURCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SIU_S12_APPOINTMENT_RESOURCE 
	 */ 
	public int APPOINTMENT_RESOURCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("APPOINTMENT_RESOURCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of SIU_S12_PERSONNEL_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SIU_S12_PERSONNEL_RESOURCE GetPERSONNEL_RESOURCE() {
	   SIU_S12_PERSONNEL_RESOURCE ret = null;
	   try {
	      ret = (SIU_S12_PERSONNEL_RESOURCE)this.GetStructure("PERSONNEL_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SIU_S12_PERSONNEL_RESOURCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SIU_S12_PERSONNEL_RESOURCE GetPERSONNEL_RESOURCE(int rep) { 
	   return (SIU_S12_PERSONNEL_RESOURCE)this.GetStructure("PERSONNEL_RESOURCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SIU_S12_PERSONNEL_RESOURCE 
	 */ 
	public int PERSONNEL_RESOURCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PERSONNEL_RESOURCE").Length; 
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
