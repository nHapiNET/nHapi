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
///Represents the OSM_R26_SPECIMEN Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SPM (Specimen) </li>
///<li>1: PRT (Participation Information) optional repeating</li>
///<li>2: OSM_R26_SPECIMEN_OBSERVATION (a Group object) optional repeating</li>
///<li>3: OSM_R26_CONTAINER (a Group object) optional repeating</li>
///<li>4: OSM_R26_SUBJECT_PERSON_ANIMAL_IDENTIFICATION (a Group object) optional </li>
///<li>5: OSM_R26_SUBJECT_POPULATION_LOCATION_IDENTIFICATION (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class OSM_R26_SPECIMEN : AbstractGroup {

	///<summary> 
	/// Creates a new OSM_R26_SPECIMEN Group.
	///</summary>
	public OSM_R26_SPECIMEN(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SPM), true, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(OSM_R26_SPECIMEN_OBSERVATION), false, true);
	      this.add(typeof(OSM_R26_CONTAINER), false, true);
	      this.add(typeof(OSM_R26_SUBJECT_PERSON_ANIMAL_IDENTIFICATION), false, false);
	      this.add(typeof(OSM_R26_SUBJECT_POPULATION_LOCATION_IDENTIFICATION), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OSM_R26_SPECIMEN - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns SPM (Specimen) - creates it if necessary
	///</summary>
	public SPM SPM { 
get{
	   SPM ret = null;
	   try {
	      ret = (SPM)this.GetStructure("SPM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PRT (Participation Information) - creates it if necessary
	///</summary>
	public PRT GetPRT() {
	   PRT ret = null;
	   try {
	      ret = (PRT)this.GetStructure("PRT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRT
	/// * (Participation Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRT GetPRT(int rep) { 
	   return (PRT)this.GetStructure("PRT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRT 
	 */ 
	public int PRTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of OSM_R26_SPECIMEN_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OSM_R26_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION() {
	   OSM_R26_SPECIMEN_OBSERVATION ret = null;
	   try {
	      ret = (OSM_R26_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OSM_R26_SPECIMEN_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OSM_R26_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION(int rep) { 
	   return (OSM_R26_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OSM_R26_SPECIMEN_OBSERVATION 
	 */ 
	public int SPECIMEN_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SPECIMEN_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of OSM_R26_CONTAINER (a Group object) - creates it if necessary
	///</summary>
	public OSM_R26_CONTAINER GetCONTAINER() {
	   OSM_R26_CONTAINER ret = null;
	   try {
	      ret = (OSM_R26_CONTAINER)this.GetStructure("CONTAINER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OSM_R26_CONTAINER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OSM_R26_CONTAINER GetCONTAINER(int rep) { 
	   return (OSM_R26_CONTAINER)this.GetStructure("CONTAINER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OSM_R26_CONTAINER 
	 */ 
	public int CONTAINERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CONTAINER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns OSM_R26_SUBJECT_PERSON_ANIMAL_IDENTIFICATION (a Group object) - creates it if necessary
	///</summary>
	public OSM_R26_SUBJECT_PERSON_ANIMAL_IDENTIFICATION SUBJECT_PERSON_ANIMAL_IDENTIFICATION { 
get{
	   OSM_R26_SUBJECT_PERSON_ANIMAL_IDENTIFICATION ret = null;
	   try {
	      ret = (OSM_R26_SUBJECT_PERSON_ANIMAL_IDENTIFICATION)this.GetStructure("SUBJECT_PERSON_ANIMAL_IDENTIFICATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns OSM_R26_SUBJECT_POPULATION_LOCATION_IDENTIFICATION (a Group object) - creates it if necessary
	///</summary>
	public OSM_R26_SUBJECT_POPULATION_LOCATION_IDENTIFICATION SUBJECT_POPULATION_LOCATION_IDENTIFICATION { 
get{
	   OSM_R26_SUBJECT_POPULATION_LOCATION_IDENTIFICATION ret = null;
	   try {
	      ret = (OSM_R26_SUBJECT_POPULATION_LOCATION_IDENTIFICATION)this.GetStructure("SUBJECT_POPULATION_LOCATION_IDENTIFICATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
