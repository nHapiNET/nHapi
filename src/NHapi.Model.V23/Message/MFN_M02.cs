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
/// Represents a MFN_M02 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: MFI (Master file identification segment) </li>
///<li>2: MFN_M02_MF_STAFF (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M02 : AbstractMessage  {

	///<summary> 
	/// Creates a new MFN_M02 Group with custom IModelClassFactory.
	///</summary>
	public MFN_M02(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new MFN_M02 Group with DefaultModelClassFactory. 
	///</summary> 
	public MFN_M02() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for MFN_M02.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFN_M02_MF_STAFF), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M02 - this is probably a bug in the source code generator.", e);
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
	/// Returns MFI (Master file identification segment) - creates it if necessary
	///</summary>
	public MFI MFI { 
get{
	   MFI ret = null;
	   try {
	      ret = (MFI)this.GetStructure("MFI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of MFN_M02_MF_STAFF (a Group object) - creates it if necessary
	///</summary>
	public MFN_M02_MF_STAFF GetMF_STAFF() {
	   MFN_M02_MF_STAFF ret = null;
	   try {
	      ret = (MFN_M02_MF_STAFF)this.GetStructure("MF_STAFF");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M02_MF_STAFF
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M02_MF_STAFF GetMF_STAFF(int rep) { 
	   return (MFN_M02_MF_STAFF)this.GetStructure("MF_STAFF", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M02_MF_STAFF 
	 */ 
	public int MF_STAFFRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_STAFF").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFN_M02_MF_STAFF results 
	 */ 
	public IEnumerable<MFN_M02_MF_STAFF> MF_STAFFs 
	{ 
		get
		{
			for (int rep = 0; rep < MF_STAFFRepetitionsUsed; rep++)
			{
				yield return (MFN_M02_MF_STAFF)this.GetStructure("MF_STAFF", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFN_M02_MF_STAFF
	///</summary>
	public MFN_M02_MF_STAFF AddMF_STAFF()
	{
		return this.AddStructure("MF_STAFF") as MFN_M02_MF_STAFF;
	}

	///<summary>
	///Removes the given MFN_M02_MF_STAFF
	///</summary>
	public void RemoveMF_STAFF(MFN_M02_MF_STAFF toRemove)
	{
		this.RemoveStructure("MF_STAFF", toRemove);
	}

	///<summary>
	///Removes the MFN_M02_MF_STAFF at the given index
	///</summary>
	public void RemoveMF_STAFFAt(int index)
	{
		this.RemoveRepetition("MF_STAFF", index);
	}

}
}
