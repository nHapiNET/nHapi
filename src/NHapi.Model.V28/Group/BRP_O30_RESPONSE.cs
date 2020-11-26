using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V28.Segment;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the BRP_O30_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: BRP_O30_PATIENT (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class BRP_O30_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new BRP_O30_RESPONSE Group.
	///</summary>
	public BRP_O30_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(BRP_O30_PATIENT), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating BRP_O30_RESPONSE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns BRP_O30_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public BRP_O30_PATIENT PATIENT { 
get{
	   BRP_O30_PATIENT ret = null;
	   try {
	      ret = (BRP_O30_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
