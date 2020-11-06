using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V27.Segment{

///<summary>
/// Represents an HL7 PSL message segment. 
/// This segment has the following fields:<ol>
///<li>PSL-1: Provider Product/Service Line Item Number (EI)</li>
///<li>PSL-2: Payer Product/Service Line Item Number (EI)</li>
///<li>PSL-3: Product/Service Line Item Sequence Number (SI)</li>
///<li>PSL-4: Provider Tracking ID (EI)</li>
///<li>PSL-5: Payer Tracking ID (EI)</li>
///<li>PSL-6: Product/Service Line Item Status (CWE)</li>
///<li>PSL-7: Product/Service Code (CWE)</li>
///<li>PSL-8: Product/Service Code Modifier (CWE)</li>
///<li>PSL-9: Product/Service Code Description (ST)</li>
///<li>PSL-10: Product/Service Effective Date (DTM)</li>
///<li>PSL-11: Product/Service Expiration Date (DTM)</li>
///<li>PSL-12: Product/Service Quantity (CQ)</li>
///<li>PSL-13: Product/Service Unit Cost (CP)</li>
///<li>PSL-14: Number of Items per Unit (NM)</li>
///<li>PSL-15: Product/Service Gross Amount (CP)</li>
///<li>PSL-16: Product/Service Billed Amount (CP)</li>
///<li>PSL-17: Product/Service Clarification Code Type (CWE)</li>
///<li>PSL-18: Product/Service Clarification Code Value (ST)</li>
///<li>PSL-19: Health Document Reference Identifier (EI)</li>
///<li>PSL-20: Processing Consideration Code (CWE)</li>
///<li>PSL-21: Restricted Disclosure Indicator (ID)</li>
///<li>PSL-22: Related Product/Service Code Indicator (CWE)</li>
///<li>PSL-23: Product/Service Amount for Physician (CP)</li>
///<li>PSL-24: Product/Service Cost Factor (NM)</li>
///<li>PSL-25: Cost Center (CX)</li>
///<li>PSL-26: Billing Period (DR)</li>
///<li>PSL-27: Days without Billing (NM)</li>
///<li>PSL-28: Session-No (NM)</li>
///<li>PSL-29: Executing Physician ID (XCN)</li>
///<li>PSL-30: Responsible Physician ID (XCN)</li>
///<li>PSL-31: Role Executing Physician (CWE)</li>
///<li>PSL-32: Medical Role Executing Physician (CWE)</li>
///<li>PSL-33: Side of body (CWE)</li>
///<li>PSL-34: Number of TP's PP (NM)</li>
///<li>PSL-35: TP-Value PP (CP)</li>
///<li>PSL-36: Internal Scaling Factor PP (NM)</li>
///<li>PSL-37: External Scaling Factor PP (NM)</li>
///<li>PSL-38: Amount PP (CP)</li>
///<li>PSL-39: Number of TP's Technical Part (NM)</li>
///<li>PSL-40: TP-Value Technical Part (CP)</li>
///<li>PSL-41: Internal Scaling Factor Technical Part (NM)</li>
///<li>PSL-42: External Scaling Factor Technical Part (NM)</li>
///<li>PSL-43: Amount Technical Part (CP)</li>
///<li>PSL-44: Total Amount Professional Part + Technical Part (CP)</li>
///<li>PSL-45: VAT-Rate (NM)</li>
///<li>PSL-46: Main-Service (ID)</li>
///<li>PSL-47: Validation (ID)</li>
///<li>PSL-48: Comment (ST)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class PSL : AbstractSegment  {

  /**
   * Creates a PSL (Product/Service Line Item) segment object that belongs to the given 
   * message.  
   */
	public PSL(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Provider Product/Service Line Item Number");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Payer Product/Service Line Item Number");
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Product/Service Line Item Sequence Number");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Provider Tracking ID");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Payer Tracking ID");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Product/Service Line Item Status");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Product/Service Code");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Product/Service Code Modifier");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Product/Service Code Description");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Product/Service Effective Date");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Product/Service Expiration Date");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Product/Service Quantity");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Product/Service Unit Cost");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Number of Items per Unit");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Product/Service Gross Amount");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Product/Service Billed Amount");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Product/Service Clarification Code Type");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Product/Service Clarification Code Value");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Health Document Reference Identifier");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Processing Consideration Code");
       this.add(typeof(ID), true, 1, 4, new System.Object[]{message, 532}, "Restricted Disclosure Indicator");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Related Product/Service Code Indicator");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Product/Service Amount for Physician");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Product/Service Cost Factor");
       this.add(typeof(CX), false, 1, 0, new System.Object[]{message}, "Cost Center");
       this.add(typeof(DR), false, 1, 0, new System.Object[]{message}, "Billing Period");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Days without Billing");
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Session-No");
       this.add(typeof(XCN), false, 1, 0, new System.Object[]{message}, "Executing Physician ID");
       this.add(typeof(XCN), false, 1, 0, new System.Object[]{message}, "Responsible Physician ID");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Role Executing Physician");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Medical Role Executing Physician");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Side of body");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Number of TP's PP");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "TP-Value PP");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Internal Scaling Factor PP");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "External Scaling Factor PP");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Amount PP");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Number of TP's Technical Part");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "TP-Value Technical Part");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Internal Scaling Factor Technical Part");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "External Scaling Factor Technical Part");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Amount Technical Part");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Total Amount Professional Part + Technical Part");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "VAT-Rate");
       this.add(typeof(ID), false, 1, 20, new System.Object[]{message, 0}, "Main-Service");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Validation");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Comment");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Provider Product/Service Line Item Number(PSL-1).
	///</summary>
	public EI ProviderProductServiceLineItemNumber
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
	/// Returns Payer Product/Service Line Item Number(PSL-2).
	///</summary>
	public EI PayerProductServiceLineItemNumber
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Product/Service Line Item Sequence Number(PSL-3).
	///</summary>
	public SI ProductServiceLineItemSequenceNumber
	{
		get{
			SI ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Provider Tracking ID(PSL-4).
	///</summary>
	public EI ProviderTrackingID
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Payer Tracking ID(PSL-5).
	///</summary>
	public EI PayerTrackingID
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Product/Service Line Item Status(PSL-6).
	///</summary>
	public CWE ProductServiceLineItemStatus
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Product/Service Code(PSL-7).
	///</summary>
	public CWE ProductServiceCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Product/Service Code Modifier(PSL-8).
	///</summary>
	public CWE ProductServiceCodeModifier
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Product/Service Code Description(PSL-9).
	///</summary>
	public ST ProductServiceCodeDescription
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
	/// Returns Product/Service Effective Date(PSL-10).
	///</summary>
	public DTM ProductServiceEffectiveDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Product/Service Expiration Date(PSL-11).
	///</summary>
	public DTM ProductServiceExpirationDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Product/Service Quantity(PSL-12).
	///</summary>
	public CQ ProductServiceQuantity
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Product/Service Unit Cost(PSL-13).
	///</summary>
	public CP ProductServiceUnitCost
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Number of Items per Unit(PSL-14).
	///</summary>
	public NM NumberOfItemsPerUnit
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Product/Service Gross Amount(PSL-15).
	///</summary>
	public CP ProductServiceGrossAmount
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Product/Service Billed Amount(PSL-16).
	///</summary>
	public CP ProductServiceBilledAmount
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Product/Service Clarification Code Type(PSL-17).
	///</summary>
	public CWE ProductServiceClarificationCodeType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns Product/Service Clarification Code Value(PSL-18).
	///</summary>
	public ST ProductServiceClarificationCodeValue
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Health Document Reference Identifier(PSL-19).
	///</summary>
	public EI HealthDocumentReferenceIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Processing Consideration Code(PSL-20).
	///</summary>
	public CWE ProcessingConsiderationCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Restricted Disclosure Indicator(PSL-21).
	///</summary>
	public ID RestrictedDisclosureIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Related Product/Service Code Indicator(PSL-22).
	///</summary>
	public CWE RelatedProductServiceCodeIndicator
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Product/Service Amount for Physician(PSL-23).
	///</summary>
	public CP ProductServiceAmountForPhysician
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Product/Service Cost Factor(PSL-24).
	///</summary>
	public NM ProductServiceCostFactor
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Cost Center(PSL-25).
	///</summary>
	public CX CostCenter
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Billing Period(PSL-26).
	///</summary>
	public DR BillingPeriod
	{
		get{
			DR ret = null;
			try
			{
			IType t = this.GetField(26, 0);
				ret = (DR)t;
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
	/// Returns Days without Billing(PSL-27).
	///</summary>
	public NM DaysWithoutBilling
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(27, 0);
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
	/// Returns Session-No(PSL-28).
	///</summary>
	public NM SessionNo
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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
	/// Returns Executing Physician ID(PSL-29).
	///</summary>
	public XCN ExecutingPhysicianID
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(29, 0);
				ret = (XCN)t;
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
	/// Returns Responsible Physician ID(PSL-30).
	///</summary>
	public XCN ResponsiblePhysicianID
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(30, 0);
				ret = (XCN)t;
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
	/// Returns Role Executing Physician(PSL-31).
	///</summary>
	public CWE RoleExecutingPhysician
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(31, 0);
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
	/// Returns Medical Role Executing Physician(PSL-32).
	///</summary>
	public CWE MedicalRoleExecutingPhysician
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(32, 0);
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
	/// Returns Side of body(PSL-33).
	///</summary>
	public CWE SideOfBody
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(33, 0);
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
	/// Returns Number of TP's PP(PSL-34).
	///</summary>
	public NM NumberOfTPSPP
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(34, 0);
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
	/// Returns TP-Value PP(PSL-35).
	///</summary>
	public CP TPValuePP
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(35, 0);
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
	/// Returns Internal Scaling Factor PP(PSL-36).
	///</summary>
	public NM InternalScalingFactorPP
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(36, 0);
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
	/// Returns External Scaling Factor PP(PSL-37).
	///</summary>
	public NM ExternalScalingFactorPP
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(37, 0);
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
	/// Returns Amount PP(PSL-38).
	///</summary>
	public CP AmountPP
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(38, 0);
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
	/// Returns Number of TP's Technical Part(PSL-39).
	///</summary>
	public NM NumberOfTPSTechnicalPart
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(39, 0);
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
	/// Returns TP-Value Technical Part(PSL-40).
	///</summary>
	public CP TPValueTechnicalPart
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(40, 0);
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
	/// Returns Internal Scaling Factor Technical Part(PSL-41).
	///</summary>
	public NM InternalScalingFactorTechnicalPart
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(41, 0);
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
	/// Returns External Scaling Factor Technical Part(PSL-42).
	///</summary>
	public NM ExternalScalingFactorTechnicalPart
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(42, 0);
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
	/// Returns Amount Technical Part(PSL-43).
	///</summary>
	public CP AmountTechnicalPart
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(43, 0);
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
	/// Returns Total Amount Professional Part + Technical Part(PSL-44).
	///</summary>
	public CP TotalAmountProfessionalPartTechnicalPart
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(44, 0);
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
	/// Returns VAT-Rate(PSL-45).
	///</summary>
	public NM VATRate
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(45, 0);
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
	/// Returns Main-Service(PSL-46).
	///</summary>
	public ID MainService
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(46, 0);
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
	/// Returns Validation(PSL-47).
	///</summary>
	public ID Validation
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(47, 0);
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
	/// Returns Comment(PSL-48).
	///</summary>
	public ST Comment
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(48, 0);
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