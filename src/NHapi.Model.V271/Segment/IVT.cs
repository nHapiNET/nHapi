using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V271.Segment{

///<summary>
/// Represents an HL7 IVT message segment. 
/// This segment has the following fields:<ol>
///<li>IVT-1: Set Id - IVT (SI)</li>
///<li>IVT-2: Inventory Location Identifier (EI)</li>
///<li>IVT-3: Inventory Location Name (ST)</li>
///<li>IVT-4: Source Location Identifier (EI)</li>
///<li>IVT-5: Source Location Name (ST)</li>
///<li>IVT-6: Item Status (CWE)</li>
///<li>IVT-7: Bin Location Identifier (EI)</li>
///<li>IVT-8: Order Packaging (CWE)</li>
///<li>IVT-9: Issue Packaging (CWE)</li>
///<li>IVT-10: Default Inventory Asset Account (EI)</li>
///<li>IVT-11: Patient Chargeable Indicator (CNE)</li>
///<li>IVT-12: Transaction Code (CWE)</li>
///<li>IVT-13: Transaction amount - unit (CP)</li>
///<li>IVT-14: Item Importance Code (CWE)</li>
///<li>IVT-15: Stocked Item Indicator (CNE)</li>
///<li>IVT-16: Consignment Item Indicator (CNE)</li>
///<li>IVT-17: Reusable Item Indicator (CNE)</li>
///<li>IVT-18: Reusable Cost (CP)</li>
///<li>IVT-19: Substitute Item Identifier (EI)</li>
///<li>IVT-20: Latex-Free Substitute Item Identifier (EI)</li>
///<li>IVT-21: Recommended Reorder Theory (CWE)</li>
///<li>IVT-22: Recommended Safety Stock Days (NM)</li>
///<li>IVT-23: Recommended Maximum Days Inventory (NM)</li>
///<li>IVT-24: Recommended Order Point (NM)</li>
///<li>IVT-25: Recommended Order Amount (NM)</li>
///<li>IVT-26: Operating Room Par Level Indicator (CNE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class IVT : AbstractSegment  {

  /**
   * Creates a IVT (Material Location) segment object that belongs to the given 
   * message.  
   */
	public IVT(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Set Id - IVT");
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Inventory Location Identifier");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Inventory Location Name");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Source Location Identifier");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Source Location Name");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Item Status");
       this.add(typeof(EI), false, 0, 0, new System.Object[]{message}, "Bin Location Identifier");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Order Packaging");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Issue Packaging");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Default Inventory Asset Account");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Patient Chargeable Indicator");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Transaction Code");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Transaction amount - unit");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Item Importance Code");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Stocked Item Indicator");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Consignment Item Indicator");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Reusable Item Indicator");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Reusable Cost");
       this.add(typeof(EI), false, 0, 0, new System.Object[]{message}, "Substitute Item Identifier");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Latex-Free Substitute Item Identifier");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Recommended Reorder Theory");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Recommended Safety Stock Days");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Recommended Maximum Days Inventory");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Recommended Order Point");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Recommended Order Amount");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Operating Room Par Level Indicator");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set Id - IVT(IVT-1).
	///</summary>
	public SI SetIdIVT
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
	/// Returns Inventory Location Identifier(IVT-2).
	///</summary>
	public EI InventoryLocationIdentifier
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
	/// Returns Inventory Location Name(IVT-3).
	///</summary>
	public ST InventoryLocationName
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
	/// Returns Source Location Identifier(IVT-4).
	///</summary>
	public EI SourceLocationIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Source Location Name(IVT-5).
	///</summary>
	public ST SourceLocationName
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
	/// Returns Item Status(IVT-6).
	///</summary>
	public CWE ItemStatus
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
	/// Returns a single repetition of Bin Location Identifier(IVT-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public EI GetBinLocationIdentifier(int rep)
	{
			EI ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (EI)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Bin Location Identifier (IVT-7).
   ///</summary>
  public EI[] GetBinLocationIdentifier() {
     EI[] ret = null;
    try {
        IType[] t = this.GetField(7);  
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
  /// Returns the total repetitions of Bin Location Identifier (IVT-7).
   ///</summary>
  public int BinLocationIdentifierRepetitionsUsed
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
	/// Returns Order Packaging(IVT-8).
	///</summary>
	public CWE OrderPackaging
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Issue Packaging(IVT-9).
	///</summary>
	public CWE IssuePackaging
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Default Inventory Asset Account(IVT-10).
	///</summary>
	public EI DefaultInventoryAssetAccount
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Patient Chargeable Indicator(IVT-11).
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
	/// Returns Transaction Code(IVT-12).
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
	/// Returns Transaction amount - unit(IVT-13).
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
	/// Returns Item Importance Code(IVT-14).
	///</summary>
	public CWE ItemImportanceCode
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
	/// Returns Stocked Item Indicator(IVT-15).
	///</summary>
	public CNE StockedItemIndicator
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Consignment Item Indicator(IVT-16).
	///</summary>
	public CNE ConsignmentItemIndicator
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Reusable Item Indicator(IVT-17).
	///</summary>
	public CNE ReusableItemIndicator
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
	/// Returns Reusable Cost(IVT-18).
	///</summary>
	public CP ReusableCost
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
	/// Returns a single repetition of Substitute Item Identifier(IVT-19).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public EI GetSubstituteItemIdentifier(int rep)
	{
			EI ret = null;
			try
			{
			IType t = this.GetField(19, rep);
				ret = (EI)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Substitute Item Identifier (IVT-19).
   ///</summary>
  public EI[] GetSubstituteItemIdentifier() {
     EI[] ret = null;
    try {
        IType[] t = this.GetField(19);  
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
  /// Returns the total repetitions of Substitute Item Identifier (IVT-19).
   ///</summary>
  public int SubstituteItemIdentifierRepetitionsUsed
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
	/// Returns Latex-Free Substitute Item Identifier(IVT-20).
	///</summary>
	public EI LatexFreeSubstituteItemIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Recommended Reorder Theory(IVT-21).
	///</summary>
	public CWE RecommendedReorderTheory
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Recommended Safety Stock Days(IVT-22).
	///</summary>
	public NM RecommendedSafetyStockDays
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Recommended Maximum Days Inventory(IVT-23).
	///</summary>
	public NM RecommendedMaximumDaysInventory
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Recommended Order Point(IVT-24).
	///</summary>
	public NM RecommendedOrderPoint
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Recommended Order Amount(IVT-25).
	///</summary>
	public NM RecommendedOrderAmount
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
	/// Returns Operating Room Par Level Indicator(IVT-26).
	///</summary>
	public CNE OperatingRoomParLevelIndicator
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


}}