using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V23.Group;
using NHapi.Model.V23.Segment;
using NHapi.Model.V23.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V23.Message

{
///<summary>
/// Represents a BAR_P05 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: EVN (Event type) </li>
///<li>2: PID (Patient Identification) </li>
///<li>3: PD1 (Patient Demographic) optional </li>
///<li>4: BAR_P05_VISIT (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class BAR_P05 : AbstractMessage  {

	///<summary> 
	/// Creates a new BAR_P05 Group with custom IModelClassFactory.
	///</summary>
	public BAR_P05(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new BAR_P05 Group with DefaultModelClassFactory. 
	///</summary> 
	public BAR_P05() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for BAR_P05.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(EVN), true, false);
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PD1), false, false);
	      this.add(typeof(BAR_P05_VISIT), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating BAR_P05 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (Message header segment) - creates it if necessary
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
	/// Returns EVN (Event type) - creates it if necessary
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
	/// Returns PD1 (Patient Demographic) - creates it if necessary
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
	/// Returns  first repetition of BAR_P05_VISIT (a Group object) - creates it if necessary
	///</summary>
	public BAR_P05_VISIT GetVISIT() {
	   BAR_P05_VISIT ret = null;
	   try {
	      ret = (BAR_P05_VISIT)this.GetStructure("VISIT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of BAR_P05_VISIT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public BAR_P05_VISIT GetVISIT(int rep) { 
	   return (BAR_P05_VISIT)this.GetStructure("VISIT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of BAR_P05_VISIT 
	 */ 
	public int VISITRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("VISIT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the BAR_P05_VISIT results 
	 */ 
	public IEnumerable<BAR_P05_VISIT> VISITs 
	{ 
		get
		{
			for (int rep = 0; rep < VISITRepetitionsUsed; rep++)
			{
				yield return (BAR_P05_VISIT)this.GetStructure("VISIT", rep);
			}
		}
	}

	///<summary>
	///Adds a new BAR_P05_VISIT
	///</summary>
	public BAR_P05_VISIT AddVISIT()
	{
		return this.AddStructure("VISIT") as BAR_P05_VISIT;
	}

	///<summary>
	///Removes the given BAR_P05_VISIT
	///</summary>
	public void RemoveVISIT(BAR_P05_VISIT toRemove)
	{
		this.RemoveStructure("VISIT", toRemove);
	}

	///<summary>
	///Removes the BAR_P05_VISIT at the given index
	///</summary>
	public void RemoveVISITAt(int index)
	{
		this.RemoveRepetition("VISIT", index);
	}

}
}
