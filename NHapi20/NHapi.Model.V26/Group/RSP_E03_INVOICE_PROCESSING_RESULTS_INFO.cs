using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V26.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V26.Group
{
///<summary>
///Represents the RSP_E03_INVOICE_PROCESSING_RESULTS_INFO Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: IPR (Invoice Processing Results) </li>
///</ol>
///</summary>
[Serializable]
public class RSP_E03_INVOICE_PROCESSING_RESULTS_INFO : AbstractGroup {

	///<summary> 
	/// Creates a new RSP_E03_INVOICE_PROCESSING_RESULTS_INFO Group.
	///</summary>
	public RSP_E03_INVOICE_PROCESSING_RESULTS_INFO(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(IPR), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RSP_E03_INVOICE_PROCESSING_RESULTS_INFO - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns IPR (Invoice Processing Results) - creates it if necessary
	///</summary>
	public IPR IPR { 
get{
	   IPR ret = null;
	   try {
	      ret = (IPR)this.GetStructure("IPR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
