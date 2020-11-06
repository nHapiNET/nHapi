using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V271.Segment{

///<summary>
/// Represents an HL7 ITM message segment. 
/// This segment has the following fields:<ol>
///<li>ITM-1: Item Identifier (EI)</li>
///<li>ITM-2: Item Description (ST)</li>
///<li>ITM-3: Item Status (CWE)</li>
///<li>ITM-4: Item Type (CWE)</li>
///<li>ITM-5: Item Category (CWE)</li>
///<li>ITM-6: Subject to Expiration Indicator (CNE)</li>
///<li>ITM-7: Manufacturer Identifier (EI)</li>
///<li>ITM-8: Manufacturer Name (ST)</li>
///<li>ITM-9: Manufacturer Catalog Number (ST)</li>
///<li>ITM-10: Manufacturer Labeler Identification Code (CWE)</li>
///<li>ITM-11: Patient Chargeable Indicator (CNE)</li>
///<li>ITM-12: Transaction Code (CWE)</li>
///<li>ITM-13: Transaction amount - unit (CP)</li>
///<li>ITM-14: Stocked Item Indicator (CNE)</li>
///<li>ITM-15: Supply Risk Codes (CWE)</li>
///<li>ITM-16: Approving Regulatory Agency (XON)</li>
///<li>ITM-17: Latex Indicator (CNE)</li>
///<li>ITM-18: Ruling Act (CWE)</li>
///<li>ITM-19: Item Natural Account Code (CWE)</li>
///<li>ITM-20: Approved To Buy Quantity (NM)</li>
///<li>ITM-21: Approved To Buy Price (MO)</li>
///<li>ITM-22: Taxable Item Indicator (CNE)</li>
///<li>ITM-23: Freight Charge Indicator (CNE)</li>
///<li>ITM-24: Item Set Indicator (CNE)</li>
///<li>ITM-25: Item Set Identifier (EI)</li>
///<li>ITM-26: Track Department Usage Indicator (CNE)</li>
///<li>ITM-27: Procedure Code (CNE)</li>
///<li>ITM-28: Procedure Code Modifier (CNE)</li>
///<li>ITM-29: Special Handling Code (CWE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class ITM : AbstractSegment  {

  /**
   * Creates a ITM (Material Item) segment object that belongs to the given 
   * message.  
   */
	public ITM(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Item Identifier");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Item Description");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Item Status");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Item Type");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Item Category");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Subject to Expiration Indicator");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Manufacturer Identifier");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Manufacturer Name");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Manufacturer Catalog Number");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Manufacturer Labeler Identification Code");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Patient Chargeable Indicator");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Transaction Code");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Transaction amount - unit");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Stocked Item Indicator");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Supply Risk Codes");
       this.add(typeof(XON), false, 0, 0, new System.Object[]{message}, "Approving Regulatory Agency");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Latex Indicator");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Ruling Act");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Item Natural Account Code");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Approved To Buy Quantity");
       this.add(typeof(MO), false, 1, 0, new System.Object[]{message}, "Approved To Buy Price");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Taxable Item Indicator");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Freight Charge Indicator");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Item Set Indicator");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Item Set Identifier");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Track Department Usage Indicator");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Procedure Code");
       this.add(typeof(CNE), false, 0, 0, new System.Object[]{message}, "Procedure Code Modifier");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Special Handling Code");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Item Identifier(ITM-1).
	///</summary>
	public EI ItemIdentifier
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
	/// Returns Item Description(ITM-2).
	///</summary>
	public ST ItemDescription
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
	/// Returns Item Status(ITM-3).
	///</summary>
	public CWE ItemStatus
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
	/// Returns Item Type(ITM-4).
	///</summary>
	public CWE ItemType
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
	/// Returns Item Category(ITM-5).
	///</summary>
	public CWE ItemCategory
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
	/// Returns Subject to Expiration Indicator(ITM-6).
	///</summary>
	public CNE SubjectToExpirationIndicator
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
	/// Returns Manufacturer Identifier(ITM-7).
	///</summary>
	public EI ManufacturerIdentifier
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
	/// Returns Manufacturer Name(ITM-8).
	///</summary>
	public ST ManufacturerName
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
	/// Returns Manufacturer Catalog Number(ITM-9).
	///</summary>
	public ST ManufacturerCatalogNumber
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
	/// Returns Manufacturer Labeler Identification Code(ITM-10).
	///</summary>
	public CWE ManufacturerLabelerIdentificationCode
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
	/// Returns Patient Chargeable Indicator(ITM-11).
	///</summary>
	public CNE PatientChargeableIndicator
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Transaction Code(ITM-12).
	///</summary>
	public CWE TransactionCode
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
	/// Returns Transaction amount - unit(ITM-13).
	///</summary>
	public CP TransactionAmountUnit
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Stocked Item Indicator(ITM-14).
	///</summary>
	public CNE StockedItemIndicator
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Supply Risk Codes(ITM-15).
	///</summary>
	public CWE SupplyRiskCodes
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
	/// Returns a single repetition of Approving Regulatory Agency(ITM-16).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XON GetApprovingRegulatoryAgency(int rep)
	{
			XON ret = null;
			try
			{
			IType t = this.GetField(16, rep);
				ret = (XON)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Approving Regulatory Agency (ITM-16).
   ///</summary>
  public XON[] GetApprovingRegulatoryAgency() {
     XON[] ret = null;
    try {
        IType[] t = this.GetField(16);  
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
  /// Returns the total repetitions of Approving Regulatory Agency (ITM-16).
   ///</summary>
  public int ApprovingRegulatoryAgencyRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(16);
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
	/// Returns Latex Indicator(ITM-17).
	///</summary>
	public CNE LatexIndicator
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns a single repetition of Ruling Act(ITM-18).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetRulingAct(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(18, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Ruling Act (ITM-18).
   ///</summary>
  public CWE[] GetRulingAct() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(18);  
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
  /// Returns the total repetitions of Ruling Act (ITM-18).
   ///</summary>
  public int RulingActRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(18);
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
	/// Returns Item Natural Account Code(ITM-19).
	///</summary>
	public CWE ItemNaturalAccountCode
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
	/// Returns Approved To Buy Quantity(ITM-20).
	///</summary>
	public NM ApprovedToBuyQuantity
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Approved To Buy Price(ITM-21).
	///</summary>
	public MO ApprovedToBuyPrice
	{
		get{
			MO ret = null;
			try
			{
			IType t = this.GetField(21, 0);
				ret = (MO)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Taxable Item Indicator(ITM-22).
	///</summary>
	public CNE TaxableItemIndicator
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
	/// Returns Freight Charge Indicator(ITM-23).
	///</summary>
	public CNE FreightChargeIndicator
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Item Set Indicator(ITM-24).
	///</summary>
	public CNE ItemSetIndicator
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Item Set Identifier(ITM-25).
	///</summary>
	public EI ItemSetIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Track Department Usage Indicator(ITM-26).
	///</summary>
	public CNE TrackDepartmentUsageIndicator
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(26, 0);
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
	/// Returns Procedure Code(ITM-27).
	///</summary>
	public CNE ProcedureCode
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(27, 0);
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
	/// Returns a single repetition of Procedure Code Modifier(ITM-28).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CNE GetProcedureCodeModifier(int rep)
	{
			CNE ret = null;
			try
			{
			IType t = this.GetField(28, rep);
				ret = (CNE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Procedure Code Modifier (ITM-28).
   ///</summary>
  public CNE[] GetProcedureCodeModifier() {
     CNE[] ret = null;
    try {
        IType[] t = this.GetField(28);  
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
  /// Returns the total repetitions of Procedure Code Modifier (ITM-28).
   ///</summary>
  public int ProcedureCodeModifierRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(28);
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
	/// Returns Special Handling Code(ITM-29).
	///</summary>
	public CWE SpecialHandlingCode
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


}}