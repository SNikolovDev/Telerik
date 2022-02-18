using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Academy.Tests.ModelsTests.LectureTests
{
    [TestClass]
    public class Name_Should
    {
        [TestMethod]
        public void Throw_When_ValueIsNull()
        {
            var lecture = Utils.Helpers.GetLecture();

            Assert.ThrowsException<ArgumentException>(() =>
            lecture.Name = null);
        }

        [TestMethod]
        public void Throw_When_ValueIsLessThanMinValue()
        {
            var lecture = Utils.Helpers.GetLecture();

            Assert.ThrowsException<ArgumentException>(() =>
            lecture.Name = new string('a', 4));
        }

        [TestMethod]
        public void Throw_When_ValueIsLargerThanMaxValue()
        {
            //Arrange
            var sut = Utils.Helpers.GetLecture();

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => sut.Name = new string('a', 31));
        }

        [TestMethod]
        public void ChangeValue_When_ValueIsCorrect()
        {
            var lecture = Utils.Helpers.GetLecture();
            lecture.Name = "Code wrecking.";

            Assert.AreEqual("Code wrecking.", lecture.Name);

        }
    }
}
