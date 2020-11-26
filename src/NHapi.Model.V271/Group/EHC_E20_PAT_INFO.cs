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
///Represents the EHC_E20_PAT_INFO Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PID (Patient Identification) </li>
///<li>1: ACC (Accident) optional repeating</li>
///<li>2: EHC_E20_INSURANCE (a Group object) repeating</li>
///<li>3: EHC_E20_DIAGNOSIS (a Group object) optional repeating</li>
///<li>4: OBX (Observation/Result) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class EHC_E20_PAT_INFO : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E20_PAT_INFO Group.
	///</summary>
	public EHC_E20_PAT_INFO(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PID), true, false);
	      this.add(typeof(ACC), false, true);
	      this.add(typeof(EHC_E20_INSURANCE), true, true);
	      this.add(typeof(EHC_E20_DIAGNOSIS), false, true);
	      this.add(typeof(OBX), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E20_PAT_INFO - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PID (Patient Identification) - creates it if necessary
	///</summary>
	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ACC (Accident) - creates it if necessary
	///</summary>
	public ACC GetACC() {
	   ACC ret = null;
	   try {
	      ret = (ACC)this.GetStructure("ACC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ACC
	/// * (Accident) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ACC GetACC(int rep) { 
	   return (ACC)this.GetStructure("ACC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ACC 
	 */ 
	public int ACCRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ACC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ACC results 
	 */ 
	public IEnumerable<ACC> ACCs 
	{ 
		get
		{
			for (int rep = 0; rep < ACCRepetitionsUsed; rep++)
			{
				yield return (ACC)this.GetStructure("ACC", rep);
			}
		}
	}

	///<summary>
	///Adds a new ACC
	///</summary>
	public ACC AddACC()
	{
		return this.AddStructure("ACC") as ACC;
	}

	///<summary>
	///Removes the given ACC
	///</summary>
	public void RemoveACC(ACC toRemove)
	{
		this.RemoveStructure("ACC", toRemove);
	}

	///<summary>
	///Removes the ACC at the given index
	///</summary>
	public void RemoveACCAt(int index)
	{
		this.RemoveRepetition("ACC", index);
	}

	///<summary>
	/// Returns  first repetition of EHC_E20_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public EHC_E20_INSURANCE GetINSURANCE() {
	   EHC_E20_INSURANCE ret = null;
	   try {
	      ret = (EHC_E20_INSURANCE)this.GetStructure("INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E20_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E20_INSURANCE GetINSURANCE(int rep) { 
	   return (EHC_E20_INSURANCE)this.GetStructure("INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E20_INSURANCE 
	 */ 
	public int INSURANCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("INSURANCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EHC_E20_INSURANCE results 
	 */ 
	public IEnumerable<EHC_E20_INSURANCE> INSURANCEs 
	{ 
		get
		{
			for (int rep = 0; rep < INSURANCERepetitionsUsed; rep++)
			{
				yield return (EHC_E20_INSURANCE)this.GetStructure("INSURANCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E20_INSURANCE
	///</summary>
	public EHC_E20_INSURANCE AddINSURANCE()
	{
		return this.AddStructure("INSURANCE") as EHC_E20_INSURANCE;
	}

	///<summary>
	///Removes the given EHC_E20_INSURANCE
	///</summary>
	public void RemoveINSURANCE(EHC_E20_INSURANCE toRemove)
	{
		this.RemoveStructure("INSURANCE", toRemove);
	}

	///<summary>
	///Removes the EHC_E20_INSURANCE at the given index
	///</summary>
	public void RemoveINSURANCEAt(int index)
	{
		this.RemoveRepetition("INSURANCE", index);
	}

	///<summary>
	/// Returns  first repetition of EHC_E20_DIAGNOSIS (a Group object) - creates it if necessary
	///</summary>
	public EHC_E20_DIAGNOSIS GetDIAGNOSIS() {
	   EHC_E20_DIAGNOSIS ret = null;
	   try {
	      ret = (EHC_E20_DIAGNOSIS)this.GetStructure("DIAGNOSIS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EHC_E20_DIAGNOSIS
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EHC_E20_DIAGNOSIS GetDIAGNOSIS(int rep) { 
	   return (EHC_E20_DIAGNOSIS)this.GetStructure("DIAGNOSIS", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EHC_E20_DIAGNOSIS 
	 */ 
	public int DIAGNOSISRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DIAGNOSIS").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EHC_E20_DIAGNOSIS results 
	 */ 
	public IEnumerable<EHC_E20_DIAGNOSIS> DIAGNOSISs 
	{ 
		get
		{
			for (int rep = 0; rep < DIAGNOSISRepetitionsUsed; rep++)
			{
				yield return (EHC_E20_DIAGNOSIS)this.GetStructure("DIAGNOSIS", rep);
			}
		}
	}

	///<summary>
	///Adds a new EHC_E20_DIAGNOSIS
	///</summary>
	public EHC_E20_DIAGNOSIS AddDIAGNOSIS()
	{
		return this.AddStructure("DIAGNOSIS") as EHC_E20_DIAGNOSIS;
	}

	///<summary>
	///Removes the given EHC_E20_DIAGNOSIS
	///</summary>
	public void RemoveDIAGNOSIS(EHC_E20_DIAGNOSIS toRemove)
	{
		this.RemoveStructure("DIAGNOSIS", toRemove);
	}

	///<summary>
	///Removes the EHC_E20_DIAGNOSIS at the given index
	///</summary>
	public void RemoveDIAGNOSISAt(int index)
	{
		this.RemoveRepetition("DIAGNOSIS", index);
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

}
}
