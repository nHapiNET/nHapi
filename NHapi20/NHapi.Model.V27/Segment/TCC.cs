using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V27.Segment{

///<summary>
/// Represents an HL7 TCC message segment. 
/// This segment has the following fields:<ol>
///<li>TCC-1: Universal Service Identifier (CWE)</li>
///<li>TCC-2: Equipment Test Application Identifier (EI)</li>
///<li>TCC-3: Specimen Source (ST)</li>
///<li>TCC-4: Auto-Dilution Factor Default (SN)</li>
///<li>TCC-5: Rerun Dilution Factor Default (SN)</li>
///<li>TCC-6: Pre-Dilution Factor Default (SN)</li>
///<li>TCC-7: Endogenous Content of Pre-Dilution Diluent (SN)</li>
///<li>TCC-8: Inventory Limits Warning Level (NM)</li>
///<li>TCC-9: Automatic Rerun Allowed (ID)</li>
///<li>TCC-10: Automatic Repeat Allowed (ID)</li>
///<li>TCC-11: Automatic Reflex Allowed (ID)</li>
///<li>TCC-12: Equipment Dynamic Range (SN)</li>
///<li>TCC-13: Units (CWE)</li>
///<li>TCC-14: Processing Type (CWE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class TCC : AbstractSegment  {

  /**
   * Creates a TCC (Test Code Configuration) segment object that belongs to the given 
   * message.  
   */
	public TCC(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Universal Service Identifier");
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Equipment Test Application Identifier");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Specimen Source");
       this.add(typeof(SN), false, 1, 0, new System.Object[]{message}, "Auto-Dilution Factor Default");
       this.add(typeof(SN), false, 1, 0, new System.Object[]{message}, "Rerun Dilution Factor Default");
       this.add(typeof(SN), false, 1, 0, new System.Object[]{message}, "Pre-Dilution Factor Default");
       this.add(typeof(SN), false, 1, 0, new System.Object[]{message}, "Endogenous Content of Pre-Dilution Diluent");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Inventory Limits Warning Level");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Automatic Rerun Allowed");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Automatic Repeat Allowed");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Automatic Reflex Allowed");
       this.add(typeof(SN), false, 1, 0, new System.Object[]{message}, "Equipment Dynamic Range");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Units");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Processing Type");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Universal Service Identifier(TCC-1).
	///</summary>
	public CWE UniversalServiceIdentifier
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Equipment Test Application Identifier(TCC-2).
	///</summary>
	public EI EquipmentTestApplicationIdentifier
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
	/// Returns Specimen Source(TCC-3).
	///</summary>
	public ST SpecimenSource
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
	/// Returns Auto-Dilution Factor Default(TCC-4).
	///</summary>
	public SN AutoDilutionFactorDefault
	{
		get{
			SN ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Rerun Dilution Factor Default(TCC-5).
	///</summary>
	public SN RerunDilutionFactorDefault
	{
		get{
			SN ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Pre-Dilution Factor Default(TCC-6).
	///</summary>
	public SN PreDilutionFactorDefault
	{
		get{
			SN ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Endogenous Content of Pre-Dilution Diluent(TCC-7).
	///</summary>
	public SN EndogenousContentOfPreDilutionDiluent
	{
		get{
			SN ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Inventory Limits Warning Level(TCC-8).
	///</summary>
	public NM InventoryLimitsWarningLevel
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
	/// Returns Automatic Rerun Allowed(TCC-9).
	///</summary>
	public ID AutomaticRerunAllowed
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Automatic Repeat Allowed(TCC-10).
	///</summary>
	public ID AutomaticRepeatAllowed
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
	/// Returns Automatic Reflex Allowed(TCC-11).
	///</summary>
	public ID AutomaticReflexAllowed
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
	/// Returns Equipment Dynamic Range(TCC-12).
	///</summary>
	public SN EquipmentDynamicRange
	{
		get{
			SN ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Units(TCC-13).
	///</summary>
	public CWE Units
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
	/// Returns Processing Type(TCC-14).
	///</summary>
	public CWE ProcessingType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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


}}