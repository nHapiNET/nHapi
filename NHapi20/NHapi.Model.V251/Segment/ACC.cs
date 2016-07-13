using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V251.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V251.Segment{

///<summary>
/// Represents an HL7 ACC message segment. 
/// This segment has the following fields:<ol>
///<li>ACC-1: Accident Date/Time (TS)</li>
///<li>ACC-2: Accident Code (CE)</li>
///<li>ACC-3: Accident Location (ST)</li>
///<li>ACC-4: Auto Accident State (CE)</li>
///<li>ACC-5: Accident Job Related Indicator (ID)</li>
///<li>ACC-6: Accident Death Indicator (ID)</li>
///<li>ACC-7: Entered By (XCN)</li>
///<li>ACC-8: Accident Description (ST)</li>
///<li>ACC-9: Brought In By (ST)</li>
///<li>ACC-10: Police Notified Indicator (ID)</li>
///<li>ACC-11: Accident Address (XAD)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class ACC : AbstractSegment  {

  /**
   * Creates a ACC (Accident) segment object that belongs to the given 
   * message.  
   */
	public ACC(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Accident Date/Time");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Accident Code");
       this.add(typeof(ST), false, 1, 25, new System.Object[]{message}, "Accident Location");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Auto Accident State");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Accident Job Related Indicator");
       this.add(typeof(ID), false, 1, 12, new System.Object[]{message, 136}, "Accident Death Indicator");
       this.add(typeof(XCN), false, 1, 250, new System.Object[]{message}, "Entered By");
       this.add(typeof(ST), false, 1, 25, new System.Object[]{message}, "Accident Description");
       this.add(typeof(ST), false, 1, 80, new System.Object[]{message}, "Brought In By");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Police Notified Indicator");
       this.add(typeof(XAD), false, 1, 250, new System.Object[]{message}, "Accident Address");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Accident Date/Time(ACC-1).
	///</summary>
	public TS AccidentDateTime
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Accident Code(ACC-2).
	///</summary>
	public CE AccidentCode
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
	/// Returns Accident Location(ACC-3).
	///</summary>
	public ST AccidentLocation
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
	/// Returns Auto Accident State(ACC-4).
	///</summary>
	public CE AutoAccidentState
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Accident Job Related Indicator(ACC-5).
	///</summary>
	public ID AccidentJobRelatedIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Accident Death Indicator(ACC-6).
	///</summary>
	public ID AccidentDeathIndicator
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Entered By(ACC-7).
	///</summary>
	public XCN EnteredBy
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
	/// Returns Accident Description(ACC-8).
	///</summary>
	public ST AccidentDescription
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
	/// Returns Brought In By(ACC-9).
	///</summary>
	public ST BroughtInBy
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
	/// Returns Police Notified Indicator(ACC-10).
	///</summary>
	public ID PoliceNotifiedIndicator
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
	/// Returns Accident Address(ACC-11).
	///</summary>
	public XAD AccidentAddress
	{
		get{
			XAD ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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


}}