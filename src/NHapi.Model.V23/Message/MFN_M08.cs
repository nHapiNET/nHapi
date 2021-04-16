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
/// Represents a MFN_M08 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: MFI (Master file identification segment) </li>
///<li>2: MFN_M08_MF_TEST_NUMERIC (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M08 : AbstractMessage  {

	///<summary> 
	/// Creates a new MFN_M08 Group with custom IModelClassFactory.
	///</summary>
	public MFN_M08(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new MFN_M08 Group with DefaultModelClassFactory. 
	///</summary> 
	public MFN_M08() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for MFN_M08.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFN_M08_MF_TEST_NUMERIC), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M08 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of MFN_M08_MF_TEST_NUMERIC (a Group object) - creates it if necessary
	///</summary>
	public MFN_M08_MF_TEST_NUMERIC GetMF_TEST_NUMERIC() {
	   MFN_M08_MF_TEST_NUMERIC ret = null;
	   try {
	      ret = (MFN_M08_MF_TEST_NUMERIC)this.GetStructure("MF_TEST_NUMERIC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M08_MF_TEST_NUMERIC
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M08_MF_TEST_NUMERIC GetMF_TEST_NUMERIC(int rep) { 
	   return (MFN_M08_MF_TEST_NUMERIC)this.GetStructure("MF_TEST_NUMERIC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M08_MF_TEST_NUMERIC 
	 */ 
	public int MF_TEST_NUMERICRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_TEST_NUMERIC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFN_M08_MF_TEST_NUMERIC results 
	 */ 
	public IEnumerable<MFN_M08_MF_TEST_NUMERIC> MF_TEST_NUMERICs 
	{ 
		get
		{
			for (int rep = 0; rep < MF_TEST_NUMERICRepetitionsUsed; rep++)
			{
				yield return (MFN_M08_MF_TEST_NUMERIC)this.GetStructure("MF_TEST_NUMERIC", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFN_M08_MF_TEST_NUMERIC
	///</summary>
	public MFN_M08_MF_TEST_NUMERIC AddMF_TEST_NUMERIC()
	{
		return this.AddStructure("MF_TEST_NUMERIC") as MFN_M08_MF_TEST_NUMERIC;
	}

	///<summary>
	///Removes the given MFN_M08_MF_TEST_NUMERIC
	///</summary>
	public void RemoveMF_TEST_NUMERIC(MFN_M08_MF_TEST_NUMERIC toRemove)
	{
		this.RemoveStructure("MF_TEST_NUMERIC", toRemove);
	}

	///<summary>
	///Removes the MFN_M08_MF_TEST_NUMERIC at the given index
	///</summary>
	public void RemoveMF_TEST_NUMERICAt(int index)
	{
		this.RemoveRepetition("MF_TEST_NUMERIC", index);
	}

}
}
