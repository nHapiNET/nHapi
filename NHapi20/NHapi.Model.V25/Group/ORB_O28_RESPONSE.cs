using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Group
{
///<summary>
///Represents the ORB_O28_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ORB_O28_PATIENT (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class ORB_O28_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new ORB_O28_RESPONSE Group.
	///</summary>
	public ORB_O28_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ORB_O28_PATIENT), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORB_O28_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ORB_O28_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public ORB_O28_PATIENT PATIENT { 
get{
	   ORB_O28_PATIENT ret = null;
	   try {
	      ret = (ORB_O28_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
