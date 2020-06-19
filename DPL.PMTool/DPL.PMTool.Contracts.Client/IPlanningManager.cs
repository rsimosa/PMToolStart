using DPL.PMTool.Accessors.Shared.EntityFramework;
using DPL.PMTool.Contracts.Client;

namespace DPL.PMTool.Managers
{
    public interface IPlanningManager
    {
        TestMeResponse TestMe();

        Project Project(int id);
        Project SaveProject(Project project);
        ProjectListItem[] Projects();
    }
}