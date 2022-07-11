﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using NHapi.Base;
using NHapi.Base.Log;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V251.Group;
using NHapi.Model.V251.Segment;

namespace NHapi.Model.V251.Message
{
   ///<summary>
   /// Represents a SIU_S26 message structure (see chapter [AAA]). This structure contains the 
   /// following elements:
   ///<ol>
   ///<li>0: MSH (Message header segment) </li>
   ///<li>1: SCH (Schedule Activity Information) </li>
   ///<li>2: NTE (Notes and comments segment) optional repeating</li>
   ///<li>3: SIU_S26_PATIENT (a Group object) optional repeating</li>
   ///<li>4: SIU_S26_RESOURCES (a Group object) repeating</li>
   ///</ol>
   ///</summary>
   [Serializable]
   public class SIU_S26 : AbstractMessage
   {

	  ///<summary> 
	  /// Creates a new SIU_S26 Group with custom IModelClassFactory.
	  ///</summary>
	  public SIU_S26(IModelClassFactory factory) : base(factory)
	  {
		 init(factory);
	  }

	  ///<summary>
	  /// Creates a new SIU_S26 Group with DefaultModelClassFactory. 
	  ///</summary> 
	  public SIU_S26() : base(new DefaultModelClassFactory())
	  {
		 init(new DefaultModelClassFactory());
	  }

	  ///<summary>
	  /// initalize method for SIU_S26.  This does the segment setup for the message. 
	  ///</summary> 
	  private void init(IModelClassFactory factory)
	  {
		 try
		 {
			this.add(typeof(MSH), true, false);
			this.add(typeof(SCH), true, false);
			 this.add(typeof(TQ1), true, true);
			this.add(typeof(NTE), false, true);
			this.add(typeof(SIU_S26_PATIENT), false, true);
			this.add(typeof(SIU_S26_RESOURCES), true, true);
		 }
		 catch (HL7Exception e)
		 {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SIU_S26 - this is probably a bug in the source code generator.", e);
		 }
	  }


	  public override string Version
	  {
		 get
		 {
			return Constants.VERSION;
		 }
	  }
	  ///<summary>
	  /// Returns MSH (Message header segment) - creates it if necessary
	  ///</summary>
	  public MSH MSH
	  {
		 get
		 {
			MSH ret = null;
			try
			{
			   ret = (MSH)this.GetStructure("MSH");
			}
			catch (HL7Exception e)
			{
			   HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
			   throw new System.Exception("An unexpected error ocurred", e);
			}
			return ret;
		 }
	  }

	  ///<summary>
	  /// Returns SCH (Schedule Activity Information) - creates it if necessary
	  ///</summary>
	  public SCH SCH
	  {
		 get
		 {
			SCH ret = null;
			try
			{
			   ret = (SCH)this.GetStructure("SCH");
			}
			catch (HL7Exception e)
			{
			   HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
			   throw new System.Exception("An unexpected error ocurred", e);
			}
			return ret;
		 }
	  }

	   public TQ1 TQ1
	   {
		   get
		   {
			   TQ1 ret = null;
			   try
			   {
				   ret = (TQ1) this.GetStructure("TQ1");
			   }
			   catch (HL7Exception e)
			   {
				   HapiLogFactory.GetHapiLog(GetType())
					   .Error("Unexpected error accessing data - this is probably a bug in teh source code generator.", e);
				   throw new Exception("An unexpected error has ocurred.", e);
			   }
			   return ret;
		   }
	   }

	  ///<summary>
	  /// Returns  first repetition of NTE (Notes and comments segment) - creates it if necessary
	  ///</summary>
	  public NTE GetNTE()
	  {
		 NTE ret = null;
		 try
		 {
			ret = (NTE)this.GetStructure("NTE");
		 }
		 catch (HL7Exception e)
		 {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
			throw new System.Exception("An unexpected error ocurred", e);
		 }
		 return ret;
	  }

	  ///<summary>
	  ///Returns a specific repetition of NTE
	  /// * (Notes and comments segment) - creates it if necessary
	  /// throws HL7Exception if the repetition requested is more than one 
	  ///     greater than the number of existing repetitions.
	  ///</summary>
	  public NTE GetNTE(int rep)
	  {
		 return (NTE)this.GetStructure("NTE", rep);
	  }

	  /** 
	   * Returns the number of existing repetitions of NTE 
	   */
	  public int NTERepetitionsUsed
	  {
		 get
		 {
			int reps = -1;
			try
			{
			   reps = this.GetAll("NTE").Length;
			}
			catch (HL7Exception e)
			{
			   string message = "Unexpected error accessing data - this is probably a bug in the source code generator.";
			   HapiLogFactory.GetHapiLog(GetType()).Error(message, e);
			   throw new System.Exception(message);
			}
			return reps;
		 }
	  }

	  /** 
	   * Enumerate over the NTE results 
	   */
	  public IEnumerable<NTE> NTEs
	  {
		 get
		 {
			for (int rep = 0; rep < NTERepetitionsUsed; rep++)
			{
			   yield return (NTE)this.GetStructure("NTE", rep);
			}
		 }
	  }

	  ///<summary>
	  ///Adds a new NTE
	  ///</summary>
	  public NTE AddNTE()
	  {
		 return this.AddStructure("NTE") as NTE;
	  }

	  ///<summary>
	  ///Removes the given NTE
	  ///</summary>
	  public void RemoveNTE(NTE toRemove)
	  {
		 this.RemoveStructure("NTE", toRemove);
	  }

