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
///Represents the EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: IPR (Invoice Processing Results) </li>
///<li>1: IVC (Invoice Segment) </li>
///<li>2: EHC_E15_PRODUCT_SERVICE_SECTION (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO Group.
	///</summary>
	public EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(IPR), true, false);
	      this.add(typeof(IVC), true, false);
	      this.add(typeof(EHC_E15_PRODUCT_SERVICE_SECTION), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E15_PAYMENT_REMITTANCE_DETAIL_INFO - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns IPR (Invoice Processing Results) - creates it if necessary
	///</summary>
	public IPR IPR { 
get{
	   IPR ret = null;
	   try {
	      ret = (IPR)this.GetStructure("IPR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns IVC (Invoice Segment) - creates it if necessary
	///</summary>
	public IVC IVC { 
get{
	   IVC ret = null;
	   try {
	      ret = (IVC)this.GetStructure("IVC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of EHC_E15_PRODUCT_SERVICE_SECTION (a Group object) - creates it if necessary
	///</summary>
	public EHC_E15_PRODUCT_SERVICE_SECTION GetPRODUCT_SERVICE_SECTION() {
	   EHC_E15_PRODUCT_SERVICE_SECTION ret = null;
	   try {
	      ret = (EHC_E15_PRODUCT_SERVICE_SECTION)this.GetStructure("PRODUCT_SERVICE_SECTION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E15_PRODUCT_SERVICE_SECTION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E15_PRODUCT_SERVICE_SECTION GetPRODUCT_SERVICE_SECTION(int rep) { 
	   return (EHC_E15_PRODUCT_SERVICE_SECTION)this.GetStructure("PRODUCT_SERVICE_SECTION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E15_PRODUCT_SERVICE_SECTION 
	 */ 
	public int PRODUCT_SERVICE_SECTIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRODUCT_SERVICE_SECTION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EHC_E15_PRODUCT_SERVICE_SECTION results 
	 */ 
	public IEnumerable<EHC_E15_PRODUCT_SERVICE_SECTION> PRODUCT_SERVICE_SECTIONs 
	{ 
		get
		{
			for (int rep = 0; rep < PRODUCT_SERVICE_SECTIONRepetitionsUsed; rep++)
			{
				yield return (EHC_E15_PRODUCT_SERVICE_SECTION)this.GetStructure("PRODUCT_SERVICE_SECTION", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E15_PRODUCT_SERVICE_SECTION
	///</summary>
	public EHC_E15_PRODUCT_SERVICE_SECTION AddPRODUCT_SERVICE_SECTION()
	{
		return this.AddStructure("PRODUCT_SERVICE_SECTION") as EHC_E15_PRODUCT_SERVICE_SECTION;
	}

	///<summary>
	///Removes the given EHC_E15_PRODUCT_SERVICE_SECTION
	///</summary>
	public void RemovePRODUCT_SERVICE_SECTION(EHC_E15_PRODUCT_SERVICE_SECTION toRemove)
	{
		this.RemoveStructure("PRODUCT_SERVICE_SECTION", toRemove);
	}

	///<summary>
	///Removes the EHC_E15_PRODUCT_SERVICE_SECTION at the given index
	///</summary>
	public void RemovePRODUCT_SERVICE_SECTIONAt(int index)
	{
		this.RemoveRepetition("PRODUCT_SERVICE_SECTION", index);
	}

}
}
