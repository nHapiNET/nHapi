using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V23.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V23.Group
{
///<summary>
///Represents the MFN_M05_MF_LOCATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFE (Master file entry segment) </li>
///<li>1: LOC (Location Identification) </li>
///<li>2: LCH (Location Characteristic) optional repeating</li>
///<li>3: LRL (Location Relationship) optional repeating</li>
///<li>4: MFN_M05_MF_LOC_DEPT (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M05_MF_LOCATION : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M05_MF_LOCATION Group.
	///</summary>
	public MFN_M05_MF_LOCATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFE), true, false);
	      this.add(typeof(LOC), true, false);
	      this.add(typeof(LCH), false, true);
	      this.add(typeof(LRL), false, true);
	      this.add(typeof(MFN_M05_MF_LOC_DEPT), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M05_MF_LOCATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns MFE (Master file entry segment) - creates it if necessary
	///</summary>
	public MFE MFE { 
get{
	   MFE ret = null;
	   try {
	      ret = (MFE)this.GetStructure("MFE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns LOC (Location Identification) - creates it if necessary
	///</summary>
	public LOC LOC { 
get{
	   LOC ret = null;
	   try {
	      ret = (LOC)this.GetStructure("LOC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of LCH (Location Characteristic) - creates it if necessary
	///</summary>
	public LCH GetLCH() {
	   LCH ret = null;
	   try {
	      ret = (LCH)this.GetStructure("LCH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LCH
	/// * (Location Characteristic) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LCH GetLCH(int rep) { 
	   return (LCH)this.GetStructure("LCH", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LCH 
	 */ 
	public int LCHRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LCH").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of LRL (Location Relationship) - creates it if necessary
	///</summary>
	public LRL GetLRL() {
	   LRL ret = null;
	   try {
	      ret = (LRL)this.GetStructure("LRL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LRL
	/// * (Location Relationship) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LRL GetLRL(int rep) { 
	   return (LRL)this.GetStructure("LRL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LRL 
	 */ 
	public int LRLRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LRL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of MFN_M05_MF_LOC_DEPT (a Group object) - creates it if necessary
	///</summary>
	public MFN_M05_MF_LOC_DEPT GetMF_LOC_DEPT() {
	   MFN_M05_MF_LOC_DEPT ret = null;
	   try {
	      ret = (MFN_M05_MF_LOC_DEPT)this.GetStructure("MF_LOC_DEPT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M05_MF_LOC_DEPT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M05_MF_LOC_DEPT GetMF_LOC_DEPT(int rep) { 
	   return (MFN_M05_MF_LOC_DEPT)this.GetStructure("MF_LOC_DEPT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M05_MF_LOC_DEPT 
	 */ 
	public int MF_LOC_DEPTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_LOC_DEPT").Length; 
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
