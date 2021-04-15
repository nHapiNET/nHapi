using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V231.Group;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Message

{
///<summary>
/// Represents a MFN_M06 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MSH - message header segment) </li>
///<li>1: MFI (MFI - master file identification segment) </li>
///<li>2: MFN_M06_MF_CLIN_STUDY (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M06 : AbstractMessage  {

	///<summary> 
	/// Creates a new MFN_M06 Group with custom IModelClassFactory.
	///</summary>
	public MFN_M06(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new MFN_M06 Group with DefaultModelClassFactory. 
	///</summary> 
	public MFN_M06() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for MFN_M06.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFN_M06_MF_CLIN_STUDY), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M06 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MSH - message header segment) - creates it if necessary
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
	/// Returns MFI (MFI - master file identification segment) - creates it if necessary
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
	/// Returns  first repetition of MFN_M06_MF_CLIN_STUDY (a Group object) - creates it if necessary
	///</summary>
	public MFN_M06_MF_CLIN_STUDY GetMF_CLIN_STUDY() {
	   MFN_M06_MF_CLIN_STUDY ret = null;
	   try {
	      ret = (MFN_M06_MF_CLIN_STUDY)this.GetStructure("MF_CLIN_STUDY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M06_MF_CLIN_STUDY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M06_MF_CLIN_STUDY GetMF_CLIN_STUDY(int rep) { 
	   return (MFN_M06_MF_CLIN_STUDY)this.GetStructure("MF_CLIN_STUDY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M06_MF_CLIN_STUDY 
	 */ 
	public int MF_CLIN_STUDYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_CLIN_STUDY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFN_M06_MF_CLIN_STUDY results 
	 */ 
	public IEnumerable<MFN_M06_MF_CLIN_STUDY> MF_CLIN_STUDYs 
	{ 
		get
		{
			for (int rep = 0; rep < MF_CLIN_STUDYRepetitionsUsed; rep++)
			{
				yield return (MFN_M06_MF_CLIN_STUDY)this.GetStructure("MF_CLIN_STUDY", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFN_M06_MF_CLIN_STUDY
	///</summary>
	public MFN_M06_MF_CLIN_STUDY AddMF_CLIN_STUDY()
	{
		return this.AddStructure("MF_CLIN_STUDY") as MFN_M06_MF_CLIN_STUDY;
	}

	///<summary>
	///Removes the given MFN_M06_MF_CLIN_STUDY
	///</summary>
	public void RemoveMF_CLIN_STUDY(MFN_M06_MF_CLIN_STUDY toRemove)
	{
		this.RemoveStructure("MF_CLIN_STUDY", toRemove);
	}

	///<summary>
	///Removes the MFN_M06_MF_CLIN_STUDY at the given index
	///</summary>
	public void RemoveMF_CLIN_STUDYAt(int index)
	{
		this.RemoveRepetition("MF_CLIN_STUDY", index);
	}

}
}
