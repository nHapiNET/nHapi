using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V27.Segment{

///<summary>
/// Represents an HL7 RXE message segment. 
/// This segment has the following fields:<ol>
///<li>RXE-1: Quantity/Timing (-)</li>
///<li>RXE-2: Give Code (CWE)</li>
///<li>RXE-3: Give Amount - Minimum (NM)</li>
///<li>RXE-4: Give Amount - Maximum (NM)</li>
///<li>RXE-5: Give Units (CWE)</li>
///<li>RXE-6: Give Dosage Form (CWE)</li>
///<li>RXE-7: Provider's Administration Instructions (CWE)</li>
///<li>RXE-8: Deliver-to Location (LA1)</li>
///<li>RXE-9: Substitution Status (ID)</li>
///<li>RXE-10: Dispense Amount (NM)</li>
///<li>RXE-11: Dispense Units (CWE)</li>
///<li>RXE-12: Number Of Refills (NM)</li>
///<li>RXE-13: Ordering Provider's DEA Number (XCN)</li>
///<li>RXE-14: Pharmacist/Treatment Supplier's Verifier ID (XCN)</li>
///<li>RXE-15: Prescription Number (ST)</li>
///<li>RXE-16: Number of Refills Remaining (NM)</li>
///<li>RXE-17: Number of Refills/Doses Dispensed (NM)</li>
///<li>RXE-18: D/T of Most Recent Refill or Dose Dispensed (DTM)</li>
///<li>RXE-19: Total Daily Dose (CQ)</li>
///<li>RXE-20: Needs Human Review (ID)</li>
///<li>RXE-21: Pharmacy/Treatment Supplier's Special Dispensing Instructions (CWE)</li>
///<li>RXE-22: Give Per (Time Unit) (ST)</li>
///<li>RXE-23: Give Rate Amount (ST)</li>
///<li>RXE-24: Give Rate Units (CWE)</li>
///<li>RXE-25: Give Strength (NM)</li>
///<li>RXE-26: Give Strength Units (CWE)</li>
///<li>RXE-27: Give Indication (CWE)</li>
///<li>RXE-28: Dispense Package Size (NM)</li>
///<li>RXE-29: Dispense Package Size Unit (CWE)</li>
///<li>RXE-30: Dispense Package Method (ID)</li>
///<li>RXE-31: Supplementary Code (CWE)</li>
///<li>RXE-32: Original Order Date/Time (DTM)</li>
///<li>RXE-33: Give Drug Strength Volume (NM)</li>
///<li>RXE-34: Give Drug Strength Volume Units (CWE)</li>
///<li>RXE-35: Controlled Substance Schedule (CWE)</li>
///<li>RXE-36: Formulary Status (ID)</li>
///<li>RXE-37: Pharmaceutical Substance Alternative (CWE)</li>
///<li>RXE-38: Pharmacy of Most Recent Fill (CWE)</li>
///<li>RXE-39: Initial Dispense Amount (NM)</li>
///<li>RXE-40: Dispensing Pharmacy (CWE)</li>
///<li>RXE-41: Dispensing Pharmacy Address (XAD)</li>
///<li>RXE-42: Deliver-to Patient Location (PL)</li>
///<li>RXE-43: Deliver-to Address (XAD)</li>
///<li>RXE-44: Pharmacy Order Type (ID)</li>
///<li>RXE-45: Pharmacy Phone Number (XTN)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class RXE : AbstractSegment  {

  /**
   * Creates a RXE (Pharmacy/Treatment Encoded Order) segment object that belongs to the given 
   * message.  
   */
	public RXE(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(-), false, 1, 0, new System.Object[]{message}, "Quantity/Timing");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Give Code");
       this.add(typeof(NM), true, 1, 0, new System.Object[]{message}, "Give Amount - Minimum");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Give Amount - Maximum");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Give Units");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Give Dosage Form");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Provider's Administration Instructions");
       this.add(typeof(LA1), false, 1, 0, new System.Object[]{message}, "Deliver-to Location");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 167}, "Substitution Status");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Dispense Amount");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Dispense Units");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Number Of Refills");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Ordering Provider's DEA Number");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Pharmacist/Treatment Supplier's Verifier ID");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Prescription Number");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Number of Refills Remaining");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Number of Refills/Doses Dispensed");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "D/T of Most Recent Refill or Dose Dispensed");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Total Daily Dose");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Needs Human Review");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Pharmacy/Treatment Supplier's Special Dispensing Instructions");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Give Per (Time Unit)");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Give Rate Amount");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Give Rate Units");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Give Strength");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Give Strength Units");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Give Indication");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Dispense Package Size");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Dispense Package Size Unit");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 321}, "Dispense Package Method");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Supplementary Code");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Original Order Date/Time");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Give Drug Strength Volume");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Give Drug Strength Volume Units");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Controlled Substance Schedule");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 478}, "Formulary Status");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Pharmaceutical Substance Alternative");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Pharmacy of Most Recent Fill");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Initial Dispense Amount");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Dispensing Pharmacy");
       this.add(typeof(XAD), false, 1, 0, new System.Object[]{message}, "Dispensing Pharmacy Address");
       this.add(typeof(PL), false, 1, 0, new System.Object[]{message}, "Deliver-to Patient Location");
       this.add(typeof(XAD), false, 1, 0, new System.Object[]{message}, "Deliver-to Address");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 480}, "Pharmacy Order Type");
       this.add(typeof(XTN), false, 0, 0, new System.Object[]{message}, "Pharmacy Phone Number");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Quantity/Timing(RXE-1).
	///</summary>
	public - QuantityTiming
	{
		get{
			- ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Give Code(RXE-2).
	///</summary>
	public CWE GiveCode
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
	/// Returns Give Amount - Minimum(RXE-3).
	///</summary>
	public NM GiveAmountMinimum
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
	/// Returns Give Amount - Maximum(RXE-4).
	///</summary>
	public NM GiveAmountMaximum
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Give Units(RXE-5).
	///</summary>
	public CWE GiveUnits
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
	/// Returns Give Dosage Form(RXE-6).
	///</summary>
	public CWE GiveDosageForm
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
	/// Returns a single repetition of Provider's Administration Instructions(RXE-7).
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
  /// Returns all repetitions of Provider's Administration Instructions (RXE-7).
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
  /// Returns the total repetitions of Provider's Administration Instructions (RXE-7).
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
	/// Returns Deliver-to Location(RXE-8).
	///</summary>
	public LA1 DeliverToLocation
	{
		get{
			LA1 ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (LA1)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Substitution Status(RXE-9).
	///</summary>
	public ID SubstitutionStatus
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
	/// Returns Dispense Amount(RXE-10).
	///</summary>
	public NM DispenseAmount
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
	/// Returns Dispense Units(RXE-11).
	///</summary>
	public CWE DispenseUnits
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
	/// Returns Number Of Refills(RXE-12).
	///</summary>
	public NM NumberOfRefills
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns a single repetition of Ordering Provider's DEA Number(RXE-13).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetOrderingProviderSDEANumber(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(13, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Ordering Provider's DEA Number (RXE-13).
   ///</summary>
  public XCN[] GetOrderingProviderSDEANumber() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(13);  
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
  /// Returns the total repetitions of Ordering Provider's DEA Number (RXE-13).
   ///</summary>
  public int OrderingProviderSDEANumberRepetitionsUsed
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
	/// Returns a single repetition of Pharmacist/Treatment Supplier's Verifier ID(RXE-14).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetPharmacistTreatmentSupplierSVerifierID(int rep)
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
  /// Returns all repetitions of Pharmacist/Treatment Supplier's Verifier ID (RXE-14).
   ///</summary>
  public XCN[] GetPharmacistTreatmentSupplierSVerifierID() {
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
  /// Returns the total repetitions of Pharmacist/Treatment Supplier's Verifier ID (RXE-14).
   ///</summary>
  public int PharmacistTreatmentSupplierSVerifierIDRepetitionsUsed
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
	/// Returns Prescription Number(RXE-15).
	///</summary>
	public ST PrescriptionNumber
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
	/// Returns Number of Refills Remaining(RXE-16).
	///</summary>
	public NM NumberOfRefillsRemaining
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Number of Refills/Doses Dispensed(RXE-17).
	///</summary>
	public NM NumberOfRefillsDosesDispensed
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns D/T of Most Recent Refill or Dose Dispensed(RXE-18).
	///</summary>
	public DTM DTOfMostRecentRefillOrDoseDispensed
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Total Daily Dose(RXE-19).
	///</summary>
	public CQ TotalDailyDose
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Needs Human Review(RXE-20).
	///</summary>
	public ID NeedsHumanReview
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns a single repetition of Pharmacy/Treatment Supplier's Special Dispensing Instructions(RXE-21).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetPharmacyTreatmentSupplierSSpecialDispensingInstructions(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(21, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Pharmacy/Treatment Supplier's Special Dispensing Instructions (RXE-21).
   ///</summary>
  public CWE[] GetPharmacyTreatmentSupplierSSpecialDispensingInstructions() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(21);  
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
  /// Returns the total repetitions of Pharmacy/Treatment Supplier's Special Dispensing Instructions (RXE-21).
   ///</summary>
  public int PharmacyTreatmentSupplierSSpecialDispensingInstructionsRepetitionsUsed
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
	/// Returns Give Per (Time Unit)(RXE-22).
	///</summary>
	public ST GivePerTimeUnit
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

	///<summary>
	/// Returns Give Rate Amount(RXE-23).
	///</summary>
	public ST GiveRateAmount
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
	/// Returns Give Rate Units(RXE-24).
	///</summary>
	public CWE GiveRateUnits
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Give Strength(RXE-25).
	///</summary>
	public NM GiveStrength
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
	/// Returns Give Strength Units(RXE-26).
	///</summary>
	public CWE GiveStrengthUnits
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
	/// Returns a single repetition of Give Indication(RXE-27).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetGiveIndication(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(27, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Give Indication (RXE-27).
   ///</summary>
  public CWE[] GetGiveIndication() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(27);  
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
  /// Returns the total repetitions of Give Indication (RXE-27).
   ///</summary>
  public int GiveIndicationRepetitionsUsed
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
	/// Returns Dispense Package Size(RXE-28).
	///</summary>
	public NM DispensePackageSize
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
	/// Returns Dispense Package Size Unit(RXE-29).
	///</summary>
	public CWE DispensePackageSizeUnit
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
	/// Returns Dispense Package Method(RXE-30).
	///</summary>
	public ID DispensePackageMethod
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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
	/// Returns a single repetition of Supplementary Code(RXE-31).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetSupplementaryCode(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(31, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Supplementary Code (RXE-31).
   ///</summary>
  public CWE[] GetSupplementaryCode() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(31);  
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
  /// Returns the total repetitions of Supplementary Code (RXE-31).
   ///</summary>
  public int SupplementaryCodeRepetitionsUsed
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
	/// Returns Original Order Date/Time(RXE-32).
	///</summary>
	public DTM OriginalOrderDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(32, 0);
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
	/// Returns Give Drug Strength Volume(RXE-33).
	///</summary>
	public NM GiveDrugStrengthVolume
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
	/// Returns Give Drug Strength Volume Units(RXE-34).
	///</summary>
	public CWE GiveDrugStrengthVolumeUnits
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
	/// Returns Controlled Substance Schedule(RXE-35).
	///</summary>
	public CWE ControlledSubstanceSchedule
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(35, 0);
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
	/// Returns Formulary Status(RXE-36).
	///</summary>
	public ID FormularyStatus
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
	/// Returns a single repetition of Pharmaceutical Substance Alternative(RXE-37).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetPharmaceuticalSubstanceAlternative(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(37, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Pharmaceutical Substance Alternative (RXE-37).
   ///</summary>
  public CWE[] GetPharmaceuticalSubstanceAlternative() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(37);  
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
  /// Returns the total repetitions of Pharmaceutical Substance Alternative (RXE-37).
   ///</summary>
  public int PharmaceuticalSubstanceAlternativeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(37);
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
	/// Returns Pharmacy of Most Recent Fill(RXE-38).
	///</summary>
	public CWE PharmacyOfMostRecentFill
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(38, 0);
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
	/// Returns Initial Dispense Amount(RXE-39).
	///</summary>
	public NM InitialDispenseAmount
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(39, 0);
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
	/// Returns Dispensing Pharmacy(RXE-40).
	///</summary>
	public CWE DispensingPharmacy
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
	/// Returns Dispensing Pharmacy Address(RXE-41).
	///</summary>
	public XAD DispensingPharmacyAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(41, 0);
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
	/// Returns Deliver-to Patient Location(RXE-42).
	///</summary>
	public PL DeliverToPatientLocation
	{
		get{
			PL ret = null;
			try
			{
			IType t = this.GetField(42, 0);
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
	/// Returns Deliver-to Address(RXE-43).
	///</summary>
	public XAD DeliverToAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(43, 0);
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
	/// Returns Pharmacy Order Type(RXE-44).
	///</summary>
	public ID PharmacyOrderType
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(44, 0);
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
	/// Returns a single repetition of Pharmacy Phone Number(RXE-45).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XTN GetPharmacyPhoneNumber(int rep)
	{
			XTN ret = null;
			try
			{
			IType t = this.GetField(45, rep);
				ret = (XTN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Pharmacy Phone Number (RXE-45).
   ///</summary>
  public XTN[] GetPharmacyPhoneNumber() {
     XTN[] ret = null;
    try {
        IType[] t = this.GetField(45);  
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
  /// Returns the total repetitions of Pharmacy Phone Number (RXE-45).
   ///</summary>
  public int PharmacyPhoneNumberRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(45);
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