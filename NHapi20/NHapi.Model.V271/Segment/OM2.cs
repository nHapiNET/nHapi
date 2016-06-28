using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V271.Segment{

///<summary>
/// Represents an HL7 OM2 message segment. 
/// This segment has the following fields:<ol>
///<li>OM2-1: Sequence Number - Test/Observation Master File (NM)</li>
///<li>OM2-2: Units of Measure (CWE)</li>
///<li>OM2-3: Range of Decimal Precision (NM)</li>
///<li>OM2-4: Corresponding SI Units of Measure (CWE)</li>
///<li>OM2-5: SI Conversion Factor (TX)</li>
///<li>OM2-6: Reference (Normal) Range for Ordinal and Continuous Observations (RFR)</li>
///<li>OM2-7: Critical Range for Ordinal and Continuous Observations (RFR)</li>
///<li>OM2-8: Absolute Range for Ordinal and Continuous Observations (RFR)</li>
///<li>OM2-9: Delta Check Criteria (DLT)</li>
///<li>OM2-10: Minimum Meaningful Increments (NM)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class OM2 : AbstractSegment  {

  /**
   * Creates a OM2 (Numeric Observation) segment object that belongs to the given 
   * message.  
   */
	public OM2(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Sequence Number - Test/Observation Master File");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Units of Measure");
       this.add(typeof(NM), false, 0, 0, new System.Object[]{message}, "Range of Decimal Precision");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Corresponding SI Units of Measure");
       this.add(typeof(TX), false, 1, 0, new System.Object[]{message}, "SI Conversion Factor");
       this.add(typeof(RFR), false, 0, 0, new System.Object[]{message}, "Reference (Normal) Range for Ordinal and Continuous Observations");
       this.add(typeof(RFR), false, 0, 0, new System.Object[]{message}, "Critical Range for Ordinal and Continuous Observations");
       this.add(typeof(RFR), false, 1, 0, new System.Object[]{message}, "Absolute Range for Ordinal and Continuous Observations");
       this.add(typeof(DLT), false, 0, 0, new System.Object[]{message}, "Delta Check Criteria");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Minimum Meaningful Increments");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Sequence Number - Test/Observation Master File(OM2-1).
	///</summary>
	public NM SequenceNumberTestObservationMasterFile
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Units of Measure(OM2-2).
	///</summary>
	public CWE UnitsOfMeasure
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
	/// Returns a single repetition of Range of Decimal Precision(OM2-3).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NM GetRangeOfDecimalPrecision(int rep)
	{
			NM ret = null;
			try
			{
			IType t = this.GetField(3, rep);
				ret = (NM)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Range of Decimal Precision (OM2-3).
   ///</summary>
  public NM[] GetRangeOfDecimalPrecision() {
     NM[] ret = null;
    try {
        IType[] t = this.GetField(3);  
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
  /// Returns the total repetitions of Range of Decimal Precision (OM2-3).
   ///</summary>
  public int RangeOfDecimalPrecisionRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(3);
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
	/// Returns Corresponding SI Units of Measure(OM2-4).
	///</summary>
	public CWE CorrespondingSIUnitsOfMeasure
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
	/// Returns SI Conversion Factor(OM2-5).
	///</summary>
	public TX SIConversionFactor
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
	/// Returns a single repetition of Reference (Normal) Range for Ordinal and Continuous Observations(OM2-6).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public RFR GetReferenceNormalRangeForOrdinalAndContinuousObservations(int rep)
	{
			RFR ret = null;
			try
			{
			IType t = this.GetField(6, rep);
				ret = (RFR)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Reference (Normal) Range for Ordinal and Continuous Observations (OM2-6).
   ///</summary>
  public RFR[] GetReferenceNormalRangeForOrdinalAndContinuousObservations() {
     RFR[] ret = null;
    try {
        IType[] t = this.GetField(6);  
        ret = new RFR[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (RFR)t[i];
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
  /// Returns the total repetitions of Reference (Normal) Range for Ordinal and Continuous Observations (OM2-6).
   ///</summary>
  public int ReferenceNormalRangeForOrdinalAndContinuousObservationsRepetitionsUsed
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
	/// Returns a single repetition of Critical Range for Ordinal and Continuous Observations(OM2-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public RFR GetCriticalRangeForOrdinalAndContinuousObservations(int rep)
	{
			RFR ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (RFR)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Critical Range for Ordinal and Continuous Observations (OM2-7).
   ///</summary>
  public RFR[] GetCriticalRangeForOrdinalAndContinuousObservations() {
     RFR[] ret = null;
    try {
        IType[] t = this.GetField(7);  
        ret = new RFR[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (RFR)t[i];
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
  /// Returns the total repetitions of Critical Range for Ordinal and Continuous Observations (OM2-7).
   ///</summary>
  public int CriticalRangeForOrdinalAndContinuousObservationsRepetitionsUsed
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
	/// Returns Absolute Range for Ordinal and Continuous Observations(OM2-8).
	///</summary>
	public RFR AbsoluteRangeForOrdinalAndContinuousObservations
	{
		get{
			RFR ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (RFR)t;
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
	/// Returns a single repetition of Delta Check Criteria(OM2-9).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public DLT GetDeltaCheckCriteria(int rep)
	{
			DLT ret = null;
			try
			{
			IType t = this.GetField(9, rep);
				ret = (DLT)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Delta Check Criteria (OM2-9).
   ///</summary>
  public DLT[] GetDeltaCheckCriteria() {
     DLT[] ret = null;
    try {
        IType[] t = this.GetField(9);  
        ret = new DLT[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (DLT)t[i];
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
  /// Returns the total repetitions of Delta Check Criteria (OM2-9).
   ///</summary>
  public int DeltaCheckCriteriaRepetitionsUsed
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
	/// Returns Minimum Meaningful Increments(OM2-10).
	///</summary>
	public NM MinimumMeaningfulIncrements
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


}}