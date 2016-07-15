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
///Represents the EAR_U08_COMMAND_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ECD (Equipment Command) </li>
///<li>1: SAC (Specimen and container detail) optional </li>
///<li>2: ECR (Equipment Command Response) </li>
///</ol>
///</summary>
[Serializable]
public class EAR_U08_COMMAND_RESPONSE : AbstractGroup {

	///<summary> 
	/// Creates a new EAR_U08_COMMAND_RESPONSE Group.
	///</summary>
	public EAR_U08_COMMAND_RESPONSE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(ECD), true, false);
	      this.add(typeof(SAC), false, false);
	      this.add(typeof(ECR), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating EAR_U08_COMMAND_RESPONSE - this is probably a bug in the source code generator.", e);
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
	/// Returns SAC (Specimen and container detail) - creates it if necessary
	///</summary>
	public SAC SAC { 
get{
	   SAC ret = null;
	   try {
	      ret = (SAC)this.GetStructure("SAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns ECR (Equipment Command Response) - creates it if necessary
	///</summary>
	public ECR ECR { 
get{
	   ECR ret = null;
	   try {
	      ret = (ECR)this.GetStructure("ECR");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
