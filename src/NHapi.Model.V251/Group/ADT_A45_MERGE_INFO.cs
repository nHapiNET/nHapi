using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V251.Segment;
using NHapi.Model.V251.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V251.Group
{
///<summary>
///Represents the ADT_A45_MERGE_INFO Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: MRG (Merge Patient Information) </li>
///<li>1: PV1 (Patient Visit) </li>
///</ol>
///</summary>
[Serializable]
public class ADT_A45_MERGE_INFO : AbstractGroup {

	///<summary> 
	/// Creates a new ADT_A45_MERGE_INFO Group.
	///</summary>
	public ADT_A45_MERGE_INFO(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(MRG), true, false);
	      this.add(typeof(PV1), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ADT_A45_MERGE_INFO - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns MRG (Merge Patient Information) - creates it if necessary
	///</summary>
	public MRG MRG { 
get{
	   MRG ret = null;
	   try {
	      ret = (MRG)this.GetStructure("MRG");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PV1 (Patient Visit) - creates it if necessary
	///</summary>
	public PV1 PV1 { 
get{
	   PV1 ret = null;
	   try {
	      ret = (PV1)this.GetStructure("PV1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
