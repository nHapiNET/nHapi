using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V28.Segment{

///<summary>
/// Represents an HL7 AUT message segment. 
/// This segment has the following fields:<ol>
///<li>AUT-1: Authorizing Payor, Plan ID (CWE)</li>
///<li>AUT-2: Authorizing Payor, Company ID (CWE)</li>
///<li>AUT-3: Authorizing Payor, Company Name (ST)</li>
///<li>AUT-4: Authorization Effective Date (DTM)</li>
///<li>AUT-5: Authorization Expiration Date (DTM)</li>
///<li>AUT-6: Authorization Identifier (EI)</li>
///<li>AUT-7: Reimbursement Limit (CP)</li>
///<li>AUT-8: Requested Number of Treatments (CQ)</li>
///<li>AUT-9: Authorized Number of Treatments (CQ)</li>
///<li>AUT-10: Process Date (DTM)</li>
///<li>AUT-11: Requested Discipline(s) (CWE)</li>
///<li>AUT-12: Authorized Discipline(s) (CWE)</li>
///<li>AUT-13: Authorization Referral Type (CWE)</li>
///<li>AUT-14: Approval Status (CWE)</li>
///<li>AUT-15: Planned Treatment Stop Date (DTM)</li>
///<li>AUT-16: Clinical Service (CWE)</li>
///<li>AUT-17: Reason Text (ST)</li>
///<li>AUT-18: Number of Authorized Treatments/Units (CQ)</li>
///<li>AUT-19: Number of Used Treatments/Units (CQ)</li>
///<li>AUT-20: Number of Schedule Treatments/Units (CQ)</li>
///<li>AUT-21: Encounter Type (CWE)</li>
///<li>AUT-22: Remaining Benefit Amount (MO)</li>
///<li>AUT-23: Authorized Provider (XON)</li>
///<li>AUT-24: Authorized Health Professional (XCN)</li>
///<li>AUT-25: Source Text (ST)</li>
///<li>AUT-26: Source Date (DTM)</li>
///<li>AUT-27: Source Phone (XTN)</li>
///<li>AUT-28: Comment (ST)</li>
///<li>AUT-29: Action Code (ID)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class AUT : AbstractSegment  {

  /**
   * Creates a AUT (Authorization Information) segment object that belongs to the given 
   * message.  
   */
	public AUT(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Authorizing Payor, Plan ID");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Authorizing Payor, Company ID");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Authorizing Payor, Company Name");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Authorization Effective Date");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Authorization Expiration Date");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Authorization Identifier");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Reimbursement Limit");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Requested Number of Treatments");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Authorized Number of Treatments");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Process Date");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Requested Discipline(s)");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Authorized Discipline(s)");
       this.add(typeof(CWE), true, 1, 250, new System.Object[]{message}, "Authorization Referral Type");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Approval Status");
       this.add(typeof(DTM), false, 1, 24, new System.Object[]{message}, "Planned Treatment Stop Date");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Clinical Service");
       this.add(typeof(ST), false, 1, 60, new System.Object[]{message}, "Reason Text");
       this.add(typeof(CQ), false, 1, 721, new System.Object[]{message}, "Number of Authorized Treatments/Units");
       this.add(typeof(CQ), false, 1, 721, new System.Object[]{message}, "Number of Used Treatments/Units");
       this.add(typeof(CQ), false, 1, 721, new System.Object[]{message}, "Number of Schedule Treatments/Units");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Encounter Type");
       this.add(typeof(MO), false, 1, 20, new System.Object[]{message}, "Remaining Benefit Amount");
       this.add(typeof(XON), false, 1, 250, new System.Object[]{message}, "Authorized Provider");
       this.add(typeof(XCN), false, 1, 250, new System.Object[]{message}, "Authorized Health Professional");
       this.add(typeof(ST), false, 1, 60, new System.Object[]{message}, "Source Text");
       this.add(typeof(DTM), false, 1, 24, new System.Object[]{message}, "Source Date");
       this.add(typeof(XTN), false, 1, 250, new System.Object[]{message}, "Source Phone");
       this.add(typeof(ST), false, 1, 254, new System.Object[]{message}, "Comment");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 206}, "Action Code");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Authorizing Payor, Plan ID(AUT-1).
	///</summary>
	public CWE AuthorizingPayorPlanID
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
	/// Returns Authorizing Payor, Company ID(AUT-2).
	///</summary>
	public CWE AuthorizingPayorCompanyID
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
	/// Returns Authorizing Payor, Company Name(AUT-3).
	///</summary>
	public ST AuthorizingPayorCompanyName
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Authorization Effective Date(AUT-4).
	///</summary>
	public DTM AuthorizationEffectiveDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Authorization Expiration Date(AUT-5).
	///</summary>
	public DTM AuthorizationExpirationDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Authorization Identifier(AUT-6).
	///</summary>
	public EI AuthorizationIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(6, 0);
				ret = (EI)t;
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
	/// Returns Reimbursement Limit(AUT-7).
	///</summary>
	public CP ReimbursementLimit
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
	/// Returns Requested Number of Treatments(AUT-8).
	///</summary>
	public CQ RequestedNumberOfTreatments
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (CQ)t;
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
	/// Returns Authorized Number of Treatments(AUT-9).
	///</summary>
	public CQ AuthorizedNumberOfTreatments
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(9, 0);
				ret = (CQ)t;
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
	/// Returns Process Date(AUT-10).
	///</summary>
	public DTM ProcessDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns a single repetition of Requested Discipline(s)(AUT-11).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetRequestedDisciplineS(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(11, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Requested Discipline(s) (AUT-11).
   ///</summary>
  public CWE[] GetRequestedDisciplineS() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(11);  
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
  /// Returns the total repetitions of Requested Discipline(s) (AUT-11).
   ///</summary>
  public int RequestedDisciplineSRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(11);
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
	/// Returns a single repetition of Authorized Discipline(s)(AUT-12).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetAuthorizedDisciplineS(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(12, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Authorized Discipline(s) (AUT-12).
   ///</summary>
  public CWE[] GetAuthorizedDisciplineS() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(12);  
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
  /// Returns the total repetitions of Authorized Discipline(s) (AUT-12).
   ///</summary>
  public int AuthorizedDisciplineSRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(12);
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
	/// Returns Authorization Referral Type(AUT-13).
	///</summary>
	public CWE AuthorizationReferralType
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
	/// Returns Approval Status(AUT-14).
	///</summary>
	public CWE ApprovalStatus
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
	/// Returns Planned Treatment Stop Date(AUT-15).
	///</summary>
	public DTM PlannedTreatmentStopDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Clinical Service(AUT-16).
	///</summary>
	public CWE ClinicalService
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
	/// Returns Reason Text(AUT-17).
	///</summary>
	public ST ReasonText
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns Number of Authorized Treatments/Units(AUT-18).
	///</summary>
	public CQ NumberOfAuthorizedTreatmentsUnits
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(18, 0);
				ret = (CQ)t;
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
	/// Returns Number of Used Treatments/Units(AUT-19).
	///</summary>
	public CQ NumberOfUsedTreatmentsUnits
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(19, 0);
				ret = (CQ)t;
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
	/// Returns Number of Schedule Treatments/Units(AUT-20).
	///</summary>
	public CQ NumberOfScheduleTreatmentsUnits
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(20, 0);
				ret = (CQ)t;
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
	/// Returns Encounter Type(AUT-21).
	///</summary>
	public CWE EncounterType
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
	/// Returns Remaining Benefit Amount(AUT-22).
	///</summary>
	public MO RemainingBenefitAmount
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
	/// Returns Authorized Provider(AUT-23).
	///</summary>
	public XON AuthorizedProvider
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(23, 0);
				ret = (XON)t;
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
	/// Returns Authorized Health Professional(AUT-24).
	///</summary>
	public XCN AuthorizedHealthProfessional
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(24, 0);
				ret = (XCN)t;
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
	/// Returns Source Text(AUT-25).
	///</summary>
	public ST SourceText
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Source Date(AUT-26).
	///</summary>
	public DTM SourceDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(26, 0);
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
	/// Returns Source Phone(AUT-27).
	///</summary>
	public XTN SourcePhone
	{
		get{
			XTN ret = null;
			try
			{
			IType t = this.GetField(27, 0);
				ret = (XTN)t;
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
	/// Returns Comment(AUT-28).
	///</summary>
	public ST Comment
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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
	/// Returns Action Code(AUT-29).
	///</summary>
	public ID ActionCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(29, 0);
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