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
/// Represents a MFN_M05 message structure (see chapter 8). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: MFI (Master File Identification) </li>
///<li>2: MFN_M05_MF_LOCATION (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M05 : AbstractMessage  {

	///<summary> 
	/// Creates a new MFN_M05 Group with custom IModelClassFactory.
	///</summary>
	public MFN_M05(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new MFN_M05 Group with DefaultModelClassFactory. 
	///</summary> 
	public MFN_M05() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for MFN_M05.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFN_M05_MF_LOCATION), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M05 - this is probably a bug in the source code generator.", e);
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
	/// Returns MFI (Master File Identification) - creates it if necessary
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
	/// Returns  first repetition of MFN_M05_MF_LOCATION (a Group object) - creates it if necessary
	///</summary>
	public MFN_M05_MF_LOCATION GetMF_LOCATION() {
	   MFN_M05_MF_LOCATION ret = null;
	   try {
	      ret = (MFN_M05_MF_LOCATION)this.GetStructure("MF_LOCATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M05_MF_LOCATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M05_MF_LOCATION GetMF_LOCATION(int rep) { 
	   return (MFN_M05_MF_LOCATION)this.GetStructure("MF_LOCATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M05_MF_LOCATION 
	 */ 
	public int MF_LOCATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_LOCATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFN_M05_MF_LOCATION results 
	 */ 
	public IEnumerable<MFN_M05_MF_LOCATION> MF_LOCATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < MF_LOCATIONRepetitionsUsed; rep++)
			{
				yield return (MFN_M05_MF_LOCATION)this.GetStructure("MF_LOCATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFN_M05_MF_LOCATION
	///</summary>
	public MFN_M05_MF_LOCATION AddMF_LOCATION()
	{
		return this.AddStructure("MF_LOCATION") as MFN_M05_MF_LOCATION;
	}

	///<summary>
	///Removes the given MFN_M05_MF_LOCATION
	///</summary>
	public void RemoveMF_LOCATION(MFN_M05_MF_LOCATION toRemove)
	{
		this.RemoveStructure("MF_LOCATION", toRemove);
	}

	///<summary>
	///Removes the MFN_M05_MF_LOCATION at the given index
	///</summary>
	public void RemoveMF_LOCATIONAt(int index)
	{
		this.RemoveRepetition("MF_LOCATION", index);
	}

}
}
