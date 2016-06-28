using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V281.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the CCU_I20_RESOURCES Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RGS (Resource Group) </li>
///<li>1: CCU_I20_RESOURCE_DETAIL (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class CCU_I20_RESOURCES : AbstractGroup {

	///<summary> 
	/// Creates a new CCU_I20_RESOURCES Group.
	///</summary>
	public CCU_I20_RESOURCES(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RGS), true, false);
	      this.add(typeof(CCU_I20_RESOURCE_DETAIL), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating CCU_I20_RESOURCES - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RGS (Resource Group) - creates it if necessary
	///</summary>
	public RGS RGS { 
get{
	   RGS ret = null;
	   try {
	      ret = (RGS)this.GetStructure("RGS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CCU_I20_RESOURCE_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public CCU_I20_RESOURCE_DETAIL GetRESOURCE_DETAIL() {
	   CCU_I20_RESOURCE_DETAIL ret = null;
	   try {
	      ret = (CCU_I20_RESOURCE_DETAIL)this.GetStructure("RESOURCE_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CCU_I20_RESOURCE_DETAIL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CCU_I20_RESOURCE_DETAIL GetRESOURCE_DETAIL(int rep) { 
	   return (CCU_I20_RESOURCE_DETAIL)this.GetStructure("RESOURCE_DETAIL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CCU_I20_RESOURCE_DETAIL 
	 */ 
	public int RESOURCE_DETAILRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RESOURCE_DETAIL").Length; 
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
