using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V28.Segment{

///<summary>
/// Represents an HL7 PV2 message segment. 
/// This segment has the following fields:<ol>
///<li>PV2-1: Prior Pending Location (PL)</li>
///<li>PV2-2: Accommodation Code (CWE)</li>
///<li>PV2-3: Admit Reason (CWE)</li>
///<li>PV2-4: Transfer Reason (CWE)</li>
///<li>PV2-5: Patient Valuables (ST)</li>
///<li>PV2-6: Patient Valuables Location (ST)</li>
///<li>PV2-7: Visit User Code (CWE)</li>
///<li>PV2-8: Expected Admit Date/Time (DTM)</li>
///<li>PV2-9: Expected Discharge Date/Time (DTM)</li>
///<li>PV2-10: Estimated Length of Inpatient Stay (NM)</li>
///<li>PV2-11: Actual Length of Inpatient Stay (NM)</li>
///<li>PV2-12: Visit Description (ST)</li>
///<li>PV2-13: Referral Source Code (XCN)</li>
///<li>PV2-14: Previous Service Date (DT)</li>
///<li>PV2-15: Employment Illness Related Indicator (ID)</li>
///<li>PV2-16: Purge Status Code (CWE)</li>
///<li>PV2-17: Purge Status Date (DT)</li>
///<li>PV2-18: Special Program Code (CWE)</li>
///<li>PV2-19: Retention Indicator (ID)</li>
///<li>PV2-20: Expected Number of Insurance Plans (NM)</li>
///<li>PV2-21: Visit Publicity Code (CWE)</li>
///<li>PV2-22: Visit Protection Indicator (ID)</li>
///<li>PV2-23: Clinic Organization Name (XON)</li>
///<li>PV2-24: Patient Status Code (CWE)</li>
///<li>PV2-25: Visit Priority Code (CWE)</li>
///<li>PV2-26: Previous Treatment Date (DT)</li>
///<li>PV2-27: Expected Discharge Disposition (CWE)</li>
///<li>PV2-28: Signature on File Date (DT)</li>
///<li>PV2-29: First Similar Illness Date (DT)</li>
///<li>PV2-30: Patient Charge Adjustment Code (CWE)</li>
///<li>PV2-31: Recurring Service Code (CWE)</li>
///<li>PV2-32: Billing Media Code (ID)</li>
///<li>PV2-33: Expected Surgery Date and Time (DTM)</li>
///<li>PV2-34: Military Partnership Code (ID)</li>
///<li>PV2-35: Military Non-Availability Code (ID)</li>
///<li>PV2-36: Newborn Baby Indicator (ID)</li>
///<li>PV2-37: Baby Detained Indicator (ID)</li>
///<li>PV2-38: Mode of Arrival Code (CWE)</li>
///<li>PV2-39: Recreational Drug Use Code (CWE)</li>
///<li>PV2-40: Admission Level of Care Code (CWE)</li>
///<li>PV2-41: Precaution Code (CWE)</li>
///<li>PV2-42: Patient Condition Code (CWE)</li>
///<li>PV2-43: Living Will Code (CWE)</li>
///<li>PV2-44: Organ Donor Code (CWE)</li>
///<li>PV2-45: Advance Directive Code (CWE)</li>
///<li>PV2-46: Patient Status Effective Date (DT)</li>
///<li>PV2-47: Expected LOA Return Date/Time (DTM)</li>
///<li>PV2-48: Expected Pre-admission Testing Date/Time (DTM)</li>
///<li>PV2-49: Notify Clergy Code (CWE)</li>
///<li>PV2-50: Advance Directive Last Verified Date (DT)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class PV2 : AbstractSegment  {

  /**
   * Creates a PV2 (Patient Visit - Additional Information) segment object that belongs to the given 
   * message.  
   */
	public PV2(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(PL), false, 1, 0, new System.Object[]{message}, "Prior Pending Location");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Accommodation Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Admit Reason");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Transfer Reason");
       this.add(typeof(ST), false, 0, 0, new System.Object[]{message}, "Patient Valuables");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Patient Valuables Location");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Visit User Code");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Expected Admit Date/Time");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Expected Discharge Date/Time");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Estimated Length of Inpatient Stay");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Actual Length of Inpatient Stay");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Visit Description");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Referral Source Code");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Previous Service Date");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Employment Illness Related Indicator");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Purge Status Code");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Purge Status Date");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Special Program Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Retention Indicator");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Expected Number of Insurance Plans");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Visit Publicity Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Visit Protection Indicator");
       this.add(typeof(XON), false, 0, 0, new System.Object[]{message}, "Clinic Organization Name");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Patient Status Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Visit Priority Code");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Previous Treatment Date");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Expected Discharge Disposition");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Signature on File Date");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "First Similar Illness Date");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Patient Charge Adjustment Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Recurring Service Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Billing Media Code");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Expected Surgery Date and Time");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Military Partnership Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Military Non-Availability Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Newborn Baby Indicator");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Baby Detained Indicator");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Mode of Arrival Code");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Recreational Drug Use Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Admission Level of Care Code");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Precaution Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Patient Condition Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Living Will Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Organ Donor Code");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Advance Directive Code");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Patient Status Effective Date");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Expected LOA Return Date/Time");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Expected Pre-admission Testing Date/Time");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Notify Clergy Code");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Advance Directive Last Verified Date");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Prior Pending Location(PV2-1).
	///</summary>
	public PL PriorPendingLocation
	{
		get{
			PL ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (PL)t;
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
	/// Returns Accommodation Code(PV2-2).
	///</summary>
	public CWE AccommodationCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Admit Reason(PV2-3).
	///</summary>
	public CWE AdmitReason
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Transfer Reason(PV2-4).
	///</summary>
	public CWE TransferReason
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
	/// Returns a single repetition of Patient Valuables(PV2-5).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ST GetPatientValuables(int rep)
	{
			ST ret = null;
			try
			{
			IType t = this.GetField(5, rep);
				ret = (ST)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Patient Valuables (PV2-5).
   ///</summary>
  public ST[] GetPatientValuables() {
     ST[] ret = null;
    try {
        IType[] t = this.GetField(5);  
        ret = new ST[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (ST)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  ///<summary>
  /// Returns the total repetitions of Patient Valuables (PV2-5).
   ///</summary>
  public int PatientValuablesRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(5);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}
	///<summary>
	/// Returns Patient Valuables Location(PV2-6).
	///</summary>
	public ST PatientValuablesLocation
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns a single repetition of Visit User Code(PV2-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetVisitUserCode(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Visit User Code (PV2-7).
   ///</summary>
  public CWE[] GetVisitUserCode() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(7);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  ///<summary>
  /// Returns the total repetitions of Visit User Code (PV2-7).
   ///</summary>
  public int VisitUserCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(7);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}
	///<summary>
	/// Returns Expected Admit Date/Time(PV2-8).
	///</summary>
	public DTM ExpectedAdmitDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Expected Discharge Date/Time(PV2-9).
	///</summary>
	public DTM ExpectedDischargeDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Estimated Length of Inpatient Stay(PV2-10).
	///</summary>
	public NM EstimatedLengthOfInpatientStay
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Actual Length of Inpatient Stay(PV2-11).
	///</summary>
	public NM ActualLengthOfInpatientStay
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Visit Description(PV2-12).
	///</summary>
	public ST VisitDescription
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns a single repetition of Referral Source Code(PV2-13).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetReferralSourceCode(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(13, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Referral Source Code (PV2-13).
   ///</summary>
  public XCN[] GetReferralSourceCode() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(13);  
        ret = new XCN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XCN)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  ///<summary>
  /// Returns the total repetitions of Referral Source Code (PV2-13).
   ///</summary>
  public int ReferralSourceCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(13);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}
	///<summary>
	/// Returns Previous Service Date(PV2-14).
	///</summary>
	public DT PreviousServiceDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(14, 0);
				ret = (DT)t;
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
	/// Returns Employment Illness Related Indicator(PV2-15).
	///</summary>
	public ID EmploymentIllnessRelatedIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Purge Status Code(PV2-16).
	///</summary>
	public CWE PurgeStatusCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Purge Status Date(PV2-17).
	///</summary>
	public DT PurgeStatusDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(17, 0);
				ret = (DT)t;
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
	/// Returns Special Program Code(PV2-18).
	///</summary>
	public CWE SpecialProgramCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Retention Indicator(PV2-19).
	///</summary>
	public ID RetentionIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Expected Number of Insurance Plans(PV2-20).
	///</summary>
	public NM ExpectedNumberOfInsurancePlans
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Visit Publicity Code(PV2-21).
	///</summary>
	public CWE VisitPublicityCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Visit Protection Indicator(PV2-22).
	///</summary>
	public ID VisitProtectionIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns a single repetition of Clinic Organization Name(PV2-23).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XON GetClinicOrganizationName(int rep)
	{
			XON ret = null;
			try
			{
			IType t = this.GetField(23, rep);
				ret = (XON)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Clinic Organization Name (PV2-23).
   ///</summary>
  public XON[] GetClinicOrganizationName() {
     XON[] ret = null;
    try {
        IType[] t = this.GetField(23);  
        ret = new XON[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XON)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  ///<summary>
  /// Returns the total repetitions of Clinic Organization Name (PV2-23).
   ///</summary>
  public int ClinicOrganizationNameRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(23);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}
	///<summary>
	/// Returns Patient Status Code(PV2-24).
	///</summary>
	public CWE PatientStatusCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Visit Priority Code(PV2-25).
	///</summary>
	public CWE VisitPriorityCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Previous Treatment Date(PV2-26).
	///</summary>
	public DT PreviousTreatmentDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(26, 0);
				ret = (DT)t;
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
	/// Returns Expected Discharge Disposition(PV2-27).
	///</summary>
	public CWE ExpectedDischargeDisposition
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
	/// Returns Signature on File Date(PV2-28).
	///</summary>
	public DT SignatureOnFileDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(28, 0);
				ret = (DT)t;
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
	/// Returns First Similar Illness Date(PV2-29).
	///</summary>
	public DT FirstSimilarIllnessDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(29, 0);
				ret = (DT)t;
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
	/// Returns Patient Charge Adjustment Code(PV2-30).
	///</summary>
	public CWE PatientChargeAdjustmentCode
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
	/// Returns Recurring Service Code(PV2-31).
	///</summary>
	public CWE RecurringServiceCode
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
	/// Returns Billing Media Code(PV2-32).
	///</summary>
	public ID BillingMediaCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(32, 0);
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
	/// Returns Expected Surgery Date and Time(PV2-33).
	///</summary>
	public DTM ExpectedSurgeryDateAndTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(33, 0);
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
	/// Returns Military Partnership Code(PV2-34).
	///</summary>
	public ID MilitaryPartnershipCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(34, 0);
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
	/// Returns Military Non-Availability Code(PV2-35).
	///</summary>
	public ID MilitaryNonAvailabilityCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(35, 0);
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
	/// Returns Newborn Baby Indicator(PV2-36).
	///</summary>
	public ID NewbornBabyIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(36, 0);
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
	/// Returns Baby Detained Indicator(PV2-37).
	///</summary>
	public ID BabyDetainedIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(37, 0);
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
	/// Returns Mode of Arrival Code(PV2-38).
	///</summary>
	public CWE ModeOfArrivalCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(38, 0);
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
	/// Returns a single repetition of Recreational Drug Use Code(PV2-39).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetRecreationalDrugUseCode(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(39, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Recreational Drug Use Code (PV2-39).
   ///</summary>
  public CWE[] GetRecreationalDrugUseCode() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(39);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  ///<summary>
  /// Returns the total repetitions of Recreational Drug Use Code (PV2-39).
   ///</summary>
  public int RecreationalDrugUseCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(39);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}
	///<summary>
	/// Returns Admission Level of Care Code(PV2-40).
	///</summary>
	public CWE AdmissionLevelOfCareCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(40, 0);
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
	/// Returns a single repetition of Precaution Code(PV2-41).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetPrecautionCode(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(41, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Precaution Code (PV2-41).
   ///</summary>
  public CWE[] GetPrecautionCode() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(41);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  ///<summary>
  /// Returns the total repetitions of Precaution Code (PV2-41).
   ///</summary>
  public int PrecautionCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(41);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}
	///<summary>
	/// Returns Patient Condition Code(PV2-42).
	///</summary>
	public CWE PatientConditionCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(42, 0);
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
	/// Returns Living Will Code(PV2-43).
	///</summary>
	public CWE LivingWillCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(43, 0);
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
	/// Returns Organ Donor Code(PV2-44).
	///</summary>
	public CWE OrganDonorCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(44, 0);
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
	/// Returns a single repetition of Advance Directive Code(PV2-45).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetAdvanceDirectiveCode(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(45, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Advance Directive Code (PV2-45).
   ///</summary>
  public CWE[] GetAdvanceDirectiveCode() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(45);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  ///<summary>
  /// Returns the total repetitions of Advance Directive Code (PV2-45).
   ///</summary>
  public int AdvanceDirectiveCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(45);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}
	///<summary>
	/// Returns Patient Status Effective Date(PV2-46).
	///</summary>
	public DT PatientStatusEffectiveDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(46, 0);
				ret = (DT)t;
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
	/// Returns Expected LOA Return Date/Time(PV2-47).
	///</summary>
	public DTM ExpectedLOAReturnDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(47, 0);
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
	/// Returns Expected Pre-admission Testing Date/Time(PV2-48).
	///</summary>
	public DTM ExpectedPreAdmissionTestingDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(48, 0);
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
	/// Returns a single repetition of Notify Clergy Code(PV2-49).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetNotifyClergyCode(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(49, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Notify Clergy Code (PV2-49).
   ///</summary>
  public CWE[] GetNotifyClergyCode() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(49);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  ///<summary>
  /// Returns the total repetitions of Notify Clergy Code (PV2-49).
   ///</summary>
  public int NotifyClergyCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(49);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}
	///<summary>
	/// Returns Advance Directive Last Verified Date(PV2-50).
	///</summary>
	public DT AdvanceDirectiveLastVerifiedDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(50, 0);
				ret = (DT)t;
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