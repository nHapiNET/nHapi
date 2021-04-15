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
/// Represents a MFN_M11 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: MFI (Master file identification segment) </li>
///<li>2: MFN_M11_MF_TEST_CALCULATED (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M11 : AbstractMessage  {

	///<summary> 
	/// Creates a new MFN_M11 Group with custom IModelClassFactory.
	///</summary>
	public MFN_M11(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new MFN_M11 Group with DefaultModelClassFactory. 
	///</summary> 
	public MFN_M11() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for MFN_M11.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFN_M11_MF_TEST_CALCULATED), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M11 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of MFN_M11_MF_TEST_CALCULATED (a Group object) - creates it if necessary
	///</summary>
	public MFN_M11_MF_TEST_CALCULATED GetMF_TEST_CALCULATED() {
	   MFN_M11_MF_TEST_CALCULATED ret = null;
	   try {
	      ret = (MFN_M11_MF_TEST_CALCULATED)this.GetStructure("MF_TEST_CALCULATED");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M11_MF_TEST_CALCULATED
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M11_MF_TEST_CALCULATED GetMF_TEST_CALCULATED(int rep) { 
	   return (MFN_M11_MF_TEST_CALCULATED)this.GetStructure("MF_TEST_CALCULATED", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M11_MF_TEST_CALCULATED 
	 */ 
	public int MF_TEST_CALCULATEDRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF_TEST_CALCULATED").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFN_M11_MF_TEST_CALCULATED results 
	 */ 
	public IEnumerable<MFN_M11_MF_TEST_CALCULATED> MF_TEST_CALCULATEDs 
	{ 
		get
		{
			for (int rep = 0; rep < MF_TEST_CALCULATEDRepetitionsUsed; rep++)
			{
				yield return (MFN_M11_MF_TEST_CALCULATED)this.GetStructure("MF_TEST_CALCULATED", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFN_M11_MF_TEST_CALCULATED
	///</summary>
	public MFN_M11_MF_TEST_CALCULATED AddMF_TEST_CALCULATED()
	{
		return this.AddStructure("MF_TEST_CALCULATED") as MFN_M11_MF_TEST_CALCULATED;
	}

	///<summary>
	///Removes the given MFN_M11_MF_TEST_CALCULATED
	///</summary>
	public void RemoveMF_TEST_CALCULATED(MFN_M11_MF_TEST_CALCULATED toRemove)
	{
		this.RemoveStructure("MF_TEST_CALCULATED", toRemove);
	}

	///<summary>
	///Removes the MFN_M11_MF_TEST_CALCULATED at the given index
	///</summary>
	public void RemoveMF_TEST_CALCULATEDAt(int index)
	{
		this.RemoveRepetition("MF_TEST_CALCULATED", index);
	}

}
}
