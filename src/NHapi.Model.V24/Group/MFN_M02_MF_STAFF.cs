using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V24.Segment;
using NHapi.Model.V24.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V24.Group
{
///<summary>
///Represents the MFN_M02_MF_STAFF Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MFE (Master File Entry) </li>
///<li>1: STF (Staff Identification) </li>
///<li>2: PRA (Practitioner Detail) optional </li>
///<li>3: ORG (Practitioner Organization Unit) optional </li>
///</ol>
///</summary>
[Serializable]
public class MFN_M02_MF_STAFF : AbstractGroup {

	///<summary> 
	/// Creates a new MFN_M02_MF_STAFF Group.
	///</summary>
	public MFN_M02_MF_STAFF(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MFE), true, false);
	      this.add(typeof(STF), true, false);
	      this.add(typeof(PRA), false, false);
	      this.add(typeof(ORG), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating MFN_M02_MF_STAFF - this is probably a bug in the source code generator.", e);
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
	/// Returns STF (Staff Identification) - creates it if necessary
	///</summary>
	public STF STF { 
get{
	   STF ret = null;
	   try {
	      ret = (STF)this.GetStructure("STF");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PRA (Practitioner Detail) - creates it if necessary
	///</summary>
	public PRA PRA { 
get{
	   PRA ret = null;
	   try {
	      ret = (PRA)this.GetStructure("PRA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ORG (Practitioner Organization Unit) - creates it if necessary
	///</summary>
	public ORG ORG { 
get{
	   ORG ret = null;
	   try {
	      ret = (ORG)this.GetStructure("ORG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
