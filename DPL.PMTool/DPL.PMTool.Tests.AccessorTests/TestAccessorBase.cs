using Microsoft.VisualStudio.TestTools.UnitTesting;
using DPL.PMTool.Accessors.Shared.EntityFramework;
using DPL.PMTool.Common.Contracts;
using System.Transactions;
using DPL.PMTool.Accessors;
using DPL.PMTool.Utilities;

namespace DPL.PMTool.Tests.AccessorTests
{
    [TestClass]
    public abstract class TestAccessorBase 
    {
        public TestAccessorBase()
        {
            AccessorFactory = new AccessorFactory(Context, new UtilityFactory(Context));
            ProjectAccess = AccessorFactory.CreateAccessor<IProjectAccess>();
        }

  
        [TestInitialize()]
        public void Init()
        {
            CreateGlobalContext();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            CancelGlobalTransaction();
        }

        public static void CreateGlobalContext()
        {
            DatabaseContext.UnitTestContext = DatabaseContext.Create(false);
            DatabaseContext.UnitTestContext.Database.BeginTransaction();
        }

        public static void CancelGlobalTransaction()
        {
            if (DatabaseContext.UnitTestContext != null)
            {
                DatabaseContext.UnitTestContext.Database.RollbackTransaction();
                DatabaseContext.UnitTestContext.AllowDispose = true;
                DatabaseContext.UnitTestContext.Dispose();
                DatabaseContext.UnitTestContext = null;
            }
        }

        protected AmbientContext Context { get; } = new AmbientContext();

        protected AccessorFactory AccessorFactory { get; set; }
        protected IProjectAccess ProjectAccess { get; set; }
    }
}
