using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V25.Segment{

///<summary>
/// Represents an HL7 ORG message segment. 
/// This segment has the following fields:<ol>
///<li>ORG-1: Set ID - ORG (SI)</li>
///<li>ORG-2: Organization Unit Code (CE)</li>
///<li>ORG-3: Organization Unit Type Code (CE)</li>
///<li>ORG-4: Primary Org Unit Indicator (ID)</li>
///<li>ORG-5: Practitioner Org Unit Identifier (CX)</li>
///<li>ORG-6: Health Care Provider Type Code (CE)</li>
///<li>ORG-7: Health Care Provider Classification Code (CE)</li>
///<li>ORG-8: Health Care Provider Area of Specialization Code (CE)</li>
///<li>ORG-9: Effective Date Range (DR)</li>
///<li>ORG-10: Employment Status Code (CE)</li>
///<li>ORG-11: Board Approval Indicator (ID)</li>
///<li>ORG-12: Primary Care Physician Indicator (ID)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class ORG : AbstractSegment  {

  /**
   * Creates a ORG (Practitioner Organization Unit) segment object that belongs to the given 
   * message.  
   */
	public ORG(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), true, 1, 60, new System.Object[]{message}, "Set ID - ORG");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Organization Unit Code");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Organization Unit Type Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Primary Org Unit Indicator");
       this.add(typeof(CX), false, 1, 60, new System.Object[]{message}, "Practitioner Org Unit Identifier");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Health Care Provider Type Code");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Health Care Provider Classification Code");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Health Care Provider Area of Specialization Code");
       this.add(typeof(DR), false, 1, 52, new System.Object[]{message}, "Effective Date Range");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Employment Status Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Board Approval Indicator");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Primary Care Physician Indicator");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - ORG(ORG-1).
	///</summary>
	public SI SetIDORG
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
	/// Returns Organization Unit Code(ORG-2).
	///</summary>
	public CE OrganizationUnitCode
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
	/// Returns Organization Unit Type Code(ORG-3).
	///</summary>
	public CE OrganizationUnitTypeCode
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
	/// Returns Primary Org Unit Indicator(ORG-4).
	///</summary>
	public ID PrimaryOrgUnitIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Practitioner Org Unit Identifier(ORG-5).
	///</summary>
	public CX PractitionerOrgUnitIdentifier
	{
		get{
			CX ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Health Care Provider Type Code(ORG-6).
	///</summary>
	public CE HealthCareProviderTypeCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Health Care Provider Classification Code(ORG-7).
	///</summary>
	public CE HealthCareProviderClassificationCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Health Care Provider Area of Specialization Code(ORG-8).
	///</summary>
	public CE HealthCareProviderAreaOfSpecializationCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Effective Date Range(ORG-9).
	///</summary>
	public DR EffectiveDateRange
	{
		get{
			DR ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Employment Status Code(ORG-10).
	///</summary>
	public CE EmploymentStatusCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Board Approval Indicator(ORG-11).
	///</summary>
	public ID BoardApprovalIndicator
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
	/// Returns Primary Care Physician Indicator(ORG-12).
	///</summary>
	public ID PrimaryCarePhysicianIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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