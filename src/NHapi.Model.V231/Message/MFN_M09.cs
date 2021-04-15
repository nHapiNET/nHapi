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
/// Represents a MFN_M09 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MSH - message header segment) </li>
///<li>1: MFI (MFI - master file identification segment) </li>
///<li>2: MFN_M09_MF_TEST_CATEGORICAL (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M09 : AbstractMessage  {

	///<summary> 
	/// Creates a new MFN_M09 Group with custom IModelClassFactory.
	///</summary>
	public MFN_M09(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new MFN_M09 Group with DefaultModelClassFactory. 
	///</summary> 
	public MFN_M09() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for MFN_M09.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFN_M09_MF_TEST_CATEGORICAL), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M09 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of MFN_M09_MF_TEST_CATEGORICAL (a Group object) - creates it if necessary
	///</summary>
	public MFN_M09_MF_TEST_CATEGORICAL GetMF_TEST_CATEGORICAL() {
	   MFN_M09_MF_TEST_CATEGORICAL ret = null;
	   try {
	      ret = (MFN_M09_MF_TEST_CATEGORICAL)this.GetStructure("MF_TEST_CATEGORICAL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M09_MF_TEST_CATEGORICAL
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M09_MF_TEST_CATEGORICAL GetMF_TEST_CATEGORICAL(int rep) { 
	   return (MFN_M09_MF_TEST_CATEGORICAL)this.GetStructure("MF_TEST_CATEGORICAL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M09_MF_TEST_CATEGORICAL 
	 */ 
	public int MF_TEST_CATEGORICALRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_TEST_CATEGORICAL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFN_M09_MF_TEST_CATEGORICAL results 
	 */ 
	public IEnumerable<MFN_M09_MF_TEST_CATEGORICAL> MF_TEST_CATEGORICALs 
	{ 
		get
		{
			for (int rep = 0; rep < MF_TEST_CATEGORICALRepetitionsUsed; rep++)
			{
				yield return (MFN_M09_MF_TEST_CATEGORICAL)this.GetStructure("MF_TEST_CATEGORICAL", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFN_M09_MF_TEST_CATEGORICAL
	///</summary>
	public MFN_M09_MF_TEST_CATEGORICAL AddMF_TEST_CATEGORICAL()
	{
		return this.AddStructure("MF_TEST_CATEGORICAL") as MFN_M09_MF_TEST_CATEGORICAL;
	}

	///<summary>
	///Removes the given MFN_M09_MF_TEST_CATEGORICAL
	///</summary>
	public void RemoveMF_TEST_CATEGORICAL(MFN_M09_MF_TEST_CATEGORICAL toRemove)
	{
		this.RemoveStructure("MF_TEST_CATEGORICAL", toRemove);
	}

	///<summary>
	///Removes the MFN_M09_MF_TEST_CATEGORICAL at the given index
	///</summary>
	public void RemoveMF_TEST_CATEGORICALAt(int index)
	{
		this.RemoveRepetition("MF_TEST_CATEGORICAL", index);
	}

}
}
