using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V24.Group;
using NHapi.Model.V24.Segment;
using NHapi.Model.V24.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V24.Message

{
///<summary>
/// Represents a DOC_T12 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: MSA (Message Acknowledgment) </li>
///<li>2: ERR (Error) optional </li>
///<li>3: QAK (Query Acknowledgment) optional </li>
///<li>4: QRD (Original-Style Query Definition) </li>
///<li>5: DOC_T12_RESULT (a Group object) repeating</li>
///<li>6: DSC (Continuation Pointer) optional </li>
///</ol>
///</summary>
[Serializable]
public class DOC_T12 : AbstractMessage  {

	///<summary> 
	/// Creates a new DOC_T12 Group with custom IModelClassFactory.
	///</summary>
	public DOC_T12(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new DOC_T12 Group with DefaultModelClassFactory. 
	///</summary> 
	public DOC_T12() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for DOC_T12.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(ERR), false, false);
	      this.add(typeof(QAK), false, false);
	      this.add(typeof(QRD), true, false);
	      this.add(typeof(DOC_T12_RESULT), true, true);
	      this.add(typeof(DSC), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating DOC_T12 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (Message Header) - creates it if necessary
	///</summary>
	public MSH MSH { 
get{
	   MSH ret = null;
	   try {
	      ret = (MSH)this.GetStructure("MSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns MSA (Message Acknowledgment) - creates it if necessary
	///</summary>
	public MSA MSA { 
get{
	   MSA ret = null;
	   try {
	      ret = (MSA)this.GetStructure("MSA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ERR (Error) - creates it if necessary
	///</summary>
	public ERR ERR { 
get{
	   ERR ret = null;
	   try {
	      ret = (ERR)this.GetStructure("ERR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns QAK (Query Acknowledgment) - creates it if necessary
	///</summary>
	public QAK QAK { 
get{
	   QAK ret = null;
	   try {
	      ret = (QAK)this.GetStructure("QAK");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns QRD (Original-Style Query Definition) - creates it if necessary
	///</summary>
	public QRD QRD { 
get{
	   QRD ret = null;
	   try {
	      ret = (QRD)this.GetStructure("QRD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of DOC_T12_RESULT (a Group object) - creates it if necessary
	///</summary>
	public DOC_T12_RESULT GetRESULT() {
	   DOC_T12_RESULT ret = null;
	   try {
	      ret = (DOC_T12_RESULT)this.GetStructure("RESULT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DOC_T12_RESULT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DOC_T12_RESULT GetRESULT(int rep) { 
	   return (DOC_T12_RESULT)this.GetStructure("RESULT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DOC_T12_RESULT 
	 */ 
	public int RESULTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RESULT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DOC_T12_RESULT results 
	 */ 
	public IEnumerable<DOC_T12_RESULT> RESULTs 
	{ 
		get
		{
			for (int rep = 0; rep < RESULTRepetitionsUsed; rep++)
			{
				yield return (DOC_T12_RESULT)this.GetStructure("RESULT", rep);
			}
		}
	}

	///<summary>
	///Adds a new DOC_T12_RESULT
	///</summary>
	public DOC_T12_RESULT AddRESULT()
	{
		return this.AddStructure("RESULT") as DOC_T12_RESULT;
	}

	///<summary>
	///Removes the given DOC_T12_RESULT
	///</summary>
	public void RemoveRESULT(DOC_T12_RESULT toRemove)
	{
		this.RemoveStructure("RESULT", toRemove);
	}

	///<summary>
	///Removes the DOC_T12_RESULT at the given index
	///</summary>
	public void RemoveRESULTAt(int index)
	{
		this.RemoveRepetition("RESULT", index);
	}

	///<summary>
	/// Returns DSC (Continuation Pointer) - creates it if necessary
	///</summary>
	public DSC DSC { 
get{
	   DSC ret = null;
	   try {
	      ret = (DSC)this.GetStructure("DSC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
