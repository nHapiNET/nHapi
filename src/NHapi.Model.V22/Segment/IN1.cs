using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V22.Segment{

///<summary>
/// Represents an HL7 IN1 message segment. 
/// This segment has the following fields:<ol>
///<li>IN1-1: Set ID - insurance (SI)</li>
///<li>IN1-2: Insurance plan ID (ID)</li>
///<li>IN1-3: Insurance company ID (ST)</li>
///<li>IN1-4: Insurance company name (ST)</li>
///<li>IN1-5: Insurance company address (AD)</li>
///<li>IN1-6: Insurance company contact pers (PN)</li>
///<li>IN1-7: Insurance company phone number (TN)</li>
///<li>IN1-8: Group number (ST)</li>
///<li>IN1-9: Group name (ST)</li>
///<li>IN1-10: Insured's group employer ID (ST)</li>
///<li>IN1-11: Insured's group employer name (ST)</li>
///<li>IN1-12: Plan effective date (DT)</li>
///<li>IN1-13: Plan expiration date (DT)</li>
///<li>IN1-14: Authorization information (CM_AUI)</li>
///<li>IN1-15: Plan type (ID)</li>
///<li>IN1-16: Name of insured (PN)</li>
///<li>IN1-17: Insured's relationship to patient (ID)</li>
///<li>IN1-18: Insured's date of birth (DT)</li>
///<li>IN1-19: Insured's address (AD)</li>
///<li>IN1-20: Assignment of benefits (ID)</li>
///<li>IN1-21: Coordination of benefits (ID)</li>
///<li>IN1-22: Coordination of benefits - priority (ST)</li>
///<li>IN1-23: Notice of admission code (ID)</li>
///<li>IN1-24: Notice of admission date (DT)</li>
///<li>IN1-25: Report of eligibility code (ID)</li>
///<li>IN1-26: Report of eligibility date (DT)</li>
///<li>IN1-27: Release information code (ID)</li>
///<li>IN1-28: Pre-admit certification (PAC) (ST)</li>
///<li>IN1-29: Verification date / time (TS)</li>
///<li>IN1-30: Verification by (CN_PERSON)</li>
///<li>IN1-31: Type of agreement code (ID)</li>
///<li>IN1-32: Billing status (ID)</li>
///<li>IN1-33: Lifetime reserve days (NM)</li>
///<li>IN1-34: Delay before lifetime reserve days (NM)</li>
///<li>IN1-35: Company plan code (ID)</li>
///<li>IN1-36: Policy number (ST)</li>
///<li>IN1-37: Policy deductible (NM)</li>
///<li>IN1-38: Policy limit - amount (NM)</li>
///<li>IN1-39: Policy limit - days (NM)</li>
///<li>IN1-40: Room rate - semi-private (NM)</li>
///<li>IN1-41: Room rate - private (NM)</li>
///<li>IN1-42: Insured's employment status (CE)</li>
///<li>IN1-43: Insured's sex (ID)</li>
///<li>IN1-44: Insured's employer address (AD)</li>
///<li>IN1-45: Verification status (ST)</li>
///<li>IN1-46: Prior insurance plan ID (ID)</li>
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
   * Creates a IN1 (INSURANCE) segment object that belongs to the given 
   * message.  
   */
	public IN1(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Set ID - insurance");
       this.add(typeof(ID), true, 1, 8, new System.Object[]{message, 72}, "Insurance plan ID");
       this.add(typeof(ST), true, 1, 9, new System.Object[]{message}, "Insurance company ID");
       this.add(typeof(ST), false, 1, 45, new System.Object[]{message}, "Insurance company name");
       this.add(typeof(AD), false, 1, 106, new System.Object[]{message}, "Insurance company address");
       this.add(typeof(PN), false, 1, 48, new System.Object[]{message}, "Insurance company contact pers");
       this.add(typeof(TN), false, 3, 40, new System.Object[]{message}, "Insurance company phone number");
       this.add(typeof(ST), false, 1, 12, new System.Object[]{message}, "Group number");
       this.add(typeof(ST), false, 1, 35, new System.Object[]{message}, "Group name");
       this.add(typeof(ST), false, 1, 12, new System.Object[]{message}, "Insured's group employer ID");
       this.add(typeof(ST), false, 1, 45, new System.Object[]{message}, "Insured's group employer name");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Plan effective date");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Plan expiration date");
       this.add(typeof(CM_AUI), false, 1, 55, new System.Object[]{message}, "Authorization information");
       this.add(typeof(ID), false, 1, 5, new System.Object[]{message, 86}, "Plan type");
       this.add(typeof(PN), false, 1, 48, new System.Object[]{message}, "Name of insured");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 63}, "Insured's relationship to patient");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Insured's date of birth");
       this.add(typeof(AD), false, 1, 106, new System.Object[]{message}, "Insured's address");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 135}, "Assignment of benefits");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 173}, "Coordination of benefits");
       this.add(typeof(ST), false, 1, 2, new System.Object[]{message}, "Coordination of benefits - priority");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 136}, "Notice of admission code");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Notice of admission date");
       this.add(typeof(ID), false, 1, 4, new System.Object[]{message, 0}, "Report of eligibility code");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Report of eligibility date");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 93}, "Release information code");
       this.add(typeof(ST), false, 1, 15, new System.Object[]{message}, "Pre-admit certification (PAC)");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Verification date / time");
       this.add(typeof(CN_PERSON), false, 1, 60, new System.Object[]{message}, "Verification by");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 98}, "Type of agreement code");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 22}, "Billing status");
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Lifetime reserve days");
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Delay before lifetime reserve days");
       this.add(typeof(ID), false, 1, 8, new System.Object[]{message, 42}, "Company plan code");
       this.add(typeof(ST), false, 1, 15, new System.Object[]{message}, "Policy number");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "Policy deductible");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "Policy limit - amount");
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Policy limit - days");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "Room rate - semi-private");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "Room rate - private");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Insured's employment status");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 1}, "Insured's sex");
       this.add(typeof(AD), false, 1, 106, new System.Object[]{message}, "Insured's employer address");
       this.add(typeof(ST), false, 1, 2, new System.Object[]{message}, "Verification status");
       this.add(typeof(ID), false, 1, 8, new System.Object[]{message, 72}, "Prior insurance plan ID");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - insurance(IN1-1).
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
	/// Returns Insurance plan ID(IN1-2).
	///</summary>
	public ID InsurancePlanID
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

	///<summary>
	/// Returns Insurance company ID(IN1-3).
	///</summary>
	public ST InsuranceCompanyID
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
	/// Returns Insurance company name(IN1-4).
	///</summary>
	public ST InsuranceCompanyName
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Insurance company address(IN1-5).
	///</summary>
	public AD InsuranceCompanyAddress
	{
		get{
			AD ret = null;
			try
			{
			IType t = this.GetField(5, 0);
				ret = (AD)t;
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
	/// Returns Insurance company contact pers(IN1-6).
	///</summary>
	public PN InsuranceCompanyContactPers
	{
		get{
			PN ret = null;
			try
			{
			IType t = this.GetField(6, 0);
				ret = (PN)t;
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
	/// Returns a single repetition of Insurance company phone number(IN1-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TN GetInsuranceCompanyPhoneNumber(int rep)
	{
			TN ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (TN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insurance company phone number (IN1-7).
   ///</summary>
  public TN[] GetInsuranceCompanyPhoneNumber() {
     TN[] ret = null;
    try {
        IType[] t = this.GetField(7);  
        ret = new TN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (TN)t[i];
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
  /// Returns the total repetitions of Insurance company phone number (IN1-7).
   ///</summary>
  public int InsuranceCompanyPhoneNumberRepetitionsUsed
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
	/// Returns Group number(IN1-8).
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
	/// Returns Group name(IN1-9).
	///</summary>
	public ST GroupName
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Insured's group employer ID(IN1-10).
	///</summary>
	public ST InsuredSGroupEmployerID
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Insured's group employer name(IN1-11).
	///</summary>
	public ST InsuredSGroupEmployerName
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Plan effective date(IN1-12).
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
	/// Returns Plan expiration date(IN1-13).
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
	/// Returns Authorization information(IN1-14).
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
	/// Returns Plan type(IN1-15).
	///</summary>
	public ID PlanType
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
	/// Returns Name of insured(IN1-16).
	///</summary>
	public PN NameOfInsured
	{
		get{
			PN ret = null;
			try
			{
			IType t = this.GetField(16, 0);
				ret = (PN)t;
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
	/// Returns Insured's relationship to patient(IN1-17).
	///</summary>
	public ID InsuredSRelationshipToPatient
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns Insured's date of birth(IN1-18).
	///</summary>
	public DT InsuredSDateOfBirth
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Insured's address(IN1-19).
	///</summary>
	public AD InsuredSAddress
	{
		get{
			AD ret = null;
			try
			{
			IType t = this.GetField(19, 0);
				ret = (AD)t;
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
	/// Returns Assignment of benefits(IN1-20).
	///</summary>
	public ID AssignmentOfBenefits
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Coordination of benefits(IN1-21).
	///</summary>
	public ID CoordinationOfBenefits
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Coordination of benefits - priority(IN1-22).
	///</summary>
	public ST CoordinationOfBenefitsPriority
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
	/// Returns Notice of admission code(IN1-23).
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
	/// Returns Notice of admission date(IN1-24).
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
	/// Returns Report of eligibility code(IN1-25).
	///</summary>
	public ID ReportOfEligibilityCode
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
	/// Returns Report of eligibility date(IN1-26).
	///</summary>
	public DT ReportOfEligibilityDate
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
	/// Returns Release information code(IN1-27).
	///</summary>
	public ID ReleaseInformationCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(27, 0);
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
	/// Returns Pre-admit certification (PAC)(IN1-28).
	///</summary>
	public ST PreAdmitCertification
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
	/// Returns Verification date / time(IN1-29).
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
	/// Returns Verification by(IN1-30).
	///</summary>
	public CN_PERSON VerificationBy
	{
		get{
			CN_PERSON ret = null;
			try
			{
			IType t = this.GetField(30, 0);
				ret = (CN_PERSON)t;
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
	/// Returns Type of agreement code(IN1-31).
	///</summary>
	public ID TypeOfAgreementCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(31, 0);
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
	/// Returns Billing status(IN1-32).
	///</summary>
	public ID BillingStatus
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
	/// Returns Lifetime reserve days(IN1-33).
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
	/// Returns Company plan code(IN1-35).
	///</summary>
	public ID CompanyPlanCode
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
	/// Returns Policy number(IN1-36).
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
	/// Returns Policy deductible(IN1-37).
	///</summary>
	public NM PolicyDeductible
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(37, 0);
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
	/// Returns Policy limit - amount(IN1-38).
	///</summary>
	public NM PolicyLimitAmount
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(38, 0);
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
	/// Returns Policy limit - days(IN1-39).
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
	/// Returns Room rate - semi-private(IN1-40).
	///</summary>
	public NM RoomRateSemiPrivate
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(40, 0);
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
	/// Returns Room rate - private(IN1-41).
	///</summary>
	public NM RoomRatePrivate
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(41, 0);
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
	/// Returns Insured's employment status(IN1-42).
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
	/// Returns Insured's sex(IN1-43).
	///</summary>
	public ID InsuredSSex
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(43, 0);
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
	/// Returns Insured's employer address(IN1-44).
	///</summary>
	public AD InsuredSEmployerAddress
	{
		get{
			AD ret = null;
			try
			{
			IType t = this.GetField(44, 0);
				ret = (AD)t;
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
	/// Returns Verification status(IN1-45).
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
	/// Returns Prior insurance plan ID(IN1-46).
	///</summary>
	public ID PriorInsurancePlanID
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(46, 0);
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