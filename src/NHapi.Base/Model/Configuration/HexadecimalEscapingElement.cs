namespace NHapi.Base.Model.Configuration
{
    using System.Configuration;

    using NHapi.Base.Parser;

    public class HexadecimalEscapingElement : ConfigurationElement
    {
        [ConfigurationProperty("lineFeedHexadecimal", DefaultValue = LineFeedHexadecimal.X0A)]
        public LineFeedHexadecimal LineFeedHexadecimal
        {
            get { return (LineFeedHexadecimal)this["lineFeedHexadecimal"]; }
            set { this["lineFeedHexadecimal"] = value; }
        }

        [ConfigurationProperty("carriageReturnHexadecimal", DefaultValue = CarriageReturnHexadecimal.X0D)]
        public CarriageReturnHexadecimal CarriageReturnHexadecimal
        {
            get { return (CarriageReturnHexadecimal)this["carriageReturnHexadecimal"]; }
            set { this["carriageReturnHexadecimal"] = value; }
        }
    }
}