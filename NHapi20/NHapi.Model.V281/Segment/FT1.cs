using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V281.Segment{

///<summary>
/// Represents an HL7 FT1 message segment. 
/// This segment has the following fields:<ol>
///<li>FT1-1: Set ID - FT1 (SI)</li>
///<li>FT1-2: Transaction ID (ST)</li>
///<li>FT1-3: Transaction Batch ID (ST)</li>
///<li>FT1-4: Transaction Date (DR)</li>
///<li>FT1-5: Transaction Posting Date (DTM)</li>
///<li>FT1-6: Transaction Type (CWE)</li>
///<li>FT1-7: Transaction Code (CWE)</li>
///<li>FT1-8: Transaction Description (-)</li>
///<li>FT1-9: Transaction Description - Alt (-)</li>
///<li>FT1-10: Transaction Quantity (NM)</li>
///<li>FT1-11: Transaction Amount - Extended (CP)</li>
///<li>FT1-12: Transaction amount - unit (CP)</li>
///<li>FT1-13: Department Code (CWE)</li>
///<li>FT1-14: Health Plan ID (CWE)</li>
///<li>FT1-15: Insurance Amount (CP)</li>
///<li>FT1-16: Assigned Patient Location (PL)</li>
///<li>FT1-17: Fee Schedule (CWE)</li>
///<li>FT1-18: Patient Type (CWE)</li>
///<li>FT1-19: Diagnosis Code - FT1 (CWE)</li>
///<li>FT1-20: Performed By Code (XCN)</li>
///<li>FT1-21: Ordered By Code (XCN)</li>
///<li>FT1-22: Unit Cost (CP)</li>
///<li>FT1-23: Filler Order Number (EI)</li>
///<li>FT1-24: Entered By Code (XCN)</li>
///<li>FT1-25: Procedure Code (CNE)</li>
///<li>FT1-26: Procedure Code Modifier (CNE)</li>
///<li>FT1-27: Advanced Beneficiary Notice Code (CWE)</li>
///<li>FT1-28: Medically Necessary Duplicate Procedure Reason (CWE)</li>
///<li>FT1-29: NDC Code (CWE)</li>
///<li>FT1-30: Payment Reference ID (CX)</li>
///<li>FT1-31: Transaction Reference Key (SI)</li>
///<li>FT1-32: Performing Facility (XON)</li>
///<li>FT1-33: Ordering Facility (XON)</li>
///<li>FT1-34: Item Number (CWE)</li>
///<li>FT1-35: Model Number (ST)</li>
///<li>FT1-36: Special Processing Code (CWE)</li>
///<li>FT1-37: Clinic Code (CWE)</li>
///<li>FT1-38: Referral Number (CX)</li>
///<li>FT1-39: Authorization Number (CX)</li>
///<li>FT1-40: Service Provider Taxonomy Code (CWE)</li>
///<li>FT1-41: Revenue Code (CWE)</li>
///<li>FT1-42: Prescription Number (ST)</li>
///<li>FT1-43: NDC Qty and UOM (CQ)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class FT1 : AbstractSegment  {

  /**
   * Creates a FT1 (Financial Transaction) segment object that belongs to the given 
   * message.  
   */
	public FT1(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), false, 1, 4, new System.Object[]{message}, "Set ID - FT1");
       this.add(typeof(ST), false, 1, 12, new System.Object[]{message}, "Transaction ID");
       this.add(typeof(ST), false, 1, 10, new System.Object[]{message}, "Transaction Batch ID");
       this.add(typeof(DR), true, 1, 0, new System.Object[]{message}, "Transaction Date");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Transaction Posting Date");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Transaction Type");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Transaction Code");
       this.add(typeof(-), false, 1, 0, new System.Object[]{message}, "Transaction Description");
       this.add(typeof(-), false, 1, 0, new System.Object[]{message}, "Transaction Description - Alt");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Transaction Quantity");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Transaction Amount - Extended");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Transaction amount - unit");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Department Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Health Plan ID");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Insurance Amount");
       this.add(typeof(PL), false, 1, 0, new System.Object[]{message}, "Assigned Patient Location");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Fee Schedule");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Patient Type");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Diagnosis Code - FT1");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Performed By Code");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Ordered By Code");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Unit Cost");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Filler Order Number");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Entered By Code");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Procedure Code");
       this.add(typeof(CNE), false, 0, 0, new System.Object[]{message}, "Procedure Code Modifier");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Advanced Beneficiary Notice Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Medically Necessary Duplicate Procedure Reason");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "NDC Code");
       this.add(typeof(CX), false, 1, 0, new System.Object[]{message}, "Payment Reference ID");
       this.add(typeof(SI), false, 0, 4, new System.Object[]{message}, "Transaction Reference Key");
       this.add(typeof(XON), false, 0, 0, new System.Object[]{message}, "Performing Facility");
       this.add(typeof(XON), false, 1, 0, new System.Object[]{message}, "Ordering Facility");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Item Number");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Model Number");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Special Processing Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Clinic Code");
       this.add(typeof(CX), false, 1, 0, new System.Object[]{message}, "Referral Number");
       this.add(typeof(CX), false, 1, 0, new System.Object[]{message}, "Authorization Number");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Service Provider Taxonomy Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Revenue Code");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Prescription Number");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "NDC Qty and UOM");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - FT1(FT1-1).
	///</summary>
	public SI SetIDFT1
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
	/// Returns Transaction ID(FT1-2).
	///</summary>
	public ST TransactionID
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
	/// Returns Transaction Batch ID(FT1-3).
	///</summary>
	public ST TransactionBatchID
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
	/// Returns Transaction Date(FT1-4).
	///</summary>
	public DR TransactionDate
	{
		get{
			DR ret = null;
			try
			{
			IType t = this.GetField(4, 0);
				ret = (DR)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Transaction Posting Date(FT1-5).
	///</summary>
	public DTM TransactionPostingDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Transaction Type(FT1-6).
	///</summary>
	public CWE TransactionType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Transaction Code(FT1-7).
	///</summary>
	public CWE TransactionCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Transaction Description(FT1-8).
	///</summary>
	public - TransactionDescription
	{
		get{
			- ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (-)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Transaction Description - Alt(FT1-9).
	///</summary>
	public - TransactionDescriptionAlt
	{
		get{
			- ret = null;
			try
			{
			IType t = this.GetField(9, 0);
				ret = (-)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Transaction Quantity(FT1-10).
	///</summary>
	public NM TransactionQuantity
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Transaction Amount - Extended(FT1-11).
	///</summary>
	public CP TransactionAmountExtended
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Transaction amount - unit(FT1-12).
	///</summary>
	public CP TransactionAmountUnit
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Department Code(FT1-13).
	///</summary>
	public CWE DepartmentCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Health Plan ID(FT1-14).
	///</summary>
	public CWE HealthPlanID
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Insurance Amount(FT1-15).
	///</summary>
	public CP InsuranceAmount
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Assigned Patient Location(FT1-16).
	///</summary>
	public PL AssignedPatientLocation
	{
		get{
			PL ret = null;
			try
			{
			IType t = this.GetField(16, 0);
				ret = (PL)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Fee Schedule(FT1-17).
	///</summary>
	public CWE FeeSchedule
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
	/// Returns Patient Type(FT1-18).
	///</summary>
	public CWE PatientType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns a single repetition of Diagnosis Code - FT1(FT1-19).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetDiagnosisCodeFT1(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(19, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Diagnosis Code - FT1 (FT1-19).
   ///</summary>
  public CWE[] GetDiagnosisCodeFT1() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(19);  
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
  /// Returns the total repetitions of Diagnosis Code - FT1 (FT1-19).
   ///</summary>
  public int DiagnosisCodeFT1RepetitionsUsed
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
	/// Returns a single repetition of Performed By Code(FT1-20).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetPerformedByCode(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(20, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Performed By Code (FT1-20).
   ///</summary>
  public XCN[] GetPerformedByCode() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(20);  
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
  /// Returns the total repetitions of Performed By Code (FT1-20).
   ///</summary>
  public int PerformedByCodeRepetitionsUsed
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
	/// Returns a single repetition of Ordered By Code(FT1-21).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetOrderedByCode(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(21, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Ordered By Code (FT1-21).
   ///</summary>
  public XCN[] GetOrderedByCode() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(21);  
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
  /// Returns the total repetitions of Ordered By Code (FT1-21).
   ///</summary>
  public int OrderedByCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(21);
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
	/// Returns Unit Cost(FT1-22).
	///</summary>
	public CP UnitCost
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Filler Order Number(FT1-23).
	///</summary>
	public EI FillerOrderNumber
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns a single repetition of Entered By Code(FT1-24).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetEnteredByCode(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(24, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Entered By Code (FT1-24).
   ///</summary>
  public XCN[] GetEnteredByCode() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(24);  
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
  /// Returns the total repetitions of Entered By Code (FT1-24).
   ///</summary>
  public int EnteredByCodeRepetitionsUsed
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
	/// Returns Procedure Code(FT1-25).
	///</summary>
	public CNE ProcedureCode
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns a single repetition of Procedure Code Modifier(FT1-26).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CNE GetProcedureCodeModifier(int rep)
	{
			CNE ret = null;
			try
			{
			IType t = this.GetField(26, rep);
				ret = (CNE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Procedure Code Modifier (FT1-26).
   ///</summary>
  public CNE[] GetProcedureCodeModifier() {
     CNE[] ret = null;
    try {
        IType[] t = this.GetField(26);  
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
  /// Returns the total repetitions of Procedure Code Modifier (FT1-26).
   ///</summary>
  public int ProcedureCodeModifierRepetitionsUsed
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
	/// Returns Advanced Beneficiary Notice Code(FT1-27).
	///</summary>
	public CWE AdvancedBeneficiaryNoticeCode
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
	/// Returns Medically Necessary Duplicate Procedure Reason(FT1-28).
	///</summary>
	public CWE MedicallyNecessaryDuplicateProcedureReason
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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
	/// Returns NDC Code(FT1-29).
	///</summary>
	public CWE NDCCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(29, 0);
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
	/// Returns Payment Reference ID(FT1-30).
	///</summary>
	public CX PaymentReferenceID
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(30, 0);
				ret = (CX)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns a single repetition of Transaction Reference Key(FT1-31).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public SI GetTransactionReferenceKey(int rep)
	{
			SI ret = null;
			try
			{
			IType t = this.GetField(31, rep);
				ret = (SI)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Transaction Reference Key (FT1-31).
   ///</summary>
  public SI[] GetTransactionReferenceKey() {
     SI[] ret = null;
    try {
        IType[] t = this.GetField(31);  
        ret = new SI[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (SI)t[i];
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
  /// Returns the total repetitions of Transaction Reference Key (FT1-31).
   ///</summary>
  public int TransactionReferenceKeyRepetitionsUsed
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
	/// Returns a single repetition of Performing Facility(FT1-32).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XON GetPerformingFacility(int rep)
	{
			XON ret = null;
			try
			{
			IType t = this.GetField(32, rep);
				ret = (XON)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Performing Facility (FT1-32).
   ///</summary>
  public XON[] GetPerformingFacility() {
     XON[] ret = null;
    try {
        IType[] t = this.GetField(32);  
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
  /// Returns the total repetitions of Performing Facility (FT1-32).
   ///</summary>
  public int PerformingFacilityRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(32);
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
	/// Returns Ordering Facility(FT1-33).
	///</summary>
	public XON OrderingFacility
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(33, 0);
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
	/// Returns Item Number(FT1-34).
	///</summary>
	public CWE ItemNumber
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(34, 0);
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
	/// Returns Model Number(FT1-35).
	///</summary>
	public ST ModelNumber
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(35, 0);
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
	/// Returns a single repetition of Special Processing Code(FT1-36).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetSpecialProcessingCode(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(36, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Special Processing Code (FT1-36).
   ///</summary>
  public CWE[] GetSpecialProcessingCode() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(36);  
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
  /// Returns the total repetitions of Special Processing Code (FT1-36).
   ///</summary>
  public int SpecialProcessingCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(36);
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
	/// Returns Clinic Code(FT1-37).
	///</summary>
	public CWE ClinicCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(37, 0);
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
	/// Returns Referral Number(FT1-38).
	///</summary>
	public CX ReferralNumber
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(38, 0);
				ret = (CX)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Authorization Number(FT1-39).
	///</summary>
	public CX AuthorizationNumber
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(39, 0);
				ret = (CX)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Service Provider Taxonomy Code(FT1-40).
	///</summary>
	public CWE ServiceProviderTaxonomyCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(40, 0);
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
	/// Returns Revenue Code(FT1-41).
	///</summary>
	public CWE RevenueCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(41, 0);
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
	/// Returns Prescription Number(FT1-42).
	///</summary>
	public ST PrescriptionNumber
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(42, 0);
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
	/// Returns NDC Qty and UOM(FT1-43).
	///</summary>
	public CQ NDCQtyAndUOM
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(43, 0);
				ret = (CQ)t;
			}
			 catch (HL7Exception he) {
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