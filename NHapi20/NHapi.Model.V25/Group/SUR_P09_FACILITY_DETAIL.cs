using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V25.Segment;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V25.Group
{
///<summary>
///Represents the SUR_P09_FACILITY_DETAIL Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: FAC (Facility) </li>
///<li>1: PDC (Product Detail Country) </li>
///<li>2: NTE (Notes and Comments) </li>
///</ol>
///</summary>
[Serializable]
public class SUR_P09_FACILITY_DETAIL : AbstractGroup {

	///<summary> 
	/// Creates a new SUR_P09_FACILITY_DETAIL Group.
	///</summary>
	public SUR_P09_FACILITY_DETAIL(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(FAC), true, false);
	      this.add(typeof(PDC), true, false);
	      this.add(typeof(NTE), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SUR_P09_FACILITY_DETAIL - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns FAC (Facility) - creates it if necessary
	///</summary>
	public FAC FAC { 
get{
	   FAC ret = null;
	   try {
	      ret = (FAC)this.GetStructure("FAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns PDC (Product Detail Country) - creates it if necessary
	///</summary>
	public PDC PDC { 
get{
	   PDC ret = null;
	   try {
	      ret = (PDC)this.GetStructure("PDC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns NTE (Notes and Comments) - creates it if necessary
	///</summary>
	public NTE NTE { 
get{
	   NTE ret = null;
	   try {
	      ret = (NTE)this.GetStructure("NTE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
