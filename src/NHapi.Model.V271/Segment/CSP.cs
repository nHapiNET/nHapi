using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V271.Segment{

///<summary>
/// Represents an HL7 CSP message segment. 
/// This segment has the following fields:<ol>
///<li>CSP-1: Study Phase Identifier (CWE)</li>
///<li>CSP-2: Date/time Study Phase Began (DTM)</li>
///<li>CSP-3: Date/time Study Phase Ended (DTM)</li>
///<li>CSP-4: Study Phase Evaluability (CWE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class CSP : AbstractSegment  {

  /**
   * Creates a CSP (Clinical Study Phase) segment object that belongs to the given 
   * message.  
   */
	public CSP(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Study Phase Identifier");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Date/time Study Phase Began");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Date/time Study Phase Ended");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Study Phase Evaluability");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Study Phase Identifier(CSP-1).
	///</summary>
	public CWE StudyPhaseIdentifier
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (CWE)t;
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
	/// Returns Date/time Study Phase Began(CSP-2).
	///</summary>
	public DTM DateTimeStudyPhaseBegan
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(2, 0);
				ret = (DTM)t;
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
	/// Returns Date/time Study Phase Ended(CSP-3).
	///</summary>
	public DTM DateTimeStudyPhaseEnded
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(3, 0);
				ret = (DTM)t;
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
	/// Returns Study Phase Evaluability(CSP-4).
	///</summary>
	public CWE StudyPhaseEvaluability
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(4, 0);
				ret = (CWE)t;
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