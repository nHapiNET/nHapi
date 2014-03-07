using System;
using NHapi.Base.Log;
using NHapi.Model.V23UCH.Group;
using NHapi.Model.V23UCH.Segment;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V23UCH.Message

{
///<summary>
/// Represents a VQQ_Q01 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (Message header segment) </li>
///<li>1: VTQ (Virtual Table Query Request) </li>
///<li>2: RDF (Table Row Definition) optional </li>
///<li>3: DSC (Continuation pointer segment) optional </li>
///</ol>
///</summary>
[Serializable]
public class VQQ_Q01 : AbstractMessage  {

	///<summary> 
	/// Creates a new VQQ_Q01 Group with custom IModelClassFactory.
	///</summary>
	public VQQ_Q01(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new VQQ_Q01 Group with DefaultModelClassFactory. 
	///</summary> 
	public VQQ_Q01() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for VQQ_Q01.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(VTQ), true, false);
	      this.add(typeof(RDF), false, false);
	      this.add(typeof(DSC), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating VQQ_Q01 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (Message header segment) - creates it if necessary
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
	/// Returns VTQ (Virtual Table Query Request) - creates it if necessary
	///</summary>
	public VTQ VTQ { 
get{
	   VTQ ret = null;
	   try {
	      ret = (VTQ)this.GetStructure("VTQ");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns RDF (Table Row Definition) - creates it if necessary
	///</summary>
	public RDF RDF { 
get{
	   RDF ret = null;
	   try {
	      ret = (RDF)this.GetStructure("RDF");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns DSC (Continuation pointer segment) - creates it if necessary
	///</summary>
	public DSC DSC { 
get{
	   DSC ret = null;
	   try {
	      ret = (DSC)this.GetStructure("DSC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
