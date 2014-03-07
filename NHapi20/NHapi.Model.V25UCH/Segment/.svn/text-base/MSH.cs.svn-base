using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V25UCH.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V25UCH.Segment{

///<summary>
/// Represents an HL7 MSH message segment. 
/// This segment has the following fields:<ol>
///<li>MSH-1: Field Separator (ST)</li>
///<li>MSH-2: Encoding Characters (ST)</li>
///<li>MSH-3: Sending Application (HD)</li>
///<li>MSH-4: Sending Facility (HD)</li>
///<li>MSH-5: Receiving Application (HD)</li>
///<li>MSH-6: Receiving Facility (HD)</li>
///<li>MSH-7: Date/Time Of Message (TS)</li>
///<li>MSH-8: Security (ST)</li>
///<li>MSH-9: Message Type (MSG)</li>
///<li>MSH-10: Message Control ID (ST)</li>
///<li>MSH-11: Processing ID (PT)</li>
///<li>MSH-12: Version ID (VID)</li>
///<li>MSH-13: Sequence Number (NM)</li>
///<li>MSH-14: Continuation Pointer (ST)</li>
///<li>MSH-15: Accept Acknowledgment Type (ID)</li>
///<li>MSH-16: Application Acknowledgment Type (ID)</li>
///<li>MSH-17: Country Code (ID)</li>
///<li>MSH-18: Character Set (ID)</li>
///<li>MSH-19: Principal Language Of Message (CE)</li>
///<li>MSH-20: Alternate Character Set Handling Scheme (ID)</li>
///<li>MSH-21: Message Profile Identifier (EI)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class MSH : AbstractSegment  {

  /**
   * Creates a MSH (Message Header) segment object that belongs to the given 
   * message.  
   */
	public MSH(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(ST), true, 1, 1, new System.Object[]{message}, "Field Separator");
       this.add(typeof(ST), true, 1, 4, new System.Object[]{message}, "Encoding Characters");
       this.add(typeof(HD), false, 1, 227, new System.Object[]{message}, "Sending Application");
       this.add(typeof(HD), false, 1, 227, new System.Object[]{message}, "Sending Facility");
       this.add(typeof(HD), false, 1, 227, new System.Object[]{message}, "Receiving Application");
       this.add(typeof(HD), false, 1, 227, new System.Object[]{message}, "Receiving Facility");
       this.add(typeof(TS), true, 1, 26, new System.Object[]{message}, "Date/Time Of Message");
       this.add(typeof(ST), false, 1, 40, new System.Object[]{message}, "Security");
       this.add(typeof(MSG), true, 1, 15, new System.Object[]{message}, "Message Type");
       this.add(typeof(ST), true, 1, 20, new System.Object[]{message}, "Message Control ID");
       this.add(typeof(PT), true, 1, 3, new System.Object[]{message}, "Processing ID");
       this.add(typeof(VID), true, 1, 60, new System.Object[]{message}, "Version ID");
       this.add(typeof(NM), false, 1, 15, new System.Object[]{message}, "Sequence Number");
       this.add(typeof(ST), false, 1, 180, new System.Object[]{message}, "Continuation Pointer");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 155}, "Accept Acknowledgment Type");
       this.add(typeof(ID), false, 1, 2, new System.Object[]{message, 155}, "Application Acknowledgment Type");
       this.add(typeof(ID), false, 1, 3, new System.Object[]{message, 399}, "Country Code");
       this.add(typeof(ID), false, 0, 16, new System.Object[]{message, 211}, "Character Set");
       this.add(typeof(CE), false, 1, 250, new System.Object[]{message}, "Principal Language Of Message");
       this.add(typeof(ID), false, 1, 20, new System.Object[]{message, 356}, "Alternate Character Set Handling Scheme");
       this.add(typeof(EI), false, 0, 427, new System.Object[]{message}, "Message Profile Identifier");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Field Separator(MSH-1).
	///</summary>
	public ST FieldSeparator
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
	/// Returns Encoding Characters(MSH-2).
	///</summary>
	public ST EncodingCharacters
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
	/// Returns Sending Application(MSH-3).
	///</summary>
	public HD SendingApplication
	{
		get{
			HD ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Sending Facility(MSH-4).
	///</summary>
	public HD SendingFacility
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
	/// Returns Receiving Application(MSH-5).
	///</summary>
	public HD ReceivingApplication
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
	/// Returns Receiving Facility(MSH-6).
	///</summary>
	public HD ReceivingFacility
	{
		get{
			HD ret = null;
			try
			{
			IType t = this.GetField(6, 0);
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
	/// Returns Date/Time Of Message(MSH-7).
	///</summary>
	public TS DateTimeOfMessage
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
	/// Returns Security(MSH-8).
	///</summary>
	public ST Security
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
	/// Returns Message Type(MSH-9).
	///</summary>
	public MSG MessageType
	{
		get{
			MSG ret = null;
			try
			{
			IType t = this.GetField(9, 0);
				ret = (MSG)t;
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
	/// Returns Message Control ID(MSH-10).
	///</summary>
	public ST MessageControlID
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
	/// Returns Processing ID(MSH-11).
	///</summary>
	public PT ProcessingID
	{
		get{
			PT ret = null;
			try
			{
			IType t = this.GetField(11, 0);
				ret = (PT)t;
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
	/// Returns Version ID(MSH-12).
	///</summary>
	public VID VersionID
	{
		get{
			VID ret = null;
			try
			{
			IType t = this.GetField(12, 0);
				ret = (VID)t;
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
	/// Returns Sequence Number(MSH-13).
	///</summary>
	public NM SequenceNumber
	{
		get{
			NM ret = null;
			try
			{
			IType t = this.GetField(13, 0);
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
	/// Returns Continuation Pointer(MSH-14).
	///</summary>
	public ST ContinuationPointer
	{
		get{
			ST ret = null;
			try
			{
			IType t = this.GetField(14, 0);
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
	/// Returns Accept Acknowledgment Type(MSH-15).
	///</summary>
	public ID AcceptAcknowledgmentType
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
	/// Returns Application Acknowledgment Type(MSH-16).
	///</summary>
	public ID ApplicationAcknowledgmentType
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(16, 0);
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
	/// Returns Country Code(MSH-17).
	///</summary>
	public ID CountryCode
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(17, 0);
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
	/// Returns a single repetition of Character Set(MSH-18).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public ID GetCharacterSet(int rep)
	{
			ID ret = null;
			try
			{
			IType t = this.GetField(18, rep);
				ret = (ID)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Character Set (MSH-18).
   ///</summary>
  public ID[] GetCharacterSet() {
     ID[] ret = null;
    try {
        IType[] t = this.GetField(18);  
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
  /// Returns the total repetitions of Character Set (MSH-18).
   ///</summary>
  public int CharacterSetRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(18);
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
	/// Returns Principal Language Of Message(MSH-19).
	///</summary>
	public CE PrincipalLanguageOfMessage
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
	/// Returns Alternate Character Set Handling Scheme(MSH-20).
	///</summary>
	public ID AlternateCharacterSetHandlingScheme
	{
		get{
			ID ret = null;
			try
			{
			IType t = this.GetField(20, 0);
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
	/// Returns a single repetition of Message Profile Identifier(MSH-21).
	/// throws HL7Exception if the repetition number is invalid.
	/// <param name="rep">The repetition number (this is a repeating field)</param>
	///</summary>
	public EI GetMessageProfileIdentifier(int rep)
	{
			EI ret = null;
			try
			{
			IType t = this.GetField(21, rep);
				ret = (EI)t;
		} catch (System.Exception ex) {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
				throw new System.Exception("An unexpected error ocurred", ex);
    }
			return ret;
  }

  ///<summary>
  /// Returns all repetitions of Message Profile Identifier (MSH-21).
   ///</summary>
  public EI[] GetMessageProfileIdentifier() {
     EI[] ret = null;
    try {
        IType[] t = this.GetField(21);  
        ret = new EI[t.Length];
        for (int i = 0; i < ret.Length; i++) {
            ret[i] = (EI)t[i];
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
  /// Returns the total repetitions of Message Profile Identifier (MSH-21).
   ///</summary>
  public int MessageProfileIdentifierRepetitionsUsed
{
get{
    try {
	return GetTotalFieldRepetitionsUsed(21);
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