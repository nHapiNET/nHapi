using System;

using NHapi.Base.Model;
namespace NHapi.Model.V26.Datatype
{
   /// <summary>
   /// Summary description for TM.
   /// </summary>
   public class TM : NHapi.Base.Model.Primitive.TM
   {
	  /// <value>
	  /// Return the version
	  ///</value>
	  /// <returns>2.6</returns>
	  virtual public System.String Version
	  {
		 get
		 {
			return "2.6";
		 }
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="theMessage">message to which this Type belongs</param>
	  public TM(IMessage theMessage)
	  		: base(theMessage)
	  {
	  }

	  /// <summary>Construct the type</summary>
	  /// <param name="theMessage">message to which this Type belongs</param>
	  /// <param name="description">The description of this type</param>
	  public TM(IMessage theMessage, string description)
	  		: base(theMessage, description)
	  {
	  }
   }
}
