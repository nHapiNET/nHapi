using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the SQR_S25_RESOURCES Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RGS (Resource Group) </li>
///<li>1: SQR_S25_SERVICE (a Group object) </li>
///<li>2: SQR_S25_GENERAL_RESOURCE (a Group object) </li>
///<li>3: SQR_S25_PERSONNEL_RESOURCE (a Group object) </li>
///<li>4: SQR_S25_LOCATION_RESOURCE (a Group object) </li>
///</ol>
///</summary>
[Serializable]
public class SQR_S25_RESOURCES : AbstractGroup {

	///<summary> 
	/// Creates a new SQR_S25_RESOURCES Group.
	///</summary>
	public SQR_S25_RESOURCES(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RGS), true, false);
	      this.add(typeof(SQR_S25_SERVICE), true, false);
	      this.add(typeof(SQR_S25_GENERAL_RESOURCE), true, false);
	      this.add(typeof(SQR_S25_PERSONNEL_RESOURCE), true, false);
	      this.add(typeof(SQR_S25_LOCATION_RESOURCE), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SQR_S25_RESOURCES - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns RGS (Resource Group) - creates it if necessary
	///</summary>
	public RGS RGS { 
get{
	   RGS ret = null;
	   try {
	      ret = (RGS)this.GetStructure("RGS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns SQR_S25_SERVICE (a Group object) - creates it if necessary
	///</summary>
	public SQR_S25_SERVICE SERVICE { 
get{
	   SQR_S25_SERVICE ret = null;
	   try {
	      ret = (SQR_S25_SERVICE)this.GetStructure("SERVICE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns SQR_S25_GENERAL_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SQR_S25_GENERAL_RESOURCE GENERAL_RESOURCE { 
get{
	   SQR_S25_GENERAL_RESOURCE ret = null;
	   try {
	      ret = (SQR_S25_GENERAL_RESOURCE)this.GetStructure("GENERAL_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns SQR_S25_PERSONNEL_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SQR_S25_PERSONNEL_RESOURCE PERSONNEL_RESOURCE { 
get{
	   SQR_S25_PERSONNEL_RESOURCE ret = null;
	   try {
	      ret = (SQR_S25_PERSONNEL_RESOURCE)this.GetStructure("PERSONNEL_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns SQR_S25_LOCATION_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SQR_S25_LOCATION_RESOURCE LOCATION_RESOURCE { 
get{
	   SQR_S25_LOCATION_RESOURCE ret = null;
	   try {
	      ret = (SQR_S25_LOCATION_RESOURCE)this.GetStructure("LOCATION_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
