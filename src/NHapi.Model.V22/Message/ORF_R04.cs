using System;
using System.Collections.Generic;
using NHapi.Base.Log;
using NHapi.Model.V22.Group;
using NHapi.Model.V22.Segment;
using NHapi.Model.V22.Datatype;
using NHapi.Base;
using NHapi.Base.Parser;
using NHapi.Base.Model;

namespace NHapi.Model.V22.Message

{
///<summary>
/// Represents a ORF_R04 message structure (see chapter [AAA]). This structure contains the 
/// following elements:
///<ol>
///<li>0: MSH (MESSAGE HEADER) </li>
///<li>1: MSA (MESSAGE ACKNOWLEDGMENT) </li>
///<li>2: ORF_R04_QUERY_RESPONSE (a Group object) repeating</li>
///<li>3: ORF_R04_ORDER (a Group object) repeating</li>
///<li>4: DSC (CONTINUATION POINTER) optional </li>
///</ol>
///</summary>
[Serializable]
public class ORF_R04 : AbstractMessage  {

	///<summary> 
	/// Creates a new ORF_R04 Group with custom IModelClassFactory.
	///</summary>
	public ORF_R04(IModelClassFactory factory) : base(factory){
	   init(factory);
	}

	///<summary>
	/// Creates a new ORF_R04 Group with DefaultModelClassFactory. 
	///</summary> 
	public ORF_R04() : base(new DefaultModelClassFactory()) { 
	   init(new DefaultModelClassFactory());
	}

	///<summary>
	/// initalize method for ORF_R04.  This does the segment setup for the message. 
	///</summary> 
	private void init(IModelClassFactory factory) {
	   try {
	      this.add(typeof(MSH), true, false);
	      this.add(typeof(MSA), true, false);
	      this.add(typeof(ORF_R04_QUERY_RESPONSE), true, true);
	      this.add(typeof(ORF_R04_ORDER), true, true);
	      this.add(typeof(DSC), false, false);
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error creating ORF_R04 - this is probably a bug in the source code generator.", e);
	   }
	}


	public override string Version
		{
			get{
			return Constants.VERSION;
			}
		}
	///<summary>
	/// Returns MSH (MESSAGE HEADER) - creates it if necessary
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
	/// Returns MSA (MESSAGE ACKNOWLEDGMENT) - creates it if necessary
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
	/// Returns  first repetition of ORF_R04_QUERY_RESPONSE (a Group object) - creates it if necessary
	///</summary>
	public ORF_R04_QUERY_RESPONSE GetQUERY_RESPONSE() {
	   ORF_R04_QUERY_RESPONSE ret = null;
	   try {
	      ret = (ORF_R04_QUERY_RESPONSE)this.GetStructure("QUERY_RESPONSE");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORF_R04_QUERY_RESPONSE
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORF_R04_QUERY_RESPONSE GetQUERY_RESPONSE(int rep) { 
	   return (ORF_R04_QUERY_RESPONSE)this.GetStructure("QUERY_RESPONSE", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORF_R04_QUERY_RESPONSE 
	 */ 
	public int QUERY_RESPONSERepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("QUERY_RESPONSE").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORF_R04_QUERY_RESPONSE results 
	 */ 
	public IEnumerable<ORF_R04_QUERY_RESPONSE> QUERY_RESPONSEs 
	{ 
		get
		{
			for (int rep = 0; rep < QUERY_RESPONSERepetitionsUsed; rep++)
			{
				yield return (ORF_R04_QUERY_RESPONSE)this.GetStructure("QUERY_RESPONSE", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORF_R04_QUERY_RESPONSE
	///</summary>
	public ORF_R04_QUERY_RESPONSE AddQUERY_RESPONSE()
	{
		return this.AddStructure("QUERY_RESPONSE") as ORF_R04_QUERY_RESPONSE;
	}

	///<summary>
	///Removes the given ORF_R04_QUERY_RESPONSE
	///</summary>
	public void RemoveQUERY_RESPONSE(ORF_R04_QUERY_RESPONSE toRemove)
	{
		this.RemoveStructure("QUERY_RESPONSE", toRemove);
	}

	///<summary>
	///Removes the ORF_R04_QUERY_RESPONSE at the given index
	///</summary>
	public void RemoveQUERY_RESPONSEAt(int index)
	{
		this.RemoveRepetition("QUERY_RESPONSE", index);
	}

	///<summary>
	/// Returns  first repetition of ORF_R04_ORDER (a Group object) - creates it if necessary
	///</summary>
	public ORF_R04_ORDER GetORDER() {
	   ORF_R04_ORDER ret = null;
	   try {
	      ret = (ORF_R04_ORDER)this.GetStructure("ORDER");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}

	///<summary>
	///Returns a specific repetition of ORF_R04_ORDER
	/// * (a Group object) - creates it if necessary
	/// throws HL7Exception if the repetition requested is more than one 
	///     greater than the number of existing repetitions.
	///</summary>
	public ORF_R04_ORDER GetORDER(int rep) { 
	   return (ORF_R04_ORDER)this.GetStructure("ORDER", rep);
	}

	/** 
	 * Returns the number of existing repetitions of ORF_R04_ORDER 
	 */ 
	public int ORDERRepetitionsUsed { 
get{
	    int reps = -1; 
	    try { 
	        reps = this.GetAll("ORDER").Length; 
	    } catch (HL7Exception e) { 
	        string message = "Unexpected error accessing data - this is probably a bug in the source code generator."; 
	        HapiLogFactory.GetHapiLog(GetType()).Error(message, e); 
	        throw new System.Exception(message);
	    } 
	    return reps; 
	}
	} 

	/** 
	 * Enumerate over the ORF_R04_ORDER results 
	 */ 
	public IEnumerable<ORF_R04_ORDER> ORDERs 
	{ 
		get
		{
			for (int rep = 0; rep < ORDERRepetitionsUsed; rep++)
			{
				yield return (ORF_R04_ORDER)this.GetStructure("ORDER", rep);
			}
		}
	}

	///<summary>
	///Adds a new ORF_R04_ORDER
	///</summary>
	public ORF_R04_ORDER AddORDER()
	{
		return this.AddStructure("ORDER") as ORF_R04_ORDER;
	}

	///<summary>
	///Removes the given ORF_R04_ORDER
	///</summary>
	public void RemoveORDER(ORF_R04_ORDER toRemove)
	{
		this.RemoveStructure("ORDER", toRemove);
	}

	///<summary>
	///Removes the ORF_R04_ORDER at the given index
	///</summary>
	public void RemoveORDERAt(int index)
	{
		this.RemoveRepetition("ORDER", index);
	}

	///<summary>
	/// Returns DSC (CONTINUATION POINTER) - creates it if necessary
	///</summary>
	public DSC DSC { 
get{
	   DSC ret = null;
	   try {
	      ret = (DSC)this.GetStructure("DSC");
	   } catch(HL7Exception e) {
	      HapiLogFactory.GetHapiLog(GetType()).Error("Unexpected error accessing data - this is probably a bug in the source code generator.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
	}
	}

}
}
