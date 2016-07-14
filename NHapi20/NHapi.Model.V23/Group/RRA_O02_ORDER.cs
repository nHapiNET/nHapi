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
///Represents the RRA_O02_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common order segment) </li>
///<li>1: RRA_O02_ADMINISTRATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RRA_O02_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RRA_O02_ORDER Group.
	///</summary>
	public RRA_O02_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(RRA_O02_ADMINISTRATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RRA_O02_ORDER - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORC (Common order segment) - creates it if necessary
	///</summary>
	public ORC ORC { 
get{
	   ORC ret = null;
	   try {
	      ret = (ORC)this.GetStructure("ORC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RRA_O02_ADMINISTRATION (a Group object) - creates it if necessary
	///</summary>
	public RRA_O02_ADMINISTRATION GetADMINISTRATION() {
	   RRA_O02_ADMINISTRATION ret = null;
	   try {
	      ret = (RRA_O02_ADMINISTRATION)this.GetStructure("ADMINISTRATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RRA_O02_ADMINISTRATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RRA_O02_ADMINISTRATION GetADMINISTRATION(int rep) { 
	   return (RRA_O02_ADMINISTRATION)this.GetStructure("ADMINISTRATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RRA_O02_ADMINISTRATION 
	 */ 
	public int ADMINISTRATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ADMINISTRATION").Length; 
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
