namespace NHapi.Base
{
    internal class Hl7Package
    {
        public Hl7Package(string packageName, string version)
        {
            Version = version;
            PackageName = packageName;
        }

        public string Version { get; set; }

        public string PackageName { get; }

        public string EventMappingResourceName
        {
            get { return PackageName + "EventMapping.EventMap.properties"; }
        }
    }
}