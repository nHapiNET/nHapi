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
   ///Represents the SIU_S26_PERSONNEL_RESOURCE Group.  A Group is an ordered collection of message 
   /// segments that can repeat together or be optionally in/excluded together.
   /// This Group contains the following elements: 
   ///<ol>
   ///<li>0: AIP (Appointment Information - Personnel Resource) </li>
   ///<li>1: NTE (Notes and comments segment) optional repeating</li>
   ///</ol>
   ///</summary>
   [Serializable]
   public class SIU_S26_PERSONNEL_RESOURCE : AbstractGroup
   {

	  ///<summary> 
	  /// Creates a new SIU_S26_PERSONNEL_RESOURCE Group.
	  ///</summary>
	  public SIU_S26_PERSONNEL_RESOURCE(IGroup parent, IModelClassFactory factory) : base(parent, factory)
	  {
		 try
		 {
			this.add(typeof(AIP), true, false);
			this.add(typeof(NTE), false, true);
		 }
		 catch (HL7Exception e)
		 {
			HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating SIU_S26_PERSONNEL_RESOURCE - this is probably a bug in the source code generator.", e);
		 }
	  }

	  ///<summary>
	  /// Returns AIP (Appointment Information - Personnel Resource) - creates it if necessary
	  ///</summary>
	  public AIP AIP
	  {
		 get
		 {
			AIP ret = null;
			try
			{
			   ret = (AIP)this.GetStructure("AIP");
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

   }
}
