using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V271.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V271.Segment{

///<summary>
/// Represents an HL7 ILT message segment. 
/// This segment has the following fields:<ol>
///<li>ILT-1: Set Id - ILT (SI)</li>
///<li>ILT-2: Inventory Lot Number (ST)</li>
///<li>ILT-3: Inventory Expiration Date (DTM)</li>
///<li>ILT-4: Inventory Received Date (DTM)</li>
///<li>ILT-5: Inventory Received Quantity (NM)</li>
///<li>ILT-6: Inventory Received Quantity Unit (CWE)</li>
///<li>ILT-7: Inventory Received Item Cost (MO)</li>
///<li>ILT-8: Inventory On Hand Date (DTM)</li>
///<li>ILT-9: Inventory On Hand Quantity (NM)</li>
///<li>ILT-10: Inventory On Hand Quantity Unit (CWE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class ILT : AbstractSegment  {

  /**
   * Creates a ILT (Material Lot) segment object that belongs to the given 
   * message.  
   */
	public ILT(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), true, 1, 4, new System.Object[]{message}, "Set Id - ILT");
       this.add(typeof(ST), true, 1, 0, new System.Object[]{message}, "Inventory Lot Number");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Inventory Expiration Date");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Inventory Received Date");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Inventory Received Quantity");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Inventory Received Quantity Unit");
       this.add(typeof(MO), false, 1, 0, new System.Object[]{message}, "Inventory Received Item Cost");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Inventory On Hand Date");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Inventory On Hand Quantity");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Inventory On Hand Quantity Unit");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set Id - ILT(ILT-1).
	///</summary>
	public SI SetIdILT
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
	/// Returns Inventory Lot Number(ILT-2).
	///</summary>
	public ST InventoryLotNumber
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
	/// Returns Inventory Expiration Date(ILT-3).
	///</summary>
	public DTM InventoryExpirationDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Inventory Received Date(ILT-4).
	///</summary>
	public DTM InventoryReceivedDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Inventory Received Quantity(ILT-5).
	///</summary>
	public NM InventoryReceivedQuantity
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
	/// Returns Inventory Received Quantity Unit(ILT-6).
	///</summary>
	public CWE InventoryReceivedQuantityUnit
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
	/// Returns Inventory Received Item Cost(ILT-7).
	///</summary>
	public MO InventoryReceivedItemCost
	{
		get{
			MO ret = null;
			try
			{
			IType t = this.GetField(7, 0);
				ret = (MO)t;
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
	/// Returns Inventory On Hand Date(ILT-8).
	///</summary>
	public DTM InventoryOnHandDate
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Inventory On Hand Quantity(ILT-9).
	///</summary>
	public NM InventoryOnHandQuantity
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Inventory On Hand Quantity Unit(ILT-10).
	///</summary>
	public CWE InventoryOnHandQuantityUnit
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


}}