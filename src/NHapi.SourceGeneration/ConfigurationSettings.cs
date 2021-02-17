namespace NHapi.SourceGeneration
{
    using System;
    using System.Configuration;

    public class ConfigurationSettings
    {
        private static string connectionString = string.Empty;

        public static bool UseFactory
        {
            get
            {
                var useFactory = false;
                var useFactoryFromConfig = ConfigurationManager.AppSettings["UseFactory"];
                if (useFactoryFromConfig != null && useFactoryFromConfig.Length > 0)
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
                var connFromConfig = ConfigurationManager.AppSettings["ConnectionString"];
                if (string.IsNullOrEmpty(connectionString) && !string.IsNullOrEmpty(connFromConfig))
                {
                    connectionString = connFromConfig;
                }

                return connectionString;
            }

            set
            {
                connectionString = value;
            }
        }
    }
}