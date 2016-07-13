using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V251.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V251.Segment{

///<summary>
/// Represents an HL7 OM6 message segment. 
/// This segment has the following fields:<ol>
///<li>OM6-1: Sequence Number - Test/Observation Master File (NM)</li>
///<li>OM6-2: Derivation Rule (TX)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class OM6 : AbstractSegment  {

  /**
   * Creates a OM6 (Observations that are Calculated from Other Observations) segment object that belongs to the given 
   * message.  
   */
	public OM6(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Sequence Number - Test/Observation Master File");
       this.add(typeof(TX), false, 1, 10240, new System.Object[]{message}, "Derivation Rule");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Sequence Number - Test/Observation Master File(OM6-1).
	///</summary>
	public NM SequenceNumberTestObservationMasterFile
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (NM)t;
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
	/// Returns Derivation Rule(OM6-2).
	///</summary>
	public TX DerivationRule
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(2, 0);
				ret = (TX)t;
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