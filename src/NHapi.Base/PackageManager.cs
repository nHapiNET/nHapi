namespace NHapi.Base
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Text;

    using NHapi.Base.Model.Configuration;

    internal class PackageManager
    {
        // TODO: Consider using Lazy<T> or other locking to ensure this is thread safe
        private static readonly PackageManager InstanceValue = new PackageManager();

        static PackageManager()
        {
        }

        private PackageManager()
        {
            LoadBaseVersions();
            LoadAdditionalVersions();
        }

        public static PackageManager Instance => InstanceValue;

        public List<Hl7Package> Packages { get; } = new List<Hl7Package>();

        /// <summary> Returns the path to the base package for model elements of the given version
        /// - e.g. "NHapi.Model.VXXX".
        /// This package should have the packages datatype, segment, group, and message
        /// under it. The path ends in with a slash.
        /// </summary>
        public static string GetVersionPackagePath(string ver)
        {
            var path = new StringBuilder("NHapi.Model.V");
            var versionChars = new char[ver.Length];
            SupportClass.GetCharsFromString(ver, 0, ver.Length, versionChars, 0);
            for (var i = 0; i < versionChars.Length; i++)
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
            var path = GetVersionPackagePath(ver);
            var packg = path.Replace('/', '.');
            packg = packg.Replace('\\', '.');
            return packg;
        }

        [Obsolete("Prefer the property 'Packages' instead")]
        public IList<Hl7Package> GetAllPackages()
        {
            return Packages;
        }

        public bool IsValidVersion(string version)
        {
            version = version.ToUpper().Trim();
            foreach (var package in Packages)
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
            var versions = new string[] { "2.1", "2.2", "2.3", "2.3.1", "2.4", "2.5", "2.5.1", "2.6", "2.7", "2.7.1", "2.8", "2.8.1" };
            foreach (var version in versions)
            {
                var packageName = GetVersionPackageName(version);
                Packages.Add(new Hl7Package(packageName, version));
            }
        }

        private void LoadAdditionalVersions()
        {
            var configSection = ConfigurationManager.GetSection("Hl7PackageCollection") as HL7PackageConfigurationSection;
            if (configSection != null)
            {
                foreach (HL7PackageElement package in configSection.Packages)
                {
                    Packages.Insert(0, new Hl7Package(package.Name, package.Version));
                }
            }
        }
    }
}