using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V23.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V23.Segment{

///<summary>
/// Represents an HL7 AUT message segment. 
/// This segment has the following fields:<ol>
///<li>AUT-1: Authorizing Payor, Plan Code (CE)</li>
///<li>AUT-2: Authorizing Payor, Company ID (CE)</li>
///<li>AUT-3: Authorizing Payor, Company Name (ST)</li>
///<li>AUT-4: Authorization Effective Date (TS)</li>
///<li>AUT-5: Authorization Expiration Date (TS)</li>
///<li>AUT-6: Authorization Identifier (EI)</li>
///<li>AUT-7: Reimbursement Limit (CP)</li>
///<li>AUT-8: Requested Number of Treatments (NM)</li>
///<li>AUT-9: Authorized Number of Treatments (NM)</li>
///<li>AUT-10: Process Date (TS)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class AUT : AbstractSegment  {

  /**
   * Creates a AUT (Authorization Information) segment object that belongs to the given 
   * message.  
   */
	public AUT(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Authorizing Payor, Plan Code");
       this.add(typeof(CE), true, 1, 200, new System.Object[]{message}, "Authorizing Payor, Company ID");
       this.add(typeof(ST), false, 1, 45, new System.Object[]{message}, "Authorizing Payor, Company Name");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Authorization Effective Date");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Authorization Expiration Date");
       this.add(typeof(EI), false, 1, 30, new System.Object[]{message}, "Authorization Identifier");
       this.add(typeof(CP), false, 1, 25, new System.Object[]{message}, "Reimbursement Limit");
       this.add(typeof(NM), false, 1, 2, new System.Object[]{message}, "Requested Number of Treatments");
       this.add(typeof(NM), false, 1, 2, new System.Object[]{message}, "Authorized Number of Treatments");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Process Date");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Authorizing Payor, Plan Code(AUT-1).
	///</summary>
	public CE AuthorizingPayorPlanCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Authorizing Payor, Company ID(AUT-2).
	///</summary>
	public CE AuthorizingPayorCompanyID
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Authorizing Payor, Company Name(AUT-3).
	///</summary>
	public ST AuthorizingPayorCompanyName
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Authorization Effective Date(AUT-4).
	///</summary>
	public TS AuthorizationEffectiveDate
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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

	///<summary>
	/// Returns Authorization Expiration Date(AUT-5).
	///</summary>
	public TS AuthorizationExpirationDate
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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

	///<summary>
	/// Returns Authorization Identifier(AUT-6).
	///</summary>
	public EI AuthorizationIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Reimbursement Limit(AUT-7).
	///</summary>
	public CP ReimbursementLimit
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(7, 0);
				ret = (CP)t;
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
	/// Returns Requested Number of Treatments(AUT-8).
	///</summary>
	public NM RequestedNumberOfTreatments
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
	/// Returns Authorized Number of Treatments(AUT-9).
	///</summary>
	public NM AuthorizedNumberOfTreatments
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
	/// Returns Process Date(AUT-10).
	///</summary>
	public TS ProcessDate
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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