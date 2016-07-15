using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using System.Collections.Generic;
using NHapi.Model.V27.Segment;
using NHapi.Model.V27.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V27.Group
{
///<summary>
///Represents the ORL_O40_PACKAGE Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: PAC (Shipment Package) </li>
///<li>1: ORL_O40_SPECIMEN_IN_PACKAGE (a Group object) optional repeating</li>
///</ol>
///</summary>
[Serializable]
public class ORL_O40_PACKAGE : AbstractGroup {

	///<summary> 
	/// Creates a new ORL_O40_PACKAGE Group.
	///</summary>
	public ORL_O40_PACKAGE(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(PAC), true, false);
	      this.add(typeof(ORL_O40_SPECIMEN_IN_PACKAGE), false, true);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORL_O40_PACKAGE - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns PAC (Shipment Package) - creates it if necessary
	///</summary>
	public PAC PAC { 
get{
	   PAC ret = null;
	   try {
	      ret = (PAC)this.GetStructure("PAC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns  first repetition of ORL_O40_SPECIMEN_IN_PACKAGE (a Group object) - creates it if necessary
	///</summary>
	public ORL_O40_SPECIMEN_IN_PACKAGE GetSPECIMEN_IN_PACKAGE() {
	   ORL_O40_SPECIMEN_IN_PACKAGE ret = null;
	   try {
	      ret = (ORL_O40_SPECIMEN_IN_PACKAGE)this.GetStructure("SPECIMEN_IN_PACKAGE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORL_O40_SPECIMEN_IN_PACKAGE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORL_O40_SPECIMEN_IN_PACKAGE GetSPECIMEN_IN_PACKAGE(int rep) { 
	   return (ORL_O40_SPECIMEN_IN_PACKAGE)this.GetStructure("SPECIMEN_IN_PACKAGE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORL_O40_SPECIMEN_IN_PACKAGE 
	 */ 
	public int SPECIMEN_IN_PACKAGERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("SPECIMEN_IN_PACKAGE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORL_O40_SPECIMEN_IN_PACKAGE results 
	 */ 
	public IEnumerable<ORL_O40_SPECIMEN_IN_PACKAGE> SPECIMEN_IN_PACKAGEs 
	{ 
		get
		{
			for (int rep = 0; rep < SPECIMEN_IN_PACKAGERepetitionsUsed; rep++)
			{
				yield return (ORL_O40_SPECIMEN_IN_PACKAGE)this.GetStructure("SPECIMEN_IN_PACKAGE", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORL_O40_SPECIMEN_IN_PACKAGE
	///</summary>
	public ORL_O40_SPECIMEN_IN_PACKAGE AddSPECIMEN_IN_PACKAGE()
	{
		return this.AddStructure("SPECIMEN_IN_PACKAGE") as ORL_O40_SPECIMEN_IN_PACKAGE;
	}

	///<summary>
	///Removes the given ORL_O40_SPECIMEN_IN_PACKAGE
	///</summary>
	public void RemoveSPECIMEN_IN_PACKAGE(ORL_O40_SPECIMEN_IN_PACKAGE toRemove)
	{
		this.RemoveStructure("SPECIMEN_IN_PACKAGE", toRemove);
	}

	///<summary>
	///Removes the ORL_O40_SPECIMEN_IN_PACKAGE at the given index
	///</summary>
	public void RemoveSPECIMEN_IN_PACKAGEAt(int index)
	{
		this.RemoveRepetition("SPECIMEN_IN_PACKAGE", index);
	}

}
}
