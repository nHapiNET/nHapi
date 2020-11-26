using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V24.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V24.Segment{

///<summary>
/// Represents an HL7 RDT message segment. 
/// This segment has the following fields:<ol>
///<li>RDT-1: Column Value (varies)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class RDT : AbstractSegment  {

  /**
   * Creates a RDT (Table Row Data) segment object that belongs to the given 
   * message.  
   */
	public RDT(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(Varies), true, 1, 0, new System.Object[]{message}, "Column Value");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Column Value(RDT-1).
	///</summary>
	public Varies ColumnValue
	{
		get{
			Varies ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (Varies)t;
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