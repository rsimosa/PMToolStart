using DPL.PMTool.Accessors;
using DPL.PMTool.Common.Shared;
using DPL.PMTool.Engines;
using DPL.PMTool.Utilities;

namespace DPL.PMTool.Managers.Shared
{
    public abstract class ManagerBase : ServiceContractBase
    {
        public EngineFactory EngineFactory { get; set; }
        public AccessorFactory AccessorFactory { get; set; }
        public UtilityFactory UtilityFactory { get; set; }

        protected ManagerBase()
        {

        }
    }
}
