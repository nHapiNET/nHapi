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
///Represents the SSR_U04_SPECIMEN_CONTAINER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SAC (Specimen Container detail) </li>
///<li>1: SPM (Specimen) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class SSR_U04_SPECIMEN_CONTAINER : AbstractGroup {

	///<summary> 
	/// Creates a new SSR_U04_SPECIMEN_CONTAINER Group.
	///</summary>
	public SSR_U04_SPECIMEN_CONTAINER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SAC), true, false);
	      this.add(typeof(SPM), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SSR_U04_SPECIMEN_CONTAINER - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of SPM (Specimen) - creates it if necessary
	///</summary>
	public SPM GetSPM() {
	   SPM ret = null;
	   try {
	      ret = (SPM)this.GetStructure("SPM");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SPM
	/// * (Specimen) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SPM GetSPM(int rep) { 
	   return (SPM)this.GetStructure("SPM", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SPM 
	 */ 
	public int SPMRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SPM").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SPM results 
	 */ 
	public IEnumerable<SPM> SPMs 
	{ 
		get
		{
			for (int rep = 0; rep < SPMRepetitionsUsed; rep++)
			{
				yield return (SPM)this.GetStructure("SPM", rep);
			}
		}
	}

	///<summary>
	///Adds a new SPM
	///</summary>
	public SPM AddSPM()
	{
		return this.AddStructure("SPM") as SPM;
	}

	///<summary>
	///Removes the given SPM
	///</summary>
	public void RemoveSPM(SPM toRemove)
	{
		this.RemoveStructure("SPM", toRemove);
	}

	///<summary>
	///Removes the SPM at the given index
	///</summary>
	public void RemoveSPMAt(int index)
	{
		this.RemoveRepetition("SPM", index);
	}

}
}
