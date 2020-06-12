using Microsoft.Extensions.Configuration;
using System;

namespace DPL.PMTool.Common.Shared
{
    public static class Config
    {
        public static string SqlServerConnectionString
        {
            get
            {
                return GetConfigValue("Database");
            }
        }

        static IConfiguration _cachedConfig;
        private static IConfiguration Configuration
        {
            get
            {
                if (_cachedConfig == null)
                {
                    var builder = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{Environment.UserName}.json", true, true)
                        .AddEnvironmentVariables();
                    _cachedConfig = builder.Build();
                }

                return _cachedConfig;
            }
        }

        private static string GetConfigValue(string environmentVariable)
        {
            var result = Configuration[environmentVariable];
            return result;
        }
    }
}
