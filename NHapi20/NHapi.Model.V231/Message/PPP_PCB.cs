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
/// Represents a PPP_PCB message structure (see chapter ). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MSH - message header segment) </li>
///<li>1: PID (PID - patient identification segment) </li>
///<li>2: PPP_PCB_PATIENT_VISIT (a Group object) optional </li>
///<li>3: PPP_PCB_PATHWAY (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class PPP_PCB : AbstractMessage  {

	///<summary> 
	/// Creates a new PPP_PCB Group with custom IModelClassFactory.
	///</summary>
	public PPP_PCB(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new PPP_PCB Group with DefaultModelClassFactory. 
	///</summary> 
	public PPP_PCB() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for PPP_PCB.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(PID), true, false);
	      this.add(typeof(PPP_PCB_PATIENT_VISIT), false, false);
	      this.add(typeof(PPP_PCB_PATHWAY), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PPP_PCB - this is probably a bug in the source code generator.", e);
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
	/// Returns PPP_PCB_PATIENT_VISIT (a Group object) - creates it if necessary
	///</summary>
	public PPP_PCB_PATIENT_VISIT PATIENT_VISIT { 
get{
	   PPP_PCB_PATIENT_VISIT ret = null;
	   try {
	      ret = (PPP_PCB_PATIENT_VISIT)this.GetStructure("PATIENT_VISIT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PPP_PCB_PATHWAY (a Group object) - creates it if necessary
	///</summary>
	public PPP_PCB_PATHWAY GetPATHWAY() {
	   PPP_PCB_PATHWAY ret = null;
	   try {
	      ret = (PPP_PCB_PATHWAY)this.GetStructure("PATHWAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PPP_PCB_PATHWAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PPP_PCB_PATHWAY GetPATHWAY(int rep) { 
	   return (PPP_PCB_PATHWAY)this.GetStructure("PATHWAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PPP_PCB_PATHWAY 
	 */ 
	public int PATHWAYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATHWAY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PPP_PCB_PATHWAY results 
	 */ 
	public IEnumerable<PPP_PCB_PATHWAY> PATHWAYs 
	{ 
		get
		{
			for (int rep = 0; rep < PATHWAYRepetitionsUsed; rep++)
			{
				yield return (PPP_PCB_PATHWAY)this.GetStructure("PATHWAY", rep);
			}
		}
	}

	///<summary>
	///Adds a new PPP_PCB_PATHWAY
	///</summary>
	public PPP_PCB_PATHWAY AddPATHWAY()
	{
		return this.AddStructure("PATHWAY") as PPP_PCB_PATHWAY;
	}

	///<summary>
	///Removes the given PPP_PCB_PATHWAY
	///</summary>
	public void RemovePATHWAY(PPP_PCB_PATHWAY toRemove)
	{
		this.RemoveStructure("PATHWAY", toRemove);
	}

	///<summary>
	///Removes the PPP_PCB_PATHWAY at the given index
	///</summary>
	public void RemovePATHWAYAt(int index)
	{
		this.RemoveRepetition("PATHWAY", index);
	}

}
}
