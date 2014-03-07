using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V25UCH.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V25UCH.Group
{
///<summary>
///Represents the EAC_U07_COMMAND Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ECD (Equipment Command) </li>
///<li>1: TQ1 (Timing/Quantity) optional </li>
///<li>2: EAC_U07_SPECIMEN_CONTAINER (a Group object) optional </li>
///<li>3: CNS (Clear Notification) optional </li>
///</ol>
///</summary>
[Serializable]
public class EAC_U07_COMMAND : AbstractGroup {

	///<summary> 
	/// Creates a new EAC_U07_COMMAND Group.
	///</summary>
	public EAC_U07_COMMAND(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ECD), true, false);
	      this.add(typeof(TQ1), false, false);
	      this.add(typeof(EAC_U07_SPECIMEN_CONTAINER), false, false);
	      this.add(typeof(CNS), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EAC_U07_COMMAND - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns ECD (Equipment Command) - creates it if necessary
	///</summary>
	public ECD ECD { 
get{
	   ECD ret = null;
	   try {
	      ret = (ECD)this.GetStructure("ECD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns TQ1 (Timing/Quantity) - creates it if necessary
	///</summary>
	public TQ1 TQ1 { 
get{
	   TQ1 ret = null;
	   try {
	      ret = (TQ1)this.GetStructure("TQ1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns EAC_U07_SPECIMEN_CONTAINER (a Group object) - creates it if necessary
	///</summary>
	public EAC_U07_SPECIMEN_CONTAINER SPECIMEN_CONTAINER { 
get{
	   EAC_U07_SPECIMEN_CONTAINER ret = null;
	   try {
	      ret = (EAC_U07_SPECIMEN_CONTAINER)this.GetStructure("SPECIMEN_CONTAINER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns CNS (Clear Notification) - creates it if necessary
	///</summary>
	public CNS CNS { 
get{
	   CNS ret = null;
	   try {
	      ret = (CNS)this.GetStructure("CNS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
