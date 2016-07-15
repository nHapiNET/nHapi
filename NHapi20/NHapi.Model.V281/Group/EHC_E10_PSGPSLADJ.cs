using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the EHC_E10_PSGPSLADJ Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSG (Product/Service Group) </li>
///<li>1: EHC_E10_PRODUCT_SERVICE_LINE_INFO (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E10_PSGPSLADJ : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E10_PSGPSLADJ Group.
	///</summary>
	public EHC_E10_PSGPSLADJ(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSG), true, false);
	      this.add(typeof(EHC_E10_PRODUCT_SERVICE_LINE_INFO), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E10_PSGPSLADJ - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PSG (Product/Service Group) - creates it if necessary
	///</summary>
	public PSG PSG { 
get{
	   PSG ret = null;
	   try {
	      ret = (PSG)this.GetStructure("PSG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of EHC_E10_PRODUCT_SERVICE_LINE_INFO (a Group object) - creates it if necessary
	///</summary>
	public EHC_E10_PRODUCT_SERVICE_LINE_INFO GetPRODUCT_SERVICE_LINE_INFO() {
	   EHC_E10_PRODUCT_SERVICE_LINE_INFO ret = null;
	   try {
	      ret = (EHC_E10_PRODUCT_SERVICE_LINE_INFO)this.GetStructure("PRODUCT_SERVICE_LINE_INFO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E10_PRODUCT_SERVICE_LINE_INFO
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E10_PRODUCT_SERVICE_LINE_INFO GetPRODUCT_SERVICE_LINE_INFO(int rep) { 
	   return (EHC_E10_PRODUCT_SERVICE_LINE_INFO)this.GetStructure("PRODUCT_SERVICE_LINE_INFO", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E10_PRODUCT_SERVICE_LINE_INFO 
	 */ 
	public int PRODUCT_SERVICE_LINE_INFORepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRODUCT_SERVICE_LINE_INFO").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EHC_E10_PRODUCT_SERVICE_LINE_INFO results 
	 */ 
	public IEnumerable<EHC_E10_PRODUCT_SERVICE_LINE_INFO> PRODUCT_SERVICE_LINE_INFOs 
	{ 
		get
		{
			for (int rep = 0; rep < PRODUCT_SERVICE_LINE_INFORepetitionsUsed; rep++)
			{
				yield return (EHC_E10_PRODUCT_SERVICE_LINE_INFO)this.GetStructure("PRODUCT_SERVICE_LINE_INFO", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E10_PRODUCT_SERVICE_LINE_INFO
	///</summary>
	public EHC_E10_PRODUCT_SERVICE_LINE_INFO AddPRODUCT_SERVICE_LINE_INFO()
	{
		return this.AddStructure("PRODUCT_SERVICE_LINE_INFO") as EHC_E10_PRODUCT_SERVICE_LINE_INFO;
	}

	///<summary>
	///Removes the given EHC_E10_PRODUCT_SERVICE_LINE_INFO
	///</summary>
	public void RemovePRODUCT_SERVICE_LINE_INFO(EHC_E10_PRODUCT_SERVICE_LINE_INFO toRemove)
	{
		this.RemoveStructure("PRODUCT_SERVICE_LINE_INFO", toRemove);
	}

	///<summary>
	///Removes the EHC_E10_PRODUCT_SERVICE_LINE_INFO at the given index
	///</summary>
	public void RemovePRODUCT_SERVICE_LINE_INFOAt(int index)
	{
		this.RemoveRepetition("PRODUCT_SERVICE_LINE_INFO", index);
	}

}
}
