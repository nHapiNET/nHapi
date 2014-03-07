using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace NHapi.Base
{
    class Hl7Package
    {
        private string _version;
        private string _packageName;
        
        public Hl7Package(string packageName, string version)
        {
            _version = version;
            _packageName = packageName;            
        }

        

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public string PackageName
        {
            get { return _packageName; }
        }

        public string EventMappingResourceName
        {
            get
            {
                return _packageName + ".EventMapping.EventMap.properties";
            }
        }
	

    }
}
