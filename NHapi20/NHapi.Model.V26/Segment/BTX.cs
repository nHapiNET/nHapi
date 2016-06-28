using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V26.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V26.Segment{

///<summary>
/// Represents an HL7 BTX message segment. 
/// This segment has the following fields:<ol>
///<li>BTX-1: Set ID - BTX (SI)</li>
///<li>BTX-2: BC Donation ID (EI)</li>
///<li>BTX-3: BC Component (CNE)</li>
///<li>BTX-4: BC Blood Group (CNE)</li>
///<li>BTX-5: CP Commercial Product (CWE)</li>
///<li>BTX-6: CP Manufacturer (XON)</li>
///<li>BTX-7: CP Lot Number (EI)</li>
///<li>BTX-8: BP Quantity (NM)</li>
///<li>BTX-9: BP Amount (NM)</li>
///<li>BTX-10: BP Units (CWE)</li>
///<li>BTX-11: BP Transfusion/Disposition Status (CWE)</li>
///<li>BTX-12: BP Message Status (ID)</li>
///<li>BTX-13: BP Date/Time of Status (DTM)</li>
///<li>BTX-14: BP Transfusion Administrator (XCN)</li>
///<li>BTX-15: BP Transfusion Verifier (XCN)</li>
///<li>BTX-16: BP Transfusion Start Date/Time of Status (DTM)</li>
///<li>BTX-17: BP Transfusion End Date/Time of Status (DTM)</li>
///<li>BTX-18: BP Adverse Reaction Type (CWE)</li>
///<li>BTX-19: BP Transfusion Interrupted Reason (CWE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class BTX : AbstractSegment  {

  /**
   * Creates a BTX (Blood Product Transfusion/Disposition) segment object that belongs to the given 
   * message.  
   */
	public BTX(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Set ID - BTX");
       this.add(typeof(EI), false, 1, 22, new System.Object[]{message}, "BC Donation ID");
       this.add(typeof(CNE), false, 1, 250, new System.Object[]{message}, "BC Component");
       this.add(typeof(CNE), false, 1, 250, new System.Object[]{message}, "BC Blood Group");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "CP Commercial Product");
       this.add(typeof(XON), false, 1, 250, new System.Object[]{message}, "CP Manufacturer");
       this.add(typeof(EI), false, 1, 22, new System.Object[]{message}, "CP Lot Number");
       this.add(typeof(NM), true, 1, 5, new System.Object[]{message}, "BP Quantity");
       this.add(typeof(NM), false, 1, 5, new System.Object[]{message}, "BP Amount");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "BP Units");
       this.add(typeof(CWE), true, 1, 250, new System.Object[]{message}, "BP Transfusion/Disposition Status");
       this.add(typeof(ID), true, 1, 1, new System.Object[]{message, 511}, "BP Message Status");
       this.add(typeof(DTM), true, 1, 24, new System.Object[]{message}, "BP Date/Time of Status");
       this.add(typeof(XCN), false, 1, 250, new System.Object[]{message}, "BP Transfusion Administrator");
       this.add(typeof(XCN), false, 1, 250, new System.Object[]{message}, "BP Transfusion Verifier");
       this.add(typeof(DTM), false, 1, 24, new System.Object[]{message}, "BP Transfusion Start Date/Time of Status");
       this.add(typeof(DTM), false, 1, 24, new System.Object[]{message}, "BP Transfusion End Date/Time of Status");
       this.add(typeof(CWE), false, 0, 250, new System.Object[]{message}, "BP Adverse Reaction Type");
       this.add(typeof(CWE), false, 1, 250, new System.Object[]{message}, "BP Transfusion Interrupted Reason");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - BTX(BTX-1).
	///</summary>
	public SI SetIDBTX
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
	/// Returns BC Donation ID(BTX-2).
	///</summary>
	public EI BCDonationID
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
	/// Returns BC Component(BTX-3).
	///</summary>
	public CNE BCComponent
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns BC Blood Group(BTX-4).
	///</summary>
	public CNE BCBloodGroup
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns CP Commercial Product(BTX-5).
	///</summary>
	public CWE CPCommercialProduct
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
	/// Returns CP Manufacturer(BTX-6).
	///</summary>
	public XON CPManufacturer
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns CP Lot Number(BTX-7).
	///</summary>
	public EI CPLotNumber
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
	/// Returns BP Quantity(BTX-8).
	///</summary>
	public NM BPQuantity
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns BP Amount(BTX-9).
	///</summary>
	public NM BPAmount
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
	/// Returns BP Units(BTX-10).
	///</summary>
	public CWE BPUnits
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
	/// Returns BP Transfusion/Disposition Status(BTX-11).
	///</summary>
	public CWE BPTransfusionDispositionStatus
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
	/// Returns BP Message Status(BTX-12).
	///</summary>
	public ID BPMessageStatus
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
	/// Returns BP Date/Time of Status(BTX-13).
	///</summary>
	public DTM BPDateTimeOfStatus
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns BP Transfusion Administrator(BTX-14).
	///</summary>
	public XCN BPTransfusionAdministrator
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns BP Transfusion Verifier(BTX-15).
	///</summary>
	public XCN BPTransfusionVerifier
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns BP Transfusion Start Date/Time of Status(BTX-16).
	///</summary>
	public DTM BPTransfusionStartDateTimeOfStatus
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns BP Transfusion End Date/Time of Status(BTX-17).
	///</summary>
	public DTM BPTransfusionEndDateTimeOfStatus
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
	/// Returns a single repetition of BP Adverse Reaction Type(BTX-18).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetBPAdverseReactionType(int rep)
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
  /// Returns all repetitions of BP Adverse Reaction Type (BTX-18).
   ///</summary>
  public CWE[] GetBPAdverseReactionType() {
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
  /// Returns the total repetitions of BP Adverse Reaction Type (BTX-18).
   ///</summary>
  public int BPAdverseReactionTypeRepetitionsUsed
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
	/// Returns BP Transfusion Interrupted Reason(BTX-19).
	///</summary>
	public CWE BPTransfusionInterruptedReason
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


}}