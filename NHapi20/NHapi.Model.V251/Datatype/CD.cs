using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V251.Datatype
{

///<summary>
/// <p>The HL7 CD (Channel Definition) data type.  Consists of the following components: </p><ol>
/// <li>Channel Identifier (WVI)</li>
/// <li>Waveform Source (WVS)</li>
/// <li>Channel Sensitivity/Units (CSU)</li>
/// <li>Channel Calibration Parameters (CCP)</li>
/// <li>Channel Sampling Frequency (NM)</li>
/// <li>Minimum/Maximum Data Values (NR)</li>
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
		data[0] = new WVI(message,"Channel Identifier");
		data[1] = new WVS(message,"Waveform Source");
		data[2] = new CSU(message,"Channel Sensitivity/Units");
		data[3] = new CCP(message,"Channel Calibration Parameters");
		data[4] = new NM(message,"Channel Sampling Frequency");
		data[5] = new NR(message,"Minimum/Maximum Data Values");
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
	/// Returns Channel Identifier (component #0).  This is a convenience method that saves you from 
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
	/// Returns Waveform Source (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public WVS WaveformSource {
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
	/// Returns Channel Sensitivity/Units (component #2).  This is a convenience method that saves you from 
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
	/// Returns Channel Calibration Parameters (component #3).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public CCP ChannelCalibrationParameters {
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
	/// Returns Channel Sampling Frequency (component #4).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM ChannelSamplingFrequency {
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
	/// Returns Minimum/Maximum Data Values (component #5).  This is a convenience method that saves you from 
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