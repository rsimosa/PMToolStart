using Microsoft.EntityFrameworkCore;

namespace DPL.PMTool.Accessors.Shared.EntityFramework
{
    public partial class DatabaseContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}