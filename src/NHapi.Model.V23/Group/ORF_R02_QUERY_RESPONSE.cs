using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V23.Segment;
using NHapi.Model.V23.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V23.Group
{
///<summary>
///Represents the ORF_R02_QUERY_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORF_R02_PATIENT (a Group object) optional </li>
///<li>1: ORF_R02_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORF_R02_QUERY_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new ORF_R02_QUERY_RESPONSE Group.
	///</summary>
	public ORF_R02_QUERY_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORF_R02_PATIENT), false, false);
	      this.add(typeof(ORF_R02_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORF_R02_QUERY_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORF_R02_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORF_R02_PATIENT PATIENT { 
get{
	   ORF_R02_PATIENT ret = null;
	   try {
	      ret = (ORF_R02_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORF_R02_ORDER (a Group object) - creates it if necessary
	///</summary>
	public ORF_R02_ORDER GetORDER() {
	   ORF_R02_ORDER ret = null;
	   try {
	      ret = (ORF_R02_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORF_R02_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORF_R02_ORDER GetORDER(int rep) { 
	   return (ORF_R02_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORF_R02_ORDER 
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
	 * Enumerate over the ORF_R02_ORDER results 
	 */ 
	public IEnumerable<ORF_R02_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (ORF_R02_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORF_R02_ORDER
	///</summary>
	public ORF_R02_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as ORF_R02_ORDER;
	}

	///<summary>
	///Removes the given ORF_R02_ORDER
	///</summary>
	public void RemoveORDER(ORF_R02_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the ORF_R02_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
