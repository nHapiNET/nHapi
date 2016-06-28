using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V271.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V271.Group
{
///<summary>
///Represents the RSP_E22_PSL_ITEM_INFO Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSL (Product/Service Line Item) </li>
///</ol>
///</summary>
[Serializable]
public class RSP_E22_PSL_ITEM_INFO : AbstractGroup {

	///<summary> 
	/// Creates a new RSP_E22_PSL_ITEM_INFO Group.
	///</summary>
	public RSP_E22_PSL_ITEM_INFO(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSL), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RSP_E22_PSL_ITEM_INFO - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PSL (Product/Service Line Item) - creates it if necessary
	///</summary>
	public PSL PSL { 
get{
	   PSL ret = null;
	   try {
	      ret = (PSL)this.GetStructure("PSL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
