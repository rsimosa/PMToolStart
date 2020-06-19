using DPL.PMTool.Accessors.Shared.EntityFramework;
using DPL.PMTool.Engines.Shared;

namespace DPL.PMTool.Engines
{
    public class ScheduleEngine : EngineBase, IScheduleEngine
    {
        public Activity[] CalculateSchedule(Activity[] activities, Project dbProject)
        {
            return activities;
        }
    }
}