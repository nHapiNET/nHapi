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
///Represents the RRI_I14_PROVIDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PRD (Provider Data) </li>
///<li>1: CTD (Contact Data) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RRI_I14_PROVIDER : AbstractGroup {

	///<summary> 
	/// Creates a new RRI_I14_PROVIDER Group.
	///</summary>
	public RRI_I14_PROVIDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PRD), true, false);
	      this.add(typeof(CTD), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RRI_I14_PROVIDER - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PRD (Provider Data) - creates it if necessary
	///</summary>
	public PRD PRD { 
get{
	   PRD ret = null;
	   try {
	      ret = (PRD)this.GetStructure("PRD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CTD (Contact Data) - creates it if necessary
	///</summary>
	public CTD GetCTD() {
	   CTD ret = null;
	   try {
	      ret = (CTD)this.GetStructure("CTD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CTD
	/// * (Contact Data) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CTD GetCTD(int rep) { 
	   return (CTD)this.GetStructure("CTD", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CTD 
	 */ 
	public int CTDRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CTD").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CTD results 
	 */ 
	public IEnumerable<CTD> CTDs 
	{ 
		get
		{
			for (int rep = 0; rep < CTDRepetitionsUsed; rep++)
			{
				yield return (CTD)this.GetStructure("CTD", rep);
			}
		}
	}

	///<summary>
	///Adds a new CTD
	///</summary>
	public CTD AddCTD()
	{
		return this.AddStructure("CTD") as CTD;
	}

	///<summary>
	///Removes the given CTD
	///</summary>
	public void RemoveCTD(CTD toRemove)
	{
		this.RemoveStructure("CTD", toRemove);
	}

	///<summary>
	///Removes the CTD at the given index
	///</summary>
	public void RemoveCTDAt(int index)
	{
		this.RemoveRepetition("CTD", index);
	}

}
}
