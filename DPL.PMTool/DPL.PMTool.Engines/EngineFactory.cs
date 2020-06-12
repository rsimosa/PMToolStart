using DPL.PMTool.Accessors;
using DPL.PMTool.Common.Contracts;
using DPL.PMTool.Common.Shared;
using DPL.PMTool.Engines.Shared;
using DPL.PMTool.Utilities;

namespace DPL.PMTool.Engines
{
    public class EngineFactory : FactoryBase
    {
        private AccessorFactory _accessorFactory;
        private UtilityFactory _utilityFactory;

        public EngineFactory(AmbientContext context, AccessorFactory accessorFactory, UtilityFactory utilityFactory)
            : base(context)
        {
            // NOTE: this is here to ensure the factories from the Manager are propogated down to the other factories 
            _utilityFactory = utilityFactory ?? new UtilityFactory(Context);
            _accessorFactory = accessorFactory ?? new AccessorFactory(Context, _utilityFactory);

            //AddType<IRemittanceCalculationEngine>(typeof(RemittanceCalculationEngine));
        }

        public T CreateEngine<T>() where T : class
        {
            return CreateEngine<T>(null, null);
        }

        public T CreateEngine<T>(AccessorFactory accessorFactory, UtilityFactory utilityFactory) where T : class
        {
            _accessorFactory = accessorFactory ?? _accessorFactory;
            _utilityFactory = utilityFactory ?? _utilityFactory;

            T result = GetInstanceForType<T>();

            // configure the context and the accessor factory if the result is not a mock
            if (result is EngineBase)
            {
                (result as EngineBase).Context = Context;
                (result as EngineBase).AccessorFactory = _accessorFactory;
                (result as EngineBase).UtilityFactory = _utilityFactory;
            }

            return result;
        }
    }
}
