using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V23.Segment;
using NHapi.Model.V23.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V23.Group
{
///<summary>
///Represents the RAS_O01_ORDER_DETAIL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RXO (Pharmacy prescription order segment) </li>
///<li>1: RAS_O01_ORDER_DETAIL_SUPPLEMENT (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class RAS_O01_ORDER_DETAIL : AbstractGroup {

	///<summary> 
	/// Creates a new RAS_O01_ORDER_DETAIL Group.
	///</summary>
	public RAS_O01_ORDER_DETAIL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RXO), true, false);
	      this.add(typeof(RAS_O01_ORDER_DETAIL_SUPPLEMENT), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RAS_O01_ORDER_DETAIL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RXO (Pharmacy prescription order segment) - creates it if necessary
	///</summary>
	public RXO RXO { 
get{
	   RXO ret = null;
	   try {
	      ret = (RXO)this.GetStructure("RXO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RAS_O01_ORDER_DETAIL_SUPPLEMENT (a Group object) - creates it if necessary
	///</summary>
	public RAS_O01_ORDER_DETAIL_SUPPLEMENT ORDER_DETAIL_SUPPLEMENT { 
get{
	   RAS_O01_ORDER_DETAIL_SUPPLEMENT ret = null;
	   try {
	      ret = (RAS_O01_ORDER_DETAIL_SUPPLEMENT)this.GetStructure("ORDER_DETAIL_SUPPLEMENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
