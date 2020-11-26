using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V22.Segment{

///<summary>
/// Represents an HL7 NPU message segment. 
/// This segment has the following fields:<ol>
///<li>NPU-1: Bed Location (CM_INTERNAL_LOCATION)</li>
///<li>NPU-2: Bed Status (ID)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class NPU : AbstractSegment  {

  /**
   * Creates a NPU (BED STATUS UPDATE) segment object that belongs to the given 
   * message.  
   */
	public NPU(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(CM_INTERNAL_LOCATION), true, 1, 12, new System.Object[]{message}, "Bed Location");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 116}, "Bed Status");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Bed Location(NPU-1).
	///</summary>
	public CM_INTERNAL_LOCATION BedLocation
	{
		get{
			CM_INTERNAL_LOCATION ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (CM_INTERNAL_LOCATION)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Bed Status(NPU-2).
	///</summary>
	public ID BedStatus
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(2, 0);
				ret = (ID)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }


}}