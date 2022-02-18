using Academy.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Academy.Tests.ModelsTests.CourseTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void InitializeOnlineStudents()
        {
            //Arrange, Act
            var sut = Utils.Helpers.GetCourse();

            //Assert
            Assert.IsInstanceOfType(sut.OnlineStudents, typeof(List<IStudent>));
        }

        [TestMethod]
        public void InitializeOnsiteStudents()
        {
            var sut = Utils.Helpers.GetCourse();

            Assert.IsInstanceOfType(sut.OnsiteStudents, typeof(List<IStudent>));
        }

        [TestMethod]
        public void InitializeLectures()
        {
            var sut = Utils.Helpers.GetCourse();

            Assert.IsInstanceOfType(sut.Lectures, typeof(List<ILecture>));

        }
    }
}
