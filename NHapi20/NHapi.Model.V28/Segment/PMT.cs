using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V28.Segment{

///<summary>
/// Represents an HL7 PMT message segment. 
/// This segment has the following fields:<ol>
///<li>PMT-1: Payment/Remittance Advice Number (EI)</li>
///<li>PMT-2: Payment/Remittance Effective Date/Time (DTM)</li>
///<li>PMT-3: Payment/Remittance Expiration Date/Time (DTM)</li>
///<li>PMT-4: Payment Method (CWE)</li>
///<li>PMT-5: Payment/Remittance Date/Time (DTM)</li>
///<li>PMT-6: Payment/Remittance Amount (CP)</li>
///<li>PMT-7: Check Number (EI)</li>
///<li>PMT-8: Payee Bank Identification (XON)</li>
///<li>PMT-9: Payee Transit Number (ST)</li>
///<li>PMT-10: Payee Bank Account ID (CX)</li>
///<li>PMT-11: Payment Organization (XON)</li>
///<li>PMT-12: ESR-Code-Line (ST)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class PMT : AbstractSegment  {

  /**
   * Creates a PMT (Payment Information) segment object that belongs to the given 
   * message.  
   */
	public PMT(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Payment/Remittance Advice Number");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Payment/Remittance Effective Date/Time");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Payment/Remittance Expiration Date/Time");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Payment Method");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Payment/Remittance Date/Time");
       this.add(typeof(CP), true, 1, 0, new System.Object[]{message}, "Payment/Remittance Amount");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Check Number");
       this.add(typeof(XON), false, 1, 0, new System.Object[]{message}, "Payee Bank Identification");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Payee Transit Number");
       this.add(typeof(CX), false, 1, 0, new System.Object[]{message}, "Payee Bank Account ID");
       this.add(typeof(XON), true, 1, 0, new System.Object[]{message}, "Payment Organization");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "ESR-Code-Line");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Payment/Remittance Advice Number(PMT-1).
	///</summary>
	public EI PaymentRemittanceAdviceNumber
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Payment/Remittance Effective Date/Time(PMT-2).
	///</summary>
	public DTM PaymentRemittanceEffectiveDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Payment/Remittance Expiration Date/Time(PMT-3).
	///</summary>
	public DTM PaymentRemittanceExpirationDateTime
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
	/// Returns Payment Method(PMT-4).
	///</summary>
	public CWE PaymentMethod
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
	/// Returns Payment/Remittance Date/Time(PMT-5).
	///</summary>
	public DTM PaymentRemittanceDateTime
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
	/// Returns Payment/Remittance Amount(PMT-6).
	///</summary>
	public CP PaymentRemittanceAmount
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Check Number(PMT-7).
	///</summary>
	public EI CheckNumber
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Payee Bank Identification(PMT-8).
	///</summary>
	public XON PayeeBankIdentification
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Payee Transit Number(PMT-9).
	///</summary>
	public ST PayeeTransitNumber
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Payee Bank Account ID(PMT-10).
	///</summary>
	public CX PayeeBankAccountID
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Payment Organization(PMT-11).
	///</summary>
	public XON PaymentOrganization
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns ESR-Code-Line(PMT-12).
	///</summary>
	public ST ESRCodeLine
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


}}