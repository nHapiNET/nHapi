using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V271.Segment{

///<summary>
/// Represents an HL7 MFI message segment. 
/// This segment has the following fields:<ol>
///<li>MFI-1: Master File Identifier (CWE)</li>
///<li>MFI-2: Master File Application Identifier (HD)</li>
///<li>MFI-3: File-Level Event Code (ID)</li>
///<li>MFI-4: Entered Date/Time (DTM)</li>
///<li>MFI-5: Effective Date/Time (DTM)</li>
///<li>MFI-6: Response Level Code (ID)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class MFI : AbstractSegment  {

  /**
   * Creates a MFI (Master File Identification) segment object that belongs to the given 
   * message.  
   */
	public MFI(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Master File Identifier");
       this.add(typeof(HD), false, 0, 0, new System.Object[]{message}, "Master File Application Identifier");
       this.add(typeof(ID), true, 1, 3, new System.Object[]{message, 178}, "File-Level Event Code");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Entered Date/Time");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Effective Date/Time");
       this.add(typeof(ID), true, 1, 2, new System.Object[]{message, 179}, "Response Level Code");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Master File Identifier(MFI-1).
	///</summary>
	public CWE MasterFileIdentifier
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns a single repetition of Master File Application Identifier(MFI-2).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public HD GetMasterFileApplicationIdentifier(int rep)
	{
			HD ret = null;
			try
			{
			IType t = this.GetField(2, rep);
				ret = (HD)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Master File Application Identifier (MFI-2).
   ///</summary>
  public HD[] GetMasterFileApplicationIdentifier() {
     HD[] ret = null;
    try {
        IType[] t = this.GetField(2);  
        ret = new HD[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (HD)t[i];
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
  /// Returns the total repetitions of Master File Application Identifier (MFI-2).
   ///</summary>
  public int MasterFileApplicationIdentifierRepetitionsUsed
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
	/// Returns File-Level Event Code(MFI-3).
	///</summary>
	public ID FileLevelEventCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Entered Date/Time(MFI-4).
	///</summary>
	public DTM EnteredDateTime
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
	/// Returns Effective Date/Time(MFI-5).
	///</summary>
	public DTM EffectiveDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Response Level Code(MFI-6).
	///</summary>
	public ID ResponseLevelCode
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


}}