using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the QVR_Q17_QBP Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: Hxx (any HL7 segment) optional </li>
///</ol>
///</summary>
[Serializable]
public class QVR_Q17_QBP : AbstractGroup {

	///<summary> 
	/// Creates a new QVR_Q17_QBP Group.
	///</summary>
	public QVR_Q17_QBP(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(Hxx), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating QVR_Q17_QBP - this is probably a bug in the source code generator.", e);
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
