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
/// Represents a RPR_I03 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: MSA (Message acknowledgement segment) </li>
///<li>2: RPR_I03_PROVIDER (a Group object) repeating</li>
///<li>3: PID (Patient Identification) optional repeating</li>
///<li>4: NTE (Notes and comments segment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RPR_I03 : AbstractMessage  {

	///<summary> 
	/// Creates a new RPR_I03 Group with custom IModelClassFactory.
	///</summary>
	public RPR_I03(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new RPR_I03 Group with DefaultModelClassFactory. 
	///</summary> 
	public RPR_I03() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for RPR_I03.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(RPR_I03_PROVIDER), true, true);
	      this.add(typeof(PID), false, true);
	      this.add(typeof(NTE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RPR_I03 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of RPR_I03_PROVIDER (a Group object) - creates it if necessary
	///</summary>
	public RPR_I03_PROVIDER GetPROVIDER() {
	   RPR_I03_PROVIDER ret = null;
	   try {
	      ret = (RPR_I03_PROVIDER)this.GetStructure("PROVIDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RPR_I03_PROVIDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RPR_I03_PROVIDER GetPROVIDER(int rep) { 
	   return (RPR_I03_PROVIDER)this.GetStructure("PROVIDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RPR_I03_PROVIDER 
	 */ 
	public int PROVIDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PROVIDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RPR_I03_PROVIDER results 
	 */ 
	public IEnumerable<RPR_I03_PROVIDER> PROVIDERs 
	{ 
		get
		{
			for (int rep = 0; rep < PROVIDERRepetitionsUsed; rep++)
			{
				yield return (RPR_I03_PROVIDER)this.GetStructure("PROVIDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new RPR_I03_PROVIDER
	///</summary>
	public RPR_I03_PROVIDER AddPROVIDER()
	{
		return this.AddStructure("PROVIDER") as RPR_I03_PROVIDER;
	}

	///<summary>
	///Removes the given RPR_I03_PROVIDER
	///</summary>
	public void RemovePROVIDER(RPR_I03_PROVIDER toRemove)
	{
		this.RemoveStructure("PROVIDER", toRemove);
	}

	///<summary>
	///Removes the RPR_I03_PROVIDER at the given index
	///</summary>
	public void RemovePROVIDERAt(int index)
	{
		this.RemoveRepetition("PROVIDER", index);
	}

	///<summary>
	/// Returns  first repetition of PID (Patient Identification) - creates it if necessary
	///</summary>
	public PID GetPID() {
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PID
	/// * (Patient Identification) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PID GetPID(int rep) { 
	   return (PID)this.GetStructure("PID", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PID 
	 */ 
	public int PIDRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PID").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PID results 
	 */ 
	public IEnumerable<PID> PIDs 
	{ 
		get
		{
			for (int rep = 0; rep < PIDRepetitionsUsed; rep++)
			{
				yield return (PID)this.GetStructure("PID", rep);
			}
		}
	}

	///<summary>
	///Adds a new PID
	///</summary>
	public PID AddPID()
	{
		return this.AddStructure("PID") as PID;
	}

	///<summary>
	///Removes the given PID
	///</summary>
	public void RemovePID(PID toRemove)
	{
		this.RemoveStructure("PID", toRemove);
	}

	///<summary>
	///Removes the PID at the given index
	///</summary>
	public void RemovePIDAt(int index)
	{
		this.RemoveRepetition("PID", index);
	}

	///<summary>
	/// Returns  first repetition of NTE (Notes and comments segment) - creates it if necessary
	///</summary>
	public NTE GetNTE() {
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NTE
	/// * (Notes and comments segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NTE GetNTE(int rep) { 
	   return (NTE)this.GetStructure("NTE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NTE 
	 */ 
	public int NTERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NTE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NTE results 
	 */ 
	public IEnumerable<NTE> NTEs 
	{ 
		get
		{
			for (int rep = 0; rep < NTERepetitionsUsed; rep++)
			{
				yield return (NTE)this.GetStructure("NTE", rep);
			}
		}
	}

	///<summary>
	///Adds a new NTE
	///</summary>
	public NTE AddNTE()
	{
		return this.AddStructure("NTE") as NTE;
	}

	///<summary>
	///Removes the given NTE
	///</summary>
	public void RemoveNTE(NTE toRemove)
	{
		this.RemoveStructure("NTE", toRemove);
	}

	///<summary>
	///Removes the NTE at the given index
	///</summary>
	public void RemoveNTEAt(int index)
	{
		this.RemoveRepetition("NTE", index);
	}

}
}
