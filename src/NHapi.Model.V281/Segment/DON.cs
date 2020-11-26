using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V281.Segment{

///<summary>
/// Represents an HL7 DON message segment. 
/// This segment has the following fields:<ol>
///<li>DON-1: Donation Identification Number - DIN (EI)</li>
///<li>DON-2: Donation Type (CNE)</li>
///<li>DON-3: Phlebotomy Start Date/Time (DTM)</li>
///<li>DON-4: Phlebotomy End Date/Time (DTM)</li>
///<li>DON-5: Donation Duration (NM)</li>
///<li>DON-6: Donation Duration Units (CNE)</li>
///<li>DON-7: Intended Procedure Type (CNE)</li>
///<li>DON-8: Actual Procedure Type (CNE)</li>
///<li>DON-9: Donor Eligibility Flag (ID)</li>
///<li>DON-10: Donor Eligibility Procedure Type (CNE)</li>
///<li>DON-11: Donor Eligibility Date (DTM)</li>
///<li>DON-12: Process Interruption (CNE)</li>
///<li>DON-13: Process Interruption Reason (CNE)</li>
///<li>DON-14: Phlebotomy Issue (CNE)</li>
///<li>DON-15: Intended Recipient Blood Relative (ID)</li>
///<li>DON-16: Intended Recipient Name (XPN)</li>
///<li>DON-17: Intended Recipient DOB (DTM)</li>
///<li>DON-18: Intended Recipient Facility (XON)</li>
///<li>DON-19: Intended Recipient Procedure Date (DTM)</li>
///<li>DON-20: Intended Recipient Ordering Provider (XPN)</li>
///<li>DON-21: Phlebotomy Status (CNE)</li>
///<li>DON-22: Arm Stick (CNE)</li>
///<li>DON-23: Bleed Start Phlebotomist (XPN)</li>
///<li>DON-24: Bleed End Phlebotomist (XPN)</li>
///<li>DON-25: Aphaeresis Type Machine (ST)</li>
///<li>DON-26: Aphaeresis Machine Serial Number (ST)</li>
///<li>DON-27: Donor Reaction (ID)</li>
///<li>DON-28: Final Review Staff ID (XPN)</li>
///<li>DON-29: Final Review Date/Time (DTM)</li>
///<li>DON-30: Number of Tubes Collected (NM)</li>
///<li>DON-31: Donation Sample Identifier (EI)</li>
///<li>DON-32: Donation Accept Staff (XCN)</li>
///<li>DON-33: Donation Material Review Staff (XCN)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class DON : AbstractSegment  {

  /**
   * Creates a DON (Donation) segment object that belongs to the given 
   * message.  
   */
	public DON(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Donation Identification Number - DIN");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Donation Type");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Phlebotomy Start Date/Time");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Phlebotomy End Date/Time");
       this.add(typeof(NM), true, 1, 0, new System.Object[]{message}, "Donation Duration");
       this.add(typeof(CNE), true, 1, 0, new System.Object[]{message}, "Donation Duration Units");
       this.add(typeof(CNE), true, 0, 0, new System.Object[]{message}, "Intended Procedure Type");
       this.add(typeof(CNE), true, 0, 0, new System.Object[]{message}, "Actual Procedure Type");
       this.add(typeof(ID), true, 1, 0, new System.Object[]{message, 136}, "Donor Eligibility Flag");
       this.add(typeof(CNE), true, 0, 0, new System.Object[]{message}, "Donor Eligibility Procedure Type");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Donor Eligibility Date");
       this.add(typeof(CNE), true, 1, 0, new System.Object[]{message}, "Process Interruption");
       this.add(typeof(CNE), true, 1, 0, new System.Object[]{message}, "Process Interruption Reason");
       this.add(typeof(CNE), true, 0, 0, new System.Object[]{message}, "Phlebotomy Issue");
       this.add(typeof(ID), true, 1, 0, new System.Object[]{message, 136}, "Intended Recipient Blood Relative");
       this.add(typeof(XPN), true, 1, 0, new System.Object[]{message}, "Intended Recipient Name");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Intended Recipient DOB");
       this.add(typeof(XON), true, 1, 0, new System.Object[]{message}, "Intended Recipient Facility");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Intended Recipient Procedure Date");
       this.add(typeof(XPN), true, 1, 0, new System.Object[]{message}, "Intended Recipient Ordering Provider");
       this.add(typeof(CNE), true, 1, 0, new System.Object[]{message}, "Phlebotomy Status");
       this.add(typeof(CNE), true, 1, 0, new System.Object[]{message}, "Arm Stick");
       this.add(typeof(XPN), true, 1, 0, new System.Object[]{message}, "Bleed Start Phlebotomist");
       this.add(typeof(XPN), true, 1, 0, new System.Object[]{message}, "Bleed End Phlebotomist");
       this.add(typeof(ST), true, 1, 0, new System.Object[]{message}, "Aphaeresis Type Machine");
       this.add(typeof(ST), true, 1, 0, new System.Object[]{message}, "Aphaeresis Machine Serial Number");
       this.add(typeof(ID), true, 1, 0, new System.Object[]{message, 136}, "Donor Reaction");
       this.add(typeof(XPN), true, 1, 0, new System.Object[]{message}, "Final Review Staff ID");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Final Review Date/Time");
       this.add(typeof(NM), true, 1, 0, new System.Object[]{message}, "Number of Tubes Collected");
       this.add(typeof(EI), true, 0, 0, new System.Object[]{message}, "Donation Sample Identifier");
       this.add(typeof(XCN), true, 1, 0, new System.Object[]{message}, "Donation Accept Staff");
       this.add(typeof(XCN), true, 0, 0, new System.Object[]{message}, "Donation Material Review Staff");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Donation Identification Number - DIN(DON-1).
	///</summary>
	public EI DonationIdentificationNumberDIN
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Donation Type(DON-2).
	///</summary>
	public CNE DonationType
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Phlebotomy Start Date/Time(DON-3).
	///</summary>
	public DTM PhlebotomyStartDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Phlebotomy End Date/Time(DON-4).
	///</summary>
	public DTM PhlebotomyEndDateTime
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
	/// Returns Donation Duration(DON-5).
	///</summary>
	public NM DonationDuration
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Donation Duration Units(DON-6).
	///</summary>
	public CNE DonationDurationUnits
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
	/// Returns a single repetition of Intended Procedure Type(DON-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CNE GetIntendedProcedureType(int rep)
	{
			CNE ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (CNE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Intended Procedure Type (DON-7).
   ///</summary>
  public CNE[] GetIntendedProcedureType() {
     CNE[] ret = null;
    try {
        IType[] t = this.GetField(7);  
        ret = new CNE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CNE)t[i];
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
  /// Returns the total repetitions of Intended Procedure Type (DON-7).
   ///</summary>
  public int IntendedProcedureTypeRepetitionsUsed
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
	/// Returns a single repetition of Actual Procedure Type(DON-8).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CNE GetActualProcedureType(int rep)
	{
			CNE ret = null;
			try
			{
			IType t = this.GetField(8, rep);
				ret = (CNE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Actual Procedure Type (DON-8).
   ///</summary>
  public CNE[] GetActualProcedureType() {
     CNE[] ret = null;
    try {
        IType[] t = this.GetField(8);  
        ret = new CNE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CNE)t[i];
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
  /// Returns the total repetitions of Actual Procedure Type (DON-8).
   ///</summary>
  public int ActualProcedureTypeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(8);
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
	/// Returns Donor Eligibility Flag(DON-9).
	///</summary>
	public ID DonorEligibilityFlag
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns a single repetition of Donor Eligibility Procedure Type(DON-10).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CNE GetDonorEligibilityProcedureType(int rep)
	{
			CNE ret = null;
			try
			{
			IType t = this.GetField(10, rep);
				ret = (CNE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Donor Eligibility Procedure Type (DON-10).
   ///</summary>
  public CNE[] GetDonorEligibilityProcedureType() {
     CNE[] ret = null;
    try {
        IType[] t = this.GetField(10);  
        ret = new CNE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CNE)t[i];
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
  /// Returns the total repetitions of Donor Eligibility Procedure Type (DON-10).
   ///</summary>
  public int DonorEligibilityProcedureTypeRepetitionsUsed
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
	/// Returns Donor Eligibility Date(DON-11).
	///</summary>
	public DTM DonorEligibilityDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Process Interruption(DON-12).
	///</summary>
	public CNE ProcessInterruption
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Process Interruption Reason(DON-13).
	///</summary>
	public CNE ProcessInterruptionReason
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns a single repetition of Phlebotomy Issue(DON-14).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CNE GetPhlebotomyIssue(int rep)
	{
			CNE ret = null;
			try
			{
			IType t = this.GetField(14, rep);
				ret = (CNE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Phlebotomy Issue (DON-14).
   ///</summary>
  public CNE[] GetPhlebotomyIssue() {
     CNE[] ret = null;
    try {
        IType[] t = this.GetField(14);  
        ret = new CNE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CNE)t[i];
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
  /// Returns the total repetitions of Phlebotomy Issue (DON-14).
   ///</summary>
  public int PhlebotomyIssueRepetitionsUsed
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
	/// Returns Intended Recipient Blood Relative(DON-15).
	///</summary>
	public ID IntendedRecipientBloodRelative
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
	/// Returns Intended Recipient Name(DON-16).
	///</summary>
	public XPN IntendedRecipientName
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
	/// Returns Intended Recipient DOB(DON-17).
	///</summary>
	public DTM IntendedRecipientDOB
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns Intended Recipient Facility(DON-18).
	///</summary>
	public XON IntendedRecipientFacility
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Intended Recipient Procedure Date(DON-19).
	///</summary>
	public DTM IntendedRecipientProcedureDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Intended Recipient Ordering Provider(DON-20).
	///</summary>
	public XPN IntendedRecipientOrderingProvider
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Phlebotomy Status(DON-21).
	///</summary>
	public CNE PhlebotomyStatus
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Arm Stick(DON-22).
	///</summary>
	public CNE ArmStick
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Bleed Start Phlebotomist(DON-23).
	///</summary>
	public XPN BleedStartPhlebotomist
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Bleed End Phlebotomist(DON-24).
	///</summary>
	public XPN BleedEndPhlebotomist
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Aphaeresis Type Machine(DON-25).
	///</summary>
	public ST AphaeresisTypeMachine
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
	/// Returns Aphaeresis Machine Serial Number(DON-26).
	///</summary>
	public ST AphaeresisMachineSerialNumber
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(26, 0);
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
	/// Returns Donor Reaction(DON-27).
	///</summary>
	public ID DonorReaction
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
	/// Returns Final Review Staff ID(DON-28).
	///</summary>
	public XPN FinalReviewStaffID
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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
	/// Returns Final Review Date/Time(DON-29).
	///</summary>
	public DTM FinalReviewDateTime
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
	/// Returns Number of Tubes Collected(DON-30).
	///</summary>
	public NM NumberOfTubesCollected
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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
	/// Returns a single repetition of Donation Sample Identifier(DON-31).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public EI GetDonationSampleIdentifier(int rep)
	{
			EI ret = null;
			try
			{
			IType t = this.GetField(31, rep);
				ret = (EI)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Donation Sample Identifier (DON-31).
   ///</summary>
  public EI[] GetDonationSampleIdentifier() {
     EI[] ret = null;
    try {
        IType[] t = this.GetField(31);  
        ret = new EI[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (EI)t[i];
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
  /// Returns the total repetitions of Donation Sample Identifier (DON-31).
   ///</summary>
  public int DonationSampleIdentifierRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(31);
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
	/// Returns Donation Accept Staff(DON-32).
	///</summary>
	public XCN DonationAcceptStaff
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(32, 0);
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
	/// Returns a single repetition of Donation Material Review Staff(DON-33).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetDonationMaterialReviewStaff(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(33, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Donation Material Review Staff (DON-33).
   ///</summary>
  public XCN[] GetDonationMaterialReviewStaff() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(33);  
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
  /// Returns the total repetitions of Donation Material Review Staff (DON-33).
   ///</summary>
  public int DonationMaterialReviewStaffRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(33);
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