using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the RDS_O13_ORDER_DETAIL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RXO (Pharmacy/Treatment Order) </li>
///<li>1: RDS_O13_ORDER_DETAIL_SUPPLEMENT (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class RDS_O13_ORDER_DETAIL : AbstractGroup {

	///<summary> 
	/// Creates a new RDS_O13_ORDER_DETAIL Group.
	///</summary>
	public RDS_O13_ORDER_DETAIL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RXO), true, false);
	      this.add(typeof(RDS_O13_ORDER_DETAIL_SUPPLEMENT), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RDS_O13_ORDER_DETAIL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RXO (Pharmacy/Treatment Order) - creates it if necessary
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
	/// Returns RDS_O13_ORDER_DETAIL_SUPPLEMENT (a Group object) - creates it if necessary
	///</summary>
	public RDS_O13_ORDER_DETAIL_SUPPLEMENT ORDER_DETAIL_SUPPLEMENT { 
get{
	   RDS_O13_ORDER_DETAIL_SUPPLEMENT ret = null;
	   try {
	      ret = (RDS_O13_ORDER_DETAIL_SUPPLEMENT)this.GetStructure("ORDER_DETAIL_SUPPLEMENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
