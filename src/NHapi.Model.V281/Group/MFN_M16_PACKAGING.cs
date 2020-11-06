using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the MFN_M16_PACKAGING Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PKG (Item Packaging) </li>
///<li>1: PCE (Patient Charge Cost Center Exceptions) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M16_PACKAGING : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M16_PACKAGING Group.
	///</summary>
	public MFN_M16_PACKAGING(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PKG), true, false);
	      this.add(typeof(PCE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M16_PACKAGING - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PKG (Item Packaging) - creates it if necessary
	///</summary>
	public PKG PKG { 
get{
	   PKG ret = null;
	   try {
	      ret = (PKG)this.GetStructure("PKG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PCE (Patient Charge Cost Center Exceptions) - creates it if necessary
	///</summary>
	public PCE GetPCE() {
	   PCE ret = null;
	   try {
	      ret = (PCE)this.GetStructure("PCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PCE
	/// * (Patient Charge Cost Center Exceptions) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PCE GetPCE(int rep) { 
	   return (PCE)this.GetStructure("PCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PCE 
	 */ 
	public int PCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PCE results 
	 */ 
	public IEnumerable<PCE> PCEs 
	{ 
		get
		{
			for (int rep = 0; rep < PCERepetitionsUsed; rep++)
			{
				yield return (PCE)this.GetStructure("PCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new PCE
	///</summary>
	public PCE AddPCE()
	{
		return this.AddStructure("PCE") as PCE;
	}

	///<summary>
	///Removes the given PCE
	///</summary>
	public void RemovePCE(PCE toRemove)
	{
		this.RemoveStructure("PCE", toRemove);
	}

	///<summary>
	///Removes the PCE at the given index
	///</summary>
	public void RemovePCEAt(int index)
	{
		this.RemoveRepetition("PCE", index);
	}

}
}
