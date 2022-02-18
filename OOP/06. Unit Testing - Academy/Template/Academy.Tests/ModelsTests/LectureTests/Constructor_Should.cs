using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Academy.Tests.ModelsTests.LectureTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void InitializeResources()
        {
            var letcture = Utils.Helpers.GetLecture();

            Assert.IsNotNull(letcture.Resources);
        }
    }
}
