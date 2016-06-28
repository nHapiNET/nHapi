using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V28.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the ORL_O40_SPECIMEN_CONTAINER_IN_PACKAGE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: SAC (Specimen Container detail) </li>
///</ol>
///</summary>
[Serializable]
public class ORL_O40_SPECIMEN_CONTAINER_IN_PACKAGE : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O40_SPECIMEN_CONTAINER_IN_PACKAGE Group.
	///</summary>
	public ORL_O40_SPECIMEN_CONTAINER_IN_PACKAGE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(SAC), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O40_SPECIMEN_CONTAINER_IN_PACKAGE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns SAC (Specimen Container detail) - creates it if necessary
	///</summary>
	public SAC SAC { 
get{
	   SAC ret = null;
	   try {
	      ret = (SAC)this.GetStructure("SAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
