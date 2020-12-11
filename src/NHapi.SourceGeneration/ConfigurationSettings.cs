using System;
using System.Configuration;

namespace NHapi.SourceGeneration
{
	public class ConfigurationSettings
	{
		public static bool UseFactory
		{
			get
			{
				bool useFactory = false;
				string useFactoryFromConfig = ConfigurationManager.AppSettings["UseFactory"];
				if (useFactoryFromConfig != null && useFactoryFromConfig.Length > 0)
				{
					useFactory = Convert.ToBoolean(useFactoryFromConfig);
				}
				return useFactory;
			}
		}

		private static string _connectionString = string.Empty;

		public static string ConnectionString
		{
			get
			{
				string connFromConfig = ConfigurationManager.AppSettings["ConnectionString"];
				if (string.IsNullOrEmpty(_connectionString) && !string.IsNullOrEmpty(connFromConfig))
				{
					_connectionString = connFromConfig;
				}
				return _connectionString;
			}
			set { _connectionString = value; }
		}
	}
}