using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V27.Segment;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the RSP_K11_SEGMENT_PATTERN Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: Hxx (any HL7 segment) </li>
///</ol>
///</summary>
[Serializable]
public class RSP_K11_SEGMENT_PATTERN : AbstractGroup {

	///<summary> 
	/// Creates a new RSP_K11_SEGMENT_PATTERN Group.
	///</summary>
	public RSP_K11_SEGMENT_PATTERN(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(Hxx), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating RSP_K11_SEGMENT_PATTERN - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns Hxx (any HL7 segment) - creates it if necessary
	///</summary>
	public Hxx Hxx { 
get{
	   Hxx ret = null;
	   try {
	      ret = (Hxx)this.GetStructure("Hxx");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
