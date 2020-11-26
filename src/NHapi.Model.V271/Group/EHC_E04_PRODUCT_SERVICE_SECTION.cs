using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V271.Segment;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V271.Group
{
///<summary>
///Represents the EHC_E04_PRODUCT_SERVICE_SECTION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSS (Product/Service Section) </li>
///<li>1: EHC_E04_PRODUCT_SERVICE_GROUP (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E04_PRODUCT_SERVICE_SECTION : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E04_PRODUCT_SERVICE_SECTION Group.
	///</summary>
	public EHC_E04_PRODUCT_SERVICE_SECTION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSS), true, false);
	      this.add(typeof(EHC_E04_PRODUCT_SERVICE_GROUP), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E04_PRODUCT_SERVICE_SECTION - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of EHC_E04_PRODUCT_SERVICE_GROUP (a Group object) - creates it if necessary
	///</summary>
	public EHC_E04_PRODUCT_SERVICE_GROUP GetPRODUCT_SERVICE_GROUP() {
	   EHC_E04_PRODUCT_SERVICE_GROUP ret = null;
	   try {
	      ret = (EHC_E04_PRODUCT_SERVICE_GROUP)this.GetStructure("PRODUCT_SERVICE_GROUP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E04_PRODUCT_SERVICE_GROUP
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E04_PRODUCT_SERVICE_GROUP GetPRODUCT_SERVICE_GROUP(int rep) { 
	   return (EHC_E04_PRODUCT_SERVICE_GROUP)this.GetStructure("PRODUCT_SERVICE_GROUP", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E04_PRODUCT_SERVICE_GROUP 
	 */ 
	public int PRODUCT_SERVICE_GROUPRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRODUCT_SERVICE_GROUP").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EHC_E04_PRODUCT_SERVICE_GROUP results 
	 */ 
	public IEnumerable<EHC_E04_PRODUCT_SERVICE_GROUP> PRODUCT_SERVICE_GROUPs 
	{ 
		get
		{
			for (int rep = 0; rep < PRODUCT_SERVICE_GROUPRepetitionsUsed; rep++)
			{
				yield return (EHC_E04_PRODUCT_SERVICE_GROUP)this.GetStructure("PRODUCT_SERVICE_GROUP", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E04_PRODUCT_SERVICE_GROUP
	///</summary>
	public EHC_E04_PRODUCT_SERVICE_GROUP AddPRODUCT_SERVICE_GROUP()
	{
		return this.AddStructure("PRODUCT_SERVICE_GROUP") as EHC_E04_PRODUCT_SERVICE_GROUP;
	}

	///<summary>
	///Removes the given EHC_E04_PRODUCT_SERVICE_GROUP
	///</summary>
	public void RemovePRODUCT_SERVICE_GROUP(EHC_E04_PRODUCT_SERVICE_GROUP toRemove)
	{
		this.RemoveStructure("PRODUCT_SERVICE_GROUP", toRemove);
	}

	///<summary>
	///Removes the EHC_E04_PRODUCT_SERVICE_GROUP at the given index
	///</summary>
	public void RemovePRODUCT_SERVICE_GROUPAt(int index)
	{
		this.RemoveRepetition("PRODUCT_SERVICE_GROUP", index);
	}

}
}
