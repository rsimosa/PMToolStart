using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Reflection;

namespace DPL.PMTool.Common.Shared
{
    public static class Config
    {
        public static string SqliteConnectionString
        {
            get
            {
                var result = GetConfigValue("PMToolDb", "Database", "db.sqlite", "Data Source=");
                return result;
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

        private static string GetConfigValue(string environmentVariable, string defaultDir = null,
            string defaultFile = null, string prefix = null)
        {
            var result = Configuration[environmentVariable];
            if (string.IsNullOrWhiteSpace(result) && defaultDir != null)
            {
                if (Assembly.GetExecutingAssembly().Location.Contains("DPL.PMTool"))
                {
                    // If we don't have a configuration in an environment variables.
                    // We are going to determine a location to store these files
                    // if it hasn't been configured. Why? Because we want to make
                    // getting setup as easy as possible.
                    // Because of check above we know that they are running this from
                    // the source, and we will put the files in a TempFiles folder at the
                    // root of source.
                    var startDir = GetStartDir();
                    result = Path.Combine(startDir, defaultDir);
                    if (!Directory.Exists(result))
                        Directory.CreateDirectory(result);
                    if (defaultFile != null)
                        result = Path.Combine(result, defaultFile);
                    if (prefix != null)
                        result = prefix + result;
                }
            }
            return result;
        }

        private static string GetStartDir()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            const string sourceStart = "DPL.PMTool";
            var dirPath = location.Substring(0, location.IndexOf(sourceStart) + sourceStart.Length);
            var dirInfo = new DirectoryInfo(dirPath);
            var tempPath = Path.Combine(dirInfo.Parent.FullName, "TempFiles");
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);
            return tempPath;
        }
    }
}
