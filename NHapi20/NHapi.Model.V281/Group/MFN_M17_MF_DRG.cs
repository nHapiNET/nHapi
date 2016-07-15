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
///Represents the MFN_M17_MF_DRG Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFE (Master File Entry) </li>
///<li>1: DMI (DRG Master File Information) </li>
///</ol>
///</summary>
[Serializable]
public class MFN_M17_MF_DRG : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M17_MF_DRG Group.
	///</summary>
	public MFN_M17_MF_DRG(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFE), true, false);
	      this.add(typeof(DMI), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M17_MF_DRG - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns MFE (Master File Entry) - creates it if necessary
	///</summary>
	public MFE MFE { 
get{
	   MFE ret = null;
	   try {
	      ret = (MFE)this.GetStructure("MFE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns DMI (DRG Master File Information) - creates it if necessary
	///</summary>
	public DMI DMI { 
get{
	   DMI ret = null;
	   try {
	      ret = (DMI)this.GetStructure("DMI");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
