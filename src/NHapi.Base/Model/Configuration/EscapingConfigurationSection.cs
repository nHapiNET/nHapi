namespace NHapi.Base.Model.Configuration
{
    using System.Configuration;

    public class EscapingConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("HexadecimalEscaping")]
        public HexadecimalEscapingElement HexadecimalEscaping
        {
            get { return this["HexadecimalEscaping"] as HexadecimalEscapingElement; }
            set { this["HexadecimalEscaping"] = value; }
        }
    }
}