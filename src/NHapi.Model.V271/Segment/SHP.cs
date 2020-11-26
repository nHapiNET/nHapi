using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V271.Segment{

///<summary>
/// Represents an HL7 SHP message segment. 
/// This segment has the following fields:<ol>
///<li>SHP-1: Shipment ID (EI)</li>
///<li>SHP-2: Internal Shipment ID (EI)</li>
///<li>SHP-3: Shipment Status (CWE)</li>
///<li>SHP-4: Shipment Status Date/Time (DTM)</li>
///<li>SHP-5: Shipment Status Reason (TX)</li>
///<li>SHP-6: Shipment Priority (CWE)</li>
///<li>SHP-7: Shipment Confidentiality (CWE)</li>
///<li>SHP-8: Number of Packages in Shipment (NM)</li>
///<li>SHP-9: Shipment Condition (CWE)</li>
///<li>SHP-10: Shipment Handling Code (CWE)</li>
///<li>SHP-11: Shipment Risk Code (CWE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class SHP : AbstractSegment  {

  /**
   * Creates a SHP (Shipment) segment object that belongs to the given 
   * message.  
   */
	public SHP(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Shipment ID");
       this.add(typeof(EI), false, 0, 0, new System.Object[]{message}, "Internal Shipment ID");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Shipment Status");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Shipment Status Date/Time");
       this.add(typeof(TX), false, 1, 0, new System.Object[]{message}, "Shipment Status Reason");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Shipment Priority");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Shipment Confidentiality");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Number of Packages in Shipment");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Shipment Condition");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Shipment Handling Code");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Shipment Risk Code");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Shipment ID(SHP-1).
	///</summary>
	public EI ShipmentID
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
	/// Returns a single repetition of Internal Shipment ID(SHP-2).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public EI GetInternalShipmentID(int rep)
	{
			EI ret = null;
			try
			{
			IType t = this.GetField(2, rep);
				ret = (EI)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Internal Shipment ID (SHP-2).
   ///</summary>
  public EI[] GetInternalShipmentID() {
     EI[] ret = null;
    try {
        IType[] t = this.GetField(2);  
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
  /// Returns the total repetitions of Internal Shipment ID (SHP-2).
   ///</summary>
  public int InternalShipmentIDRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(2);
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
	/// Returns Shipment Status(SHP-3).
	///</summary>
	public CWE ShipmentStatus
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
	/// Returns Shipment Status Date/Time(SHP-4).
	///</summary>
	public DTM ShipmentStatusDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Shipment Status Reason(SHP-5).
	///</summary>
	public TX ShipmentStatusReason
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(5, 0);
				ret = (TX)t;
			}
			 catch (HL7Exception he) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
				throw new System.Exception("An unexpected error ocurred", he);
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
	}
  }

	///<summary>
	/// Returns Shipment Priority(SHP-6).
	///</summary>
	public CWE ShipmentPriority
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
	/// Returns a single repetition of Shipment Confidentiality(SHP-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetShipmentConfidentiality(int rep)
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
  /// Returns all repetitions of Shipment Confidentiality (SHP-7).
   ///</summary>
  public CWE[] GetShipmentConfidentiality() {
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
  /// Returns the total repetitions of Shipment Confidentiality (SHP-7).
   ///</summary>
  public int ShipmentConfidentialityRepetitionsUsed
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
	/// Returns Number of Packages in Shipment(SHP-8).
	///</summary>
	public NM NumberOfPackagesInShipment
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
	/// Returns a single repetition of Shipment Condition(SHP-9).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetShipmentCondition(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(9, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Shipment Condition (SHP-9).
   ///</summary>
  public CWE[] GetShipmentCondition() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(9);  
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
  /// Returns the total repetitions of Shipment Condition (SHP-9).
   ///</summary>
  public int ShipmentConditionRepetitionsUsed
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
	/// Returns a single repetition of Shipment Handling Code(SHP-10).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetShipmentHandlingCode(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(10, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Shipment Handling Code (SHP-10).
   ///</summary>
  public CWE[] GetShipmentHandlingCode() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(10);  
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
  /// Returns the total repetitions of Shipment Handling Code (SHP-10).
   ///</summary>
  public int ShipmentHandlingCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(10);
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
	/// Returns a single repetition of Shipment Risk Code(SHP-11).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetShipmentRiskCode(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(11, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Shipment Risk Code (SHP-11).
   ///</summary>
  public CWE[] GetShipmentRiskCode() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(11);  
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
  /// Returns the total repetitions of Shipment Risk Code (SHP-11).
   ///</summary>
  public int ShipmentRiskCodeRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(11);
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