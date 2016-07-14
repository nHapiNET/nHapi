using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;
using NHapi.Model.V251.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the ORL_O36_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORL_O36_PATIENT (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class ORL_O36_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O36_RESPONSE Group.
	///</summary>
	public ORL_O36_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORL_O36_PATIENT), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O36_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORL_O36_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORL_O36_PATIENT PATIENT { 
get{
	   ORL_O36_PATIENT ret = null;
	   try {
	      ret = (ORL_O36_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
