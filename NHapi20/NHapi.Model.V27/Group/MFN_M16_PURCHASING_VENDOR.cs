using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V27.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the MFN_M16_PURCHASING_VENDOR Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: VND (Purchasing Vendor) </li>
///<li>1: MFN_M16_PACKAGING (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M16_PURCHASING_VENDOR : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M16_PURCHASING_VENDOR Group.
	///</summary>
	public MFN_M16_PURCHASING_VENDOR(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(VND), true, false);
	      this.add(typeof(MFN_M16_PACKAGING), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M16_PURCHASING_VENDOR - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns VND (Purchasing Vendor) - creates it if necessary
	///</summary>
	public VND VND { 
get{
	   VND ret = null;
	   try {
	      ret = (VND)this.GetStructure("VND");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of MFN_M16_PACKAGING (a Group object) - creates it if necessary
	///</summary>
	public MFN_M16_PACKAGING GetPACKAGING() {
	   MFN_M16_PACKAGING ret = null;
	   try {
	      ret = (MFN_M16_PACKAGING)this.GetStructure("PACKAGING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M16_PACKAGING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M16_PACKAGING GetPACKAGING(int rep) { 
	   return (MFN_M16_PACKAGING)this.GetStructure("PACKAGING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M16_PACKAGING 
	 */ 
	public int PACKAGINGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PACKAGING").Length; 
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
