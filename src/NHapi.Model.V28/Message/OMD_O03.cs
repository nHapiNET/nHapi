using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V28.Group;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Message

{
///<summary>
/// Represents a OMD_O03 message structure (see chapter 4.7.1). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: SFT (Software Segment) optional repeating</li>
///<li>2: UAC (User Authentication Credential Segment) optional </li>
///<li>3: NTE (Notes and Comments) optional repeating</li>
///<li>4: OMD_O03_PATIENT (a Group object) optional </li>
///<li>5: OMD_O03_ORDER_DIET (a Group object) repeating</li>
///<li>6: OMD_O03_ORDER_TRAY (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class OMD_O03 : AbstractMessage  {

	///<summary> 
	/// Creates a new OMD_O03 Group with custom IModelClassFactory.
	///</summary>
	public OMD_O03(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new OMD_O03 Group with DefaultModelClassFactory. 
	///</summary> 
	public OMD_O03() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for OMD_O03.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(SFT), false, true);
	      this.add(typeof(UAC), false, false);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(OMD_O03_PATIENT), false, false);
	      this.add(typeof(OMD_O03_ORDER_DIET), true, true);
	      this.add(typeof(OMD_O03_ORDER_TRAY), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating OMD_O03 - this is probably a bug in the source code generator.", e);
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
	/// Returns  first repetition of SFT (Software Segment) - creates it if necessary
	///</summary>
	public SFT GetSFT() {
	   SFT ret = null;
	   try {
	      ret = (SFT)this.GetStructure("SFT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SFT
	/// * (Software Segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SFT GetSFT(int rep) { 
	   return (SFT)this.GetStructure("SFT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SFT 
	 */ 
	public int SFTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SFT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the SFT results 
	 */ 
	public IEnumerable<SFT> SFTs 
	{ 
		get
		{
			for (int rep = 0; rep < SFTRepetitionsUsed; rep++)
			{
				yield return (SFT)this.GetStructure("SFT", rep);
			}
		}
	}

	///<summary>
	///Adds a new SFT
	///</summary>
	public SFT AddSFT()
	{
		return this.AddStructure("SFT") as SFT;
	}

	///<summary>
	///Removes the given SFT
	///</summary>
	public void RemoveSFT(SFT toRemove)
	{
		this.RemoveStructure("SFT", toRemove);
	}

	///<summary>
	///Removes the SFT at the given index
	///</summary>
	public void RemoveSFTAt(int index)
	{
		this.RemoveRepetition("SFT", index);
	}

	///<summary>
	/// Returns UAC (User Authentication Credential Segment) - creates it if necessary
	///</summary>
	public UAC UAC { 
get{
	   UAC ret = null;
	   try {
	      ret = (UAC)this.GetStructure("UAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NTE (Notes and Comments) - creates it if necessary
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
	/// * (Notes and Comments) - creates it if necessary
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

	///<summary>
	/// Returns OMD_O03_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public OMD_O03_PATIENT PATIENT { 
get{
	   OMD_O03_PATIENT ret = null;
	   try {
	      ret = (OMD_O03_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of OMD_O03_ORDER_DIET (a Group object) - creates it if necessary
	///</summary>
	public OMD_O03_ORDER_DIET GetORDER_DIET() {
	   OMD_O03_ORDER_DIET ret = null;
	   try {
	      ret = (OMD_O03_ORDER_DIET)this.GetStructure("ORDER_DIET");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OMD_O03_ORDER_DIET
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OMD_O03_ORDER_DIET GetORDER_DIET(int rep) { 
	   return (OMD_O03_ORDER_DIET)this.GetStructure("ORDER_DIET", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OMD_O03_ORDER_DIET 
	 */ 
	public int ORDER_DIETRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER_DIET").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OMD_O03_ORDER_DIET results 
	 */ 
	public IEnumerable<OMD_O03_ORDER_DIET> ORDER_DIETs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDER_DIETRepetitionsUsed; rep++)
			{
				yield return (OMD_O03_ORDER_DIET)this.GetStructure("ORDER_DIET", rep);
			}
		}
	}

	///<summary>
	///Adds a new OMD_O03_ORDER_DIET
	///</summary>
	public OMD_O03_ORDER_DIET AddORDER_DIET()
	{
		return this.AddStructure("ORDER_DIET") as OMD_O03_ORDER_DIET;
	}

	///<summary>
	///Removes the given OMD_O03_ORDER_DIET
	///</summary>
	public void RemoveORDER_DIET(OMD_O03_ORDER_DIET toRemove)
	{
		this.RemoveStructure("ORDER_DIET", toRemove);
	}

	///<summary>
	///Removes the OMD_O03_ORDER_DIET at the given index
	///</summary>
	public void RemoveORDER_DIETAt(int index)
	{
		this.RemoveRepetition("ORDER_DIET", index);
	}

	///<summary>
	/// Returns  first repetition of OMD_O03_ORDER_TRAY (a Group object) - creates it if necessary
	///</summary>
	public OMD_O03_ORDER_TRAY GetORDER_TRAY() {
	   OMD_O03_ORDER_TRAY ret = null;
	   try {
	      ret = (OMD_O03_ORDER_TRAY)this.GetStructure("ORDER_TRAY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OMD_O03_ORDER_TRAY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OMD_O03_ORDER_TRAY GetORDER_TRAY(int rep) { 
	   return (OMD_O03_ORDER_TRAY)this.GetStructure("ORDER_TRAY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OMD_O03_ORDER_TRAY 
	 */ 
	public int ORDER_TRAYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER_TRAY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the OMD_O03_ORDER_TRAY results 
	 */ 
	public IEnumerable<OMD_O03_ORDER_TRAY> ORDER_TRAYs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDER_TRAYRepetitionsUsed; rep++)
			{
				yield return (OMD_O03_ORDER_TRAY)this.GetStructure("ORDER_TRAY", rep);
			}
		}
	}

	///<summary>
	///Adds a new OMD_O03_ORDER_TRAY
	///</summary>
	public OMD_O03_ORDER_TRAY AddORDER_TRAY()
	{
		return this.AddStructure("ORDER_TRAY") as OMD_O03_ORDER_TRAY;
	}

	///<summary>
	///Removes the given OMD_O03_ORDER_TRAY
	///</summary>
	public void RemoveORDER_TRAY(OMD_O03_ORDER_TRAY toRemove)
	{
		this.RemoveStructure("ORDER_TRAY", toRemove);
	}

	///<summary>
	///Removes the OMD_O03_ORDER_TRAY at the given index
	///</summary>
	public void RemoveORDER_TRAYAt(int index)
	{
		this.RemoveRepetition("ORDER_TRAY", index);
	}

}
}
