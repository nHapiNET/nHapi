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
/// Represents a REF_I13 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: RF1 (Referral Information Segment) optional </li>
///<li>2: REF_I13_AUTHORIZATION (a Group object) optional </li>
///<li>3: REF_I13_PROVIDER (a Group object) repeating</li>
///<li>4: PID (Patient Identification) </li>
///<li>5: NK1 (Next of kin) optional repeating</li>
///<li>6: GT1 (Guarantor) optional repeating</li>
///<li>7: REF_I13_INSURANCE (a Group object) optional repeating</li>
///<li>8: ACC (Accident) optional </li>
///<li>9: DG1 (Diagnosis) optional repeating</li>
///<li>10: DRG (Diagnosis Related Group) optional repeating</li>
///<li>11: AL1 (Patient allergy information) optional repeating</li>
///<li>12: REF_I13_PROCEDURE (a Group object) optional repeating</li>
///<li>13: REF_I13_RESULTS (a Group object) optional repeating</li>
///<li>14: REF_I13_VISIT (a Group object) optional </li>
///<li>15: NTE (Notes and comments segment) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class REF_I13 : AbstractMessage  {

	///<summary> 
	/// Creates a new REF_I13 Group with custom IModelClassFactory.
	///</summary>
	public REF_I13(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new REF_I13 Group with DefaultModelClassFactory. 
	///</summary> 
	public REF_I13() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for REF_I13.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(RF1), false, false);
	      this.add(typeof(REF_I13_AUTHORIZATION), false, false);
	      this.add(typeof(REF_I13_PROVIDER), true, true);
	      this.add(typeof(PID), true, false);
	      this.add(typeof(NK1), false, true);
	      this.add(typeof(GT1), false, true);
	      this.add(typeof(REF_I13_INSURANCE), false, true);
	      this.add(typeof(ACC), false, false);
	      this.add(typeof(DG1), false, true);
	      this.add(typeof(DRG), false, true);
	      this.add(typeof(AL1), false, true);
	      this.add(typeof(REF_I13_PROCEDURE), false, true);
	      this.add(typeof(REF_I13_RESULTS), false, true);
	      this.add(typeof(REF_I13_VISIT), false, false);
	      this.add(typeof(NTE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating REF_I13 - this is probably a bug in the source code generator.", e);
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
	/// Returns RF1 (Referral Information Segment) - creates it if necessary
	///</summary>
	public RF1 RF1 { 
get{
	   RF1 ret = null;
	   try {
	      ret = (RF1)this.GetStructure("RF1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns REF_I13_AUTHORIZATION (a Group object) - creates it if necessary
	///</summary>
	public REF_I13_AUTHORIZATION AUTHORIZATION { 
get{
	   REF_I13_AUTHORIZATION ret = null;
	   try {
	      ret = (REF_I13_AUTHORIZATION)this.GetStructure("AUTHORIZATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of REF_I13_PROVIDER (a Group object) - creates it if necessary
	///</summary>
	public REF_I13_PROVIDER GetPROVIDER() {
	   REF_I13_PROVIDER ret = null;
	   try {
	      ret = (REF_I13_PROVIDER)this.GetStructure("PROVIDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of REF_I13_PROVIDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public REF_I13_PROVIDER GetPROVIDER(int rep) { 
	   return (REF_I13_PROVIDER)this.GetStructure("PROVIDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of REF_I13_PROVIDER 
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
	 * Enumerate over the REF_I13_PROVIDER results 
	 */ 
	public IEnumerable<REF_I13_PROVIDER> PROVIDERs 
	{ 
		get
		{
			for (int rep = 0; rep < PROVIDERRepetitionsUsed; rep++)
			{
				yield return (REF_I13_PROVIDER)this.GetStructure("PROVIDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new REF_I13_PROVIDER
	///</summary>
	public REF_I13_PROVIDER AddPROVIDER()
	{
		return this.AddStructure("PROVIDER") as REF_I13_PROVIDER;
	}

	///<summary>
	///Removes the given REF_I13_PROVIDER
	///</summary>
	public void RemovePROVIDER(REF_I13_PROVIDER toRemove)
	{
		this.RemoveStructure("PROVIDER", toRemove);
	}

	///<summary>
	///Removes the REF_I13_PROVIDER at the given index
	///</summary>
	public void RemovePROVIDERAt(int index)
	{
		this.RemoveRepetition("PROVIDER", index);
	}

	///<summary>
	/// Returns PID (Patient Identification) - creates it if necessary
	///</summary>
	public PID PID { 
get{
	   PID ret = null;
	   try {
	      ret = (PID)this.GetStructure("PID");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of NK1 (Next of kin) - creates it if necessary
	///</summary>
	public NK1 GetNK1() {
	   NK1 ret = null;
	   try {
	      ret = (NK1)this.GetStructure("NK1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of NK1
	/// * (Next of kin) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public NK1 GetNK1(int rep) { 
	   return (NK1)this.GetStructure("NK1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of NK1 
	 */ 
	public int NK1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("NK1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the NK1 results 
	 */ 
	public IEnumerable<NK1> NK1s 
	{ 
		get
		{
			for (int rep = 0; rep < NK1RepetitionsUsed; rep++)
			{
				yield return (NK1)this.GetStructure("NK1", rep);
			}
		}
	}

	///<summary>
	///Adds a new NK1
	///</summary>
	public NK1 AddNK1()
	{
		return this.AddStructure("NK1") as NK1;
	}

	///<summary>
	///Removes the given NK1
	///</summary>
	public void RemoveNK1(NK1 toRemove)
	{
		this.RemoveStructure("NK1", toRemove);
	}

	///<summary>
	///Removes the NK1 at the given index
	///</summary>
	public void RemoveNK1At(int index)
	{
		this.RemoveRepetition("NK1", index);
	}

	///<summary>
	/// Returns  first repetition of GT1 (Guarantor) - creates it if necessary
	///</summary>
	public GT1 GetGT1() {
	   GT1 ret = null;
	   try {
	      ret = (GT1)this.GetStructure("GT1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of GT1
	/// * (Guarantor) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public GT1 GetGT1(int rep) { 
	   return (GT1)this.GetStructure("GT1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of GT1 
	 */ 
	public int GT1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("GT1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the GT1 results 
	 */ 
	public IEnumerable<GT1> GT1s 
	{ 
		get
		{
			for (int rep = 0; rep < GT1RepetitionsUsed; rep++)
			{
				yield return (GT1)this.GetStructure("GT1", rep);
			}
		}
	}

	///<summary>
	///Adds a new GT1
	///</summary>
	public GT1 AddGT1()
	{
		return this.AddStructure("GT1") as GT1;
	}

	///<summary>
	///Removes the given GT1
	///</summary>
	public void RemoveGT1(GT1 toRemove)
	{
		this.RemoveStructure("GT1", toRemove);
	}

	///<summary>
	///Removes the GT1 at the given index
	///</summary>
	public void RemoveGT1At(int index)
	{
		this.RemoveRepetition("GT1", index);
	}

	///<summary>
	/// Returns  first repetition of REF_I13_INSURANCE (a Group object) - creates it if necessary
	///</summary>
	public REF_I13_INSURANCE GetINSURANCE() {
	   REF_I13_INSURANCE ret = null;
	   try {
	      ret = (REF_I13_INSURANCE)this.GetStructure("INSURANCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of REF_I13_INSURANCE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public REF_I13_INSURANCE GetINSURANCE(int rep) { 
	   return (REF_I13_INSURANCE)this.GetStructure("INSURANCE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of REF_I13_INSURANCE 
	 */ 
	public int INSURANCERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("INSURANCE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the REF_I13_INSURANCE results 
	 */ 
	public IEnumerable<REF_I13_INSURANCE> INSURANCEs 
	{ 
		get
		{
			for (int rep = 0; rep < INSURANCERepetitionsUsed; rep++)
			{
				yield return (REF_I13_INSURANCE)this.GetStructure("INSURANCE", rep);
			}
		}
	}

	///<summary>
	///Adds a new REF_I13_INSURANCE
	///</summary>
	public REF_I13_INSURANCE AddINSURANCE()
	{
		return this.AddStructure("INSURANCE") as REF_I13_INSURANCE;
	}

	///<summary>
	///Removes the given REF_I13_INSURANCE
	///</summary>
	public void RemoveINSURANCE(REF_I13_INSURANCE toRemove)
	{
		this.RemoveStructure("INSURANCE", toRemove);
	}

	///<summary>
	///Removes the REF_I13_INSURANCE at the given index
	///</summary>
	public void RemoveINSURANCEAt(int index)
	{
		this.RemoveRepetition("INSURANCE", index);
	}

	///<summary>
	/// Returns ACC (Accident) - creates it if necessary
	///</summary>
	public ACC ACC { 
get{
	   ACC ret = null;
	   try {
	      ret = (ACC)this.GetStructure("ACC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of DG1 (Diagnosis) - creates it if necessary
	///</summary>
	public DG1 GetDG1() {
	   DG1 ret = null;
	   try {
	      ret = (DG1)this.GetStructure("DG1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DG1
	/// * (Diagnosis) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DG1 GetDG1(int rep) { 
	   return (DG1)this.GetStructure("DG1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DG1 
	 */ 
	public int DG1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DG1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DG1 results 
	 */ 
	public IEnumerable<DG1> DG1s 
	{ 
		get
		{
			for (int rep = 0; rep < DG1RepetitionsUsed; rep++)
			{
				yield return (DG1)this.GetStructure("DG1", rep);
			}
		}
	}

	///<summary>
	///Adds a new DG1
	///</summary>
	public DG1 AddDG1()
	{
		return this.AddStructure("DG1") as DG1;
	}

	///<summary>
	///Removes the given DG1
	///</summary>
	public void RemoveDG1(DG1 toRemove)
	{
		this.RemoveStructure("DG1", toRemove);
	}

	///<summary>
	///Removes the DG1 at the given index
	///</summary>
	public void RemoveDG1At(int index)
	{
		this.RemoveRepetition("DG1", index);
	}

	///<summary>
	/// Returns  first repetition of DRG (Diagnosis Related Group) - creates it if necessary
	///</summary>
	public DRG GetDRG() {
	   DRG ret = null;
	   try {
	      ret = (DRG)this.GetStructure("DRG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of DRG
	/// * (Diagnosis Related Group) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public DRG GetDRG(int rep) { 
	   return (DRG)this.GetStructure("DRG", rep);
	}

	/** 
	 * Returns the number of existing repetitions of DRG 
	 */ 
	public int DRGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("DRG").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the DRG results 
	 */ 
	public IEnumerable<DRG> DRGs 
	{ 
		get
		{
			for (int rep = 0; rep < DRGRepetitionsUsed; rep++)
			{
				yield return (DRG)this.GetStructure("DRG", rep);
			}
		}
	}

	///<summary>
	///Adds a new DRG
	///</summary>
	public DRG AddDRG()
	{
		return this.AddStructure("DRG") as DRG;
	}

	///<summary>
	///Removes the given DRG
	///</summary>
	public void RemoveDRG(DRG toRemove)
	{
		this.RemoveStructure("DRG", toRemove);
	}

	///<summary>
	///Removes the DRG at the given index
	///</summary>
	public void RemoveDRGAt(int index)
	{
		this.RemoveRepetition("DRG", index);
	}

	///<summary>
	/// Returns  first repetition of AL1 (Patient allergy information) - creates it if necessary
	///</summary>
	public AL1 GetAL1() {
	   AL1 ret = null;
	   try {
	      ret = (AL1)this.GetStructure("AL1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of AL1
	/// * (Patient allergy information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public AL1 GetAL1(int rep) { 
	   return (AL1)this.GetStructure("AL1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of AL1 
	 */ 
	public int AL1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("AL1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the AL1 results 
	 */ 
	public IEnumerable<AL1> AL1s 
	{ 
		get
		{
			for (int rep = 0; rep < AL1RepetitionsUsed; rep++)
			{
				yield return (AL1)this.GetStructure("AL1", rep);
			}
		}
	}

	///<summary>
	///Adds a new AL1
	///</summary>
	public AL1 AddAL1()
	{
		return this.AddStructure("AL1") as AL1;
	}

	///<summary>
	///Removes the given AL1
	///</summary>
	public void RemoveAL1(AL1 toRemove)
	{
		this.RemoveStructure("AL1", toRemove);
	}

	///<summary>
	///Removes the AL1 at the given index
	///</summary>
	public void RemoveAL1At(int index)
	{
		this.RemoveRepetition("AL1", index);
	}

	///<summary>
	/// Returns  first repetition of REF_I13_PROCEDURE (a Group object) - creates it if necessary
	///</summary>
	public REF_I13_PROCEDURE GetPROCEDURE() {
	   REF_I13_PROCEDURE ret = null;
	   try {
	      ret = (REF_I13_PROCEDURE)this.GetStructure("PROCEDURE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of REF_I13_PROCEDURE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public REF_I13_PROCEDURE GetPROCEDURE(int rep) { 
	   return (REF_I13_PROCEDURE)this.GetStructure("PROCEDURE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of REF_I13_PROCEDURE 
	 */ 
	public int PROCEDURERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PROCEDURE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the REF_I13_PROCEDURE results 
	 */ 
	public IEnumerable<REF_I13_PROCEDURE> PROCEDUREs 
	{ 
		get
		{
			for (int rep = 0; rep < PROCEDURERepetitionsUsed; rep++)
			{
				yield return (REF_I13_PROCEDURE)this.GetStructure("PROCEDURE", rep);
			}
		}
	}

	///<summary>
	///Adds a new REF_I13_PROCEDURE
	///</summary>
	public REF_I13_PROCEDURE AddPROCEDURE()
	{
		return this.AddStructure("PROCEDURE") as REF_I13_PROCEDURE;
	}

	///<summary>
	///Removes the given REF_I13_PROCEDURE
	///</summary>
	public void RemovePROCEDURE(REF_I13_PROCEDURE toRemove)
	{
		this.RemoveStructure("PROCEDURE", toRemove);
	}

	///<summary>
	///Removes the REF_I13_PROCEDURE at the given index
	///</summary>
	public void RemovePROCEDUREAt(int index)
	{
		this.RemoveRepetition("PROCEDURE", index);
	}

	///<summary>
	/// Returns  first repetition of REF_I13_RESULTS (a Group object) - creates it if necessary
	///</summary>
	public REF_I13_RESULTS GetRESULTS() {
	   REF_I13_RESULTS ret = null;
	   try {
	      ret = (REF_I13_RESULTS)this.GetStructure("RESULTS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of REF_I13_RESULTS
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public REF_I13_RESULTS GetRESULTS(int rep) { 
	   return (REF_I13_RESULTS)this.GetStructure("RESULTS", rep);
	}

	/** 
	 * Returns the number of existing repetitions of REF_I13_RESULTS 
	 */ 
	public int RESULTSRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RESULTS").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the REF_I13_RESULTS results 
	 */ 
	public IEnumerable<REF_I13_RESULTS> RESULTSs 
	{ 
		get
		{
			for (int rep = 0; rep < RESULTSRepetitionsUsed; rep++)
			{
				yield return (REF_I13_RESULTS)this.GetStructure("RESULTS", rep);
			}
		}
	}

	///<summary>
	///Adds a new REF_I13_RESULTS
	///</summary>
	public REF_I13_RESULTS AddRESULTS()
	{
		return this.AddStructure("RESULTS") as REF_I13_RESULTS;
	}

	///<summary>
	///Removes the given REF_I13_RESULTS
	///</summary>
	public void RemoveRESULTS(REF_I13_RESULTS toRemove)
	{
		this.RemoveStructure("RESULTS", toRemove);
	}

	///<summary>
	///Removes the REF_I13_RESULTS at the given index
	///</summary>
	public void RemoveRESULTSAt(int index)
	{
		this.RemoveRepetition("RESULTS", index);
	}

	///<summary>
	/// Returns REF_I13_VISIT (a Group object) - creates it if necessary
	///</summary>
	public REF_I13_VISIT VISIT { 
get{
	   REF_I13_VISIT ret = null;
	   try {
	      ret = (REF_I13_VISIT)this.GetStructure("VISIT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
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
