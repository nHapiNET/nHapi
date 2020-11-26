using System;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;
using NHapi.Model.V22.Datatype;
using NHapi.Base.Log;

namespace NHapi.Model.V22.Segment{

///<summary>
/// Represents an HL7 RXA message segment. 
/// This segment has the following fields:<ol>
///<li>RXA-1: Give Sub-ID Counter (NM)</li>
///<li>RXA-2: Administration Sub-ID Counter (NM)</li>
///<li>RXA-3: Date / time start of administration (TS)</li>
///<li>RXA-4: Date / time end of administration (TS)</li>
///<li>RXA-5: Administered Code (CE)</li>
///<li>RXA-6: Administered Amount (NM)</li>
///<li>RXA-7: Administered Units (CE)</li>
///<li>RXA-8: Administered Dosage Form (CE)</li>
///<li>RXA-9: Administration Notes (ST)</li>
///<li>RXA-10: Administering Provider (CN_PERSON)</li>
///<li>RXA-11: Administered-at Location (CM_LA1)</li>
///<li>RXA-12: Administered Per (Time Unit) (ST)</li>
///</ol>
/// The get...() methods return data from individual fields.  These methods 
/// do not throw exceptions and may therefore have to handle exceptions internally.  
/// If an exception is handled internally, it is logged and null is returned.  
/// This is not expected to happen - if it does happen this indicates not so much 
/// an exceptional circumstance as a bug in the code for this class.
///</summary>
[Serializable]
public class RXA : AbstractSegment  {

  /**
   * Creates a RXA (PHARMACY AADMINISTRATION) segment object that belongs to the given 
   * message.  
   */
	public RXA(IGroup parent, IModelClassFactory factory) : base(parent,factory) {
	IMessage message = Message;
    try {
       this.add(typeof(NM), true, 1, 4, new System.Object[]{message}, "Give Sub-ID Counter");
       this.add(typeof(NM), true, 1, 4, new System.Object[]{message}, "Administration Sub-ID Counter");
       this.add(typeof(TS), true, 1, 26, new System.Object[]{message}, "Date / time start of administration");
       this.add(typeof(TS), true, 1, 26, new System.Object[]{message}, "Date / time end of administration");
       this.add(typeof(CE), true, 1, 100, new System.Object[]{message}, "Administered Code");
       this.add(typeof(NM), true, 1, 20, new System.Object[]{message}, "Administered Amount");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Administered Units");
       this.add(typeof(CE), false, 1, 60, new System.Object[]{message}, "Administered Dosage Form");
       this.add(typeof(ST), false, 1, 200, new System.Object[]{message}, "Administration Notes");
       this.add(typeof(CN_PERSON), false, 1, 200, new System.Object[]{message}, "Administering Provider");
       this.add(typeof(CM_LA1), false, 1, 12, new System.Object[]{message}, "Administered-at Location");
       this.add(typeof(ST), false, 1, 20, new System.Object[]{message}, "Administered Per (Time Unit)");
    } catch (HL7Exception he) {
        HapiLogFactory.GetHapiLog(GetType()).Error("Can't instantiate " + GetType().Name, he);
    }
  }

	///<summary>
	/// Returns Give Sub-ID Counter(RXA-1).
	///</summary>
	public NM GiveSubIDCounter
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
	/// Returns Administration Sub-ID Counter(RXA-2).
	///</summary>
	public NM AdministrationSubIDCounter
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
	/// Returns Date / time start of administration(RXA-3).
	///</summary>
	public TS DateTimeStartOfAdministration
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(3, 0);
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
	/// Returns Date / time end of administration(RXA-4).
	///</summary>
	public TS DateTimeEndOfAdministration
	{
		get{
			TS ret = null;
			try
			{
			IType t = this.GetField(4, 0);
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
	/// Returns Administered Code(RXA-5).
	///</summary>
	public CE AdministeredCode
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
	/// Returns Administered Amount(RXA-6).
	///</summary>
	public NM AdministeredAmount
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
	/// Returns Administered Units(RXA-7).
	///</summary>
	public CE AdministeredUnits
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
	/// Returns Administered Dosage Form(RXA-8).
	///</summary>
	public CE AdministeredDosageForm
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
	/// Returns Administration Notes(RXA-9).
	///</summary>
	public ST AdministrationNotes
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
	/// Returns Administering Provider(RXA-10).
	///</summary>
	public CN_PERSON AdministeringProvider
	{
		get{
			CN_PERSON ret = null;
			try
			{
			IType t = this.GetField(10, 0);
				ret = (CN_PERSON)t;
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
	/// Returns Administered-at Location(RXA-11).
	///</summary>
	public CM_LA1 AdministeredAtLocation
	{
		get{
			CM_LA1 ret = null;
			try
			{
			IType t = this.GetField(11, 0);
				ret = (CM_LA1)t;
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
	/// Returns Administered Per (Time Unit)(RXA-12).
	///</summary>
	public ST AdministeredPerTimeUnit
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