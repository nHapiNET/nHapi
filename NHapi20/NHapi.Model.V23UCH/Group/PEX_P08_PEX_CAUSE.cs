using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V23UCH.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V23UCH.Group
{
///<summary>
///Represents the PEX_P08_PEX_CAUSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PCR (Possible Causal Relationship) </li>
///<li>1: PEX_P08_RX_ORDER (a Group object) optional </li>
///<li>2: PEX_P08_RX_ADMINISTRATION (a Group object) optional repeating</li>
///<li>3: PRB (Problem Detail) optional repeating</li>
///<li>4: OBX (Observation segment) optional repeating</li>
///<li>5: NTE (Notes and comments segment) optional repeating</li>
///<li>6: PEX_P08_ASSOCIATED_PERSON (a Group object) optional </li>
///<li>7: PEX_P08_STUDY (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class PEX_P08_PEX_CAUSE : AbstractGroup {

	///<summary> 
	/// Creates a new PEX_P08_PEX_CAUSE Group.
	///</summary>
	public PEX_P08_PEX_CAUSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PCR), true, false);
	      this.add(typeof(PEX_P08_RX_ORDER), false, false);
	      this.add(typeof(PEX_P08_RX_ADMINISTRATION), false, true);
	      this.add(typeof(PRB), false, true);
	      this.add(typeof(OBX), false, true);
	      this.add(typeof(NTE), false, true);
	      this.add(typeof(PEX_P08_ASSOCIATED_PERSON), false, false);
	      this.add(typeof(PEX_P08_STUDY), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating PEX_P08_PEX_CAUSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PCR (Possible Causal Relationship) - creates it if necessary
	///</summary>
	public PCR PCR { 
get{
	   PCR ret = null;
	   try {
	      ret = (PCR)this.GetStructure("PCR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PEX_P08_RX_ORDER (a Group object) - creates it if necessary
	///</summary>
	public PEX_P08_RX_ORDER RX_ORDER { 
get{
	   PEX_P08_RX_ORDER ret = null;
	   try {
	      ret = (PEX_P08_RX_ORDER)this.GetStructure("RX_ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PEX_P08_RX_ADMINISTRATION (a Group object) - creates it if necessary
	///</summary>
	public PEX_P08_RX_ADMINISTRATION GetRX_ADMINISTRATION() {
	   PEX_P08_RX_ADMINISTRATION ret = null;
	   try {
	      ret = (PEX_P08_RX_ADMINISTRATION)this.GetStructure("RX_ADMINISTRATION");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PEX_P08_RX_ADMINISTRATION
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PEX_P08_RX_ADMINISTRATION GetRX_ADMINISTRATION(int rep) { 
	   return (PEX_P08_RX_ADMINISTRATION)this.GetStructure("RX_ADMINISTRATION", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PEX_P08_RX_ADMINISTRATION 
	 */ 
	public int RX_ADMINISTRATIONRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RX_ADMINISTRATION").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of PRB (Problem Detail) - creates it if necessary
	///</summary>
	public PRB GetPRB() {
	   PRB ret = null;
	   try {
	      ret = (PRB)this.GetStructure("PRB");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PRB
	/// * (Problem Detail) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PRB GetPRB(int rep) { 
	   return (PRB)this.GetStructure("PRB", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PRB 
	 */ 
	public int PRBRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PRB").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns  first repetition of OBX (Observation segment) - creates it if necessary
	///</summary>
	public OBX GetOBX() {
	   OBX ret = null;
	   try {
	      ret = (OBX)this.GetStructure("OBX");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of OBX
	/// * (Observation segment) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public OBX GetOBX(int rep) { 
	   return (OBX)this.GetStructure("OBX", rep);
	}

	/** 
	 * Returns the number of existing repetitions of OBX 
	 */ 
	public int OBXRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("OBX").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
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

	///<summary>
	/// Returns PEX_P08_ASSOCIATED_PERSON (a Group object) - creates it if necessary
	///</summary>
	public PEX_P08_ASSOCIATED_PERSON ASSOCIATED_PERSON { 
get{
	   PEX_P08_ASSOCIATED_PERSON ret = null;
	   try {
	      ret = (PEX_P08_ASSOCIATED_PERSON)this.GetStructure("ASSOCIATED_PERSON");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of PEX_P08_STUDY (a Group object) - creates it if necessary
	///</summary>
	public PEX_P08_STUDY GetSTUDY() {
	   PEX_P08_STUDY ret = null;
	   try {
	      ret = (PEX_P08_STUDY)this.GetStructure("STUDY");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of PEX_P08_STUDY
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public PEX_P08_STUDY GetSTUDY(int rep) { 
	   return (PEX_P08_STUDY)this.GetStructure("STUDY", rep);
	}

	/** 
	 * Returns the number of existing repetitions of PEX_P08_STUDY 
	 */ 
	public int STUDYRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("STUDY").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

}
}
