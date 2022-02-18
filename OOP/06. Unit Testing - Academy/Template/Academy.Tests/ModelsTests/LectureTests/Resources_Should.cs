using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Tests.ModelsTests.LectureTests
{
    [TestClass]
    public class Resources_Should
    {
        [TestMethod]
        public void ShouldReturnList()
        {
            var lecture = Utils.Helpers.GetLecture();

            Assert.IsInstanceOfType(lecture.Resources, typeof(IList<ILectureResource>));
        }

        [TestMethod]
        public void ShouldReturnCorrectType()
        {
            var lecture = Utils.Helpers.GetLecture();

            Assert.IsInstanceOfType(lecture.Trainer, typeof(ITrainer));
        }

        [TestMethod]
        public void ShouldReturnIToString()
        {
            var lecture = Utils.Helpers.GetLecture();

            Assert.IsNotNull(lecture.ToString());
        }
    }
}
