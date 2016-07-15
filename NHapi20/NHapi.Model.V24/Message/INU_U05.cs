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
/// Represents a INU_U05 message structure (see chapter 13). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: EQU (Equipment Detail) </li>
///<li>2: INV (Inventory Detail) repeating</li>
///<li>3: ROL (Role) optional </li>
///</ol>
///</summary>
[Serializable]
public class INU_U05 : AbstractMessage  {

	///<summary> 
	/// Creates a new INU_U05 Group with custom IModelClassFactory.
	///</summary>
	public INU_U05(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new INU_U05 Group with DefaultModelClassFactory. 
	///</summary> 
	public INU_U05() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for INU_U05.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(EQU), true, false);
	      this.add(typeof(INV), true, true);
	      this.add(typeof(ROL), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating INU_U05 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of INV (Inventory Detail) - creates it if necessary
	///</summary>
	public INV GetINV() {
	   INV ret = null;
	   try {
	      ret = (INV)this.GetStructure("INV");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of INV
	/// * (Inventory Detail) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public INV GetINV(int rep) { 
	   return (INV)this.GetStructure("INV", rep);
	}

	/** 
	 * Returns the number of existing repetitions of INV 
	 */ 
	public int INVRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("INV").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the INV results 
	 */ 
	public IEnumerable<INV> INVs 
	{ 
		get
		{
			for (int rep = 0; rep < INVRepetitionsUsed; rep++)
			{
				yield return (INV)this.GetStructure("INV", rep);
			}
		}
	}

	///<summary>
	///Adds a new INV
	///</summary>
	public INV AddINV()
	{
		return this.AddStructure("INV") as INV;
	}

	///<summary>
	///Removes the given INV
	///</summary>
	public void RemoveINV(INV toRemove)
	{
		this.RemoveStructure("INV", toRemove);
	}

	///<summary>
	///Removes the INV at the given index
	///</summary>
	public void RemoveINVAt(int index)
	{
		this.RemoveRepetition("INV", index);
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
