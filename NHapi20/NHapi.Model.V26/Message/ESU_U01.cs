using System;
using NHapi.Base.Log;
using NHapi.Model.V26.Group;
using NHapi.Model.V26.Segment;
using NHapi.Model.V26.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V26.Message

{
///<summary>
/// Represents a ESU_U01 message structure (see chapter 13.3.1). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: EQU (Equipment Detail) </li>
///<li>4: ISD (Interaction Status Detail) optional repeating</li>
///<li>5: ROL (Role) optional </li>
///</ol>
///</summary>
[Serializable]
public class ESU_U01 : AbstractMessage  {

	///<summary> 
	/// Creates a new ESU_U01 Group with custom IModelClassFactory.
	///</summary>
	public ESU_U01(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new ESU_U01 Group with DefaultModelClassFactory. 
	///</summary> 
	public ESU_U01() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for ESU_U01.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(EQU), true, false);
	      this.add(typeof(ISD), false, true);
	      this.add(typeof(ROL), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ESU_U01 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of ISD (Interaction Status Detail) - creates it if necessary
	///</summary>
	public ISD GetISD() {
	   ISD ret = null;
	   try {
	      ret = (ISD)this.GetStructure("ISD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ISD
	/// * (Interaction Status Detail) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ISD GetISD(int rep) { 
	   return (ISD)this.GetStructure("ISD", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ISD 
	 */ 
	public int ISDRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ISD").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
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
