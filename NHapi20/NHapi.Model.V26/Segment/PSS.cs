using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V26.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V26.Segment{

///<summary>
/// Represents an HL7 PSS message segment. 
/// This segment has the following fields:<ol>
///<li>PSS-1: Provider Product/Service Section Number (EI)</li>
///<li>PSS-2: Payer Product/Service Section Number (EI)</li>
///<li>PSS-3: Product/Service Section Sequence Number (SI)</li>
///<li>PSS-4: Billed Amount (CP)</li>
///<li>PSS-5: Section Description or Heading (ST)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class PSS : AbstractSegment  {

  /**
   * Creates a PSS (Product/Service Section) segment object that belongs to the given 
   * message.  
   */
	public PSS(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(EI), true, 1, 73, new System.Object[]{message}, "Provider Product/Service Section Number");
       this.add(typeof(EI), false, 1, 73, new System.Object[]{message}, "Payer Product/Service Section Number");
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Product/Service Section Sequence Number");
       this.add(typeof(CP), true, 1, 254, new System.Object[]{message}, "Billed Amount");
       this.add(typeof(ST), true, 1, 254, new System.Object[]{message}, "Section Description or Heading");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Provider Product/Service Section Number(PSS-1).
	///</summary>
	public EI ProviderProductServiceSectionNumber
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
	/// Returns Payer Product/Service Section Number(PSS-2).
	///</summary>
	public EI PayerProductServiceSectionNumber
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
	/// Returns Product/Service Section Sequence Number(PSS-3).
	///</summary>
	public SI ProductServiceSectionSequenceNumber
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
	/// Returns Billed Amount(PSS-4).
	///</summary>
	public CP BilledAmount
	{
		get{
			CP ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Section Description or Heading(PSS-5).
	///</summary>
	public ST SectionDescriptionOrHeading
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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