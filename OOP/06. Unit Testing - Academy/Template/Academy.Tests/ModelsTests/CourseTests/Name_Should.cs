using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Academy.Tests.ModelsTests.CourseTests
{
    [TestClass]
    public class Name_Should
    {
        [TestMethod]
        public void Throw_When_ValueIsNull()
        {
            var sut = Utils.Helpers.GetCourse();

            Assert.ThrowsException<ArgumentException>(() =>
            sut.Name = null);
        }

        [TestMethod]
        public void Throw_When_ValueIsLessThanMinValue()
        {
            var sut = Utils.Helpers.GetCourse();

            Assert.ThrowsException<ArgumentException>(() =>
            sut.Name = new string('a', 2));
        }

        [TestMethod]
        public void Throw_When_ValueIsLargerThanMaxValue()
        {
            var sut = Utils.Helpers.GetCourse();

            Assert.ThrowsException<ArgumentException>(() =>
            sut.Name = new string('a', 46));
        }

        [TestMethod]
        public void ChangeValue_When_ValueIsCorrect()
        {
            var sut = Utils.Helpers.GetCourse();
            sut.Name = "Quality Assurance";

            Assert.AreEqual("Quality Assurance", sut.Name);
           
        }
    }
}
