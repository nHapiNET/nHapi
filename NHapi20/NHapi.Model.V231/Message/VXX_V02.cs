using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V231.Group;
using NHapi.Model.V231.Segment;
using NHapi.Model.V231.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V231.Message

{
///<summary>
/// Represents a VXX_V02 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MSH - message header segment) </li>
///<li>1: MSA (MSA - message acknowledgment segment) </li>
///<li>2: QRD (QRD - original-style query definition segment) </li>
///<li>3: QRF (QRF - original style query filter segment) optional </li>
///<li>4: VXX_V02_PATIENT (a Group object) repeating</li>
///</ol>
///</summary>
[Serializable]
public class VXX_V02 : AbstractMessage  {

	///<summary> 
	/// Creates a new VXX_V02 Group with custom IModelClassFactory.
	///</summary>
	public VXX_V02(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new VXX_V02 Group with DefaultModelClassFactory. 
	///</summary> 
	public VXX_V02() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for VXX_V02.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(QRD), true, false);
	      this.add(typeof(QRF), false, false);
	      this.add(typeof(VXX_V02_PATIENT), true, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating VXX_V02 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MSH - message header segment) - creates it if necessary
	///</summary>
	public MSH MSH { 
get{
	   MSH ret = null;
	   try {
	      ret = (MSH)this.GetStructure("MSH");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns MSA (MSA - message acknowledgment segment) - creates it if necessary
	///</summary>
	public MSA MSA { 
get{
	   MSA ret = null;
	   try {
	      ret = (MSA)this.GetStructure("MSA");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns QRD (QRD - original-style query definition segment) - creates it if necessary
	///</summary>
	public QRD QRD { 
get{
	   QRD ret = null;
	   try {
	      ret = (QRD)this.GetStructure("QRD");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns QRF (QRF - original style query filter segment) - creates it if necessary
	///</summary>
	public QRF QRF { 
get{
	   QRF ret = null;
	   try {
	      ret = (QRF)this.GetStructure("QRF");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of VXX_V02_PATIENT (a Group object) - creates it if necessary
	///</summary>
	public VXX_V02_PATIENT GetPATIENT() {
	   VXX_V02_PATIENT ret = null;
	   try {
	      ret = (VXX_V02_PATIENT)this.GetStructure("PATIENT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of VXX_V02_PATIENT
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public VXX_V02_PATIENT GetPATIENT(int rep) { 
	   return (VXX_V02_PATIENT)this.GetStructure("PATIENT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of VXX_V02_PATIENT 
	 */ 
	public int PATIENTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("PATIENT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the VXX_V02_PATIENT results 
	 */ 
	public IEnumerable<VXX_V02_PATIENT> PATIENTs 
	{ 
		get
		{
			for (int rep = 0; rep < PATIENTRepetitionsUsed; rep++)
			{
				yield return (VXX_V02_PATIENT)this.GetStructure("PATIENT", rep);
			}
		}
	}

	///<summary>
	///Adds a new VXX_V02_PATIENT
	///</summary>
	public VXX_V02_PATIENT AddPATIENT()
	{
		return this.AddStructure("PATIENT") as VXX_V02_PATIENT;
	}

	///<summary>
	///Removes the given VXX_V02_PATIENT
	///</summary>
	public void RemovePATIENT(VXX_V02_PATIENT toRemove)
	{
		this.RemoveStructure("PATIENT", toRemove);
	}

	///<summary>
	///Removes the VXX_V02_PATIENT at the given index
	///</summary>
	public void RemovePATIENTAt(int index)
	{
		this.RemoveRepetition("PATIENT", index);
	}

}
}
