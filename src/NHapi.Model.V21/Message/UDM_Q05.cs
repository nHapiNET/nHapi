using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V21.Group;
using NHapi.Model.V21.Segment;
using NHapi.Model.V21.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V21.Message

{
///<summary>
/// Represents a UDM_Q05 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MESSAGE HEADER) </li>
///<li>1: URD (RESULTS/UPDATE DEFINITION) </li>
///<li>2: URS (UNSOLICITED SELECTION) optional </li>
///<li>3: DSP (DISPLAY DATA) repeating</li>
///<li>4: DSC (CONTINUATION POINTER) </li>
///</ol>
///</summary>
[Serializable]
public class UDM_Q05 : AbstractMessage  {

	///<summary> 
	/// Creates a new UDM_Q05 Group with custom IModelClassFactory.
	///</summary>
	public UDM_Q05(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new UDM_Q05 Group with DefaultModelClassFactory. 
	///</summary> 
	public UDM_Q05() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for UDM_Q05.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(URD), true, false);
	      this.add(typeof(URS), false, false);
	      this.add(typeof(DSP), true, true);
	      this.add(typeof(DSC), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating UDM_Q05 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MESSAGE HEADER) - creates it if necessary
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
	/// Returns URD (RESULTS/UPDATE DEFINITION) - creates it if necessary
	///</summary>
	public URD URD { 
get{
	   URD ret = null;
	   try {
	      ret = (URD)this.GetStructure("URD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns URS (UNSOLICITED SELECTION) - creates it if necessary
	///</summary>
	public URS URS { 
get{
	   URS ret = null;
	   try {
	      ret = (URS)this.GetStructure("URS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of DSP (DISPLAY DATA) - creates it if necessary
	///</summary>
	public DSP GetDSP() {
	   DSP ret = null;
	   try {
	      ret = (DSP)this.GetStructure("DSP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DSP
	/// * (DISPLAY DATA) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DSP GetDSP(int rep) { 
	   return (DSP)this.GetStructure("DSP", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DSP 
	 */ 
	public int DSPRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DSP").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DSP results 
	 */ 
	public IEnumerable<DSP> DSPs 
	{ 
		get
		{
			for (int rep = 0; rep < DSPRepetitionsUsed; rep++)
			{
				yield return (DSP)this.GetStructure("DSP", rep);
			}
		}
	}

	///<summary>
	///Adds a new DSP
	///</summary>
	public DSP AddDSP()
	{
		return this.AddStructure("DSP") as DSP;
	}

	///<summary>
	///Removes the given DSP
	///</summary>
	public void RemoveDSP(DSP toRemove)
	{
		this.RemoveStructure("DSP", toRemove);
	}

	///<summary>
	///Removes the DSP at the given index
	///</summary>
	public void RemoveDSPAt(int index)
	{
		this.RemoveRepetition("DSP", index);
	}

	///<summary>
	/// Returns DSC (CONTINUATION POINTER) - creates it if necessary
	///</summary>
	public DSC DSC { 
get{
	   DSC ret = null;
	   try {
	      ret = (DSC)this.GetStructure("DSC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
