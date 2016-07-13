using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V27.Segment{

///<summary>
/// Represents an HL7 IN1 message segment. 
/// This segment has the following fields:<ol>
///<li>IN1-1: Set ID - IN1 (SI)</li>
///<li>IN1-2: Health Plan ID (CWE)</li>
///<li>IN1-3: Insurance Company ID (CX)</li>
///<li>IN1-4: Insurance Company Name (XON)</li>
///<li>IN1-5: Insurance Company Address (XAD)</li>
///<li>IN1-6: Insurance Co Contact Person (XPN)</li>
///<li>IN1-7: Insurance Co Phone Number (XTN)</li>
///<li>IN1-8: Group Number (ST)</li>
///<li>IN1-9: Group Name (XON)</li>
///<li>IN1-10: Insured's Group Emp ID (CX)</li>
///<li>IN1-11: Insured's Group Emp Name (XON)</li>
///<li>IN1-12: Plan Effective Date (DT)</li>
///<li>IN1-13: Plan Expiration Date (DT)</li>
///<li>IN1-14: Authorization Information (AUI)</li>
///<li>IN1-15: Plan Type (CWE)</li>
///<li>IN1-16: Name Of Insured (XPN)</li>
///<li>IN1-17: Insured's Relationship To Patient (CWE)</li>
///<li>IN1-18: Insured's Date Of Birth (DTM)</li>
///<li>IN1-19: Insured's Address (XAD)</li>
///<li>IN1-20: Assignment Of Benefits (CWE)</li>
///<li>IN1-21: Coordination Of Benefits (CWE)</li>
///<li>IN1-22: Coord Of Ben. Priority (ST)</li>
///<li>IN1-23: Notice Of Admission Flag (ID)</li>
///<li>IN1-24: Notice Of Admission Date (DT)</li>
///<li>IN1-25: Report Of Eligibility Flag (ID)</li>
///<li>IN1-26: Report Of Eligibility Date (DT)</li>
///<li>IN1-27: Release Information Code (CWE)</li>
///<li>IN1-28: Pre-Admit Cert (PAC) (ST)</li>
///<li>IN1-29: Verification Date/Time (DTM)</li>
///<li>IN1-30: Verification By (XCN)</li>
///<li>IN1-31: Type Of Agreement Code (CWE)</li>
///<li>IN1-32: Billing Status (CWE)</li>
///<li>IN1-33: Lifetime Reserve Days (NM)</li>
///<li>IN1-34: Delay Before L.R. Day (NM)</li>
///<li>IN1-35: Company Plan Code (CWE)</li>
///<li>IN1-36: Policy Number (ST)</li>
///<li>IN1-37: Policy Deductible (CP)</li>
///<li>IN1-38: Policy Limit - Amount (CP)</li>
///<li>IN1-39: Policy Limit - Days (NM)</li>
///<li>IN1-40: Room Rate - Semi-Private (CP)</li>
///<li>IN1-41: Room Rate - Private (CP)</li>
///<li>IN1-42: Insured's Employment Status (CWE)</li>
///<li>IN1-43: Insured's Administrative Sex (CWE)</li>
///<li>IN1-44: Insured's Employer's Address (XAD)</li>
///<li>IN1-45: Verification Status (ST)</li>
///<li>IN1-46: Prior Insurance Plan ID (CWE)</li>
///<li>IN1-47: Coverage Type (CWE)</li>
///<li>IN1-48: Handicap (CWE)</li>
///<li>IN1-49: Insured's ID Number (CX)</li>
///<li>IN1-50: Signature Code (CWE)</li>
///<li>IN1-51: Signature Code Date (DT)</li>
///<li>IN1-52: Insured's Birth Place (ST)</li>
///<li>IN1-53: VIP Indicator (CWE)</li>
///<li>IN1-54: External Health Plan Identifiers (CX)</li>
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
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Set ID - IN1");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Health Plan ID");
       this.add(typeof(CX), true, 0, 0, new System.Object[]{message}, "Insurance Company ID");
       this.add(typeof(XON), false, 0, 0, new System.Object[]{message}, "Insurance Company Name");
       this.add(typeof(XAD), false, 0, 0, new System.Object[]{message}, "Insurance Company Address");
       this.add(typeof(XPN), false, 0, 0, new System.Object[]{message}, "Insurance Co Contact Person");
       this.add(typeof(XTN), false, 0, 0, new System.Object[]{message}, "Insurance Co Phone Number");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Group Number");
       this.add(typeof(XON), false, 0, 0, new System.Object[]{message}, "Group Name");
       this.add(typeof(CX), false, 0, 0, new System.Object[]{message}, "Insured's Group Emp ID");
       this.add(typeof(XON), false, 0, 0, new System.Object[]{message}, "Insured's Group Emp Name");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Plan Effective Date");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Plan Expiration Date");
       this.add(typeof(AUI), false, 1, 0, new System.Object[]{message}, "Authorization Information");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Plan Type");
       this.add(typeof(XPN), false, 0, 0, new System.Object[]{message}, "Name Of Insured");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Insured's Relationship To Patient");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Insured's Date Of Birth");
       this.add(typeof(XAD), false, 0, 0, new System.Object[]{message}, "Insured's Address");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Assignment Of Benefits");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Coordination Of Benefits");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Coord Of Ben. Priority");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Notice Of Admission Flag");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Notice Of Admission Date");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Report Of Eligibility Flag");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Report Of Eligibility Date");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Release Information Code");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Pre-Admit Cert (PAC)");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Verification Date/Time");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Verification By");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Type Of Agreement Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Billing Status");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Lifetime Reserve Days");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Delay Before L.R. Day");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Company Plan Code");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Policy Number");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Policy Deductible");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Policy Limit - Amount");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Policy Limit - Days");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Room Rate - Semi-Private");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Room Rate - Private");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Insured's Employment Status");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Insured's Administrative Sex");
       this.add(typeof(XAD), false, 0, 0, new System.Object[]{message}, "Insured's Employer's Address");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Verification Status");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Prior Insurance Plan ID");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Coverage Type");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Handicap");
       this.add(typeof(CX), false, 0, 0, new System.Object[]{message}, "Insured's ID Number");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Signature Code");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Signature Code Date");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Insured's Birth Place");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "VIP Indicator");
       this.add(typeof(CX), false, 0, 0, new System.Object[]{message}, "External Health Plan Identifiers");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - IN1(IN1-1).
	///</summary>
	public SI SetIDIN1
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
	/// Returns Health Plan ID(IN1-2).
	///</summary>
	public CWE HealthPlanID
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
	/// Returns a single repetition of Insurance Company ID(IN1-3).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CX GetInsuranceCompanyID(int rep)
	{
			CX ret = null;
			try
			{
			IType t = this.GetField(3, rep);
				ret = (CX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insurance Company ID (IN1-3).
   ///</summary>
  public CX[] GetInsuranceCompanyID() {
     CX[] ret = null;
    try {
        IType[] t = this.GetField(3);  
        ret = new CX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CX)t[i];
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
  /// Returns the total repetitions of Insurance Company ID (IN1-3).
   ///</summary>
  public int InsuranceCompanyIDRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(3);
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
	/// Returns a single repetition of Insurance Company Name(IN1-4).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XON GetInsuranceCompanyName(int rep)
	{
			XON ret = null;
			try
			{
			IType t = this.GetField(4, rep);
				ret = (XON)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insurance Company Name (IN1-4).
   ///</summary>
  public XON[] GetInsuranceCompanyName() {
     XON[] ret = null;
    try {
        IType[] t = this.GetField(4);  
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
  /// Returns the total repetitions of Insurance Company Name (IN1-4).
   ///</summary>
  public int InsuranceCompanyNameRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(4);
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
	/// Returns a single repetition of Insurance Company Address(IN1-5).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XAD GetInsuranceCompanyAddress(int rep)
	{
			XAD ret = null;
			try
			{
			IType t = this.GetField(5, rep);
				ret = (XAD)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insurance Company Address (IN1-5).
   ///</summary>
  public XAD[] GetInsuranceCompanyAddress() {
     XAD[] ret = null;
    try {
        IType[] t = this.GetField(5);  
        ret = new XAD[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XAD)t[i];
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
  /// Returns the total repetitions of Insurance Company Address (IN1-5).
   ///</summary>
  public int InsuranceCompanyAddressRepetitionsUsed
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
	/// Returns a single repetition of Insurance Co Contact Person(IN1-6).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XPN GetInsuranceCoContactPerson(int rep)
	{
			XPN ret = null;
			try
			{
			IType t = this.GetField(6, rep);
				ret = (XPN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insurance Co Contact Person (IN1-6).
   ///</summary>
  public XPN[] GetInsuranceCoContactPerson() {
     XPN[] ret = null;
    try {
        IType[] t = this.GetField(6);  
        ret = new XPN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XPN)t[i];
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
  /// Returns the total repetitions of Insurance Co Contact Person (IN1-6).
   ///</summary>
  public int InsuranceCoContactPersonRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(6);
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
	/// Returns a single repetition of Group Name(IN1-9).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XON GetGroupName(int rep)
	{
			XON ret = null;
			try
			{
			IType t = this.GetField(9, rep);
				ret = (XON)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Group Name (IN1-9).
   ///</summary>
  public XON[] GetGroupName() {
     XON[] ret = null;
    try {
        IType[] t = this.GetField(9);  
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
  /// Returns the total repetitions of Group Name (IN1-9).
   ///</summary>
  public int GroupNameRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(9);
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
	/// Returns a single repetition of Insured's Group Emp ID(IN1-10).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CX GetInsuredSGroupEmpID(int rep)
	{
			CX ret = null;
			try
			{
			IType t = this.GetField(10, rep);
				ret = (CX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insured's Group Emp ID (IN1-10).
   ///</summary>
  public CX[] GetInsuredSGroupEmpID() {
     CX[] ret = null;
    try {
        IType[] t = this.GetField(10);  
        ret = new CX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CX)t[i];
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
  /// Returns the total repetitions of Insured's Group Emp ID (IN1-10).
   ///</summary>
  public int InsuredSGroupEmpIDRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(10);
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
	/// Returns a single repetition of Insured's Group Emp Name(IN1-11).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XON GetInsuredSGroupEmpName(int rep)
	{
			XON ret = null;
			try
			{
			IType t = this.GetField(11, rep);
				ret = (XON)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insured's Group Emp Name (IN1-11).
   ///</summary>
  public XON[] GetInsuredSGroupEmpName() {
     XON[] ret = null;
    try {
        IType[] t = this.GetField(11);  
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
  /// Returns the total repetitions of Insured's Group Emp Name (IN1-11).
   ///</summary>
  public int InsuredSGroupEmpNameRepetitionsUsed
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
	public AUI AuthorizationInformation
	{
		get{
			AUI ret = null;
			try
			{
			IType t = this.GetField(14, 0);
				ret = (AUI)t;
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
	public CWE PlanType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns a single repetition of Name Of Insured(IN1-16).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XPN GetNameOfInsured(int rep)
	{
			XPN ret = null;
			try
			{
			IType t = this.GetField(16, rep);
				ret = (XPN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Name Of Insured (IN1-16).
   ///</summary>
  public XPN[] GetNameOfInsured() {
     XPN[] ret = null;
    try {
        IType[] t = this.GetField(16);  
        ret = new XPN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XPN)t[i];
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
  /// Returns the total repetitions of Name Of Insured (IN1-16).
   ///</summary>
  public int NameOfInsuredRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(16);
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
	/// Returns Insured's Relationship To Patient(IN1-17).
	///</summary>
	public CWE InsuredSRelationshipToPatient
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
	/// Returns Insured's Date Of Birth(IN1-18).
	///</summary>
	public DTM InsuredSDateOfBirth
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns a single repetition of Insured's Address(IN1-19).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XAD GetInsuredSAddress(int rep)
	{
			XAD ret = null;
			try
			{
			IType t = this.GetField(19, rep);
				ret = (XAD)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insured's Address (IN1-19).
   ///</summary>
  public XAD[] GetInsuredSAddress() {
     XAD[] ret = null;
    try {
        IType[] t = this.GetField(19);  
        ret = new XAD[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XAD)t[i];
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
  /// Returns the total repetitions of Insured's Address (IN1-19).
   ///</summary>
  public int InsuredSAddressRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(19);
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
	/// Returns Assignment Of Benefits(IN1-20).
	///</summary>
	public CWE AssignmentOfBenefits
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
	/// Returns Coordination Of Benefits(IN1-21).
	///</summary>
	public CWE CoordinationOfBenefits
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
	/// Returns Coord Of Ben. Priority(IN1-22).
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
	/// Returns Notice Of Admission Flag(IN1-23).
	///</summary>
	public ID NoticeOfAdmissionFlag
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
	/// Returns Notice Of Admission Date(IN1-24).
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
	/// Returns Report Of Eligibility Flag(IN1-25).
	///</summary>
	public ID ReportOfEligibilityFlag
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
	/// Returns Report Of Eligibility Date(IN1-26).
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
	/// Returns Release Information Code(IN1-27).
	///</summary>
	public CWE ReleaseInformationCode
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
	public DTM VerificationDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(29, 0);
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
	/// Returns a single repetition of Verification By(IN1-30).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetVerificationBy(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(30, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Verification By (IN1-30).
   ///</summary>
  public XCN[] GetVerificationBy() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(30);  
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
  /// Returns the total repetitions of Verification By (IN1-30).
   ///</summary>
  public int VerificationByRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(30);
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
	/// Returns Type Of Agreement Code(IN1-31).
	///</summary>
	public CWE TypeOfAgreementCode
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
	/// Returns Billing Status(IN1-32).
	///</summary>
	public CWE BillingStatus
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
	/// Returns Delay Before L.R. Day(IN1-34).
	///</summary>
	public NM DelayBeforeLRDay
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
	public CWE CompanyPlanCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(35, 0);
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
	public CWE InsuredSEmploymentStatus
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
	/// Returns Insured's Administrative Sex(IN1-43).
	///</summary>
	public CWE InsuredSAdministrativeSex
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
	/// Returns a single repetition of Insured's Employer's Address(IN1-44).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XAD GetInsuredSEmployerSAddress(int rep)
	{
			XAD ret = null;
			try
			{
			IType t = this.GetField(44, rep);
				ret = (XAD)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insured's Employer's Address (IN1-44).
   ///</summary>
  public XAD[] GetInsuredSEmployerSAddress() {
     XAD[] ret = null;
    try {
        IType[] t = this.GetField(44);  
        ret = new XAD[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XAD)t[i];
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
  /// Returns the total repetitions of Insured's Employer's Address (IN1-44).
   ///</summary>
  public int InsuredSEmployerSAddressRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(44);
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
	public CWE PriorInsurancePlanID
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(46, 0);
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
	/// Returns Coverage Type(IN1-47).
	///</summary>
	public CWE CoverageType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(47, 0);
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
	/// Returns Handicap(IN1-48).
	///</summary>
	public CWE Handicap
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(48, 0);
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
	/// Returns a single repetition of Insured's ID Number(IN1-49).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CX GetInsuredSIDNumber(int rep)
	{
			CX ret = null;
			try
			{
			IType t = this.GetField(49, rep);
				ret = (CX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Insured's ID Number (IN1-49).
   ///</summary>
  public CX[] GetInsuredSIDNumber() {
     CX[] ret = null;
    try {
        IType[] t = this.GetField(49);  
        ret = new CX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CX)t[i];
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
  /// Returns the total repetitions of Insured's ID Number (IN1-49).
   ///</summary>
  public int InsuredSIDNumberRepetitionsUsed
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
	/// Returns Signature Code(IN1-50).
	///</summary>
	public CWE SignatureCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(50, 0);
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
	/// Returns Signature Code Date(IN1-51).
	///</summary>
	public DT SignatureCodeDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(51, 0);
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
	/// Returns Insured's Birth Place(IN1-52).
	///</summary>
	public ST InsuredSBirthPlace
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(52, 0);
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
	/// Returns VIP Indicator(IN1-53).
	///</summary>
	public CWE VIPIndicator
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(53, 0);
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
	/// Returns a single repetition of External Health Plan Identifiers(IN1-54).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CX GetExternalHealthPlanIdentifiers(int rep)
	{
			CX ret = null;
			try
			{
			IType t = this.GetField(54, rep);
				ret = (CX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of External Health Plan Identifiers (IN1-54).
   ///</summary>
  public CX[] GetExternalHealthPlanIdentifiers() {
     CX[] ret = null;
    try {
        IType[] t = this.GetField(54);  
        ret = new CX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CX)t[i];
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
  /// Returns the total repetitions of External Health Plan Identifiers (IN1-54).
   ///</summary>
  public int ExternalHealthPlanIdentifiersRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(54);
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

}}