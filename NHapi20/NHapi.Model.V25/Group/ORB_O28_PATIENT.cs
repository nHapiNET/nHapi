using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Group
{
///<summary>
///Represents the ORB_O28_PATIENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PID (Patient Identification) </li>
///<li>1: ORB_O28_ORDER (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORB_O28_PATIENT : AbstractGroup {

	///<summary> 
	/// Creates a new ORB_O28_PATIENT Group.
	///</summary>
	public ORB_O28_PATIENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PID), true, false);
	      this.add(typeof(ORB_O28_ORDER), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORB_O28_PATIENT - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PID (Patient Identification) - creates it if necessary
	///</summary>
	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORB_O28_ORDER (a Group object) - creates it if necessary
	///</summary>
	public ORB_O28_ORDER GetORDER() {
	   ORB_O28_ORDER ret = null;
	   try {
	      ret = (ORB_O28_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORB_O28_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORB_O28_ORDER GetORDER(int rep) { 
	   return (ORB_O28_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORB_O28_ORDER 
	 */ 
	public int ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORB_O28_ORDER results 
	 */ 
	public IEnumerable<ORB_O28_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (ORB_O28_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORB_O28_ORDER
	///</summary>
	public ORB_O28_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as ORB_O28_ORDER;
	}

	///<summary>
	///Removes the given ORB_O28_ORDER
	///</summary>
	public void RemoveORDER(ORB_O28_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the ORB_O28_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
