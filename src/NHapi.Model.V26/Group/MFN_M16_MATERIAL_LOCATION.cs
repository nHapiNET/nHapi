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
///Represents the MFN_M16_MATERIAL_LOCATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: IVT (Material Location) </li>
///<li>1: ILT (Material Lot) optional repeating</li>
///<li>2: NTE (Notes and Comments) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M16_MATERIAL_LOCATION : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M16_MATERIAL_LOCATION Group.
	///</summary>
	public MFN_M16_MATERIAL_LOCATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(IVT), true, false);
	      this.add(typeof(ILT), false, true);
	      this.add(typeof(NTE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M16_MATERIAL_LOCATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns IVT (Material Location) - creates it if necessary
	///</summary>
	public IVT IVT { 
get{
	   IVT ret = null;
	   try {
	      ret = (IVT)this.GetStructure("IVT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ILT (Material Lot) - creates it if necessary
	///</summary>
	public ILT GetILT() {
	   ILT ret = null;
	   try {
	      ret = (ILT)this.GetStructure("ILT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ILT
	/// * (Material Lot) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ILT GetILT(int rep) { 
	   return (ILT)this.GetStructure("ILT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ILT 
	 */ 
	public int ILTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ILT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ILT results 
	 */ 
	public IEnumerable<ILT> ILTs 
	{ 
		get
		{
			for (int rep = 0; rep < ILTRepetitionsUsed; rep++)
			{
				yield return (ILT)this.GetStructure("ILT", rep);
			}
		}
	}

	///<summary>
	///Adds a new ILT
	///</summary>
	public ILT AddILT()
	{
		return this.AddStructure("ILT") as ILT;
	}

	///<summary>
	///Removes the given ILT
	///</summary>
	public void RemoveILT(ILT toRemove)
	{
		this.RemoveStructure("ILT", toRemove);
	}

	///<summary>
	///Removes the ILT at the given index
	///</summary>
	public void RemoveILTAt(int index)
	{
		this.RemoveRepetition("ILT", index);
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

}
}
