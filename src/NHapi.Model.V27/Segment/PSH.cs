using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V27.Segment{

///<summary>
/// Represents an HL7 PSH message segment. 
/// This segment has the following fields:<ol>
///<li>PSH-1: Report Type (ST)</li>
///<li>PSH-2: Report Form Identifier (ST)</li>
///<li>PSH-3: Report Date (DTM)</li>
///<li>PSH-4: Report Interval Start Date (DTM)</li>
///<li>PSH-5: Report Interval End Date (DTM)</li>
///<li>PSH-6: Quantity Manufactured (CQ)</li>
///<li>PSH-7: Quantity Distributed (CQ)</li>
///<li>PSH-8: Quantity Distributed Method (ID)</li>
///<li>PSH-9: Quantity Distributed Comment (FT)</li>
///<li>PSH-10: Quantity in Use (CQ)</li>
///<li>PSH-11: Quantity in Use Method (ID)</li>
///<li>PSH-12: Quantity in Use Comment (FT)</li>
///<li>PSH-13: Number of Product Experience Reports Filed by Facility (NM)</li>
///<li>PSH-14: Number of Product Experience Reports Filed by Distributor (NM)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class PSH : AbstractSegment  {

  /**
   * Creates a PSH (Product Summary Header) segment object that belongs to the given 
   * message.  
   */
	public PSH(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(ST), true, 1, 0, new System.Object[]{message}, "Report Type");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Report Form Identifier");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Report Date");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Report Interval Start Date");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Report Interval End Date");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Quantity Manufactured");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Quantity Distributed");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 329}, "Quantity Distributed Method");
       this.add(typeof(FT), false, 1, 0, new System.Object[]{message}, "Quantity Distributed Comment");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Quantity in Use");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 329}, "Quantity in Use Method");
       this.add(typeof(FT), false, 1, 0, new System.Object[]{message}, "Quantity in Use Comment");
       this.add(typeof(NM), false, 8, 0, new System.Object[]{message}, "Number of Product Experience Reports Filed by Facility");
       this.add(typeof(NM), false, 8, 0, new System.Object[]{message}, "Number of Product Experience Reports Filed by Distributor");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Report Type(PSH-1).
	///</summary>
	public ST ReportType
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
	/// Returns Report Form Identifier(PSH-2).
	///</summary>
	public ST ReportFormIdentifier
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Report Date(PSH-3).
	///</summary>
	public DTM ReportDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Report Interval Start Date(PSH-4).
	///</summary>
	public DTM ReportIntervalStartDate
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
	/// Returns Report Interval End Date(PSH-5).
	///</summary>
	public DTM ReportIntervalEndDate
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
	/// Returns Quantity Manufactured(PSH-6).
	///</summary>
	public CQ QuantityManufactured
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(6, 0);
				ret = (CQ)t;
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
	/// Returns Quantity Distributed(PSH-7).
	///</summary>
	public CQ QuantityDistributed
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(7, 0);
				ret = (CQ)t;
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
	/// Returns Quantity Distributed Method(PSH-8).
	///</summary>
	public ID QuantityDistributedMethod
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Quantity Distributed Comment(PSH-9).
	///</summary>
	public FT QuantityDistributedComment
	{
		get{
			FT ret = null;
			try
			{
			IType t = this.GetField(9, 0);
				ret = (FT)t;
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
	/// Returns Quantity in Use(PSH-10).
	///</summary>
	public CQ QuantityInUse
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(10, 0);
				ret = (CQ)t;
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
	/// Returns Quantity in Use Method(PSH-11).
	///</summary>
	public ID QuantityInUseMethod
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
	/// Returns Quantity in Use Comment(PSH-12).
	///</summary>
	public FT QuantityInUseComment
	{
		get{
			FT ret = null;
			try
			{
			IType t = this.GetField(12, 0);
				ret = (FT)t;
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
	/// Returns a single repetition of Number of Product Experience Reports Filed by Facility(PSH-13).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NM GetNumberOfProductExperienceReportsFiledByFacility(int rep)
	{
			NM ret = null;
			try
			{
			IType t = this.GetField(13, rep);
				ret = (NM)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Number of Product Experience Reports Filed by Facility (PSH-13).
   ///</summary>
  public NM[] GetNumberOfProductExperienceReportsFiledByFacility() {
     NM[] ret = null;
    try {
        IType[] t = this.GetField(13);  
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
  /// Returns the total repetitions of Number of Product Experience Reports Filed by Facility (PSH-13).
   ///</summary>
  public int NumberOfProductExperienceReportsFiledByFacilityRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(13);
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
	/// Returns a single repetition of Number of Product Experience Reports Filed by Distributor(PSH-14).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NM GetNumberOfProductExperienceReportsFiledByDistributor(int rep)
	{
			NM ret = null;
			try
			{
			IType t = this.GetField(14, rep);
				ret = (NM)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Number of Product Experience Reports Filed by Distributor (PSH-14).
   ///</summary>
  public NM[] GetNumberOfProductExperienceReportsFiledByDistributor() {
     NM[] ret = null;
    try {
        IType[] t = this.GetField(14);  
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
  /// Returns the total repetitions of Number of Product Experience Reports Filed by Distributor (PSH-14).
   ///</summary>
  public int NumberOfProductExperienceReportsFiledByDistributorRepetitionsUsed
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

}}