using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V271.Segment{

///<summary>
/// Represents an HL7 IAM message segment. 
/// This segment has the following fields:<ol>
///<li>IAM-1: Set ID - IAM (SI)</li>
///<li>IAM-2: Allergen Type Code (CWE)</li>
///<li>IAM-3: Allergen Code/Mnemonic/Description (CWE)</li>
///<li>IAM-4: Allergy Severity Code (CWE)</li>
///<li>IAM-5: Allergy Reaction Code (ST)</li>
///<li>IAM-6: Allergy Action Code (CNE)</li>
///<li>IAM-7: Allergy Unique Identifier (EI)</li>
///<li>IAM-8: Action Reason (ST)</li>
///<li>IAM-9: Sensitivity to Causative Agent Code (CWE)</li>
///<li>IAM-10: Allergen Group Code/Mnemonic/Description (CWE)</li>
///<li>IAM-11: Onset Date (DT)</li>
///<li>IAM-12: Onset Date Text (ST)</li>
///<li>IAM-13: Reported Date/Time (DTM)</li>
///<li>IAM-14: Reported By (XPN)</li>
///<li>IAM-15: Relationship to Patient Code (CWE)</li>
///<li>IAM-16: Alert Device Code (CWE)</li>
///<li>IAM-17: Allergy Clinical Status Code (CWE)</li>
///<li>IAM-18: Statused by Person (XCN)</li>
///<li>IAM-19: Statused by Organization (XON)</li>
///<li>IAM-20: Statused at Date/Time (DTM)</li>
///<li>IAM-21: Inactivated by Person (XCN)</li>
///<li>IAM-22: Inactivated Date/Time (DTM)</li>
///<li>IAM-23: Initially Recorded by Person (XCN)</li>
///<li>IAM-24: Initially Recorded Date/Time (DTM)</li>
///<li>IAM-25: Modified by Person (XCN)</li>
///<li>IAM-26: Modified Date/Time (DTM)</li>
///<li>IAM-27: Clinician Identified Code (CWE)</li>
///<li>IAM-28: Initially Recorded by Organization (XON)</li>
///<li>IAM-29: Modified by Organization (XON)</li>
///<li>IAM-30: Inactivated by Organization (XON)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class IAM : AbstractSegment  {

  /**
   * Creates a IAM (Patient Adverse Reaction Information) segment object that belongs to the given 
   * message.  
   */
	public IAM(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Set ID - IAM");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Allergen Type Code");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Allergen Code/Mnemonic/Description");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Allergy Severity Code");
       this.add(typeof(ST), false, 0, 0, new System.Object[]{message}, "Allergy Reaction Code");
       this.add(typeof(CNE), true, 1, 0, new System.Object[]{message}, "Allergy Action Code");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Allergy Unique Identifier");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Action Reason");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Sensitivity to Causative Agent Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Allergen Group Code/Mnemonic/Description");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Onset Date");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Onset Date Text");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Reported Date/Time");
       this.add(typeof(XPN), false, 1, 0, new System.Object[]{message}, "Reported By");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Relationship to Patient Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Alert Device Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Allergy Clinical Status Code");
       this.add(typeof(XCN), false, 1, 0, new System.Object[]{message}, "Statused by Person");
       this.add(typeof(XON), false, 1, 0, new System.Object[]{message}, "Statused by Organization");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Statused at Date/Time");
       this.add(typeof(XCN), false, 1, 0, new System.Object[]{message}, "Inactivated by Person");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Inactivated Date/Time");
       this.add(typeof(XCN), false, 1, 0, new System.Object[]{message}, "Initially Recorded by Person");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Initially Recorded Date/Time");
       this.add(typeof(XCN), false, 1, 0, new System.Object[]{message}, "Modified by Person");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Modified Date/Time");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Clinician Identified Code");
       this.add(typeof(XON), false, 1, 0, new System.Object[]{message}, "Initially Recorded by Organization");
       this.add(typeof(XON), false, 1, 0, new System.Object[]{message}, "Modified by Organization");
       this.add(typeof(XON), false, 1, 0, new System.Object[]{message}, "Inactivated by Organization");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - IAM(IAM-1).
	///</summary>
	public SI SetIDIAM
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
	/// Returns Allergen Type Code(IAM-2).
	///</summary>
	public CWE AllergenTypeCode
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
	/// Returns Allergen Code/Mnemonic/Description(IAM-3).
	///</summary>
	public CWE AllergenCodeMnemonicDescription
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
	/// Returns Allergy Severity Code(IAM-4).
	///</summary>
	public CWE AllergySeverityCode
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
	/// Returns a single repetition of Allergy Reaction Code(IAM-5).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ST GetAllergyReactionCode(int rep)
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
  /// Returns all repetitions of Allergy Reaction Code (IAM-5).
   ///</summary>
  public ST[] GetAllergyReactionCode() {
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
  /// Returns the total repetitions of Allergy Reaction Code (IAM-5).
   ///</summary>
  public int AllergyReactionCodeRepetitionsUsed
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
	/// Returns Allergy Action Code(IAM-6).
	///</summary>
	public CNE AllergyActionCode
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Allergy Unique Identifier(IAM-7).
	///</summary>
	public EI AllergyUniqueIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Action Reason(IAM-8).
	///</summary>
	public ST ActionReason
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
	/// Returns Sensitivity to Causative Agent Code(IAM-9).
	///</summary>
	public CWE SensitivityToCausativeAgentCode
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
	/// Returns Allergen Group Code/Mnemonic/Description(IAM-10).
	///</summary>
	public CWE AllergenGroupCodeMnemonicDescription
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
	/// Returns Onset Date(IAM-11).
	///</summary>
	public DT OnsetDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Onset Date Text(IAM-12).
	///</summary>
	public ST OnsetDateText
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
	/// Returns Reported Date/Time(IAM-13).
	///</summary>
	public DTM ReportedDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Reported By(IAM-14).
	///</summary>
	public XPN ReportedBy
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Relationship to Patient Code(IAM-15).
	///</summary>
	public CWE RelationshipToPatientCode
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
	/// Returns Alert Device Code(IAM-16).
	///</summary>
	public CWE AlertDeviceCode
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
	/// Returns Allergy Clinical Status Code(IAM-17).
	///</summary>
	public CWE AllergyClinicalStatusCode
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
	/// Returns Statused by Person(IAM-18).
	///</summary>
	public XCN StatusedByPerson
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Statused by Organization(IAM-19).
	///</summary>
	public XON StatusedByOrganization
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Statused at Date/Time(IAM-20).
	///</summary>
	public DTM StatusedAtDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Inactivated by Person(IAM-21).
	///</summary>
	public XCN InactivatedByPerson
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Inactivated Date/Time(IAM-22).
	///</summary>
	public DTM InactivatedDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Initially Recorded by Person(IAM-23).
	///</summary>
	public XCN InitiallyRecordedByPerson
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Initially Recorded Date/Time(IAM-24).
	///</summary>
	public DTM InitiallyRecordedDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Modified by Person(IAM-25).
	///</summary>
	public XCN ModifiedByPerson
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Modified Date/Time(IAM-26).
	///</summary>
	public DTM ModifiedDateTime
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
	/// Returns Clinician Identified Code(IAM-27).
	///</summary>
	public CWE ClinicianIdentifiedCode
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
	/// Returns Initially Recorded by Organization(IAM-28).
	///</summary>
	public XON InitiallyRecordedByOrganization
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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
	/// Returns Modified by Organization(IAM-29).
	///</summary>
	public XON ModifiedByOrganization
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(29, 0);
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
	/// Returns Inactivated by Organization(IAM-30).
	///</summary>
	public XON InactivatedByOrganization
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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


}}