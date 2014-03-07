using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Base.Log;
using System;
using NHapi.Model.V25UCH.Segment;

using NHapi.Base.Model;

namespace NHapi.Model.V25UCH.Group
{
///<summary>
///Represents the NMD_N02_CLOCK_AND_STATS_WITH_NOTES Group.  A Group is an ordered collection of message 
/// segments that can repeat together or be optionally in/excluded together.
/// This Group contains the following elements: 
///<ol>
///<li>0: NMD_N02_CLOCK (a Group object) optional </li>
///<li>1: NMD_N02_APP_STATS (a Group object) optional </li>
///<li>2: NMD_N02_APP_STATUS (a Group object) optional </li>
///</ol>
///</summary>
[Serializable]
public class NMD_N02_CLOCK_AND_STATS_WITH_NOTES : AbstractGroup {

	///<summary> 
	/// Creates a new NMD_N02_CLOCK_AND_STATS_WITH_NOTES Group.
	///</summary>
	public NMD_N02_CLOCK_AND_STATS_WITH_NOTES(IGroup parent, IModelClassFactory factory) : base(parent, factory){
	   try {
	      this.add(typeof(NMD_N02_CLOCK), false, false);
	      this.add(typeof(NMD_N02_APP_STATS), false, false);
	      this.add(typeof(NMD_N02_APP_STATUS), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating NMD_N02_CLOCK_AND_STATS_WITH_NOTES - this is probably a bug in the source code generator.", e);
	   }
	}

	///<summary>
	/// Returns NMD_N02_CLOCK (a Group object) - creates it if necessary
	///</summary>
	public NMD_N02_CLOCK CLOCK { 
get{
	   NMD_N02_CLOCK ret = null;
	   try {
	      ret = (NMD_N02_CLOCK)this.GetStructure("CLOCK");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns NMD_N02_APP_STATS (a Group object) - creates it if necessary
	///</summary>
	public NMD_N02_APP_STATS APP_STATS { 
get{
	   NMD_N02_APP_STATS ret = null;
	   try {
	      ret = (NMD_N02_APP_STATS)this.GetStructure("APP_STATS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

	///<summary>
	/// Returns NMD_N02_APP_STATUS (a Group object) - creates it if necessary
	///</summary>
	public NMD_N02_APP_STATUS APP_STATUS { 
get{
	   NMD_N02_APP_STATUS ret = null;
	   try {
	      ret = (NMD_N02_APP_STATUS)this.GetStructure("APP_STATUS");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
