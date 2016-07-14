using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V23.Segment;
using NHapi.Model.V23.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V23.Group
{
///<summary>
///Represents the SRM_S06_RESOURCES Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RGS (Resource Group) </li>
///<li>1: SRM_S06_SERVICE (a Group object) optional repeating</li>
///<li>2: SRM_S06_GENERAL_RESOURCE (a Group object) optional repeating</li>
///<li>3: SRM_S06_LOCATION_RESOURCE (a Group object) optional repeating</li>
///<li>4: SRM_S06_PERSONNEL_RESOURCE (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class SRM_S06_RESOURCES : AbstractGroup {

	///<summary> 
	/// Creates a new SRM_S06_RESOURCES Group.
	///</summary>
	public SRM_S06_RESOURCES(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RGS), true, false);
	      this.add(typeof(SRM_S06_SERVICE), false, true);
	      this.add(typeof(SRM_S06_GENERAL_RESOURCE), false, true);
	      this.add(typeof(SRM_S06_LOCATION_RESOURCE), false, true);
	      this.add(typeof(SRM_S06_PERSONNEL_RESOURCE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SRM_S06_RESOURCES - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of SRM_S06_SERVICE (a Group object) - creates it if necessary
	///</summary>
	public SRM_S06_SERVICE GetSERVICE() {
	   SRM_S06_SERVICE ret = null;
	   try {
	      ret = (SRM_S06_SERVICE)this.GetStructure("SERVICE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SRM_S06_SERVICE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SRM_S06_SERVICE GetSERVICE(int rep) { 
	   return (SRM_S06_SERVICE)this.GetStructure("SERVICE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SRM_S06_SERVICE 
	 */ 
	public int SERVICERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SERVICE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of SRM_S06_GENERAL_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SRM_S06_GENERAL_RESOURCE GetGENERAL_RESOURCE() {
	   SRM_S06_GENERAL_RESOURCE ret = null;
	   try {
	      ret = (SRM_S06_GENERAL_RESOURCE)this.GetStructure("GENERAL_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SRM_S06_GENERAL_RESOURCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SRM_S06_GENERAL_RESOURCE GetGENERAL_RESOURCE(int rep) { 
	   return (SRM_S06_GENERAL_RESOURCE)this.GetStructure("GENERAL_RESOURCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SRM_S06_GENERAL_RESOURCE 
	 */ 
	public int GENERAL_RESOURCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("GENERAL_RESOURCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of SRM_S06_LOCATION_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SRM_S06_LOCATION_RESOURCE GetLOCATION_RESOURCE() {
	   SRM_S06_LOCATION_RESOURCE ret = null;
	   try {
	      ret = (SRM_S06_LOCATION_RESOURCE)this.GetStructure("LOCATION_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SRM_S06_LOCATION_RESOURCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SRM_S06_LOCATION_RESOURCE GetLOCATION_RESOURCE(int rep) { 
	   return (SRM_S06_LOCATION_RESOURCE)this.GetStructure("LOCATION_RESOURCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SRM_S06_LOCATION_RESOURCE 
	 */ 
	public int LOCATION_RESOURCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LOCATION_RESOURCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of SRM_S06_PERSONNEL_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SRM_S06_PERSONNEL_RESOURCE GetPERSONNEL_RESOURCE() {
	   SRM_S06_PERSONNEL_RESOURCE ret = null;
	   try {
	      ret = (SRM_S06_PERSONNEL_RESOURCE)this.GetStructure("PERSONNEL_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SRM_S06_PERSONNEL_RESOURCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SRM_S06_PERSONNEL_RESOURCE GetPERSONNEL_RESOURCE(int rep) { 
	   return (SRM_S06_PERSONNEL_RESOURCE)this.GetStructure("PERSONNEL_RESOURCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SRM_S06_PERSONNEL_RESOURCE 
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
