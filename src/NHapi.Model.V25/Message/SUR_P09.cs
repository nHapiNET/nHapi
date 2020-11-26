using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V25.Group;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Message

{
///<summary>
/// Represents a SUR_P09 message structure (see chapter 7.11.2). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SUR_P09_FACILITY (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class SUR_P09 : AbstractMessage  {

	///<summary> 
	/// Creates a new SUR_P09 Group with custom IModelClassFactory.
	///</summary>
	public SUR_P09(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new SUR_P09 Group with DefaultModelClassFactory. 
	///</summary> 
	public SUR_P09() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for SUR_P09.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SUR_P09_FACILITY), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SUR_P09 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of SUR_P09_FACILITY (a Group object) - creates it if necessary
	///</summary>
	public SUR_P09_FACILITY GetFACILITY() {
	   SUR_P09_FACILITY ret = null;
	   try {
	      ret = (SUR_P09_FACILITY)this.GetStructure("FACILITY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SUR_P09_FACILITY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SUR_P09_FACILITY GetFACILITY(int rep) { 
	   return (SUR_P09_FACILITY)this.GetStructure("FACILITY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SUR_P09_FACILITY 
	 */ 
	public int FACILITYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("FACILITY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SUR_P09_FACILITY results 
	 */ 
	public IEnumerable<SUR_P09_FACILITY> FACILITYs 
	{ 
		get
		{
			for (int rep = 0; rep < FACILITYRepetitionsUsed; rep++)
			{
				yield return (SUR_P09_FACILITY)this.GetStructure("FACILITY", rep);
			}
		}
	}

	///<summary>
	///Adds a new SUR_P09_FACILITY
	///</summary>
	public SUR_P09_FACILITY AddFACILITY()
	{
		return this.AddStructure("FACILITY") as SUR_P09_FACILITY;
	}

	///<summary>
	///Removes the given SUR_P09_FACILITY
	///</summary>
	public void RemoveFACILITY(SUR_P09_FACILITY toRemove)
	{
		this.RemoveStructure("FACILITY", toRemove);
	}

	///<summary>
	///Removes the SUR_P09_FACILITY at the given index
	///</summary>
	public void RemoveFACILITYAt(int index)
	{
		this.RemoveRepetition("FACILITY", index);
	}

}
}
