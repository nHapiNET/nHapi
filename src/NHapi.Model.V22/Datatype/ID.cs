using System;

using NHapi.Base.Model;
namespace NHapi.Model.V22.Datatype
{
   /// <summary>
   /// Summary description for ID.
   /// </summary>
   public class ID : NHapi.Base.Model.Primitive.ID
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
	  public ID(IMessage theMessage)
		  : base(theMessage)
	  {
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="theMessage">message to which this Type belongs</param>
	  /// <param name="description">The description of this type</param>
	  public ID(IMessage theMessage, string description)
		  : base(theMessage, description)
	  {
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="theMessage">message to which this Type belongs</param>
	  /// <param name="theTable">The table which this type belongs</param>
	  public ID(IMessage theMessage, int theTable)
		  : base(theMessage, theTable)
	  {
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="theMessage">message to which this Type belongs</param>
	  /// <param name="theTable">The table which this type belongs</param>
	  /// <param name="description">The description of this type</param>
	  public ID(IMessage theMessage, int theTable, string description)
		  : base(theMessage, theTable, description)
	  {
	  }
   }
}
