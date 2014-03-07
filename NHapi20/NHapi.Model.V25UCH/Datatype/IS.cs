using System;

using NHapi.Base.Model;
namespace NHapi.Model.V25UCH.Datatype
{
/// <summary>/// Summary description for IS.
/// </summary>
public class IS: NHapi.Base.Model.Primitive.IS
{
/// <summary>Return the version
/// <returns>2.5.UCH</returns>
///</summary>

            virtual public System.String Version
            {
			    get
			    {
				    return "2.5.UCH";
			    }
		    }
            


                ///<summary>Construct the type
                ///<param name="theMessage">message to which this Type belongs</param>
                ///<param name="theTable">The table which this type belongs</param>
                ///</summary>
                public IS(IMessage theMessage,int theTable):base(theMessage, theTable)
                {}
                


                ///<summary>Construct the type
                ///<param name="message">message to which this Type belongs</param>
                ///<param name="theTable">The table which this type belongs</param>
                ///<param name="description">The description of this type</param>
                ///</summary>
		        public IS(IMessage message, int theTable, string description) : base(message,theTable, description)
    	        {}
                }}