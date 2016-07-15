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
/// Represents a ADT_A43 message structure (see chapter 3). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: EVN (Event Type) </li>
///<li>2: ADT_A43_PATIENT (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class ADT_A43 : AbstractMessage  {

	///<summary> 
	/// Creates a new ADT_A43 Group with custom IModelClassFactory.
	///</summary>
	public ADT_A43(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new ADT_A43 Group with DefaultModelClassFactory. 
	///</summary> 
	public ADT_A43() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for ADT_A43.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(EVN), true, false);
	      this.add(typeof(ADT_A43_PATIENT), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ADT_A43 - this is probably a bug in the source code generator.", e);
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
	/// Returns EVN (Event Type) - creates it if necessary
	///</summary>
	public EVN EVN { 
get{
	   EVN ret = null;
	   try {
	      ret = (EVN)this.GetStructure("EVN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ADT_A43_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ADT_A43_PATIENT GetPATIENT() {
	   ADT_A43_PATIENT ret = null;
	   try {
	      ret = (ADT_A43_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ADT_A43_PATIENT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ADT_A43_PATIENT GetPATIENT(int rep) { 
	   return (ADT_A43_PATIENT)this.GetStructure("PATIENT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ADT_A43_PATIENT 
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
	 * Enumerate over the ADT_A43_PATIENT results 
	 */ 
	public IEnumerable<ADT_A43_PATIENT> PATIENTs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENTRepetitionsUsed; rep++)
			{
				yield return (ADT_A43_PATIENT)this.GetStructure("PATIENT", rep);
			}
		}
	}

	///<summary>
	///Adds a new ADT_A43_PATIENT
	///</summary>
	public ADT_A43_PATIENT AddPATIENT()
	{
		return this.AddStructure("PATIENT") as ADT_A43_PATIENT;
	}

	///<summary>
	///Removes the given ADT_A43_PATIENT
	///</summary>
	public void RemovePATIENT(ADT_A43_PATIENT toRemove)
	{
		this.RemoveStructure("PATIENT", toRemove);
	}

	///<summary>
	///Removes the ADT_A43_PATIENT at the given index
	///</summary>
	public void RemovePATIENTAt(int index)
	{
		this.RemoveRepetition("PATIENT", index);
	}

}
}
