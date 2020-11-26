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
/// Represents a MFN_M01 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: MFI (Master file identification segment) </li>
///<li>2: MFN_M01_MF (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFN_M01 : AbstractMessage  {

	///<summary> 
	/// Creates a new MFN_M01 Group with custom IModelClassFactory.
	///</summary>
	public MFN_M01(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new MFN_M01 Group with DefaultModelClassFactory. 
	///</summary> 
	public MFN_M01() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for MFN_M01.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFN_M01_MF), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M01 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of MFN_M01_MF (a Group object) - creates it if necessary
	///</summary>
	public MFN_M01_MF GetMF() {
	   MFN_M01_MF ret = null;
	   try {
	      ret = (MFN_M01_MF)this.GetStructure("MF");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFN_M01_MF
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFN_M01_MF GetMF(int rep) { 
	   return (MFN_M01_MF)this.GetStructure("MF", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFN_M01_MF 
	 */ 
	public int MFRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MF").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFN_M01_MF results 
	 */ 
	public IEnumerable<MFN_M01_MF> MFs 
	{ 
		get
		{
			for (int rep = 0; rep < MFRepetitionsUsed; rep++)
			{
				yield return (MFN_M01_MF)this.GetStructure("MF", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFN_M01_MF
	///</summary>
	public MFN_M01_MF AddMF()
	{
		return this.AddStructure("MF") as MFN_M01_MF;
	}

	///<summary>
	///Removes the given MFN_M01_MF
	///</summary>
	public void RemoveMF(MFN_M01_MF toRemove)
	{
		this.RemoveStructure("MF", toRemove);
	}

	///<summary>
	///Removes the MFN_M01_MF at the given index
	///</summary>
	public void RemoveMFAt(int index)
	{
		this.RemoveRepetition("MF", index);
	}

}
}
