using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the RDE_O11_ORDER Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORC (Common Order) </li>
///<li>1: PRT (Participation Information) optional repeating</li>
///<li>2: RDE_O11_TIMING (a Group object) optional repeating</li>
///<li>3: RDE_O11_ORDER_DETAIL (a Group object) optional </li>
///<li>4: RXE (Pharmacy/Treatment Encoded Order) </li>
///<li>5: PRT (Participation Information) optional repeating</li>
///<li>6: NTE (Notes and Comments) optional repeating</li>
///<li>7: RDE_O11_TIMING_ENCODED (a Group object) repeating</li>
///<li>8: RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER (a Group object) optional repeating</li>
///<li>9: RXR (Pharmacy/Treatment Route) repeating</li>
///<li>10: RXC (Pharmacy/Treatment Component Order) optional repeating</li>
///<li>11: CDO (Cumulative Dosage) optional repeating</li>
///<li>12: RDE_O11_OBSERVATION (a Group object) optional repeating</li>
///<li>13: FT1 (Financial Transaction) optional repeating</li>
///<li>14: BLG (Billing) optional </li>
///<li>15: CTI (Clinical Trial Identification) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class RDE_O11_ORDER : AbstractGroup {

	///<summary> 
	/// Creates a new RDE_O11_ORDER Group.
	///</summary>
	public RDE_O11_ORDER(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORC), true, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(RDE_O11_TIMING), false, true);
	      this.add(typeof(RDE_O11_ORDER_DETAIL), false, false);
	      this.add(typeof(RXE), true, false);
	      this.add(typeof(PRT), false, true);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(RDE_O11_TIMING_ENCODED), true, true);
	      this.add(typeof(RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER), false, true);
	      this.add(typeof(RXR), true, true);
	      this.add(typeof(RXC), false, true);
	      this.add(typeof(CDO), false, true);
	      this.add(typeof(RDE_O11_OBSERVATION), false, true);
	      this.add(typeof(FT1), false, true);
	      this.add(typeof(BLG), false, false);
	      this.add(typeof(CTI), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RDE_O11_ORDER - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORC (Common Order) - creates it if necessary
	///</summary>
	public ORC ORC { 
get{
	   ORC ret = null;
	   try {
	      ret = (ORC)this.GetStructure("ORC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PRT (Participation Information) - creates it if necessary
	///</summary>
	public PRT GetPRT() {
	   PRT ret = null;
	   try {
	      ret = (PRT)this.GetStructure("PRT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRT
	/// * (Participation Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRT GetPRT(int rep) { 
	   return (PRT)this.GetStructure("PRT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRT 
	 */ 
	public int PRTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PRT results 
	 */ 
	public IEnumerable<PRT> PRTs 
	{ 
		get
		{
			for (int rep = 0; rep < PRTRepetitionsUsed; rep++)
			{
				yield return (PRT)this.GetStructure("PRT", rep);
			}
		}
	}

	///<summary>
	///Adds a new PRT
	///</summary>
	public PRT AddPRT()
	{
		return this.AddStructure("PRT") as PRT;
	}

	///<summary>
	///Removes the given PRT
	///</summary>
	public void RemovePRT(PRT toRemove)
	{
		this.RemoveStructure("PRT", toRemove);
	}

	///<summary>
	///Removes the PRT at the given index
	///</summary>
	public void RemovePRTAt(int index)
	{
		this.RemoveRepetition("PRT", index);
	}

	///<summary>
	/// Returns  first repetition of RDE_O11_TIMING (a Group object) - creates it if necessary
	///</summary>
	public RDE_O11_TIMING GetTIMING() {
	   RDE_O11_TIMING ret = null;
	   try {
	      ret = (RDE_O11_TIMING)this.GetStructure("TIMING");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RDE_O11_TIMING
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RDE_O11_TIMING GetTIMING(int rep) { 
	   return (RDE_O11_TIMING)this.GetStructure("TIMING", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RDE_O11_TIMING 
	 */ 
	public int TIMINGRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RDE_O11_TIMING results 
	 */ 
	public IEnumerable<RDE_O11_TIMING> TIMINGs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMINGRepetitionsUsed; rep++)
			{
				yield return (RDE_O11_TIMING)this.GetStructure("TIMING", rep);
			}
		}
	}

	///<summary>
	///Adds a new RDE_O11_TIMING
	///</summary>
	public RDE_O11_TIMING AddTIMING()
	{
		return this.AddStructure("TIMING") as RDE_O11_TIMING;
	}

	///<summary>
	///Removes the given RDE_O11_TIMING
	///</summary>
	public void RemoveTIMING(RDE_O11_TIMING toRemove)
	{
		this.RemoveStructure("TIMING", toRemove);
	}

	///<summary>
	///Removes the RDE_O11_TIMING at the given index
	///</summary>
	public void RemoveTIMINGAt(int index)
	{
		this.RemoveRepetition("TIMING", index);
	}

	///<summary>
	/// Returns RDE_O11_ORDER_DETAIL (a Group object) - creates it if necessary
	///</summary>
	public RDE_O11_ORDER_DETAIL ORDER_DETAIL { 
get{
	   RDE_O11_ORDER_DETAIL ret = null;
	   try {
	      ret = (RDE_O11_ORDER_DETAIL)this.GetStructure("ORDER_DETAIL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RXE (Pharmacy/Treatment Encoded Order) - creates it if necessary
	///</summary>
	public RXE RXE { 
get{
	   RXE ret = null;
	   try {
	      ret = (RXE)this.GetStructure("RXE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PRT2 (Participation Information) - creates it if necessary
	///</summary>
	public PRT GetPRT2() {
	   PRT ret = null;
	   try {
	      ret = (PRT)this.GetStructure("PRT2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRT2
	/// * (Participation Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRT GetPRT2(int rep) { 
	   return (PRT)this.GetStructure("PRT2", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRT2 
	 */ 
	public int PRT2RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRT2").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the PRT results 
	 */ 
	public IEnumerable<PRT> PRT2s 
	{ 
		get
		{
			for (int rep = 0; rep < PRT2RepetitionsUsed; rep++)
			{
				yield return (PRT)this.GetStructure("PRT2", rep);
			}
		}
	}

	///<summary>
	///Adds a new PRT
	///</summary>
	public PRT AddPRT2()
	{
		return this.AddStructure("PRT2") as PRT;
	}

	///<summary>
	///Removes the given PRT
	///</summary>
	public void RemovePRT2(PRT toRemove)
	{
		this.RemoveStructure("PRT2", toRemove);
	}

	///<summary>
	///Removes the PRT at the given index
	///</summary>
	public void RemovePRT2At(int index)
	{
		this.RemoveRepetition("PRT2", index);
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
	/// Returns  first repetition of RDE_O11_TIMING_ENCODED (a Group object) - creates it if necessary
	///</summary>
	public RDE_O11_TIMING_ENCODED GetTIMING_ENCODED() {
	   RDE_O11_TIMING_ENCODED ret = null;
	   try {
	      ret = (RDE_O11_TIMING_ENCODED)this.GetStructure("TIMING_ENCODED");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RDE_O11_TIMING_ENCODED
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RDE_O11_TIMING_ENCODED GetTIMING_ENCODED(int rep) { 
	   return (RDE_O11_TIMING_ENCODED)this.GetStructure("TIMING_ENCODED", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RDE_O11_TIMING_ENCODED 
	 */ 
	public int TIMING_ENCODEDRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("TIMING_ENCODED").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RDE_O11_TIMING_ENCODED results 
	 */ 
	public IEnumerable<RDE_O11_TIMING_ENCODED> TIMING_ENCODEDs 
	{ 
		get
		{
			for (int rep = 0; rep < TIMING_ENCODEDRepetitionsUsed; rep++)
			{
				yield return (RDE_O11_TIMING_ENCODED)this.GetStructure("TIMING_ENCODED", rep);
			}
		}
	}

	///<summary>
	///Adds a new RDE_O11_TIMING_ENCODED
	///</summary>
	public RDE_O11_TIMING_ENCODED AddTIMING_ENCODED()
	{
		return this.AddStructure("TIMING_ENCODED") as RDE_O11_TIMING_ENCODED;
	}

	///<summary>
	///Removes the given RDE_O11_TIMING_ENCODED
	///</summary>
	public void RemoveTIMING_ENCODED(RDE_O11_TIMING_ENCODED toRemove)
	{
		this.RemoveStructure("TIMING_ENCODED", toRemove);
	}

	///<summary>
	///Removes the RDE_O11_TIMING_ENCODED at the given index
	///</summary>
	public void RemoveTIMING_ENCODEDAt(int index)
	{
		this.RemoveRepetition("TIMING_ENCODED", index);
	}

	///<summary>
	/// Returns  first repetition of RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER (a Group object) - creates it if necessary
	///</summary>
	public RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER GetPHARMACY_TREATMENT_INFUSION_ORDER() {
	   RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER ret = null;
	   try {
	      ret = (RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER)this.GetStructure("PHARMACY_TREATMENT_INFUSION_ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER GetPHARMACY_TREATMENT_INFUSION_ORDER(int rep) { 
	   return (RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER)this.GetStructure("PHARMACY_TREATMENT_INFUSION_ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER 
	 */ 
	public int PHARMACY_TREATMENT_INFUSION_ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PHARMACY_TREATMENT_INFUSION_ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER results 
	 */ 
	public IEnumerable<RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER> PHARMACY_TREATMENT_INFUSION_ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < PHARMACY_TREATMENT_INFUSION_ORDERRepetitionsUsed; rep++)
			{
				yield return (RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER)this.GetStructure("PHARMACY_TREATMENT_INFUSION_ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER
	///</summary>
	public RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER AddPHARMACY_TREATMENT_INFUSION_ORDER()
	{
		return this.AddStructure("PHARMACY_TREATMENT_INFUSION_ORDER") as RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER;
	}

	///<summary>
	///Removes the given RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER
	///</summary>
	public void RemovePHARMACY_TREATMENT_INFUSION_ORDER(RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER toRemove)
	{
		this.RemoveStructure("PHARMACY_TREATMENT_INFUSION_ORDER", toRemove);
	}

	///<summary>
	///Removes the RDE_O11_PHARMACY_TREATMENT_INFUSION_ORDER at the given index
	///</summary>
	public void RemovePHARMACY_TREATMENT_INFUSION_ORDERAt(int index)
	{
		this.RemoveRepetition("PHARMACY_TREATMENT_INFUSION_ORDER", index);
	}

	///<summary>
	/// Returns  first repetition of RXR (Pharmacy/Treatment Route) - creates it if necessary
	///</summary>
	public RXR GetRXR() {
	   RXR ret = null;
	   try {
	      ret = (RXR)this.GetStructure("RXR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RXR
	/// * (Pharmacy/Treatment Route) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RXR GetRXR(int rep) { 
	   return (RXR)this.GetStructure("RXR", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RXR 
	 */ 
	public int RXRRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RXR").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RXR results 
	 */ 
	public IEnumerable<RXR> RXRs 
	{ 
		get
		{
			for (int rep = 0; rep < RXRRepetitionsUsed; rep++)
			{
				yield return (RXR)this.GetStructure("RXR", rep);
			}
		}
	}

	///<summary>
	///Adds a new RXR
	///</summary>
	public RXR AddRXR()
	{
		return this.AddStructure("RXR") as RXR;
	}

	///<summary>
	///Removes the given RXR
	///</summary>
	public void RemoveRXR(RXR toRemove)
	{
		this.RemoveStructure("RXR", toRemove);
	}

	///<summary>
	///Removes the RXR at the given index
	///</summary>
	public void RemoveRXRAt(int index)
	{
		this.RemoveRepetition("RXR", index);
	}

	///<summary>
	/// Returns  first repetition of RXC (Pharmacy/Treatment Component Order) - creates it if necessary
	///</summary>
	public RXC GetRXC() {
	   RXC ret = null;
	   try {
	      ret = (RXC)this.GetStructure("RXC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RXC
	/// * (Pharmacy/Treatment Component Order) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RXC GetRXC(int rep) { 
	   return (RXC)this.GetStructure("RXC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RXC 
	 */ 
	public int RXCRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RXC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RXC results 
	 */ 
	public IEnumerable<RXC> RXCs 
	{ 
		get
		{
			for (int rep = 0; rep < RXCRepetitionsUsed; rep++)
			{
				yield return (RXC)this.GetStructure("RXC", rep);
			}
		}
	}

	///<summary>
	///Adds a new RXC
	///</summary>
	public RXC AddRXC()
	{
		return this.AddStructure("RXC") as RXC;
	}

	///<summary>
	///Removes the given RXC
	///</summary>
	public void RemoveRXC(RXC toRemove)
	{
		this.RemoveStructure("RXC", toRemove);
	}

	///<summary>
	///Removes the RXC at the given index
	///</summary>
	public void RemoveRXCAt(int index)
	{
		this.RemoveRepetition("RXC", index);
	}

	///<summary>
	/// Returns  first repetition of CDO (Cumulative Dosage) - creates it if necessary
	///</summary>
	public CDO GetCDO() {
	   CDO ret = null;
	   try {
	      ret = (CDO)this.GetStructure("CDO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CDO
	/// * (Cumulative Dosage) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CDO GetCDO(int rep) { 
	   return (CDO)this.GetStructure("CDO", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CDO 
	 */ 
	public int CDORepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CDO").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CDO results 
	 */ 
	public IEnumerable<CDO> CDOs 
	{ 
		get
		{
			for (int rep = 0; rep < CDORepetitionsUsed; rep++)
			{
				yield return (CDO)this.GetStructure("CDO", rep);
			}
		}
	}

	///<summary>
	///Adds a new CDO
	///</summary>
	public CDO AddCDO()
	{
		return this.AddStructure("CDO") as CDO;
	}

	///<summary>
	///Removes the given CDO
	///</summary>
	public void RemoveCDO(CDO toRemove)
	{
		this.RemoveStructure("CDO", toRemove);
	}

	///<summary>
	///Removes the CDO at the given index
	///</summary>
	public void RemoveCDOAt(int index)
	{
		this.RemoveRepetition("CDO", index);
	}

	///<summary>
	/// Returns  first repetition of RDE_O11_OBSERVATION (a Group object) - creates it if necessary
	///</summary>
	public RDE_O11_OBSERVATION GetOBSERVATION() {
	   RDE_O11_OBSERVATION ret = null;
	   try {
	      ret = (RDE_O11_OBSERVATION)this.GetStructure("OBSERVATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RDE_O11_OBSERVATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RDE_O11_OBSERVATION GetOBSERVATION(int rep) { 
	   return (RDE_O11_OBSERVATION)this.GetStructure("OBSERVATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RDE_O11_OBSERVATION 
	 */ 
	public int OBSERVATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBSERVATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RDE_O11_OBSERVATION results 
	 */ 
	public IEnumerable<RDE_O11_OBSERVATION> OBSERVATIONs 
	{ 
		get
		{
			for (int rep = 0; rep < OBSERVATIONRepetitionsUsed; rep++)
			{
				yield return (RDE_O11_OBSERVATION)this.GetStructure("OBSERVATION", rep);
			}
		}
	}

	///<summary>
	///Adds a new RDE_O11_OBSERVATION
	///</summary>
	public RDE_O11_OBSERVATION AddOBSERVATION()
	{
		return this.AddStructure("OBSERVATION") as RDE_O11_OBSERVATION;
	}

	///<summary>
	///Removes the given RDE_O11_OBSERVATION
	///</summary>
	public void RemoveOBSERVATION(RDE_O11_OBSERVATION toRemove)
	{
		this.RemoveStructure("OBSERVATION", toRemove);
	}

	///<summary>
	///Removes the RDE_O11_OBSERVATION at the given index
	///</summary>
	public void RemoveOBSERVATIONAt(int index)
	{
		this.RemoveRepetition("OBSERVATION", index);
	}

	///<summary>
	/// Returns  first repetition of FT1 (Financial Transaction) - creates it if necessary
	///</summary>
	public FT1 GetFT1() {
	   FT1 ret = null;
	   try {
	      ret = (FT1)this.GetStructure("FT1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of FT1
	/// * (Financial Transaction) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public FT1 GetFT1(int rep) { 
	   return (FT1)this.GetStructure("FT1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of FT1 
	 */ 
	public int FT1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("FT1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the FT1 results 
	 */ 
	public IEnumerable<FT1> FT1s 
	{ 
		get
		{
			for (int rep = 0; rep < FT1RepetitionsUsed; rep++)
			{
				yield return (FT1)this.GetStructure("FT1", rep);
			}
		}
	}

	///<summary>
	///Adds a new FT1
	///</summary>
	public FT1 AddFT1()
	{
		return this.AddStructure("FT1") as FT1;
	}

	///<summary>
	///Removes the given FT1
	///</summary>
	public void RemoveFT1(FT1 toRemove)
	{
		this.RemoveStructure("FT1", toRemove);
	}

	///<summary>
	///Removes the FT1 at the given index
	///</summary>
	public void RemoveFT1At(int index)
	{
		this.RemoveRepetition("FT1", index);
	}

	///<summary>
	/// Returns BLG (Billing) - creates it if necessary
	///</summary>
	public BLG BLG { 
get{
	   BLG ret = null;
	   try {
	      ret = (BLG)this.GetStructure("BLG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of CTI (Clinical Trial Identification) - creates it if necessary
	///</summary>
	public CTI GetCTI() {
	   CTI ret = null;
	   try {
	      ret = (CTI)this.GetStructure("CTI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of CTI
	/// * (Clinical Trial Identification) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public CTI GetCTI(int rep) { 
	   return (CTI)this.GetStructure("CTI", rep);
	}

	/** 
	 * Returns the number of existing repetitions of CTI 
	 */ 
	public int CTIRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("CTI").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the CTI results 
	 */ 
	public IEnumerable<CTI> CTIs 
	{ 
		get
		{
			for (int rep = 0; rep < CTIRepetitionsUsed; rep++)
			{
				yield return (CTI)this.GetStructure("CTI", rep);
			}
		}
	}

	///<summary>
	///Adds a new CTI
	///</summary>
	public CTI AddCTI()
	{
		return this.AddStructure("CTI") as CTI;
	}

	///<summary>
	///Removes the given CTI
	///</summary>
	public void RemoveCTI(CTI toRemove)
	{
		this.RemoveStructure("CTI", toRemove);
	}

	///<summary>
	///Removes the CTI at the given index
	///</summary>
	public void RemoveCTIAt(int index)
	{
		this.RemoveRepetition("CTI", index);
	}

}
}
