using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the DPR_O48_DONATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: DON (Donation) </li>
///<li>1: OBX (Observation/Result) optional repeating</li>
///<li>2: NTE (Notes and Comments) optional repeating</li>
///<li>3: DPR_O48_BLOOD_UNIT (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class DPR_O48_DONATION : AbstractGroup {

	///<summary> 
	/// Creates a new DPR_O48_DONATION Group.
	///</summary>
	public DPR_O48_DONATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(DON), true, false);
	      this.add(typeof(OBX), false, true);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(DPR_O48_BLOOD_UNIT), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating DPR_O48_DONATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns DON (Donation) - creates it if necessary
	///</summary>
	public DON DON { 
get{
	   DON ret = null;
	   try {
	      ret = (DON)this.GetStructure("DON");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of OBX (Observation/Result) - creates it if necessary
	///</summary>
	public OBX GetOBX() {
	   OBX ret = null;
	   try {
	      ret = (OBX)this.GetStructure("OBX");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OBX
	/// * (Observation/Result) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OBX GetOBX(int rep) { 
	   return (OBX)this.GetStructure("OBX", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OBX 
	 */ 
	public int OBXRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBX").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OBX results 
	 */ 
	public IEnumerable<OBX> OBXs 
	{ 
		get
		{
			for (int rep = 0; rep < OBXRepetitionsUsed; rep++)
			{
				yield return (OBX)this.GetStructure("OBX", rep);
			}
		}
	}

	///<summary>
	///Adds a new OBX
	///</summary>
	public OBX AddOBX()
	{
		return this.AddStructure("OBX") as OBX;
	}

	///<summary>
	///Removes the given OBX
	///</summary>
	public void RemoveOBX(OBX toRemove)
	{
		this.RemoveStructure("OBX", toRemove);
	}

	///<summary>
	///Removes the OBX at the given index
	///</summary>
	public void RemoveOBXAt(int index)
	{
		this.RemoveRepetition("OBX", index);
	}

	///<summary>
	/// Returns  first repetition of NTE (Notes and Comments) - creates it if necessary
	///</summary>
	public NTE GetNTE() {
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NTE
	/// * (Notes and Comments) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NTE GetNTE(int rep) { 
	   return (NTE)this.GetStructure("NTE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NTE 
	 */ 
	public int NTERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NTE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NTE results 
	 */ 
	public IEnumerable<NTE> NTEs 
	{ 
		get
		{
			for (int rep = 0; rep < NTERepetitionsUsed; rep++)
			{
				yield return (NTE)this.GetStructure("NTE", rep);
			}
		}
	}

	///<summary>
	///Adds a new NTE
	///</summary>
	public NTE AddNTE()
	{
		return this.AddStructure("NTE") as NTE;
	}

	///<summary>
	///Removes the given NTE
	///</summary>
	public void RemoveNTE(NTE toRemove)
	{
		this.RemoveStructure("NTE", toRemove);
	}

	///<summary>
	///Removes the NTE at the given index
	///</summary>
	public void RemoveNTEAt(int index)
	{
		this.RemoveRepetition("NTE", index);
	}

	///<summary>
	/// Returns DPR_O48_BLOOD_UNIT (a Group object) - creates it if necessary
	///</summary>
	public DPR_O48_BLOOD_UNIT BLOOD_UNIT { 
get{
	   DPR_O48_BLOOD_UNIT ret = null;
	   try {
	      ret = (DPR_O48_BLOOD_UNIT)this.GetStructure("BLOOD_UNIT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
