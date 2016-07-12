using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V26.Segment;
using NHapi.Model.V26.Datatype;
using NHapi.Base.Model;

namespace NHapi.Model.V26.Group
{
///<summary>
///Represents the NMQ_N01_CLOCK_AND_STATISTICS Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: NCK (System Clock) optional </li>
///<li>1: NST (Application control level statistics) optional </li>
///<li>2: NSC (Application Status Change) optional </li>
///</ol>
///</summary>
[Serializable]
public class NMQ_N01_CLOCK_AND_STATISTICS : AbstractGroup {

	///<summary> 
	/// Creates a new NMQ_N01_CLOCK_AND_STATISTICS Group.
	///</summary>
	public NMQ_N01_CLOCK_AND_STATISTICS(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(NCK), false, false);
	      this.add(typeof(NST), false, false);
	      this.add(typeof(NSC), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating NMQ_N01_CLOCK_AND_STATISTICS - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns NCK (System Clock) - creates it if necessary
	///</summary>
	public NCK NCK { 
get{
	   NCK ret = null;
	   try {
	      ret = (NCK)this.GetStructure("NCK");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns NST (Application control level statistics) - creates it if necessary
	///</summary>
	public NST NST { 
get{
	   NST ret = null;
	   try {
	      ret = (NST)this.GetStructure("NST");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns NSC (Application Status Change) - creates it if necessary
	///</summary>
	public NSC NSC { 
get{
	   NSC ret = null;
	   try {
	      ret = (NSC)this.GetStructure("NSC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
