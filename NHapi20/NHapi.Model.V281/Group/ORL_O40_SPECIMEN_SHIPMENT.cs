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
///Represents the ORL_O40_SPECIMEN_SHIPMENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SHP (Shipment) </li>
///<li>1: ORL_O40_PACKAGE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORL_O40_SPECIMEN_SHIPMENT : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O40_SPECIMEN_SHIPMENT Group.
	///</summary>
	public ORL_O40_SPECIMEN_SHIPMENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SHP), true, false);
	      this.add(typeof(ORL_O40_PACKAGE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O40_SPECIMEN_SHIPMENT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns SHP (Shipment) - creates it if necessary
	///</summary>
	public SHP SHP { 
get{
	   SHP ret = null;
	   try {
	      ret = (SHP)this.GetStructure("SHP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORL_O40_PACKAGE (a Group object) - creates it if necessary
	///</summary>
	public ORL_O40_PACKAGE GetPACKAGE() {
	   ORL_O40_PACKAGE ret = null;
	   try {
	      ret = (ORL_O40_PACKAGE)this.GetStructure("PACKAGE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORL_O40_PACKAGE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORL_O40_PACKAGE GetPACKAGE(int rep) { 
	   return (ORL_O40_PACKAGE)this.GetStructure("PACKAGE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORL_O40_PACKAGE 
	 */ 
	public int PACKAGERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PACKAGE").Length; 
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
