using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V27.Segment{

///<summary>
/// Represents an HL7 DRG message segment. 
/// This segment has the following fields:<ol>
///<li>DRG-1: Diagnostic Related Group (CNE)</li>
///<li>DRG-2: DRG Assigned Date/Time (DTM)</li>
///<li>DRG-3: DRG Approval Indicator (ID)</li>
///<li>DRG-4: DRG Grouper Review Code (CWE)</li>
///<li>DRG-5: Outlier Type (CWE)</li>
///<li>DRG-6: Outlier Days (NM)</li>
///<li>DRG-7: Outlier Cost (CP)</li>
///<li>DRG-8: DRG Payor (CWE)</li>
///<li>DRG-9: Outlier Reimbursement (CP)</li>
///<li>DRG-10: Confidential Indicator (ID)</li>
///<li>DRG-11: DRG Transfer Type (CWE)</li>
///<li>DRG-12: Name of Coder (XPN)</li>
///<li>DRG-13: Grouper Status (CWE)</li>
///<li>DRG-14: PCCL Value Code (CWE)</li>
///<li>DRG-15: Effective Weight (NM)</li>
///<li>DRG-16: Monetary Amount (MO)</li>
///<li>DRG-17: Status Patient (CWE)</li>
///<li>DRG-18: Grouper Software Name (ST)</li>
///<li>DRG-19: Grouper Software Version (ST)</li>
///<li>DRG-20: Status Financial Calculation (CWE)</li>
///<li>DRG-21: Relative Discount/Surcharge (MO)</li>
///<li>DRG-22: Basic Charge (MO)</li>
///<li>DRG-23: Total Charge (MO)</li>
///<li>DRG-24: Discount/Surcharge (MO)</li>
///<li>DRG-25: Calculated Days (NM)</li>
///<li>DRG-26: Status Gender (CWE)</li>
///<li>DRG-27: Status Age (CWE)</li>
///<li>DRG-28: Status Length of Stay (CWE)</li>
///<li>DRG-29: Status Same Day Flag (CWE)</li>
///<li>DRG-30: Status Separation Mode (CWE)</li>
///<li>DRG-31: Status Weight at Birth (CWE)</li>
///<li>DRG-32: Status Respiration Minutes (CWE)</li>
///<li>DRG-33: Status Admission (CWE)</li>
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
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Diagnostic Related Group");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "DRG Assigned Date/Time");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "DRG Approval Indicator");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "DRG Grouper Review Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Outlier Type");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Outlier Days");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Outlier Cost");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "DRG Payor");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Outlier Reimbursement");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Confidential Indicator");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "DRG Transfer Type");
       this.add(typeof(XPN), false, 1, 0, new System.Object[]{message}, "Name of Coder");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Grouper Status");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "PCCL Value Code");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Effective Weight");
       this.add(typeof(MO), false, 1, 0, new System.Object[]{message}, "Monetary Amount");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Status Patient");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Grouper Software Name");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Grouper Software Version");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Status Financial Calculation");
       this.add(typeof(MO), false, 1, 0, new System.Object[]{message}, "Relative Discount/Surcharge");
       this.add(typeof(MO), false, 1, 0, new System.Object[]{message}, "Basic Charge");
       this.add(typeof(MO), false, 1, 0, new System.Object[]{message}, "Total Charge");
       this.add(typeof(MO), false, 1, 0, new System.Object[]{message}, "Discount/Surcharge");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Calculated Days");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Status Gender");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Status Age");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Status Length of Stay");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Status Same Day Flag");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Status Separation Mode");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Status Weight at Birth");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Status Respiration Minutes");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Status Admission");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Diagnostic Related Group(DRG-1).
	///</summary>
	public CNE DiagnosticRelatedGroup
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (CNE)t;
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
	public DTM DRGAssignedDateTime
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
	public CWE DRGGrouperReviewCode
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

	///<summary>
	/// Returns Outlier Type(DRG-5).
	///</summary>
	public CWE OutlierType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	public CWE DRGPayor
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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

	///<summary>
	/// Returns DRG Transfer Type(DRG-11).
	///</summary>
	public CWE DRGTransferType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Name of Coder(DRG-12).
	///</summary>
	public XPN NameOfCoder
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(12, 0);
				ret = (XPN)t;
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
	/// Returns Grouper Status(DRG-13).
	///</summary>
	public CWE GrouperStatus
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns PCCL Value Code(DRG-14).
	///</summary>
	public CWE PCCLValueCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Effective Weight(DRG-15).
	///</summary>
	public NM EffectiveWeight
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Monetary Amount(DRG-16).
	///</summary>
	public MO MonetaryAmount
	{
		get{
			MO ret = null;
			try
			{
			IType t = this.GetField(16, 0);
				ret = (MO)t;
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
	/// Returns Status Patient(DRG-17).
	///</summary>
	public CWE StatusPatient
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns Grouper Software Name(DRG-18).
	///</summary>
	public ST GrouperSoftwareName
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(18, 0);
				ret = (ST)t;
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
	/// Returns Grouper Software Version(DRG-19).
	///</summary>
	public ST GrouperSoftwareVersion
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(19, 0);
				ret = (ST)t;
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
	/// Returns Status Financial Calculation(DRG-20).
	///</summary>
	public CWE StatusFinancialCalculation
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Relative Discount/Surcharge(DRG-21).
	///</summary>
	public MO RelativeDiscountSurcharge
	{
		get{
			MO ret = null;
			try
			{
			IType t = this.GetField(21, 0);
				ret = (MO)t;
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
	/// Returns Basic Charge(DRG-22).
	///</summary>
	public MO BasicCharge
	{
		get{
			MO ret = null;
			try
			{
			IType t = this.GetField(22, 0);
				ret = (MO)t;
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
	/// Returns Total Charge(DRG-23).
	///</summary>
	public MO TotalCharge
	{
		get{
			MO ret = null;
			try
			{
			IType t = this.GetField(23, 0);
				ret = (MO)t;
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
	/// Returns Discount/Surcharge(DRG-24).
	///</summary>
	public MO DiscountSurcharge
	{
		get{
			MO ret = null;
			try
			{
			IType t = this.GetField(24, 0);
				ret = (MO)t;
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
	/// Returns Calculated Days(DRG-25).
	///</summary>
	public NM CalculatedDays
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Status Gender(DRG-26).
	///</summary>
	public CWE StatusGender
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(26, 0);
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
	/// Returns Status Age(DRG-27).
	///</summary>
	public CWE StatusAge
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(27, 0);
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
	/// Returns Status Length of Stay(DRG-28).
	///</summary>
	public CWE StatusLengthOfStay
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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
	/// Returns Status Same Day Flag(DRG-29).
	///</summary>
	public CWE StatusSameDayFlag
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(29, 0);
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
	/// Returns Status Separation Mode(DRG-30).
	///</summary>
	public CWE StatusSeparationMode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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
	/// Returns Status Weight at Birth(DRG-31).
	///</summary>
	public CWE StatusWeightAtBirth
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(31, 0);
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
	/// Returns Status Respiration Minutes(DRG-32).
	///</summary>
	public CWE StatusRespirationMinutes
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(32, 0);
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
	/// Returns Status Admission(DRG-33).
	///</summary>
	public CWE StatusAdmission
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(33, 0);
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