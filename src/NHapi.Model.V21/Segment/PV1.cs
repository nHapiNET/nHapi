using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V21.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V21.Segment{

///<summary>
/// Represents an HL7 PV1 message segment. 
/// This segment has the following fields:<ol>
///<li>PV1-1: SET ID - PATIENT VISIT (SI)</li>
///<li>PV1-2: PATIENT CLASS (ID)</li>
///<li>PV1-3: ASSIGNED PATIENT LOCATION (ID)</li>
///<li>PV1-4: ADMISSION TYPE (ID)</li>
///<li>PV1-5: PRE-ADMIT NUMBER (ST)</li>
///<li>PV1-6: PRIOR PATIENT LOCATION (ID)</li>
///<li>PV1-7: ATTENDING DOCTOR (CN)</li>
///<li>PV1-8: REFERRING DOCTOR (CN)</li>
///<li>PV1-9: CONSULTING DOCTOR (CN)</li>
///<li>PV1-10: HOSPITAL SERVICE (ID)</li>
///<li>PV1-11: TEMPORARY LOCATION (ID)</li>
///<li>PV1-12: PRE-ADMIT TEST INDICATOR (ID)</li>
///<li>PV1-13: RE-ADMISSION INDICATOR (ID)</li>
///<li>PV1-14: ADMIT SOURCE (ID)</li>
///<li>PV1-15: AMBULATORY STATUS (ID)</li>
///<li>PV1-16: VIP INDICATOR (ID)</li>
///<li>PV1-17: ADMITTING DOCTOR (CN)</li>
///<li>PV1-18: PATIENT TYPE (ID)</li>
///<li>PV1-19: VISIT NUMBER (NM)</li>
///<li>PV1-20: FINANCIAL CLASS (ID)</li>
///<li>PV1-21: CHARGE PRICE INDICATOR (ID)</li>
///<li>PV1-22: COURTESY CODE (ID)</li>
///<li>PV1-23: CREDIT RATING (ID)</li>
///<li>PV1-24: CONTRACT CODE (ID)</li>
///<li>PV1-25: CONTRACT EFFECTIVE DATE (DT)</li>
///<li>PV1-26: CONTRACT AMOUNT (NM)</li>
///<li>PV1-27: CONTRACT PERIOD (NM)</li>
///<li>PV1-28: INTEREST CODE (ID)</li>
///<li>PV1-29: TRANSFER TO BAD DEBT CODE (ID)</li>
///<li>PV1-30: TRANSFER TO BAD DEBT DATE (DT)</li>
///<li>PV1-31: BAD DEBT AGENCY CODE (ST)</li>
///<li>PV1-32: BAD DEBT TRANSFER AMOUNT (NM)</li>
///<li>PV1-33: BAD DEBT RECOVERY AMOUNT (NM)</li>
///<li>PV1-34: DELETE ACCOUNT INDICATOR (ID)</li>
///<li>PV1-35: DELETE ACCOUNT DATE (DT)</li>
///<li>PV1-36: DISCHARGE DISPOSITION (ID)</li>
///<li>PV1-37: DISCHARGED TO LOCATION (ID)</li>
///<li>PV1-38: DIET TYPE (ID)</li>
///<li>PV1-39: SERVICING FACILITY (ID)</li>
///<li>PV1-40: BED STATUS (ID)</li>
///<li>PV1-41: ACCOUNT STATUS (ID)</li>
///<li>PV1-42: PENDING LOCATION (ID)</li>
///<li>PV1-43: PRIOR TEMPORARY LOCATION (ID)</li>
///<li>PV1-44: ADMIT DATE/TIME (TS)</li>
///<li>PV1-45: DISCHARGE DATE/TIME (TS)</li>
///<li>PV1-46: CURRENT PATIENT BALANCE (NM)</li>
///<li>PV1-47: TOTAL CHARGES (NM)</li>
///<li>PV1-48: TOTAL ADJUSTMENTS (NM)</li>
///<li>PV1-49: TOTAL PAYMENTS (NM)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class PV1 : AbstractSegment  {

  /**
   * Creates a PV1 (PATIENT VISIT) segment object that belongs to the given 
   * message.  
   */
	public PV1(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), false, 1, 4, new System.Object[]{message}, "SET ID - PATIENT VISIT");
       this.add(typeof(ID), true, 1, 1, new System.Object[]{message, 4}, "PATIENT CLASS");
       this.add(typeof(ID), true, 1, 12, new System.Object[]{message, 79}, "ASSIGNED PATIENT LOCATION");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 7}, "ADMISSION TYPE");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "PRE-ADMIT NUMBER");
       this.add(typeof(ID), false, 1, 12, new System.Object[]{message, 79}, "PRIOR PATIENT LOCATION");
       this.add(typeof(CN), false, 1, 60, new System.Object[]{message}, "ATTENDING DOCTOR");
       this.add(typeof(CN), false, 1, 60, new System.Object[]{message}, "REFERRING DOCTOR");
       this.add(typeof(CN), false, 0, 60, new System.Object[]{message}, "CONSULTING DOCTOR");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 69}, "HOSPITAL SERVICE");
       this.add(typeof(ID), false, 1, 12, new System.Object[]{message, 79}, "TEMPORARY LOCATION");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 87}, "PRE-ADMIT TEST INDICATOR");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 92}, "RE-ADMISSION INDICATOR");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 23}, "ADMIT SOURCE");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 9}, "AMBULATORY STATUS");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 99}, "VIP INDICATOR");
       this.add(typeof(CN), false, 1, 60, new System.Object[]{message}, "ADMITTING DOCTOR");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 18}, "PATIENT TYPE");
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "VISIT NUMBER");
       this.add(typeof(ID), false, 4, 11, new System.Object[]{message, 64}, "FINANCIAL CLASS");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 32}, "CHARGE PRICE INDICATOR");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 45}, "COURTESY CODE");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 46}, "CREDIT RATING");
       this.add(typeof(ID), false, 0, 2, new System.Object[]{message, 44}, "CONTRACT CODE");
       this.add(typeof(DT), false, 0, 8, new System.Object[]{message}, "CONTRACT EFFECTIVE DATE");
       this.add(typeof(NM), false, 0, 12, new System.Object[]{message}, "CONTRACT AMOUNT");
       this.add(typeof(NM), false, 0, 3, new System.Object[]{message}, "CONTRACT PERIOD");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 73}, "INTEREST CODE");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 110}, "TRANSFER TO BAD DEBT CODE");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "TRANSFER TO BAD DEBT DATE");
       this.add(typeof(ST), false, 1, 10, new System.Object[]{message}, "BAD DEBT AGENCY CODE");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "BAD DEBT TRANSFER AMOUNT");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "BAD DEBT RECOVERY AMOUNT");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 111}, "DELETE ACCOUNT INDICATOR");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "DELETE ACCOUNT DATE");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 112}, "DISCHARGE DISPOSITION");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 113}, "DISCHARGED TO LOCATION");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 114}, "DIET TYPE");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 115}, "SERVICING FACILITY");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 116}, "BED STATUS");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 117}, "ACCOUNT STATUS");
       this.add(typeof(ID), false, 1, 12, new System.Object[]{message, 79}, "PENDING LOCATION");
       this.add(typeof(ID), false, 1, 12, new System.Object[]{message, 79}, "PRIOR TEMPORARY LOCATION");
       this.add(typeof(TS), false, 1, 19, new System.Object[]{message}, "ADMIT DATE/TIME");
       this.add(typeof(TS), false, 1, 19, new System.Object[]{message}, "DISCHARGE DATE/TIME");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "CURRENT PATIENT BALANCE");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "TOTAL CHARGES");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "TOTAL ADJUSTMENTS");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "TOTAL PAYMENTS");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns SET ID - PATIENT VISIT(PV1-1).
	///</summary>
	public SI SETIDPATIENTVISIT
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
	/// Returns PATIENT CLASS(PV1-2).
	///</summary>
	public ID PATIENTCLASS
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
	/// Returns ASSIGNED PATIENT LOCATION(PV1-3).
	///</summary>
	public ID ASSIGNEDPATIENTLOCATION
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns ADMISSION TYPE(PV1-4).
	///</summary>
	public ID ADMISSIONTYPE
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns PRE-ADMIT NUMBER(PV1-5).
	///</summary>
	public ST PREADMITNUMBER
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

	///<summary>
	/// Returns PRIOR PATIENT LOCATION(PV1-6).
	///</summary>
	public ID PRIORPATIENTLOCATION
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns ATTENDING DOCTOR(PV1-7).
	///</summary>
	public CN ATTENDINGDOCTOR
	{
		get{
			CN ret = null;
			try
			{
			IType t = this.GetField(7, 0);
				ret = (CN)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns REFERRING DOCTOR(PV1-8).
	///</summary>
	public CN REFERRINGDOCTOR
	{
		get{
			CN ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (CN)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns a single repetition of CONSULTING DOCTOR(PV1-9).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CN GetCONSULTINGDOCTOR(int rep)
	{
			CN ret = null;
			try
			{
			IType t = this.GetField(9, rep);
				ret = (CN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of CONSULTING DOCTOR (PV1-9).
   ///</summary>
  public CN[] GetCONSULTINGDOCTOR() {
     CN[] ret = null;
    try {
        IType[] t = this.GetField(9);  
        ret = new CN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CN)t[i];
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
  /// Returns the total repetitions of CONSULTING DOCTOR (PV1-9).
   ///</summary>
  public int CONSULTINGDOCTORRepetitionsUsed
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
	/// Returns HOSPITAL SERVICE(PV1-10).
	///</summary>
	public ID HOSPITALSERVICE
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
	/// Returns TEMPORARY LOCATION(PV1-11).
	///</summary>
	public ID TEMPORARYLOCATION
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns PRE-ADMIT TEST INDICATOR(PV1-12).
	///</summary>
	public ID PREADMITTESTINDICATOR
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
	/// Returns RE-ADMISSION INDICATOR(PV1-13).
	///</summary>
	public ID READMISSIONINDICATOR
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns ADMIT SOURCE(PV1-14).
	///</summary>
	public ID ADMITSOURCE
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns AMBULATORY STATUS(PV1-15).
	///</summary>
	public ID AMBULATORYSTATUS
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
	/// Returns VIP INDICATOR(PV1-16).
	///</summary>
	public ID VIPINDICATOR
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
	/// Returns ADMITTING DOCTOR(PV1-17).
	///</summary>
	public CN ADMITTINGDOCTOR
	{
		get{
			CN ret = null;
			try
			{
			IType t = this.GetField(17, 0);
				ret = (CN)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns PATIENT TYPE(PV1-18).
	///</summary>
	public ID PATIENTTYPE
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns VISIT NUMBER(PV1-19).
	///</summary>
	public NM VISITNUMBER
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns a single repetition of FINANCIAL CLASS(PV1-20).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ID GetFINANCIALCLASS(int rep)
	{
			ID ret = null;
			try
			{
			IType t = this.GetField(20, rep);
				ret = (ID)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of FINANCIAL CLASS (PV1-20).
   ///</summary>
  public ID[] GetFINANCIALCLASS() {
     ID[] ret = null;
    try {
        IType[] t = this.GetField(20);  
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
  /// Returns the total repetitions of FINANCIAL CLASS (PV1-20).
   ///</summary>
  public int FINANCIALCLASSRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(20);
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
	/// Returns CHARGE PRICE INDICATOR(PV1-21).
	///</summary>
	public ID CHARGEPRICEINDICATOR
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
	/// Returns COURTESY CODE(PV1-22).
	///</summary>
	public ID COURTESYCODE
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
	/// Returns CREDIT RATING(PV1-23).
	///</summary>
	public ID CREDITRATING
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
	/// Returns a single repetition of CONTRACT CODE(PV1-24).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ID GetCONTRACTCODE(int rep)
	{
			ID ret = null;
			try
			{
			IType t = this.GetField(24, rep);
				ret = (ID)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of CONTRACT CODE (PV1-24).
   ///</summary>
  public ID[] GetCONTRACTCODE() {
     ID[] ret = null;
    try {
        IType[] t = this.GetField(24);  
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
  /// Returns the total repetitions of CONTRACT CODE (PV1-24).
   ///</summary>
  public int CONTRACTCODERepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(24);
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
	/// Returns a single repetition of CONTRACT EFFECTIVE DATE(PV1-25).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public DT GetCONTRACTEFFECTIVEDATE(int rep)
	{
			DT ret = null;
			try
			{
			IType t = this.GetField(25, rep);
				ret = (DT)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of CONTRACT EFFECTIVE DATE (PV1-25).
   ///</summary>
  public DT[] GetCONTRACTEFFECTIVEDATE() {
     DT[] ret = null;
    try {
        IType[] t = this.GetField(25);  
        ret = new DT[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (DT)t[i];
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
  /// Returns the total repetitions of CONTRACT EFFECTIVE DATE (PV1-25).
   ///</summary>
  public int CONTRACTEFFECTIVEDATERepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(25);
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
	/// Returns a single repetition of CONTRACT AMOUNT(PV1-26).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NM GetCONTRACTAMOUNT(int rep)
	{
			NM ret = null;
			try
			{
			IType t = this.GetField(26, rep);
				ret = (NM)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of CONTRACT AMOUNT (PV1-26).
   ///</summary>
  public NM[] GetCONTRACTAMOUNT() {
     NM[] ret = null;
    try {
        IType[] t = this.GetField(26);  
        ret = new NM[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (NM)t[i];
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
  /// Returns the total repetitions of CONTRACT AMOUNT (PV1-26).
   ///</summary>
  public int CONTRACTAMOUNTRepetitionsUsed
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
	/// Returns a single repetition of CONTRACT PERIOD(PV1-27).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NM GetCONTRACTPERIOD(int rep)
	{
			NM ret = null;
			try
			{
			IType t = this.GetField(27, rep);
				ret = (NM)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of CONTRACT PERIOD (PV1-27).
   ///</summary>
  public NM[] GetCONTRACTPERIOD() {
     NM[] ret = null;
    try {
        IType[] t = this.GetField(27);  
        ret = new NM[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (NM)t[i];
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
  /// Returns the total repetitions of CONTRACT PERIOD (PV1-27).
   ///</summary>
  public int CONTRACTPERIODRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(27);
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
	/// Returns INTEREST CODE(PV1-28).
	///</summary>
	public ID INTERESTCODE
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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
	/// Returns TRANSFER TO BAD DEBT CODE(PV1-29).
	///</summary>
	public ID TRANSFERTOBADDEBTCODE
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

	///<summary>
	/// Returns TRANSFER TO BAD DEBT DATE(PV1-30).
	///</summary>
	public DT TRANSFERTOBADDEBTDATE
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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
	/// Returns BAD DEBT AGENCY CODE(PV1-31).
	///</summary>
	public ST BADDEBTAGENCYCODE
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(31, 0);
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
	/// Returns BAD DEBT TRANSFER AMOUNT(PV1-32).
	///</summary>
	public NM BADDEBTTRANSFERAMOUNT
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(32, 0);
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
	/// Returns BAD DEBT RECOVERY AMOUNT(PV1-33).
	///</summary>
	public NM BADDEBTRECOVERYAMOUNT
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
	/// Returns DELETE ACCOUNT INDICATOR(PV1-34).
	///</summary>
	public ID DELETEACCOUNTINDICATOR
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
	/// Returns DELETE ACCOUNT DATE(PV1-35).
	///</summary>
	public DT DELETEACCOUNTDATE
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(35, 0);
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
	/// Returns DISCHARGE DISPOSITION(PV1-36).
	///</summary>
	public ID DISCHARGEDISPOSITION
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
	/// Returns DISCHARGED TO LOCATION(PV1-37).
	///</summary>
	public ID DISCHARGEDTOLOCATION
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
	/// Returns DIET TYPE(PV1-38).
	///</summary>
	public ID DIETTYPE
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(38, 0);
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
	/// Returns SERVICING FACILITY(PV1-39).
	///</summary>
	public ID SERVICINGFACILITY
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(39, 0);
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
	/// Returns BED STATUS(PV1-40).
	///</summary>
	public ID BEDSTATUS
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(40, 0);
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
	/// Returns ACCOUNT STATUS(PV1-41).
	///</summary>
	public ID ACCOUNTSTATUS
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(41, 0);
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
	/// Returns PENDING LOCATION(PV1-42).
	///</summary>
	public ID PENDINGLOCATION
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(42, 0);
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
	/// Returns PRIOR TEMPORARY LOCATION(PV1-43).
	///</summary>
	public ID PRIORTEMPORARYLOCATION
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
	/// Returns ADMIT DATE/TIME(PV1-44).
	///</summary>
	public TS ADMITDATETIME
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(44, 0);
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
	/// Returns DISCHARGE DATE/TIME(PV1-45).
	///</summary>
	public TS DISCHARGEDATETIME
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(45, 0);
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
	/// Returns CURRENT PATIENT BALANCE(PV1-46).
	///</summary>
	public NM CURRENTPATIENTBALANCE
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(46, 0);
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
	/// Returns TOTAL CHARGES(PV1-47).
	///</summary>
	public NM TOTALCHARGES
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(47, 0);
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
	/// Returns TOTAL ADJUSTMENTS(PV1-48).
	///</summary>
	public NM TOTALADJUSTMENTS
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(48, 0);
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
	/// Returns TOTAL PAYMENTS(PV1-49).
	///</summary>
	public NM TOTALPAYMENTS
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(49, 0);
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


}}