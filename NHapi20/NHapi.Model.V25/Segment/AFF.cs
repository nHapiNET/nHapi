using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V25.Segment{

///<summary>
/// Represents an HL7 AFF message segment. 
/// This segment has the following fields:<ol>
///<li>AFF-1: Set ID _ AFF (SI)</li>
///<li>AFF-2: Professional Organization (XON)</li>
///<li>AFF-3: Professional Organization Address (XAD)</li>
///<li>AFF-4: Professional Organization Affiliation Date Range (DR)</li>
///<li>AFF-5: Professional Affiliation Additional Information (ST)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class AFF : AbstractSegment  {

  /**
   * Creates a AFF (Professional Affiliation) segment object that belongs to the given 
   * message.  
   */
	public AFF(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), true, 1, 60, new System.Object[]{message}, "Set ID _ AFF");
       this.add(typeof(XON), true, 1, 250, new System.Object[]{message}, "Professional Organization");
       this.add(typeof(XAD), false, 1, 250, new System.Object[]{message}, "Professional Organization Address");
       this.add(typeof(DR), false, 0, 52, new System.Object[]{message}, "Professional Organization Affiliation Date Range");
       this.add(typeof(ST), false, 1, 60, new System.Object[]{message}, "Professional Affiliation Additional Information");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID _ AFF(AFF-1).
	///</summary>
	public SI SetIDAFF
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
	/// Returns Professional Organization(AFF-2).
	///</summary>
	public XON ProfessionalOrganization
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Professional Organization Address(AFF-3).
	///</summary>
	public XAD ProfessionalOrganizationAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns a single repetition of Professional Organization Affiliation Date Range(AFF-4).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public DR GetProfessionalOrganizationAffiliationDateRange(int rep)
	{
			DR ret = null;
			try
			{
			IType t = this.GetField(4, rep);
				ret = (DR)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Professional Organization Affiliation Date Range (AFF-4).
   ///</summary>
  public DR[] GetProfessionalOrganizationAffiliationDateRange() {
     DR[] ret = null;
    try {
        IType[] t = this.GetField(4);  
        ret = new DR[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (DR)t[i];
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
  /// Returns the total repetitions of Professional Organization Affiliation Date Range (AFF-4).
   ///</summary>
  public int ProfessionalOrganizationAffiliationDateRangeRepetitionsUsed
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
	/// Returns Professional Affiliation Additional Information(AFF-5).
	///</summary>
	public ST ProfessionalAffiliationAdditionalInformation
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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


}}