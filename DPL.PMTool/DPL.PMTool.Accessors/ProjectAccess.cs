using System.Linq;
using DPL.PMTool.Accessors.Shared.EntityFramework;

namespace DPL.PMTool.Accessors
{
    public class ProjectAccess : IProjectAccess
    {
        public Project Project(int id)
        {
            using (var db = DatabaseContext.Create())
            {
                return db.Projects.FirstOrDefault(p => p.Id == id);
            }
        }
        
        public Project SaveProject(Project project)
        {
            using (var db = DatabaseContext.Create())
            {
                if (project.Id == 0)
                {
                    db.Projects.Add(project);
                }
                else
                {
                    db.Projects.Attach(project);
                }

                db.SaveChanges();
            }

            return project;
        }
        
    }
}