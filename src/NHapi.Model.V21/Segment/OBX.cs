using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V21.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V21.Segment{

///<summary>
/// Represents an HL7 OBX message segment. 
/// This segment has the following fields:<ol>
///<li>OBX-1: SET ID - OBSERVATION SIMPLE (SI)</li>
///<li>OBX-2: VALUE TYPE (ID)</li>
///<li>OBX-3: OBSERVATION IDENTIFIER (CE)</li>
///<li>OBX-4: OBSERVATION SUB-ID (NM)</li>
///<li>OBX-5: OBSERVATION RESULTS (ST)</li>
///<li>OBX-6: UNITS (ID)</li>
///<li>OBX-7: REFERENCES RANGE (ST)</li>
///<li>OBX-8: ABNORMAL FLAGS (ST)</li>
///<li>OBX-9: PROBABILITY (NM)</li>
///<li>OBX-10: NATURE OF ABNORMAL TEST (ID)</li>
///<li>OBX-11: OBSERV RESULT STATUS (ID)</li>
///<li>OBX-12: DATE LAST OBS NORMAL VALUES (TS)</li>
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
   * Creates a OBX (RESULT) segment object that belongs to the given 
   * message.  
   */
	public OBX(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), false, 1, 4, new System.Object[]{message}, "SET ID - OBSERVATION SIMPLE");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 125}, "VALUE TYPE");
       this.add(typeof(CE), true, 1, 80, new System.Object[]{message}, "OBSERVATION IDENTIFIER");
       this.add(typeof(NM), false, 1, 20, new System.Object[]{message}, "OBSERVATION SUB-ID");
       this.add(typeof(Varies), true, 1, 65, new System.Object[]{message}, "OBSERVATION RESULTS");
       this.add(typeof(ID), false, 1, 20, new System.Object[]{message, 0}, "UNITS");
       this.add(typeof(ST), false, 1, 60, new System.Object[]{message}, "REFERENCES RANGE");
       this.add(typeof(ST), false, 5, 10, new System.Object[]{message}, "ABNORMAL FLAGS");
       this.add(typeof(NM), false, 1, 5, new System.Object[]{message}, "PROBABILITY");
       this.add(typeof(ID), false, 1, 5, new System.Object[]{message, 80}, "NATURE OF ABNORMAL TEST");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 85}, "OBSERV RESULT STATUS");
       this.add(typeof(TS), false, 1, 19, new System.Object[]{message}, "DATE LAST OBS NORMAL VALUES");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns SET ID - OBSERVATION SIMPLE(OBX-1).
	///</summary>
	public SI SETIDOBSERVATIONSIMPLE
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
	/// Returns VALUE TYPE(OBX-2).
	///</summary>
	public ID VALUETYPE
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
	/// Returns OBSERVATION IDENTIFIER(OBX-3).
	///</summary>
	public CE OBSERVATIONIDENTIFIER
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
	/// Returns OBSERVATION SUB-ID(OBX-4).
	///</summary>
	public NM OBSERVATIONSUBID
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
	/// Returns OBSERVATION RESULTS(OBX-5).
	///</summary>
	public Varies OBSERVATIONRESULTS
	{
			get
			{
				Varies ret = null;
				try
				{
					IType t = this.GetField(5, 0);
					ret = (Varies)t;
				}
				catch (HL7Exception he)
				{
					HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
					throw new System.Exception("An unexpected error ocurred", he);
				}
				catch (System.Exception ex)
				{
					HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
					throw new System.Exception("An unexpected error ocurred", ex);
				}
				return ret;
			}
		}

	///<summary>
	/// Returns UNITS(OBX-6).
	///</summary>
	public ID UNITS
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
	/// Returns REFERENCES RANGE(OBX-7).
	///</summary>
	public ST REFERENCESRANGE
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
	/// Returns a single repetition of ABNORMAL FLAGS(OBX-8).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ST GetABNORMALFLAGS(int rep)
	{
			ST ret = null;
			try
			{
			IType t = this.GetField(8, rep);
				ret = (ST)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of ABNORMAL FLAGS (OBX-8).
   ///</summary>
  public ST[] GetABNORMALFLAGS() {
     ST[] ret = null;
    try {
        IType[] t = this.GetField(8);  
        ret = new ST[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (ST)t[i];
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
  /// Returns the total repetitions of ABNORMAL FLAGS (OBX-8).
   ///</summary>
  public int ABNORMALFLAGSRepetitionsUsed
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
	/// Returns PROBABILITY(OBX-9).
	///</summary>
	public NM PROBABILITY
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
	/// Returns NATURE OF ABNORMAL TEST(OBX-10).
	///</summary>
	public ID NATUREOFABNORMALTEST
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns OBSERV RESULT STATUS(OBX-11).
	///</summary>
	public ID OBSERVRESULTSTATUS
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
	/// Returns DATE LAST OBS NORMAL VALUES(OBX-12).
	///</summary>
	public TS DATELASTOBSNORMALVALUES
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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


}}