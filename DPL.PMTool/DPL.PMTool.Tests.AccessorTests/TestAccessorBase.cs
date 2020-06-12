using Microsoft.VisualStudio.TestTools.UnitTesting;
using DPL.PMTool.Accessors.Shared.EntityFramework;
using DPL.PMTool.Common.Contracts;
using System.Transactions;

namespace DPL.PMTool.Tests.AccessorTests
{
    [TestClass]
    public abstract class TestAccessorBase
    {
        private TransactionScope _transactionScopeFixture;

        public TestAccessorBase()
        {
        }

        [TestInitialize]
        public void BaseTestInitialize()
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.MaximumTimeout
            };
            _transactionScopeFixture = new TransactionScope(
                TransactionScopeOption.Required,
                transactionOptions);
        }
        [TestCleanup]
        public void BaseTestCleanup()
        {
            _transactionScopeFixture.Dispose();
        }

        protected AmbientContext Context { get; } = new AmbientContext();
    }
}
