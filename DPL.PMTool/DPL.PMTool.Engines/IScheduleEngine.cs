using DPL.PMTool.Accessors.Shared.EntityFramework;

namespace DPL.PMTool.Engines
{
    public interface IScheduleEngine
    {
        Activity[] CalculateSchedule(Activity[] activities, Project dbProject);
    }
}