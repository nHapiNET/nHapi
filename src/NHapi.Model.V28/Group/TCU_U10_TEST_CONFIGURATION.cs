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
///Represents the TCU_U10_TEST_CONFIGURATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SPM (Specimen) optional </li>
///<li>1: TCC (Test Code Configuration) repeating</li>
///</ol>
///</summary>
[Serializable]
public class TCU_U10_TEST_CONFIGURATION : AbstractGroup {

	///<summary> 
	/// Creates a new TCU_U10_TEST_CONFIGURATION Group.
	///</summary>
	public TCU_U10_TEST_CONFIGURATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SPM), false, false);
	      this.add(typeof(TCC), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating TCU_U10_TEST_CONFIGURATION - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of TCC (Test Code Configuration) - creates it if necessary
	///</summary>
	public TCC GetTCC() {
	   TCC ret = null;
	   try {
	      ret = (TCC)this.GetStructure("TCC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of TCC
	/// * (Test Code Configuration) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public TCC GetTCC(int rep) { 
	   return (TCC)this.GetStructure("TCC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of TCC 
	 */ 
	public int TCCRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TCC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the TCC results 
	 */ 
	public IEnumerable<TCC> TCCs 
	{ 
		get
		{
			for (int rep = 0; rep < TCCRepetitionsUsed; rep++)
			{
				yield return (TCC)this.GetStructure("TCC", rep);
			}
		}
	}

	///<summary>
	///Adds a new TCC
	///</summary>
	public TCC AddTCC()
	{
		return this.AddStructure("TCC") as TCC;
	}

	///<summary>
	///Removes the given TCC
	///</summary>
	public void RemoveTCC(TCC toRemove)
	{
		this.RemoveStructure("TCC", toRemove);
	}

	///<summary>
	///Removes the TCC at the given index
	///</summary>
	public void RemoveTCCAt(int index)
	{
		this.RemoveRepetition("TCC", index);
	}

}
}
