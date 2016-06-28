using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V281.Segment{

///<summary>
/// Represents an HL7 RXO message segment. 
/// This segment has the following fields:<ol>
///<li>RXO-1: Requested Give Code (CWE)</li>
///<li>RXO-2: Requested Give Amount - Minimum (NM)</li>
///<li>RXO-3: Requested Give Amount - Maximum (NM)</li>
///<li>RXO-4: Requested Give Units (CWE)</li>
///<li>RXO-5: Requested Dosage Form (CWE)</li>
///<li>RXO-6: Provider's Pharmacy/Treatment Instructions (CWE)</li>
///<li>RXO-7: Provider's Administration Instructions (CWE)</li>
///<li>RXO-8: Deliver-To Location (-)</li>
///<li>RXO-9: Allow Substitutions (ID)</li>
///<li>RXO-10: Requested Dispense Code (CWE)</li>
///<li>RXO-11: Requested Dispense Amount (NM)</li>
///<li>RXO-12: Requested Dispense Units (CWE)</li>
///<li>RXO-13: Number Of Refills (NM)</li>
///<li>RXO-14: Ordering Provider's DEA Number (XCN)</li>
///<li>RXO-15: Pharmacist/Treatment Supplier's Verifier ID (XCN)</li>
///<li>RXO-16: Needs Human Review (ID)</li>
///<li>RXO-17: Requested Give Per (Time Unit) (ST)</li>
///<li>RXO-18: Requested Give Strength (NM)</li>
///<li>RXO-19: Requested Give Strength Units (CWE)</li>
///<li>RXO-20: Indication (CWE)</li>
///<li>RXO-21: Requested Give Rate Amount (ST)</li>
///<li>RXO-22: Requested Give Rate Units (CWE)</li>
///<li>RXO-23: Total Daily Dose (CQ)</li>
///<li>RXO-24: Supplementary Code (CWE)</li>
///<li>RXO-25: Requested Drug Strength Volume (NM)</li>
///<li>RXO-26: Requested Drug Strength Volume Units (CWE)</li>
///<li>RXO-27: Pharmacy Order Type (ID)</li>
///<li>RXO-28: Dispensing Interval (NM)</li>
///<li>RXO-29: Medication Instance Identifier (EI)</li>
///<li>RXO-30: Segment Instance Identifier (EI)</li>
///<li>RXO-31: Mood Code (CNE)</li>
///<li>RXO-32: Dispensing Pharmacy (CWE)</li>
///<li>RXO-33: Dispensing Pharmacy Address (XAD)</li>
///<li>RXO-34: Deliver-to Patient Location (PL)</li>
///<li>RXO-35: Deliver-to Address (XAD)</li>
///<li>RXO-36: Pharmacy Phone Number (XTN)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class RXO : AbstractSegment  {

  /**
   * Creates a RXO (Pharmacy/Treatment Order) segment object that belongs to the given 
   * message.  
   */
	public RXO(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Requested Give Code");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Requested Give Amount - Minimum");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Requested Give Amount - Maximum");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Requested Give Units");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Requested Dosage Form");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Provider's Pharmacy/Treatment Instructions");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Provider's Administration Instructions");
       this.add(typeof(-), false, 1, 0, new System.Object[]{message}, "Deliver-To Location");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 161}, "Allow Substitutions");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Requested Dispense Code");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Requested Dispense Amount");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Requested Dispense Units");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Number Of Refills");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Ordering Provider's DEA Number");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Pharmacist/Treatment Supplier's Verifier ID");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Needs Human Review");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Requested Give Per (Time Unit)");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Requested Give Strength");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Requested Give Strength Units");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Indication");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Requested Give Rate Amount");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Requested Give Rate Units");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Total Daily Dose");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Supplementary Code");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Requested Drug Strength Volume");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Requested Drug Strength Volume Units");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 480}, "Pharmacy Order Type");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Dispensing Interval");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Medication Instance Identifier");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Segment Instance Identifier");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Mood Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Dispensing Pharmacy");
       this.add(typeof(XAD), false, 1, 0, new System.Object[]{message}, "Dispensing Pharmacy Address");
       this.add(typeof(PL), false, 1, 0, new System.Object[]{message}, "Deliver-to Patient Location");
       this.add(typeof(XAD), false, 1, 0, new System.Object[]{message}, "Deliver-to Address");
       this.add(typeof(XTN), false, 0, 0, new System.Object[]{message}, "Pharmacy Phone Number");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Requested Give Code(RXO-1).
	///</summary>
	public CWE RequestedGiveCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Requested Give Amount - Minimum(RXO-2).
	///</summary>
	public NM RequestedGiveAmountMinimum
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Requested Give Amount - Maximum(RXO-3).
	///</summary>
	public NM RequestedGiveAmountMaximum
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Requested Give Units(RXO-4).
	///</summary>
	public CWE RequestedGiveUnits
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
	/// Returns Requested Dosage Form(RXO-5).
	///</summary>
	public CWE RequestedDosageForm
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns a single repetition of Provider's Pharmacy/Treatment Instructions(RXO-6).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetProviderSPharmacyTreatmentInstructions(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(6, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Provider's Pharmacy/Treatment Instructions (RXO-6).
   ///</summary>
  public CWE[] GetProviderSPharmacyTreatmentInstructions() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(6);  
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
  /// Returns the total repetitions of Provider's Pharmacy/Treatment Instructions (RXO-6).
   ///</summary>
  public int ProviderSPharmacyTreatmentInstructionsRepetitionsUsed
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
	/// Returns a single repetition of Provider's Administration Instructions(RXO-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetProviderSAdministrationInstructions(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Provider's Administration Instructions (RXO-7).
   ///</summary>
  public CWE[] GetProviderSAdministrationInstructions() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(7);  
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
  /// Returns the total repetitions of Provider's Administration Instructions (RXO-7).
   ///</summary>
  public int ProviderSAdministrationInstructionsRepetitionsUsed
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
	/// Returns Deliver-To Location(RXO-8).
	///</summary>
	public - DeliverToLocation
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
	/// Returns Allow Substitutions(RXO-9).
	///</summary>
	public ID AllowSubstitutions
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
	/// Returns Requested Dispense Code(RXO-10).
	///</summary>
	public CWE RequestedDispenseCode
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
	/// Returns Requested Dispense Amount(RXO-11).
	///</summary>
	public NM RequestedDispenseAmount
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Requested Dispense Units(RXO-12).
	///</summary>
	public CWE RequestedDispenseUnits
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Number Of Refills(RXO-13).
	///</summary>
	public NM NumberOfRefills
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns a single repetition of Ordering Provider's DEA Number(RXO-14).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetOrderingProviderSDEANumber(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(14, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Ordering Provider's DEA Number (RXO-14).
   ///</summary>
  public XCN[] GetOrderingProviderSDEANumber() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(14);  
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
  /// Returns the total repetitions of Ordering Provider's DEA Number (RXO-14).
   ///</summary>
  public int OrderingProviderSDEANumberRepetitionsUsed
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
	/// Returns a single repetition of Pharmacist/Treatment Supplier's Verifier ID(RXO-15).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetPharmacistTreatmentSupplierSVerifierID(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(15, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Pharmacist/Treatment Supplier's Verifier ID (RXO-15).
   ///</summary>
  public XCN[] GetPharmacistTreatmentSupplierSVerifierID() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(15);  
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
  /// Returns the total repetitions of Pharmacist/Treatment Supplier's Verifier ID (RXO-15).
   ///</summary>
  public int PharmacistTreatmentSupplierSVerifierIDRepetitionsUsed
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
	/// Returns Needs Human Review(RXO-16).
	///</summary>
	public ID NeedsHumanReview
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
	/// Returns Requested Give Per (Time Unit)(RXO-17).
	///</summary>
	public ST RequestedGivePerTimeUnit
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
	/// Returns Requested Give Strength(RXO-18).
	///</summary>
	public NM RequestedGiveStrength
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Requested Give Strength Units(RXO-19).
	///</summary>
	public CWE RequestedGiveStrengthUnits
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns a single repetition of Indication(RXO-20).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetIndication(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(20, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Indication (RXO-20).
   ///</summary>
  public CWE[] GetIndication() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(20);  
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
  /// Returns the total repetitions of Indication (RXO-20).
   ///</summary>
  public int IndicationRepetitionsUsed
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
	/// Returns Requested Give Rate Amount(RXO-21).
	///</summary>
	public ST RequestedGiveRateAmount
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Requested Give Rate Units(RXO-22).
	///</summary>
	public CWE RequestedGiveRateUnits
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Total Daily Dose(RXO-23).
	///</summary>
	public CQ TotalDailyDose
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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

	///<summary>
	/// Returns a single repetition of Supplementary Code(RXO-24).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetSupplementaryCode(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(24, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Supplementary Code (RXO-24).
   ///</summary>
  public CWE[] GetSupplementaryCode() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(24);  
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
  /// Returns the total repetitions of Supplementary Code (RXO-24).
   ///</summary>
  public int SupplementaryCodeRepetitionsUsed
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
	/// Returns Requested Drug Strength Volume(RXO-25).
	///</summary>
	public NM RequestedDrugStrengthVolume
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
	/// Returns Requested Drug Strength Volume Units(RXO-26).
	///</summary>
	public CWE RequestedDrugStrengthVolumeUnits
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(26, 0);
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
	/// Returns Pharmacy Order Type(RXO-27).
	///</summary>
	public ID PharmacyOrderType
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
	/// Returns Dispensing Interval(RXO-28).
	///</summary>
	public NM DispensingInterval
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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
	/// Returns Medication Instance Identifier(RXO-29).
	///</summary>
	public EI MedicationInstanceIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(29, 0);
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
	/// Returns Segment Instance Identifier(RXO-30).
	///</summary>
	public EI SegmentInstanceIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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
	/// Returns Mood Code(RXO-31).
	///</summary>
	public CNE MoodCode
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(31, 0);
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
	/// Returns Dispensing Pharmacy(RXO-32).
	///</summary>
	public CWE DispensingPharmacy
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
	/// Returns Dispensing Pharmacy Address(RXO-33).
	///</summary>
	public XAD DispensingPharmacyAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(33, 0);
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
	/// Returns Deliver-to Patient Location(RXO-34).
	///</summary>
	public PL DeliverToPatientLocation
	{
		get{
			PL ret = null;
			try
			{
			IType t = this.GetField(34, 0);
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
	/// Returns Deliver-to Address(RXO-35).
	///</summary>
	public XAD DeliverToAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(35, 0);
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
	/// Returns a single repetition of Pharmacy Phone Number(RXO-36).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XTN GetPharmacyPhoneNumber(int rep)
	{
			XTN ret = null;
			try
			{
			IType t = this.GetField(36, rep);
				ret = (XTN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Pharmacy Phone Number (RXO-36).
   ///</summary>
  public XTN[] GetPharmacyPhoneNumber() {
     XTN[] ret = null;
    try {
        IType[] t = this.GetField(36);  
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
  /// Returns the total repetitions of Pharmacy Phone Number (RXO-36).
   ///</summary>
  public int PharmacyPhoneNumberRepetitionsUsed
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

}}