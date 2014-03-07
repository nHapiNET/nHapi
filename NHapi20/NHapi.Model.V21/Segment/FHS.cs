using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V21.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V21.Segment{

///<summary>
/// Represents an HL7 FHS message segment. 
/// This segment has the following fields:<ol>
///<li>FHS-1: FILE FIELD SEPARATOR (ST)</li>
///<li>FHS-2: FILE ENCODING CHARACTERS (ST)</li>
///<li>FHS-3: FILE SENDING APPLICATION (ST)</li>
///<li>FHS-4: FILE SENDING FACILITY (ST)</li>
///<li>FHS-5: FILE RECEIVING APPLICATION (ST)</li>
///<li>FHS-6: FILE RECEIVING FACILITY (ST)</li>
///<li>FHS-7: DATE/TIME OF FILE CREATION (TS)</li>
///<li>FHS-8: FILE SECURITY (ST)</li>
///<li>FHS-9: FILE NAME/ID (ST)</li>
///<li>FHS-10: FILE HEADER COMMENT (ST)</li>
///<li>FHS-11: FILE CONTROL ID (ST)</li>
///<li>FHS-12: REFERENCE FILE CONTROL ID (ST)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class FHS : AbstractSegment  {

  /**
   * Creates a FHS (FILE HEADER) segment object that belongs to the given 
   * message.  
   */
	public FHS(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(ST), true, 1, 1, new System.Object[]{message}, "FILE FIELD SEPARATOR");
       this.add(typeof(ST), true, 1, 4, new System.Object[]{message}, "FILE ENCODING CHARACTERS");
       this.add(typeof(ST), false, 1, 15, new System.Object[]{message}, "FILE SENDING APPLICATION");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "FILE SENDING FACILITY");
       this.add(typeof(ST), false, 1, 15, new System.Object[]{message}, "FILE RECEIVING APPLICATION");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "FILE RECEIVING FACILITY");
       this.add(typeof(TS), false, 1, 19, new System.Object[]{message}, "DATE/TIME OF FILE CREATION");
       this.add(typeof(ST), false, 1, 40, new System.Object[]{message}, "FILE SECURITY");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "FILE NAME/ID");
       this.add(typeof(ST), false, 1, 80, new System.Object[]{message}, "FILE HEADER COMMENT");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "FILE CONTROL ID");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "REFERENCE FILE CONTROL ID");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns FILE FIELD SEPARATOR(FHS-1).
	///</summary>
	public ST FILEFIELDSEPARATOR
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns FILE ENCODING CHARACTERS(FHS-2).
	///</summary>
	public ST FILEENCODINGCHARACTERS
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
	/// Returns FILE SENDING APPLICATION(FHS-3).
	///</summary>
	public ST FILESENDINGAPPLICATION
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
	/// Returns FILE SENDING FACILITY(FHS-4).
	///</summary>
	public ST FILESENDINGFACILITY
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns FILE RECEIVING APPLICATION(FHS-5).
	///</summary>
	public ST FILERECEIVINGAPPLICATION
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns FILE RECEIVING FACILITY(FHS-6).
	///</summary>
	public ST FILERECEIVINGFACILITY
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
	/// Returns DATE/TIME OF FILE CREATION(FHS-7).
	///</summary>
	public TS DATETIMEOFFILECREATION
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
	/// Returns FILE SECURITY(FHS-8).
	///</summary>
	public ST FILESECURITY
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
	/// Returns FILE NAME/ID(FHS-9).
	///</summary>
	public ST FILENAMEID
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
	/// Returns FILE HEADER COMMENT(FHS-10).
	///</summary>
	public ST FILEHEADERCOMMENT
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns FILE CONTROL ID(FHS-11).
	///</summary>
	public ST FILECONTROLID
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(11, 0);
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
	/// Returns REFERENCE FILE CONTROL ID(FHS-12).
	///</summary>
	public ST REFERENCEFILECONTROLID
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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


}}