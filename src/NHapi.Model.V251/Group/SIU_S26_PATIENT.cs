﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHapi.Base;
using NHapi.Base.Log;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V251.Segment;

namespace NHapi.Model.V251.Group
{
   ///<summary>
   ///Represents the SIU_S26_PATIENT Group.  A Group is an ordered collection of message 
   /// segments that can repeat together or be optionally in/excluded together.
   /// This Group contains the following elements: 
   ///<ol>
   ///<li>0: PID (Patient Identification) </li>
   ///<li>1: PV1 (Patient visit) optional </li>
   ///<li>2: PV2 (Patient visit - additional information) optional </li>
   ///<li>3: OBX (Observation segment) optional repeating</li>
   ///<li>4: DG1 (Diagnosis) optional repeating</li>
   ///</ol>
   ///</summary>
   [Serializable]
   public class SIU_S26_PATIENT : AbstractGroup
   {

	  ///<summary> 
	  /// Creates a new SIU_S26_PATIENT Group.
	  ///</summary>
	  public SIU_S26_PATIENT(IGroup parent, IModelClassFactory factory) : base(parent, factory)
	  {
		 try
		 {
			this.add(typeof(PID), true, false);
			this.add(typeof(PV1), false, false);
			this.add(typeof(PV2), false, false);
			this.add(typeof(OBX), false, true);
			this.add(typeof(DG1), false, true);
		 }
		 catch (HL7Exception e)
		 {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SIU_S26_PATIENT - this is probably a bug in the source code generator.", e);
		 }
	  }

	  ///<summary>
	  /// Returns PID (Patient Identification) - creates it if necessary
	  ///</summary>
	  public PID PID
	  {
		 get
		 {
			PID ret = null;
			try
			{
			   ret = (PID)this.GetStructure("PID");
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
	  /// Returns PV1 (Patient visit) - creates it if necessary
	  ///</summary>
	  public PV1 PV1
	  {
		 get
		 {
			PV1 ret = null;
			try
			{
			   ret = (PV1)this.GetStructure("PV1");
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
	  /// Returns PV2 (Patient visit - additional information) - creates it if necessary
	  ///</summary>
	  public PV2 PV2
	  {
		 get
		 {
			PV2 ret = null;
			try
			{
			   ret = (PV2)this.GetStructure("PV2");
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
	  /// Returns  first repetition of OBX (Observation segment) - creates it if necessary
	  ///</summary>
	  public OBX GetOBX()
	  {
		 OBX ret = null;
		 try
		 {
			ret = (OBX)this.GetStructure("OBX");
		 }
		 catch (HL7Exception e)
		 {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
			throw new System.Exception("An unexpected error ocurred", e);
		 }
		 return ret;
	  }

	  ///<summary>
	  ///Returns a specific repetition of OBX
	  /// * (Observation segment) - creates it if necessary
	  /// throws HL7Exception if the repetition requested is more than one 
	  ///     greater than the number of existing repetitions.
	  ///</summary>
	  public OBX GetOBX(int rep)
	  {
		 return (OBX)this.GetStructure("OBX", rep);
	  }

	  /** 
	   * Returns the number of existing repetitions of OBX 
	   */
	  public int OBXRepetitionsUsed
	  {
		 get
		 {
			int reps = -1;
			try
			{
			   reps = this.GetAll("OBX").Length;
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
	   * Enumerate over the OBX results 
	   */
	  public IEnumerable<OBX> OBXs
	  {
		 get
		 {
			for (int rep = 0; rep < OBXRepetitionsUsed; rep++)
			{
			   yield return (OBX)this.GetStructure("OBX", rep);
			}
		 }
	  }

	  ///<summary>
	  ///Adds a new OBX
	  ///</summary>
	  public OBX AddOBX()
	  {
		 return this.AddStructure("OBX") as OBX;
	  }

	  ///<summary>
	  ///Removes the given OBX
	  ///</summary>
	  public void RemoveOBX(OBX toRemove)
	  {
		 this.RemoveStructure("OBX", toRemove);
	  }

	  ///<summary>
	  ///Removes the OBX at the given index
	  ///</summary>
	  public void RemoveOBXAt(int index)
	  {
		 this.RemoveRepetition("OBX", index);
	  }

	  ///<summary>
	  /// Returns  first repetition of DG1 (Diagnosis) - creates it if necessary
	  ///</summary>
	  public DG1 GetDG1()
	  {
		 DG1 ret = null;
		 try
		 {
			ret = (DG1)this.GetStructure("DG1");
		 }
		 catch (HL7Exception e)
		 {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
			throw new System.Exception("An unexpected error ocurred", e);
		 }
		 return ret;
	  }

	  ///<summary>
	  ///Returns a specific repetition of DG1
	  /// * (Diagnosis) - creates it if necessary
	  /// throws HL7Exception if the repetition requested is more than one 
	  ///     greater than the number of existing repetitions.
	  ///</summary>
	  public DG1 GetDG1(int rep)
	  {
		 return (DG1)this.GetStructure("DG1", rep);
	  }

	  /** 
	   * Returns the number of existing repetitions of DG1 
	   */
	  public int DG1RepetitionsUsed
	  {
		 get
		 {
			int reps = -1;
			try
			{
			   reps = this.GetAll("DG1").Length;
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
	   * Enumerate over the DG1 results 
	   */
	  public IEnumerable<DG1> DG1s
	  {
		 get
		 {
			for (int rep = 0; rep < DG1RepetitionsUsed; rep++)
			{
			   yield return (DG1)this.GetStructure("DG1", rep);
			}
		 }
	  }

	  ///<summary>
	  ///Adds a new DG1
	  ///</summary>
	  public DG1 AddDG1()
	  {
		 return this.AddStructure("DG1") as DG1;
	  }

	  ///<summary>
	  ///Removes the given DG1
	  ///</summary>
	  public void RemoveDG1(DG1 toRemove)
	  {
		 this.RemoveStructure("DG1", toRemove);
	  }

	  ///<summary>
	  ///Removes the DG1 at the given index
	  ///</summary>
	  public void RemoveDG1At(int index)
	  {
		 this.RemoveRepetition("DG1", index);
	  }

   }
}
