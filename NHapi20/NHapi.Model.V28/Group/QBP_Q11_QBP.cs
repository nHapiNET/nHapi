using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V28.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V28.Group
{
///<summary>
///Represents the QBP_Q11_QBP Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: Hxx (any HL7 segment) optional </li>
///</ol>
///</summary>
[Serializable]
public class QBP_Q11_QBP : AbstractGroup {

	///<summary> 
	/// Creates a new QBP_Q11_QBP Group.
	///</summary>
	public QBP_Q11_QBP(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(Hxx), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating QBP_Q11_QBP - this is probably a bug in the source code generator.", e);
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
