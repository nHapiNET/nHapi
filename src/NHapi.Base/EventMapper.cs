namespace NHapi.Base
{
    using System.Collections;
    using System.Collections.Specialized;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal class EventMapper
    {
        private static readonly EventMapper InstanceValue = new EventMapper();

        private Hashtable map = new Hashtable();

        static EventMapper()
        {
        }

        private EventMapper()
        {
            var packages = PackageManager.Instance.GetAllPackages();
            foreach (var package in packages)
            {
                Assembly assembly = null;
                try
                {
                    var assemblyToLoad = RemoveTrailingDot(package);
                    assembly = Assembly.Load(assemblyToLoad);
                }
                catch (FileNotFoundException)
                {
                    // Just skip, this assembly is not used
                }

                var structures = new NameValueCollection();
                if (assembly != null)
                {
                    structures = GetAssemblyEventMapping(assembly, package);
                }

                map[package.Version] = structures;
            }
        }

        public static EventMapper Instance => InstanceValue;

        public Hashtable Maps => map;

        private static string RemoveTrailingDot(Hl7Package package)
        {
            var assemblyString = package.PackageName;
            var lastChar = assemblyString.LastOrDefault();
            var trailingDot = lastChar != default(char) && lastChar.ToString() == ".";
            if (trailingDot)
            {
                assemblyString = assemblyString.Substring(0, assemblyString.Length - 1);
            }

            return assemblyString;
        }

        private NameValueCollection GetAssemblyEventMapping(Assembly assembly, Hl7Package package)
        {
            var structures = new NameValueCollection();
            using (var inResource = assembly.GetManifestResourceStream(package.EventMappingResourceName))
            {
                if (inResource != null)
                {
                    using (var sr = new StreamReader(inResource))
                    {
                        var line = sr.ReadLine();
                        while (line != null)
                        {
                            if ((line.Length > 0) && (line[0] != '#'))
                            {
                                var lineElements = line.Split(' ', '\t');
                                structures.Add(lineElements[0], lineElements[1]);
                            }

                            line = sr.ReadLine();
                        }
                    }
                }
            }

            return structures;
        }
    }
}