using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DPL.PMTool.Accessors.Shared.EntityFramework
{
    public partial class DatabaseContext : DbContext
    {
        protected IConfigurationRoot Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Common.Shared.Config.SqlServerConnectionString);
            }
        }
    }
}
