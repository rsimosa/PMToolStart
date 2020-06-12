using Microsoft.Extensions.Configuration;
using DPL.PMTool.Common.Shared;
using DPL.PMTool.Utilities;

namespace DPL.PMTool.Accessors.Shared
{
    public abstract class AccessorBase : ServiceContractBase
    {
        public UtilityFactory UtilityFactory { get; set; }

        protected string DatabaseConnectionString
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .AddEnvironmentVariables();

                var configuration = builder.Build();

                var db = configuration["REPLACE_WITH_CONNECTIONSTRING"];

                return db;
            }
        }
    }
}
