using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V28.Segment{

///<summary>
/// Represents an HL7 ADJ message segment. 
/// This segment has the following fields:<ol>
///<li>ADJ-1: Provider Adjustment Number (EI)</li>
///<li>ADJ-2: Payer Adjustment Number (EI)</li>
///<li>ADJ-3: Adjustment Sequence Number (SI)</li>
///<li>ADJ-4: Adjustment Category (CWE)</li>
///<li>ADJ-5: Adjustment Amount (CP)</li>
///<li>ADJ-6: Adjustment Quantity (CQ)</li>
///<li>ADJ-7: Adjustment Reason PA (CWE)</li>
///<li>ADJ-8: Adjustment Description (ST)</li>
///<li>ADJ-9: Original Value (NM)</li>
///<li>ADJ-10: Substitute Value (NM)</li>
///<li>ADJ-11: Adjustment Action (CWE)</li>
///<li>ADJ-12: Provider Adjustment Number Cross Reference (EI)</li>
///<li>ADJ-13: Provider Product/Service Line Item Number Cross Reference (EI)</li>
///<li>ADJ-14: Adjustment Date (DTM)</li>
///<li>ADJ-15: Responsible Organization (XON)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class ADJ : AbstractSegment  {

  /**
   * Creates a ADJ (Adjustment) segment object that belongs to the given 
   * message.  
   */
	public ADJ(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Provider Adjustment Number");
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Payer Adjustment Number");
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Adjustment Sequence Number");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Adjustment Category");
       this.add(typeof(CP), false, 1, 0, new System.Object[]{message}, "Adjustment Amount");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Adjustment Quantity");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Adjustment Reason PA");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Adjustment Description");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Original Value");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Substitute Value");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Adjustment Action");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Provider Adjustment Number Cross Reference");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Provider Product/Service Line Item Number Cross Reference");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Adjustment Date");
       this.add(typeof(XON), false, 1, 0, new System.Object[]{message}, "Responsible Organization");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Provider Adjustment Number(ADJ-1).
	///</summary>
	public EI ProviderAdjustmentNumber
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
	/// Returns Payer Adjustment Number(ADJ-2).
	///</summary>
	public EI PayerAdjustmentNumber
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
	/// Returns Adjustment Sequence Number(ADJ-3).
	///</summary>
	public SI AdjustmentSequenceNumber
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
	/// Returns Adjustment Category(ADJ-4).
	///</summary>
	public CWE AdjustmentCategory
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
	/// Returns Adjustment Amount(ADJ-5).
	///</summary>
	public CP AdjustmentAmount
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Adjustment Quantity(ADJ-6).
	///</summary>
	public CQ AdjustmentQuantity
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
	/// Returns Adjustment Reason PA(ADJ-7).
	///</summary>
	public CWE AdjustmentReasonPA
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
	/// Returns Adjustment Description(ADJ-8).
	///</summary>
	public ST AdjustmentDescription
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Original Value(ADJ-9).
	///</summary>
	public NM OriginalValue
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
	/// Returns Substitute Value(ADJ-10).
	///</summary>
	public NM SubstituteValue
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Adjustment Action(ADJ-11).
	///</summary>
	public CWE AdjustmentAction
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Provider Adjustment Number Cross Reference(ADJ-12).
	///</summary>
	public EI ProviderAdjustmentNumberCrossReference
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Provider Product/Service Line Item Number Cross Reference(ADJ-13).
	///</summary>
	public EI ProviderProductServiceLineItemNumberCrossReference
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Adjustment Date(ADJ-14).
	///</summary>
	public DTM AdjustmentDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Responsible Organization(ADJ-15).
	///</summary>
	public XON ResponsibleOrganization
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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


}}