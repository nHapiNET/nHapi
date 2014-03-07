using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V22.Segment{

///<summary>
/// Represents an HL7 ORC message segment. 
/// This segment has the following fields:<ol>
///<li>ORC-1: Order Control (ID)</li>
///<li>ORC-2: Placer Order Number (CM_PLACER)</li>
///<li>ORC-3: Filler Order Number (CM_FILLER)</li>
///<li>ORC-4: Placer Group Number (CM_GROUP_ID)</li>
///<li>ORC-5: Order Status (ID)</li>
///<li>ORC-6: Response Flag (ID)</li>
///<li>ORC-7: Quantity / timing (TQ)</li>
///<li>ORC-8: Parent (CM_EIP)</li>
///<li>ORC-9: Date / time of transaction (TS)</li>
///<li>ORC-10: Entered By (CN_PERSON)</li>
///<li>ORC-11: Verified By (CN_PERSON)</li>
///<li>ORC-12: Ordering Provider (CN_PERSON)</li>
///<li>ORC-13: Enterer's Location (CM_PARENT_RESULT)</li>
///<li>ORC-14: Call Back Phone Number (TN)</li>
///<li>ORC-15: Order effective date / time (TS)</li>
///<li>ORC-16: Order Control Code Reason (CE)</li>
///<li>ORC-17: Entering Organization (CE)</li>
///<li>ORC-18: Entering Device (CE)</li>
///<li>ORC-19: Action by (CN_PERSON)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class ORC : AbstractSegment  {

  /**
   * Creates a ORC (COMMOM ORDER) segment object that belongs to the given 
   * message.  
   */
	public ORC(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(ID), true, 1, 2, new System.Object[]{message, 119}, "Order Control");
       this.add(typeof(CM_PLACER), false, 1, 75, new System.Object[]{message}, "Placer Order Number");
       this.add(typeof(CM_FILLER), false, 1, 75, new System.Object[]{message}, "Filler Order Number");
       this.add(typeof(CM_GROUP_ID), false, 1, 75, new System.Object[]{message}, "Placer Group Number");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 38}, "Order Status");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 121}, "Response Flag");
       this.add(typeof(TQ), false, 0, 200, new System.Object[]{message}, "Quantity / timing");
       this.add(typeof(CM_EIP), false, 1, 200, new System.Object[]{message}, "Parent");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Date / time of transaction");
       this.add(typeof(CN_PERSON), false, 1, 80, new System.Object[]{message}, "Entered By");
       this.add(typeof(CN_PERSON), false, 1, 80, new System.Object[]{message}, "Verified By");
       this.add(typeof(CN_PERSON), false, 1, 80, new System.Object[]{message}, "Ordering Provider");
       this.add(typeof(CM_PARENT_RESULT), false, 1, 80, new System.Object[]{message}, "Enterer's Location");
       this.add(typeof(TN), false, 2, 40, new System.Object[]{message}, "Call Back Phone Number");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Order effective date / time");
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Order Control Code Reason");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Entering Organization");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Entering Device");
       this.add(typeof(CN_PERSON), false, 1, 80, new System.Object[]{message}, "Action by");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Order Control(ORC-1).
	///</summary>
	public ID OrderControl
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Placer Order Number(ORC-2).
	///</summary>
	public CM_PLACER PlacerOrderNumber
	{
		get{
			CM_PLACER ret = null;
			try
			{
			IType t = this.GetField(2, 0);
				ret = (CM_PLACER)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Filler Order Number(ORC-3).
	///</summary>
	public CM_FILLER FillerOrderNumber
	{
		get{
			CM_FILLER ret = null;
			try
			{
			IType t = this.GetField(3, 0);
				ret = (CM_FILLER)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Placer Group Number(ORC-4).
	///</summary>
	public CM_GROUP_ID PlacerGroupNumber
	{
		get{
			CM_GROUP_ID ret = null;
			try
			{
			IType t = this.GetField(4, 0);
				ret = (CM_GROUP_ID)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Order Status(ORC-5).
	///</summary>
	public ID OrderStatus
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Response Flag(ORC-6).
	///</summary>
	public ID ResponseFlag
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
	/// Returns a single repetition of Quantity / timing(ORC-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TQ GetQuantityTiming(int rep)
	{
			TQ ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (TQ)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Quantity / timing (ORC-7).
   ///</summary>
  public TQ[] GetQuantityTiming() {
     TQ[] ret = null;
    try {
        IType[] t = this.GetField(7);  
        ret = new TQ[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (TQ)t[i];
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
  /// Returns the total repetitions of Quantity / timing (ORC-7).
   ///</summary>
  public int QuantityTimingRepetitionsUsed
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
	/// Returns Parent(ORC-8).
	///</summary>
	public CM_EIP Parent
	{
		get{
			CM_EIP ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (CM_EIP)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Date / time of transaction(ORC-9).
	///</summary>
	public TS DateTimeOfTransaction
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Entered By(ORC-10).
	///</summary>
	public CN_PERSON EnteredBy
	{
		get{
			CN_PERSON ret = null;
			try
			{
			IType t = this.GetField(10, 0);
				ret = (CN_PERSON)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Verified By(ORC-11).
	///</summary>
	public CN_PERSON VerifiedBy
	{
		get{
			CN_PERSON ret = null;
			try
			{
			IType t = this.GetField(11, 0);
				ret = (CN_PERSON)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Ordering Provider(ORC-12).
	///</summary>
	public CN_PERSON OrderingProvider
	{
		get{
			CN_PERSON ret = null;
			try
			{
			IType t = this.GetField(12, 0);
				ret = (CN_PERSON)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Enterer's Location(ORC-13).
	///</summary>
	public CM_PARENT_RESULT EntererSLocation
	{
		get{
			CM_PARENT_RESULT ret = null;
			try
			{
			IType t = this.GetField(13, 0);
				ret = (CM_PARENT_RESULT)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns a single repetition of Call Back Phone Number(ORC-14).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TN GetCallBackPhoneNumber(int rep)
	{
			TN ret = null;
			try
			{
			IType t = this.GetField(14, rep);
				ret = (TN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Call Back Phone Number (ORC-14).
   ///</summary>
  public TN[] GetCallBackPhoneNumber() {
     TN[] ret = null;
    try {
        IType[] t = this.GetField(14);  
        ret = new TN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (TN)t[i];
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
  /// Returns the total repetitions of Call Back Phone Number (ORC-14).
   ///</summary>
  public int CallBackPhoneNumberRepetitionsUsed
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
	/// Returns Order effective date / time(ORC-15).
	///</summary>
	public TS OrderEffectiveDateTime
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Order Control Code Reason(ORC-16).
	///</summary>
	public CE OrderControlCodeReason
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(16, 0);
				ret = (CE)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Entering Organization(ORC-17).
	///</summary>
	public CE EnteringOrganization
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(17, 0);
				ret = (CE)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Entering Device(ORC-18).
	///</summary>
	public CE EnteringDevice
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(18, 0);
				ret = (CE)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Action by(ORC-19).
	///</summary>
	public CN_PERSON ActionBy
	{
		get{
			CN_PERSON ret = null;
			try
			{
			IType t = this.GetField(19, 0);
				ret = (CN_PERSON)t;
			}
			 catch (HL7Exception he) {
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