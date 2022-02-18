using Academy.Models.Contracts;
using Academy.Models.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;

namespace Academy.Tests.ModelsTests.StudentTests
{
    [TestClass]
    public class Username_Should
    {
        [TestMethod]
        public void Throw_When_ValueIsNullOrWhiteSpace()
        {
            //Arrange
            var student = Utils.Helpers.GetStudent();
            string newUsername = null;

            //Act
            Assert.ThrowsException<ArgumentException>(() => student.Username = newUsername);
        }

        [TestMethod]
        public void Throw_When_ValueIsLessThanMin()
        {
            var student = Utils.Helpers.GetStudent();
            string newUsername = string.Format(new string('a', 2));

            Assert.ThrowsException<ArgumentException>(() => student.Username = newUsername);
        }

        [TestMethod]
        public void Throw_When_ValueIsLargerThanMax()
        {
            var student = Utils.Helpers.GetStudent();
            string newUsername = string.Format(new string('a', 17));

            Assert.ThrowsException<ArgumentException>(() => student.Username = newUsername);
        }

        [TestMethod]
        public void ChangeValue_When_ValueIsCorrect()
        {
            var student = Utils.Helpers.GetStudent();
            student.Username = "Hulk";

            Assert.AreEqual("Hulk", student.Username);
        }

        [TestMethod]
        public void ShouldReturnTrack()
        {
            var student = Utils.Helpers.GetStudent();

            Assert.IsInstanceOfType(student.Track, typeof(Track));
        }

        [TestMethod]
        public void ShouldReturnICourseResult()
        {
            var student = Utils.Helpers.GetStudent();

            Assert.IsInstanceOfType(student.CourseResults, typeof(IList));
        }

        [TestMethod]
        public void ShouldReturnIToString()
        {
            var student = Utils.Helpers.GetStudent();

            Assert.IsNotNull(student.ToString());
        }
    }
}