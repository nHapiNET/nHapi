using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V281.Segment{

///<summary>
/// Represents an HL7 OM1 message segment. 
/// This segment has the following fields:<ol>
///<li>OM1-1: Sequence Number - Test/Observation Master File (NM)</li>
///<li>OM1-2: Producer's Service/Test/Observation ID (CWE)</li>
///<li>OM1-3: Permitted Data Types (ID)</li>
///<li>OM1-4: Specimen Required (ID)</li>
///<li>OM1-5: Producer ID (CWE)</li>
///<li>OM1-6: Observation Description (TX)</li>
///<li>OM1-7: Other Service/Test/Observation IDs for the Observation (CWE)</li>
///<li>OM1-8: Other Names (ST)</li>
///<li>OM1-9: Preferred Report Name for the Observation (ST)</li>
///<li>OM1-10: Preferred Short Name or Mnemonic for the Observation (ST)</li>
///<li>OM1-11: Preferred Long Name for the Observation (ST)</li>
///<li>OM1-12: Orderability (ID)</li>
///<li>OM1-13: Identity of Instrument Used to Perform this Study (CWE)</li>
///<li>OM1-14: Coded Representation of Method (CWE)</li>
///<li>OM1-15: Portable Device Indicator (ID)</li>
///<li>OM1-16: Observation Producing Department/Section (CWE)</li>
///<li>OM1-17: Telephone Number of Section (XTN)</li>
///<li>OM1-18: Nature of Service/Test/Observation (CWE)</li>
///<li>OM1-19: Report Subheader (CWE)</li>
///<li>OM1-20: Report Display Order (ST)</li>
///<li>OM1-21: Date/Time Stamp for Any Change in Definition for the Observation (DTM)</li>
///<li>OM1-22: Effective Date/Time of Change (DTM)</li>
///<li>OM1-23: Typical Turn-Around Time (NM)</li>
///<li>OM1-24: Processing Time (NM)</li>
///<li>OM1-25: Processing Priority (ID)</li>
///<li>OM1-26: Reporting Priority (ID)</li>
///<li>OM1-27: Outside Site(s) Where Observation May Be Performed (CWE)</li>
///<li>OM1-28: Address of Outside Site(s) (XAD)</li>
///<li>OM1-29: Phone Number of Outside Site (XTN)</li>
///<li>OM1-30: Confidentiality Code (CWE)</li>
///<li>OM1-31: Observations Required to Interpret this Observation (CWE)</li>
///<li>OM1-32: Interpretation of Observations (TX)</li>
///<li>OM1-33: Contraindications to Observations (CWE)</li>
///<li>OM1-34: Reflex Tests/Observations (CWE)</li>
///<li>OM1-35: Rules that Trigger Reflex Testing (TX)</li>
///<li>OM1-36: Fixed Canned Message (CWE)</li>
///<li>OM1-37: Patient Preparation (TX)</li>
///<li>OM1-38: Procedure Medication (CWE)</li>
///<li>OM1-39: Factors that may Affect the Observation (TX)</li>
///<li>OM1-40: Service/Test/Observation Performance Schedule (ST)</li>
///<li>OM1-41: Description of Test Methods (TX)</li>
///<li>OM1-42: Kind of Quantity Observed (CWE)</li>
///<li>OM1-43: Point Versus Interval (CWE)</li>
///<li>OM1-44: Challenge Information (TX)</li>
///<li>OM1-45: Relationship Modifier (CWE)</li>
///<li>OM1-46: Target Anatomic Site Of Test (CWE)</li>
///<li>OM1-47: Modality of Imaging Measurement (CWE)</li>
///<li>OM1-48: Exclusive Test (ID)</li>
///<li>OM1-49: Diagnostic Serv Sect ID (ID)</li>
///<li>OM1-50: Taxonomic Classification Code (CWE)</li>
///<li>OM1-51: Other Names (ST)</li>
///<li>OM1-52: Replacement Producer's Service/Test/Observation ID (CWE)</li>
///<li>OM1-53: Prior Resuts Instructions (TX)</li>
///<li>OM1-54: Special Instructions (TX)</li>
///<li>OM1-55: Test Category (CWE)</li>
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
   * Creates a OM1 (General Segment) segment object that belongs to the given 
   * message.  
   */
	public OM1(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(NM), true, 1, 0, new System.Object[]{message}, "Sequence Number - Test/Observation Master File");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Producer's Service/Test/Observation ID");
       this.add(typeof(ID), false, 0, 3, new System.Object[]{message, 125}, "Permitted Data Types");
       this.add(typeof(ID), true, 1, 1, new System.Object[]{message, 136}, "Specimen Required");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Producer ID");
       this.add(typeof(TX), false, 1, 0, new System.Object[]{message}, "Observation Description");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Other Service/Test/Observation IDs for the Observation");
       this.add(typeof(ST), false, 0, 0, new System.Object[]{message}, "Other Names");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Preferred Report Name for the Observation");
       this.add(typeof(ST), false, 1, 8, new System.Object[]{message}, "Preferred Short Name or Mnemonic for the Observation");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Preferred Long Name for the Observation");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Orderability");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Identity of Instrument Used to Perform this Study");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Coded Representation of Method");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 136}, "Portable Device Indicator");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Observation Producing Department/Section");
       this.add(typeof(XTN), false, 1, 0, new System.Object[]{message}, "Telephone Number of Section");
       this.add(typeof(CWE), true, 1, 1, new System.Object[]{message}, "Nature of Service/Test/Observation");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Report Subheader");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Report Display Order");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Date/Time Stamp for Any Change in Definition for the Observation");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Effective Date/Time of Change");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Typical Turn-Around Time");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Processing Time");
       this.add(typeof(ID), false, 0, 1, new System.Object[]{message, 168}, "Processing Priority");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 169}, "Reporting Priority");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Outside Site(s) Where Observation May Be Performed");
       this.add(typeof(XAD), false, 0, 0, new System.Object[]{message}, "Address of Outside Site(s)");
       this.add(typeof(XTN), false, 1, 0, new System.Object[]{message}, "Phone Number of Outside Site");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Confidentiality Code");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Observations Required to Interpret this Observation");
       this.add(typeof(TX), false, 1, 0, new System.Object[]{message}, "Interpretation of Observations");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Contraindications to Observations");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Reflex Tests/Observations");
       this.add(typeof(TX), false, 0, 0, new System.Object[]{message}, "Rules that Trigger Reflex Testing");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Fixed Canned Message");
       this.add(typeof(TX), false, 0, 0, new System.Object[]{message}, "Patient Preparation");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Procedure Medication");
       this.add(typeof(TX), false, 1, 0, new System.Object[]{message}, "Factors that may Affect the Observation");
       this.add(typeof(ST), false, 0, 0, new System.Object[]{message}, "Service/Test/Observation Performance Schedule");
       this.add(typeof(TX), false, 1, 0, new System.Object[]{message}, "Description of Test Methods");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Kind of Quantity Observed");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Point Versus Interval");
       this.add(typeof(TX), false, 1, 0, new System.Object[]{message}, "Challenge Information");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Relationship Modifier");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Target Anatomic Site Of Test");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Modality of Imaging Measurement");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 919}, "Exclusive Test");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 74}, "Diagnostic Serv Sect ID");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Taxonomic Classification Code");
       this.add(typeof(ST), false, 0, 200, new System.Object[]{message}, "Other Names");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Replacement Producer's Service/Test/Observation ID");
       this.add(typeof(TX), false, 0, 0, new System.Object[]{message}, "Prior Resuts Instructions");
       this.add(typeof(TX), false, 1, 0, new System.Object[]{message}, "Special Instructions");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Test Category");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Sequence Number - Test/Observation Master File(OM1-1).
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
	/// Returns Producer's Service/Test/Observation ID(OM1-2).
	///</summary>
	public CWE ProducerSServiceTestObservationID
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	public CWE ProducerID
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Observation Description(OM1-6).
	///</summary>
	public TX ObservationDescription
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns a single repetition of Other Service/Test/Observation IDs for the Observation(OM1-7).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetOtherServiceTestObservationIDsForTheObservation(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(7, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Other Service/Test/Observation IDs for the Observation (OM1-7).
   ///</summary>
  public CWE[] GetOtherServiceTestObservationIDsForTheObservation() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(7);  
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
  /// Returns the total repetitions of Other Service/Test/Observation IDs for the Observation (OM1-7).
   ///</summary>
  public int OtherServiceTestObservationIDsForTheObservationRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(7);
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
	/// Returns Preferred Short Name or Mnemonic for the Observation(OM1-10).
	///</summary>
	public ST PreferredShortNameOrMnemonicForTheObservation
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
	/// Returns a single repetition of Identity of Instrument Used to Perform this Study(OM1-13).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetIdentityOfInstrumentUsedToPerformThisStudy(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(13, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Identity of Instrument Used to Perform this Study (OM1-13).
   ///</summary>
  public CWE[] GetIdentityOfInstrumentUsedToPerformThisStudy() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(13);  
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
  /// Returns the total repetitions of Identity of Instrument Used to Perform this Study (OM1-13).
   ///</summary>
  public int IdentityOfInstrumentUsedToPerformThisStudyRepetitionsUsed
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
	/// Returns a single repetition of Coded Representation of Method(OM1-14).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetCodedRepresentationOfMethod(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(14, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Coded Representation of Method (OM1-14).
   ///</summary>
  public CWE[] GetCodedRepresentationOfMethod() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(14);  
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
  /// Returns the total repetitions of Coded Representation of Method (OM1-14).
   ///</summary>
  public int CodedRepresentationOfMethodRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(14);
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
	/// Returns Portable Device Indicator(OM1-15).
	///</summary>
	public ID PortableDeviceIndicator
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
	public CWE GetObservationProducingDepartmentSection(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(16, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Observation Producing Department/Section (OM1-16).
   ///</summary>
  public CWE[] GetObservationProducingDepartmentSection() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(16);  
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
	public XTN TelephoneNumberOfSection
	{
		get{
			XTN ret = null;
			try
			{
			IType t = this.GetField(17, 0);
				ret = (XTN)t;
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
	/// Returns Nature of Service/Test/Observation(OM1-18).
	///</summary>
	public CWE NatureOfServiceTestObservation
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
	/// Returns Report Subheader(OM1-19).
	///</summary>
	public CWE ReportSubheader
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
	/// Returns Date/Time Stamp for Any Change in Definition for the Observation(OM1-21).
	///</summary>
	public DTM DateTimeStampForAnyChangeInDefinitionForTheObservation
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(21, 0);
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
	/// Returns Effective Date/Time of Change(OM1-22).
	///</summary>
	public DTM EffectiveDateTimeOfChange
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
	/// Returns a single repetition of Outside Site(s) Where Observation May Be Performed(OM1-27).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetOutsideSiteSWhereObservationMayBePerformed(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(27, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Outside Site(s) Where Observation May Be Performed (OM1-27).
   ///</summary>
  public CWE[] GetOutsideSiteSWhereObservationMayBePerformed() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(27);  
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
  /// Returns the total repetitions of Outside Site(s) Where Observation May Be Performed (OM1-27).
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
	/// Returns a single repetition of Address of Outside Site(s)(OM1-28).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public XAD GetAddressOfOutsideSiteS(int rep)
	{
			XAD ret = null;
			try
			{
			IType t = this.GetField(28, rep);
				ret = (XAD)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Address of Outside Site(s) (OM1-28).
   ///</summary>
  public XAD[] GetAddressOfOutsideSiteS() {
     XAD[] ret = null;
    try {
        IType[] t = this.GetField(28);  
        ret = new XAD[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (XAD)t[i];
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
  /// Returns the total repetitions of Address of Outside Site(s) (OM1-28).
   ///</summary>
  public int AddressOfOutsideSiteSRepetitionsUsed
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
	/// Returns Phone Number of Outside Site(OM1-29).
	///</summary>
	public XTN PhoneNumberOfOutsideSite
	{
		get{
			XTN ret = null;
			try
			{
			IType t = this.GetField(29, 0);
				ret = (XTN)t;
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
	public CWE ConfidentialityCode
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(30, 0);
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
	/// Returns a single repetition of Observations Required to Interpret this Observation(OM1-31).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetObservationsRequiredToInterpretThisObservation(int rep)
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
  /// Returns all repetitions of Observations Required to Interpret this Observation (OM1-31).
   ///</summary>
  public CWE[] GetObservationsRequiredToInterpretThisObservation() {
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
  /// Returns the total repetitions of Observations Required to Interpret this Observation (OM1-31).
   ///</summary>
  public int ObservationsRequiredToInterpretThisObservationRepetitionsUsed
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
	/// Returns a single repetition of Contraindications to Observations(OM1-33).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetContraindicationsToObservations(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(33, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Contraindications to Observations (OM1-33).
   ///</summary>
  public CWE[] GetContraindicationsToObservations() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(33);  
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
  /// Returns the total repetitions of Contraindications to Observations (OM1-33).
   ///</summary>
  public int ContraindicationsToObservationsRepetitionsUsed
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
	/// Returns a single repetition of Reflex Tests/Observations(OM1-34).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetReflexTestsObservations(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(34, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Reflex Tests/Observations (OM1-34).
   ///</summary>
  public CWE[] GetReflexTestsObservations() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(34);  
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
	/// Returns a single repetition of Rules that Trigger Reflex Testing(OM1-35).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TX GetRulesThatTriggerReflexTesting(int rep)
	{
			TX ret = null;
			try
			{
			IType t = this.GetField(35, rep);
				ret = (TX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Rules that Trigger Reflex Testing (OM1-35).
   ///</summary>
  public TX[] GetRulesThatTriggerReflexTesting() {
     TX[] ret = null;
    try {
        IType[] t = this.GetField(35);  
        ret = new TX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (TX)t[i];
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
  /// Returns the total repetitions of Rules that Trigger Reflex Testing (OM1-35).
   ///</summary>
  public int RulesThatTriggerReflexTestingRepetitionsUsed
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
	/// Returns a single repetition of Fixed Canned Message(OM1-36).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetFixedCannedMessage(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(36, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Fixed Canned Message (OM1-36).
   ///</summary>
  public CWE[] GetFixedCannedMessage() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(36);  
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
  /// Returns the total repetitions of Fixed Canned Message (OM1-36).
   ///</summary>
  public int FixedCannedMessageRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(36);
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
	/// Returns a single repetition of Patient Preparation(OM1-37).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TX GetPatientPreparation(int rep)
	{
			TX ret = null;
			try
			{
			IType t = this.GetField(37, rep);
				ret = (TX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Patient Preparation (OM1-37).
   ///</summary>
  public TX[] GetPatientPreparation() {
     TX[] ret = null;
    try {
        IType[] t = this.GetField(37);  
        ret = new TX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (TX)t[i];
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
  /// Returns the total repetitions of Patient Preparation (OM1-37).
   ///</summary>
  public int PatientPreparationRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(37);
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
	/// Returns Procedure Medication(OM1-38).
	///</summary>
	public CWE ProcedureMedication
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(38, 0);
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
	/// Returns Factors that may Affect the Observation(OM1-39).
	///</summary>
	public TX FactorsThatMayAffectTheObservation
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
	/// Returns a single repetition of Service/Test/Observation Performance Schedule(OM1-40).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ST GetServiceTestObservationPerformanceSchedule(int rep)
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
  /// Returns all repetitions of Service/Test/Observation Performance Schedule (OM1-40).
   ///</summary>
  public ST[] GetServiceTestObservationPerformanceSchedule() {
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
  /// Returns the total repetitions of Service/Test/Observation Performance Schedule (OM1-40).
   ///</summary>
  public int ServiceTestObservationPerformanceScheduleRepetitionsUsed
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
	public CWE KindOfQuantityObserved
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(42, 0);
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
	/// Returns Point Versus Interval(OM1-43).
	///</summary>
	public CWE PointVersusInterval
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(43, 0);
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
	/// Returns Challenge Information(OM1-44).
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
	/// Returns Relationship Modifier(OM1-45).
	///</summary>
	public CWE RelationshipModifier
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(45, 0);
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
	/// Returns Target Anatomic Site Of Test(OM1-46).
	///</summary>
	public CWE TargetAnatomicSiteOfTest
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(46, 0);
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
	/// Returns Modality of Imaging Measurement(OM1-47).
	///</summary>
	public CWE ModalityOfImagingMeasurement
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(47, 0);
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
	/// Returns Exclusive Test(OM1-48).
	///</summary>
	public ID ExclusiveTest
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(48, 0);
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
	/// Returns Diagnostic Serv Sect ID(OM1-49).
	///</summary>
	public ID DiagnosticServSectID
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(49, 0);
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
	/// Returns Taxonomic Classification Code(OM1-50).
	///</summary>
	public CWE TaxonomicClassificationCode
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
	/// Returns a single repetition of Other Names(OM1-51).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ST GetOtherNames(int rep)
	{
			ST ret = null;
			try
			{
			IType t = this.GetField(51, rep);
				ret = (ST)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Other Names (OM1-51).
   ///</summary>
  public ST[] GetOtherNames() {
     ST[] ret = null;
    try {
        IType[] t = this.GetField(51);  
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
  /// Returns the total repetitions of Other Names (OM1-51).
   ///</summary>
  public int OtherNamesRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(51);
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
	/// Returns a single repetition of Replacement Producer's Service/Test/Observation ID(OM1-52).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetReplacementProducerSServiceTestObservationID(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(52, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Replacement Producer's Service/Test/Observation ID (OM1-52).
   ///</summary>
  public CWE[] GetReplacementProducerSServiceTestObservationID() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(52);  
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
  /// Returns the total repetitions of Replacement Producer's Service/Test/Observation ID (OM1-52).
   ///</summary>
  public int ReplacementProducerSServiceTestObservationIDRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(52);
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
	/// Returns a single repetition of Prior Resuts Instructions(OM1-53).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public TX GetPriorResutsInstructions(int rep)
	{
			TX ret = null;
			try
			{
			IType t = this.GetField(53, rep);
				ret = (TX)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Prior Resuts Instructions (OM1-53).
   ///</summary>
  public TX[] GetPriorResutsInstructions() {
     TX[] ret = null;
    try {
        IType[] t = this.GetField(53);  
        ret = new TX[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (TX)t[i];
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
  /// Returns the total repetitions of Prior Resuts Instructions (OM1-53).
   ///</summary>
  public int PriorResutsInstructionsRepetitionsUsed
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
	///<summary>
	/// Returns Special Instructions(OM1-54).
	///</summary>
	public TX SpecialInstructions
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(54, 0);
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
	/// Returns a single repetition of Test Category(OM1-55).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetTestCategory(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(55, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Test Category (OM1-55).
   ///</summary>
  public CWE[] GetTestCategory() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(55);  
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
  /// Returns the total repetitions of Test Category (OM1-55).
   ///</summary>
  public int TestCategoryRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(55);
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