	  ///<summary>
	  ///Removes the NTE at the given index
	  ///</summary>
	  public void RemoveNTEAt(int index)
	  {
		 this.RemoveRepetition("NTE", index);
	  }

	  ///<summary>
	  /// Returns  first repetition of SIU_S26_PATIENT (a Group object) - creates it if necessary
	  ///</summary>
	  public SIU_S26_PATIENT GetPATIENT()
	  {
		 SIU_S26_PATIENT ret = null;
		 try
		 {
			ret = (SIU_S26_PATIENT)this.GetStructure("PATIENT");
		 }
		 catch (HL7Exception e)
		 {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
			throw new System.Exception("An unexpected error ocurred", e);
		 }
		 return ret;
	  }

	  ///<summary>
	  ///Returns a specific repetition of SIU_S26_PATIENT
	  /// * (a Group object) - creates it if necessary
	  /// throws HL7Exception if the repetition requested is more than one 
	  ///     greater than the number of existing repetitions.
	  ///</summary>
	  public SIU_S26_PATIENT GetPATIENT(int rep)
	  {
		 return (SIU_S26_PATIENT)this.GetStructure("PATIENT", rep);
	  }

	  /** 
	   * Returns the number of existing repetitions of SIU_S26_PATIENT 
	   */
	  public int PATIENTRepetitionsUsed
	  {
		 get
		 {
			int reps = -1;
			try
			{
			   reps = this.GetAll("PATIENT").Length;
			}
			catch (HL7Exception e)
			{
			   string message = "Unexpected error accessing data - this is probably a bug in the source code generator.";
			   HapiLogFactory.GetHapiLog(GetType()).Error(message, e);
			   throw new System.Exception(message);
			}
			return reps;
		 }
	  }

	  /** 
	   * Enumerate over the SIU_S26_PATIENT results 
	   */
	  public IEnumerable<SIU_S26_PATIENT> PATIENTs
	  {
		 get
		 {
			for (int rep = 0; rep < PATIENTRepetitionsUsed; rep++)
			{
			   yield return (SIU_S26_PATIENT)this.GetStructure("PATIENT", rep);
			}
		 }
	  }

	  ///<summary>
	  ///Adds a new SIU_S26_PATIENT
	  ///</summary>
	  public SIU_S26_PATIENT AddPATIENT()
	  {
		 return this.AddStructure("PATIENT") as SIU_S26_PATIENT;
	  }

	  ///<summary>
	  ///Removes the given SIU_S26_PATIENT
	  ///</summary>
	  public void RemovePATIENT(SIU_S26_PATIENT toRemove)
	  {
		 this.RemoveStructure("PATIENT", toRemove);
	  }

	  ///<summary>
	  ///Removes the SIU_S26_PATIENT at the given index
	  ///</summary>
	  public void RemovePATIENTAt(int index)
	  {
		 this.RemoveRepetition("PATIENT", index);
	  }

	  ///<summary>
	  /// Returns  first repetition of SIU_S26_RESOURCES (a Group object) - creates it if necessary
	  ///</summary>
	  public SIU_S26_RESOURCES GetRESOURCES()
	  {
		 SIU_S26_RESOURCES ret = null;
		 try
		 {
			ret = (SIU_S26_RESOURCES)this.GetStructure("RESOURCES");
		 }
		 catch (HL7Exception e)
		 {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
			throw new System.Exception("An unexpected error ocurred", e);
		 }
		 return ret;
	  }

	  ///<summary>
	  ///Returns a specific repetition of SIU_S26_RESOURCES
	  /// * (a Group object) - creates it if necessary
	  /// throws HL7Exception if the repetition requested is more than one 
	  ///     greater than the number of existing repetitions.
	  ///</summary>
	  public SIU_S26_RESOURCES GetRESOURCES(int rep)
	  {
		 return (SIU_S26_RESOURCES)this.GetStructure("RESOURCES", rep);
	  }

	  /** 
	   * Returns the number of existing repetitions of SIU_S26_RESOURCES 
	   */
	  public int RESOURCESRepetitionsUsed
	  {
		 get
		 {
			int reps = -1;
			try
			{
			   reps = this.GetAll("RESOURCES").Length;
			}
			catch (HL7Exception e)
			{
			   string message = "Unexpected error accessing data - this is probably a bug in the source code generator.";
			   HapiLogFactory.GetHapiLog(GetType()).Error(message, e);
			   throw new System.Exception(message);
			}
			return reps;
		 }
	  }

	  /** 
	   * Enumerate over the SIU_S26_RESOURCES results 
	   */
	  public IEnumerable<SIU_S26_RESOURCES> RESOURCESs
	  {
		 get
		 {
			for (int rep = 0; rep < RESOURCESRepetitionsUsed; rep++)
			{
			   yield return (SIU_S26_RESOURCES)this.GetStructure("RESOURCES", rep);
			}
		 }
	  }

	  ///<summary>
	  ///Adds a new SIU_S26_RESOURCES
	  ///</summary>
	  public SIU_S26_RESOURCES AddRESOURCES()
	  {
		 return this.AddStructure("RESOURCES") as SIU_S26_RESOURCES;
	  }

	  ///<summary>
	  ///Removes the given SIU_S26_RESOURCES
	  ///</summary>
	  public void RemoveRESOURCES(SIU_S26_RESOURCES toRemove)
	  {
		 this.RemoveStructure("RESOURCES", toRemove);
	  }

	  ///<summary>
	  ///Removes the SIU_S26_RESOURCES at the given index
	  ///</summary>
	  public void RemoveRESOURCESAt(int index)
	  {
		 this.RemoveRepetition("RESOURCES", index);
	  }

   }
}
