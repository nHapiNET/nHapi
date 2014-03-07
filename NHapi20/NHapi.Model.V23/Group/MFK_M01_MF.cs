using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V23.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V23.Group
{
///<summary>
///Represents the MFK_M01_MF Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFA (Master file acknowledgement segment) optional </li>
///</ol>
///</summary>
[Serializable]
public class MFK_M01_MF : AbstractGroup {

	///<summary> 
	/// Creates a new MFK_M01_MF Group.
	///</summary>
	public MFK_M01_MF(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFA), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFK_M01_MF - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns MFA (Master file acknowledgement segment) - creates it if necessary
	///</summary>
	public MFA MFA { 
get{
	   MFA ret = null;
	   try {
	      ret = (MFA)this.GetStructure("MFA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
