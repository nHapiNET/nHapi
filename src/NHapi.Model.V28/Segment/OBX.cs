using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V28.Segment{

///<summary>
/// Represents an HL7 OBX message segment. 
/// This segment has the following fields:<ol>
///<li>OBX-1: Set ID - OBX (SI)</li>
///<li>OBX-2: Value Type (ID)</li>
///<li>OBX-3: Observation Identifier (CWE)</li>
///<li>OBX-4: Observation Sub-ID (ST)</li>
///<li>OBX-5: Observation Value (varies)</li>
///<li>OBX-6: Units (CWE)</li>
///<li>OBX-7: References Range (ST)</li>
///<li>OBX-8: Interpretation Codes (CWE)</li>
///<li>OBX-9: Probability (NM)</li>
///<li>OBX-10: Nature of Abnormal Test (ID)</li>
///<li>OBX-11: Observation Result Status (ID)</li>
///<li>OBX-12: Effective Date of Reference Range (DTM)</li>
///<li>OBX-13: User Defined Access Checks (ST)</li>
///<li>OBX-14: Date/Time of the Observation (DTM)</li>
///<li>OBX-15: Producer's ID (CWE)</li>
///<li>OBX-16: Responsible Observer (XCN)</li>
///<li>OBX-17: Observation Method (CWE)</li>
///<li>OBX-18: Equipment Instance Identifier (EI)</li>
///<li>OBX-19: Date/Time of the Analysis (DTM)</li>
///<li>OBX-20: Observation Site (CWE)</li>
///<li>OBX-21: Observation Instance Identifier (EI)</li>
///<li>OBX-22: Mood Code (CNE)</li>
///<li>OBX-23: Performing Organization Name (XON)</li>
///<li>OBX-24: Performing Organization Address (XAD)</li>
///<li>OBX-25: Performing Organization Medical Director (XCN)</li>
///<li>OBX-26: Patient Results Release Category (ID)</li>
///<li>OBX-27: Root Cause (CWE)</li>
///<li>OBX-28: Local Process Control (CWE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class OBX : AbstractSegment  {

  /**
   * Creates a OBX (Observation/Result) segment object that belongs to the given 
   * message.  
   */
	public OBX(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), false, 1, 4, new System.Object[]{message}, "Set ID - OBX");
       this.add(typeof(ID), true, 1, 3, new System.Object[]{message, 125}, "Value Type");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Observation Identifier");
       this.add(typeof(ST), true, 1, 0, new System.Object[]{message}, "Observation Sub-ID");
       this.add(typeof(Varies), false, 0, 0, new System.Object[]{message}, "Observation Value");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Units");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "References Range");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Interpretation Codes");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Probability");
       this.add(typeof(ID), false, 0, 2, new System.Object[]{message, 80}, "Nature of Abnormal Test");
       this.add(typeof(ID), true, 1, 1, new System.Object[]{message, 85}, "Observation Result Status");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Effective Date of Reference Range");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "User Defined Access Checks");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Date/Time of the Observation");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Producer's ID");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Responsible Observer");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Observation Method");
       this.add(typeof(EI), false, 0, 0, new System.Object[]{message}, "Equipment Instance Identifier");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Date/Time of the Analysis");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Observation Site");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Observation Instance Identifier");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Mood Code");
       this.add(typeof(XON), false, 1, 0, new System.Object[]{message}, "Performing Organization Name");
       this.add(typeof(XAD), false, 1, 0, new System.Object[]{message}, "Performing Organization Address");
       this.add(typeof(XCN), false, 1, 0, new System.Object[]{message}, "Performing Organization Medical Director");
       this.add(typeof(ID), false, 1, 10, new System.Object[]{message, 909}, "Patient Results Release Category");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Root Cause");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Local Process Control");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - OBX(OBX-1).
	///</summary>
	public SI SetIDOBX
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
	/// Returns Value Type(OBX-2).
	///</summary>
	public ID ValueType
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Observation Identifier(OBX-3).
	///</summary>
	public CWE ObservationIdentifier
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
	/// Returns Observation Sub-ID(OBX-4).
	///</summary>
	public ST ObservationSubID
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
	/// Returns a single repetition of Observation Value(OBX-5).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public Varies GetObservationValue(int rep)
	{
			Varies ret = null;
			try
			{
			IType t = this.GetField(5, rep);
				ret = (Varies)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Observation Value (OBX-5).
   ///</summary>
  public Varies[] GetObservationValue() {
     Varies[] ret = null;
    try {
        IType[] t = this.GetField(5);  
        ret = new Varies[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (Varies)t[i];
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
  /// Returns the total repetitions of Observation Value (OBX-5).
   ///</summary>
  public int ObservationValueRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(5);
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
	/// Returns Units(OBX-6).
	///</summary>
	public CWE Units
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
	/// Returns References Range(OBX-7).
	///</summary>
	public ST ReferencesRange
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
	/// Returns a single repetition of Interpretation Codes(OBX-8).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetInterpretationCodes(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(8, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Interpretation Codes (OBX-8).
   ///</summary>
  public CWE[] GetInterpretationCodes() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(8);  
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
  /// Returns the total repetitions of Interpretation Codes (OBX-8).
   ///</summary>
  public int InterpretationCodesRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(8);
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
	/// Returns Probability(OBX-9).
	///</summary>
	public NM Probability
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
	/// Returns a single repetition of Nature of Abnormal Test(OBX-10).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ID GetNatureOfAbnormalTest(int rep)
	{
			ID ret = null;
			try
			{
			IType t = this.GetField(10, rep);
				ret = (ID)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Nature of Abnormal Test (OBX-10).
   ///</summary>
  public ID[] GetNatureOfAbnormalTest() {
     ID[] ret = null;
    try {
        IType[] t = this.GetField(10);  
        ret = new ID[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (ID)t[i];
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
  /// Returns the total repetitions of Nature of Abnormal Test (OBX-10).
   ///</summary>
  public int NatureOfAbnormalTestRepetitionsUsed
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
	/// Returns Observation Result Status(OBX-11).
	///</summary>
	public ID ObservationResultStatus
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Effective Date of Reference Range(OBX-12).
	///</summary>
	public DTM EffectiveDateOfReferenceRange
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns User Defined Access Checks(OBX-13).
	///</summary>
	public ST UserDefinedAccessChecks
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
	/// Returns Date/Time of the Observation(OBX-14).
	///</summary>
	public DTM DateTimeOfTheObservation
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
	/// Returns Producer's ID(OBX-15).
	///</summary>
	public CWE ProducerSID
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
	/// Returns a single repetition of Responsible Observer(OBX-16).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetResponsibleObserver(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(16, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Responsible Observer (OBX-16).
   ///</summary>
  public XCN[] GetResponsibleObserver() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(16);  
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
  /// Returns the total repetitions of Responsible Observer (OBX-16).
   ///</summary>
  public int ResponsibleObserverRepetitionsUsed
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
	/// Returns a single repetition of Observation Method(OBX-17).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetObservationMethod(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(17, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Observation Method (OBX-17).
   ///</summary>
  public CWE[] GetObservationMethod() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(17);  
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
  /// Returns the total repetitions of Observation Method (OBX-17).
   ///</summary>
  public int ObservationMethodRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(17);
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
	/// Returns a single repetition of Equipment Instance Identifier(OBX-18).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public EI GetEquipmentInstanceIdentifier(int rep)
	{
			EI ret = null;
			try
			{
			IType t = this.GetField(18, rep);
				ret = (EI)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Equipment Instance Identifier (OBX-18).
   ///</summary>
  public EI[] GetEquipmentInstanceIdentifier() {
     EI[] ret = null;
    try {
        IType[] t = this.GetField(18);  
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
  /// Returns the total repetitions of Equipment Instance Identifier (OBX-18).
   ///</summary>
  public int EquipmentInstanceIdentifierRepetitionsUsed
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
	/// Returns Date/Time of the Analysis(OBX-19).
	///</summary>
	public DTM DateTimeOfTheAnalysis
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns a single repetition of Observation Site(OBX-20).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetObservationSite(int rep)
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
  /// Returns all repetitions of Observation Site (OBX-20).
   ///</summary>
  public CWE[] GetObservationSite() {
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
  /// Returns the total repetitions of Observation Site (OBX-20).
   ///</summary>
  public int ObservationSiteRepetitionsUsed
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
	/// Returns Observation Instance Identifier(OBX-21).
	///</summary>
	public EI ObservationInstanceIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Mood Code(OBX-22).
	///</summary>
	public CNE MoodCode
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
	/// Returns Performing Organization Name(OBX-23).
	///</summary>
	public XON PerformingOrganizationName
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Performing Organization Address(OBX-24).
	///</summary>
	public XAD PerformingOrganizationAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Performing Organization Medical Director(OBX-25).
	///</summary>
	public XCN PerformingOrganizationMedicalDirector
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Patient Results Release Category(OBX-26).
	///</summary>
	public ID PatientResultsReleaseCategory
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(26, 0);
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
	/// Returns Root Cause(OBX-27).
	///</summary>
	public CWE RootCause
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
	/// Returns a single repetition of Local Process Control(OBX-28).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetLocalProcessControl(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(28, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Local Process Control (OBX-28).
   ///</summary>
  public CWE[] GetLocalProcessControl() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(28);  
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
  /// Returns the total repetitions of Local Process Control (OBX-28).
   ///</summary>
  public int LocalProcessControlRepetitionsUsed
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

}}