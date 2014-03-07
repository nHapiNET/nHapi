using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V23.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V23.Segment{

///<summary>
/// Represents an HL7 MRG message segment. 
/// This segment has the following fields:<ol>
///<li>MRG-1: Prior Patient ID - Internal (CX)</li>
///<li>MRG-2: Prior Alternate Patient ID (CX)</li>
///<li>MRG-3: Prior Patient Account Number (CX)</li>
///<li>MRG-4: Prior Patient ID - External (CX)</li>
///<li>MRG-5: Prior Visit Number (CX)</li>
///<li>MRG-6: Prior Alternate Visit ID (CX)</li>
///<li>MRG-7: Prior Patient Name (CX)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class MRG : AbstractSegment  {

  /**
   * Creates a MRG (Merge patient information) segment object that belongs to the given 
   * message.  
   */
	public MRG(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(CX), true, 0, 20, new System.Object[]{message}, "Prior Patient ID - Internal");
       this.add(typeof(CX), false, 0, 16, new System.Object[]{message}, "Prior Alternate Patient ID");
       this.add(typeof(CX), false, 1, 20, new System.Object[]{message}, "Prior Patient Account Number");
       this.add(typeof(CX), false, 1, 16, new System.Object[]{message}, "Prior Patient ID - External");
       this.add(typeof(CX), false, 1, 0, new System.Object[]{message}, "Prior Visit Number");
       this.add(typeof(CX), false, 1, 0, new System.Object[]{message}, "Prior Alternate Visit ID");
       this.add(typeof(CX), false, 1, 0, new System.Object[]{message}, "Prior Patient Name");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns a single repetition of Prior Patient ID - Internal(MRG-1).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CX GetPriorPatientIDInternal(int rep)
	{
			CX ret = null;
			try
			{
			IType t = this.GetField(1, rep);
				ret = (CX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Prior Patient ID - Internal (MRG-1).
   ///</summary>
  public CX[] GetPriorPatientIDInternal() {
     CX[] ret = null;
    try {
        IType[] t = this.GetField(1);  
        ret = new CX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CX)t[i];
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
  /// Returns the total repetitions of Prior Patient ID - Internal (MRG-1).
   ///</summary>
  public int PriorPatientIDInternalRepetitionsUsed
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
	/// Returns a single repetition of Prior Alternate Patient ID(MRG-2).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CX GetPriorAlternatePatientID(int rep)
	{
			CX ret = null;
			try
			{
			IType t = this.GetField(2, rep);
				ret = (CX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Prior Alternate Patient ID (MRG-2).
   ///</summary>
  public CX[] GetPriorAlternatePatientID() {
     CX[] ret = null;
    try {
        IType[] t = this.GetField(2);  
        ret = new CX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CX)t[i];
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
  /// Returns the total repetitions of Prior Alternate Patient ID (MRG-2).
   ///</summary>
  public int PriorAlternatePatientIDRepetitionsUsed
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
	/// Returns Prior Patient Account Number(MRG-3).
	///</summary>
	public CX PriorPatientAccountNumber
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Prior Patient ID - External(MRG-4).
	///</summary>
	public CX PriorPatientIDExternal
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Prior Visit Number(MRG-5).
	///</summary>
	public CX PriorVisitNumber
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Prior Alternate Visit ID(MRG-6).
	///</summary>
	public CX PriorAlternateVisitID
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Prior Patient Name(MRG-7).
	///</summary>
	public CX PriorPatientName
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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


}}