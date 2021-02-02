namespace NHapi.Base.Model.Configuration
{
    using System;
    using System.Configuration;

    public class HL7PackageConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public HL7PackageCollection Packages
        {
            get { return (HL7PackageCollection)this[string.Empty]; }
        }
    }

    public class HL7PackageCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new HL7PackageElement();
        }

        protected override string ElementName
        {
            get { return "HL7Package"; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if ( element is HL7PackageElement)
            {
                HL7PackageElement el = (HL7PackageElement)element;

                return el.Name;
            }

            throw new ArgumentException("The specified element is not of the correct type.");
        }
    }

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