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
///Represents the ORM_O01_PATIENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PID (Patient Identification) </li>
///<li>1: PD1 (Patient Additional Demographic) optional </li>
///<li>2: NTE (Notes and Comments) optional repeating</li>
///<li>3: ORM_O01_PATIENT_VISIT (a Group object) optional </li>
///<li>4: ORM_O01_INSURANCE (a Group object) optional repeating</li>
///<li>5: GT1 (Guarantor) optional </li>
///<li>6: AL1 (Patient Allergy Information) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORM_O01_PATIENT : AbstractGroup {

	///<summary> 
	/// Creates a new ORM_O01_PATIENT Group.
	///</summary>
	public ORM_O01_PATIENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PD1), false, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(ORM_O01_PATIENT_VISIT), false, false);
	      this.add(typeof(ORM_O01_INSURANCE), false, true);
	      this.add(typeof(GT1), false, false);
	      this.add(typeof(AL1), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORM_O01_PATIENT - this is probably a bug in the source code generator.", e);
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
	/// Returns PD1 (Patient Additional Demographic) - creates it if necessary
	///</summary>
	public PD1 PD1 { 
get{
	   PD1 ret = null;
	   try {
	      ret = (PD1)this.GetStructure("PD1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
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
	/// Returns ORM_O01_PATIENT_VISIT (a Group object) - creates it if necessary
	///</summary>
	public ORM_O01_PATIENT_VISIT PATIENT_VISIT { 
get{
	   ORM_O01_PATIENT_VISIT ret = null;
	   try {
	      ret = (ORM_O01_PATIENT_VISIT)this.GetStructure("PATIENT_VISIT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORM_O01_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public ORM_O01_INSURANCE GetINSURANCE() {
	   ORM_O01_INSURANCE ret = null;
	   try {
	      ret = (ORM_O01_INSURANCE)this.GetStructure("INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORM_O01_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORM_O01_INSURANCE GetINSURANCE(int rep) { 
	   return (ORM_O01_INSURANCE)this.GetStructure("INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORM_O01_INSURANCE 
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
	 * Enumerate over the ORM_O01_INSURANCE results 
	 */ 
	public IEnumerable<ORM_O01_INSURANCE> INSURANCEs 
	{ 
		get
		{
			for (int rep = 0; rep < INSURANCERepetitionsUsed; rep++)
			{
				yield return (ORM_O01_INSURANCE)this.GetStructure("INSURANCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORM_O01_INSURANCE
	///</summary>
	public ORM_O01_INSURANCE AddINSURANCE()
	{
		return this.AddStructure("INSURANCE") as ORM_O01_INSURANCE;
	}

	///<summary>
	///Removes the given ORM_O01_INSURANCE
	///</summary>
	public void RemoveINSURANCE(ORM_O01_INSURANCE toRemove)
	{
		this.RemoveStructure("INSURANCE", toRemove);
	}

	///<summary>
	///Removes the ORM_O01_INSURANCE at the given index
	///</summary>
	public void RemoveINSURANCEAt(int index)
	{
		this.RemoveRepetition("INSURANCE", index);
	}

	///<summary>
	/// Returns GT1 (Guarantor) - creates it if necessary
	///</summary>
	public GT1 GT1 { 
get{
	   GT1 ret = null;
	   try {
	      ret = (GT1)this.GetStructure("GT1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of AL1 (Patient Allergy Information) - creates it if necessary
	///</summary>
	public AL1 GetAL1() {
	   AL1 ret = null;
	   try {
	      ret = (AL1)this.GetStructure("AL1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of AL1
	/// * (Patient Allergy Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public AL1 GetAL1(int rep) { 
	   return (AL1)this.GetStructure("AL1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of AL1 
	 */ 
	public int AL1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("AL1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the AL1 results 
	 */ 
	public IEnumerable<AL1> AL1s 
	{ 
		get
		{
			for (int rep = 0; rep < AL1RepetitionsUsed; rep++)
			{
				yield return (AL1)this.GetStructure("AL1", rep);
			}
		}
	}

	///<summary>
	///Adds a new AL1
	///</summary>
	public AL1 AddAL1()
	{
		return this.AddStructure("AL1") as AL1;
	}

	///<summary>
	///Removes the given AL1
	///</summary>
	public void RemoveAL1(AL1 toRemove)
	{
		this.RemoveStructure("AL1", toRemove);
	}

	///<summary>
	///Removes the AL1 at the given index
	///</summary>
	public void RemoveAL1At(int index)
	{
		this.RemoveRepetition("AL1", index);
	}

}
}
