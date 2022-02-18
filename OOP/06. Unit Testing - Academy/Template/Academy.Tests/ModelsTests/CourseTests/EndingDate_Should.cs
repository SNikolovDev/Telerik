using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Academy.Tests.ModelsTests.CourseTests
{
    [TestClass]
    public class EndingDate_Should
    {
        [TestMethod]
        public void Throw_When_ValueIsNull()
        {
            //Arrange
            var sut = Utils.Helpers.GetCourse();

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.EndingDate = null);
        }

        [TestMethod]
        public void ChangeValue_When_ValueIsCorrect()
        {
            var sut = Utils.Helpers.GetCourse();
            string dateString = "20/03/2030 12:42:46";
            sut.EndingDate = DateTime.Parse(string.Format(dateString));

            Assert.AreEqual(DateTime.Parse(string.Format(dateString)), sut.EndingDate);
        }
    }
}
