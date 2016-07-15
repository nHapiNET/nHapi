using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V27.Segment;
using NHapi.Model.V27.Datatype;
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

	/** 
	 * Enumerate over the LOC results 
	 */ 
	public IEnumerable<LOC> LOCs 
	{ 
		get
		{
			for (int rep = 0; rep < LOCRepetitionsUsed; rep++)
			{
				yield return (LOC)this.GetStructure("LOC", rep);
			}
		}
	}

	///<summary>
	///Adds a new LOC
	///</summary>
	public LOC AddLOC()
	{
		return this.AddStructure("LOC") as LOC;
	}

	///<summary>
	///Removes the given LOC
	///</summary>
	public void RemoveLOC(LOC toRemove)
	{
		this.RemoveStructure("LOC", toRemove);
	}

	///<summary>
	///Removes the LOC at the given index
	///</summary>
	public void RemoveLOCAt(int index)
	{
		this.RemoveRepetition("LOC", index);
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

	/** 
	 * Enumerate over the ROL results 
	 */ 
	public IEnumerable<ROL> ROLs 
	{ 
		get
		{
			for (int rep = 0; rep < ROLRepetitionsUsed; rep++)
			{
				yield return (ROL)this.GetStructure("ROL", rep);
			}
		}
	}

	///<summary>
	///Adds a new ROL
	///</summary>
	public ROL AddROL()
	{
		return this.AddStructure("ROL") as ROL;
	}

	///<summary>
	///Removes the given ROL
	///</summary>
	public void RemoveROL(ROL toRemove)
	{
		this.RemoveStructure("ROL", toRemove);
	}

	///<summary>
	///Removes the ROL at the given index
	///</summary>
	public void RemoveROLAt(int index)
	{
		this.RemoveRepetition("ROL", index);
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

	/** 
	 * Enumerate over the EHC_E01_PATIENT_INFO results 
	 */ 
	public IEnumerable<EHC_E01_PATIENT_INFO> PATIENT_INFOs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENT_INFORepetitionsUsed; rep++)
			{
				yield return (EHC_E01_PATIENT_INFO)this.GetStructure("PATIENT_INFO", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E01_PATIENT_INFO
	///</summary>
	public EHC_E01_PATIENT_INFO AddPATIENT_INFO()
	{
		return this.AddStructure("PATIENT_INFO") as EHC_E01_PATIENT_INFO;
	}

	///<summary>
	///Removes the given EHC_E01_PATIENT_INFO
	///</summary>
	public void RemovePATIENT_INFO(EHC_E01_PATIENT_INFO toRemove)
	{
		this.RemoveStructure("PATIENT_INFO", toRemove);
	}

	///<summary>
	///Removes the EHC_E01_PATIENT_INFO at the given index
	///</summary>
	public void RemovePATIENT_INFOAt(int index)
	{
		this.RemoveRepetition("PATIENT_INFO", index);
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

	/** 
	 * Enumerate over the EHC_E01_PRODUCT_SERVICE_LINE_ITEM results 
	 */ 
	public IEnumerable<EHC_E01_PRODUCT_SERVICE_LINE_ITEM> PRODUCT_SERVICE_LINE_ITEMs 
	{ 
		get
		{
			for (int rep = 0; rep < PRODUCT_SERVICE_LINE_ITEMRepetitionsUsed; rep++)
			{
				yield return (EHC_E01_PRODUCT_SERVICE_LINE_ITEM)this.GetStructure("PRODUCT_SERVICE_LINE_ITEM", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E01_PRODUCT_SERVICE_LINE_ITEM
	///</summary>
	public EHC_E01_PRODUCT_SERVICE_LINE_ITEM AddPRODUCT_SERVICE_LINE_ITEM()
	{
		return this.AddStructure("PRODUCT_SERVICE_LINE_ITEM") as EHC_E01_PRODUCT_SERVICE_LINE_ITEM;
	}

	///<summary>
	///Removes the given EHC_E01_PRODUCT_SERVICE_LINE_ITEM
	///</summary>
	public void RemovePRODUCT_SERVICE_LINE_ITEM(EHC_E01_PRODUCT_SERVICE_LINE_ITEM toRemove)
	{
		this.RemoveStructure("PRODUCT_SERVICE_LINE_ITEM", toRemove);
	}

	///<summary>
	///Removes the EHC_E01_PRODUCT_SERVICE_LINE_ITEM at the given index
	///</summary>
	public void RemovePRODUCT_SERVICE_LINE_ITEMAt(int index)
	{
		this.RemoveRepetition("PRODUCT_SERVICE_LINE_ITEM", index);
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

	/** 
	 * Enumerate over the EHC_E01_PROCEDURE results 
	 */ 
	public IEnumerable<EHC_E01_PROCEDURE> PROCEDUREs 
	{ 
		get
		{
			for (int rep = 0; rep < PROCEDURERepetitionsUsed; rep++)
			{
				yield return (EHC_E01_PROCEDURE)this.GetStructure("PROCEDURE", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E01_PROCEDURE
	///</summary>
	public EHC_E01_PROCEDURE AddPROCEDURE()
	{
		return this.AddStructure("PROCEDURE") as EHC_E01_PROCEDURE;
	}

	///<summary>
	///Removes the given EHC_E01_PROCEDURE
	///</summary>
	public void RemovePROCEDURE(EHC_E01_PROCEDURE toRemove)
	{
		this.RemoveStructure("PROCEDURE", toRemove);
	}

	///<summary>
	///Removes the EHC_E01_PROCEDURE at the given index
	///</summary>
	public void RemovePROCEDUREAt(int index)
	{
		this.RemoveRepetition("PROCEDURE", index);
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

	/** 
	 * Enumerate over the EHC_E01_INVOICE_PROCESSING results 
	 */ 
	public IEnumerable<EHC_E01_INVOICE_PROCESSING> INVOICE_PROCESSINGs 
	{ 
		get
		{
			for (int rep = 0; rep < INVOICE_PROCESSINGRepetitionsUsed; rep++)
			{
				yield return (EHC_E01_INVOICE_PROCESSING)this.GetStructure("INVOICE_PROCESSING", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E01_INVOICE_PROCESSING
	///</summary>
	public EHC_E01_INVOICE_PROCESSING AddINVOICE_PROCESSING()
	{
		return this.AddStructure("INVOICE_PROCESSING") as EHC_E01_INVOICE_PROCESSING;
	}

	///<summary>
	///Removes the given EHC_E01_INVOICE_PROCESSING
	///</summary>
	public void RemoveINVOICE_PROCESSING(EHC_E01_INVOICE_PROCESSING toRemove)
	{
		this.RemoveStructure("INVOICE_PROCESSING", toRemove);
	}

	///<summary>
	///Removes the EHC_E01_INVOICE_PROCESSING at the given index
	///</summary>
	public void RemoveINVOICE_PROCESSINGAt(int index)
	{
		this.RemoveRepetition("INVOICE_PROCESSING", index);
	}

}
}
