namespace NHapi.Base.Model.Configuration
{
    using System.Configuration;

    public class HL7PackageElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get { return this["name"].ToString(); }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("version", IsKey = true, IsRequired = true)]
        public string Version
        {
            get { return this["version"].ToString(); }
            set { this["version"] = value; }
        }
    }
}