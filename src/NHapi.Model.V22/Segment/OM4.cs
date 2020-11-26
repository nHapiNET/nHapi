using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V22.Segment{

///<summary>
/// Represents an HL7 OM4 message segment. 
/// This segment has the following fields:<ol>
///<li>OM4-1: Segment Type ID (ST)</li>
///<li>OM4-2: Sequence Number - Test/ Observation Master File (NM)</li>
///<li>OM4-3: Derived Specimen (ID)</li>
///<li>OM4-4: Container Description (TX)</li>
///<li>OM4-5: Container Volume (NM)</li>
///<li>OM4-6: Container Units (CE)</li>
///<li>OM4-7: Specimen (CE)</li>
///<li>OM4-8: Additive (CE)</li>
///<li>OM4-9: Preparation (TX)</li>
///<li>OM4-10: Special Handling Requirements (TX)</li>
///<li>OM4-11: Normal Collection Volume (CQ_QUANTITY)</li>
///<li>OM4-12: Minimum Collection Volume (CQ_COMP_QUANT)</li>
///<li>OM4-13: Specimen Requirements (TX)</li>
///<li>OM4-14: Specimen Priorities (ID)</li>
///<li>OM4-15: Specimen Retention Time (CQ_COMP_QUANT)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class OM4 : AbstractSegment  {

  /**
   * Creates a OM4 (OBSERVATION that require specimens) segment object that belongs to the given 
   * message.  
   */
	public OM4(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(ST), false, 1, 3, new System.Object[]{message}, "Segment Type ID");
       this.add(typeof(NM), false, 1, 4, new System.Object[]{message}, "Sequence Number - Test/ Observation Master File");
       this.add(typeof(ID), false, 1, 1, new System.Object[]{message, 170}, "Derived Specimen");
       this.add(typeof(TX), false, 1, 60, new System.Object[]{message}, "Container Description");
       this.add(typeof(NM), false, 1, 20, new System.Object[]{message}, "Container Volume");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Container Units");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Specimen");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Additive");
       this.add(typeof(TX), false, 1, 10240, new System.Object[]{message}, "Preparation");
       this.add(typeof(TX), false, 1, 10240, new System.Object[]{message}, "Special Handling Requirements");
       this.add(typeof(CQ_QUANTITY), false, 1, 20, new System.Object[]{message}, "Normal Collection Volume");
       this.add(typeof(CQ_COMP_QUANT), false, 1, 20, new System.Object[]{message}, "Minimum Collection Volume");
       this.add(typeof(TX), false, 1, 10240, new System.Object[]{message}, "Specimen Requirements");
       this.add(typeof(ID), false, 0, 60, new System.Object[]{message, 27}, "Specimen Priorities");
       this.add(typeof(CQ_COMP_QUANT), false, 1, 20, new System.Object[]{message}, "Specimen Retention Time");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Segment Type ID(OM4-1).
	///</summary>
	public ST SegmentTypeID
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
	/// Returns Sequence Number - Test/ Observation Master File(OM4-2).
	///</summary>
	public NM SequenceNumberTestObservationMasterFile
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
	/// Returns Derived Specimen(OM4-3).
	///</summary>
	public ID DerivedSpecimen
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Container Description(OM4-4).
	///</summary>
	public TX ContainerDescription
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Container Volume(OM4-5).
	///</summary>
	public NM ContainerVolume
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
	/// Returns Container Units(OM4-6).
	///</summary>
	public CE ContainerUnits
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
	/// Returns Specimen(OM4-7).
	///</summary>
	public CE Specimen
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
	/// Returns Additive(OM4-8).
	///</summary>
	public CE Additive
	{
		get{
			CE ret = null;
			try
			{
			IType t = this.GetField(8, 0);
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
	/// Returns Preparation(OM4-9).
	///</summary>
	public TX Preparation
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Special Handling Requirements(OM4-10).
	///</summary>
	public TX SpecialHandlingRequirements
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(10, 0);
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
	/// Returns Normal Collection Volume(OM4-11).
	///</summary>
	public CQ_QUANTITY NormalCollectionVolume
	{
		get{
			CQ_QUANTITY ret = null;
			try
			{
			IType t = this.GetField(11, 0);
				ret = (CQ_QUANTITY)t;
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
	/// Returns Minimum Collection Volume(OM4-12).
	///</summary>
	public CQ_COMP_QUANT MinimumCollectionVolume
	{
		get{
			CQ_COMP_QUANT ret = null;
			try
			{
			IType t = this.GetField(12, 0);
				ret = (CQ_COMP_QUANT)t;
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
	/// Returns Specimen Requirements(OM4-13).
	///</summary>
	public TX SpecimenRequirements
	{
		get{
			TX ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns a single repetition of Specimen Priorities(OM4-14).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ID GetSpecimenPriorities(int rep)
	{
			ID ret = null;
			try
			{
			IType t = this.GetField(14, rep);
				ret = (ID)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Specimen Priorities (OM4-14).
   ///</summary>
  public ID[] GetSpecimenPriorities() {
     ID[] ret = null;
    try {
        IType[] t = this.GetField(14);  
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
  /// Returns the total repetitions of Specimen Priorities (OM4-14).
   ///</summary>
  public int SpecimenPrioritiesRepetitionsUsed
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
	/// Returns Specimen Retention Time(OM4-15).
	///</summary>
	public CQ_COMP_QUANT SpecimenRetentionTime
	{
		get{
			CQ_COMP_QUANT ret = null;
			try
			{
			IType t = this.GetField(15, 0);
				ret = (CQ_COMP_QUANT)t;
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