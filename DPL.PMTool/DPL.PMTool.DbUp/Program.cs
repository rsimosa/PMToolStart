using DbUp;
using DbUp.Engine;
using System;
using System.Reflection;
using DPL.PMTool.Accessors.Shared;
using DPL.PMTool.Common.Shared;

namespace DPL.PMTool.DbUp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = Config.SqliteConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string environment variable missing.");
            }

            //EnsureDatabase.For.SqlDatabase(connectionString);

        
            UpdateDb(connectionString);

        }

        private static void UpdateDb(string connectionString)
        {
            var migrator = DeployChanges.To
                .SQLiteDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .WithExecutionTimeout(TimeSpan.FromSeconds(300))
                .LogToConsole()
                .Build();

            var result = migrator.PerformUpgrade();
    
            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                if (Environment.UserInteractive)
                {
                    Console.ReadLine();
                }

                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();

            if (Environment.UserInteractive)
            {
                Console.ReadLine();
            }
        }
    }
}
