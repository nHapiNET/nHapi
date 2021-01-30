using System;

using NHapi.Base;
using NHapi.Base.Log;
using NHapi.Base.Model;
using NHapi.Base.Model.Primitive;
using NHapi.Base.Parser;
using NHapi.Model.V22.Datatype;
using NHapi.Model.V22_ZSegments.Datatype;

namespace NHapi.Model.V22_ZSegments.Segment
{

   /// <summary>
   /// Additional insurance data (for main insurance code 1, 2).
   /// <para>
   /// This segment has the following fields:
   /// <list type="bullet">
   /// <item><term>ZIN-1</term><description>Addition Operation</description></item>
   /// <item><term>ZIN-2</term><description>Number patient (ST)</description></item>
   /// <item><term>ZIN-3</term><description>Insurability 1 (ex 110 = unemployed) <br />
   ///	- All risks of the general regulation<br />
   ///	- Only great risks of self-employees<br />
   ///	- International treaties(NM)
   /// </description></item>
   /// <item><term>ZIN-4</term><description>Insurability 2 (ex 900 voluntary insurance against 75%) - Small risks of the voluntary insurance (NM)</description></item>
   /// <item><term>ZIN-5</term><description>Accident data (ACCIDENTDATA)</description></item>
   /// <item><term>ZIN-6</term><description>Accident timestamp (TSComponentOne)</description></item>
   /// </list>
   /// </para>
   /// <para>
   /// The get...() methods return data from individual fields. These methods 
   /// do not throw exceptions and may therefore have to handle exceptions internally.
   /// If an exception is handled internally, it is logged and null is returned.
   /// This is not expected to happen - if it does happen this indicates not so much
   /// an exceptional circumstance as a bug in the code for this class.
   /// </para>
   /// </summary>	
   [Serializable]
	public class ZIN : AbstractSegment
	{
		#region Constructor

		public ZIN(IGroup parent, IModelClassFactory factory) : base(parent, factory)
		{
			IMessage message = Message;
			try
			{
				this.add(typeof(ST), false, 1, 13, new System.Object[] { message }, "Number contractee");
				this.add(typeof(ST), false, 1, 13, new System.Object[] { message }, "Number patient");
				this.add(typeof(NM), false, 1, 3, new System.Object[] { message }, "Insurability 1");
				this.add(typeof(NM), false, 1, 3, new System.Object[] { message }, "Insurability 2");
				this.add(typeof(ACCIDENTDATA), false, 1, 55, new System.Object[] { message }, "Accident data");
				this.add(typeof(TSComponentOne), false, 1, 10, new System.Object[] { message }, "Accident timestamp");
			}
			catch (HL7Exception he)
			{
				HapiLogFactory.GetHapiLog(this.GetType()).Error("Can't instantiate " + this.GetType().Name, he);
			}
		}

		#endregion

		#region Properties

		/// <summary>
		/// Returns Number contractee(ZIN-1).
		/// </summary>
		public ST ContracteeNumber
		{
			get
			{
				ST ret = null;
				try
				{
					IType t = this.GetField(2, 0);
					ret = (ST)t;
				}
				catch (HL7Exception he)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
					throw new System.Exception("An unexpected error ocurred", he);
				}
				catch (Exception ex)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
					throw new System.Exception("An unexpected error ocurred", ex);
				}
				return ret;
			}
		}

		/// <summary>
		/// Returns Number patient(ZIN-2).
		/// </summary>
		public ST PatientNumber
		{
			get
			{
				ST ret = null;
				try
				{
					IType t = this.GetField(2, 0);
					ret = (ST)t;
				}
				catch (HL7Exception he)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
					throw new System.Exception("An unexpected error ocurred", he);
				}
				catch (Exception ex)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
					throw new System.Exception("An unexpected error ocurred", ex);
				}
				return ret;
			}
		}

		/// <summary>
		/// Returns Insurability 1(ZIN-3).
		/// (ex 110 = unemployed)
		///		- All risks of the general regulation
		///		- Only great risks of self-employees
		///		- International treaties
		/// </summary>
		public NM Insurability1
		{
			get
			{
				NM ret = null;
				try
				{
					IType t = this.GetField(3, 0);
					ret = (NM)t;
				}
				catch (HL7Exception he)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
					throw new System.Exception("An unexpected error ocurred", he);
				}
				catch (Exception ex)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
					throw new System.Exception("An unexpected error ocurred", ex);
				}
				return ret;
			}
		}

		/// <summary>
		/// Returns Insurability 2(ZIN-4).
		/// (ex 900 voluntary insurance against 75%)
		///		- Small risks of the voluntary insurance
		/// </summary>
		public NM Insurability2
		{
			get
			{
				NM ret = null;
				try
				{
					IType t = this.GetField(4, 0);
					ret = (NM)t;
				}
				catch (HL7Exception he)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
					throw new System.Exception("An unexpected error ocurred", he);
				}
				catch (Exception ex)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
					throw new System.Exception("An unexpected error ocurred", ex);
				}
				return ret;
			}
		}

		/// <summary>
		/// Returns Accident data(ZIN-5).
		/// </summary>
		public ACCIDENTDATA AccidentData
		{
			get
			{
				ACCIDENTDATA ret = null;
				try
				{
					IType t = this.GetField(5, 0);
					ret = (ACCIDENTDATA)t;
				}
				catch (HL7Exception he)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
					throw new System.Exception("An unexpected error ocurred", he);
				}
				catch (Exception ex)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
					throw new System.Exception("An unexpected error ocurred", ex);
				}
				return ret;
			}
		}

		/// <summary>
		/// Returns Accident timestamp(ZIN-6).
		/// </summary>
		public TSComponentOne AccidentTimestamp
		{
			get
			{
				TSComponentOne ret = null;
				try
				{
					IType t = this.GetField(6, 0);
					ret = (TSComponentOne)t;
				}
				catch (HL7Exception he)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", he);
					throw new System.Exception("An unexpected error ocurred", he);
				}
				catch (Exception ex)
				{
					HapiLogFactory.GetHapiLog(this.GetType()).Error("Unexpected problem obtaining field value.  This is a bug.", ex);
					throw new System.Exception("An unexpected error ocurred", ex);
				}
				return ret;
			}
		}

		#endregion
	}
}
