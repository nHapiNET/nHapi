using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V271.Group;
using NHapi.Model.V271.Segment;
using NHapi.Model.V271.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V271.Message

{
///<summary>
/// Represents a EAR_U08 message structure (see chapter 13.3.8). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: EQU (Equipment Detail) </li>
///<li>4: EAR_U08_COMMAND_RESPONSE (a Group object) repeating</li>
///<li>5: ROL (Role) optional </li>
///</ol>
///</summary>
[Serializable]
public class EAR_U08 : AbstractMessage  {

	///<summary> 
	/// Creates a new EAR_U08 Group with custom IModelClassFactory.
	///</summary>
	public EAR_U08(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new EAR_U08 Group with DefaultModelClassFactory. 
	///</summary> 
	public EAR_U08() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for EAR_U08.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(EQU), true, false);
	      this.add(typeof(EAR_U08_COMMAND_RESPONSE), true, true);
	      this.add(typeof(ROL), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EAR_U08 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (Message Header) - creates it if necessary
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
	/// Returns  first repetition of SFT (Software Segment) - creates it if necessary
	///</summary>
	public SFT GetSFT() {
	   SFT ret = null;
	   try {
	      ret = (SFT)this.GetStructure("SFT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SFT
	/// * (Software Segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SFT GetSFT(int rep) { 
	   return (SFT)this.GetStructure("SFT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SFT 
	 */ 
	public int SFTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SFT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SFT results 
	 */ 
	public IEnumerable<SFT> SFTs 
	{ 
		get
		{
			for (int rep = 0; rep < SFTRepetitionsUsed; rep++)
			{
				yield return (SFT)this.GetStructure("SFT", rep);
			}
		}
	}

	///<summary>
	///Adds a new SFT
	///</summary>
	public SFT AddSFT()
	{
		return this.AddStructure("SFT") as SFT;
	}

	///<summary>
	///Removes the given SFT
	///</summary>
	public void RemoveSFT(SFT toRemove)
	{
		this.RemoveStructure("SFT", toRemove);
	}

	///<summary>
	///Removes the SFT at the given index
	///</summary>
	public void RemoveSFTAt(int index)
	{
		this.RemoveRepetition("SFT", index);
	}

	///<summary>
	/// Returns UAC (User Authentication Credential Segment) - creates it if necessary
	///</summary>
	public UAC UAC { 
get{
	   UAC ret = null;
	   try {
	      ret = (UAC)this.GetStructure("UAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns EQU (Equipment Detail) - creates it if necessary
	///</summary>
	public EQU EQU { 
get{
	   EQU ret = null;
	   try {
	      ret = (EQU)this.GetStructure("EQU");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of EAR_U08_COMMAND_RESPONSE (a Group object) - creates it if necessary
	///</summary>
	public EAR_U08_COMMAND_RESPONSE GetCOMMAND_RESPONSE() {
	   EAR_U08_COMMAND_RESPONSE ret = null;
	   try {
	      ret = (EAR_U08_COMMAND_RESPONSE)this.GetStructure("COMMAND_RESPONSE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EAR_U08_COMMAND_RESPONSE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EAR_U08_COMMAND_RESPONSE GetCOMMAND_RESPONSE(int rep) { 
	   return (EAR_U08_COMMAND_RESPONSE)this.GetStructure("COMMAND_RESPONSE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EAR_U08_COMMAND_RESPONSE 
	 */ 
	public int COMMAND_RESPONSERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("COMMAND_RESPONSE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EAR_U08_COMMAND_RESPONSE results 
	 */ 
	public IEnumerable<EAR_U08_COMMAND_RESPONSE> COMMAND_RESPONSEs 
	{ 
		get
		{
			for (int rep = 0; rep < COMMAND_RESPONSERepetitionsUsed; rep++)
			{
				yield return (EAR_U08_COMMAND_RESPONSE)this.GetStructure("COMMAND_RESPONSE", rep);
			}
		}
	}

	///<summary>
	///Adds a new EAR_U08_COMMAND_RESPONSE
	///</summary>
	public EAR_U08_COMMAND_RESPONSE AddCOMMAND_RESPONSE()
	{
		return this.AddStructure("COMMAND_RESPONSE") as EAR_U08_COMMAND_RESPONSE;
	}

	///<summary>
	///Removes the given EAR_U08_COMMAND_RESPONSE
	///</summary>
	public void RemoveCOMMAND_RESPONSE(EAR_U08_COMMAND_RESPONSE toRemove)
	{
		this.RemoveStructure("COMMAND_RESPONSE", toRemove);
	}

	///<summary>
	///Removes the EAR_U08_COMMAND_RESPONSE at the given index
	///</summary>
	public void RemoveCOMMAND_RESPONSEAt(int index)
	{
		this.RemoveRepetition("COMMAND_RESPONSE", index);
	}

	///<summary>
	/// Returns ROL (Role) - creates it if necessary
	///</summary>
	public ROL ROL { 
get{
	   ROL ret = null;
	   try {
	      ret = (ROL)this.GetStructure("ROL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
