using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V281.Segment{

///<summary>
/// Represents an HL7 RXV message segment. 
/// This segment has the following fields:<ol>
///<li>RXV-1: Set ID - RXV (SI)</li>
///<li>RXV-2: Bolus Type (ID)</li>
///<li>RXV-3: Bolus Dose Amount (NM)</li>
///<li>RXV-4: Bolus Dose Amount Units (CWE)</li>
///<li>RXV-5: Bolus Dose Volume (NM)</li>
///<li>RXV-6: Bolus Dose Volume Units (CWE)</li>
///<li>RXV-7: PCA Type (ID)</li>
///<li>RXV-8: PCA Dose Amount (NM)</li>
///<li>RXV-9: PCA Dose Amount Units (CWE)</li>
///<li>RXV-10: PCA Dose Amount Volume (NM)</li>
///<li>RXV-11: PCA Dose Amount Volume Units (CWE)</li>
///<li>RXV-12: Max Dose Amount (NM)</li>
///<li>RXV-13: Max Dose Amount Units (CWE)</li>
///<li>RXV-14: Max Dose Amount Volume (NM)</li>
///<li>RXV-15: Max Dose Amount Volume Units (CWE)</li>
///<li>RXV-16: Max Dose per Time (CQ)</li>
///<li>RXV-17: Lockout Interval (CQ)</li>
///<li>RXV-18: Syringe Manufacturer (CWE)</li>
///<li>RXV-19: Syringe Model Number (CWE)</li>
///<li>RXV-20: Syringe Size (NM)</li>
///<li>RXV-21: Syringe Size Units (CWE)</li>
///<li>RXV-22: Action Code (ID)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class RXV : AbstractSegment  {

  /**
   * Creates a RXV (Pharmacy/Treatment Infusion) segment object that belongs to the given 
   * message.  
   */
	public RXV(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), false, 1, 0, new System.Object[]{message}, "Set ID - RXV");
       this.add(typeof(ID), true, 1, 1, new System.Object[]{message, 917}, "Bolus Type");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Bolus Dose Amount");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Bolus Dose Amount Units");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Bolus Dose Volume");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Bolus Dose Volume Units");
       this.add(typeof(ID), true, 1, 2, new System.Object[]{message, 918}, "PCA Type");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "PCA Dose Amount");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "PCA Dose Amount Units");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "PCA Dose Amount Volume");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "PCA Dose Amount Volume Units");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Max Dose Amount");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Max Dose Amount Units");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Max Dose Amount Volume");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Max Dose Amount Volume Units");
       this.add(typeof(CQ), true, 1, 0, new System.Object[]{message}, "Max Dose per Time");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Lockout Interval");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Syringe Manufacturer");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Syringe Model Number");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Syringe Size");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Syringe Size Units");
       this.add(typeof(ID), false, 1, 0, new System.Object[]{message, 206}, "Action Code");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - RXV(RXV-1).
	///</summary>
	public SI SetIDRXV
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
	/// Returns Bolus Type(RXV-2).
	///</summary>
	public ID BolusType
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Bolus Dose Amount(RXV-3).
	///</summary>
	public NM BolusDoseAmount
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Bolus Dose Amount Units(RXV-4).
	///</summary>
	public CWE BolusDoseAmountUnits
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
	/// Returns Bolus Dose Volume(RXV-5).
	///</summary>
	public NM BolusDoseVolume
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
	/// Returns Bolus Dose Volume Units(RXV-6).
	///</summary>
	public CWE BolusDoseVolumeUnits
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
	/// Returns PCA Type(RXV-7).
	///</summary>
	public ID PCAType
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns PCA Dose Amount(RXV-8).
	///</summary>
	public NM PCADoseAmount
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns PCA Dose Amount Units(RXV-9).
	///</summary>
	public CWE PCADoseAmountUnits
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns PCA Dose Amount Volume(RXV-10).
	///</summary>
	public NM PCADoseAmountVolume
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
	/// Returns PCA Dose Amount Volume Units(RXV-11).
	///</summary>
	public CWE PCADoseAmountVolumeUnits
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
	/// Returns Max Dose Amount(RXV-12).
	///</summary>
	public NM MaxDoseAmount
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
	/// Returns Max Dose Amount Units(RXV-13).
	///</summary>
	public CWE MaxDoseAmountUnits
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
	/// Returns Max Dose Amount Volume(RXV-14).
	///</summary>
	public NM MaxDoseAmountVolume
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
	/// Returns Max Dose Amount Volume Units(RXV-15).
	///</summary>
	public CWE MaxDoseAmountVolumeUnits
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Max Dose per Time(RXV-16).
	///</summary>
	public CQ MaxDosePerTime
	{
		get{
			CQ ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Lockout Interval(RXV-17).
	///</summary>
	public CQ LockoutInterval
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
	/// Returns Syringe Manufacturer(RXV-18).
	///</summary>
	public CWE SyringeManufacturer
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Syringe Model Number(RXV-19).
	///</summary>
	public CWE SyringeModelNumber
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Syringe Size(RXV-20).
	///</summary>
	public NM SyringeSize
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Syringe Size Units(RXV-21).
	///</summary>
	public CWE SyringeSizeUnits
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Action Code(RXV-22).
	///</summary>
	public ID ActionCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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