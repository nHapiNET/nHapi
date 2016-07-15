using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
///<summary>
///Represents the ORU_R01_ORDER_OBSERVATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (ORC - common order segment) optional </li>
///<li>1: OBR (OBR - observation request segment) </li>
///<li>2: NTE (NTE - notes and comments segment) optional repeating</li>
///<li>3: ORU_R01_OBSERVATION (a Group object) repeating</li>
///<li>4: CTI (CTI - clinical trial identification segment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORU_R01_ORDER_OBSERVATION : AbstractGroup {

	///<summary> 
	/// Creates a new ORU_R01_ORDER_OBSERVATION Group.
	///</summary>
	public ORU_R01_ORDER_OBSERVATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), false, false);
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(ORU_R01_OBSERVATION), true, true);
	      this.add(typeof(CTI), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORU_R01_ORDER_OBSERVATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORC (ORC - common order segment) - creates it if necessary
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
	/// Returns OBR (OBR - observation request segment) - creates it if necessary
	///</summary>
	public OBR OBR { 
get{
	   OBR ret = null;
	   try {
	      ret = (OBR)this.GetStructure("OBR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NTE (NTE - notes and comments segment) - creates it if necessary
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
	/// * (NTE - notes and comments segment) - creates it if necessary
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
	/// Returns  first repetition of ORU_R01_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public ORU_R01_OBSERVATION GetOBSERVATION() {
	   ORU_R01_OBSERVATION ret = null;
	   try {
	      ret = (ORU_R01_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORU_R01_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORU_R01_OBSERVATION GetOBSERVATION(int rep) { 
	   return (ORU_R01_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORU_R01_OBSERVATION 
	 */ 
	public int OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORU_R01_OBSERVATION results 
	 */ 
	public IEnumerable<ORU_R01_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (ORU_R01_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORU_R01_OBSERVATION
	///</summary>
	public ORU_R01_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as ORU_R01_OBSERVATION;
	}

	///<summary>
	///Removes the given ORU_R01_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(ORU_R01_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the ORU_R01_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of CTI (CTI - clinical trial identification segment) - creates it if necessary
	///</summary>
	public CTI GetCTI() {
	   CTI ret = null;
	   try {
	      ret = (CTI)this.GetStructure("CTI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CTI
	/// * (CTI - clinical trial identification segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CTI GetCTI(int rep) { 
	   return (CTI)this.GetStructure("CTI", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CTI 
	 */ 
	public int CTIRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CTI").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CTI results 
	 */ 
	public IEnumerable<CTI> CTIs 
	{ 
		get
		{
			for (int rep = 0; rep < CTIRepetitionsUsed; rep++)
			{
				yield return (CTI)this.GetStructure("CTI", rep);
			}
		}
	}

	///<summary>
	///Adds a new CTI
	///</summary>
	public CTI AddCTI()
	{
		return this.AddStructure("CTI") as CTI;
	}

	///<summary>
	///Removes the given CTI
	///</summary>
	public void RemoveCTI(CTI toRemove)
	{
		this.RemoveStructure("CTI", toRemove);
	}

	///<summary>
	///Removes the CTI at the given index
	///</summary>
	public void RemoveCTIAt(int index)
	{
		this.RemoveRepetition("CTI", index);
	}

}
}
