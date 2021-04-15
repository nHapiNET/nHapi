using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Group
{
///<summary>
///Represents the MFN_M08_MF_NUMERIC_OBSERVATION Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: OM2 (OM2 - numeric observation segment) optional </li>
///<li>1: OM3 (OM3 - categorical test/observation segment) optional </li>
///<li>2: OM4 (OM4 - observations that require specimens segment) optional </li>
///</ol>
///</summary>
[Serializable]
public class MFN_M08_MF_NUMERIC_OBSERVATION : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M08_MF_NUMERIC_OBSERVATION Group.
	///</summary>
	public MFN_M08_MF_NUMERIC_OBSERVATION(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(OM2), false, false);
	      this.add(typeof(OM3), false, false);
	      this.add(typeof(OM4), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M08_MF_NUMERIC_OBSERVATION - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns OM2 (OM2 - numeric observation segment) - creates it if necessary
	///</summary>
	public OM2 OM2 { 
get{
	   OM2 ret = null;
	   try {
	      ret = (OM2)this.GetStructure("OM2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns OM3 (OM3 - categorical test/observation segment) - creates it if necessary
	///</summary>
	public OM3 OM3 { 
get{
	   OM3 ret = null;
	   try {
	      ret = (OM3)this.GetStructure("OM3");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns OM4 (OM4 - observations that require specimens segment) - creates it if necessary
	///</summary>
	public OM4 OM4 { 
get{
	   OM4 ret = null;
	   try {
	      ret = (OM4)this.GetStructure("OM4");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
