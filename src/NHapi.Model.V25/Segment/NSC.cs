using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V25.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V25.Segment{

///<summary>
/// Represents an HL7 NSC message segment. 
/// This segment has the following fields:<ol>
///<li>NSC-1: Application Change Type (IS)</li>
///<li>NSC-2: Current CPU (ST)</li>
///<li>NSC-3: Current Fileserver (ST)</li>
///<li>NSC-4: Current Application (HD)</li>
///<li>NSC-5: Current Facility (HD)</li>
///<li>NSC-6: New CPU (ST)</li>
///<li>NSC-7: New Fileserver (ST)</li>
///<li>NSC-8: New Application (HD)</li>
///<li>NSC-9: New Facility (HD)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class NSC : AbstractSegment  {

  /**
   * Creates a NSC (Application Status Change) segment object that belongs to the given 
   * message.  
   */
	public NSC(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(IS), true, 1, 4, new System.Object[]{message, 409}, "Application Change Type");
       this.add(typeof(ST), false, 1, 30, new System.Object[]{message}, "Current CPU");
       this.add(typeof(ST), false, 1, 30, new System.Object[]{message}, "Current Fileserver");
       this.add(typeof(HD), false, 1, 30, new System.Object[]{message}, "Current Application");
       this.add(typeof(HD), false, 1, 30, new System.Object[]{message}, "Current Facility");
       this.add(typeof(ST), false, 1, 30, new System.Object[]{message}, "New CPU");
       this.add(typeof(ST), false, 1, 30, new System.Object[]{message}, "New Fileserver");
       this.add(typeof(HD), false, 1, 30, new System.Object[]{message}, "New Application");
       this.add(typeof(HD), false, 1, 30, new System.Object[]{message}, "New Facility");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Application Change Type(NSC-1).
	///</summary>
	public IS ApplicationChangeType
	{
		get{
			IS ret = null;
			try
			{
			IType t = this.GetField(1, 0);
				ret = (IS)t;
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
	/// Returns Current CPU(NSC-2).
	///</summary>
	public ST CurrentCPU
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
	/// Returns Current Fileserver(NSC-3).
	///</summary>
	public ST CurrentFileserver
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
	/// Returns Current Application(NSC-4).
	///</summary>
	public HD CurrentApplication
	{
		get{
			HD ret = null;
			try
			{
			IType t = this.GetField(4, 0);
				ret = (HD)t;
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
	/// Returns Current Facility(NSC-5).
	///</summary>
	public HD CurrentFacility
	{
		get{
			HD ret = null;
			try
			{
			IType t = this.GetField(5, 0);
				ret = (HD)t;
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
	/// Returns New CPU(NSC-6).
	///</summary>
	public ST NewCPU
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns New Fileserver(NSC-7).
	///</summary>
	public ST NewFileserver
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns New Application(NSC-8).
	///</summary>
	public HD NewApplication
	{
		get{
			HD ret = null;
			try
			{
			IType t = this.GetField(8, 0);
				ret = (HD)t;
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
	/// Returns New Facility(NSC-9).
	///</summary>
	public HD NewFacility
	{
		get{
			HD ret = null;
			try
			{
			IType t = this.GetField(9, 0);
				ret = (HD)t;
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