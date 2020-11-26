using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V27.Segment{

///<summary>
/// Represents an HL7 REL message segment. 
/// This segment has the following fields:<ol>
///<li>REL-1: Set ID -REL (SI)</li>
///<li>REL-2: Relationship Type (CWE)</li>
///<li>REL-3: This Relationship Instance Identifier (EI)</li>
///<li>REL-4: Source Information Instance Identifier (EI)</li>
///<li>REL-5: Target Information Instance Identifier (EI)</li>
///<li>REL-6: Asserting Entity Instance ID (EI)</li>
///<li>REL-7: Asserting Person (XCN)</li>
///<li>REL-8: Asserting Organization (XON)</li>
///<li>REL-9: Assertor Address (XAD)</li>
///<li>REL-10: Assertor Contact (XTN)</li>
///<li>REL-11: Assertion Date Range (DR)</li>
///<li>REL-12: Negation Indicator (ID)</li>
///<li>REL-13: Certainty of Relationship (CWE)</li>
///<li>REL-14: Priority No (NM)</li>
///<li>REL-15: Priority  Sequence No (rel preference for consideration) (NM)</li>
///<li>REL-16: Separability Indicator (ID)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class REL : AbstractSegment  {

  /**
   * Creates a REL (Clinical Relationship Segment) segment object that belongs to the given 
   * message.  
   */
	public REL(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), false, 1, 4, new System.Object[]{message}, "Set ID -REL");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Relationship Type");
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "This Relationship Instance Identifier");
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Source Information Instance Identifier");
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Target Information Instance Identifier");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Asserting Entity Instance ID");
       this.add(typeof(XCN), false, 1, 0, new System.Object[]{message}, "Asserting Person");
       this.add(typeof(XON), false, 1, 0, new System.Object[]{message}, "Asserting Organization");
       this.add(typeof(XAD), false, 1, 0, new System.Object[]{message}, "Assertor Address");
       this.add(typeof(XTN), false, 1, 0, new System.Object[]{message}, "Assertor Contact");
       this.add(typeof(DR), false, 1, 0, new System.Object[]{message}, "Assertion Date Range");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Negation Indicator");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Certainty of Relationship");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Priority No");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Priority  Sequence No (rel preference for consideration)");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Separability Indicator");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID -REL(REL-1).
	///</summary>
	public SI SetIDREL
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
	/// Returns Relationship Type(REL-2).
	///</summary>
	public CWE RelationshipType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns This Relationship Instance Identifier(REL-3).
	///</summary>
	public EI ThisRelationshipInstanceIdentifier
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Source Information Instance Identifier(REL-4).
	///</summary>
	public EI SourceInformationInstanceIdentifier
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
	/// Returns Target Information Instance Identifier(REL-5).
	///</summary>
	public EI TargetInformationInstanceIdentifier
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
	/// Returns Asserting Entity Instance ID(REL-6).
	///</summary>
	public EI AssertingEntityInstanceID
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
	/// Returns Asserting Person(REL-7).
	///</summary>
	public XCN AssertingPerson
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Asserting Organization(REL-8).
	///</summary>
	public XON AssertingOrganization
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
	/// Returns Assertor Address(REL-9).
	///</summary>
	public XAD AssertorAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(9, 0);
				ret = (XAD)t;
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
	/// Returns Assertor Contact(REL-10).
	///</summary>
	public XTN AssertorContact
	{
		get{
			XTN ret = null;
			try
			{
			IType t = this.GetField(10, 0);
				ret = (XTN)t;
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
	/// Returns Assertion Date Range(REL-11).
	///</summary>
	public DR AssertionDateRange
	{
		get{
			DR ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Negation Indicator(REL-12).
	///</summary>
	public ID NegationIndicator
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

	///<summary>
	/// Returns Certainty of Relationship(REL-13).
	///</summary>
	public CWE CertaintyOfRelationship
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Priority No(REL-14).
	///</summary>
	public NM PriorityNo
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
	/// Returns Priority  Sequence No (rel preference for consideration)(REL-15).
	///</summary>
	public NM PrioritySequenceNoRelpreferenceforconsideration
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
	/// Returns Separability Indicator(REL-16).
	///</summary>
	public ID SeparabilityIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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