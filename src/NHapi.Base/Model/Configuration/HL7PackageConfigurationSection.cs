namespace NHapi.Base.Model.Configuration
{
    using System.Configuration;

    public class HL7PackageConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public HL7PackageCollection Packages
        {
            get { return (HL7PackageCollection)this[string.Empty]; }
        }
    }
}