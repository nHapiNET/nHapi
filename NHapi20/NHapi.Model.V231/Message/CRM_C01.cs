using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V231.Group;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Message

{
///<summary>
/// Represents a CRM_C01 message structure (see chapter ). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MSH - message header segment) </li>
///<li>1: CRM_C01_PATIENT (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class CRM_C01 : AbstractMessage  {

	///<summary> 
	/// Creates a new CRM_C01 Group with custom IModelClassFactory.
	///</summary>
	public CRM_C01(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new CRM_C01 Group with DefaultModelClassFactory. 
	///</summary> 
	public CRM_C01() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for CRM_C01.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(CRM_C01_PATIENT), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CRM_C01 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MSH - message header segment) - creates it if necessary
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
	/// Returns  first repetition of CRM_C01_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public CRM_C01_PATIENT GetPATIENT() {
	   CRM_C01_PATIENT ret = null;
	   try {
	      ret = (CRM_C01_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CRM_C01_PATIENT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CRM_C01_PATIENT GetPATIENT(int rep) { 
	   return (CRM_C01_PATIENT)this.GetStructure("PATIENT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CRM_C01_PATIENT 
	 */ 
	public int PATIENTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATIENT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CRM_C01_PATIENT results 
	 */ 
	public IEnumerable<CRM_C01_PATIENT> PATIENTs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENTRepetitionsUsed; rep++)
			{
				yield return (CRM_C01_PATIENT)this.GetStructure("PATIENT", rep);
			}
		}
	}

	///<summary>
	///Adds a new CRM_C01_PATIENT
	///</summary>
	public CRM_C01_PATIENT AddPATIENT()
	{
		return this.AddStructure("PATIENT") as CRM_C01_PATIENT;
	}

	///<summary>
	///Removes the given CRM_C01_PATIENT
	///</summary>
	public void RemovePATIENT(CRM_C01_PATIENT toRemove)
	{
		this.RemoveStructure("PATIENT", toRemove);
	}

	///<summary>
	///Removes the CRM_C01_PATIENT at the given index
	///</summary>
	public void RemovePATIENTAt(int index)
	{
		this.RemoveRepetition("PATIENT", index);
	}

}
}
