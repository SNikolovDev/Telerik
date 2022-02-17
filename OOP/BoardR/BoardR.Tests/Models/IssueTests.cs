using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BoardR.Tests
{
    [TestClass]
    public class IssueTests
    {
        [TestMethod]
        public void ConstructorShouldSetValidParameters()
        {
            //Assert
            string title = "Test title";
            string description = "Test description";
            DateTime dueDate = DateTime.Now;

            //Act
            Issue issue = new Issue(title, description, dueDate);

            //Arrange
            Assert.AreEqual(title, issue.Title);
            Assert.AreEqual(description, issue.Description);
            Assert.AreEqual(dueDate, issue.DueDate);
        }

        [TestMethod]
        public void ReturnsCorrectType()
        {
            //Act
            Issue issue = new Issue("Test Title", "description", DateTime.Now);

            //Arrange
            Assert.IsInstanceOfType(issue, typeof(Issue));
        }

        [TestMethod]
        public void DescriptionShouldGiveErrorMessageWhenValueIsNull()
        {
            //Act
            Issue issue = new Issue("Test title", null, DateTime.Now);

            //Arrange
            Assert.AreEqual("No description", issue.Description);
        }

        [TestMethod]

        public void ShouldAdvanceStatus()
        {
            //Act
            Issue issue = new Issue("Test title", null, DateTime.Now);
            issue.Status = Status.Open;
            issue.AdvanceStatus();

            //Arrange
            Assert.AreEqual(issue.Status, Status.Verified);
        }

        [TestMethod]

        public void ShouldRevertStatus()
        {
            //Act
            Issue issue = new Issue("Test title", null, DateTime.Now);
            issue.Status = Status.Verified;
            issue.RevertStatus();

            //Arrange
            Assert.AreEqual(issue.Status, Status.Open);
        }

        //[TestMethod]
        //public void ShouldAddAnEventInLogWhenCreated()
        //{
        //    //Act
        //    Issue issue = new Issue("Test title", "Test Description", DateTime.Now);
        //    EventLog log = new EventLog("Test Log");

        //    Assert.AreEqual(log.ViewInfo(), $"Created Issue: 'Test title', [Open|{DateTime.Now:dd-MM-yyyy}] Description: Test Description");
        //}
    }
}

