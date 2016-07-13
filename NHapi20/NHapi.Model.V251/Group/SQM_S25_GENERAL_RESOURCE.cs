using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the SQM_S25_GENERAL_RESOURCE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: AIG (Appointment Information - General Resource) </li>
///<li>1: APR (Appointment Preferences) optional </li>
///</ol>
///</summary>
[Serializable]
public class SQM_S25_GENERAL_RESOURCE : AbstractGroup {

	///<summary> 
	/// Creates a new SQM_S25_GENERAL_RESOURCE Group.
	///</summary>
	public SQM_S25_GENERAL_RESOURCE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(AIG), true, false);
	      this.add(typeof(APR), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SQM_S25_GENERAL_RESOURCE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns AIG (Appointment Information - General Resource) - creates it if necessary
	///</summary>
	public AIG AIG { 
get{
	   AIG ret = null;
	   try {
	      ret = (AIG)this.GetStructure("AIG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns APR (Appointment Preferences) - creates it if necessary
	///</summary>
	public APR APR { 
get{
	   APR ret = null;
	   try {
	      ret = (APR)this.GetStructure("APR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
