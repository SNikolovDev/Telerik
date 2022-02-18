using Academy.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Academy.Tests.ModelsTests.LectureTests
{
    [TestClass]
    public class Date_Should
    {
        [TestMethod]
        public void ReturnDatTimeType()
        {
            var lecture = Utils.Helpers.GetLecture();

            Assert.IsInstanceOfType(lecture.Date, typeof(DateTime));
        }
    }
}
