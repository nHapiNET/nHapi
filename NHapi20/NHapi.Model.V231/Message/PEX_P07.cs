using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V231.Group;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Message

{
///<summary>
/// Represents a PEX_P07 message structure (see chapter ). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MSH - message header segment) </li>
///<li>1: EVN (EVN - event type segment) </li>
///<li>2: PID (PID - patient identification segment) </li>
///<li>3: PD1 (PD1 - patient additional demographic segment) optional </li>
///<li>4: NTE (NTE - notes and comments segment) optional repeating</li>
///<li>5: PEX_P07_VISIT (a Group object) optional </li>
///<li>6: PEX_P07_EXPERIENCE (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class PEX_P07 : AbstractMessage  {

	///<summary> 
	/// Creates a new PEX_P07 Group with custom IModelClassFactory.
	///</summary>
	public PEX_P07(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new PEX_P07 Group with DefaultModelClassFactory. 
	///</summary> 
	public PEX_P07() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for PEX_P07.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(EVN), true, false);
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PD1), false, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(PEX_P07_VISIT), false, false);
	      this.add(typeof(PEX_P07_EXPERIENCE), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PEX_P07 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MSH - message header segment) - creates it if necessary
	///</summary>
	public MSH MSH { 
get{
	   MSH ret = null;
	   try {
	      ret = (MSH)this.GetStructure("MSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns EVN (EVN - event type segment) - creates it if necessary
	///</summary>
	public EVN EVN { 
get{
	   EVN ret = null;
	   try {
	      ret = (EVN)this.GetStructure("EVN");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PID (PID - patient identification segment) - creates it if necessary
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
	/// Returns PD1 (PD1 - patient additional demographic segment) - creates it if necessary
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
	/// Returns PEX_P07_VISIT (a Group object) - creates it if necessary
	///</summary>
	public PEX_P07_VISIT VISIT { 
get{
	   PEX_P07_VISIT ret = null;
	   try {
	      ret = (PEX_P07_VISIT)this.GetStructure("VISIT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PEX_P07_EXPERIENCE (a Group object) - creates it if necessary
	///</summary>
	public PEX_P07_EXPERIENCE GetEXPERIENCE() {
	   PEX_P07_EXPERIENCE ret = null;
	   try {
	      ret = (PEX_P07_EXPERIENCE)this.GetStructure("EXPERIENCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PEX_P07_EXPERIENCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PEX_P07_EXPERIENCE GetEXPERIENCE(int rep) { 
	   return (PEX_P07_EXPERIENCE)this.GetStructure("EXPERIENCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PEX_P07_EXPERIENCE 
	 */ 
	public int EXPERIENCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("EXPERIENCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PEX_P07_EXPERIENCE results 
	 */ 
	public IEnumerable<PEX_P07_EXPERIENCE> EXPERIENCEs 
	{ 
		get
		{
			for (int rep = 0; rep < EXPERIENCERepetitionsUsed; rep++)
			{
				yield return (PEX_P07_EXPERIENCE)this.GetStructure("EXPERIENCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new PEX_P07_EXPERIENCE
	///</summary>
	public PEX_P07_EXPERIENCE AddEXPERIENCE()
	{
		return this.AddStructure("EXPERIENCE") as PEX_P07_EXPERIENCE;
	}

	///<summary>
	///Removes the given PEX_P07_EXPERIENCE
	///</summary>
	public void RemoveEXPERIENCE(PEX_P07_EXPERIENCE toRemove)
	{
		this.RemoveStructure("EXPERIENCE", toRemove);
	}

	///<summary>
	///Removes the PEX_P07_EXPERIENCE at the given index
	///</summary>
	public void RemoveEXPERIENCEAt(int index)
	{
		this.RemoveRepetition("EXPERIENCE", index);
	}

}
}
