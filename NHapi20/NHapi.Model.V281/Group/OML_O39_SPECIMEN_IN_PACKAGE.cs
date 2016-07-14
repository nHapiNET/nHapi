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
///Represents the OML_O39_SPECIMEN_IN_PACKAGE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SPM (Specimen) </li>
///<li>1: OML_O39_SPECIMEN_OBSERVATION (a Group object) optional repeating</li>
///<li>2: OML_O39_SPECIMEN_CONTAINER_IN_PACKAGE (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class OML_O39_SPECIMEN_IN_PACKAGE : AbstractGroup {

	///<summary> 
	/// Creates a new OML_O39_SPECIMEN_IN_PACKAGE Group.
	///</summary>
	public OML_O39_SPECIMEN_IN_PACKAGE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SPM), true, false);
	      this.add(typeof(OML_O39_SPECIMEN_OBSERVATION), false, true);
	      this.add(typeof(OML_O39_SPECIMEN_CONTAINER_IN_PACKAGE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OML_O39_SPECIMEN_IN_PACKAGE - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of OML_O39_SPECIMEN_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public OML_O39_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION() {
	   OML_O39_SPECIMEN_OBSERVATION ret = null;
	   try {
	      ret = (OML_O39_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O39_SPECIMEN_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O39_SPECIMEN_OBSERVATION GetSPECIMEN_OBSERVATION(int rep) { 
	   return (OML_O39_SPECIMEN_OBSERVATION)this.GetStructure("SPECIMEN_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O39_SPECIMEN_OBSERVATION 
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
	/// Returns  first repetition of OML_O39_SPECIMEN_CONTAINER_IN_PACKAGE (a Group object) - creates it if necessary
	///</summary>
	public OML_O39_SPECIMEN_CONTAINER_IN_PACKAGE GetSPECIMEN_CONTAINER_IN_PACKAGE() {
	   OML_O39_SPECIMEN_CONTAINER_IN_PACKAGE ret = null;
	   try {
	      ret = (OML_O39_SPECIMEN_CONTAINER_IN_PACKAGE)this.GetStructure("SPECIMEN_CONTAINER_IN_PACKAGE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OML_O39_SPECIMEN_CONTAINER_IN_PACKAGE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OML_O39_SPECIMEN_CONTAINER_IN_PACKAGE GetSPECIMEN_CONTAINER_IN_PACKAGE(int rep) { 
	   return (OML_O39_SPECIMEN_CONTAINER_IN_PACKAGE)this.GetStructure("SPECIMEN_CONTAINER_IN_PACKAGE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OML_O39_SPECIMEN_CONTAINER_IN_PACKAGE 
	 */ 
	public int SPECIMEN_CONTAINER_IN_PACKAGERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SPECIMEN_CONTAINER_IN_PACKAGE").Length; 
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
