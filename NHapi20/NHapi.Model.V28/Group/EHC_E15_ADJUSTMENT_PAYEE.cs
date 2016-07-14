using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the EHC_E15_ADJUSTMENT_PAYEE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ADJ (Adjustment) </li>
///<li>1: PRT (Participation Information) optional </li>
///<li>2: ROL (Role) optional </li>
///</ol>
///</summary>
[Serializable]
public class EHC_E15_ADJUSTMENT_PAYEE : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E15_ADJUSTMENT_PAYEE Group.
	///</summary>
	public EHC_E15_ADJUSTMENT_PAYEE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ADJ), true, false);
	      this.add(typeof(PRT), false, false);
	      this.add(typeof(ROL), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E15_ADJUSTMENT_PAYEE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ADJ (Adjustment) - creates it if necessary
	///</summary>
	public ADJ ADJ { 
get{
	   ADJ ret = null;
	   try {
	      ret = (ADJ)this.GetStructure("ADJ");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PRT (Participation Information) - creates it if necessary
	///</summary>
	public PRT PRT { 
get{
	   PRT ret = null;
	   try {
	      ret = (PRT)this.GetStructure("PRT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ROL (Role) - creates it if necessary
	///</summary>
	public ROL ROL { 
get{
	   ROL ret = null;
	   try {
	      ret = (ROL)this.GetStructure("ROL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
