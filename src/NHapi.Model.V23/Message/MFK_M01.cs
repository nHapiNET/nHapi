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
/// Represents a MFK_M01 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: MSA (Message acknowledgement segment) </li>
///<li>2: ERR (Error segment) optional </li>
///<li>3: ERR (Error segment) optional </li>
///<li>4: MFI (Master file identification segment) </li>
///<li>5: MFA (Master file acknowledgement segment) optional repeating</li>
///<li>6: MFI (Master file identification segment) </li>
///<li>7: MFK_M01_MF (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class MFK_M01 : AbstractMessage  {

	///<summary> 
	/// Creates a new MFK_M01 Group with custom IModelClassFactory.
	///</summary>
	public MFK_M01(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new MFK_M01 Group with DefaultModelClassFactory. 
	///</summary> 
	public MFK_M01() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for MFK_M01.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(ERR), false, false);
	      this.add(typeof(ERR), false, false);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFA), false, true);
	      this.add(typeof(MFI), true, false);
	      this.add(typeof(MFK_M01_MF), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFK_M01 - this is probably a bug in the source code generator.", e);
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
	/// Returns ERR2 (Error segment) - creates it if necessary
	///</summary>
	public ERR ERR2 { 
get{
	   ERR ret = null;
	   try {
	      ret = (ERR)this.GetStructure("ERR2");
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
	/// Returns  first repetition of MFA (Master file acknowledgement segment) - creates it if necessary
	///</summary>
	public MFA GetMFA() {
	   MFA ret = null;
	   try {
	      ret = (MFA)this.GetStructure("MFA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFA
	/// * (Master file acknowledgement segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFA GetMFA(int rep) { 
	   return (MFA)this.GetStructure("MFA", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFA 
	 */ 
	public int MFARepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("MFA").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the MFA results 
	 */ 
	public IEnumerable<MFA> MFAs 
	{ 
		get
		{
			for (int rep = 0; rep < MFARepetitionsUsed; rep++)
			{
				yield return (MFA)this.GetStructure("MFA", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFA
	///</summary>
	public MFA AddMFA()
	{
		return this.AddStructure("MFA") as MFA;
	}

	///<summary>
	///Removes the given MFA
	///</summary>
	public void RemoveMFA(MFA toRemove)
	{
		this.RemoveStructure("MFA", toRemove);
	}

	///<summary>
	///Removes the MFA at the given index
	///</summary>
	public void RemoveMFAAt(int index)
	{
		this.RemoveRepetition("MFA", index);
	}

	///<summary>
	/// Returns MFI2 (Master file identification segment) - creates it if necessary
	///</summary>
	public MFI MFI2 { 
get{
	   MFI ret = null;
	   try {
	      ret = (MFI)this.GetStructure("MFI2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of MFK_M01_MF (a Group object) - creates it if necessary
	///</summary>
	public MFK_M01_MF GetMF() {
	   MFK_M01_MF ret = null;
	   try {
	      ret = (MFK_M01_MF)this.GetStructure("MF");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of MFK_M01_MF
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public MFK_M01_MF GetMF(int rep) { 
	   return (MFK_M01_MF)this.GetStructure("MF", rep);
	}

	/** 
	 * Returns the number of existing repetitions of MFK_M01_MF 
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
	 * Enumerate over the MFK_M01_MF results 
	 */ 
	public IEnumerable<MFK_M01_MF> MFs 
	{ 
		get
		{
			for (int rep = 0; rep < MFRepetitionsUsed; rep++)
			{
				yield return (MFK_M01_MF)this.GetStructure("MF", rep);
			}
		}
	}

	///<summary>
	///Adds a new MFK_M01_MF
	///</summary>
	public MFK_M01_MF AddMF()
	{
		return this.AddStructure("MF") as MFK_M01_MF;
	}

	///<summary>
	///Removes the given MFK_M01_MF
	///</summary>
	public void RemoveMF(MFK_M01_MF toRemove)
	{
		this.RemoveStructure("MF", toRemove);
	}

	///<summary>
	///Removes the MFK_M01_MF at the given index
	///</summary>
	public void RemoveMFAt(int index)
	{
		this.RemoveRepetition("MF", index);
	}

}
}
