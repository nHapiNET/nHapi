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
/// Represents a SSR_U04 message structure (see chapter 13). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: EQU (Equipment Detail) </li>
///<li>2: SAC (Specimen and container detail) repeating</li>
///<li>3: ROL (Role) optional </li>
///</ol>
///</summary>
[Serializable]
public class SSR_U04 : AbstractMessage  {

	///<summary> 
	/// Creates a new SSR_U04 Group with custom IModelClassFactory.
	///</summary>
	public SSR_U04(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new SSR_U04 Group with DefaultModelClassFactory. 
	///</summary> 
	public SSR_U04() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for SSR_U04.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(EQU), true, false);
	      this.add(typeof(SAC), true, true);
	      this.add(typeof(ROL), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SSR_U04 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of SAC (Specimen and container detail) - creates it if necessary
	///</summary>
	public SAC GetSAC() {
	   SAC ret = null;
	   try {
	      ret = (SAC)this.GetStructure("SAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SAC
	/// * (Specimen and container detail) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SAC GetSAC(int rep) { 
	   return (SAC)this.GetStructure("SAC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SAC 
	 */ 
	public int SACRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SAC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SAC results 
	 */ 
	public IEnumerable<SAC> SACs 
	{ 
		get
		{
			for (int rep = 0; rep < SACRepetitionsUsed; rep++)
			{
				yield return (SAC)this.GetStructure("SAC", rep);
			}
		}
	}

	///<summary>
	///Adds a new SAC
	///</summary>
	public SAC AddSAC()
	{
		return this.AddStructure("SAC") as SAC;
	}

	///<summary>
	///Removes the given SAC
	///</summary>
	public void RemoveSAC(SAC toRemove)
	{
		this.RemoveStructure("SAC", toRemove);
	}

	///<summary>
	///Removes the SAC at the given index
	///</summary>
	public void RemoveSACAt(int index)
	{
		this.RemoveRepetition("SAC", index);
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
