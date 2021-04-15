using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V22.Segment{

///<summary>
/// Represents an HL7 OM2 message segment. 
/// This segment has the following fields:<ol>
///<li>OM2-1: Segment Type ID (ST)</li>
///<li>OM2-2: Sequence Number - Test/ Observation Master File (NM)</li>
///<li>OM2-3: Units of Measure (CE)</li>
///<li>OM2-4: Range of Decimal Precision (NM)</li>
///<li>OM2-5: Corresponding SI Units of Measure (CE)</li>
///<li>OM2-6: SI Conversion Factor (TX)</li>
///<li>OM2-7: Reference (normal) range - ordinal and continuous observations (CM_RFR)</li>
///<li>OM2-8: Critical range for ordinal and continuous observations (CM_RANGE)</li>
///<li>OM2-9: Absolute range for ordinal and continuous observations (CM_ABS_RANGE)</li>
///<li>OM2-10: Delta Check Criteria (CM_DLT)</li>
///<li>OM2-11: Minimum Meaningful Increments (NM)</li>
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
   * Creates a OM2 (NUMERIC OBSERVATION) segment object that belongs to the given 
   * message.  
   */
	public OM2(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(ST), false, 1, 3, new System.Object[]{message}, "Segment Type ID");
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Sequence Number - Test/ Observation Master File");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Units of Measure");
       this.add(typeof(NM), false, 1, 10, new System.Object[]{message}, "Range of Decimal Precision");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Corresponding SI Units of Measure");
       this.add(typeof(TX), true, 0, 20, new System.Object[]{message}, "SI Conversion Factor");
       this.add(typeof(CM_RFR), false, 0, 200, new System.Object[]{message}, "Reference (normal) range - ordinal and continuous observations");
       this.add(typeof(CM_RANGE), false, 1, 200, new System.Object[]{message}, "Critical range for ordinal and continuous observations");
       this.add(typeof(CM_ABS_RANGE), false, 1, 200, new System.Object[]{message}, "Absolute range for ordinal and continuous observations");
       this.add(typeof(CM_DLT), false, 0, 200, new System.Object[]{message}, "Delta Check Criteria");
       this.add(typeof(NM), false, 1, 20, new System.Object[]{message}, "Minimum Meaningful Increments");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Segment Type ID(OM2-1).
	///</summary>
	public ST SegmentTypeID
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Sequence Number - Test/ Observation Master File(OM2-2).
	///</summary>
	public NM SequenceNumberTestObservationMasterFile
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
	/// Returns Units of Measure(OM2-3).
	///</summary>
	public CE UnitsOfMeasure
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Range of Decimal Precision(OM2-4).
	///</summary>
	public NM RangeOfDecimalPrecision
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
	/// Returns Corresponding SI Units of Measure(OM2-5).
	///</summary>
	public CE CorrespondingSIUnitsOfMeasure
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns a single repetition of SI Conversion Factor(OM2-6).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TX GetSIConversionFactor(int rep)
	{
			TX ret = null;
			try
			{
			IType t = this.GetField(6, rep);
				ret = (TX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of SI Conversion Factor (OM2-6).
   ///</summary>
  public TX[] GetSIConversionFactor() {
     TX[] ret = null;
    try {
        IType[] t = this.GetField(6);  
        ret = new TX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (TX)t[i];
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
  /// Returns the total repetitions of SI Conversion Factor (OM2-6).
   ///</summary>
  public int SIConversionFactorRepetitionsUsed
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
	/// Returns a single repetition of Reference (normal) range - ordinal and continuous observations(OM2-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CM_RFR GetReferenceNormalRangeOrdinalContinuousObservations(int rep)
	{
			CM_RFR ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (CM_RFR)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Reference (normal) range - ordinal and continuous observations (OM2-7).
   ///</summary>
  public CM_RFR[] GetReferenceNormalRangeOrdinalContinuousObservations() {
     CM_RFR[] ret = null;
    try {
        IType[] t = this.GetField(7);  
        ret = new CM_RFR[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CM_RFR)t[i];
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
  /// Returns the total repetitions of Reference (normal) range - ordinal and continuous observations (OM2-7).
   ///</summary>
  public int ReferenceNormalRangeOrdinalContinuousObservationsRepetitionsUsed
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
	/// Returns Critical range for ordinal and continuous observations(OM2-8).
	///</summary>
	public CM_RANGE CriticalRangeForOrdinalAndContinuousObservations
	{
		get{
			CM_RANGE ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (CM_RANGE)t;
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
	/// Returns Absolute range for ordinal and continuous observations(OM2-9).
	///</summary>
	public CM_ABS_RANGE AbsoluteRangeForOrdinalAndContinuousObservations
	{
		get{
			CM_ABS_RANGE ret = null;
			try
			{
			IType t = this.GetField(9, 0);
				ret = (CM_ABS_RANGE)t;
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
	/// Returns a single repetition of Delta Check Criteria(OM2-10).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CM_DLT GetDeltaCheckCriteria(int rep)
	{
			CM_DLT ret = null;
			try
			{
			IType t = this.GetField(10, rep);
				ret = (CM_DLT)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Delta Check Criteria (OM2-10).
   ///</summary>
  public CM_DLT[] GetDeltaCheckCriteria() {
     CM_DLT[] ret = null;
    try {
        IType[] t = this.GetField(10);  
        ret = new CM_DLT[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CM_DLT)t[i];
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
  /// Returns the total repetitions of Delta Check Criteria (OM2-10).
   ///</summary>
  public int DeltaCheckCriteriaRepetitionsUsed
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
	/// Returns Minimum Meaningful Increments(OM2-11).
	///</summary>
	public NM MinimumMeaningfulIncrements
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


}}