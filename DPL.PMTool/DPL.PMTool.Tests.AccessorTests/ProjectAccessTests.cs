using System;
using DPL.PMTool.Accessors.Shared.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DPL.PMTool.Tests.AccessorTests
{
    [TestClass]
    public class ProjectAccessTests : TestAccessorBase
    {
        [TestMethod]
        public void ProjectAccess_Basic_Test()
        {
            // arrange / given
            var project = new Project()
            {
                Name = "TEST-" + Guid.NewGuid().ToString()
            };

            // act / when
            var saved = ProjectAccess.SaveProject(project);
            var loaded = ProjectAccess.Project(saved.Id);
            
            // assert / then
            Assert.IsNotNull(loaded);
            Assert.IsTrue(loaded.Id > 0);
        }
    }
}