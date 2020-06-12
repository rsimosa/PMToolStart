using Microsoft.VisualStudio.TestTools.UnitTesting;
using DPL.PMTool.Accessors.Shared;

namespace DPL.PMTool.Tests.AccessorTests
{
    [TestClass]
    public class DTOMapperTests
    {
        [TestMethod]
        [TestCategory("Accessor Tests")]
        public void DTOMapper_IsDTOMapperConfigValid()
        {
            DTOMapper.Configuration.AssertConfigurationIsValid();
        }
    }
}
