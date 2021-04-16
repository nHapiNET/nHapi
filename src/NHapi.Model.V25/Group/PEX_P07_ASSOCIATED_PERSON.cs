using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Group
{
///<summary>
///Represents the PEX_P07_ASSOCIATED_PERSON Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: NK1 (Next of Kin / Associated Parties) </li>
///<li>1: PEX_P07_ASSOCIATED_RX_ORDER (a Group object) optional </li>
///<li>2: PEX_P07_ASSOCIATED_RX_ADMIN (a Group object) optional repeating</li>
///<li>3: PRB (Problem Details) optional repeating</li>
///<li>4: OBX (Observation/Result) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class PEX_P07_ASSOCIATED_PERSON : AbstractGroup {

	///<summary> 
	/// Creates a new PEX_P07_ASSOCIATED_PERSON Group.
	///</summary>
	public PEX_P07_ASSOCIATED_PERSON(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(NK1), true, false);
	      this.add(typeof(PEX_P07_ASSOCIATED_RX_ORDER), false, false);
	      this.add(typeof(PEX_P07_ASSOCIATED_RX_ADMIN), false, true);
	      this.add(typeof(PRB), false, true);
	      this.add(typeof(OBX), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PEX_P07_ASSOCIATED_PERSON - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns NK1 (Next of Kin / Associated Parties) - creates it if necessary
	///</summary>
	public NK1 NK1 { 
get{
	   NK1 ret = null;
	   try {
	      ret = (NK1)this.GetStructure("NK1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PEX_P07_ASSOCIATED_RX_ORDER (a Group object) - creates it if necessary
	///</summary>
	public PEX_P07_ASSOCIATED_RX_ORDER ASSOCIATED_RX_ORDER { 
get{
	   PEX_P07_ASSOCIATED_RX_ORDER ret = null;
	   try {
	      ret = (PEX_P07_ASSOCIATED_RX_ORDER)this.GetStructure("ASSOCIATED_RX_ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PEX_P07_ASSOCIATED_RX_ADMIN (a Group object) - creates it if necessary
	///</summary>
	public PEX_P07_ASSOCIATED_RX_ADMIN GetASSOCIATED_RX_ADMIN() {
	   PEX_P07_ASSOCIATED_RX_ADMIN ret = null;
	   try {
	      ret = (PEX_P07_ASSOCIATED_RX_ADMIN)this.GetStructure("ASSOCIATED_RX_ADMIN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PEX_P07_ASSOCIATED_RX_ADMIN
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PEX_P07_ASSOCIATED_RX_ADMIN GetASSOCIATED_RX_ADMIN(int rep) { 
	   return (PEX_P07_ASSOCIATED_RX_ADMIN)this.GetStructure("ASSOCIATED_RX_ADMIN", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PEX_P07_ASSOCIATED_RX_ADMIN 
	 */ 
	public int ASSOCIATED_RX_ADMINRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ASSOCIATED_RX_ADMIN").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PEX_P07_ASSOCIATED_RX_ADMIN results 
	 */ 
	public IEnumerable<PEX_P07_ASSOCIATED_RX_ADMIN> ASSOCIATED_RX_ADMINs 
	{ 
		get
		{
			for (int rep = 0; rep < ASSOCIATED_RX_ADMINRepetitionsUsed; rep++)
			{
				yield return (PEX_P07_ASSOCIATED_RX_ADMIN)this.GetStructure("ASSOCIATED_RX_ADMIN", rep);
			}
		}
	}

	///<summary>
	///Adds a new PEX_P07_ASSOCIATED_RX_ADMIN
	///</summary>
	public PEX_P07_ASSOCIATED_RX_ADMIN AddASSOCIATED_RX_ADMIN()
	{
		return this.AddStructure("ASSOCIATED_RX_ADMIN") as PEX_P07_ASSOCIATED_RX_ADMIN;
	}

	///<summary>
	///Removes the given PEX_P07_ASSOCIATED_RX_ADMIN
	///</summary>
	public void RemoveASSOCIATED_RX_ADMIN(PEX_P07_ASSOCIATED_RX_ADMIN toRemove)
	{
		this.RemoveStructure("ASSOCIATED_RX_ADMIN", toRemove);
	}

	///<summary>
	///Removes the PEX_P07_ASSOCIATED_RX_ADMIN at the given index
	///</summary>
	public void RemoveASSOCIATED_RX_ADMINAt(int index)
	{
		this.RemoveRepetition("ASSOCIATED_RX_ADMIN", index);
	}

	///<summary>
	/// Returns  first repetition of PRB (Problem Details) - creates it if necessary
	///</summary>
	public PRB GetPRB() {
	   PRB ret = null;
	   try {
	      ret = (PRB)this.GetStructure("PRB");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRB
	/// * (Problem Details) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRB GetPRB(int rep) { 
	   return (PRB)this.GetStructure("PRB", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRB 
	 */ 
	public int PRBRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRB").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PRB results 
	 */ 
	public IEnumerable<PRB> PRBs 
	{ 
		get
		{
			for (int rep = 0; rep < PRBRepetitionsUsed; rep++)
			{
				yield return (PRB)this.GetStructure("PRB", rep);
			}
		}
	}

	///<summary>
	///Adds a new PRB
	///</summary>
	public PRB AddPRB()
	{
		return this.AddStructure("PRB") as PRB;
	}

	///<summary>
	///Removes the given PRB
	///</summary>
	public void RemovePRB(PRB toRemove)
	{
		this.RemoveStructure("PRB", toRemove);
	}

	///<summary>
	///Removes the PRB at the given index
	///</summary>
	public void RemovePRBAt(int index)
	{
		this.RemoveRepetition("PRB", index);
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
