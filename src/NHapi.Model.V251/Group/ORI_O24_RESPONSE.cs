using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V251.Segment;
using NHapi.Model.V251.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the ORI_O24_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORI_O24_PATIENT (a Group object) optional </li>
///<li>1: ORI_O24_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORI_O24_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new ORI_O24_RESPONSE Group.
	///</summary>
	public ORI_O24_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORI_O24_PATIENT), false, false);
	      this.add(typeof(ORI_O24_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORI_O24_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORI_O24_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORI_O24_PATIENT PATIENT { 
get{
	   ORI_O24_PATIENT ret = null;
	   try {
	      ret = (ORI_O24_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORI_O24_ORDER (a Group object) - creates it if necessary
	///</summary>
	public ORI_O24_ORDER GetORDER() {
	   ORI_O24_ORDER ret = null;
	   try {
	      ret = (ORI_O24_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORI_O24_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORI_O24_ORDER GetORDER(int rep) { 
	   return (ORI_O24_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORI_O24_ORDER 
	 */ 
	public int ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORI_O24_ORDER results 
	 */ 
	public IEnumerable<ORI_O24_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (ORI_O24_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORI_O24_ORDER
	///</summary>
	public ORI_O24_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as ORI_O24_ORDER;
	}

	///<summary>
	///Removes the given ORI_O24_ORDER
	///</summary>
	public void RemoveORDER(ORI_O24_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the ORI_O24_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
