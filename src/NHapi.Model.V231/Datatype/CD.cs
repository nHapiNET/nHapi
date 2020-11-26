using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V231.Datatype
{

///<summary>
/// <p>The HL7 CD (channel definition) data type.  Consists of the following components: </p><ol>
/// <li>channel identifier (WVI)</li>
/// <li>electrode names (WVS)</li>
/// <li>channel sensitivity/units (CSU)</li>
/// <li>calibration parameters (CCP)</li>
/// <li>sampling frequency (NM)</li>
/// <li>minimum/maximum data values (NR)</li>
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
		data[0] = new WVI(message,"Channel identifier");
		data[1] = new WVS(message,"Electrode names");
		data[2] = new CSU(message,"Channel sensitivity/units");
		data[3] = new CCP(message,"Calibration parameters");
		data[4] = new NM(message,"Sampling frequency");
		data[5] = new NR(message,"Minimum/maximum data values");
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
	public WVI ChannelIdentifier {
get{
	   WVI ret = null;
	   try {
	      ret = (WVI)this[0];
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
	public WVS ElectrodeNames {
get{
	   WVS ret = null;
	   try {
	      ret = (WVS)this[1];
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
	public CSU ChannelSensitivityUnits {
get{
	   CSU ret = null;
	   try {
	      ret = (CSU)this[2];
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
	public CCP CalibrationParameters {
get{
	   CCP ret = null;
	   try {
	      ret = (CCP)this[3];
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
	public NR MinimumMaximumDataValues {
get{
	   NR ret = null;
	   try {
	      ret = (NR)this[5];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}