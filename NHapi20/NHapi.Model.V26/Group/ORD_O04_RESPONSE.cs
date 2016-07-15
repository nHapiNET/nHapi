using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V26.Segment;
using NHapi.Model.V26.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V26.Group
{
///<summary>
///Represents the ORD_O04_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORD_O04_PATIENT (a Group object) optional </li>
///<li>1: ORD_O04_ORDER_DIET (a Group object) repeating</li>
///<li>2: ORD_O04_ORDER_TRAY (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORD_O04_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new ORD_O04_RESPONSE Group.
	///</summary>
	public ORD_O04_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORD_O04_PATIENT), false, false);
	      this.add(typeof(ORD_O04_ORDER_DIET), true, true);
	      this.add(typeof(ORD_O04_ORDER_TRAY), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORD_O04_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORD_O04_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORD_O04_PATIENT PATIENT { 
get{
	   ORD_O04_PATIENT ret = null;
	   try {
	      ret = (ORD_O04_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORD_O04_ORDER_DIET (a Group object) - creates it if necessary
	///</summary>
	public ORD_O04_ORDER_DIET GetORDER_DIET() {
	   ORD_O04_ORDER_DIET ret = null;
	   try {
	      ret = (ORD_O04_ORDER_DIET)this.GetStructure("ORDER_DIET");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORD_O04_ORDER_DIET
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORD_O04_ORDER_DIET GetORDER_DIET(int rep) { 
	   return (ORD_O04_ORDER_DIET)this.GetStructure("ORDER_DIET", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORD_O04_ORDER_DIET 
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

	/** 
	 * Enumerate over the ORD_O04_ORDER_DIET results 
	 */ 
	public IEnumerable<ORD_O04_ORDER_DIET> ORDER_DIETs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDER_DIETRepetitionsUsed; rep++)
			{
				yield return (ORD_O04_ORDER_DIET)this.GetStructure("ORDER_DIET", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORD_O04_ORDER_DIET
	///</summary>
	public ORD_O04_ORDER_DIET AddORDER_DIET()
	{
		return this.AddStructure("ORDER_DIET") as ORD_O04_ORDER_DIET;
	}

	///<summary>
	///Removes the given ORD_O04_ORDER_DIET
	///</summary>
	public void RemoveORDER_DIET(ORD_O04_ORDER_DIET toRemove)
	{
		this.RemoveStructure("ORDER_DIET", toRemove);
	}

	///<summary>
	///Removes the ORD_O04_ORDER_DIET at the given index
	///</summary>
	public void RemoveORDER_DIETAt(int index)
	{
		this.RemoveRepetition("ORDER_DIET", index);
	}

	///<summary>
	/// Returns  first repetition of ORD_O04_ORDER_TRAY (a Group object) - creates it if necessary
	///</summary>
	public ORD_O04_ORDER_TRAY GetORDER_TRAY() {
	   ORD_O04_ORDER_TRAY ret = null;
	   try {
	      ret = (ORD_O04_ORDER_TRAY)this.GetStructure("ORDER_TRAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORD_O04_ORDER_TRAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORD_O04_ORDER_TRAY GetORDER_TRAY(int rep) { 
	   return (ORD_O04_ORDER_TRAY)this.GetStructure("ORDER_TRAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORD_O04_ORDER_TRAY 
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

	/** 
	 * Enumerate over the ORD_O04_ORDER_TRAY results 
	 */ 
	public IEnumerable<ORD_O04_ORDER_TRAY> ORDER_TRAYs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDER_TRAYRepetitionsUsed; rep++)
			{
				yield return (ORD_O04_ORDER_TRAY)this.GetStructure("ORDER_TRAY", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORD_O04_ORDER_TRAY
	///</summary>
	public ORD_O04_ORDER_TRAY AddORDER_TRAY()
	{
		return this.AddStructure("ORDER_TRAY") as ORD_O04_ORDER_TRAY;
	}

	///<summary>
	///Removes the given ORD_O04_ORDER_TRAY
	///</summary>
	public void RemoveORDER_TRAY(ORD_O04_ORDER_TRAY toRemove)
	{
		this.RemoveStructure("ORDER_TRAY", toRemove);
	}

	///<summary>
	///Removes the ORD_O04_ORDER_TRAY at the given index
	///</summary>
	public void RemoveORDER_TRAYAt(int index)
	{
		this.RemoveRepetition("ORDER_TRAY", index);
	}

}
}
