using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V281.Segment;
using NHapi.Model.V281.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V281.Group
{
///<summary>
///Represents the ADT_A05_INSURANCE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: IN1 (Insurance) </li>
///<li>1: IN2 (Insurance Additional Information) optional </li>
///<li>2: IN3 (Insurance Additional Information, Certification) optional repeating</li>
///<li>3: ROL (Role) optional repeating</li>
///<li>4: AUT (Authorization Information) optional repeating</li>
///<li>5: RF1 (Referral Information) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ADT_A05_INSURANCE : AbstractGroup {

	///<summary> 
	/// Creates a new ADT_A05_INSURANCE Group.
	///</summary>
	public ADT_A05_INSURANCE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(IN1), true, false);
	      this.add(typeof(IN2), false, false);
	      this.add(typeof(IN3), false, true);
	      this.add(typeof(ROL), false, true);
	      this.add(typeof(AUT), false, true);
	      this.add(typeof(RF1), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ADT_A05_INSURANCE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns IN1 (Insurance) - creates it if necessary
	///</summary>
	public IN1 IN1 { 
get{
	   IN1 ret = null;
	   try {
	      ret = (IN1)this.GetStructure("IN1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns IN2 (Insurance Additional Information) - creates it if necessary
	///</summary>
	public IN2 IN2 { 
get{
	   IN2 ret = null;
	   try {
	      ret = (IN2)this.GetStructure("IN2");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of IN3 (Insurance Additional Information, Certification) - creates it if necessary
	///</summary>
	public IN3 GetIN3() {
	   IN3 ret = null;
	   try {
	      ret = (IN3)this.GetStructure("IN3");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of IN3
	/// * (Insurance Additional Information, Certification) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public IN3 GetIN3(int rep) { 
	   return (IN3)this.GetStructure("IN3", rep);
	}

	/** 
	 * Returns the number of existing repetitions of IN3 
	 */ 
	public int IN3RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("IN3").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the IN3 results 
	 */ 
	public IEnumerable<IN3> IN3s 
	{ 
		get
		{
			for (int rep = 0; rep < IN3RepetitionsUsed; rep++)
			{
				yield return (IN3)this.GetStructure("IN3", rep);
			}
		}
	}

	///<summary>
	///Adds a new IN3
	///</summary>
	public IN3 AddIN3()
	{
		return this.AddStructure("IN3") as IN3;
	}

	///<summary>
	///Removes the given IN3
	///</summary>
	public void RemoveIN3(IN3 toRemove)
	{
		this.RemoveStructure("IN3", toRemove);
	}

	///<summary>
	///Removes the IN3 at the given index
	///</summary>
	public void RemoveIN3At(int index)
	{
		this.RemoveRepetition("IN3", index);
	}

	///<summary>
	/// Returns  first repetition of ROL (Role) - creates it if necessary
	///</summary>
	public ROL GetROL() {
	   ROL ret = null;
	   try {
	      ret = (ROL)this.GetStructure("ROL");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ROL
	/// * (Role) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ROL GetROL(int rep) { 
	   return (ROL)this.GetStructure("ROL", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ROL 
	 */ 
	public int ROLRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ROL").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ROL results 
	 */ 
	public IEnumerable<ROL> ROLs 
	{ 
		get
		{
			for (int rep = 0; rep < ROLRepetitionsUsed; rep++)
			{
				yield return (ROL)this.GetStructure("ROL", rep);
			}
		}
	}

	///<summary>
	///Adds a new ROL
	///</summary>
	public ROL AddROL()
	{
		return this.AddStructure("ROL") as ROL;
	}

	///<summary>
	///Removes the given ROL
	///</summary>
	public void RemoveROL(ROL toRemove)
	{
		this.RemoveStructure("ROL", toRemove);
	}

	///<summary>
	///Removes the ROL at the given index
	///</summary>
	public void RemoveROLAt(int index)
	{
		this.RemoveRepetition("ROL", index);
	}

	///<summary>
	/// Returns  first repetition of AUT (Authorization Information) - creates it if necessary
	///</summary>
	public AUT GetAUT() {
	   AUT ret = null;
	   try {
	      ret = (AUT)this.GetStructure("AUT");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of AUT
	/// * (Authorization Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public AUT GetAUT(int rep) { 
	   return (AUT)this.GetStructure("AUT", rep);
	}

	/** 
	 * Returns the number of existing repetitions of AUT 
	 */ 
	public int AUTRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("AUT").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the AUT results 
	 */ 
	public IEnumerable<AUT> AUTs 
	{ 
		get
		{
			for (int rep = 0; rep < AUTRepetitionsUsed; rep++)
			{
				yield return (AUT)this.GetStructure("AUT", rep);
			}
		}
	}

	///<summary>
	///Adds a new AUT
	///</summary>
	public AUT AddAUT()
	{
		return this.AddStructure("AUT") as AUT;
	}

	///<summary>
	///Removes the given AUT
	///</summary>
	public void RemoveAUT(AUT toRemove)
	{
		this.RemoveStructure("AUT", toRemove);
	}

	///<summary>
	///Removes the AUT at the given index
	///</summary>
	public void RemoveAUTAt(int index)
	{
		this.RemoveRepetition("AUT", index);
	}

	///<summary>
	/// Returns  first repetition of RF1 (Referral Information) - creates it if necessary
	///</summary>
	public RF1 GetRF1() {
	   RF1 ret = null;
	   try {
	      ret = (RF1)this.GetStructure("RF1");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of RF1
	/// * (Referral Information) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public RF1 GetRF1(int rep) { 
	   return (RF1)this.GetStructure("RF1", rep);
	}

	/** 
	 * Returns the number of existing repetitions of RF1 
	 */ 
	public int RF1RepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("RF1").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the RF1 results 
	 */ 
	public IEnumerable<RF1> RF1s 
	{ 
		get
		{
			for (int rep = 0; rep < RF1RepetitionsUsed; rep++)
			{
				yield return (RF1)this.GetStructure("RF1", rep);
			}
		}
	}

	///<summary>
	///Adds a new RF1
	///</summary>
	public RF1 AddRF1()
	{
		return this.AddStructure("RF1") as RF1;
	}

	///<summary>
	///Removes the given RF1
	///</summary>
	public void RemoveRF1(RF1 toRemove)
	{
		this.RemoveStructure("RF1", toRemove);
	}

	///<summary>
	///Removes the RF1 at the given index
	///</summary>
	public void RemoveRF1At(int index)
	{
		this.RemoveRepetition("RF1", index);
	}

}
}
