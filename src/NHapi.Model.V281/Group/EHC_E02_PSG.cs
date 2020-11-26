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
///Represents the EHC_E02_PSG Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSG (Product/Service Group) </li>
///<li>1: PSL (Product/Service Line Item) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E02_PSG : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E02_PSG Group.
	///</summary>
	public EHC_E02_PSG(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSG), true, false);
	      this.add(typeof(PSL), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E02_PSG - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PSG (Product/Service Group) - creates it if necessary
	///</summary>
	public PSG PSG { 
get{
	   PSG ret = null;
	   try {
	      ret = (PSG)this.GetStructure("PSG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PSL (Product/Service Line Item) - creates it if necessary
	///</summary>
	public PSL GetPSL() {
	   PSL ret = null;
	   try {
	      ret = (PSL)this.GetStructure("PSL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PSL
	/// * (Product/Service Line Item) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PSL GetPSL(int rep) { 
	   return (PSL)this.GetStructure("PSL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PSL 
	 */ 
	public int PSLRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PSL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PSL results 
	 */ 
	public IEnumerable<PSL> PSLs 
	{ 
		get
		{
			for (int rep = 0; rep < PSLRepetitionsUsed; rep++)
			{
				yield return (PSL)this.GetStructure("PSL", rep);
			}
		}
	}

	///<summary>
	///Adds a new PSL
	///</summary>
	public PSL AddPSL()
	{
		return this.AddStructure("PSL") as PSL;
	}

	///<summary>
	///Removes the given PSL
	///</summary>
	public void RemovePSL(PSL toRemove)
	{
		this.RemoveStructure("PSL", toRemove);
	}

	///<summary>
	///Removes the PSL at the given index
	///</summary>
	public void RemovePSLAt(int index)
	{
		this.RemoveRepetition("PSL", index);
	}

}
}
