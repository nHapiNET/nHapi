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
///Represents the EHC_E24_PSL_ITEM_INFO Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSL (Product/Service Line Item) </li>
///<li>1: AUT (Authorization Information) optional </li>
///<li>2: EHC_E24_PAYER_ADJUSTMENT (a Group object) optional repeating</li>
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
	      this.add(typeof(EHC_E24_PAYER_ADJUSTMENT), false, true);
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
	/// Returns  first repetition of EHC_E24_PAYER_ADJUSTMENT (a Group object) - creates it if necessary
	///</summary>
	public EHC_E24_PAYER_ADJUSTMENT GetPAYER_ADJUSTMENT() {
	   EHC_E24_PAYER_ADJUSTMENT ret = null;
	   try {
	      ret = (EHC_E24_PAYER_ADJUSTMENT)this.GetStructure("PAYER_ADJUSTMENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E24_PAYER_ADJUSTMENT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E24_PAYER_ADJUSTMENT GetPAYER_ADJUSTMENT(int rep) { 
	   return (EHC_E24_PAYER_ADJUSTMENT)this.GetStructure("PAYER_ADJUSTMENT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E24_PAYER_ADJUSTMENT 
	 */ 
	public int PAYER_ADJUSTMENTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PAYER_ADJUSTMENT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EHC_E24_PAYER_ADJUSTMENT results 
	 */ 
	public IEnumerable<EHC_E24_PAYER_ADJUSTMENT> PAYER_ADJUSTMENTs 
	{ 
		get
		{
			for (int rep = 0; rep < PAYER_ADJUSTMENTRepetitionsUsed; rep++)
			{
				yield return (EHC_E24_PAYER_ADJUSTMENT)this.GetStructure("PAYER_ADJUSTMENT", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E24_PAYER_ADJUSTMENT
	///</summary>
	public EHC_E24_PAYER_ADJUSTMENT AddPAYER_ADJUSTMENT()
	{
		return this.AddStructure("PAYER_ADJUSTMENT") as EHC_E24_PAYER_ADJUSTMENT;
	}

	///<summary>
	///Removes the given EHC_E24_PAYER_ADJUSTMENT
	///</summary>
	public void RemovePAYER_ADJUSTMENT(EHC_E24_PAYER_ADJUSTMENT toRemove)
	{
		this.RemoveStructure("PAYER_ADJUSTMENT", toRemove);
	}

	///<summary>
	///Removes the EHC_E24_PAYER_ADJUSTMENT at the given index
	///</summary>
	public void RemovePAYER_ADJUSTMENTAt(int index)
	{
		this.RemoveRepetition("PAYER_ADJUSTMENT", index);
	}

}
}
