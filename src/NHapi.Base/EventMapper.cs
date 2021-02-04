namespace NHapi.Base
{
    using System.Collections;
    using System.Collections.Generic;
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
            IList<Hl7Package> packages = PackageManager.Instance.GetAllPackages();
            foreach (Hl7Package package in packages)
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

                NameValueCollection structures = new NameValueCollection();
                if (assembly != null)
                {
                    structures = GetAssemblyEventMapping(assembly, package);
                }

                map[package.Version] = structures;
            }
        }

        public static EventMapper Instance
        {
            get { return InstanceValue; }
        }

        public Hashtable Maps
        {
            get { return map; }
        }

        private static string RemoveTrailingDot(Hl7Package package)
        {
            string assemblyString = package.PackageName;
            char lastChar = assemblyString.LastOrDefault();
            bool trailingDot = lastChar != default(char) && lastChar.ToString() == ".";
            if (trailingDot)
            {
                assemblyString = assemblyString.Substring(0, assemblyString.Length - 1);
            }

            return assemblyString;
        }

        private NameValueCollection GetAssemblyEventMapping(Assembly assembly, Hl7Package package)
        {
            NameValueCollection structures = new NameValueCollection();
            using (Stream inResource = assembly.GetManifestResourceStream(package.EventMappingResourceName))
            {
                if (inResource != null)
                {
                    using (StreamReader sr = new StreamReader(inResource))
                    {
                        string line = sr.ReadLine();
                        while (line != null)
                        {
                            if ((line.Length > 0) && (line[0] != '#'))
                            {
                                string[] lineElements = line.Split(' ', '\t');
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