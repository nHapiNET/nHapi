using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V281.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the ORL_O44_PACKAGE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PAC (Shipment Package) </li>
///<li>1: ORL_O44_SPECIMEN_IN_PACKAGE (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORL_O44_PACKAGE : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O44_PACKAGE Group.
	///</summary>
	public ORL_O44_PACKAGE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PAC), true, false);
	      this.add(typeof(ORL_O44_SPECIMEN_IN_PACKAGE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O44_PACKAGE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PAC (Shipment Package) - creates it if necessary
	///</summary>
	public PAC PAC { 
get{
	   PAC ret = null;
	   try {
	      ret = (PAC)this.GetStructure("PAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORL_O44_SPECIMEN_IN_PACKAGE (a Group object) - creates it if necessary
	///</summary>
	public ORL_O44_SPECIMEN_IN_PACKAGE GetSPECIMEN_IN_PACKAGE() {
	   ORL_O44_SPECIMEN_IN_PACKAGE ret = null;
	   try {
	      ret = (ORL_O44_SPECIMEN_IN_PACKAGE)this.GetStructure("SPECIMEN_IN_PACKAGE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORL_O44_SPECIMEN_IN_PACKAGE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORL_O44_SPECIMEN_IN_PACKAGE GetSPECIMEN_IN_PACKAGE(int rep) { 
	   return (ORL_O44_SPECIMEN_IN_PACKAGE)this.GetStructure("SPECIMEN_IN_PACKAGE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORL_O44_SPECIMEN_IN_PACKAGE 
	 */ 
	public int SPECIMEN_IN_PACKAGERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SPECIMEN_IN_PACKAGE").Length; 
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
