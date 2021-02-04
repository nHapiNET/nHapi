namespace NHapi.Base
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;

    using NHapi.Base.Model.Configuration;

    internal class PackageManager
    {
        private static readonly PackageManager InstanceValue = new PackageManager();
        private List<Hl7Package> packages = new List<Hl7Package>();

        static PackageManager()
        {
        }

        private PackageManager()
        {
            LoadBaseVersions();
            LoadAdditionalVersions();
        }

        public static PackageManager Instance
        {
            get { return InstanceValue; }
        }

        /// <summary> Returns the path to the base package for model elements of the given version
        /// - e.g. "NHapi.Model.VXXX".
        /// This package should have the packages datatype, segment, group, and message
        /// under it. The path ends in with a slash.
        /// </summary>
        public static string GetVersionPackagePath(string ver)
        {
            StringBuilder path = new StringBuilder("NHapi.Model.V");
            char[] versionChars = new char[ver.Length];
            SupportClass.GetCharsFromString(ver, 0, ver.Length, versionChars, 0);
            for (int i = 0; i < versionChars.Length; i++)
            {
                if (versionChars[i] != '.')
                {
                    path.Append(versionChars[i]);
                }
            }

            path.Append("/");
            return path.ToString();
        }

        /// <summary> Returns the package name for model elements of the given version - e.g.
        /// "NHapi.Base.Model.v24.".  This method
        /// is identical to. <code>getVersionPackagePath(...)</code> except that path
        /// separators are replaced with dots.
        /// </summary>
        public static string GetVersionPackageName(string ver)
        {
            string path = GetVersionPackagePath(ver);
            string packg = path.Replace('/', '.');
            packg = packg.Replace('\\', '.');
            return packg;
        }

        public IList<Hl7Package> GetAllPackages()
        {
            return packages;
        }

        public bool IsValidVersion(string version)
        {
            version = version.ToUpper().Trim();
            foreach (Hl7Package package in packages)
            {
                if (package.Version.ToUpper().Trim().Equals(version))
                {
                    return true;
                }
            }

            return false;
        }

        private void LoadBaseVersions()
        {
            string[] versions = new string[] { "2.1", "2.2", "2.3", "2.3.1", "2.4", "2.5", "2.5.1", "2.6", "2.7", "2.7.1", "2.8", "2.8.1" };
            foreach (string version in versions)
            {
                string packageName = GetVersionPackageName(version);
                packages.Add(new Hl7Package(packageName, version));
            }
        }

        private void LoadAdditionalVersions()
        {
            var configSection = ConfigurationManager.GetSection("Hl7PackageCollection") as HL7PackageConfigurationSection;
            if (configSection != null)
            {
                foreach (HL7PackageElement package in configSection.Packages)
                {
                    packages.Insert(0, new Hl7Package(package.Name, package.Version));
                }
            }
        }
    }
}