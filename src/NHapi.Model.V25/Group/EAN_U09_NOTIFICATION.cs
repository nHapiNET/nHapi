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
///Represents the EAN_U09_NOTIFICATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: NDS (Notification Detail) </li>
///<li>1: NTE (Notes and Comments) optional </li>
///</ol>
///</summary>
[Serializable]
public class EAN_U09_NOTIFICATION : AbstractGroup {

	///<summary> 
	/// Creates a new EAN_U09_NOTIFICATION Group.
	///</summary>
	public EAN_U09_NOTIFICATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(NDS), true, false);
	      this.add(typeof(NTE), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EAN_U09_NOTIFICATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns NDS (Notification Detail) - creates it if necessary
	///</summary>
	public NDS NDS { 
get{
	   NDS ret = null;
	   try {
	      ret = (NDS)this.GetStructure("NDS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns NTE (Notes and Comments) - creates it if necessary
	///</summary>
	public NTE NTE { 
get{
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
