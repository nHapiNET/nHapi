using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V22.Segment{

///<summary>
/// Represents an HL7 PV1 message segment. 
/// This segment has the following fields:<ol>
///<li>PV1-1: Set ID - Patient Visit (SI)</li>
///<li>PV1-2: Patient Class (ID)</li>
///<li>PV1-3: Assigned Patient Location (CM_INTERNAL_LOCATION)</li>
///<li>PV1-4: Admission Type (ID)</li>
///<li>PV1-5: Preadmit Number (ST)</li>
///<li>PV1-6: Prior Patient Location (CM_INTERNAL_LOCATION)</li>
///<li>PV1-7: Attending Doctor (CN_PHYSICIAN)</li>
///<li>PV1-8: Referring Doctor (CN_PHYSICIAN)</li>
///<li>PV1-9: Consulting Doctor (CN_PHYSICIAN)</li>
///<li>PV1-10: Hospital Service (ID)</li>
///<li>PV1-11: Temporary Location (CM_INTERNAL_LOCATION)</li>
///<li>PV1-12: Preadmit Test Indicator (ID)</li>
///<li>PV1-13: Readmission indicator (ID)</li>
///<li>PV1-14: Admit Source (ID)</li>
///<li>PV1-15: Ambulatory Status (ID)</li>
///<li>PV1-16: VIP Indicator (ID)</li>
///<li>PV1-17: Admitting Doctor (CN_PHYSICIAN)</li>
///<li>PV1-18: Patient type (ID)</li>
///<li>PV1-19: Visit Number (CM_PAT_ID)</li>
///<li>PV1-20: Financial Class (CM_FINANCE)</li>
///<li>PV1-21: Charge Price Indicator (ID)</li>
///<li>PV1-22: Courtesy Code (ID)</li>
///<li>PV1-23: Credit Rating (ID)</li>
///<li>PV1-24: Contract Code (ID)</li>
///<li>PV1-25: Contract Effective Date (DT)</li>
///<li>PV1-26: Contract Amount (NM)</li>
///<li>PV1-27: Contract Period (NM)</li>
///<li>PV1-28: Interest Code (ID)</li>
///<li>PV1-29: Transfer to bad debt - code (ID)</li>
///<li>PV1-30: Transfer to bad debt - date (DT)</li>
///<li>PV1-31: Bad Debt Agency Code (ID)</li>
///<li>PV1-32: Bad Debt Transfer Amount (NM)</li>
///<li>PV1-33: Bad Debt Recovery Amount (NM)</li>
///<li>PV1-34: Delete Account Indicator (ID)</li>
///<li>PV1-35: Delete Account Date (DT)</li>
///<li>PV1-36: Discharge Disposition (ID)</li>
///<li>PV1-37: Discharged to Location (CM_DLD)</li>
///<li>PV1-38: Diet Type (ID)</li>
///<li>PV1-39: Servicing Facility (ID)</li>
///<li>PV1-40: Bed Status (ID)</li>
///<li>PV1-41: Account Status (ID)</li>
///<li>PV1-42: Pending Location (CM_INTERNAL_LOCATION)</li>
///<li>PV1-43: Prior Temporary Location (CM_INTERNAL_LOCATION)</li>
///<li>PV1-44: Admit date / time (TS)</li>
///<li>PV1-45: Discharge date / time (TS)</li>
///<li>PV1-46: Current Patient Balance (NM)</li>
///<li>PV1-47: Total Charges (NM)</li>
///<li>PV1-48: Total Adjustments (NM)</li>
///<li>PV1-49: Total Payments (NM)</li>
///<li>PV1-50: Alternate Visit ID (CM_PAT_ID_0192)</li>
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
       this.add(typeof(SI), false, 1, 4, new System.Object[]{message}, "Set ID - Patient Visit");
       this.add(typeof(ID), true, 1, 1, new System.Object[]{message, 4}, "Patient Class");
       this.add(typeof(CM_INTERNAL_LOCATION), false, 1, 12, new System.Object[]{message}, "Assigned Patient Location");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 7}, "Admission Type");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "Preadmit Number");
       this.add(typeof(CM_INTERNAL_LOCATION), false, 1, 12, new System.Object[]{message}, "Prior Patient Location");
       this.add(typeof(CN_PHYSICIAN), false, 1, 60, new System.Object[]{message}, "Attending Doctor");
       this.add(typeof(CN_PHYSICIAN), false, 1, 60, new System.Object[]{message}, "Referring Doctor");
       this.add(typeof(CN_PHYSICIAN), false, 0, 60, new System.Object[]{message}, "Consulting Doctor");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 69}, "Hospital Service");
       this.add(typeof(CM_INTERNAL_LOCATION), false, 1, 12, new System.Object[]{message}, "Temporary Location");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 87}, "Preadmit Test Indicator");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 92}, "Readmission indicator");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 23}, "Admit Source");
       this.add(typeof(ID), false, 0, 2, new System.Object[]{message, 9}, "Ambulatory Status");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 99}, "VIP Indicator");
       this.add(typeof(CN_PHYSICIAN), false, 1, 60, new System.Object[]{message}, "Admitting Doctor");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 18}, "Patient type");
       this.add(typeof(NM), false, 1, 15, new System.Object[]{message}, "Visit Number");
       this.add(typeof(CM_FINANCE), false, 4, 50, new System.Object[]{message}, "Financial Class");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 32}, "Charge Price Indicator");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 45}, "Courtesy Code");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 46}, "Credit Rating");
       this.add(typeof(ID), false, 0, 2, new System.Object[]{message, 44}, "Contract Code");
       this.add(typeof(DT), false, 0, 8, new System.Object[]{message}, "Contract Effective Date");
       this.add(typeof(NM), false, 0, 12, new System.Object[]{message}, "Contract Amount");
       this.add(typeof(NM), false, 0, 3, new System.Object[]{message}, "Contract Period");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 73}, "Interest Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 110}, "Transfer to bad debt - code");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Transfer to bad debt - date");
       this.add(typeof(ID), false, 1, 10, new System.Object[]{message, 21}, "Bad Debt Agency Code");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "Bad Debt Transfer Amount");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "Bad Debt Recovery Amount");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 111}, "Delete Account Indicator");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Delete Account Date");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 112}, "Discharge Disposition");
       this.add(typeof(CM_DLD), false, 1, 25, new System.Object[]{message}, "Discharged to Location");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 114}, "Diet Type");
       this.add(typeof(ID), false, 1, 4, new System.Object[]{message, 115}, "Servicing Facility");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 116}, "Bed Status");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 117}, "Account Status");
       this.add(typeof(CM_INTERNAL_LOCATION), false, 1, 12, new System.Object[]{message}, "Pending Location");
       this.add(typeof(CM_INTERNAL_LOCATION), false, 1, 12, new System.Object[]{message}, "Prior Temporary Location");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Admit date / time");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Discharge date / time");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "Current Patient Balance");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "Total Charges");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "Total Adjustments");
       this.add(typeof(NM), false, 1, 12, new System.Object[]{message}, "Total Payments");
       this.add(typeof(CM_PAT_ID_0192), false, 1, 20, new System.Object[]{message}, "Alternate Visit ID");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - Patient Visit(PV1-1).
	///</summary>
	public SI SetIDPatientVisit
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
	/// Returns Patient Class(PV1-2).
	///</summary>
	public ID PatientClass
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
	/// Returns Assigned Patient Location(PV1-3).
	///</summary>
	public CM_INTERNAL_LOCATION AssignedPatientLocation
	{
		get{
			CM_INTERNAL_LOCATION ret = null;
			try
			{
			IType t = this.GetField(3, 0);
				ret = (CM_INTERNAL_LOCATION)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Admission Type(PV1-4).
	///</summary>
	public ID AdmissionType
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
	/// Returns Preadmit Number(PV1-5).
	///</summary>
	public ST PreadmitNumber
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
	/// Returns Prior Patient Location(PV1-6).
	///</summary>
	public CM_INTERNAL_LOCATION PriorPatientLocation
	{
		get{
			CM_INTERNAL_LOCATION ret = null;
			try
			{
			IType t = this.GetField(6, 0);
				ret = (CM_INTERNAL_LOCATION)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Attending Doctor(PV1-7).
	///</summary>
	public CN_PHYSICIAN AttendingDoctor
	{
		get{
			CN_PHYSICIAN ret = null;
			try
			{
			IType t = this.GetField(7, 0);
				ret = (CN_PHYSICIAN)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Referring Doctor(PV1-8).
	///</summary>
	public CN_PHYSICIAN ReferringDoctor
	{
		get{
			CN_PHYSICIAN ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (CN_PHYSICIAN)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns a single repetition of Consulting Doctor(PV1-9).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CN_PHYSICIAN GetConsultingDoctor(int rep)
	{
			CN_PHYSICIAN ret = null;
			try
			{
			IType t = this.GetField(9, rep);
				ret = (CN_PHYSICIAN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Consulting Doctor (PV1-9).
   ///</summary>
  public CN_PHYSICIAN[] GetConsultingDoctor() {
     CN_PHYSICIAN[] ret = null;
    try {
        IType[] t = this.GetField(9);  
        ret = new CN_PHYSICIAN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CN_PHYSICIAN)t[i];
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
  /// Returns the total repetitions of Consulting Doctor (PV1-9).
   ///</summary>
  public int ConsultingDoctorRepetitionsUsed
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
	/// Returns Hospital Service(PV1-10).
	///</summary>
	public ID HospitalService
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
	/// Returns Temporary Location(PV1-11).
	///</summary>
	public CM_INTERNAL_LOCATION TemporaryLocation
	{
		get{
			CM_INTERNAL_LOCATION ret = null;
			try
			{
			IType t = this.GetField(11, 0);
				ret = (CM_INTERNAL_LOCATION)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Preadmit Test Indicator(PV1-12).
	///</summary>
	public ID PreadmitTestIndicator
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
	/// Returns Readmission indicator(PV1-13).
	///</summary>
	public ID ReadmissionIndicator
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
	/// Returns Admit Source(PV1-14).
	///</summary>
	public ID AdmitSource
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
	/// Returns a single repetition of Ambulatory Status(PV1-15).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ID GetAmbulatoryStatus(int rep)
	{
			ID ret = null;
			try
			{
			IType t = this.GetField(15, rep);
				ret = (ID)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Ambulatory Status (PV1-15).
   ///</summary>
  public ID[] GetAmbulatoryStatus() {
     ID[] ret = null;
    try {
        IType[] t = this.GetField(15);  
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
  /// Returns the total repetitions of Ambulatory Status (PV1-15).
   ///</summary>
  public int AmbulatoryStatusRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(15);
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
	/// Returns VIP Indicator(PV1-16).
	///</summary>
	public ID VIPIndicator
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
	/// Returns Admitting Doctor(PV1-17).
	///</summary>
	public CN_PHYSICIAN AdmittingDoctor
	{
		get{
			CN_PHYSICIAN ret = null;
			try
			{
			IType t = this.GetField(17, 0);
				ret = (CN_PHYSICIAN)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Patient type(PV1-18).
	///</summary>
	public ID PatientType
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
	/// Returns Visit Number(PV1-19).
	///</summary>
	public NM VisitNumber
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
	/// Returns a single repetition of Financial Class(PV1-20).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CM_FINANCE GetFinancialClass(int rep)
	{
			CM_FINANCE ret = null;
			try
			{
			IType t = this.GetField(20, rep);
				ret = (CM_FINANCE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Financial Class (PV1-20).
   ///</summary>
  public CM_FINANCE[] GetFinancialClass() {
     CM_FINANCE[] ret = null;
    try {
        IType[] t = this.GetField(20);  
        ret = new CM_FINANCE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CM_FINANCE)t[i];
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
  /// Returns the total repetitions of Financial Class (PV1-20).
   ///</summary>
  public int FinancialClassRepetitionsUsed
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
	/// Returns Charge Price Indicator(PV1-21).
	///</summary>
	public ID ChargePriceIndicator
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
	/// Returns Courtesy Code(PV1-22).
	///</summary>
	public ID CourtesyCode
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
	/// Returns Credit Rating(PV1-23).
	///</summary>
	public ID CreditRating
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
	/// Returns a single repetition of Contract Code(PV1-24).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ID GetContractCode(int rep)
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
  /// Returns all repetitions of Contract Code (PV1-24).
   ///</summary>
  public ID[] GetContractCode() {
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
  /// Returns the total repetitions of Contract Code (PV1-24).
   ///</summary>
  public int ContractCodeRepetitionsUsed
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
	/// Returns a single repetition of Contract Effective Date(PV1-25).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public DT GetContractEffectiveDate(int rep)
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
  /// Returns all repetitions of Contract Effective Date (PV1-25).
   ///</summary>
  public DT[] GetContractEffectiveDate() {
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
  /// Returns the total repetitions of Contract Effective Date (PV1-25).
   ///</summary>
  public int ContractEffectiveDateRepetitionsUsed
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
	/// Returns a single repetition of Contract Amount(PV1-26).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NM GetContractAmount(int rep)
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
  /// Returns all repetitions of Contract Amount (PV1-26).
   ///</summary>
  public NM[] GetContractAmount() {
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
  /// Returns the total repetitions of Contract Amount (PV1-26).
   ///</summary>
  public int ContractAmountRepetitionsUsed
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
	/// Returns a single repetition of Contract Period(PV1-27).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NM GetContractPeriod(int rep)
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
  /// Returns all repetitions of Contract Period (PV1-27).
   ///</summary>
  public NM[] GetContractPeriod() {
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
  /// Returns the total repetitions of Contract Period (PV1-27).
   ///</summary>
  public int ContractPeriodRepetitionsUsed
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
	/// Returns Interest Code(PV1-28).
	///</summary>
	public ID InterestCode
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
	/// Returns Transfer to bad debt - code(PV1-29).
	///</summary>
	public ID TransferToBadDebtCode
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
	/// Returns Transfer to bad debt - date(PV1-30).
	///</summary>
	public DT TransferToBadDebtDate
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
	/// Returns Bad Debt Agency Code(PV1-31).
	///</summary>
	public ID BadDebtAgencyCode
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
	/// Returns Bad Debt Transfer Amount(PV1-32).
	///</summary>
	public NM BadDebtTransferAmount
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
	/// Returns Bad Debt Recovery Amount(PV1-33).
	///</summary>
	public NM BadDebtRecoveryAmount
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
	/// Returns Delete Account Indicator(PV1-34).
	///</summary>
	public ID DeleteAccountIndicator
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
	/// Returns Delete Account Date(PV1-35).
	///</summary>
	public DT DeleteAccountDate
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
	/// Returns Discharge Disposition(PV1-36).
	///</summary>
	public ID DischargeDisposition
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
	/// Returns Discharged to Location(PV1-37).
	///</summary>
	public CM_DLD DischargedToLocation
	{
		get{
			CM_DLD ret = null;
			try
			{
			IType t = this.GetField(37, 0);
				ret = (CM_DLD)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Diet Type(PV1-38).
	///</summary>
	public ID DietType
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
	/// Returns Servicing Facility(PV1-39).
	///</summary>
	public ID ServicingFacility
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
	/// Returns Bed Status(PV1-40).
	///</summary>
	public ID BedStatus
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
	/// Returns Account Status(PV1-41).
	///</summary>
	public ID AccountStatus
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
	/// Returns Pending Location(PV1-42).
	///</summary>
	public CM_INTERNAL_LOCATION PendingLocation
	{
		get{
			CM_INTERNAL_LOCATION ret = null;
			try
			{
			IType t = this.GetField(42, 0);
				ret = (CM_INTERNAL_LOCATION)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Prior Temporary Location(PV1-43).
	///</summary>
	public CM_INTERNAL_LOCATION PriorTemporaryLocation
	{
		get{
			CM_INTERNAL_LOCATION ret = null;
			try
			{
			IType t = this.GetField(43, 0);
				ret = (CM_INTERNAL_LOCATION)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Admit date / time(PV1-44).
	///</summary>
	public TS AdmitDateTime
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
	/// Returns Discharge date / time(PV1-45).
	///</summary>
	public TS DischargeDateTime
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
	/// Returns Current Patient Balance(PV1-46).
	///</summary>
	public NM CurrentPatientBalance
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
	/// Returns Total Charges(PV1-47).
	///</summary>
	public NM TotalCharges
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
	/// Returns Total Adjustments(PV1-48).
	///</summary>
	public NM TotalAdjustments
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
	/// Returns Total Payments(PV1-49).
	///</summary>
	public NM TotalPayments
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

	///<summary>
	/// Returns Alternate Visit ID(PV1-50).
	///</summary>
	public CM_PAT_ID_0192 AlternateVisitID
	{
		get{
			CM_PAT_ID_0192 ret = null;
			try
			{
			IType t = this.GetField(50, 0);
				ret = (CM_PAT_ID_0192)t;
			}
			 catch (HL7Exception he) {
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