using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the SUR_P09_FACPSHPDCPSHFACPDCNTEED Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: FAC (Facility) </li>
///<li>1: SUR_P09_PSHPDC (a Group object) repeating</li>
///<li>2: PSH (Product Summary Header) </li>
///<li>3: SUR_P09_FACPDCNTE (a Group object) repeating</li>
///<li>4: ED (Encapsulated Data (wrong segment)) </li>
///</ol>
///</summary>
[Serializable]
public class SUR_P09_FACPSHPDCPSHFACPDCNTEED : AbstractGroup {

	///<summary> 
	/// Creates a new SUR_P09_FACPSHPDCPSHFACPDCNTEED Group.
	///</summary>
	public SUR_P09_FACPSHPDCPSHFACPDCNTEED(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(FAC), true, false);
	      this.add(typeof(SUR_P09_PSHPDC), true, true);
	      this.add(typeof(PSH), true, false);
	      this.add(typeof(SUR_P09_FACPDCNTE), true, true);
	      this.add(typeof(ED), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SUR_P09_FACPSHPDCPSHFACPDCNTEED - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns FAC (Facility) - creates it if necessary
	///</summary>
	public FAC FAC { 
get{
	   FAC ret = null;
	   try {
	      ret = (FAC)this.GetStructure("FAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of SUR_P09_PSHPDC (a Group object) - creates it if necessary
	///</summary>
	public SUR_P09_PSHPDC GetPSHPDC() {
	   SUR_P09_PSHPDC ret = null;
	   try {
	      ret = (SUR_P09_PSHPDC)this.GetStructure("PSHPDC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SUR_P09_PSHPDC
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SUR_P09_PSHPDC GetPSHPDC(int rep) { 
	   return (SUR_P09_PSHPDC)this.GetStructure("PSHPDC", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SUR_P09_PSHPDC 
	 */ 
	public int PSHPDCRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PSHPDC").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns PSH (Product Summary Header) - creates it if necessary
	///</summary>
	public PSH PSH { 
get{
	   PSH ret = null;
	   try {
	      ret = (PSH)this.GetStructure("PSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of SUR_P09_FACPDCNTE (a Group object) - creates it if necessary
	///</summary>
	public SUR_P09_FACPDCNTE GetFACPDCNTE() {
	   SUR_P09_FACPDCNTE ret = null;
	   try {
	      ret = (SUR_P09_FACPDCNTE)this.GetStructure("FACPDCNTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of SUR_P09_FACPDCNTE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public SUR_P09_FACPDCNTE GetFACPDCNTE(int rep) { 
	   return (SUR_P09_FACPDCNTE)this.GetStructure("FACPDCNTE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of SUR_P09_FACPDCNTE 
	 */ 
	public int FACPDCNTERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("FACPDCNTE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	///<summary>
	/// Returns ED (Encapsulated Data (wrong segment)) - creates it if necessary
	///</summary>
	public ED ED { 
get{
	   ED ret = null;
	   try {
	      ret = (ED)this.GetStructure("ED");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
