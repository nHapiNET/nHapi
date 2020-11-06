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
///Represents the CSU_C09_STUDY_PHARM Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: CSU_C09_COMMON_ORDER (a Group object) optional </li>
///<li>1: CSU_C09_RX_ADMIN (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class CSU_C09_STUDY_PHARM : AbstractGroup {

	///<summary> 
	/// Creates a new CSU_C09_STUDY_PHARM Group.
	///</summary>
	public CSU_C09_STUDY_PHARM(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(CSU_C09_COMMON_ORDER), false, false);
	      this.add(typeof(CSU_C09_RX_ADMIN), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CSU_C09_STUDY_PHARM - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns CSU_C09_COMMON_ORDER (a Group object) - creates it if necessary
	///</summary>
	public CSU_C09_COMMON_ORDER COMMON_ORDER { 
get{
	   CSU_C09_COMMON_ORDER ret = null;
	   try {
	      ret = (CSU_C09_COMMON_ORDER)this.GetStructure("COMMON_ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CSU_C09_RX_ADMIN (a Group object) - creates it if necessary
	///</summary>
	public CSU_C09_RX_ADMIN GetRX_ADMIN() {
	   CSU_C09_RX_ADMIN ret = null;
	   try {
	      ret = (CSU_C09_RX_ADMIN)this.GetStructure("RX_ADMIN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CSU_C09_RX_ADMIN
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CSU_C09_RX_ADMIN GetRX_ADMIN(int rep) { 
	   return (CSU_C09_RX_ADMIN)this.GetStructure("RX_ADMIN", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CSU_C09_RX_ADMIN 
	 */ 
	public int RX_ADMINRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RX_ADMIN").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CSU_C09_RX_ADMIN results 
	 */ 
	public IEnumerable<CSU_C09_RX_ADMIN> RX_ADMINs 
	{ 
		get
		{
			for (int rep = 0; rep < RX_ADMINRepetitionsUsed; rep++)
			{
				yield return (CSU_C09_RX_ADMIN)this.GetStructure("RX_ADMIN", rep);
			}
		}
	}

	///<summary>
	///Adds a new CSU_C09_RX_ADMIN
	///</summary>
	public CSU_C09_RX_ADMIN AddRX_ADMIN()
	{
		return this.AddStructure("RX_ADMIN") as CSU_C09_RX_ADMIN;
	}

	///<summary>
	///Removes the given CSU_C09_RX_ADMIN
	///</summary>
	public void RemoveRX_ADMIN(CSU_C09_RX_ADMIN toRemove)
	{
		this.RemoveStructure("RX_ADMIN", toRemove);
	}

	///<summary>
	///Removes the CSU_C09_RX_ADMIN at the given index
	///</summary>
	public void RemoveRX_ADMINAt(int index)
	{
		this.RemoveRepetition("RX_ADMIN", index);
	}

}
}
