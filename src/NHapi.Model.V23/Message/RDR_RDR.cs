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
/// Represents a RDR_RDR message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: MSA (Message acknowledgement segment) </li>
///<li>2: ERR (Error segment) optional </li>
///<li>3: RDR_RDR_DEFINITION (a Group object) repeating</li>
///<li>4: DSC (Continuation pointer segment) optional </li>
///</ol>
///</summary>
[Serializable]
public class RDR_RDR : AbstractMessage  {

	///<summary> 
	/// Creates a new RDR_RDR Group with custom IModelClassFactory.
	///</summary>
	public RDR_RDR(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new RDR_RDR Group with DefaultModelClassFactory. 
	///</summary> 
	public RDR_RDR() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for RDR_RDR.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(ERR), false, false);
	      this.add(typeof(RDR_RDR_DEFINITION), true, true);
	      this.add(typeof(DSC), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RDR_RDR - this is probably a bug in the source code generator.", e);
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
	/// Returns MSA (Message acknowledgement segment) - creates it if necessary
	///</summary>
	public MSA MSA { 
get{
	   MSA ret = null;
	   try {
	      ret = (MSA)this.GetStructure("MSA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ERR (Error segment) - creates it if necessary
	///</summary>
	public ERR ERR { 
get{
	   ERR ret = null;
	   try {
	      ret = (ERR)this.GetStructure("ERR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of RDR_RDR_DEFINITION (a Group object) - creates it if necessary
	///</summary>
	public RDR_RDR_DEFINITION GetDEFINITION() {
	   RDR_RDR_DEFINITION ret = null;
	   try {
	      ret = (RDR_RDR_DEFINITION)this.GetStructure("DEFINITION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RDR_RDR_DEFINITION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RDR_RDR_DEFINITION GetDEFINITION(int rep) { 
	   return (RDR_RDR_DEFINITION)this.GetStructure("DEFINITION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RDR_RDR_DEFINITION 
	 */ 
	public int DEFINITIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DEFINITION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RDR_RDR_DEFINITION results 
	 */ 
	public IEnumerable<RDR_RDR_DEFINITION> DEFINITIONs 
	{ 
		get
		{
			for (int rep = 0; rep < DEFINITIONRepetitionsUsed; rep++)
			{
				yield return (RDR_RDR_DEFINITION)this.GetStructure("DEFINITION", rep);
			}
		}
	}

	///<summary>
	///Adds a new RDR_RDR_DEFINITION
	///</summary>
	public RDR_RDR_DEFINITION AddDEFINITION()
	{
		return this.AddStructure("DEFINITION") as RDR_RDR_DEFINITION;
	}

	///<summary>
	///Removes the given RDR_RDR_DEFINITION
	///</summary>
	public void RemoveDEFINITION(RDR_RDR_DEFINITION toRemove)
	{
		this.RemoveStructure("DEFINITION", toRemove);
	}

	///<summary>
	///Removes the RDR_RDR_DEFINITION at the given index
	///</summary>
	public void RemoveDEFINITIONAt(int index)
	{
		this.RemoveRepetition("DEFINITION", index);
	}

	///<summary>
	/// Returns DSC (Continuation pointer segment) - creates it if necessary
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
