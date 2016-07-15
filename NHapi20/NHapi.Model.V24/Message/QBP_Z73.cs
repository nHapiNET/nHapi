using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V24.Group;
using NHapi.Model.V24.Segment;
using NHapi.Model.V24.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V24.Message

{
///<summary>
/// Represents a QBP_Z73 message structure (see chapter 4). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message Header) </li>
///<li>1: QPD (Query Parameter Definition) </li>
///<li>2: RCP (Response Control Parameter) </li>
///</ol>
///</summary>
[Serializable]
public class QBP_Z73 : AbstractMessage  {

	///<summary> 
	/// Creates a new QBP_Z73 Group with custom IModelClassFactory.
	///</summary>
	public QBP_Z73(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new QBP_Z73 Group with DefaultModelClassFactory. 
	///</summary> 
	public QBP_Z73() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for QBP_Z73.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(QPD), true, false);
	      this.add(typeof(RCP), true, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating QBP_Z73 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (Message Header) - creates it if necessary
	///</summary>
	public MSH MSH { 
get{
	   MSH ret = null;
	   try {
	      ret = (MSH)this.GetStructure("MSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns QPD (Query Parameter Definition) - creates it if necessary
	///</summary>
	public QPD QPD { 
get{
	   QPD ret = null;
	   try {
	      ret = (QPD)this.GetStructure("QPD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RCP (Response Control Parameter) - creates it if necessary
	///</summary>
	public RCP RCP { 
get{
	   RCP ret = null;
	   try {
	      ret = (RCP)this.GetStructure("RCP");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
