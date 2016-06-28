using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V27.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the EHC_E24_PAYER_ADJUSTMENT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ADJ (Adjustment) </li>
///</ol>
///</summary>
[Serializable]
public class EHC_E24_PAYER_ADJUSTMENT : AbstractGroup {

	///<summary> 
	/// Creates a new EHC_E24_PAYER_ADJUSTMENT Group.
	///</summary>
	public EHC_E24_PAYER_ADJUSTMENT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ADJ), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EHC_E24_PAYER_ADJUSTMENT - this is probably a bug in the source code generator.", e);
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

}
}
