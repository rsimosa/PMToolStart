using DPL.PMTool.Accessors;
using DPL.PMTool.Common.Shared;
using DPL.PMTool.Utilities;

namespace DPL.PMTool.Engines.Shared
{
    public abstract class EngineBase : ServiceContractBase
    {
        public AccessorFactory AccessorFactory { get; set; }
        public UtilityFactory UtilityFactory { get; set; }

        protected EngineBase()
        {

        }
    }
}
