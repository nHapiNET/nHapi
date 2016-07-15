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
///Represents the OUL_R22_SPECIMEN Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SPM (Specimen) </li>
///<li>1: OBX (Observation/Result) optional repeating</li>
///<li>2: OUL_R22_CONTAINER (a Group object) optional repeating</li>
///<li>3: OUL_R22_ORDER (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class OUL_R22_SPECIMEN : AbstractGroup {

	///<summary> 
	/// Creates a new OUL_R22_SPECIMEN Group.
	///</summary>
	public OUL_R22_SPECIMEN(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SPM), true, false);
	      this.add(typeof(OBX), false, true);
	      this.add(typeof(OUL_R22_CONTAINER), false, true);
	      this.add(typeof(OUL_R22_ORDER), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OUL_R22_SPECIMEN - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of OUL_R22_CONTAINER (a Group object) - creates it if necessary
	///</summary>
	public OUL_R22_CONTAINER GetCONTAINER() {
	   OUL_R22_CONTAINER ret = null;
	   try {
	      ret = (OUL_R22_CONTAINER)this.GetStructure("CONTAINER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OUL_R22_CONTAINER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OUL_R22_CONTAINER GetCONTAINER(int rep) { 
	   return (OUL_R22_CONTAINER)this.GetStructure("CONTAINER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OUL_R22_CONTAINER 
	 */ 
	public int CONTAINERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CONTAINER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OUL_R22_CONTAINER results 
	 */ 
	public IEnumerable<OUL_R22_CONTAINER> CONTAINERs 
	{ 
		get
		{
			for (int rep = 0; rep < CONTAINERRepetitionsUsed; rep++)
			{
				yield return (OUL_R22_CONTAINER)this.GetStructure("CONTAINER", rep);
			}
		}
	}

	///<summary>
	///Adds a new OUL_R22_CONTAINER
	///</summary>
	public OUL_R22_CONTAINER AddCONTAINER()
	{
		return this.AddStructure("CONTAINER") as OUL_R22_CONTAINER;
	}

	///<summary>
	///Removes the given OUL_R22_CONTAINER
	///</summary>
	public void RemoveCONTAINER(OUL_R22_CONTAINER toRemove)
	{
		this.RemoveStructure("CONTAINER", toRemove);
	}

	///<summary>
	///Removes the OUL_R22_CONTAINER at the given index
	///</summary>
	public void RemoveCONTAINERAt(int index)
	{
		this.RemoveRepetition("CONTAINER", index);
	}

	///<summary>
	/// Returns  first repetition of OUL_R22_ORDER (a Group object) - creates it if necessary
	///</summary>
	public OUL_R22_ORDER GetORDER() {
	   OUL_R22_ORDER ret = null;
	   try {
	      ret = (OUL_R22_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OUL_R22_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OUL_R22_ORDER GetORDER(int rep) { 
	   return (OUL_R22_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OUL_R22_ORDER 
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
	 * Enumerate over the OUL_R22_ORDER results 
	 */ 
	public IEnumerable<OUL_R22_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (OUL_R22_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new OUL_R22_ORDER
	///</summary>
	public OUL_R22_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as OUL_R22_ORDER;
	}

	///<summary>
	///Removes the given OUL_R22_ORDER
	///</summary>
	public void RemoveORDER(OUL_R22_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the OUL_R22_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

}
}
