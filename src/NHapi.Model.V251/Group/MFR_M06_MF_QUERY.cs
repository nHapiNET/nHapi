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
///Represents the MFR_M06_MF_QUERY Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFE (Master File Entry) </li>
///<li>1: CM0 (Clinical Study Master) </li>
///<li>2: CM1 (Clinical Study Phase Master) optional repeating</li>
///<li>3: CM2 (Clinical Study Schedule Master) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFR_M06_MF_QUERY : AbstractGroup {

	///<summary> 
	/// Creates a new MFR_M06_MF_QUERY Group.
	///</summary>
	public MFR_M06_MF_QUERY(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFE), true, false);
	      this.add(typeof(CM0), true, false);
	      this.add(typeof(CM1), false, true);
	      this.add(typeof(CM2), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFR_M06_MF_QUERY - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns MFE (Master File Entry) - creates it if necessary
	///</summary>
	public MFE MFE { 
get{
	   MFE ret = null;
	   try {
	      ret = (MFE)this.GetStructure("MFE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns CM0 (Clinical Study Master) - creates it if necessary
	///</summary>
	public CM0 CM0 { 
get{
	   CM0 ret = null;
	   try {
	      ret = (CM0)this.GetStructure("CM0");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CM1 (Clinical Study Phase Master) - creates it if necessary
	///</summary>
	public CM1 GetCM1() {
	   CM1 ret = null;
	   try {
	      ret = (CM1)this.GetStructure("CM1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CM1
	/// * (Clinical Study Phase Master) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CM1 GetCM1(int rep) { 
	   return (CM1)this.GetStructure("CM1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CM1 
	 */ 
	public int CM1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CM1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CM1 results 
	 */ 
	public IEnumerable<CM1> CM1s 
	{ 
		get
		{
			for (int rep = 0; rep < CM1RepetitionsUsed; rep++)
			{
				yield return (CM1)this.GetStructure("CM1", rep);
			}
		}
	}

	///<summary>
	///Adds a new CM1
	///</summary>
	public CM1 AddCM1()
	{
		return this.AddStructure("CM1") as CM1;
	}

	///<summary>
	///Removes the given CM1
	///</summary>
	public void RemoveCM1(CM1 toRemove)
	{
		this.RemoveStructure("CM1", toRemove);
	}

	///<summary>
	///Removes the CM1 at the given index
	///</summary>
	public void RemoveCM1At(int index)
	{
		this.RemoveRepetition("CM1", index);
	}

	///<summary>
	/// Returns  first repetition of CM2 (Clinical Study Schedule Master) - creates it if necessary
	///</summary>
	public CM2 GetCM2() {
	   CM2 ret = null;
	   try {
	      ret = (CM2)this.GetStructure("CM2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CM2
	/// * (Clinical Study Schedule Master) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CM2 GetCM2(int rep) { 
	   return (CM2)this.GetStructure("CM2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CM2 
	 */ 
	public int CM2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CM2").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CM2 results 
	 */ 
	public IEnumerable<CM2> CM2s 
	{ 
		get
		{
			for (int rep = 0; rep < CM2RepetitionsUsed; rep++)
			{
				yield return (CM2)this.GetStructure("CM2", rep);
			}
		}
	}

	///<summary>
	///Adds a new CM2
	///</summary>
	public CM2 AddCM2()
	{
		return this.AddStructure("CM2") as CM2;
	}

	///<summary>
	///Removes the given CM2
	///</summary>
	public void RemoveCM2(CM2 toRemove)
	{
		this.RemoveStructure("CM2", toRemove);
	}

	///<summary>
	///Removes the CM2 at the given index
	///</summary>
	public void RemoveCM2At(int index)
	{
		this.RemoveRepetition("CM2", index);
	}

}
}
