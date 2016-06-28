using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V27.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the ORL_O40_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORL_O40_PATIENT (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class ORL_O40_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O40_RESPONSE Group.
	///</summary>
	public ORL_O40_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORL_O40_PATIENT), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O40_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORL_O40_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORL_O40_PATIENT PATIENT { 
get{
	   ORL_O40_PATIENT ret = null;
	   try {
	      ret = (ORL_O40_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
