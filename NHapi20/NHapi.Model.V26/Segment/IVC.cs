using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V26.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V26.Segment{

///<summary>
/// Represents an HL7 IVC message segment. 
/// This segment has the following fields:<ol>
///<li>IVC-1: Provider Invoice Number (EI)</li>
///<li>IVC-2: Payer Invoice Number (EI)</li>
///<li>IVC-3: Contract/Agreement Number (EI)</li>
///<li>IVC-4: Invoice Control (IS)</li>
///<li>IVC-5: Invoice Reason (IS)</li>
///<li>IVC-6: Invoice Type (IS)</li>
///<li>IVC-7: Invoice Date/Time (DTM)</li>
///<li>IVC-8: Invoice Amount (CP)</li>
///<li>IVC-9: Payment Terms (ST)</li>
///<li>IVC-10: Provider Organization (XON)</li>
///<li>IVC-11: Payer Organization (XON)</li>
///<li>IVC-12: Attention (XCN)</li>
///<li>IVC-13: Last Invoice Indicator (ID)</li>
///<li>IVC-14: Invoice Booking Period (DTM)</li>
///<li>IVC-15: Origin (ST)</li>
///<li>IVC-16: Invoice Fixed Amount (CP)</li>
///<li>IVC-17: Special Costs (CP)</li>
///<li>IVC-18: Amount for Doctors Treatment (CP)</li>
///<li>IVC-19: Responsible Physician (XCN)</li>
///<li>IVC-20: Cost Center (CX)</li>
///<li>IVC-21: Invoice Prepaid Amount (CP)</li>
///<li>IVC-22: Total Invoice Amount without Prepaid Amount (CP)</li>
///<li>IVC-23: Total-Amount of VAT (CP)</li>
///<li>IVC-24: VAT-Rates applied (NM)</li>
///<li>IVC-25: Benefit Group (IS)</li>
///<li>IVC-26: Provider Tax ID (ST)</li>
///<li>IVC-27: Payer Tax ID (ST)</li>
///<li>IVC-28: Provider Tax status (IS)</li>
///<li>IVC-29: Payer Tax status (IS)</li>
///<li>IVC-30: Sales Tax ID (ST)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class IVC : AbstractSegment  {

  /**
   * Creates a IVC (Invoice Segment) segment object that belongs to the given 
   * message.  
   */
	public IVC(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(EI), true, 1, 74, new System.Object[]{message}, "Provider Invoice Number");
       this.add(typeof(EI), false, 1, 74, new System.Object[]{message}, "Payer Invoice Number");
       this.add(typeof(EI), false, 1, 74, new System.Object[]{message}, "Contract/Agreement Number");
       this.add(typeof(IS), true, 1, 2, new System.Object[]{message, 553}, "Invoice Control");
       this.add(typeof(IS), true, 1, 4, new System.Object[]{message, 554}, "Invoice Reason");
       this.add(typeof(IS), true, 1, 2, new System.Object[]{message, 555}, "Invoice Type");
       this.add(typeof(DTM), true, 1, 24, new System.Object[]{message}, "Invoice Date/Time");
       this.add(typeof(CP), true, 1, 254, new System.Object[]{message}, "Invoice Amount");
       this.add(typeof(ST), false, 1, 80, new System.Object[]{message}, "Payment Terms");
       this.add(typeof(XON), true, 1, 183, new System.Object[]{message}, "Provider Organization");
       this.add(typeof(XON), true, 1, 183, new System.Object[]{message}, "Payer Organization");
       this.add(typeof(XCN), false, 1, 637, new System.Object[]{message}, "Attention");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Last Invoice Indicator");
       this.add(typeof(DTM), false, 1, 24, new System.Object[]{message}, "Invoice Booking Period");
       this.add(typeof(ST), false, 1, 250, new System.Object[]{message}, "Origin");
       this.add(typeof(CP), false, 1, 254, new System.Object[]{message}, "Invoice Fixed Amount");
       this.add(typeof(CP), false, 1, 254, new System.Object[]{message}, "Special Costs");
       this.add(typeof(CP), false, 1, 254, new System.Object[]{message}, "Amount for Doctors Treatment");
       this.add(typeof(XCN), false, 1, 250, new System.Object[]{message}, "Responsible Physician");
       this.add(typeof(CX), false, 1, 250, new System.Object[]{message}, "Cost Center");
       this.add(typeof(CP), false, 1, 254, new System.Object[]{message}, "Invoice Prepaid Amount");
       this.add(typeof(CP), false, 1, 254, new System.Object[]{message}, "Total Invoice Amount without Prepaid Amount");
       this.add(typeof(CP), false, 1, 254, new System.Object[]{message}, "Total-Amount of VAT");
       this.add(typeof(NM), false, 0, 1024, new System.Object[]{message}, "VAT-Rates applied");
       this.add(typeof(IS), true, 1, 4, new System.Object[]{message, 556}, "Benefit Group");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "Provider Tax ID");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "Payer Tax ID");
       this.add(typeof(IS), false, 1, 4, new System.Object[]{message, 572}, "Provider Tax status");
       this.add(typeof(IS), false, 1, 4, new System.Object[]{message, 572}, "Payer Tax status");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "Sales Tax ID");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Provider Invoice Number(IVC-1).
	///</summary>
	public EI ProviderInvoiceNumber
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
	/// Returns Payer Invoice Number(IVC-2).
	///</summary>
	public EI PayerInvoiceNumber
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Contract/Agreement Number(IVC-3).
	///</summary>
	public EI ContractAgreementNumber
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Invoice Control(IVC-4).
	///</summary>
	public IS InvoiceControl
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(4, 0);
				ret = (IS)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Invoice Reason(IVC-5).
	///</summary>
	public IS InvoiceReason
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(5, 0);
				ret = (IS)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Invoice Type(IVC-6).
	///</summary>
	public IS InvoiceType
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(6, 0);
				ret = (IS)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Invoice Date/Time(IVC-7).
	///</summary>
	public DTM InvoiceDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Invoice Amount(IVC-8).
	///</summary>
	public CP InvoiceAmount
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Payment Terms(IVC-9).
	///</summary>
	public ST PaymentTerms
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Provider Organization(IVC-10).
	///</summary>
	public XON ProviderOrganization
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Payer Organization(IVC-11).
	///</summary>
	public XON PayerOrganization
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Attention(IVC-12).
	///</summary>
	public XCN Attention
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Last Invoice Indicator(IVC-13).
	///</summary>
	public ID LastInvoiceIndicator
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
	/// Returns Invoice Booking Period(IVC-14).
	///</summary>
	public DTM InvoiceBookingPeriod
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Origin(IVC-15).
	///</summary>
	public ST Origin
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
	/// Returns Invoice Fixed Amount(IVC-16).
	///</summary>
	public CP InvoiceFixedAmount
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Special Costs(IVC-17).
	///</summary>
	public CP SpecialCosts
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns Amount for Doctors Treatment(IVC-18).
	///</summary>
	public CP AmountForDoctorsTreatment
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Responsible Physician(IVC-19).
	///</summary>
	public XCN ResponsiblePhysician
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Cost Center(IVC-20).
	///</summary>
	public CX CostCenter
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Invoice Prepaid Amount(IVC-21).
	///</summary>
	public CP InvoicePrepaidAmount
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Total Invoice Amount without Prepaid Amount(IVC-22).
	///</summary>
	public CP TotalInvoiceAmountWithoutPrepaidAmount
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
	/// Returns Total-Amount of VAT(IVC-23).
	///</summary>
	public CP TotalAmountOfVAT
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns a single repetition of VAT-Rates applied(IVC-24).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NM GetVATRatesApplied(int rep)
	{
			NM ret = null;
			try
			{
			IType t = this.GetField(24, rep);
				ret = (NM)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of VAT-Rates applied (IVC-24).
   ///</summary>
  public NM[] GetVATRatesApplied() {
     NM[] ret = null;
    try {
        IType[] t = this.GetField(24);  
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
  /// Returns the total repetitions of VAT-Rates applied (IVC-24).
   ///</summary>
  public int VATRatesAppliedRepetitionsUsed
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
	/// Returns Benefit Group(IVC-25).
	///</summary>
	public IS BenefitGroup
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(25, 0);
				ret = (IS)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Provider Tax ID(IVC-26).
	///</summary>
	public ST ProviderTaxID
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
	/// Returns Payer Tax ID(IVC-27).
	///</summary>
	public ST PayerTaxID
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

	///<summary>
	/// Returns Provider Tax status(IVC-28).
	///</summary>
	public IS ProviderTaxStatus
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(28, 0);
				ret = (IS)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Payer Tax status(IVC-29).
	///</summary>
	public IS PayerTaxStatus
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(29, 0);
				ret = (IS)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Sales Tax ID(IVC-30).
	///</summary>
	public ST SalesTaxID
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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