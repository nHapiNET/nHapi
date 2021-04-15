using NHapi.Base.Model;

namespace NHapi.Model.V21.Datatype
{
	/// <summary>
	/// Composite message
	/// </summary>
	public class CM : GenericComposite
	{

		/// <summary>Construct the type</summary>
		/// <param name="theMessage">message to which this Type belongs</param>
		public CM(IMessage theMessage)
			: base(theMessage)
		{
		}

		/// <summary>Construct the type</summary>
		/// <param name="theMessage">message to which this Type belongs</param>
		/// <param name="description">The description of this type</param>
		public CM(IMessage theMessage, string description)
			: base(theMessage, description)
		{
		}
	}
}
