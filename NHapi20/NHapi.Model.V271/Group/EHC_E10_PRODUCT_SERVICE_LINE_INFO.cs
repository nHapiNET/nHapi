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
///Represents the EHC_E10_PRODUCT_SERVICE_LINE_INFO Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSL (Product/Service Line Item) </li>
///<li>1: ADJ (Adjustment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E10_PRODUCT_SERVICE_LINE_INFO : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E10_PRODUCT_SERVICE_LINE_INFO Group.
	///</summary>
	public EHC_E10_PRODUCT_SERVICE_LINE_INFO(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSL), true, false);
	      this.add(typeof(ADJ), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E10_PRODUCT_SERVICE_LINE_INFO - this is probably a bug in the source code generator.", e);
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

	/** 
	 * Enumerate over the ADJ results 
	 */ 
	public IEnumerable<ADJ> ADJs 
	{ 
		get
		{
			for (int rep = 0; rep < ADJRepetitionsUsed; rep++)
			{
				yield return (ADJ)this.GetStructure("ADJ", rep);
			}
		}
	}

	///<summary>
	///Adds a new ADJ
	///</summary>
	public ADJ AddADJ()
	{
		return this.AddStructure("ADJ") as ADJ;
	}

	///<summary>
	///Removes the given ADJ
	///</summary>
	public void RemoveADJ(ADJ toRemove)
	{
		this.RemoveStructure("ADJ", toRemove);
	}

	///<summary>
	///Removes the ADJ at the given index
	///</summary>
	public void RemoveADJAt(int index)
	{
		this.RemoveRepetition("ADJ", index);
	}

}
}
