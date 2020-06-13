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
            var connectionString = Common.Shared.Config.SqliteConnectionString;
            optionsBuilder.UseSqlite(connectionString);
        }
        
        internal static DatabaseContext UnitTestContext { get; set; }

        // Everyone that uses the DatabaseContext will use this 
        // constructor method
        public static DatabaseContext Create(bool allowDispose = true)
        {
            if (UnitTestContext == null)
                return new DatabaseContext()
                {
                    AllowDispose = allowDispose
                };
            return UnitTestContext;
        }

        private DatabaseContext()
            : base()

        {

        }

        public override void Dispose()
        {
            // this is the secret of the wrapper, without this do nothing we won't handle rolling back transactions
            // only dispose if we are allowing it to dispose
            if (AllowDispose)
                base.Dispose();
        }
        
        public bool AllowDispose { get; set; } = true;
    }
}
