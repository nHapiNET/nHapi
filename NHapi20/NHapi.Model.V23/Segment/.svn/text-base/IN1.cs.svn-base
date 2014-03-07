using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V23.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V23.Segment{

///<summary>
/// Represents an HL7 IN1 message segment. 
/// This segment has the following fields:<ol>
///<li>IN1-1: Set ID - Insurance (SI)</li>
///<li>IN1-2: Insurance Plan ID (CE)</li>
///<li>IN1-3: Insurance Company ID (CX)</li>
///<li>IN1-4: Insurance Company Name (XON)</li>
///<li>IN1-5: Insurance Company Address (XAD)</li>
///<li>IN1-6: Insurance Co. Contact Ppers (XPN)</li>
///<li>IN1-7: Insurance Co Phone Number (XTN)</li>
///<li>IN1-8: Group Number (ST)</li>
///<li>IN1-9: Group Name (XON)</li>
///<li>IN1-10: Insured's group employer ID (CX)</li>
///<li>IN1-11: Insured's Group Emp Name (XON)</li>
///<li>IN1-12: Plan Effective Date (DT)</li>
///<li>IN1-13: Plan Expiration Date (DT)</li>
///<li>IN1-14: Authorization Information (CM_AUI)</li>
///<li>IN1-15: Plan Type (IS)</li>
///<li>IN1-16: Name of Insured (XPN)</li>
///<li>IN1-17: Insured's Relationship to Patient (IS)</li>
///<li>IN1-18: Insured's Date of Birth (TS)</li>
///<li>IN1-19: Insured's Address (XAD)</li>
///<li>IN1-20: Assignment of Benefits (IS)</li>
///<li>IN1-21: Coordination of Benefits (IS)</li>
///<li>IN1-22: Coord of Ben. Priority (ST)</li>
///<li>IN1-23: Notice of Admission Code (ID)</li>
///<li>IN1-24: Notice of Admission Date (DT)</li>
///<li>IN1-25: Rpt of Eigibility Code (ID)</li>
///<li>IN1-26: Rpt of Eligibility Date (DT)</li>
///<li>IN1-27: Release Information Code (IS)</li>
///<li>IN1-28: Pre-Admit Cert (PAC) (ST)</li>
///<li>IN1-29: Verification Date/Time (TS)</li>
///<li>IN1-30: Verification By (XPN)</li>
///<li>IN1-31: Type of Agreement Code (IS)</li>
///<li>IN1-32: Billing Status (IS)</li>
///<li>IN1-33: Lifetime Reserve Days (NM)</li>
///<li>IN1-34: Delay before lifetime reserve days (NM)</li>
///<li>IN1-35: Company Plan Code (IS)</li>
///<li>IN1-36: Policy Number (ST)</li>
///<li>IN1-37: Policy Deductible (CP)</li>
///<li>IN1-38: Policy Limit - Amount (CP)</li>
///<li>IN1-39: Policy Limit - Days (NM)</li>
///<li>IN1-40: Room Rate - Semi-Private (CP)</li>
///<li>IN1-41: Room Rate - Private (CP)</li>
///<li>IN1-42: Insured's Employment Status (CE)</li>
///<li>IN1-43: Insured's Sex (IS)</li>
///<li>IN1-44: Insured's Employer Address (XAD)</li>
///<li>IN1-45: Verification Status (ST)</li>
///<li>IN1-46: Prior Insurance Plan ID (IS)</li>
///<li>IN1-47: Coverage Type (IS)</li>
///<li>IN1-48: Handicap (IS)</li>
///<li>IN1-49: Insured's ID Number (CX)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class IN1 : AbstractSegment  {

  /**
   * Creates a IN1 (Insurance) segment object that belongs to the given 
   * message.  
   */
	public IN1(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Set ID - Insurance");
       this.add(typeof(CE), false, 1, 8, new System.Object[]{message}, "Insurance Plan ID");
       this.add(typeof(CX), true, 1, 59, new System.Object[]{message}, "Insurance Company ID");
       this.add(typeof(XON), false, 1, 130, new System.Object[]{message}, "Insurance Company Name");
       this.add(typeof(XAD), false, 1, 106, new System.Object[]{message}, "Insurance Company Address");
       this.add(typeof(XPN), false, 1, 48, new System.Object[]{message}, "Insurance Co. Contact Ppers");
       this.add(typeof(XTN), false, 3, 40, new System.Object[]{message}, "Insurance Co Phone Number");
       this.add(typeof(ST), false, 1, 12, new System.Object[]{message}, "Group Number");
       this.add(typeof(XON), false, 1, 130, new System.Object[]{message}, "Group Name");
       this.add(typeof(CX), false, 1, 12, new System.Object[]{message}, "Insured's group employer ID");
       this.add(typeof(XON), false, 1, 130, new System.Object[]{message}, "Insured's Group Emp Name");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Plan Effective Date");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Plan Expiration Date");
       this.add(typeof(CM_AUI), false, 1, 55, new System.Object[]{message}, "Authorization Information");
       this.add(typeof(IS), false, 1, 3, new System.Object[]{message, 86}, "Plan Type");
       this.add(typeof(XPN), false, 1, 48, new System.Object[]{message}, "Name of Insured");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 63}, "Insured's Relationship to Patient");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Insured's Date of Birth");
       this.add(typeof(XAD), false, 1, 106, new System.Object[]{message}, "Insured's Address");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 135}, "Assignment of Benefits");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 173}, "Coordination of Benefits");
       this.add(typeof(ST), false, 1, 2, new System.Object[]{message}, "Coord of Ben. Priority");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 136}, "Notice of Admission Code");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Notice of Admission Date");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 136}, "Rpt of Eigibility Code");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Rpt of Eligibility Date");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 93}, "Release Information Code");
       this.add(typeof(ST), false, 1, 15, new System.Object[]{message}, "Pre-Admit Cert (PAC)");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Verification Date/Time");
       this.add(typeof(XPN), false, 1, 60, new System.Object[]{message}, "Verification By");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 98}, "Type of Agreement Code");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 22}, "Billing Status");
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Lifetime Reserve Days");
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Delay before lifetime reserve days");
       this.add(typeof(IS), false, 1, 8, new System.Object[]{message, 42}, "Company Plan Code");
       this.add(typeof(ST), false, 1, 15, new System.Object[]{message}, "Policy Number");
       this.add(typeof(CP), false, 1, 12, new System.Object[]{message}, "Policy Deductible");
       this.add(typeof(CP), false, 1, 12, new System.Object[]{message}, "Policy Limit - Amount");
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Policy Limit - Days");
       this.add(typeof(CP), false, 1, 12, new System.Object[]{message}, "Room Rate - Semi-Private");
       this.add(typeof(CP), false, 1, 12, new System.Object[]{message}, "Room Rate - Private");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Insured's Employment Status");
       this.add(typeof(IS), false, 1, 1, new System.Object[]{message, 1}, "Insured's Sex");
       this.add(typeof(XAD), false, 1, 106, new System.Object[]{message}, "Insured's Employer Address");
       this.add(typeof(ST), false, 1, 2, new System.Object[]{message}, "Verification Status");
       this.add(typeof(IS), false, 1, 8, new System.Object[]{message, 72}, "Prior Insurance Plan ID");
       this.add(typeof(IS), false, 1, 3, new System.Object[]{message, 309}, "Coverage Type");
       this.add(typeof(IS), false, 1, 2, new System.Object[]{message, 310}, "Handicap");
       this.add(typeof(CX), false, 1, 12, new System.Object[]{message}, "Insured's ID Number");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - Insurance(IN1-1).
	///</summary>
	public SI SetIDInsurance
	{
		get{
			SI ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (SI)t;
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
	/// Returns Insurance Plan ID(IN1-2).
	///</summary>
	public CE InsurancePlanID
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Insurance Company ID(IN1-3).
	///</summary>
	public CX InsuranceCompanyID
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(3, 0);
				ret = (CX)t;
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
	/// Returns Insurance Company Name(IN1-4).
	///</summary>
	public XON InsuranceCompanyName
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Insurance Company Address(IN1-5).
	///</summary>
	public XAD InsuranceCompanyAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(5, 0);
				ret = (XAD)t;
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
	/// Returns Insurance Co. Contact Ppers(IN1-6).
	///</summary>
	public XPN InsuranceCoContactPpers
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns a single repetition of Insurance Co Phone Number(IN1-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XTN GetInsuranceCoPhoneNumber(int rep)
	{
			XTN ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (XTN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insurance Co Phone Number (IN1-7).
   ///</summary>
  public XTN[] GetInsuranceCoPhoneNumber() {
     XTN[] ret = null;
    try {
        IType[] t = this.GetField(7);  
        ret = new XTN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XTN)t[i];
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
  /// Returns the total repetitions of Insurance Co Phone Number (IN1-7).
   ///</summary>
  public int InsuranceCoPhoneNumberRepetitionsUsed
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
	/// Returns Group Number(IN1-8).
	///</summary>
	public ST GroupNumber
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Group Name(IN1-9).
	///</summary>
	public XON GroupName
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Insured's group employer ID(IN1-10).
	///</summary>
	public CX InsuredSGroupEmployerID
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(10, 0);
				ret = (CX)t;
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
	/// Returns Insured's Group Emp Name(IN1-11).
	///</summary>
	public XON InsuredSGroupEmpName
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Plan Effective Date(IN1-12).
	///</summary>
	public DT PlanEffectiveDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Plan Expiration Date(IN1-13).
	///</summary>
	public DT PlanExpirationDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Authorization Information(IN1-14).
	///</summary>
	public CM_AUI AuthorizationInformation
	{
		get{
			CM_AUI ret = null;
			try
			{
			IType t = this.GetField(14, 0);
				ret = (CM_AUI)t;
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
	/// Returns Plan Type(IN1-15).
	///</summary>
	public IS PlanType
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Name of Insured(IN1-16).
	///</summary>
	public XPN NameOfInsured
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Insured's Relationship to Patient(IN1-17).
	///</summary>
	public IS InsuredSRelationshipToPatient
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns Insured's Date of Birth(IN1-18).
	///</summary>
	public TS InsuredSDateOfBirth
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Insured's Address(IN1-19).
	///</summary>
	public XAD InsuredSAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(19, 0);
				ret = (XAD)t;
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
	/// Returns Assignment of Benefits(IN1-20).
	///</summary>
	public IS AssignmentOfBenefits
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Coordination of Benefits(IN1-21).
	///</summary>
	public IS CoordinationOfBenefits
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Coord of Ben. Priority(IN1-22).
	///</summary>
	public ST CoordOfBenPriority
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Notice of Admission Code(IN1-23).
	///</summary>
	public ID NoticeOfAdmissionCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Notice of Admission Date(IN1-24).
	///</summary>
	public DT NoticeOfAdmissionDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Rpt of Eigibility Code(IN1-25).
	///</summary>
	public ID RptOfEigibilityCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Rpt of Eligibility Date(IN1-26).
	///</summary>
	public DT RptOfEligibilityDate
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
	/// Returns Release Information Code(IN1-27).
	///</summary>
	public IS ReleaseInformationCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(27, 0);
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
	/// Returns Pre-Admit Cert (PAC)(IN1-28).
	///</summary>
	public ST PreAdmitCert
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
	/// Returns Verification Date/Time(IN1-29).
	///</summary>
	public TS VerificationDateTime
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(29, 0);
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
	/// Returns Verification By(IN1-30).
	///</summary>
	public XPN VerificationBy
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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
	/// Returns Type of Agreement Code(IN1-31).
	///</summary>
	public IS TypeOfAgreementCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(31, 0);
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
	/// Returns Billing Status(IN1-32).
	///</summary>
	public IS BillingStatus
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(32, 0);
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
	/// Returns Lifetime Reserve Days(IN1-33).
	///</summary>
	public NM LifetimeReserveDays
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(33, 0);
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
	/// Returns Delay before lifetime reserve days(IN1-34).
	///</summary>
	public NM DelayBeforeLifetimeReserveDays
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(34, 0);
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
	/// Returns Company Plan Code(IN1-35).
	///</summary>
	public IS CompanyPlanCode
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(35, 0);
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
	/// Returns Policy Number(IN1-36).
	///</summary>
	public ST PolicyNumber
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(36, 0);
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
	/// Returns Policy Deductible(IN1-37).
	///</summary>
	public CP PolicyDeductible
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(37, 0);
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
	/// Returns Policy Limit - Amount(IN1-38).
	///</summary>
	public CP PolicyLimitAmount
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(38, 0);
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
	/// Returns Policy Limit - Days(IN1-39).
	///</summary>
	public NM PolicyLimitDays
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(39, 0);
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
	/// Returns Room Rate - Semi-Private(IN1-40).
	///</summary>
	public CP RoomRateSemiPrivate
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(40, 0);
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
	/// Returns Room Rate - Private(IN1-41).
	///</summary>
	public CP RoomRatePrivate
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(41, 0);
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
	/// Returns Insured's Employment Status(IN1-42).
	///</summary>
	public CE InsuredSEmploymentStatus
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(42, 0);
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
	/// Returns Insured's Sex(IN1-43).
	///</summary>
	public IS InsuredSSex
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(43, 0);
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
	/// Returns Insured's Employer Address(IN1-44).
	///</summary>
	public XAD InsuredSEmployerAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(44, 0);
				ret = (XAD)t;
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
	/// Returns Verification Status(IN1-45).
	///</summary>
	public ST VerificationStatus
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(45, 0);
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
	/// Returns Prior Insurance Plan ID(IN1-46).
	///</summary>
	public IS PriorInsurancePlanID
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(46, 0);
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
	/// Returns Coverage Type(IN1-47).
	///</summary>
	public IS CoverageType
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(47, 0);
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
	/// Returns Handicap(IN1-48).
	///</summary>
	public IS Handicap
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(48, 0);
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
	/// Returns Insured's ID Number(IN1-49).
	///</summary>
	public CX InsuredSIDNumber
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(49, 0);
				ret = (CX)t;
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