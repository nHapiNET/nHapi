using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V23UCH.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V23UCH.Segment{

///<summary>
/// Represents an HL7 ZEG message segment. 
/// This segment has the following fields:<ol>
///<li>ZEG-1: Patient Alias 2 (XPN)</li>
///<li>ZEG-2: Patient Alias 3 (XPN)</li>
///<li>ZEG-3: Advanced Directive (ST)</li>
///<li>ZEG-4: Veteran (ST)</li>
///<li>ZEG-5: Product Line (ST)</li>
///<li>ZEG-6: FSC Reporting Category (CM_FSC)</li>
///<li>ZEG-7: Mode of Arrival (ST)</li>
///<li>ZEG-8: Provider of Record (ST)</li>
///<li>ZEG-9: Scheduleing Appointment Number (NM)</li>
///<li>ZEG-10: Injury Date (DT)</li>
///<li>ZEG-11: Referral External Number (ST)</li>
///<li>ZEG-12: Valid From Date (ST)</li>
///<li>ZEG-13: Valid To Date (ST)</li>
///<li>ZEG-14: Referring Physician UPIN (ST)</li>
///<li>ZEG-15: Authorization Number (ST)</li>
///<li>ZEG-16: Patient Email Address (ST)</li>
///<li>ZEG-17: Attending Physician UPIN (ST)</li>
///<li>ZEG-18: HIPPA Contact Flag (ST)</li>
///<li>ZEG-19: Patient Employer Name (ST)</li>
///<li>ZEG-20: Patient Relationship to Contact 1 (ST)</li>
///<li>ZEG-21: Patient Employer Address (AD)</li>
///<li>ZEG-22: Admitting DX Comment 1 (ST)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class ZEG : AbstractSegment  {

  /**
   * Creates a ZEG (Visit Custom Segment) segment object that belongs to the given 
   * message.  
   */
	public ZEG(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(XPN), false, 1, 200, new System.Object[]{message}, "Patient Alias 2");
       this.add(typeof(XPN), false, 1, 200, new System.Object[]{message}, "Patient Alias 3");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Advanced Directive");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Veteran");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Product Line");
       this.add(typeof(CM_FSC), false, 0, 0, new System.Object[]{message}, "FSC Reporting Category");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Mode of Arrival");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Provider of Record");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Scheduleing Appointment Number");
       this.add(typeof(DT), false, 1, 0, new System.Object[]{message}, "Injury Date");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Referral External Number");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Valid From Date");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Valid To Date");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Referring Physician UPIN");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Authorization Number");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Patient Email Address");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Attending Physician UPIN");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "HIPPA Contact Flag");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Patient Employer Name");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Patient Relationship to Contact 1");
       this.add(typeof(AD), false, 1, 0, new System.Object[]{message}, "Patient Employer Address");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Admitting DX Comment 1");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Patient Alias 2(ZEG-1).
	///</summary>
	public XPN PatientAlias2
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Patient Alias 3(ZEG-2).
	///</summary>
	public XPN PatientAlias3
	{
		get{
			XPN ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Advanced Directive(ZEG-3).
	///</summary>
	public ST AdvancedDirective
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
	/// Returns Veteran(ZEG-4).
	///</summary>
	public ST Veteran
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
	/// Returns Product Line(ZEG-5).
	///</summary>
	public ST ProductLine
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
	/// Returns a single repetition of FSC Reporting Category(ZEG-6).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CM_FSC GetFSCReportingCategory(int rep)
	{
			CM_FSC ret = null;
			try
			{
			IType t = this.GetField(6, rep);
				ret = (CM_FSC)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of FSC Reporting Category (ZEG-6).
   ///</summary>
  public CM_FSC[] GetFSCReportingCategory() {
     CM_FSC[] ret = null;
    try {
        IType[] t = this.GetField(6);  
        ret = new CM_FSC[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CM_FSC)t[i];
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
  /// Returns the total repetitions of FSC Reporting Category (ZEG-6).
   ///</summary>
  public int FSCReportingCategoryRepetitionsUsed
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
	/// Returns Mode of Arrival(ZEG-7).
	///</summary>
	public ST ModeOfArrival
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Provider of Record(ZEG-8).
	///</summary>
	public ST ProviderOfRecord
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
	/// Returns Scheduleing Appointment Number(ZEG-9).
	///</summary>
	public NM ScheduleingAppointmentNumber
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Injury Date(ZEG-10).
	///</summary>
	public DT InjuryDate
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Referral External Number(ZEG-11).
	///</summary>
	public ST ReferralExternalNumber
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
	/// Returns Valid From Date(ZEG-12).
	///</summary>
	public ST ValidFromDate
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
	/// Returns Valid To Date(ZEG-13).
	///</summary>
	public ST ValidToDate
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
	/// Returns Referring Physician UPIN(ZEG-14).
	///</summary>
	public ST ReferringPhysicianUPIN
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Authorization Number(ZEG-15).
	///</summary>
	public ST AuthorizationNumber
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
	/// Returns Patient Email Address(ZEG-16).
	///</summary>
	public ST PatientEmailAddress
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Attending Physician UPIN(ZEG-17).
	///</summary>
	public ST AttendingPhysicianUPIN
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns HIPPA Contact Flag(ZEG-18).
	///</summary>
	public ST HIPPAContactFlag
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Patient Employer Name(ZEG-19).
	///</summary>
	public ST PatientEmployerName
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
	/// Returns Patient Relationship to Contact 1(ZEG-20).
	///</summary>
	public ST PatientRelationshipToContact1
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Patient Employer Address(ZEG-21).
	///</summary>
	public AD PatientEmployerAddress
	{
		get{
			AD ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Admitting DX Comment 1(ZEG-22).
	///</summary>
	public ST AdmittingDXComment1
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


}}