using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the SUR_P09_PRODUCT Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PSH (Product Summary Header) </li>
///<li>1: PDC (Product Detail Country) </li>
///</ol>
///</summary>
[Serializable]
public class SUR_P09_PRODUCT : AbstractGroup {

	///<summary> 
	/// Creates a new SUR_P09_PRODUCT Group.
	///</summary>
	public SUR_P09_PRODUCT(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PSH), true, false);
	      this.add(typeof(PDC), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SUR_P09_PRODUCT - this is probably a bug in the source code generator.", e);
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
	/// Returns PDC (Product Detail Country) - creates it if necessary
	///</summary>
	public PDC PDC { 
get{
	   PDC ret = null;
	   try {
	      ret = (PDC)this.GetStructure("PDC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
