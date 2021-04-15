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
/// Represents a MFN_M12 message structure (see chapter 8). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: MFI (Master File Identification) </li>
///<li>2: MFN_M12_MF_OBS_ATTRIBUTES (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M12 : AbstractMessage  {

	///<summary> 
	/// Creates a new MFN_M12 Group with custom IModelClassFactory.
	///</summary>
	public MFN_M12(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new MFN_M12 Group with DefaultModelClassFactory. 
	///</summary> 
	public MFN_M12() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for MFN_M12.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFN_M12_MF_OBS_ATTRIBUTES), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M12 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of MFN_M12_MF_OBS_ATTRIBUTES (a Group object) - creates it if necessary
	///</summary>
	public MFN_M12_MF_OBS_ATTRIBUTES GetMF_OBS_ATTRIBUTES() {
	   MFN_M12_MF_OBS_ATTRIBUTES ret = null;
	   try {
	      ret = (MFN_M12_MF_OBS_ATTRIBUTES)this.GetStructure("MF_OBS_ATTRIBUTES");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M12_MF_OBS_ATTRIBUTES
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M12_MF_OBS_ATTRIBUTES GetMF_OBS_ATTRIBUTES(int rep) { 
	   return (MFN_M12_MF_OBS_ATTRIBUTES)this.GetStructure("MF_OBS_ATTRIBUTES", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M12_MF_OBS_ATTRIBUTES 
	 */ 
	public int MF_OBS_ATTRIBUTESRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_OBS_ATTRIBUTES").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFN_M12_MF_OBS_ATTRIBUTES results 
	 */ 
	public IEnumerable<MFN_M12_MF_OBS_ATTRIBUTES> MF_OBS_ATTRIBUTESs 
	{ 
		get
		{
			for (int rep = 0; rep < MF_OBS_ATTRIBUTESRepetitionsUsed; rep++)
			{
				yield return (MFN_M12_MF_OBS_ATTRIBUTES)this.GetStructure("MF_OBS_ATTRIBUTES", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFN_M12_MF_OBS_ATTRIBUTES
	///</summary>
	public MFN_M12_MF_OBS_ATTRIBUTES AddMF_OBS_ATTRIBUTES()
	{
		return this.AddStructure("MF_OBS_ATTRIBUTES") as MFN_M12_MF_OBS_ATTRIBUTES;
	}

	///<summary>
	///Removes the given MFN_M12_MF_OBS_ATTRIBUTES
	///</summary>
	public void RemoveMF_OBS_ATTRIBUTES(MFN_M12_MF_OBS_ATTRIBUTES toRemove)
	{
		this.RemoveStructure("MF_OBS_ATTRIBUTES", toRemove);
	}

	///<summary>
	///Removes the MFN_M12_MF_OBS_ATTRIBUTES at the given index
	///</summary>
	public void RemoveMF_OBS_ATTRIBUTESAt(int index)
	{
		this.RemoveRepetition("MF_OBS_ATTRIBUTES", index);
	}

}
}
