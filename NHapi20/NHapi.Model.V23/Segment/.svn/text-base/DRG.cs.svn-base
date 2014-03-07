using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V23.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V23.Segment{

///<summary>
/// Represents an HL7 DRG message segment. 
/// This segment has the following fields:<ol>
///<li>DRG-1: Diagnostic Related Group (CE)</li>
///<li>DRG-2: DRG Assigned Date/Time (TS)</li>
///<li>DRG-3: DRG Approval Indicator (ID)</li>
///<li>DRG-4: DRG Grouper Review Code (IS)</li>
///<li>DRG-5: Outlier Type (CE)</li>
///<li>DRG-6: Outlier Days (NM)</li>
///<li>DRG-7: Outlier Cost (CP)</li>
///<li>DRG-8: DRG Payor (IS)</li>
///<li>DRG-9: Outlier Reimbursement (CP)</li>
///<li>DRG-10: Confidential Indicator (ID)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class DRG : AbstractSegment  {

  /**
   * Creates a DRG (Diagnosis Related Group) segment object that belongs to the given 
   * message.  
   */
	public DRG(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(CE), false, 1, 4, new System.Object[]{message}, "Diagnostic Related Group");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "DRG Assigned Date/Time");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 136}, "DRG Approval Indicator");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 56}, "DRG Grouper Review Code");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Outlier Type");
       this.add(typeof(NM), false, 1, 3, new System.Object[]{message}, "Outlier Days");
       this.add(typeof(CP), false, 1, 12, new System.Object[]{message}, "Outlier Cost");
       this.add(typeof(IS), false, 1, 1, new System.Object[]{message, 229}, "DRG Payor");
       this.add(typeof(CP), false, 1, 9, new System.Object[]{message}, "Outlier Reimbursement");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Confidential Indicator");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Diagnostic Related Group(DRG-1).
	///</summary>
	public CE DiagnosticRelatedGroup
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (CE)t;
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
	/// Returns DRG Assigned Date/Time(DRG-2).
	///</summary>
	public TS DRGAssignedDateTime
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(2, 0);
				ret = (TS)t;
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
	/// Returns DRG Approval Indicator(DRG-3).
	///</summary>
	public ID DRGApprovalIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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

	///<summary>
	/// Returns DRG Grouper Review Code(DRG-4).
	///</summary>
	public IS DRGGrouperReviewCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(4, 0);
				ret = (IS)t;
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
	/// Returns Outlier Type(DRG-5).
	///</summary>
	public CE OutlierType
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(5, 0);
				ret = (CE)t;
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
	/// Returns Outlier Days(DRG-6).
	///</summary>
	public NM OutlierDays
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Outlier Cost(DRG-7).
	///</summary>
	public CP OutlierCost
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(7, 0);
				ret = (CP)t;
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
	/// Returns DRG Payor(DRG-8).
	///</summary>
	public IS DRGPayor
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (IS)t;
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
	/// Returns Outlier Reimbursement(DRG-9).
	///</summary>
	public CP OutlierReimbursement
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(9, 0);
				ret = (CP)t;
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
	/// Returns Confidential Indicator(DRG-10).
	///</summary>
	public ID ConfidentialIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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