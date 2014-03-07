using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V23UCH.Datatype
{

///<summary>
/// <p>The HL7 CD (Channel Definition (2.8.2)) data type.  Consists of the following components: </p><ol>
/// <li>channel identifier (CM_WVI)</li>
/// <li>electrode names (CM_CD_ELECTRODE)</li>
/// <li>channel sensitivity/units (CM_CSU)</li>
/// <li>calibration parameters (CM_CCP)</li>
/// <li>sampling frequency (NM)</li>
/// <li>minimum/maximum data values (CM_MDV)</li>
/// </ol>
///</summary>
[Serializable]
public class CD : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CD.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CD(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CD.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CD(IMessage message, string description) : base(message, description){
		data = new IType[6];
		data[0] = new CM_WVI(message,"Channel identifier");
		data[1] = new CM_CD_ELECTRODE(message,"Electrode names");
		data[2] = new CM_CSU(message,"Channel sensitivity/units");
		data[3] = new CM_CCP(message,"Calibration parameters");
		data[4] = new NM(message,"Sampling frequency");
		data[5] = new CM_MDV(message,"Minimum/maximum data values");
	}

	///<summary>
	/// Returns an array containing the data elements.
	///</summary>
	public IType[] Components
	{ 
		get{
			return this.data; 
		}
	}

	///<summary>
	/// Returns an individual data component.
	/// @throws DataTypeException if the given element number is out of range.
	///<param name="index">The index item to get (zero based)</param>
	///<returns>The data component (as a type) at the requested number (ordinal)</returns>
	///</summary>
	public IType this[int index] { 

get{
		try { 
			return this.data[index]; 
		} catch (System.ArgumentOutOfRangeException) { 
			throw new DataTypeException("Element " + index + " doesn't exist in 6 element CD composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns channel identifier (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CM_WVI ChannelIdentifier {
get{
	   CM_WVI ret = null;
	   try {
	      ret = (CM_WVI)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns electrode names (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CM_CD_ELECTRODE ElectrodeNames {
get{
	   CM_CD_ELECTRODE ret = null;
	   try {
	      ret = (CM_CD_ELECTRODE)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns channel sensitivity/units (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CM_CSU ChannelSensitivityUnits {
get{
	   CM_CSU ret = null;
	   try {
	      ret = (CM_CSU)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns calibration parameters (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CM_CCP CalibrationParameters {
get{
	   CM_CCP ret = null;
	   try {
	      ret = (CM_CCP)this[3];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns sampling frequency (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM SamplingFrequency {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[4];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns minimum/maximum data values (component #5).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CM_MDV MinimumMaximumDataValues {
get{
	   CM_MDV ret = null;
	   try {
	      ret = (CM_MDV)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}