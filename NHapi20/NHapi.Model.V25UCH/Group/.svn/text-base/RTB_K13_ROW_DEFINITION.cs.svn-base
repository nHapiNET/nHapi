using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V25UCH.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V25UCH.Group
{
///<summary>
///Represents the RTB_K13_ROW_DEFINITION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RDF (Table Row Definition) </li>
///<li>1: RDT (Table Row Data) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RTB_K13_ROW_DEFINITION : AbstractGroup {

	///<summary> 
	/// Creates a new RTB_K13_ROW_DEFINITION Group.
	///</summary>
	public RTB_K13_ROW_DEFINITION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RDF), true, false);
	      this.add(typeof(RDT), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RTB_K13_ROW_DEFINITION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RDF (Table Row Definition) - creates it if necessary
	///</summary>
	public RDF RDF { 
get{
	   RDF ret = null;
	   try {
	      ret = (RDF)this.GetStructure("RDF");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RDT (Table Row Data) - creates it if necessary
	///</summary>
	public RDT GetRDT() {
	   RDT ret = null;
	   try {
	      ret = (RDT)this.GetStructure("RDT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RDT
	/// * (Table Row Data) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RDT GetRDT(int rep) { 
	   return (RDT)this.GetStructure("RDT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RDT 
	 */ 
	public int RDTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RDT").Length; 
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
