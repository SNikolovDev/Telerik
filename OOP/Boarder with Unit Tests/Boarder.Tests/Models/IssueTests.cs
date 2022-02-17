using Boarder.Models;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Boarder.Tests
{
    [TestClass]
    public class IssueTests
    {
        [TestMethod]
        public void ShouldCreateIssueWhenParametersAreValid()
        {
            string title = "Title";
            string description = "Description";
            DateTime dueDate = DateTime.Parse("20-03-2030");

            Issue issue = new Issue(title, description, dueDate);

            Assert.AreEqual("Title", issue.Title);
        }

        [TestMethod]
        public void ShouldSetDescription()
        {
            Issue issue = new Issue("Title", "Description", DateTime.Parse("20-03-2030"));

            Assert.AreEqual("Description", issue.Description);
        }

        [TestMethod]
        public void ShouldSetDueDate()
        {
            Issue issue = new Issue("Title", "Description", DateTime.Parse("20-03-2030"));

            Assert.AreEqual(DateTime.Parse("20-03-2030"), issue.DueDate);
        }

        [TestMethod]
        public void StatusShouldStartAtOpen()
        {
            Issue issue = new Issue("Title", "Description", DateTime.Parse("20-03-2030"));

            Assert.AreEqual(Status.Open, issue.Status);
        }

        [TestMethod]
        public void ShouldAdvancedStatus()
        {
            Issue issue = new Issue("Title", "Description", DateTime.Parse("20-03-2030"));
            issue.AdvanceStatus();

            Assert.AreEqual(Status.Verified, issue.Status);
        }

        [TestMethod]
        public void ShouldRevertStatus()
        {
            Issue issue = new Issue("Title", "Description", DateTime.Parse("20-03-2030"));
            issue.AdvanceStatus();
            issue.RevertStatus();

            Assert.AreEqual(Status.Open, issue.Status);
        }

        [TestMethod]
        public void ShouldAddInfo()
        {
            Issue issue = new Issue("Title", "Description", DateTime.Parse("20-03-2030"));

            Assert.IsNotNull(issue.ViewInfo());
        }

        [TestMethod]
        public void ShouldAddInEventLog()
        {
            Issue issue = new Issue("Title", "Description", DateTime.Parse("20-03-2030"));

            Assert.AreEqual(1, issue.EventLog.Count);
        }

        [TestMethod]
        public void ReturnsCorrectType()
        {
            Issue issue = new Issue("Title", "Description", DateTime.Parse("20-03-2030"));

            Assert.IsInstanceOfType(issue, typeof(Issue));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenTitleNameIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue(null, "Assignee", DateTime.Parse("20-03-2030")));
        }

        [TestMethod]
        [DataRow("ivo")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ShouldThrowAnExceptionWhenInvalidTitleLength(string value)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue(value, "Descritption", DateTime.Parse("20-03-2030")));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenDueDateIsInThePast()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue("Ala-bala", "Assignee", DateTime.Parse("20-03-2000")));
        }

        [TestMethod]
        public void ShouldHaveMessageIfThereIsNowDescription()
        {
            Issue issue = new Issue("Title", null, DateTime.Parse("20-03-2030"));

            Assert.IsNotNull(issue.Description);
        }

        [TestMethod]
        public void IssueShouldDeriveFromBoardItem()
        {
            var type = typeof(Issue);
            var isAssignable = typeof(BoardItem).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable);
        }

        [TestMethod]
        public void ShouldAddToLogWhenStatusAlreadyAtVerified()
        {
            Issue issue = new Issue("Title", "Description", DateTime.Parse("20-03-2030"));
           
            issue.AdvanceStatus();
            int logCount = issue.EventLog.Count;
            issue.AdvanceStatus();

            Assert.AreEqual(logCount + 1, issue.EventLog.Count);
        }

        [TestMethod]
        public void ShouldAddToLogWhenStatusAlreadyAtOpen()
        {
            Issue issue = new Issue("Title", "Description", DateTime.Parse("20-03-2030"));
          
            int logCount = issue.EventLog.Count;
            issue.RevertStatus();

            Assert.AreEqual(logCount + 1, issue.EventLog.Count);
        }
    }
}
