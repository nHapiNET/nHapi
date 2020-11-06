using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the CCI_I22_RESOURCE_DETAIL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: AIS (Appointment Information) </li>
///<li>1: AIG (Appointment Information - General Resource) </li>
///<li>2: AIL (Appointment Information - Location Resource) </li>
///<li>3: AIP (Appointment Information - Personnel Resource) </li>
///<li>4: CCI_I22_RESOURCE_OBSERVATION (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCI_I22_RESOURCE_DETAIL : AbstractGroup {

	///<summary> 
	/// Creates a new CCI_I22_RESOURCE_DETAIL Group.
	///</summary>
	public CCI_I22_RESOURCE_DETAIL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(AIS), true, false);
	      this.add(typeof(AIG), true, false);
	      this.add(typeof(AIL), true, false);
	      this.add(typeof(AIP), true, false);
	      this.add(typeof(CCI_I22_RESOURCE_OBSERVATION), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCI_I22_RESOURCE_DETAIL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns AIS (Appointment Information) - creates it if necessary
	///</summary>
	public AIS AIS { 
get{
	   AIS ret = null;
	   try {
	      ret = (AIS)this.GetStructure("AIS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIG (Appointment Information - General Resource) - creates it if necessary
	///</summary>
	public AIG AIG { 
get{
	   AIG ret = null;
	   try {
	      ret = (AIG)this.GetStructure("AIG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIL (Appointment Information - Location Resource) - creates it if necessary
	///</summary>
	public AIL AIL { 
get{
	   AIL ret = null;
	   try {
	      ret = (AIL)this.GetStructure("AIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns AIP (Appointment Information - Personnel Resource) - creates it if necessary
	///</summary>
	public AIP AIP { 
get{
	   AIP ret = null;
	   try {
	      ret = (AIP)this.GetStructure("AIP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CCI_I22_RESOURCE_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public CCI_I22_RESOURCE_OBSERVATION GetRESOURCE_OBSERVATION() {
	   CCI_I22_RESOURCE_OBSERVATION ret = null;
	   try {
	      ret = (CCI_I22_RESOURCE_OBSERVATION)this.GetStructure("RESOURCE_OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCI_I22_RESOURCE_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCI_I22_RESOURCE_OBSERVATION GetRESOURCE_OBSERVATION(int rep) { 
	   return (CCI_I22_RESOURCE_OBSERVATION)this.GetStructure("RESOURCE_OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCI_I22_RESOURCE_OBSERVATION 
	 */ 
	public int RESOURCE_OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RESOURCE_OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CCI_I22_RESOURCE_OBSERVATION results 
	 */ 
	public IEnumerable<CCI_I22_RESOURCE_OBSERVATION> RESOURCE_OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < RESOURCE_OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (CCI_I22_RESOURCE_OBSERVATION)this.GetStructure("RESOURCE_OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new CCI_I22_RESOURCE_OBSERVATION
	///</summary>
	public CCI_I22_RESOURCE_OBSERVATION AddRESOURCE_OBSERVATION()
	{
		return this.AddStructure("RESOURCE_OBSERVATION") as CCI_I22_RESOURCE_OBSERVATION;
	}

	///<summary>
	///Removes the given CCI_I22_RESOURCE_OBSERVATION
	///</summary>
	public void RemoveRESOURCE_OBSERVATION(CCI_I22_RESOURCE_OBSERVATION toRemove)
	{
		this.RemoveStructure("RESOURCE_OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the CCI_I22_RESOURCE_OBSERVATION at the given index
	///</summary>
	public void RemoveRESOURCE_OBSERVATIONAt(int index)
	{
		this.RemoveRepetition("RESOURCE_OBSERVATION", index);
	}

}
}
