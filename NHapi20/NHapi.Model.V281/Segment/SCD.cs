using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V281.Segment{

///<summary>
/// Represents an HL7 SCD message segment. 
/// This segment has the following fields:<ol>
///<li>SCD-1: Cycle Start Time (TM)</li>
///<li>SCD-2: Cycle Count (NM)</li>
///<li>SCD-3: Temp Max (CQ)</li>
///<li>SCD-4: Temp Min (CQ)</li>
///<li>SCD-5: Load Number (NM)</li>
///<li>SCD-6: Condition Time (CQ)</li>
///<li>SCD-7: Sterilize Time (CQ)</li>
///<li>SCD-8: Exhaust Time (CQ)</li>
///<li>SCD-9: Total Cycle Time (CQ)</li>
///<li>SCD-10: Device Status (CWE)</li>
///<li>SCD-11: Cycle Start Date/Time (DTM)</li>
///<li>SCD-12: Dry Time (CQ)</li>
///<li>SCD-13: Leak Rate (CQ)</li>
///<li>SCD-14: Control Temperature (CQ)</li>
///<li>SCD-15: Sterilizer Temperature (CQ)</li>
///<li>SCD-16: Cycle Complete Time (TM)</li>
///<li>SCD-17: Under Temperature (CQ)</li>
///<li>SCD-18: Over Temperature (CQ)</li>
///<li>SCD-19: Abort Cycle (CNE)</li>
///<li>SCD-20: Alarm (CNE)</li>
///<li>SCD-21: Long in Charge Phase (CNE)</li>
///<li>SCD-22: Long in Exhaust Phase (CNE)</li>
///<li>SCD-23: Long in Fast Exhaust Phase (CNE)</li>
///<li>SCD-24: Reset (CNE)</li>
///<li>SCD-25: Operator - Unload (XCN)</li>
///<li>SCD-26: Door Open (CNE)</li>
///<li>SCD-27: Reading Failure (CNE)</li>
///<li>SCD-28: Cycle Type (CWE)</li>
///<li>SCD-29: Thermal Rinse Time (CQ)</li>
///<li>SCD-30: Wash Time (CQ)</li>
///<li>SCD-31: Injection Rate (CQ)</li>
///<li>SCD-32: Procedure Code (CNE)</li>
///<li>SCD-33: Patient Identifier List (CX)</li>
///<li>SCD-34: Attending Doctor (XCN)</li>
///<li>SCD-35: Dilution Factor (SN)</li>
///<li>SCD-36: Fill Time (CQ)</li>
///<li>SCD-37: Inlet Temperature (CQ)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class SCD : AbstractSegment  {

  /**
   * Creates a SCD (Anti-Microbial Cycle Data) segment object that belongs to the given 
   * message.  
   */
	public SCD(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(TM), false, 1, 0, new System.Object[]{message}, "Cycle Start Time");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Cycle Count");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Temp Max");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Temp Min");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Load Number");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Condition Time");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Sterilize Time");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Exhaust Time");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Total Cycle Time");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Device Status");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Cycle Start Date/Time");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Dry Time");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Leak Rate");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Control Temperature");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Sterilizer Temperature");
       this.add(typeof(TM), false, 1, 0, new System.Object[]{message}, "Cycle Complete Time");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Under Temperature");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Over Temperature");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Abort Cycle");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Alarm");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Long in Charge Phase");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Long in Exhaust Phase");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Long in Fast Exhaust Phase");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Reset");
       this.add(typeof(XCN), false, 1, 0, new System.Object[]{message}, "Operator - Unload");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Door Open");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Reading Failure");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Cycle Type");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Thermal Rinse Time");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Wash Time");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Injection Rate");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Procedure Code");
       this.add(typeof(CX), false, 0, 0, new System.Object[]{message}, "Patient Identifier List");
       this.add(typeof(XCN), false, 1, 0, new System.Object[]{message}, "Attending Doctor");
       this.add(typeof(SN), false, 1, 0, new System.Object[]{message}, "Dilution Factor");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Fill Time");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Inlet Temperature");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Cycle Start Time(SCD-1).
	///</summary>
	public TM CycleStartTime
	{
		get{
			TM ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (TM)t;
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
	/// Returns Cycle Count(SCD-2).
	///</summary>
	public NM CycleCount
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Temp Max(SCD-3).
	///</summary>
	public CQ TempMax
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Temp Min(SCD-4).
	///</summary>
	public CQ TempMin
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Load Number(SCD-5).
	///</summary>
	public NM LoadNumber
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

	///<summary>
	/// Returns Condition Time(SCD-6).
	///</summary>
	public CQ ConditionTime
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
	/// Returns Sterilize Time(SCD-7).
	///</summary>
	public CQ SterilizeTime
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Exhaust Time(SCD-8).
	///</summary>
	public CQ ExhaustTime
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Total Cycle Time(SCD-9).
	///</summary>
	public CQ TotalCycleTime
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Device Status(SCD-10).
	///</summary>
	public CWE DeviceStatus
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Cycle Start Date/Time(SCD-11).
	///</summary>
	public DTM CycleStartDateTime
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
	/// Returns Dry Time(SCD-12).
	///</summary>
	public CQ DryTime
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
	/// Returns Leak Rate(SCD-13).
	///</summary>
	public CQ LeakRate
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Control Temperature(SCD-14).
	///</summary>
	public CQ ControlTemperature
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Sterilizer Temperature(SCD-15).
	///</summary>
	public CQ SterilizerTemperature
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Cycle Complete Time(SCD-16).
	///</summary>
	public TM CycleCompleteTime
	{
		get{
			TM ret = null;
			try
			{
			IType t = this.GetField(16, 0);
				ret = (TM)t;
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
	/// Returns Under Temperature(SCD-17).
	///</summary>
	public CQ UnderTemperature
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns Over Temperature(SCD-18).
	///</summary>
	public CQ OverTemperature
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Abort Cycle(SCD-19).
	///</summary>
	public CNE AbortCycle
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Alarm(SCD-20).
	///</summary>
	public CNE Alarm
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Long in Charge Phase(SCD-21).
	///</summary>
	public CNE LongInChargePhase
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Long in Exhaust Phase(SCD-22).
	///</summary>
	public CNE LongInExhaustPhase
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Long in Fast Exhaust Phase(SCD-23).
	///</summary>
	public CNE LongInFastExhaustPhase
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Reset(SCD-24).
	///</summary>
	public CNE Reset
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Operator - Unload(SCD-25).
	///</summary>
	public XCN OperatorUnload
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Door Open(SCD-26).
	///</summary>
	public CNE DoorOpen
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(26, 0);
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
	/// Returns Reading Failure(SCD-27).
	///</summary>
	public CNE ReadingFailure
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(27, 0);
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
	/// Returns Cycle Type(SCD-28).
	///</summary>
	public CWE CycleType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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
	/// Returns Thermal Rinse Time(SCD-29).
	///</summary>
	public CQ ThermalRinseTime
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(29, 0);
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
	/// Returns Wash Time(SCD-30).
	///</summary>
	public CQ WashTime
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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
	/// Returns Injection Rate(SCD-31).
	///</summary>
	public CQ InjectionRate
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(31, 0);
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
	/// Returns Procedure Code(SCD-32).
	///</summary>
	public CNE ProcedureCode
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(32, 0);
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
	/// Returns a single repetition of Patient Identifier List(SCD-33).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CX GetPatientIdentifierList(int rep)
	{
			CX ret = null;
			try
			{
			IType t = this.GetField(33, rep);
				ret = (CX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Patient Identifier List (SCD-33).
   ///</summary>
  public CX[] GetPatientIdentifierList() {
     CX[] ret = null;
    try {
        IType[] t = this.GetField(33);  
        ret = new CX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CX)t[i];
        }
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
    } catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
  }
 return ret;
}

  ///<summary>
  /// Returns the total repetitions of Patient Identifier List (SCD-33).
   ///</summary>
  public int PatientIdentifierListRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(33);
    }
catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
        throw new System.Exception("An unexpected error ocurred", he);
} catch (System.Exception cce) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", cce);
        throw new System.Exception("An unexpected error ocurred", cce);
}
}
}
	///<summary>
	/// Returns Attending Doctor(SCD-34).
	///</summary>
	public XCN AttendingDoctor
	{
		get{
			XCN ret = null;
			try
			{
			IType t = this.GetField(34, 0);
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
	/// Returns Dilution Factor(SCD-35).
	///</summary>
	public SN DilutionFactor
	{
		get{
			SN ret = null;
			try
			{
			IType t = this.GetField(35, 0);
				ret = (SN)t;
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
	/// Returns Fill Time(SCD-36).
	///</summary>
	public CQ FillTime
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(36, 0);
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
	/// Returns Inlet Temperature(SCD-37).
	///</summary>
	public CQ InletTemperature
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(37, 0);
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


}}