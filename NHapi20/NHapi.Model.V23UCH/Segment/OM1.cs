using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V23UCH.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V23UCH.Segment{

///<summary>
/// Represents an HL7 OM1 message segment. 
/// This segment has the following fields:<ol>
///<li>OM1-1: Sequence Number - Test/ Observation Master File (NM)</li>
///<li>OM1-2: Producer's Test/Observation ID (CE)</li>
///<li>OM1-3: Permitted Data Types (ID)</li>
///<li>OM1-4: Specimen Required (ID)</li>
///<li>OM1-5: Producer ID (CE)</li>
///<li>OM1-6: Observation Description (CE)</li>
///<li>OM1-7: Other Test/Observation IDs for the Observation (CE)</li>
///<li>OM1-8: Other Names (ST)</li>
///<li>OM1-9: Preferred Report Name for the Observation (ST)</li>
///<li>OM1-10: Preferred Short Name or Mnemonic for Observation (ST)</li>
///<li>OM1-11: Preferred Long Name for the Observation (ST)</li>
///<li>OM1-12: Orderability (ID)</li>
///<li>OM1-13: Identity of Instrument Used to Perfrom this Study (CE)</li>
///<li>OM1-14: Coded Representation of Method (CE)</li>
///<li>OM1-15: Portable (ID)</li>
///<li>OM1-16: Observation Producing Department/Section (CE)</li>
///<li>OM1-17: Telephone Number of Section (TN)</li>
///<li>OM1-18: Nature of Test/Observation (ID)</li>
///<li>OM1-19: Report Subheader (CE)</li>
///<li>OM1-20: Report Display Order (ST)</li>
///<li>OM1-21: Date/Time Stamp for any change in Def Attri for Obs (TS)</li>
///<li>OM1-22: Effective Date/Time of Change in Test Proc. that make Results Non-Comparable (TS)</li>
///<li>OM1-23: Typical Turn-Around Time (NM)</li>
///<li>OM1-24: Processing Time (NM)</li>
///<li>OM1-25: Processing Priority (ID)</li>
///<li>OM1-26: Reporting Priority (ID)</li>
///<li>OM1-27: Outside Site(s) Where Observation may be Performed (CE)</li>
///<li>OM1-28: Address of Outside Site(s) (AD)</li>
///<li>OM1-29: Phone Number of Outside Site (TN)</li>
///<li>OM1-30: Confidentiality Code (ID)</li>
///<li>OM1-31: Observations Required to Interpret the Observation (CE)</li>
///<li>OM1-32: Interpretation of Observations (TX)</li>
///<li>OM1-33: Contraindications to Observations (CE)</li>
///<li>OM1-34: Reflex Tests/Observations (CE)</li>
///<li>OM1-35: Rules that Trigger Reflex Testing (ST)</li>
///<li>OM1-36: Fixed Canned Message (CE)</li>
///<li>OM1-37: Patient Preparation (TX)</li>
///<li>OM1-38: Procedure Medication (CE)</li>
///<li>OM1-39: Factors that may Effect the Observation (TX)</li>
///<li>OM1-40: Test/Observation Performance Schedule (ST)</li>
///<li>OM1-41: Description of Test Methods (TX)</li>
///<li>OM1-42: Kind of Quantity Observed (CE)</li>
///<li>OM1-43: Point versus Interval (CE)</li>
///<li>OM1-44: Challenge information (TX)</li>
///<li>OM1-45: Relationship modifier (CE)</li>
///<li>OM1-46: Target anatomic site of test (CE)</li>
///<li>OM1-47: Modality of imaging measurement (CE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class OM1 : AbstractSegment  {

  /**
   * Creates a OM1 (General - fields that apply to most observations) segment object that belongs to the given 
   * message.  
   */
	public OM1(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Sequence Number - Test/ Observation Master File");
       this.add(typeof(CE), true, 1, 200, new System.Object[]{message}, "Producer's Test/Observation ID");
       this.add(typeof(ID), false, 0, 12, new System.Object[]{message, 125}, "Permitted Data Types");
       this.add(typeof(ID), true, 1, 1, new System.Object[]{message, 136}, "Specimen Required");
       this.add(typeof(CE), true, 1, 200, new System.Object[]{message}, "Producer ID");
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Observation Description");
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Other Test/Observation IDs for the Observation");
       this.add(typeof(ST), true, 0, 200, new System.Object[]{message}, "Other Names");
       this.add(typeof(ST), false, 1, 30, new System.Object[]{message}, "Preferred Report Name for the Observation");
       this.add(typeof(ST), false, 1, 8, new System.Object[]{message}, "Preferred Short Name or Mnemonic for Observation");
       this.add(typeof(ST), false, 1, 200, new System.Object[]{message}, "Preferred Long Name for the Observation");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Orderability");
       this.add(typeof(CE), false, 0, 60, new System.Object[]{message}, "Identity of Instrument Used to Perfrom this Study");
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Coded Representation of Method");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Portable");
       this.add(typeof(CE), false, 0, 60, new System.Object[]{message}, "Observation Producing Department/Section");
       this.add(typeof(TN), false, 1, 40, new System.Object[]{message}, "Telephone Number of Section");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 174}, "Nature of Test/Observation");
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Report Subheader");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "Report Display Order");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Date/Time Stamp for any change in Def Attri for Obs");
       this.add(typeof(TS), false, 1, 26, new System.Object[]{message}, "Effective Date/Time of Change in Test Proc. that make Results Non-Comparable");
       this.add(typeof(NM), false, 1, 20, new System.Object[]{message}, "Typical Turn-Around Time");
       this.add(typeof(NM), false, 1, 20, new System.Object[]{message}, "Processing Time");
       this.add(typeof(ID), false, 0, 40, new System.Object[]{message, 168}, "Processing Priority");
       this.add(typeof(ID), false, 1, 5, new System.Object[]{message, 169}, "Reporting Priority");
       this.add(typeof(CE), false, 0, 200, new System.Object[]{message}, "Outside Site(s) Where Observation may be Performed");
       this.add(typeof(AD), false, 1, 1000, new System.Object[]{message}, "Address of Outside Site(s)");
       this.add(typeof(TN), false, 1, 400, new System.Object[]{message}, "Phone Number of Outside Site");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 177}, "Confidentiality Code");
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Observations Required to Interpret the Observation");
       this.add(typeof(TX), false, 1, 65536, new System.Object[]{message}, "Interpretation of Observations");
       this.add(typeof(CE), false, 1, 65536, new System.Object[]{message}, "Contraindications to Observations");
       this.add(typeof(CE), false, 0, 200, new System.Object[]{message}, "Reflex Tests/Observations");
       this.add(typeof(ST), false, 1, 80, new System.Object[]{message}, "Rules that Trigger Reflex Testing");
       this.add(typeof(CE), false, 1, 65536, new System.Object[]{message}, "Fixed Canned Message");
       this.add(typeof(TX), false, 1, 200, new System.Object[]{message}, "Patient Preparation");
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Procedure Medication");
       this.add(typeof(TX), false, 1, 200, new System.Object[]{message}, "Factors that may Effect the Observation");
       this.add(typeof(ST), false, 0, 60, new System.Object[]{message}, "Test/Observation Performance Schedule");
       this.add(typeof(TX), false, 1, 65536, new System.Object[]{message}, "Description of Test Methods");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Kind of Quantity Observed");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Point versus Interval");
       this.add(typeof(TX), false, 1, 200, new System.Object[]{message}, "Challenge information");
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Relationship modifier");
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Target anatomic site of test");
       this.add(typeof(CE), false, 1, 200, new System.Object[]{message}, "Modality of imaging measurement");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Sequence Number - Test/ Observation Master File(OM1-1).
	///</summary>
	public NM SequenceNumberTestObservationMasterFile
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Producer's Test/Observation ID(OM1-2).
	///</summary>
	public CE ProducerSTestObservationID
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
	/// Returns a single repetition of Permitted Data Types(OM1-3).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ID GetPermittedDataTypes(int rep)
	{
			ID ret = null;
			try
			{
			IType t = this.GetField(3, rep);
				ret = (ID)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Permitted Data Types (OM1-3).
   ///</summary>
  public ID[] GetPermittedDataTypes() {
     ID[] ret = null;
    try {
        IType[] t = this.GetField(3);  
        ret = new ID[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (ID)t[i];
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
  /// Returns the total repetitions of Permitted Data Types (OM1-3).
   ///</summary>
  public int PermittedDataTypesRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(3);
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
	/// Returns Specimen Required(OM1-4).
	///</summary>
	public ID SpecimenRequired
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Producer ID(OM1-5).
	///</summary>
	public CE ProducerID
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Observation Description(OM1-6).
	///</summary>
	public CE ObservationDescription
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Other Test/Observation IDs for the Observation(OM1-7).
	///</summary>
	public CE OtherTestObservationIDsForTheObservation
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(7, 0);
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
	/// Returns a single repetition of Other Names(OM1-8).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ST GetOtherNames(int rep)
	{
			ST ret = null;
			try
			{
			IType t = this.GetField(8, rep);
				ret = (ST)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Other Names (OM1-8).
   ///</summary>
  public ST[] GetOtherNames() {
     ST[] ret = null;
    try {
        IType[] t = this.GetField(8);  
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
  /// Returns the total repetitions of Other Names (OM1-8).
   ///</summary>
  public int OtherNamesRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(8);
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
	/// Returns Preferred Report Name for the Observation(OM1-9).
	///</summary>
	public ST PreferredReportNameForTheObservation
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
	/// Returns Preferred Short Name or Mnemonic for Observation(OM1-10).
	///</summary>
	public ST PreferredShortNameOrMnemonicForObservation
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
	/// Returns Preferred Long Name for the Observation(OM1-11).
	///</summary>
	public ST PreferredLongNameForTheObservation
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
	/// Returns Orderability(OM1-12).
	///</summary>
	public ID Orderability
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(12, 0);
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
	/// Returns a single repetition of Identity of Instrument Used to Perfrom this Study(OM1-13).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CE GetIdentityOfInstrumentUsedToPerfromThisStudy(int rep)
	{
			CE ret = null;
			try
			{
			IType t = this.GetField(13, rep);
				ret = (CE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Identity of Instrument Used to Perfrom this Study (OM1-13).
   ///</summary>
  public CE[] GetIdentityOfInstrumentUsedToPerfromThisStudy() {
     CE[] ret = null;
    try {
        IType[] t = this.GetField(13);  
        ret = new CE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CE)t[i];
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
  /// Returns the total repetitions of Identity of Instrument Used to Perfrom this Study (OM1-13).
   ///</summary>
  public int IdentityOfInstrumentUsedToPerfromThisStudyRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(13);
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
	/// Returns Coded Representation of Method(OM1-14).
	///</summary>
	public CE CodedRepresentationOfMethod
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Portable(OM1-15).
	///</summary>
	public ID Portable
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns a single repetition of Observation Producing Department/Section(OM1-16).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CE GetObservationProducingDepartmentSection(int rep)
	{
			CE ret = null;
			try
			{
			IType t = this.GetField(16, rep);
				ret = (CE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Observation Producing Department/Section (OM1-16).
   ///</summary>
  public CE[] GetObservationProducingDepartmentSection() {
     CE[] ret = null;
    try {
        IType[] t = this.GetField(16);  
        ret = new CE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CE)t[i];
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
  /// Returns the total repetitions of Observation Producing Department/Section (OM1-16).
   ///</summary>
  public int ObservationProducingDepartmentSectionRepetitionsUsed
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
	/// Returns Telephone Number of Section(OM1-17).
	///</summary>
	public TN TelephoneNumberOfSection
	{
		get{
			TN ret = null;
			try
			{
			IType t = this.GetField(17, 0);
				ret = (TN)t;
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
	/// Returns Nature of Test/Observation(OM1-18).
	///</summary>
	public ID NatureOfTestObservation
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(18, 0);
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
	/// Returns Report Subheader(OM1-19).
	///</summary>
	public CE ReportSubheader
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(19, 0);
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
	/// Returns Report Display Order(OM1-20).
	///</summary>
	public ST ReportDisplayOrder
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
	/// Returns Date/Time Stamp for any change in Def Attri for Obs(OM1-21).
	///</summary>
	public TS DateTimeStampForAnyChangeInDefAttriForObs
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Effective Date/Time of Change in Test Proc. that make Results Non-Comparable(OM1-22).
	///</summary>
	public TS EffectiveDateTimeOfChangeInTestProcThatMakeResultsNonComparable
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Typical Turn-Around Time(OM1-23).
	///</summary>
	public NM TypicalTurnAroundTime
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Processing Time(OM1-24).
	///</summary>
	public NM ProcessingTime
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns a single repetition of Processing Priority(OM1-25).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ID GetProcessingPriority(int rep)
	{
			ID ret = null;
			try
			{
			IType t = this.GetField(25, rep);
				ret = (ID)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Processing Priority (OM1-25).
   ///</summary>
  public ID[] GetProcessingPriority() {
     ID[] ret = null;
    try {
        IType[] t = this.GetField(25);  
        ret = new ID[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (ID)t[i];
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
  /// Returns the total repetitions of Processing Priority (OM1-25).
   ///</summary>
  public int ProcessingPriorityRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(25);
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
	/// Returns Reporting Priority(OM1-26).
	///</summary>
	public ID ReportingPriority
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(26, 0);
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
	/// Returns a single repetition of Outside Site(s) Where Observation may be Performed(OM1-27).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CE GetOutsideSiteSWhereObservationMayBePerformed(int rep)
	{
			CE ret = null;
			try
			{
			IType t = this.GetField(27, rep);
				ret = (CE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Outside Site(s) Where Observation may be Performed (OM1-27).
   ///</summary>
  public CE[] GetOutsideSiteSWhereObservationMayBePerformed() {
     CE[] ret = null;
    try {
        IType[] t = this.GetField(27);  
        ret = new CE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CE)t[i];
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
  /// Returns the total repetitions of Outside Site(s) Where Observation may be Performed (OM1-27).
   ///</summary>
  public int OutsideSiteSWhereObservationMayBePerformedRepetitionsUsed
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
	/// Returns Address of Outside Site(s)(OM1-28).
	///</summary>
	public AD AddressOfOutsideSiteS
	{
		get{
			AD ret = null;
			try
			{
			IType t = this.GetField(28, 0);
				ret = (AD)t;
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
	/// Returns Phone Number of Outside Site(OM1-29).
	///</summary>
	public TN PhoneNumberOfOutsideSite
	{
		get{
			TN ret = null;
			try
			{
			IType t = this.GetField(29, 0);
				ret = (TN)t;
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
	/// Returns Confidentiality Code(OM1-30).
	///</summary>
	public ID ConfidentialityCode
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
	/// Returns Observations Required to Interpret the Observation(OM1-31).
	///</summary>
	public CE ObservationsRequiredToInterpretTheObservation
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(31, 0);
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
	/// Returns Interpretation of Observations(OM1-32).
	///</summary>
	public TX InterpretationOfObservations
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(32, 0);
				ret = (TX)t;
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
	/// Returns Contraindications to Observations(OM1-33).
	///</summary>
	public CE ContraindicationsToObservations
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(33, 0);
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
	/// Returns a single repetition of Reflex Tests/Observations(OM1-34).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CE GetReflexTestsObservations(int rep)
	{
			CE ret = null;
			try
			{
			IType t = this.GetField(34, rep);
				ret = (CE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Reflex Tests/Observations (OM1-34).
   ///</summary>
  public CE[] GetReflexTestsObservations() {
     CE[] ret = null;
    try {
        IType[] t = this.GetField(34);  
        ret = new CE[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (CE)t[i];
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
  /// Returns the total repetitions of Reflex Tests/Observations (OM1-34).
   ///</summary>
  public int ReflexTestsObservationsRepetitionsUsed
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
	/// Returns Rules that Trigger Reflex Testing(OM1-35).
	///</summary>
	public ST RulesThatTriggerReflexTesting
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(35, 0);
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
	/// Returns Fixed Canned Message(OM1-36).
	///</summary>
	public CE FixedCannedMessage
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(36, 0);
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
	/// Returns Patient Preparation(OM1-37).
	///</summary>
	public TX PatientPreparation
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(37, 0);
				ret = (TX)t;
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
	/// Returns Procedure Medication(OM1-38).
	///</summary>
	public CE ProcedureMedication
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(38, 0);
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
	/// Returns Factors that may Effect the Observation(OM1-39).
	///</summary>
	public TX FactorsThatMayEffectTheObservation
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(39, 0);
				ret = (TX)t;
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
	/// Returns a single repetition of Test/Observation Performance Schedule(OM1-40).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ST GetTestObservationPerformanceSchedule(int rep)
	{
			ST ret = null;
			try
			{
			IType t = this.GetField(40, rep);
				ret = (ST)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Test/Observation Performance Schedule (OM1-40).
   ///</summary>
  public ST[] GetTestObservationPerformanceSchedule() {
     ST[] ret = null;
    try {
        IType[] t = this.GetField(40);  
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
  /// Returns the total repetitions of Test/Observation Performance Schedule (OM1-40).
   ///</summary>
  public int TestObservationPerformanceScheduleRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(40);
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
	/// Returns Description of Test Methods(OM1-41).
	///</summary>
	public TX DescriptionOfTestMethods
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(41, 0);
				ret = (TX)t;
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
	/// Returns Kind of Quantity Observed(OM1-42).
	///</summary>
	public CE KindOfQuantityObserved
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(42, 0);
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
	/// Returns Point versus Interval(OM1-43).
	///</summary>
	public CE PointVersusInterval
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(43, 0);
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
	/// Returns Challenge information(OM1-44).
	///</summary>
	public TX ChallengeInformation
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(44, 0);
				ret = (TX)t;
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
	/// Returns Relationship modifier(OM1-45).
	///</summary>
	public CE RelationshipModifier
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(45, 0);
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
	/// Returns Target anatomic site of test(OM1-46).
	///</summary>
	public CE TargetAnatomicSiteOfTest
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(46, 0);
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
	/// Returns Modality of imaging measurement(OM1-47).
	///</summary>
	public CE ModalityOfImagingMeasurement
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(47, 0);
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


}}