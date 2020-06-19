using DPL.PMTool.Accessors;
using DPL.PMTool.Contracts.Client;
using DPL.PMTool.Engines;
using DPL.PMTool.Managers.Shared;
using System.Collections.Generic;

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
            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            var dbProject = projectAccess.Project(id);

            // convert db project to client version

            var dbActivities = projectAccess.ActivitiesForProject(id);

            var clientProject = new Project();
            Activity[] clientActivities;

            if (dbActivities != null)
            {
                clientActivities = new Activity[dbActivities.Length];
                List<Activity> activitiesList = new List<Activity>();

                foreach (var serverActivity in dbActivities)
                {
                    Activity clientActivity = new Activity();
                    clientActivity.Id = serverActivity.Id;
                    clientActivity.TaskName = serverActivity.TaskName;
                    clientActivity.Estimate = serverActivity.Estimate;
                    clientActivity.Predecessors = serverActivity.Predecessors;
                    clientActivity.Resource = serverActivity.Resource;
                    clientActivity.Priority = serverActivity.Priority;
                    clientActivity.Start = serverActivity.Start;
                    clientActivity.Finish = serverActivity.Finish;
                    activitiesList.Add(clientActivity);
                }

                for (int i = 0; i < activitiesList.Count; i++)
                {
                    clientActivities[i] = activitiesList[i];
                }
            }
            else
            {
                clientActivities = new Activity[0];
            }

            if (dbProject != null)
            {
                clientProject.Id = dbProject.Id;
                clientProject.Name = dbProject.Name;
                clientProject.Start = dbProject.Start;
                clientProject.Activities = clientActivities;
            }

            return clientProject;
        }

        public ProjectListItem[] Projects()
        {
            List<ProjectListItem> projectListItems = new List<ProjectListItem>();

            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            var projectsArray = projectAccess.Projects();

            foreach (var project in projectsArray)
            {
                projectListItems.Add(new ProjectListItem()
                {
                    Id = project.Id,
                    Name = project.Name
                });
            }

            return projectListItems.ToArray();
        }

        public Project SaveProject(Project project)
        {
            var projectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
            var activitiesSchedulerAccess = EngineFactory.CreateEngine<IScheduleEngine>();

            var dbProject = new DPL.PMTool.Accessors.Shared.EntityFramework.Project()
            {
                Name = project.Name,
                Id = project.Id,
                Start = project.Start,
            };

            var savedProject = projectAccess.SaveProject(dbProject);
            var resultProject = new Project()
            {
                Id = savedProject.Id,
                Start = savedProject.Start,
                Name = savedProject.Name
            };

            var activities = new List<Activity>();
            var act = new List<DPL.PMTool.Accessors.Shared.EntityFramework.Activity>();
            foreach (var activity in project.Activities)
            {
                var dbActivity = new DPL.PMTool.Accessors.Shared.EntityFramework.Activity()
                {
                    Id = activity.Id,
                    Estimate = activity.Estimate,
                    TaskName = activity.TaskName,
                    Predecessors = activity.Predecessors,
                    Priority = activity.Priority,
                    Finish = activity.Finish,
                    Start = activity.Start,
                    Resource = activity.Resource,
                    ProjectId = dbProject.Id
                };
                act.Add(dbActivity);
            }

            var resultActivities = activitiesSchedulerAccess.CalculateSchedule(act.ToArray(), dbProject);

            foreach (var rsa in resultActivities)
            {
                activities.Add(new Activity()
                {
                    Id = rsa.Id,
                    Estimate = rsa.Estimate,
                    TaskName = rsa.TaskName,
                    Start = rsa.Start,
                    Finish = rsa.Finish,
                    Predecessors = rsa.Predecessors,
                    Priority = rsa.Priority,
                    Resource = rsa.Resource,
                });
            }

            resultProject.Activities = activities.ToArray();

            return resultProject;
        }
    }
}