using System;

using NHapi.Base.Model;
namespace NHapi.Model.V22.Datatype
{
   /// <summary>
   /// Summary description for DT.
   /// </summary>
   public class DT : NHapi.Base.Model.Primitive.DT
   {
	  /// <value>
	  /// Return the version
	  /// </value>
	  /// <returns>2.2</returns>
	  virtual public System.String Version
	  {
		 get
		 {
			return "2.2";
		 }
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="theMessage">message to which this Type belongs</param>
	  public DT(IMessage theMessage)
		  : base(theMessage)
	  {
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="theMessage">message to which this Type belongs</param>
	  /// <param name="description">The description of this type</param>
	  public DT(IMessage theMessage, string description)
		  : base(theMessage, description)
	  {
	  }
   }
}
