using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V22.Segment{

///<summary>
/// Represents an HL7 GT1 message segment. 
/// This segment has the following fields:<ol>
///<li>GT1-1: Set ID - guarantor (SI)</li>
///<li>GT1-2: Guarantor number (COMP_ID_DIGIT)</li>
///<li>GT1-3: Guarantor name (PN)</li>
///<li>GT1-4: Guarantor spouse name (PN)</li>
///<li>GT1-5: Guarantor address (AD)</li>
///<li>GT1-6: Guarantor phone number - home (TN)</li>
///<li>GT1-7: Guarantor phone number - business (TN)</li>
///<li>GT1-8: Guarantor date of birth (DT)</li>
///<li>GT1-9: Guarantor sex (ID)</li>
///<li>GT1-10: Guarantor type (ID)</li>
///<li>GT1-11: Guarantor relationship (ID)</li>
///<li>GT1-12: Guarantor social security number (ST)</li>
///<li>GT1-13: Guarantor date - begin (DT)</li>
///<li>GT1-14: Guarantor date - end (DT)</li>
///<li>GT1-15: Guarantor priority (NM)</li>
///<li>GT1-16: Guarantor employer name (ST)</li>
///<li>GT1-17: Guarantor employer address (AD)</li>
///<li>GT1-18: Guarantor employ phone number (TN)</li>
///<li>GT1-19: Guarantor employee ID number (ST)</li>
///<li>GT1-20: Guarantor employment status (ID)</li>
///<li>GT1-21: Guarantor organization (ST)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class GT1 : AbstractSegment  {

  /**
   * Creates a GT1 (GUARANTOR) segment object that belongs to the given 
   * message.  
   */
	public GT1(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Set ID - guarantor");
       this.add(typeof(COMP_ID_DIGIT), false, 1, 20, new System.Object[]{message}, "Guarantor number");
       this.add(typeof(PN), true, 1, 48, new System.Object[]{message}, "Guarantor name");
       this.add(typeof(PN), false, 1, 48, new System.Object[]{message}, "Guarantor spouse name");
       this.add(typeof(AD), false, 1, 106, new System.Object[]{message}, "Guarantor address");
       this.add(typeof(TN), false, 3, 40, new System.Object[]{message}, "Guarantor phone number - home");
       this.add(typeof(TN), false, 3, 40, new System.Object[]{message}, "Guarantor phone number - business");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Guarantor date of birth");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 1}, "Guarantor sex");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 68}, "Guarantor type");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 63}, "Guarantor relationship");
       this.add(typeof(ST), false, 1, 11, new System.Object[]{message}, "Guarantor social security number");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Guarantor date - begin");
       this.add(typeof(DT), false, 1, 8, new System.Object[]{message}, "Guarantor date - end");
       this.add(typeof(NM), false, 1, 2, new System.Object[]{message}, "Guarantor priority");
       this.add(typeof(ST), false, 1, 45, new System.Object[]{message}, "Guarantor employer name");
       this.add(typeof(AD), false, 1, 106, new System.Object[]{message}, "Guarantor employer address");
       this.add(typeof(TN), false, 3, 40, new System.Object[]{message}, "Guarantor employ phone number");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "Guarantor employee ID number");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 66}, "Guarantor employment status");
       this.add(typeof(ST), false, 1, 60, new System.Object[]{message}, "Guarantor organization");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - guarantor(GT1-1).
	///</summary>
	public SI SetIDGuarantor
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
	/// Returns Guarantor number(GT1-2).
	///</summary>
	public COMP_ID_DIGIT GuarantorNumber
	{
		get{
			COMP_ID_DIGIT ret = null;
			try
			{
			IType t = this.GetField(2, 0);
				ret = (COMP_ID_DIGIT)t;
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
	/// Returns Guarantor name(GT1-3).
	///</summary>
	public PN GuarantorName
	{
		get{
			PN ret = null;
			try
			{
			IType t = this.GetField(3, 0);
				ret = (PN)t;
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
	/// Returns Guarantor spouse name(GT1-4).
	///</summary>
	public PN GuarantorSpouseName
	{
		get{
			PN ret = null;
			try
			{
			IType t = this.GetField(4, 0);
				ret = (PN)t;
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
	/// Returns Guarantor address(GT1-5).
	///</summary>
	public AD GuarantorAddress
	{
		get{
			AD ret = null;
			try
			{
			IType t = this.GetField(5, 0);
				ret = (AD)t;
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
	/// Returns a single repetition of Guarantor phone number - home(GT1-6).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TN GetGuarantorPhoneNumberHome(int rep)
	{
			TN ret = null;
			try
			{
			IType t = this.GetField(6, rep);
				ret = (TN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Guarantor phone number - home (GT1-6).
   ///</summary>
  public TN[] GetGuarantorPhoneNumberHome() {
     TN[] ret = null;
    try {
        IType[] t = this.GetField(6);  
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
  /// Returns the total repetitions of Guarantor phone number - home (GT1-6).
   ///</summary>
  public int GuarantorPhoneNumberHomeRepetitionsUsed
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
	/// Returns a single repetition of Guarantor phone number - business(GT1-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TN GetGuarantorPhoneNumberBusiness(int rep)
	{
			TN ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (TN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Guarantor phone number - business (GT1-7).
   ///</summary>
  public TN[] GetGuarantorPhoneNumberBusiness() {
     TN[] ret = null;
    try {
        IType[] t = this.GetField(7);  
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
  /// Returns the total repetitions of Guarantor phone number - business (GT1-7).
   ///</summary>
  public int GuarantorPhoneNumberBusinessRepetitionsUsed
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
	/// Returns Guarantor date of birth(GT1-8).
	///</summary>
	public DT GuarantorDateOfBirth
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (DT)t;
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
	/// Returns Guarantor sex(GT1-9).
	///</summary>
	public ID GuarantorSex
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Guarantor type(GT1-10).
	///</summary>
	public ID GuarantorType
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
	/// Returns Guarantor relationship(GT1-11).
	///</summary>
	public ID GuarantorRelationship
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
	/// Returns Guarantor social security number(GT1-12).
	///</summary>
	public ST GuarantorSocialSecurityNumber
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Guarantor date - begin(GT1-13).
	///</summary>
	public DT GuarantorDateBegin
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(13, 0);
				ret = (DT)t;
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
	/// Returns Guarantor date - end(GT1-14).
	///</summary>
	public DT GuarantorDateEnd
	{
		get{
			DT ret = null;
			try
			{
			IType t = this.GetField(14, 0);
				ret = (DT)t;
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
	/// Returns Guarantor priority(GT1-15).
	///</summary>
	public NM GuarantorPriority
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Guarantor employer name(GT1-16).
	///</summary>
	public ST GuarantorEmployerName
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Guarantor employer address(GT1-17).
	///</summary>
	public AD GuarantorEmployerAddress
	{
		get{
			AD ret = null;
			try
			{
			IType t = this.GetField(17, 0);
				ret = (AD)t;
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
	/// Returns a single repetition of Guarantor employ phone number(GT1-18).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TN GetGuarantorEmployPhoneNumber(int rep)
	{
			TN ret = null;
			try
			{
			IType t = this.GetField(18, rep);
				ret = (TN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Guarantor employ phone number (GT1-18).
   ///</summary>
  public TN[] GetGuarantorEmployPhoneNumber() {
     TN[] ret = null;
    try {
        IType[] t = this.GetField(18);  
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
  /// Returns the total repetitions of Guarantor employ phone number (GT1-18).
   ///</summary>
  public int GuarantorEmployPhoneNumberRepetitionsUsed
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
	/// Returns Guarantor employee ID number(GT1-19).
	///</summary>
	public ST GuarantorEmployeeIDNumber
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Guarantor employment status(GT1-20).
	///</summary>
	public ID GuarantorEmploymentStatus
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Guarantor organization(GT1-21).
	///</summary>
	public ST GuarantorOrganization
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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


}}