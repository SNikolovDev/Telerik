using Boarder.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Boarder.Tests
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void ShouldCreateTaskWhenParamertersAreCorrect()
        {
            string title = "Title";
            string assignee = "Assignee";
            DateTime dueDate = DateTime.Parse("20-03-2030");

            Issue task = new Issue(title, assignee, dueDate);

            Assert.AreEqual("Title", task.Title);
        }

        [TestMethod]
        public void ShouldSetAssigne()
        {
            Issue task = new Issue("Title", "Assignee", DateTime.Parse("20-03-2030"));

            Assert.AreEqual("Assignee", task.Assignee);
        }

        [TestMethod]
        public void ShouldSetDueDate()
        {
            Issue task = new Issue("Title", "Assignee", DateTime.Parse("20-03-2030"));

            Assert.AreEqual(DateTime.Parse("20-03-2030"), task.DueDate);
        }

        [TestMethod]
        public void ShouldAdvancedStatus()
        {
            Issue task = new Issue("Title", "Assignee", DateTime.Parse("20-03-2030"));
            task.AdvanceStatus();

            Assert.AreEqual(Status.InProgress, task.Status);
        }

        [TestMethod]
        public void ShouldRevertStatus()
        {
            Issue task = new Issue("Title", "Assignee", DateTime.Parse("20-03-2030"));
            task.AdvanceStatus();
            task.RevertStatus();

            Assert.AreEqual(Status.Todo, task.Status);
        }

        [TestMethod]
        public void ShouldAddInfo()
        {
            Issue task = new Issue("Title", "Assignee", DateTime.Parse("20-03-2030"));

            Assert.IsNotNull(task.ViewInfo());
        }

        [TestMethod]
        public void ShouldAddInEventLog()
        {
            Issue task = new Issue("Title", "Assignee", DateTime.Parse("20-03-2030"));

            Assert.AreEqual(1, issue.EventLog.Count);
        }

        public void ReturnsCorrectType()
        {

            Issue task = new Issue("Title", "Assignee", DateTime.Parse("20-03-2030"));

            Assert.IsInstanceOfType(task, typeof(Issue));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenAssigneesNameIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue("Test title", null, DateTime.Now));
        }

        [TestMethod]
        [DataRow("ivo")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ShouldThrowAnExceptionWhenInvalidAssigneeLength(string value)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue("Test title", value, DateTime.Parse("20-03-2030")));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenTitleNameIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue(null, "Assignee", DateTime.Now));
        }

        [TestMethod]
        [DataRow("ivo")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ShouldThrowAnExceptionWhenInvalidTitleLength(string value)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue(value, "Assignee", DateTime.Parse("20-03-2030")));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenDueDateIsInThePast()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Issue("Ala-bala", "Assignee", DateTime.Parse("20-03-2000")));
        }
    }
}
