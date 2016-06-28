using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V28.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the EHC_E10_PSSPSGPSLADJ Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSS (Product/Service Section) </li>
///<li>1: EHC_E10_PSGPSLADJ (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E10_PSSPSGPSLADJ : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E10_PSSPSGPSLADJ Group.
	///</summary>
	public EHC_E10_PSSPSGPSLADJ(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSS), true, false);
	      this.add(typeof(EHC_E10_PSGPSLADJ), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E10_PSSPSGPSLADJ - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PSS (Product/Service Section) - creates it if necessary
	///</summary>
	public PSS PSS { 
get{
	   PSS ret = null;
	   try {
	      ret = (PSS)this.GetStructure("PSS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of EHC_E10_PSGPSLADJ (a Group object) - creates it if necessary
	///</summary>
	public EHC_E10_PSGPSLADJ GetPSGPSLADJ() {
	   EHC_E10_PSGPSLADJ ret = null;
	   try {
	      ret = (EHC_E10_PSGPSLADJ)this.GetStructure("PSGPSLADJ");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E10_PSGPSLADJ
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E10_PSGPSLADJ GetPSGPSLADJ(int rep) { 
	   return (EHC_E10_PSGPSLADJ)this.GetStructure("PSGPSLADJ", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E10_PSGPSLADJ 
	 */ 
	public int PSGPSLADJRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PSGPSLADJ").Length; 
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
