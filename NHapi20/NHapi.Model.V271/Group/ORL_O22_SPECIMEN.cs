using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V271.Segment;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V271.Group
{
///<summary>
///Represents the ORL_O22_SPECIMEN Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SPM (Specimen) </li>
///<li>1: SAC (Specimen Container detail) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORL_O22_SPECIMEN : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O22_SPECIMEN Group.
	///</summary>
	public ORL_O22_SPECIMEN(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SPM), true, false);
	      this.add(typeof(SAC), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O22_SPECIMEN - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns SPM (Specimen) - creates it if necessary
	///</summary>
	public SPM SPM { 
get{
	   SPM ret = null;
	   try {
	      ret = (SPM)this.GetStructure("SPM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of SAC (Specimen Container detail) - creates it if necessary
	///</summary>
	public SAC GetSAC() {
	   SAC ret = null;
	   try {
	      ret = (SAC)this.GetStructure("SAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SAC
	/// * (Specimen Container detail) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SAC GetSAC(int rep) { 
	   return (SAC)this.GetStructure("SAC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SAC 
	 */ 
	public int SACRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SAC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SAC results 
	 */ 
	public IEnumerable<SAC> SACs 
	{ 
		get
		{
			for (int rep = 0; rep < SACRepetitionsUsed; rep++)
			{
				yield return (SAC)this.GetStructure("SAC", rep);
			}
		}
	}

	///<summary>
	///Adds a new SAC
	///</summary>
	public SAC AddSAC()
	{
		return this.AddStructure("SAC") as SAC;
	}

	///<summary>
	///Removes the given SAC
	///</summary>
	public void RemoveSAC(SAC toRemove)
	{
		this.RemoveStructure("SAC", toRemove);
	}

	///<summary>
	///Removes the SAC at the given index
	///</summary>
	public void RemoveSACAt(int index)
	{
		this.RemoveRepetition("SAC", index);
	}

}
}
