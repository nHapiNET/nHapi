using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V22.Group;
using NHapi.Model.V22.Segment;
using NHapi.Model.V22.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V22.Message

{
///<summary>
/// Represents a ORU_R01 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MESSAGE HEADER) </li>
///<li>1: ORU_R01_PATIENT_RESULT (a Group object) repeating</li>
///<li>2: DSC (CONTINUATION POINTER) optional </li>
///</ol>
///</summary>
[Serializable]
public class ORU_R01 : AbstractMessage  {

	///<summary> 
	/// Creates a new ORU_R01 Group with custom IModelClassFactory.
	///</summary>
	public ORU_R01(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new ORU_R01 Group with DefaultModelClassFactory. 
	///</summary> 
	public ORU_R01() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for ORU_R01.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(ORU_R01_PATIENT_RESULT), true, true);
	      this.add(typeof(DSC), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORU_R01 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MESSAGE HEADER) - creates it if necessary
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
	/// Returns  first repetition of ORU_R01_PATIENT_RESULT (a Group object) - creates it if necessary
	///</summary>
	public ORU_R01_PATIENT_RESULT GetPATIENT_RESULT() {
	   ORU_R01_PATIENT_RESULT ret = null;
	   try {
	      ret = (ORU_R01_PATIENT_RESULT)this.GetStructure("PATIENT_RESULT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORU_R01_PATIENT_RESULT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORU_R01_PATIENT_RESULT GetPATIENT_RESULT(int rep) { 
	   return (ORU_R01_PATIENT_RESULT)this.GetStructure("PATIENT_RESULT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORU_R01_PATIENT_RESULT 
	 */ 
	public int PATIENT_RESULTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATIENT_RESULT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORU_R01_PATIENT_RESULT results 
	 */ 
	public IEnumerable<ORU_R01_PATIENT_RESULT> PATIENT_RESULTs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENT_RESULTRepetitionsUsed; rep++)
			{
				yield return (ORU_R01_PATIENT_RESULT)this.GetStructure("PATIENT_RESULT", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORU_R01_PATIENT_RESULT
	///</summary>
	public ORU_R01_PATIENT_RESULT AddPATIENT_RESULT()
	{
		return this.AddStructure("PATIENT_RESULT") as ORU_R01_PATIENT_RESULT;
	}

	///<summary>
	///Removes the given ORU_R01_PATIENT_RESULT
	///</summary>
	public void RemovePATIENT_RESULT(ORU_R01_PATIENT_RESULT toRemove)
	{
		this.RemoveStructure("PATIENT_RESULT", toRemove);
	}

	///<summary>
	///Removes the ORU_R01_PATIENT_RESULT at the given index
	///</summary>
	public void RemovePATIENT_RESULTAt(int index)
	{
		this.RemoveRepetition("PATIENT_RESULT", index);
	}

	///<summary>
	/// Returns DSC (CONTINUATION POINTER) - creates it if necessary
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
