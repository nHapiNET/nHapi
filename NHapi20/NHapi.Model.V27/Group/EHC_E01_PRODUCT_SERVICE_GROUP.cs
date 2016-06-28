using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V27.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the EHC_E01_PRODUCT_SERVICE_GROUP Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSG (Product/Service Group) </li>
///<li>1: LOC (Location Identification) optional repeating</li>
///<li>2: ROL (Role) optional repeating</li>
///<li>3: EHC_E01_PATIENT_INFO (a Group object) optional repeating</li>
///<li>4: EHC_E01_PRODUCT_SERVICE_LINE_ITEM (a Group object) repeating</li>
///<li>5: EHC_E01_PROCEDURE (a Group object) optional repeating</li>
///<li>6: EHC_E01_INVOICE_PROCESSING (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E01_PRODUCT_SERVICE_GROUP : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E01_PRODUCT_SERVICE_GROUP Group.
	///</summary>
	public EHC_E01_PRODUCT_SERVICE_GROUP(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSG), true, false);
	      this.add(typeof(LOC), false, true);
	      this.add(typeof(ROL), false, true);
	      this.add(typeof(EHC_E01_PATIENT_INFO), false, true);
	      this.add(typeof(EHC_E01_PRODUCT_SERVICE_LINE_ITEM), true, true);
	      this.add(typeof(EHC_E01_PROCEDURE), false, true);
	      this.add(typeof(EHC_E01_INVOICE_PROCESSING), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E01_PRODUCT_SERVICE_GROUP - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of LOC (Location Identification) - creates it if necessary
	///</summary>
	public LOC GetLOC() {
	   LOC ret = null;
	   try {
	      ret = (LOC)this.GetStructure("LOC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of LOC
	/// * (Location Identification) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public LOC GetLOC(int rep) { 
	   return (LOC)this.GetStructure("LOC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of LOC 
	 */ 
	public int LOCRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LOC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of ROL (Role) - creates it if necessary
	///</summary>
	public ROL GetROL() {
	   ROL ret = null;
	   try {
	      ret = (ROL)this.GetStructure("ROL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ROL
	/// * (Role) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ROL GetROL(int rep) { 
	   return (ROL)this.GetStructure("ROL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ROL 
	 */ 
	public int ROLRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ROL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of EHC_E01_PATIENT_INFO (a Group object) - creates it if necessary
	///</summary>
	public EHC_E01_PATIENT_INFO GetPATIENT_INFO() {
	   EHC_E01_PATIENT_INFO ret = null;
	   try {
	      ret = (EHC_E01_PATIENT_INFO)this.GetStructure("PATIENT_INFO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E01_PATIENT_INFO
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E01_PATIENT_INFO GetPATIENT_INFO(int rep) { 
	   return (EHC_E01_PATIENT_INFO)this.GetStructure("PATIENT_INFO", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E01_PATIENT_INFO 
	 */ 
	public int PATIENT_INFORepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATIENT_INFO").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of EHC_E01_PRODUCT_SERVICE_LINE_ITEM (a Group object) - creates it if necessary
	///</summary>
	public EHC_E01_PRODUCT_SERVICE_LINE_ITEM GetPRODUCT_SERVICE_LINE_ITEM() {
	   EHC_E01_PRODUCT_SERVICE_LINE_ITEM ret = null;
	   try {
	      ret = (EHC_E01_PRODUCT_SERVICE_LINE_ITEM)this.GetStructure("PRODUCT_SERVICE_LINE_ITEM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E01_PRODUCT_SERVICE_LINE_ITEM
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E01_PRODUCT_SERVICE_LINE_ITEM GetPRODUCT_SERVICE_LINE_ITEM(int rep) { 
	   return (EHC_E01_PRODUCT_SERVICE_LINE_ITEM)this.GetStructure("PRODUCT_SERVICE_LINE_ITEM", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E01_PRODUCT_SERVICE_LINE_ITEM 
	 */ 
	public int PRODUCT_SERVICE_LINE_ITEMRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRODUCT_SERVICE_LINE_ITEM").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of EHC_E01_PROCEDURE (a Group object) - creates it if necessary
	///</summary>
	public EHC_E01_PROCEDURE GetPROCEDURE() {
	   EHC_E01_PROCEDURE ret = null;
	   try {
	      ret = (EHC_E01_PROCEDURE)this.GetStructure("PROCEDURE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E01_PROCEDURE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E01_PROCEDURE GetPROCEDURE(int rep) { 
	   return (EHC_E01_PROCEDURE)this.GetStructure("PROCEDURE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E01_PROCEDURE 
	 */ 
	public int PROCEDURERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PROCEDURE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of EHC_E01_INVOICE_PROCESSING (a Group object) - creates it if necessary
	///</summary>
	public EHC_E01_INVOICE_PROCESSING GetINVOICE_PROCESSING() {
	   EHC_E01_INVOICE_PROCESSING ret = null;
	   try {
	      ret = (EHC_E01_INVOICE_PROCESSING)this.GetStructure("INVOICE_PROCESSING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E01_INVOICE_PROCESSING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E01_INVOICE_PROCESSING GetINVOICE_PROCESSING(int rep) { 
	   return (EHC_E01_INVOICE_PROCESSING)this.GetStructure("INVOICE_PROCESSING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E01_INVOICE_PROCESSING 
	 */ 
	public int INVOICE_PROCESSINGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("INVOICE_PROCESSING").Length; 
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
