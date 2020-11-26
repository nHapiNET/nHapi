using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V28.Segment{

///<summary>
/// Represents an HL7 BUI message segment. 
/// This segment has the following fields:<ol>
///<li>BUI-1: Set ID - BUI (SI)</li>
///<li>BUI-2: Blood Unit Identifier (EI)</li>
///<li>BUI-3: Blood Unit Type (CWE)</li>
///<li>BUI-4: Blood Unit Weight (NM)</li>
///<li>BUI-5: Weight Units (CNE)</li>
///<li>BUI-6: Blood Unit Volume (NM)</li>
///<li>BUI-7: Volume Units (CNE)</li>
///<li>BUI-8: Container Catalog Number (ST)</li>
///<li>BUI-9: Container Lot Number (ST)</li>
///<li>BUI-10: Container Manufacturer (XON)</li>
///<li>BUI-11: Transport Temperature (NR)</li>
///<li>BUI-12: Transport Temperature Units (CNE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class BUI : AbstractSegment  {

  /**
   * Creates a BUI (Blood Unit Information) segment object that belongs to the given 
   * message.  
   */
	public BUI(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), false, 1, 4, new System.Object[]{message}, "Set ID - BUI");
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Blood Unit Identifier");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Blood Unit Type");
       this.add(typeof(NM), true, 1, 0, new System.Object[]{message}, "Blood Unit Weight");
       this.add(typeof(CNE), true, 1, 0, new System.Object[]{message}, "Weight Units");
       this.add(typeof(NM), true, 1, 0, new System.Object[]{message}, "Blood Unit Volume");
       this.add(typeof(CNE), true, 1, 0, new System.Object[]{message}, "Volume Units");
       this.add(typeof(ST), true, 1, 0, new System.Object[]{message}, "Container Catalog Number");
       this.add(typeof(ST), true, 1, 0, new System.Object[]{message}, "Container Lot Number");
       this.add(typeof(XON), true, 1, 0, new System.Object[]{message}, "Container Manufacturer");
       this.add(typeof(NR), true, 1, 0, new System.Object[]{message}, "Transport Temperature");
       this.add(typeof(CNE), true, 1, 0, new System.Object[]{message}, "Transport Temperature Units");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - BUI(BUI-1).
	///</summary>
	public SI SetIDBUI
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
	/// Returns Blood Unit Identifier(BUI-2).
	///</summary>
	public EI BloodUnitIdentifier
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
	/// Returns Blood Unit Type(BUI-3).
	///</summary>
	public CWE BloodUnitType
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Blood Unit Weight(BUI-4).
	///</summary>
	public NM BloodUnitWeight
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
	/// Returns Weight Units(BUI-5).
	///</summary>
	public CNE WeightUnits
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Blood Unit Volume(BUI-6).
	///</summary>
	public NM BloodUnitVolume
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Volume Units(BUI-7).
	///</summary>
	public CNE VolumeUnits
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Container Catalog Number(BUI-8).
	///</summary>
	public ST ContainerCatalogNumber
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
	/// Returns Container Lot Number(BUI-9).
	///</summary>
	public ST ContainerLotNumber
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
	/// Returns Container Manufacturer(BUI-10).
	///</summary>
	public XON ContainerManufacturer
	{
		get{
			XON ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Transport Temperature(BUI-11).
	///</summary>
	public NR TransportTemperature
	{
		get{
			NR ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns Transport Temperature Units(BUI-12).
	///</summary>
	public CNE TransportTemperatureUnits
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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


}}