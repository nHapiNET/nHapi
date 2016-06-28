using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V281.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the DFT_P11_TIMING_QUANTITY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: TQ1 (Timing/Quantity) </li>
///<li>1: TQ2 (Timing/Quantity Relationship) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class DFT_P11_TIMING_QUANTITY : AbstractGroup {

	///<summary> 
	/// Creates a new DFT_P11_TIMING_QUANTITY Group.
	///</summary>
	public DFT_P11_TIMING_QUANTITY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(TQ1), true, false);
	      this.add(typeof(TQ2), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating DFT_P11_TIMING_QUANTITY - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns TQ1 (Timing/Quantity) - creates it if necessary
	///</summary>
	public TQ1 TQ1 { 
get{
	   TQ1 ret = null;
	   try {
	      ret = (TQ1)this.GetStructure("TQ1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of TQ2 (Timing/Quantity Relationship) - creates it if necessary
	///</summary>
	public TQ2 GetTQ2() {
	   TQ2 ret = null;
	   try {
	      ret = (TQ2)this.GetStructure("TQ2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of TQ2
	/// * (Timing/Quantity Relationship) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public TQ2 GetTQ2(int rep) { 
	   return (TQ2)this.GetStructure("TQ2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of TQ2 
	 */ 
	public int TQ2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TQ2").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

}
}
