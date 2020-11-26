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
///Represents the OMD_O03_ORDER_DIET Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: OMD_O03_TIMING_DIET (a Group object) optional repeating</li>
///<li>2: OMD_O03_DIET (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class OMD_O03_ORDER_DIET : AbstractGroup {

	///<summary> 
	/// Creates a new OMD_O03_ORDER_DIET Group.
	///</summary>
	public OMD_O03_ORDER_DIET(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(OMD_O03_TIMING_DIET), false, true);
	      this.add(typeof(OMD_O03_DIET), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OMD_O03_ORDER_DIET - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORC (Common Order) - creates it if necessary
	///</summary>
	public ORC ORC { 
get{
	   ORC ret = null;
	   try {
	      ret = (ORC)this.GetStructure("ORC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of OMD_O03_TIMING_DIET (a Group object) - creates it if necessary
	///</summary>
	public OMD_O03_TIMING_DIET GetTIMING_DIET() {
	   OMD_O03_TIMING_DIET ret = null;
	   try {
	      ret = (OMD_O03_TIMING_DIET)this.GetStructure("TIMING_DIET");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OMD_O03_TIMING_DIET
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OMD_O03_TIMING_DIET GetTIMING_DIET(int rep) { 
	   return (OMD_O03_TIMING_DIET)this.GetStructure("TIMING_DIET", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OMD_O03_TIMING_DIET 
	 */ 
	public int TIMING_DIETRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING_DIET").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OMD_O03_TIMING_DIET results 
	 */ 
	public IEnumerable<OMD_O03_TIMING_DIET> TIMING_DIETs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMING_DIETRepetitionsUsed; rep++)
			{
				yield return (OMD_O03_TIMING_DIET)this.GetStructure("TIMING_DIET", rep);
			}
		}
	}

	///<summary>
	///Adds a new OMD_O03_TIMING_DIET
	///</summary>
	public OMD_O03_TIMING_DIET AddTIMING_DIET()
	{
		return this.AddStructure("TIMING_DIET") as OMD_O03_TIMING_DIET;
	}

	///<summary>
	///Removes the given OMD_O03_TIMING_DIET
	///</summary>
	public void RemoveTIMING_DIET(OMD_O03_TIMING_DIET toRemove)
	{
		this.RemoveStructure("TIMING_DIET", toRemove);
	}

	///<summary>
	///Removes the OMD_O03_TIMING_DIET at the given index
	///</summary>
	public void RemoveTIMING_DIETAt(int index)
	{
		this.RemoveRepetition("TIMING_DIET", index);
	}

	///<summary>
	/// Returns OMD_O03_DIET (a Group object) - creates it if necessary
	///</summary>
	public OMD_O03_DIET DIET { 
get{
	   OMD_O03_DIET ret = null;
	   try {
	      ret = (OMD_O03_DIET)this.GetStructure("DIET");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
