using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V21.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V21.Group
{
///<summary>
///Represents the ORR_O02_ORDER_DETAIL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OBR (OBSERVATION REQUEST) </li>
///<li>1: ORO (ORDER OTHER) </li>
///<li>2: RX1 (PHARMACY ORDER) </li>
///</ol>
///</summary>
[Serializable]
public class ORR_O02_ORDER_DETAIL : AbstractGroup {

	///<summary> 
	/// Creates a new ORR_O02_ORDER_DETAIL Group.
	///</summary>
	public ORR_O02_ORDER_DETAIL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OBR), true, false);
	      this.add(typeof(ORO), true, false);
	      this.add(typeof(RX1), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORR_O02_ORDER_DETAIL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns OBR (OBSERVATION REQUEST) - creates it if necessary
	///</summary>
	public OBR OBR { 
get{
	   OBR ret = null;
	   try {
	      ret = (OBR)this.GetStructure("OBR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ORO (ORDER OTHER) - creates it if necessary
	///</summary>
	public ORO ORO { 
get{
	   ORO ret = null;
	   try {
	      ret = (ORO)this.GetStructure("ORO");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RX1 (PHARMACY ORDER) - creates it if necessary
	///</summary>
	public RX1 RX1 { 
get{
	   RX1 ret = null;
	   try {
	      ret = (RX1)this.GetStructure("RX1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
