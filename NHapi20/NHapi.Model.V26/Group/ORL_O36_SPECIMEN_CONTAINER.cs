using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V26.Segment;
using NHapi.Model.V26.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V26.Group
{
///<summary>
///Represents the ORL_O36_SPECIMEN_CONTAINER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SAC (Specimen Container detail) </li>
///<li>1: ORL_O36_ORDER (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORL_O36_SPECIMEN_CONTAINER : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O36_SPECIMEN_CONTAINER Group.
	///</summary>
	public ORL_O36_SPECIMEN_CONTAINER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SAC), true, false);
	      this.add(typeof(ORL_O36_ORDER), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O36_SPECIMEN_CONTAINER - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns SAC (Specimen Container detail) - creates it if necessary
	///</summary>
	public SAC SAC { 
get{
	   SAC ret = null;
	   try {
	      ret = (SAC)this.GetStructure("SAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORL_O36_ORDER (a Group object) - creates it if necessary
	///</summary>
	public ORL_O36_ORDER GetORDER() {
	   ORL_O36_ORDER ret = null;
	   try {
	      ret = (ORL_O36_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORL_O36_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORL_O36_ORDER GetORDER(int rep) { 
	   return (ORL_O36_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORL_O36_ORDER 
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
	 * Enumerate over the ORL_O36_ORDER results 
	 */ 
	public IEnumerable<ORL_O36_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (ORL_O36_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORL_O36_ORDER
	///</summary>
	public ORL_O36_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as ORL_O36_ORDER;
	}

	///<summary>
	///Removes the given ORL_O36_ORDER
	///</summary>
	public void RemoveORDER(ORL_O36_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the ORL_O36_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
