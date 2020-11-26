using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V22.Segment{

///<summary>
/// Represents an HL7 PID message segment. 
/// This segment has the following fields:<ol>
///<li>PID-1: Set ID - Patient ID (SI)</li>
///<li>PID-2: Patient ID (External ID) (CK_PAT_ID)</li>
///<li>PID-3: Patient ID (Internal ID) (CM_PAT_ID)</li>
///<li>PID-4: Alternate Patient ID (ST)</li>
///<li>PID-5: Patient Name (PN)</li>
///<li>PID-6: Mother's Maiden Name (ST)</li>
///<li>PID-7: Date of Birth (TS)</li>
///<li>PID-8: Sex (ID)</li>
///<li>PID-9: Patient Alias (PN)</li>
///<li>PID-10: Race (ID)</li>
///<li>PID-11: Patient Address (AD)</li>
///<li>PID-12: County code (ID)</li>
///<li>PID-13: Phone Number - Home (TN)</li>
///<li>PID-14: Phone Number - Business (TN)</li>
///<li>PID-15: Language - Patient (ST)</li>
///<li>PID-16: Marital Status (ID)</li>
///<li>PID-17: Religion (ID)</li>
///<li>PID-18: Patient Account Number (CK_PAT_ID)</li>
///<li>PID-19: Social security number - patient (ST)</li>
///<li>PID-20: Driver's license number - patient (CM_LICENSE_NO)</li>
///<li>PID-21: Mother's Identifier (CK_PAT_ID)</li>
///<li>PID-22: Ethnic Group (ID)</li>
///<li>PID-23: Birth Place (ST)</li>
///<li>PID-24: Multiple Birth Indicator (ID)</li>
///<li>PID-25: Birth Order (NM)</li>
///<li>PID-26: Citizenship (ID)</li>
///<li>PID-27: Veterans Military Status (ST)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class PID : AbstractSegment  {

  /**
   * Creates a PID (PATIENT IDENTIFICATION) segment object that belongs to the given 
   * message.  
   */
	public PID(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), false, 1, 4, new System.Object[]{message}, "Set ID - Patient ID");
       this.add(typeof(CK_PAT_ID), false, 1, 16, new System.Object[]{message}, "Patient ID (External ID)");
       this.add(typeof(CM_PAT_ID), true, 0, 20, new System.Object[]{message}, "Patient ID (Internal ID)");
       this.add(typeof(ST), false, 1, 12, new System.Object[]{message}, "Alternate Patient ID");
       this.add(typeof(PN), true, 1, 48, new System.Object[]{message}, "Patient Name");
       this.add(typeof(ST), false, 1, 30, new System.Object[]{message}, "Mother's Maiden Name");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Date of Birth");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 1}, "Sex");
       this.add(typeof(PN), false, 0, 48, new System.Object[]{message}, "Patient Alias");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 5}, "Race");
       this.add(typeof(AD), false, 3, 106, new System.Object[]{message}, "Patient Address");
       this.add(typeof(ID), false, 1, 4, new System.Object[]{message, 0}, "County code");
       this.add(typeof(TN), false, 3, 40, new System.Object[]{message}, "Phone Number - Home");
       this.add(typeof(TN), false, 3, 40, new System.Object[]{message}, "Phone Number - Business");
       this.add(typeof(ST), false, 1, 25, new System.Object[]{message}, "Language - Patient");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 2}, "Marital Status");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 6}, "Religion");
       this.add(typeof(CK_PAT_ID), false, 1, 20, new System.Object[]{message}, "Patient Account Number");
       this.add(typeof(ST), false, 1, 16, new System.Object[]{message}, "Social security number - patient");
       this.add(typeof(CM_LICENSE_NO), false, 1, 25, new System.Object[]{message}, "Driver's license number - patient");
       this.add(typeof(CK_PAT_ID), false, 1, 20, new System.Object[]{message}, "Mother's Identifier");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 189}, "Ethnic Group");
       this.add(typeof(ST), false, 1, 25, new System.Object[]{message}, "Birth Place");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 0}, "Multiple Birth Indicator");
       this.add(typeof(NM), false, 1, 2, new System.Object[]{message}, "Birth Order");
       this.add(typeof(ID), false, 0, 3, new System.Object[]{message, 171}, "Citizenship");
       this.add(typeof(ST), false, 1, 60, new System.Object[]{message}, "Veterans Military Status");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - Patient ID(PID-1).
	///</summary>
	public SI SetIDPatientID
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
	/// Returns Patient ID (External ID)(PID-2).
	///</summary>
	public CK_PAT_ID PatientIDExternalID
	{
		get{
			CK_PAT_ID ret = null;
			try
			{
			IType t = this.GetField(2, 0);
				ret = (CK_PAT_ID)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns a single repetition of Patient ID (Internal ID)(PID-3).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CM_PAT_ID GetPatientIDInternalID(int rep)
	{
			CM_PAT_ID ret = null;
			try
			{
			IType t = this.GetField(3, rep);
				ret = (CM_PAT_ID)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Patient ID (Internal ID) (PID-3).
   ///</summary>
  public CM_PAT_ID[] GetPatientIDInternalID() {
     CM_PAT_ID[] ret = null;
    try {
        IType[] t = this.GetField(3);  
        ret = new CM_PAT_ID[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CM_PAT_ID)t[i];
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
  /// Returns the total repetitions of Patient ID (Internal ID) (PID-3).
   ///</summary>
  public int PatientIDInternalIDRepetitionsUsed
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
	/// Returns Alternate Patient ID(PID-4).
	///</summary>
	public ST AlternatePatientID
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
	/// Returns Patient Name(PID-5).
	///</summary>
	public PN PatientName
	{
		get{
			PN ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Mother's Maiden Name(PID-6).
	///</summary>
	public ST MotherSMaidenName
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
	/// Returns Date of Birth(PID-7).
	///</summary>
	public TS DateOfBirth
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Sex(PID-8).
	///</summary>
	public ID Sex
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns a single repetition of Patient Alias(PID-9).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public PN GetPatientAlias(int rep)
	{
			PN ret = null;
			try
			{
			IType t = this.GetField(9, rep);
				ret = (PN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Patient Alias (PID-9).
   ///</summary>
  public PN[] GetPatientAlias() {
     PN[] ret = null;
    try {
        IType[] t = this.GetField(9);  
        ret = new PN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (PN)t[i];
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
  /// Returns the total repetitions of Patient Alias (PID-9).
   ///</summary>
  public int PatientAliasRepetitionsUsed
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
	/// Returns Race(PID-10).
	///</summary>
	public ID Race
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
	/// Returns a single repetition of Patient Address(PID-11).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public AD GetPatientAddress(int rep)
	{
			AD ret = null;
			try
			{
			IType t = this.GetField(11, rep);
				ret = (AD)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Patient Address (PID-11).
   ///</summary>
  public AD[] GetPatientAddress() {
     AD[] ret = null;
    try {
        IType[] t = this.GetField(11);  
        ret = new AD[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (AD)t[i];
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
  /// Returns the total repetitions of Patient Address (PID-11).
   ///</summary>
  public int PatientAddressRepetitionsUsed
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
	/// Returns County code(PID-12).
	///</summary>
	public ID CountyCode
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
	/// Returns a single repetition of Phone Number - Home(PID-13).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TN GetPhoneNumberHome(int rep)
	{
			TN ret = null;
			try
			{
			IType t = this.GetField(13, rep);
				ret = (TN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Phone Number - Home (PID-13).
   ///</summary>
  public TN[] GetPhoneNumberHome() {
     TN[] ret = null;
    try {
        IType[] t = this.GetField(13);  
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
  /// Returns the total repetitions of Phone Number - Home (PID-13).
   ///</summary>
  public int PhoneNumberHomeRepetitionsUsed
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
	/// Returns a single repetition of Phone Number - Business(PID-14).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TN GetPhoneNumberBusiness(int rep)
	{
			TN ret = null;
			try
			{
			IType t = this.GetField(14, rep);
				ret = (TN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Phone Number - Business (PID-14).
   ///</summary>
  public TN[] GetPhoneNumberBusiness() {
     TN[] ret = null;
    try {
        IType[] t = this.GetField(14);  
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
  /// Returns the total repetitions of Phone Number - Business (PID-14).
   ///</summary>
  public int PhoneNumberBusinessRepetitionsUsed
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
	/// Returns Language - Patient(PID-15).
	///</summary>
	public ST LanguagePatient
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Marital Status(PID-16).
	///</summary>
	public ID MaritalStatus
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Religion(PID-17).
	///</summary>
	public ID Religion
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
	/// Returns Patient Account Number(PID-18).
	///</summary>
	public CK_PAT_ID PatientAccountNumber
	{
		get{
			CK_PAT_ID ret = null;
			try
			{
			IType t = this.GetField(18, 0);
				ret = (CK_PAT_ID)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Social security number - patient(PID-19).
	///</summary>
	public ST SocialSecurityNumberPatient
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
	/// Returns Driver's license number - patient(PID-20).
	///</summary>
	public CM_LICENSE_NO DriverSLicenseNumberPatient
	{
		get{
			CM_LICENSE_NO ret = null;
			try
			{
			IType t = this.GetField(20, 0);
				ret = (CM_LICENSE_NO)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Mother's Identifier(PID-21).
	///</summary>
	public CK_PAT_ID MotherSIdentifier
	{
		get{
			CK_PAT_ID ret = null;
			try
			{
			IType t = this.GetField(21, 0);
				ret = (CK_PAT_ID)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Ethnic Group(PID-22).
	///</summary>
	public ID EthnicGroup
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
	/// Returns Birth Place(PID-23).
	///</summary>
	public ST BirthPlace
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Multiple Birth Indicator(PID-24).
	///</summary>
	public ID MultipleBirthIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Birth Order(PID-25).
	///</summary>
	public NM BirthOrder
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
	/// Returns a single repetition of Citizenship(PID-26).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ID GetCitizenship(int rep)
	{
			ID ret = null;
			try
			{
			IType t = this.GetField(26, rep);
				ret = (ID)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Citizenship (PID-26).
   ///</summary>
  public ID[] GetCitizenship() {
     ID[] ret = null;
    try {
        IType[] t = this.GetField(26);  
        ret = new ID[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (ID)t[i];
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
  /// Returns the total repetitions of Citizenship (PID-26).
   ///</summary>
  public int CitizenshipRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(26);
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
	/// Returns Veterans Military Status(PID-27).
	///</summary>
	public ST VeteransMilitaryStatus
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(27, 0);
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