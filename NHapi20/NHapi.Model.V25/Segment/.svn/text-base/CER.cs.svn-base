using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V25.Segment{

///<summary>
/// Represents an HL7 CER message segment. 
/// This segment has the following fields:<ol>
///<li>CER-1: Set ID _ CER (SI)</li>
///<li>CER-2: Serial Number (ST)</li>
///<li>CER-3: Version (ST)</li>
///<li>CER-4: Granting Authority (XON)</li>
///<li>CER-5: Issuing Authority (XCN)</li>
///<li>CER-6: Signature of Issuing Authority (ED)</li>
///<li>CER-7: Granting Country (ID)</li>
///<li>CER-8: Granting State/Province (CWE)</li>
///<li>CER-9: Granting County/Parish (CWE)</li>
///<li>CER-10: Certificate Type (CWE)</li>
///<li>CER-11: Certificate Domain (CWE)</li>
///<li>CER-12: Subject ID (ID)</li>
///<li>CER-13: Subject Name (ST)</li>
///<li>CER-14: Subject Directory Attribute Extension (Health Professional Data) (CWE)</li>
///<li>CER-15: Subject Public Key Info (CWE)</li>
///<li>CER-16: Authority Key Identifier (CWE)</li>
///<li>CER-17: Basic Constraint (ID)</li>
///<li>CER-18: CRL Distribution Point (CWE)</li>
///<li>CER-19: Jurisdiction Country (ID)</li>
///<li>CER-20: Jurisdiction State/Province (CWE)</li>
///<li>CER-21: Jurisdiction County/Parish (CWE)</li>
///<li>CER-22: Jurisdiction Breadth (CWE)</li>
///<li>CER-23: Granting Date (TS)</li>
///<li>CER-24: Issuing Date (TS)</li>
///<li>CER-25: Activation Date (TS)</li>
///<li>CER-26: Inactivation Date (TS)</li>
///<li>CER-27: Expiration Date (TS)</li>
///<li>CER-28: Renewal Date (TS)</li>
///<li>CER-29: Revocation Date (TS)</li>
///<li>CER-30: Revocation Reason Code (CE)</li>
///<li>CER-31: Certificate Status (CWE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class CER : AbstractSegment  {

  /**
   * Creates a CER (Certificate Detail) segment object that belongs to the given 
   * message.  
   */
	public CER(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Set ID _ CER");
       this.add(typeof(ST), false, 1, 80, new System.Object[]{message}, "Serial Number");
       this.add(typeof(ST), false, 1, 80, new System.Object[]{message}, "Version");
       this.add(typeof(XON), false, 1, 250, new System.Object[]{message}, "Granting Authority");
       this.add(typeof(XCN), false, 1, 250, new System.Object[]{message}, "Issuing Authority");
       this.add(typeof(ED), false, 1, 65536, new System.Object[]{message}, "Signature of Issuing Authority");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 399}, "Granting Country");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Granting State/Province");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Granting County/Parish");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Certificate Type");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Certificate Domain");
       this.add(typeof(ID), false, 1, 250, new System.Object[]{message, 0}, "Subject ID");
       this.add(typeof(ST), true, 1, 250, new System.Object[]{message}, "Subject Name");
       this.add(typeof(CWE), false, 0, 250, new System.Object[]{message}, "Subject Directory Attribute Extension (Health Professional Data)");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Subject Public Key Info");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Authority Key Identifier");
       this.add(typeof(ID), false, 1, 250, new System.Object[]{message, 136}, "Basic Constraint");
       this.add(typeof(CWE), false, 0, 250, new System.Object[]{message}, "CRL Distribution Point");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 399}, "Jurisdiction Country");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Jurisdiction State/Province");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Jurisdiction County/Parish");
       this.add(typeof(CWE), false, 0, 250, new System.Object[]{message}, "Jurisdiction Breadth");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Granting Date");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Issuing Date");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Activation Date");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Inactivation Date");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Expiration Date");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Renewal Date");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Revocation Date");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Revocation Reason Code");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "Certificate Status");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID _ CER(CER-1).
	///</summary>
	public SI SetIDCER
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
	/// Returns Serial Number(CER-2).
	///</summary>
	public ST SerialNumber
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Version(CER-3).
	///</summary>
	public ST Version
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
	/// Returns Granting Authority(CER-4).
	///</summary>
	public XON GrantingAuthority
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
	/// Returns Issuing Authority(CER-5).
	///</summary>
	public XCN IssuingAuthority
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Signature of Issuing Authority(CER-6).
	///</summary>
	public ED SignatureOfIssuingAuthority
	{
		get{
			ED ret = null;
			try
			{
			IType t = this.GetField(6, 0);
				ret = (ED)t;
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
	/// Returns Granting Country(CER-7).
	///</summary>
	public ID GrantingCountry
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Granting State/Province(CER-8).
	///</summary>
	public CWE GrantingStateProvince
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
	/// Returns Granting County/Parish(CER-9).
	///</summary>
	public CWE GrantingCountyParish
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Certificate Type(CER-10).
	///</summary>
	public CWE CertificateType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Certificate Domain(CER-11).
	///</summary>
	public CWE CertificateDomain
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
	/// Returns Subject ID(CER-12).
	///</summary>
	public ID SubjectID
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Subject Name(CER-13).
	///</summary>
	public ST SubjectName
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns a single repetition of Subject Directory Attribute Extension (Health Professional Data)(CER-14).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetSubjectDirectoryAttributeExtensionHealthProfessionalData(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(14, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Subject Directory Attribute Extension (Health Professional Data) (CER-14).
   ///</summary>
  public CWE[] GetSubjectDirectoryAttributeExtensionHealthProfessionalData() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(14);  
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
  /// Returns the total repetitions of Subject Directory Attribute Extension (Health Professional Data) (CER-14).
   ///</summary>
  public int SubjectDirectoryAttributeExtensionHealthProfessionalDataRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(14);
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
	/// Returns Subject Public Key Info(CER-15).
	///</summary>
	public CWE SubjectPublicKeyInfo
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
	/// Returns Authority Key Identifier(CER-16).
	///</summary>
	public CWE AuthorityKeyIdentifier
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
	/// Returns Basic Constraint(CER-17).
	///</summary>
	public ID BasicConstraint
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
	/// Returns a single repetition of CRL Distribution Point(CER-18).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetCRLDistributionPoint(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(18, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of CRL Distribution Point (CER-18).
   ///</summary>
  public CWE[] GetCRLDistributionPoint() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(18);  
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
  /// Returns the total repetitions of CRL Distribution Point (CER-18).
   ///</summary>
  public int CRLDistributionPointRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(18);
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
	/// Returns Jurisdiction Country(CER-19).
	///</summary>
	public ID JurisdictionCountry
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
	/// Returns Jurisdiction State/Province(CER-20).
	///</summary>
	public CWE JurisdictionStateProvince
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
	/// Returns Jurisdiction County/Parish(CER-21).
	///</summary>
	public CWE JurisdictionCountyParish
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
	/// Returns a single repetition of Jurisdiction Breadth(CER-22).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetJurisdictionBreadth(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(22, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Jurisdiction Breadth (CER-22).
   ///</summary>
  public CWE[] GetJurisdictionBreadth() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(22);  
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
  /// Returns the total repetitions of Jurisdiction Breadth (CER-22).
   ///</summary>
  public int JurisdictionBreadthRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(22);
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
	/// Returns Granting Date(CER-23).
	///</summary>
	public TS GrantingDate
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Issuing Date(CER-24).
	///</summary>
	public TS IssuingDate
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Activation Date(CER-25).
	///</summary>
	public TS ActivationDate
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Inactivation Date(CER-26).
	///</summary>
	public TS InactivationDate
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(26, 0);
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
	/// Returns Expiration Date(CER-27).
	///</summary>
	public TS ExpirationDate
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(27, 0);
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
	/// Returns Renewal Date(CER-28).
	///</summary>
	public TS RenewalDate
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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
	/// Returns Revocation Date(CER-29).
	///</summary>
	public TS RevocationDate
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
	/// Returns Revocation Reason Code(CER-30).
	///</summary>
	public CE RevocationReasonCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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
	/// Returns Certificate Status(CER-31).
	///</summary>
	public CWE CertificateStatus
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


}}