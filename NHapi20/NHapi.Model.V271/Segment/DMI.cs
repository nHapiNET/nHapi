using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V271.Segment{

///<summary>
/// Represents an HL7 DMI message segment. 
/// This segment has the following fields:<ol>
///<li>DMI-1: Diagnostic Related Group (CNE)</li>
///<li>DMI-2: Major Diagnostic Category (CNE)</li>
///<li>DMI-3: Lower and Upper Trim Points (NR)</li>
///<li>DMI-4: Average Length of Stay (NM)</li>
///<li>DMI-5: Relative Weight (NM)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class DMI : AbstractSegment  {

  /**
   * Creates a DMI (DRG Master File Information) segment object that belongs to the given 
   * message.  
   */
	public DMI(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Diagnostic Related Group");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Major Diagnostic Category");
       this.add(typeof(NR), false, 1, 0, new System.Object[]{message}, "Lower and Upper Trim Points");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Average Length of Stay");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Relative Weight");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Diagnostic Related Group(DMI-1).
	///</summary>
	public CNE DiagnosticRelatedGroup
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (CNE)t;
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
	/// Returns Major Diagnostic Category(DMI-2).
	///</summary>
	public CNE MajorDiagnosticCategory
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(2, 0);
				ret = (CNE)t;
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
	/// Returns Lower and Upper Trim Points(DMI-3).
	///</summary>
	public NR LowerAndUpperTrimPoints
	{
		get{
			NR ret = null;
			try
			{
			IType t = this.GetField(3, 0);
				ret = (NR)t;
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
	/// Returns Average Length of Stay(DMI-4).
	///</summary>
	public NM AverageLengthOfStay
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Relative Weight(DMI-5).
	///</summary>
	public NM RelativeWeight
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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


}}