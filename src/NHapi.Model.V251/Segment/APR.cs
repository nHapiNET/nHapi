using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V251.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V251.Segment{

///<summary>
/// Represents an HL7 APR message segment. 
/// This segment has the following fields:<ol>
///<li>APR-1: Time Selection Criteria (SCV)</li>
///<li>APR-2: Resource Selection Criteria (SCV)</li>
///<li>APR-3: Location Selection Criteria (SCV)</li>
///<li>APR-4: Slot Spacing Criteria (NM)</li>
///<li>APR-5: Filler Override Criteria (SCV)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class APR : AbstractSegment  {

  /**
   * Creates a APR (Appointment Preferences) segment object that belongs to the given 
   * message.  
   */
	public APR(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SCV), false, 0, 80, new System.Object[]{message}, "Time Selection Criteria");
       this.add(typeof(SCV), false, 0, 80, new System.Object[]{message}, "Resource Selection Criteria");
       this.add(typeof(SCV), false, 0, 80, new System.Object[]{message}, "Location Selection Criteria");
       this.add(typeof(NM), false, 1, 5, new System.Object[]{message}, "Slot Spacing Criteria");
       this.add(typeof(SCV), false, 0, 80, new System.Object[]{message}, "Filler Override Criteria");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns a single repetition of Time Selection Criteria(APR-1).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public SCV GetTimeSelectionCriteria(int rep)
	{
			SCV ret = null;
			try
			{
			IType t = this.GetField(1, rep);
				ret = (SCV)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Time Selection Criteria (APR-1).
   ///</summary>
  public SCV[] GetTimeSelectionCriteria() {
     SCV[] ret = null;
    try {
        IType[] t = this.GetField(1);  
        ret = new SCV[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (SCV)t[i];
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
  /// Returns the total repetitions of Time Selection Criteria (APR-1).
   ///</summary>
  public int TimeSelectionCriteriaRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(1);
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
	/// Returns a single repetition of Resource Selection Criteria(APR-2).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public SCV GetResourceSelectionCriteria(int rep)
	{
			SCV ret = null;
			try
			{
			IType t = this.GetField(2, rep);
				ret = (SCV)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Resource Selection Criteria (APR-2).
   ///</summary>
  public SCV[] GetResourceSelectionCriteria() {
     SCV[] ret = null;
    try {
        IType[] t = this.GetField(2);  
        ret = new SCV[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (SCV)t[i];
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
  /// Returns the total repetitions of Resource Selection Criteria (APR-2).
   ///</summary>
  public int ResourceSelectionCriteriaRepetitionsUsed
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
	/// Returns a single repetition of Location Selection Criteria(APR-3).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public SCV GetLocationSelectionCriteria(int rep)
	{
			SCV ret = null;
			try
			{
			IType t = this.GetField(3, rep);
				ret = (SCV)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Location Selection Criteria (APR-3).
   ///</summary>
  public SCV[] GetLocationSelectionCriteria() {
     SCV[] ret = null;
    try {
        IType[] t = this.GetField(3);  
        ret = new SCV[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (SCV)t[i];
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
  /// Returns the total repetitions of Location Selection Criteria (APR-3).
   ///</summary>
  public int LocationSelectionCriteriaRepetitionsUsed
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
	/// Returns Slot Spacing Criteria(APR-4).
	///</summary>
	public NM SlotSpacingCriteria
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
	/// Returns a single repetition of Filler Override Criteria(APR-5).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public SCV GetFillerOverrideCriteria(int rep)
	{
			SCV ret = null;
			try
			{
			IType t = this.GetField(5, rep);
				ret = (SCV)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Filler Override Criteria (APR-5).
   ///</summary>
  public SCV[] GetFillerOverrideCriteria() {
     SCV[] ret = null;
    try {
        IType[] t = this.GetField(5);  
        ret = new SCV[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (SCV)t[i];
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
  /// Returns the total repetitions of Filler Override Criteria (APR-5).
   ///</summary>
  public int FillerOverrideCriteriaRepetitionsUsed
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

}}