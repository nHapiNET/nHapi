using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V231.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
///<summary>
///Represents the ORD_O02_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORD_O02_PATIENT (a Group object) optional </li>
///<li>1: ORD_O02_ORDER_DIET (a Group object) repeating</li>
///<li>2: ORD_O02_ORDER_TRAY (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORD_O02_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new ORD_O02_RESPONSE Group.
	///</summary>
	public ORD_O02_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORD_O02_PATIENT), false, false);
	      this.add(typeof(ORD_O02_ORDER_DIET), true, true);
	      this.add(typeof(ORD_O02_ORDER_TRAY), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORD_O02_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORD_O02_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORD_O02_PATIENT PATIENT { 
get{
	   ORD_O02_PATIENT ret = null;
	   try {
	      ret = (ORD_O02_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORD_O02_ORDER_DIET (a Group object) - creates it if necessary
	///</summary>
	public ORD_O02_ORDER_DIET GetORDER_DIET() {
	   ORD_O02_ORDER_DIET ret = null;
	   try {
	      ret = (ORD_O02_ORDER_DIET)this.GetStructure("ORDER_DIET");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORD_O02_ORDER_DIET
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORD_O02_ORDER_DIET GetORDER_DIET(int rep) { 
	   return (ORD_O02_ORDER_DIET)this.GetStructure("ORDER_DIET", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORD_O02_ORDER_DIET 
	 */ 
	public int ORDER_DIETRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER_DIET").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of ORD_O02_ORDER_TRAY (a Group object) - creates it if necessary
	///</summary>
	public ORD_O02_ORDER_TRAY GetORDER_TRAY() {
	   ORD_O02_ORDER_TRAY ret = null;
	   try {
	      ret = (ORD_O02_ORDER_TRAY)this.GetStructure("ORDER_TRAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORD_O02_ORDER_TRAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORD_O02_ORDER_TRAY GetORDER_TRAY(int rep) { 
	   return (ORD_O02_ORDER_TRAY)this.GetStructure("ORDER_TRAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORD_O02_ORDER_TRAY 
	 */ 
	public int ORDER_TRAYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER_TRAY").Length; 
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
