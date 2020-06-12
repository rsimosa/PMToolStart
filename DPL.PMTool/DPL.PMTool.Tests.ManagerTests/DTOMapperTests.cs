using Microsoft.VisualStudio.TestTools.UnitTesting;
using DPL.PMTool.Managers.Shared;

namespace DPL.PMTool.Tests.ManagerTests
{
    [TestClass]
    public class DTOMapperTests
    {
        [TestMethod]
        [TestCategory("Manager Tests")]
        public void DTOMapper_IsDTOMApperConfigValid()
        {
            DTOMapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
