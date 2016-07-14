using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the EHC_E02_PRODUCT_SERVICE_SECTION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSS (Product/Service Section) </li>
///<li>1: EHC_E02_PSG (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E02_PRODUCT_SERVICE_SECTION : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E02_PRODUCT_SERVICE_SECTION Group.
	///</summary>
	public EHC_E02_PRODUCT_SERVICE_SECTION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSS), true, false);
	      this.add(typeof(EHC_E02_PSG), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E02_PRODUCT_SERVICE_SECTION - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of EHC_E02_PSG (a Group object) - creates it if necessary
	///</summary>
	public EHC_E02_PSG GetPSG() {
	   EHC_E02_PSG ret = null;
	   try {
	      ret = (EHC_E02_PSG)this.GetStructure("PSG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E02_PSG
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E02_PSG GetPSG(int rep) { 
	   return (EHC_E02_PSG)this.GetStructure("PSG", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E02_PSG 
	 */ 
	public int PSGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PSG").Length; 
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
