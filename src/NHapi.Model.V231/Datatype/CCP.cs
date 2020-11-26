using System;
using NHapi.Base.Model;
using NHapi.Base.Log;
using NHapi.Base;
using NHapi.Base.Model.Primitive;

namespace NHapi.Model.V231.Datatype
{

///<summary>
/// <p>The HL7 CCP (channel calibration parameters) data type.  Consists of the following components: </p><ol>
/// <li>channel calibration sensitivity correction factor (NM)</li>
/// <li>channel calibration baseline (NM)</li>
/// <li>channel calibration time skew (NM)</li>
/// </ol>
///</summary>
[Serializable]
public class CCP : AbstractType, IComposite{
	private IType[] data;

	///<summary>
	/// Creates a CCP.
	/// <param name="message">The Message to which this Type belongs</param>
	///</summary>
	public CCP(IMessage message) : this(message, null){}

	///<summary>
	/// Creates a CCP.
	/// <param name="message">The Message to which this Type belongs</param>
	/// <param name="description">The description of this type</param>
	///</summary>
	public CCP(IMessage message, string description) : base(message, description){
		data = new IType[3];
		data[0] = new NM(message,"Channel calibration sensitivity correction factor");
		data[1] = new NM(message,"Channel calibration baseline");
		data[2] = new NM(message,"Channel calibration time skew");
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
			throw new DataTypeException("Element " + index + " doesn't exist in 3 element CCP composite"); 
		} 
	} 
	} 
	///<summary>
	/// Returns channel calibration sensitivity correction factor (component #0).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM ChannelCalibrationSensitivityCorrectionFactor {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[0];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns channel calibration baseline (component #1).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM ChannelCalibrationBaseline {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[1];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
	///<summary>
	/// Returns channel calibration time skew (component #2).  This is a convenience method that saves you from 
	/// casting and handling an exception.
	///</summary>
	public NM ChannelCalibrationTimeSkew {
get{
	   NM ret = null;
	   try {
	      ret = (NM)this[2];
	   } catch (DataTypeException e) {
	      HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem accessing known data type component - this is a bug.", e);
	      throw new System.Exception("An unexpected error ocurred",e);
	   }
	   return ret;
}

}
}}