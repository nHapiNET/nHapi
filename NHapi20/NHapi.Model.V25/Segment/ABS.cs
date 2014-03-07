using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V25.Segment{

///<summary>
/// Represents an HL7 ABS message segment. 
/// This segment has the following fields:<ol>
///<li>ABS-1: Discharge Care Provider (XCN)</li>
///<li>ABS-2: Transfer Medical Service Code (CE)</li>
///<li>ABS-3: Severity of Illness Code (CE)</li>
///<li>ABS-4: Date/Time of Attestation (TS)</li>
///<li>ABS-5: Attested By (XCN)</li>
///<li>ABS-6: Triage Code (CE)</li>
///<li>ABS-7: Abstract Completion Date/Time (TS)</li>
///<li>ABS-8: Abstracted By (XCN)</li>
///<li>ABS-9: Case Category Code (CE)</li>
///<li>ABS-10: Caesarian Section Indicator (ID)</li>
///<li>ABS-11: Gestation Category Code (CE)</li>
///<li>ABS-12: Gestation Period - Weeks (NM)</li>
///<li>ABS-13: Newborn Code (CE)</li>
///<li>ABS-14: Stillborn Indicator (ID)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class ABS : AbstractSegment  {

  /**
   * Creates a ABS (Abstract) segment object that belongs to the given 
   * message.  
   */
	public ABS(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(XCN), false, 1, 250, new System.Object[]{message}, "Discharge Care Provider");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Transfer Medical Service Code");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Severity of Illness Code");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Date/Time of Attestation");
       this.add(typeof(XCN), false, 1, 250, new System.Object[]{message}, "Attested By");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Triage Code");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Abstract Completion Date/Time");
       this.add(typeof(XCN), false, 1, 250, new System.Object[]{message}, "Abstracted By");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Case Category Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Caesarian Section Indicator");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Gestation Category Code");
       this.add(typeof(NM), false, 1, 3, new System.Object[]{message}, "Gestation Period - Weeks");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Newborn Code");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Stillborn Indicator");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Discharge Care Provider(ABS-1).
	///</summary>
	public XCN DischargeCareProvider
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Transfer Medical Service Code(ABS-2).
	///</summary>
	public CE TransferMedicalServiceCode
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
	/// Returns Severity of Illness Code(ABS-3).
	///</summary>
	public CE SeverityOfIllnessCode
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
	/// Returns Date/Time of Attestation(ABS-4).
	///</summary>
	public TS DateTimeOfAttestation
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
	/// Returns Attested By(ABS-5).
	///</summary>
	public XCN AttestedBy
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Triage Code(ABS-6).
	///</summary>
	public CE TriageCode
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
	/// Returns Abstract Completion Date/Time(ABS-7).
	///</summary>
	public TS AbstractCompletionDateTime
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Abstracted By(ABS-8).
	///</summary>
	public XCN AbstractedBy
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Case Category Code(ABS-9).
	///</summary>
	public CE CaseCategoryCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Caesarian Section Indicator(ABS-10).
	///</summary>
	public ID CaesarianSectionIndicator
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
	/// Returns Gestation Category Code(ABS-11).
	///</summary>
	public CE GestationCategoryCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Gestation Period - Weeks(ABS-12).
	///</summary>
	public NM GestationPeriodWeeks
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Newborn Code(ABS-13).
	///</summary>
	public CE NewbornCode
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Stillborn Indicator(ABS-14).
	///</summary>
	public ID StillbornIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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