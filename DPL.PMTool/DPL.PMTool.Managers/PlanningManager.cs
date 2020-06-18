using DPL.PMTool.Accessors;
using DPL.PMTool.Managers.Shared;
using System;

namespace DPL.PMTool.Managers
{
    public class PlanningManager : ManagerBase, IPlanningManager
    {
        public TestMeResponse TestMe()
        {
            return new TestMeResponse()
            {
                Message = "TestMe"
            };
        }

        public Project Project(int id)
        {
            // this should load from the ProjectAccess service.
            // var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            // var dbProject = projectAccess.Project(id);
            // convert db project to client version

            return new Project()
            {
                Id = id,
                Name = "TEST",
                Start = DateTime.Now,
                Activities = new[] {
                    new Activity()
                    {
                        TaskName = "TEST",
                    }
                }
            };
        }

        public Project SaveProject(Project project)
        {
            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();

            var dbProject = new Accessors.Shared.EntityFramework.Project
            {
                Id = project.Id,
                Name = project.Name,
                Start = project.Start
            };

            // you will need to copy properties across to the database versions of project / activity
            var saved = projectAccess.SaveProject(dbProject);
            // return saved;

            var result = new Managers.Project
            {
                Id = saved.Id,
                Name = saved.Name,
                Start = saved.Start,
            };

            // you will need to return a project, with data from the database.
            return result; // don't return this version.
        }
    }
}