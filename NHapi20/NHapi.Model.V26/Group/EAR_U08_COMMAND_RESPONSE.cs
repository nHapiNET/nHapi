using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V26.Segment;
using NHapi.Model.V26.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V26.Group
{
///<summary>
///Represents the EAR_U08_COMMAND_RESPONSE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: ECD (Equipment Command) </li>
///<li>1: EAR_U08_SPECIMEN_CONTAINER (a Group object) optional </li>
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
	      this.add(typeof(EAR_U08_SPECIMEN_CONTAINER), false, false);
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
	/// Returns EAR_U08_SPECIMEN_CONTAINER (a Group object) - creates it if necessary
	///</summary>
	public EAR_U08_SPECIMEN_CONTAINER SPECIMEN_CONTAINER { 
get{
	   EAR_U08_SPECIMEN_CONTAINER ret = null;
	   try {
	      ret = (EAR_U08_SPECIMEN_CONTAINER)this.GetStructure("SPECIMEN_CONTAINER");
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
