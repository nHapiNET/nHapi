using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V27.Segment{

///<summary>
/// Represents an HL7 OBR message segment. 
/// This segment has the following fields:<ol>
///<li>OBR-1: Set ID - OBR (SI)</li>
///<li>OBR-2: Placer Order Number (EI)</li>
///<li>OBR-3: Filler Order Number (EI)</li>
///<li>OBR-4: Universal Service Identifier (CWE)</li>
///<li>OBR-5: Priority (ST)</li>
///<li>OBR-6: Requested Date/Time (ST)</li>
///<li>OBR-7: Observation Date/Time # (DTM)</li>
///<li>OBR-8: Observation End Date/Time # (DTM)</li>
///<li>OBR-9: Collection Volume * (CQ)</li>
///<li>OBR-10: Collector Identifier * (XCN)</li>
///<li>OBR-11: Specimen Action Code * (ID)</li>
///<li>OBR-12: Danger Code (CWE)</li>
///<li>OBR-13: Relevant Clinical Information (ST)</li>
///<li>OBR-14: Specimen Received Date/Time (DTM)</li>
///<li>OBR-15: Specimen Source (ST)</li>
///<li>OBR-16: Ordering Provider (XCN)</li>
///<li>OBR-17: Order Callback Phone Number (XTN)</li>
///<li>OBR-18: Placer Field 1 (ST)</li>
///<li>OBR-19: Placer Field 2 (ST)</li>
///<li>OBR-20: Filler Field 1 + (ST)</li>
///<li>OBR-21: Filler Field 2 + (ST)</li>
///<li>OBR-22: Results Rpt/Status Chng - Date/Time + (DTM)</li>
///<li>OBR-23: Charge to Practice + (MOC)</li>
///<li>OBR-24: Diagnostic Serv Sect ID (ID)</li>
///<li>OBR-25: Result Status + (ID)</li>
///<li>OBR-26: Parent Result + (PRL)</li>
///<li>OBR-27: Quantity/Timing (ST)</li>
///<li>OBR-28: Result Copies To (XCN)</li>
///<li>OBR-29: Parent (EIP)</li>
///<li>OBR-30: Transportation Mode (ID)</li>
///<li>OBR-31: Reason for Study (CWE)</li>
///<li>OBR-32: Principal Result Interpreter + (NDL)</li>
///<li>OBR-33: Assistant Result Interpreter + (NDL)</li>
///<li>OBR-34: Technician + (NDL)</li>
///<li>OBR-35: Transcriptionist + (NDL)</li>
///<li>OBR-36: Scheduled Date/Time + (DTM)</li>
///<li>OBR-37: Number of Sample Containers * (NM)</li>
///<li>OBR-38: Transport Logistics of Collected Sample * (CWE)</li>
///<li>OBR-39: Collector's Comment * (CWE)</li>
///<li>OBR-40: Transport Arrangement Responsibility (CWE)</li>
///<li>OBR-41: Transport Arranged (ID)</li>
///<li>OBR-42: Escort Required (ID)</li>
///<li>OBR-43: Planned Patient Transport Comment (CWE)</li>
///<li>OBR-44: Procedure Code (CNE)</li>
///<li>OBR-45: Procedure Code Modifier (CNE)</li>
///<li>OBR-46: Placer Supplemental Service Information (CWE)</li>
///<li>OBR-47: Filler Supplemental Service Information (CWE)</li>
///<li>OBR-48: Medically Necessary Duplicate Procedure Reason (CWE)</li>
///<li>OBR-49: Result Handling (CWE)</li>
///<li>OBR-50: Parent Universal Service Identifier (CWE)</li>
///<li>OBR-51: Observation Group ID (EI)</li>
///<li>OBR-52: Parent Observation Group ID (EI)</li>
///<li>OBR-53: Alternate Placer Order Number (CX)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class OBR : AbstractSegment  {

  /**
   * Creates a OBR (Observation Request) segment object that belongs to the given 
   * message.  
   */
	public OBR(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(SI), false, 1, 4, new System.Object[]{message}, "Set ID - OBR");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Placer Order Number");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Filler Order Number");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Universal Service Identifier");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Priority");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Requested Date/Time");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Observation Date/Time #");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Observation End Date/Time #");
       this.add(typeof(CQ), false, 1, 0, new System.Object[]{message}, "Collection Volume *");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Collector Identifier *");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 65}, "Specimen Action Code *");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Danger Code");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Relevant Clinical Information");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Specimen Received Date/Time");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Specimen Source");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Ordering Provider");
       this.add(typeof(XTN), false, 2, 0, new System.Object[]{message}, "Order Callback Phone Number");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Placer Field 1");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Placer Field 2");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Filler Field 1 +");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Filler Field 2 +");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Results Rpt/Status Chng - Date/Time +");
       this.add(typeof(MOC), false, 1, 0, new System.Object[]{message}, "Charge to Practice +");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 74}, "Diagnostic Serv Sect ID");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 123}, "Result Status +");
       this.add(typeof(PRL), false, 1, 0, new System.Object[]{message}, "Parent Result +");
       this.add(typeof(ST), false, 0, 0, new System.Object[]{message}, "Quantity/Timing");
       this.add(typeof(XCN), false, 0, 0, new System.Object[]{message}, "Result Copies To");
       this.add(typeof(EIP), false, 1, 0, new System.Object[]{message}, "Parent");
       this.add(typeof(ID), false, 1, 4, new System.Object[]{message, 124}, "Transportation Mode");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Reason for Study");
       this.add(typeof(NDL), false, 1, 0, new System.Object[]{message}, "Principal Result Interpreter +");
       this.add(typeof(NDL), false, 0, 0, new System.Object[]{message}, "Assistant Result Interpreter +");
       this.add(typeof(NDL), false, 0, 0, new System.Object[]{message}, "Technician +");
       this.add(typeof(NDL), false, 0, 0, new System.Object[]{message}, "Transcriptionist +");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Scheduled Date/Time +");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Number of Sample Containers *");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Transport Logistics of Collected Sample *");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Collector's Comment *");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Transport Arrangement Responsibility");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 224}, "Transport Arranged");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 225}, "Escort Required");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Planned Patient Transport Comment");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Procedure Code");
       this.add(typeof(CNE), false, 0, 0, new System.Object[]{message}, "Procedure Code Modifier");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Placer Supplemental Service Information");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Filler Supplemental Service Information");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Medically Necessary Duplicate Procedure Reason");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Result Handling");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Parent Universal Service Identifier");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Observation Group ID");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Parent Observation Group ID");
       this.add(typeof(CX), false, 0, 0, new System.Object[]{message}, "Alternate Placer Order Number");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Set ID - OBR(OBR-1).
	///</summary>
	public SI SetIDOBR
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
	/// Returns Placer Order Number(OBR-2).
	///</summary>
	public EI PlacerOrderNumber
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
	/// Returns Filler Order Number(OBR-3).
	///</summary>
	public EI FillerOrderNumber
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Universal Service Identifier(OBR-4).
	///</summary>
	public CWE UniversalServiceIdentifier
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
	/// Returns Priority(OBR-5).
	///</summary>
	public ST Priority
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
	/// Returns Requested Date/Time(OBR-6).
	///</summary>
	public ST RequestedDateTime
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
	/// Returns Observation Date/Time #(OBR-7).
	///</summary>
	public DTM ObservationDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns Observation End Date/Time #(OBR-8).
	///</summary>
	public DTM ObservationEndDateTime
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
	/// Returns Collection Volume *(OBR-9).
	///</summary>
	public CQ CollectionVolume
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
	/// Returns a single repetition of Collector Identifier *(OBR-10).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetCollectorIdentifier(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(10, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Collector Identifier * (OBR-10).
   ///</summary>
  public XCN[] GetCollectorIdentifier() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(10);  
        ret = new XCN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XCN)t[i];
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
  /// Returns the total repetitions of Collector Identifier * (OBR-10).
   ///</summary>
  public int CollectorIdentifierRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(10);
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
	/// Returns Specimen Action Code *(OBR-11).
	///</summary>
	public ID SpecimenActionCode
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
	/// Returns Danger Code(OBR-12).
	///</summary>
	public CWE DangerCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns Relevant Clinical Information(OBR-13).
	///</summary>
	public ST RelevantClinicalInformation
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Specimen Received Date/Time(OBR-14).
	///</summary>
	public DTM SpecimenReceivedDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Specimen Source(OBR-15).
	///</summary>
	public ST SpecimenSource
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns a single repetition of Ordering Provider(OBR-16).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetOrderingProvider(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(16, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Ordering Provider (OBR-16).
   ///</summary>
  public XCN[] GetOrderingProvider() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(16);  
        ret = new XCN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XCN)t[i];
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
  /// Returns the total repetitions of Ordering Provider (OBR-16).
   ///</summary>
  public int OrderingProviderRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(16);
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
	/// Returns a single repetition of Order Callback Phone Number(OBR-17).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XTN GetOrderCallbackPhoneNumber(int rep)
	{
			XTN ret = null;
			try
			{
			IType t = this.GetField(17, rep);
				ret = (XTN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Order Callback Phone Number (OBR-17).
   ///</summary>
  public XTN[] GetOrderCallbackPhoneNumber() {
     XTN[] ret = null;
    try {
        IType[] t = this.GetField(17);  
        ret = new XTN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XTN)t[i];
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
  /// Returns the total repetitions of Order Callback Phone Number (OBR-17).
   ///</summary>
  public int OrderCallbackPhoneNumberRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(17);
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
	/// Returns Placer Field 1(OBR-18).
	///</summary>
	public ST PlacerField1
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Placer Field 2(OBR-19).
	///</summary>
	public ST PlacerField2
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Filler Field 1 +(OBR-20).
	///</summary>
	public ST FillerField1
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns Filler Field 2 +(OBR-21).
	///</summary>
	public ST FillerField2
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Results Rpt/Status Chng - Date/Time +(OBR-22).
	///</summary>
	public DTM ResultsRptStatusChngDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Charge to Practice +(OBR-23).
	///</summary>
	public MOC ChargeToPractice
	{
		get{
			MOC ret = null;
			try
			{
			IType t = this.GetField(23, 0);
				ret = (MOC)t;
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
	/// Returns Diagnostic Serv Sect ID(OBR-24).
	///</summary>
	public ID DiagnosticServSectID
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Result Status +(OBR-25).
	///</summary>
	public ID ResultStatus
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Parent Result +(OBR-26).
	///</summary>
	public PRL ParentResult
	{
		get{
			PRL ret = null;
			try
			{
			IType t = this.GetField(26, 0);
				ret = (PRL)t;
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
	/// Returns a single repetition of Quantity/Timing(OBR-27).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ST GetQuantityTiming(int rep)
	{
			ST ret = null;
			try
			{
			IType t = this.GetField(27, rep);
				ret = (ST)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Quantity/Timing (OBR-27).
   ///</summary>
  public ST[] GetQuantityTiming() {
     ST[] ret = null;
    try {
        IType[] t = this.GetField(27);  
        ret = new ST[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (ST)t[i];
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
  /// Returns the total repetitions of Quantity/Timing (OBR-27).
   ///</summary>
  public int QuantityTimingRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(27);
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
	/// Returns a single repetition of Result Copies To(OBR-28).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XCN GetResultCopiesTo(int rep)
	{
			XCN ret = null;
			try
			{
			IType t = this.GetField(28, rep);
				ret = (XCN)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Result Copies To (OBR-28).
   ///</summary>
  public XCN[] GetResultCopiesTo() {
     XCN[] ret = null;
    try {
        IType[] t = this.GetField(28);  
        ret = new XCN[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XCN)t[i];
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
  /// Returns the total repetitions of Result Copies To (OBR-28).
   ///</summary>
  public int ResultCopiesToRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(28);
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
	/// Returns Parent(OBR-29).
	///</summary>
	public EIP Parent
	{
		get{
			EIP ret = null;
			try
			{
			IType t = this.GetField(29, 0);
				ret = (EIP)t;
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
	/// Returns Transportation Mode(OBR-30).
	///</summary>
	public ID TransportationMode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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
	/// Returns a single repetition of Reason for Study(OBR-31).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetReasonForStudy(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(31, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Reason for Study (OBR-31).
   ///</summary>
  public CWE[] GetReasonForStudy() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(31);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
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
  /// Returns the total repetitions of Reason for Study (OBR-31).
   ///</summary>
  public int ReasonForStudyRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(31);
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
	/// Returns Principal Result Interpreter +(OBR-32).
	///</summary>
	public NDL PrincipalResultInterpreter
	{
		get{
			NDL ret = null;
			try
			{
			IType t = this.GetField(32, 0);
				ret = (NDL)t;
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
	/// Returns a single repetition of Assistant Result Interpreter +(OBR-33).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NDL GetAssistantResultInterpreter(int rep)
	{
			NDL ret = null;
			try
			{
			IType t = this.GetField(33, rep);
				ret = (NDL)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Assistant Result Interpreter + (OBR-33).
   ///</summary>
  public NDL[] GetAssistantResultInterpreter() {
     NDL[] ret = null;
    try {
        IType[] t = this.GetField(33);  
        ret = new NDL[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (NDL)t[i];
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
  /// Returns the total repetitions of Assistant Result Interpreter + (OBR-33).
   ///</summary>
  public int AssistantResultInterpreterRepetitionsUsed
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
	/// Returns a single repetition of Technician +(OBR-34).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NDL GetTechnician(int rep)
	{
			NDL ret = null;
			try
			{
			IType t = this.GetField(34, rep);
				ret = (NDL)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Technician + (OBR-34).
   ///</summary>
  public NDL[] GetTechnician() {
     NDL[] ret = null;
    try {
        IType[] t = this.GetField(34);  
        ret = new NDL[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (NDL)t[i];
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
  /// Returns the total repetitions of Technician + (OBR-34).
   ///</summary>
  public int TechnicianRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(34);
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
	/// Returns a single repetition of Transcriptionist +(OBR-35).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public NDL GetTranscriptionist(int rep)
	{
			NDL ret = null;
			try
			{
			IType t = this.GetField(35, rep);
				ret = (NDL)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Transcriptionist + (OBR-35).
   ///</summary>
  public NDL[] GetTranscriptionist() {
     NDL[] ret = null;
    try {
        IType[] t = this.GetField(35);  
        ret = new NDL[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (NDL)t[i];
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
  /// Returns the total repetitions of Transcriptionist + (OBR-35).
   ///</summary>
  public int TranscriptionistRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(35);
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
	/// Returns Scheduled Date/Time +(OBR-36).
	///</summary>
	public DTM ScheduledDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(36, 0);
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
	/// Returns Number of Sample Containers *(OBR-37).
	///</summary>
	public NM NumberOfSampleContainers
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(37, 0);
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
	/// Returns a single repetition of Transport Logistics of Collected Sample *(OBR-38).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetTransportLogisticsOfCollectedSample(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(38, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Transport Logistics of Collected Sample * (OBR-38).
   ///</summary>
  public CWE[] GetTransportLogisticsOfCollectedSample() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(38);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
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
  /// Returns the total repetitions of Transport Logistics of Collected Sample * (OBR-38).
   ///</summary>
  public int TransportLogisticsOfCollectedSampleRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(38);
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
	/// Returns a single repetition of Collector's Comment *(OBR-39).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetCollectorSComment(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(39, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Collector's Comment * (OBR-39).
   ///</summary>
  public CWE[] GetCollectorSComment() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(39);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
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
  /// Returns the total repetitions of Collector's Comment * (OBR-39).
   ///</summary>
  public int CollectorSCommentRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(39);
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
	/// Returns Transport Arrangement Responsibility(OBR-40).
	///</summary>
	public CWE TransportArrangementResponsibility
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(40, 0);
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
	/// Returns Transport Arranged(OBR-41).
	///</summary>
	public ID TransportArranged
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(41, 0);
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
	/// Returns Escort Required(OBR-42).
	///</summary>
	public ID EscortRequired
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(42, 0);
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
	/// Returns a single repetition of Planned Patient Transport Comment(OBR-43).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetPlannedPatientTransportComment(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(43, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Planned Patient Transport Comment (OBR-43).
   ///</summary>
  public CWE[] GetPlannedPatientTransportComment() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(43);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
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
  /// Returns the total repetitions of Planned Patient Transport Comment (OBR-43).
   ///</summary>
  public int PlannedPatientTransportCommentRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(43);
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
	/// Returns Procedure Code(OBR-44).
	///</summary>
	public CNE ProcedureCode
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(44, 0);
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
	/// Returns a single repetition of Procedure Code Modifier(OBR-45).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CNE GetProcedureCodeModifier(int rep)
	{
			CNE ret = null;
			try
			{
			IType t = this.GetField(45, rep);
				ret = (CNE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Procedure Code Modifier (OBR-45).
   ///</summary>
  public CNE[] GetProcedureCodeModifier() {
     CNE[] ret = null;
    try {
        IType[] t = this.GetField(45);  
        ret = new CNE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CNE)t[i];
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
  /// Returns the total repetitions of Procedure Code Modifier (OBR-45).
   ///</summary>
  public int ProcedureCodeModifierRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(45);
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
	/// Returns a single repetition of Placer Supplemental Service Information(OBR-46).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetPlacerSupplementalServiceInformation(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(46, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Placer Supplemental Service Information (OBR-46).
   ///</summary>
  public CWE[] GetPlacerSupplementalServiceInformation() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(46);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
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
  /// Returns the total repetitions of Placer Supplemental Service Information (OBR-46).
   ///</summary>
  public int PlacerSupplementalServiceInformationRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(46);
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
	/// Returns a single repetition of Filler Supplemental Service Information(OBR-47).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetFillerSupplementalServiceInformation(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(47, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Filler Supplemental Service Information (OBR-47).
   ///</summary>
  public CWE[] GetFillerSupplementalServiceInformation() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(47);  
        ret = new CWE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CWE)t[i];
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
  /// Returns the total repetitions of Filler Supplemental Service Information (OBR-47).
   ///</summary>
  public int FillerSupplementalServiceInformationRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(47);
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
	/// Returns Medically Necessary Duplicate Procedure Reason(OBR-48).
	///</summary>
	public CWE MedicallyNecessaryDuplicateProcedureReason
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(48, 0);
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
	/// Returns Result Handling(OBR-49).
	///</summary>
	public CWE ResultHandling
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(49, 0);
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
	/// Returns Parent Universal Service Identifier(OBR-50).
	///</summary>
	public CWE ParentUniversalServiceIdentifier
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(50, 0);
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
	/// Returns Observation Group ID(OBR-51).
	///</summary>
	public EI ObservationGroupID
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(51, 0);
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
	/// Returns Parent Observation Group ID(OBR-52).
	///</summary>
	public EI ParentObservationGroupID
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(52, 0);
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
	/// Returns a single repetition of Alternate Placer Order Number(OBR-53).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CX GetAlternatePlacerOrderNumber(int rep)
	{
			CX ret = null;
			try
			{
			IType t = this.GetField(53, rep);
				ret = (CX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Alternate Placer Order Number (OBR-53).
   ///</summary>
  public CX[] GetAlternatePlacerOrderNumber() {
     CX[] ret = null;
    try {
        IType[] t = this.GetField(53);  
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
  /// Returns the total repetitions of Alternate Placer Order Number (OBR-53).
   ///</summary>
  public int AlternatePlacerOrderNumberRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(53);
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

}}