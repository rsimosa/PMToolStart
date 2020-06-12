using Microsoft.VisualStudio.TestTools.UnitTesting;
using DPL.PMTool.Engines.Shared;

namespace DPL.PMTool.Tests.EngineTests
{
    [TestClass]
    public class DTOMapperTests
    {
        [TestMethod]
        [TestCategory("Engine Tests")]
        public void DTOMapper_IsDTOMApperConfigValid()
        {
            DTOMapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
