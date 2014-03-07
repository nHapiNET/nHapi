using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V251.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the SRR_S01_RESOURCES Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: RGS (Resource Group) </li>
///<li>1: SRR_S01_SERVICE (a Group object) </li>
///<li>2: SRR_S01_GENERAL_RESOURCE (a Group object) </li>
///<li>3: SRR_S01_LOCATION_RESOURCE (a Group object) </li>
///<li>4: SRR_S01_PERSONNEL_RESOURCE (a Group object) </li>
///</ol>
///</summary>
[Serializable]
public class SRR_S01_RESOURCES : AbstractGroup {

	///<summary> 
	/// Creates a new SRR_S01_RESOURCES Group.
	///</summary>
	public SRR_S01_RESOURCES(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(RGS), true, false);
	      this.add(typeof(SRR_S01_SERVICE), true, false);
	      this.add(typeof(SRR_S01_GENERAL_RESOURCE), true, false);
	      this.add(typeof(SRR_S01_LOCATION_RESOURCE), true, false);
	      this.add(typeof(SRR_S01_PERSONNEL_RESOURCE), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SRR_S01_RESOURCES - this is probably a bug in the source code generator.", e);
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
	/// Returns SRR_S01_SERVICE (a Group object) - creates it if necessary
	///</summary>
	public SRR_S01_SERVICE SERVICE { 
get{
	   SRR_S01_SERVICE ret = null;
	   try {
	      ret = (SRR_S01_SERVICE)this.GetStructure("SERVICE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns SRR_S01_GENERAL_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SRR_S01_GENERAL_RESOURCE GENERAL_RESOURCE { 
get{
	   SRR_S01_GENERAL_RESOURCE ret = null;
	   try {
	      ret = (SRR_S01_GENERAL_RESOURCE)this.GetStructure("GENERAL_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns SRR_S01_LOCATION_RESOURCE (a Group object) - creates it if necessary
	///</summary>
   public SRR_S01_LOCATION_RESOURCE LOCATION_RESOURCE
   { 
get{
	   SRR_S01_LOCATION_RESOURCE ret = null;
	   try {
	      ret = (SRR_S01_LOCATION_RESOURCE)this.GetStructure("LOCATION_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns SRR_S01_PERSONNEL_RESOURCE (a Group object) - creates it if necessary
	///</summary>
	public SRR_S01_PERSONNEL_RESOURCE PERSONNEL_RESOURCE { 
get{
	   SRR_S01_PERSONNEL_RESOURCE ret = null;
	   try {
	      ret = (SRR_S01_PERSONNEL_RESOURCE)this.GetStructure("PERSONNEL_RESOURCE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
