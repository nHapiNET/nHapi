using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V24.Group;
using NHapi.Model.V24.Segment;
using NHapi.Model.V24.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V24.Message

{
///<summary>
/// Represents a LSU_U12 message structure (see chapter 13). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: EQU (Equipment Detail) </li>
///<li>2: EQP (Equipment/log Service) repeating</li>
///<li>3: ROL (Role) optional </li>
///</ol>
///</summary>
[Serializable]
public class LSU_U12 : AbstractMessage  {

	///<summary> 
	/// Creates a new LSU_U12 Group with custom IModelClassFactory.
	///</summary>
	public LSU_U12(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new LSU_U12 Group with DefaultModelClassFactory. 
	///</summary> 
	public LSU_U12() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for LSU_U12.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(EQU), true, false);
	      this.add(typeof(EQP), true, true);
	      this.add(typeof(ROL), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating LSU_U12 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of EQP (Equipment/log Service) - creates it if necessary
	///</summary>
	public EQP GetEQP() {
	   EQP ret = null;
	   try {
	      ret = (EQP)this.GetStructure("EQP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of EQP
	/// * (Equipment/log Service) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public EQP GetEQP(int rep) { 
	   return (EQP)this.GetStructure("EQP", rep);
	}

	/** 
	 * Returns the number of existing repetitions of EQP 
	 */ 
	public int EQPRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("EQP").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the EQP results 
	 */ 
	public IEnumerable<EQP> EQPs 
	{ 
		get
		{
			for (int rep = 0; rep < EQPRepetitionsUsed; rep++)
			{
				yield return (EQP)this.GetStructure("EQP", rep);
			}
		}
	}

	///<summary>
	///Adds a new EQP
	///</summary>
	public EQP AddEQP()
	{
		return this.AddStructure("EQP") as EQP;
	}

	///<summary>
	///Removes the given EQP
	///</summary>
	public void RemoveEQP(EQP toRemove)
	{
		this.RemoveStructure("EQP", toRemove);
	}

	///<summary>
	///Removes the EQP at the given index
	///</summary>
	public void RemoveEQPAt(int index)
	{
		this.RemoveRepetition("EQP", index);
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
