using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V28.Segment{

///<summary>
/// Represents an HL7 SFT message segment. 
/// This segment has the following fields:<ol>
///<li>SFT-1: Software Vendor Organization (XON)</li>
///<li>SFT-2: Software Certified Version or Release Number (ST)</li>
///<li>SFT-3: Software Product Name (ST)</li>
///<li>SFT-4: Software Binary ID (ST)</li>
///<li>SFT-5: Software Product Information (TX)</li>
///<li>SFT-6: Software Install Date (DTM)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class SFT : AbstractSegment  {

  /**
   * Creates a SFT (Software Segment) segment object that belongs to the given 
   * message.  
   */
	public SFT(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(XON), true, 1, 0, new System.Object[]{message}, "Software Vendor Organization");
       this.add(typeof(ST), true, 1, 0, new System.Object[]{message}, "Software Certified Version or Release Number");
       this.add(typeof(ST), true, 1, 0, new System.Object[]{message}, "Software Product Name");
       this.add(typeof(ST), true, 1, 0, new System.Object[]{message}, "Software Binary ID");
       this.add(typeof(TX), false, 1, 0, new System.Object[]{message}, "Software Product Information");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Software Install Date");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Software Vendor Organization(SFT-1).
	///</summary>
	public XON SoftwareVendorOrganization
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Software Certified Version or Release Number(SFT-2).
	///</summary>
	public ST SoftwareCertifiedVersionOrReleaseNumber
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
	/// Returns Software Product Name(SFT-3).
	///</summary>
	public ST SoftwareProductName
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
	/// Returns Software Binary ID(SFT-4).
	///</summary>
	public ST SoftwareBinaryID
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Software Product Information(SFT-5).
	///</summary>
	public TX SoftwareProductInformation
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(5, 0);
				ret = (TX)t;
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
	/// Returns Software Install Date(SFT-6).
	///</summary>
	public DTM SoftwareInstallDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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


}}