using System;

using NHapi.Base.Model;
namespace NHapi.Model.V27.Datatype
{
   /// <summary>
   /// Summary description for IS.
   /// </summary>
   public class IS : NHapi.Base.Model.Primitive.IS
   {
	  /// <value>
	  /// Return the version
	  /// </value>
	  /// <returns>2.7</returns>

	  virtual public System.String Version
	  {
		 get
		 {
			return "2.7";
		 }
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="theMessage">message to which this Type belongs</param>
	  public IS(IMessage theMessage)
		  : base(theMessage)
	  {
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="theMessage">message to which this Type belongs</param>
	  /// <param name="description">The description of this type</param>
	  public IS(IMessage theMessage, string description)
		  : base(theMessage, description)
	  {
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="theMessage">message to which this Type belongs</param>
	  /// <param name="theTable">The table which this type belongs</param>
	  public IS(IMessage theMessage, int theTable)
	  		: base(theMessage, theTable)
	  {
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="message">message to which this Type belongs</param>
	  /// <param name="theTable">The table which this type belongs</param>
	  /// <param name="description">The description of this type</param>
	  public IS(IMessage message, int theTable, string description)
	  		: base(message, theTable, description)
	  {
	  }
   }
}
