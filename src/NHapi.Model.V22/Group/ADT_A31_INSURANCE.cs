using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V22.Segment;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V22.Group
{
///<summary>
///Represents the ADT_A31_INSURANCE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: IN1 (INSURANCE) </li>
///<li>1: IN2 (INSURANCE ADDITIONAL INFO) optional </li>
///<li>2: IN3 (INSURANCE ADDITIONAL INFO-CERTIFICATION) optional </li>
///</ol>
///</summary>
[Serializable]
public class ADT_A31_INSURANCE : AbstractGroup {

	///<summary> 
	/// Creates a new ADT_A31_INSURANCE Group.
	///</summary>
	public ADT_A31_INSURANCE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(IN1), true, false);
	      this.add(typeof(IN2), false, false);
	      this.add(typeof(IN3), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ADT_A31_INSURANCE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns IN1 (INSURANCE) - creates it if necessary
	///</summary>
	public IN1 IN1 { 
get{
	   IN1 ret = null;
	   try {
	      ret = (IN1)this.GetStructure("IN1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns IN2 (INSURANCE ADDITIONAL INFO) - creates it if necessary
	///</summary>
	public IN2 IN2 { 
get{
	   IN2 ret = null;
	   try {
	      ret = (IN2)this.GetStructure("IN2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns IN3 (INSURANCE ADDITIONAL INFO-CERTIFICATION) - creates it if necessary
	///</summary>
	public IN3 IN3 { 
get{
	   IN3 ret = null;
	   try {
	      ret = (IN3)this.GetStructure("IN3");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
