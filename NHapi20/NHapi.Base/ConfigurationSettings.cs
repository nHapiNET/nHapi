using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace NHapi.Base
{
    public class ConfigurationSettings
    {
        public static bool UseFactory
        {
            get
            {
                bool useFactory = false;
                string useFactoryFromConfig = System.Configuration.ConfigurationManager.AppSettings["UseFactory"];
                if(useFactoryFromConfig !=null && useFactoryFromConfig.Length>0)
                {
                    useFactory = Convert.ToBoolean(useFactoryFromConfig);
                }
                return useFactory;
            }
        }

        public static string ConnectionString
        {
            get
            {
                string conn = "";
                string connFromConfig = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
                if (connFromConfig != null && connFromConfig.Length > 0)
                {
                    conn = connFromConfig;
                }
                return conn;
            }
        }
    }
}
