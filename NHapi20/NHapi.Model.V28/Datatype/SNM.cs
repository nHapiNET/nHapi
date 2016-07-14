using System;

using NHapi.Base.Model;
namespace NHapi.Model.V28.Datatype
{
/// <summary>/// Summary description for SNM.
/// </summary>
public class SNM: AbstractPrimitive
{
/// <summary>Return the version
/// <returns>2.8</returns>
///</summary>

            virtual public System.String Version
            {
			    get
			    {
				    return "2.8";
			    }
		    }
            


                ///<summary>Construct the type
                ///<param name="theMessage">message to which this Type belongs</param>
                ///</summary>
                public SNM(IMessage theMessage):base(theMessage)
                {}
                


                ///<summary>Construct the type
                ///<param name="message">message to which this Type belongs</param>
                ///<param name="description">The description of this type</param>
                ///</summary>
		        public SNM(IMessage message, string description) : base(message,description)
    	        {}
                }}