namespace NHapi.Base.Model.Configuration
{
    using System;
    using System.Configuration;

    public class HL7PackageCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "HL7Package"; }
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            if (element is HL7PackageElement)
            {
                HL7PackageElement el = (HL7PackageElement)element;

                return el.Name;
            }

            throw new ArgumentException("The specified element is not of the correct type.");
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new HL7PackageElement();
        }
    }
}