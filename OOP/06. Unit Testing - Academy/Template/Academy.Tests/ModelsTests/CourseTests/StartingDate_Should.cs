using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Academy.Tests.ModelsTests.CourseTests
{
    [TestClass]
    public class StartingDate_Should
    {
        [TestMethod]
        public void Throw_When_ValueIsNull()
        {
            var course = Utils.Helpers.GetCourse();

            Assert.ThrowsException<ArgumentNullException>(() =>
            course.StartingDate = null);
        }

        [TestMethod]
        public void ChangeValue_When_ValueIsCorrect()
        {
            //Arrange
            var course = Utils.Helpers.GetCourse();
            var expected = DateTime.Parse("10.10.2010");

            //Act
            course.StartingDate = expected;

            //Assert
            Assert.AreEqual(expected, course.StartingDate);
        }

        [TestMethod]
        public void ReturnsCorrectType()
        {
            var course = Utils.Helpers.GetCourse();

            Assert.IsInstanceOfType(course.StartingDate, typeof(DateTime));
        }  
    }
}
