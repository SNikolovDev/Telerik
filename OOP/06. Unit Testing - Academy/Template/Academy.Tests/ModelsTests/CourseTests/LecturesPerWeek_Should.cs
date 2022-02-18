using Academy.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Academy.Tests.ModelsTests.CourseTests
{
    [TestClass]
    public class LecturesPerWeek_Should
    {
        [TestMethod]
        public void Throw_When_ValueIsLessThanMin()
        {
            //Arrange
            var sut = Utils.Helpers.GetCourse();

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.LecturesPerWeek = 0);
        }

        [TestMethod]
        public void Throw_When_ValueIsLargerThanMaxValue()
        {
            var sut = Utils.Helpers.GetCourse();

            Assert.ThrowsException<ArgumentException>(() => sut.LecturesPerWeek = 8);
        }

        [TestMethod]
        public void ChangeValue_When_ValueIsCorrect()
        {
            var sut = Utils.Helpers.GetCourse();
            sut.LecturesPerWeek = 4;

            Assert.AreEqual(4, sut.LecturesPerWeek);

        }
    }
}