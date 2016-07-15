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
///Represents the SQM_S25_RESOURCES Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RGS (Resource Group) </li>
///<li>1: SQM_S25_SERVICE (a Group object) optional repeating</li>
///<li>2: SQM_S25_GENERAL_RESOURCE (a Group object) optional repeating</li>
///<li>3: SQM_S25_PERSONNEL_RESOURCE (a Group object) optional repeating</li>
///<li>4: SQM_S25_LOCATION_RESOURCE (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class SQM_S25_RESOURCES : AbstractGroup {

	///<summary> 
	/// Creates a new SQM_S25_RESOURCES Group.
	///</summary>
	public SQM_S25_RESOURCES(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RGS), true, false);
	      this.add(typeof(SQM_S25_SERVICE), false, true);
	      this.add(typeof(SQM_S25_GENERAL_RESOURCE), false, true);
	      this.add(typeof(SQM_S25_PERSONNEL_RESOURCE), false, true);
	      this.add(typeof(SQM_S25_LOCATION_RESOURCE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SQM_S25_RESOURCES - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RGS (Resource Group) - creates it if necessary
	///</summary>
	public RGS RGS { 
get{
	   RGS ret = null;
	   try {
	      ret = (RGS)this.GetStructure("RGS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of SQM_S25_SERVICE (a Group object) - creates it if necessary
	///</summary>
	public SQM_S25_SERVICE GetSERVICE() {
	   SQM_S25_SERVICE ret = null;
	   try {
	      ret = (SQM_S25_SERVICE)this.GetStructure("SERVICE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SQM_S25_SERVICE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SQM_S25_SERVICE GetSERVICE(int rep) { 
	   return (SQM_S25_SERVICE)this.GetStructure("SERVICE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SQM_S25_SERVICE 
	 */ 
	public int SERVICERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SERVICE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SQM_S25_SERVICE results 
	 */ 
	public IEnumerable<SQM_S25_SERVICE> SERVICEs 
	{ 
		get
		{
			for (int rep = 0; rep < SERVICERepetitionsUsed; rep++)
			{
				yield return (SQM_S25_SERVICE)this.GetStructure("SERVICE", rep);
			}
		}
	}

	///<summary>
	///Adds a new SQM_S25_SERVICE
	///</summary>
	public SQM_S25_SERVICE AddSERVICE()
	{
		return this.AddStructure("SERVICE") as SQM_S25_SERVICE;
	}

	///<summary>
	///Removes the given SQM_S25_SERVICE
	///</summary>
	public void RemoveSERVICE(SQM_S25_SERVICE toRemove)
	{
		this.RemoveStructure("SERVICE", toRemove);
	}

	///<summary>
	///Removes the SQM_S25_SERVICE at the given index
	///</summary>
	public void RemoveSERVICEAt(int index)
	{
		this.RemoveRepetition("SERVICE", index);
	}

	///<summary>
	/// Returns  first repetition of SQM_S25_GENERAL_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SQM_S25_GENERAL_RESOURCE GetGENERAL_RESOURCE() {
	   SQM_S25_GENERAL_RESOURCE ret = null;
	   try {
	      ret = (SQM_S25_GENERAL_RESOURCE)this.GetStructure("GENERAL_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SQM_S25_GENERAL_RESOURCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SQM_S25_GENERAL_RESOURCE GetGENERAL_RESOURCE(int rep) { 
	   return (SQM_S25_GENERAL_RESOURCE)this.GetStructure("GENERAL_RESOURCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SQM_S25_GENERAL_RESOURCE 
	 */ 
	public int GENERAL_RESOURCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("GENERAL_RESOURCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SQM_S25_GENERAL_RESOURCE results 
	 */ 
	public IEnumerable<SQM_S25_GENERAL_RESOURCE> GENERAL_RESOURCEs 
	{ 
		get
		{
			for (int rep = 0; rep < GENERAL_RESOURCERepetitionsUsed; rep++)
			{
				yield return (SQM_S25_GENERAL_RESOURCE)this.GetStructure("GENERAL_RESOURCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new SQM_S25_GENERAL_RESOURCE
	///</summary>
	public SQM_S25_GENERAL_RESOURCE AddGENERAL_RESOURCE()
	{
		return this.AddStructure("GENERAL_RESOURCE") as SQM_S25_GENERAL_RESOURCE;
	}

	///<summary>
	///Removes the given SQM_S25_GENERAL_RESOURCE
	///</summary>
	public void RemoveGENERAL_RESOURCE(SQM_S25_GENERAL_RESOURCE toRemove)
	{
		this.RemoveStructure("GENERAL_RESOURCE", toRemove);
	}

	///<summary>
	///Removes the SQM_S25_GENERAL_RESOURCE at the given index
	///</summary>
	public void RemoveGENERAL_RESOURCEAt(int index)
	{
		this.RemoveRepetition("GENERAL_RESOURCE", index);
	}

	///<summary>
	/// Returns  first repetition of SQM_S25_PERSONNEL_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SQM_S25_PERSONNEL_RESOURCE GetPERSONNEL_RESOURCE() {
	   SQM_S25_PERSONNEL_RESOURCE ret = null;
	   try {
	      ret = (SQM_S25_PERSONNEL_RESOURCE)this.GetStructure("PERSONNEL_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SQM_S25_PERSONNEL_RESOURCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SQM_S25_PERSONNEL_RESOURCE GetPERSONNEL_RESOURCE(int rep) { 
	   return (SQM_S25_PERSONNEL_RESOURCE)this.GetStructure("PERSONNEL_RESOURCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SQM_S25_PERSONNEL_RESOURCE 
	 */ 
	public int PERSONNEL_RESOURCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PERSONNEL_RESOURCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SQM_S25_PERSONNEL_RESOURCE results 
	 */ 
	public IEnumerable<SQM_S25_PERSONNEL_RESOURCE> PERSONNEL_RESOURCEs 
	{ 
		get
		{
			for (int rep = 0; rep < PERSONNEL_RESOURCERepetitionsUsed; rep++)
			{
				yield return (SQM_S25_PERSONNEL_RESOURCE)this.GetStructure("PERSONNEL_RESOURCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new SQM_S25_PERSONNEL_RESOURCE
	///</summary>
	public SQM_S25_PERSONNEL_RESOURCE AddPERSONNEL_RESOURCE()
	{
		return this.AddStructure("PERSONNEL_RESOURCE") as SQM_S25_PERSONNEL_RESOURCE;
	}

	///<summary>
	///Removes the given SQM_S25_PERSONNEL_RESOURCE
	///</summary>
	public void RemovePERSONNEL_RESOURCE(SQM_S25_PERSONNEL_RESOURCE toRemove)
	{
		this.RemoveStructure("PERSONNEL_RESOURCE", toRemove);
	}

	///<summary>
	///Removes the SQM_S25_PERSONNEL_RESOURCE at the given index
	///</summary>
	public void RemovePERSONNEL_RESOURCEAt(int index)
	{
		this.RemoveRepetition("PERSONNEL_RESOURCE", index);
	}

	///<summary>
	/// Returns  first repetition of SQM_S25_LOCATION_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SQM_S25_LOCATION_RESOURCE GetLOCATION_RESOURCE() {
	   SQM_S25_LOCATION_RESOURCE ret = null;
	   try {
	      ret = (SQM_S25_LOCATION_RESOURCE)this.GetStructure("LOCATION_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SQM_S25_LOCATION_RESOURCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SQM_S25_LOCATION_RESOURCE GetLOCATION_RESOURCE(int rep) { 
	   return (SQM_S25_LOCATION_RESOURCE)this.GetStructure("LOCATION_RESOURCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SQM_S25_LOCATION_RESOURCE 
	 */ 
	public int LOCATION_RESOURCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("LOCATION_RESOURCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SQM_S25_LOCATION_RESOURCE results 
	 */ 
	public IEnumerable<SQM_S25_LOCATION_RESOURCE> LOCATION_RESOURCEs 
	{ 
		get
		{
			for (int rep = 0; rep < LOCATION_RESOURCERepetitionsUsed; rep++)
			{
				yield return (SQM_S25_LOCATION_RESOURCE)this.GetStructure("LOCATION_RESOURCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new SQM_S25_LOCATION_RESOURCE
	///</summary>
	public SQM_S25_LOCATION_RESOURCE AddLOCATION_RESOURCE()
	{
		return this.AddStructure("LOCATION_RESOURCE") as SQM_S25_LOCATION_RESOURCE;
	}

	///<summary>
	///Removes the given SQM_S25_LOCATION_RESOURCE
	///</summary>
	public void RemoveLOCATION_RESOURCE(SQM_S25_LOCATION_RESOURCE toRemove)
	{
		this.RemoveStructure("LOCATION_RESOURCE", toRemove);
	}

	///<summary>
	///Removes the SQM_S25_LOCATION_RESOURCE at the given index
	///</summary>
	public void RemoveLOCATION_RESOURCEAt(int index)
	{
		this.RemoveRepetition("LOCATION_RESOURCE", index);
	}

}
}
