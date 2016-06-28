using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V28.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V28.Segment{

///<summary>
/// Represents an HL7 PRB message segment. 
/// This segment has the following fields:<ol>
///<li>PRB-1: Action Code (ID)</li>
///<li>PRB-2: Action Date/Time (DTM)</li>
///<li>PRB-3: Problem ID (CWE)</li>
///<li>PRB-4: Problem Instance ID (EI)</li>
///<li>PRB-5: Episode of Care ID (EI)</li>
///<li>PRB-6: Problem List Priority (NM)</li>
///<li>PRB-7: Problem Established Date/Time (DTM)</li>
///<li>PRB-8: Anticipated Problem Resolution Date/Time (DTM)</li>
///<li>PRB-9: Actual Problem Resolution Date/Time (DTM)</li>
///<li>PRB-10: Problem Classification (CWE)</li>
///<li>PRB-11: Problem Management Discipline (CWE)</li>
///<li>PRB-12: Problem Persistence (CWE)</li>
///<li>PRB-13: Problem Confirmation Status (CWE)</li>
///<li>PRB-14: Problem Life Cycle Status (CWE)</li>
///<li>PRB-15: Problem Life Cycle Status Date/Time (DTM)</li>
///<li>PRB-16: Problem Date of Onset (DTM)</li>
///<li>PRB-17: Problem Onset Text (ST)</li>
///<li>PRB-18: Problem Ranking (CWE)</li>
///<li>PRB-19: Certainty of Problem (CWE)</li>
///<li>PRB-20: Probability of Problem (0-1) (NM)</li>
///<li>PRB-21: Individual Awareness of Problem (CWE)</li>
///<li>PRB-22: Problem Prognosis (CWE)</li>
///<li>PRB-23: Individual Awareness of Prognosis (CWE)</li>
///<li>PRB-24: Family/Significant Other Awareness of Problem/Prognosis (ST)</li>
///<li>PRB-25: Security/Sensitivity (CWE)</li>
///<li>PRB-26: Problem Severity (CWE)</li>
///<li>PRB-27: Problem Perspective (CWE)</li>
///<li>PRB-28: Mood Code (CNE)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class PRB : AbstractSegment  {

  /**
   * Creates a PRB (Problem Details) segment object that belongs to the given 
   * message.  
   */
	public PRB(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(ID), true, 1, 2, new System.Object[]{message, 206}, "Action Code");
       this.add(typeof(DTM), true, 1, 0, new System.Object[]{message}, "Action Date/Time");
       this.add(typeof(CWE), true, 1, 0, new System.Object[]{message}, "Problem ID");
       this.add(typeof(EI), true, 1, 0, new System.Object[]{message}, "Problem Instance ID");
       this.add(typeof(EI), false, 1, 0, new System.Object[]{message}, "Episode of Care ID");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Problem List Priority");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Problem Established Date/Time");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Anticipated Problem Resolution Date/Time");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Actual Problem Resolution Date/Time");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Problem Classification");
       this.add(typeof(CWE), false, 0, 0, new System.Object[]{message}, "Problem Management Discipline");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Problem Persistence");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Problem Confirmation Status");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Problem Life Cycle Status");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Problem Life Cycle Status Date/Time");
       this.add(typeof(DTM), false, 1, 0, new System.Object[]{message}, "Problem Date of Onset");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Problem Onset Text");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Problem Ranking");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Certainty of Problem");
       this.add(typeof(NM), false, 1, 0, new System.Object[]{message}, "Probability of Problem (0-1)");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Individual Awareness of Problem");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Problem Prognosis");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Individual Awareness of Prognosis");
       this.add(typeof(ST), false, 1, 0, new System.Object[]{message}, "Family/Significant Other Awareness of Problem/Prognosis");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Security/Sensitivity");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Problem Severity");
       this.add(typeof(CWE), false, 1, 0, new System.Object[]{message}, "Problem Perspective");
       this.add(typeof(CNE), false, 1, 0, new System.Object[]{message}, "Mood Code");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Action Code(PRB-1).
	///</summary>
	public ID ActionCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(1, 0);
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
	/// Returns Action Date/Time(PRB-2).
	///</summary>
	public DTM ActionDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(2, 0);
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
	/// Returns Problem ID(PRB-3).
	///</summary>
	public CWE ProblemID
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
	/// Returns Problem Instance ID(PRB-4).
	///</summary>
	public EI ProblemInstanceID
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Episode of Care ID(PRB-5).
	///</summary>
	public EI EpisodeOfCareID
	{
		get{
			EI ret = null;
			try
			{
			IType t = this.GetField(5, 0);
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
	/// Returns Problem List Priority(PRB-6).
	///</summary>
	public NM ProblemListPriority
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
	/// Returns Problem Established Date/Time(PRB-7).
	///</summary>
	public DTM ProblemEstablishedDateTime
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
	/// Returns Anticipated Problem Resolution Date/Time(PRB-8).
	///</summary>
	public DTM AnticipatedProblemResolutionDateTime
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
	/// Returns Actual Problem Resolution Date/Time(PRB-9).
	///</summary>
	public DTM ActualProblemResolutionDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(9, 0);
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
	/// Returns Problem Classification(PRB-10).
	///</summary>
	public CWE ProblemClassification
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

	///<summary>
	/// Returns a single repetition of Problem Management Discipline(PRB-11).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public CWE GetProblemManagementDiscipline(int rep)
	{
			CWE ret = null;
			try
			{
			IType t = this.GetField(11, rep);
				ret = (CWE)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Problem Management Discipline (PRB-11).
   ///</summary>
  public CWE[] GetProblemManagementDiscipline() {
     CWE[] ret = null;
    try {
        IType[] t = this.GetField(11);  
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
  /// Returns the total repetitions of Problem Management Discipline (PRB-11).
   ///</summary>
  public int ProblemManagementDisciplineRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(11);
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
	/// Returns Problem Persistence(PRB-12).
	///</summary>
	public CWE ProblemPersistence
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
	/// Returns Problem Confirmation Status(PRB-13).
	///</summary>
	public CWE ProblemConfirmationStatus
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
	/// Returns Problem Life Cycle Status(PRB-14).
	///</summary>
	public CWE ProblemLifeCycleStatus
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

	///<summary>
	/// Returns Problem Life Cycle Status Date/Time(PRB-15).
	///</summary>
	public DTM ProblemLifeCycleStatusDateTime
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(15, 0);
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
	/// Returns Problem Date of Onset(PRB-16).
	///</summary>
	public DTM ProblemDateOfOnset
	{
		get{
			DTM ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Problem Onset Text(PRB-17).
	///</summary>
	public ST ProblemOnsetText
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns Problem Ranking(PRB-18).
	///</summary>
	public CWE ProblemRanking
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
	/// Returns Certainty of Problem(PRB-19).
	///</summary>
	public CWE CertaintyOfProblem
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
	/// Returns Probability of Problem (0-1)(PRB-20).
	///</summary>
	public NM ProbabilityOfProblem
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
	/// Returns Individual Awareness of Problem(PRB-21).
	///</summary>
	public CWE IndividualAwarenessOfProblem
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
	/// Returns Problem Prognosis(PRB-22).
	///</summary>
	public CWE ProblemPrognosis
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(22, 0);
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
	/// Returns Individual Awareness of Prognosis(PRB-23).
	///</summary>
	public CWE IndividualAwarenessOfPrognosis
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(23, 0);
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
	/// Returns Family/Significant Other Awareness of Problem/Prognosis(PRB-24).
	///</summary>
	public ST FamilySignificantOtherAwarenessOfProblemPrognosis
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(24, 0);
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
	/// Returns Security/Sensitivity(PRB-25).
	///</summary>
	public CWE SecuritySensitivity
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(25, 0);
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
	/// Returns Problem Severity(PRB-26).
	///</summary>
	public CWE ProblemSeverity
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(26, 0);
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
	/// Returns Problem Perspective(PRB-27).
	///</summary>
	public CWE ProblemPerspective
	{
		get{
			CWE ret = null;
			try
			{
			IType t = this.GetField(27, 0);
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
	/// Returns Mood Code(PRB-28).
	///</summary>
	public CNE MoodCode
	{
		get{
			CNE ret = null;
			try
			{
			IType t = this.GetField(28, 0);
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