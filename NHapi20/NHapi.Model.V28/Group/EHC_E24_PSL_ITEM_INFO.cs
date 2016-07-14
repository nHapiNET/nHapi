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
///Represents the EHC_E24_PSL_ITEM_INFO Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSL (Product/Service Line Item) </li>
///<li>1: AUT (Authorization Information) optional </li>
///<li>2: ADJ (Adjustment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E24_PSL_ITEM_INFO : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E24_PSL_ITEM_INFO Group.
	///</summary>
	public EHC_E24_PSL_ITEM_INFO(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSL), true, false);
	      this.add(typeof(AUT), false, false);
	      this.add(typeof(ADJ), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E24_PSL_ITEM_INFO - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PSL (Product/Service Line Item) - creates it if necessary
	///</summary>
	public PSL PSL { 
get{
	   PSL ret = null;
	   try {
	      ret = (PSL)this.GetStructure("PSL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AUT (Authorization Information) - creates it if necessary
	///</summary>
	public AUT AUT { 
get{
	   AUT ret = null;
	   try {
	      ret = (AUT)this.GetStructure("AUT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ADJ (Adjustment) - creates it if necessary
	///</summary>
	public ADJ GetADJ() {
	   ADJ ret = null;
	   try {
	      ret = (ADJ)this.GetStructure("ADJ");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ADJ
	/// * (Adjustment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ADJ GetADJ(int rep) { 
	   return (ADJ)this.GetStructure("ADJ", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ADJ 
	 */ 
	public int ADJRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ADJ").Length; 
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
