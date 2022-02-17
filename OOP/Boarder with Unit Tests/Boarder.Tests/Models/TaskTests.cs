using Boarder.Models;

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Boarder.Tests
{
    [TestClass]
    public class TaskTests
    {
        [TestInitialize]
        public void CreateTask()
        {
            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));
        }
        [TestMethod]
        public void ShouldCreateTaskWhenParamertersAreValid()
        {
            string title = "Title";
            string assignee = "Assignee";
            DateTime dueDate = DateTime.Parse("20-03-2030");

            Task task= new Task(title, assignee, dueDate);

            Assert.AreEqual("Title", task.Title);
        }

        [TestMethod]
        public void ShouldSetAssigne()
        {
            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));

            Assert.AreEqual("Assignee", task.Assignee);
        }

        [TestMethod]
        public void ShouldSetDueDate()
        {
            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));

            Assert.AreEqual(DateTime.Parse("20-03-2030"), task.DueDate);
        }

        [TestMethod]
        public void StatusShouldStartAtOpen()
        {
            Task task = new Task("Title", "Description", DateTime.Parse("20-03-2030"));

            Assert.AreEqual(Status.Todo, task.Status);
        }

        [TestMethod]
        public void ShouldAdvancedStatus()
        {
            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));
            task.AdvanceStatus();

            Assert.AreEqual(Status.InProgress, task.Status);
        }

        [TestMethod]
        public void ShouldRevertStatus()
        {
            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));
            task.AdvanceStatus();
            task.RevertStatus();

            Assert.AreEqual(Status.Todo, task.Status);
        }

        [TestMethod]
        public void ShouldAddInfo()
        {
            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));

            Assert.IsNotNull(task.ViewInfo());
        }

        [TestMethod]
        public void ShouldAddInEventLog()
        {
            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));

            Assert.AreEqual(1, task.EventLog.Count);
        }

        [TestMethod]
        public void ReturnsCorrectType()
        {

            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));

            Assert.IsInstanceOfType(task, typeof(Task));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow(" ")]

        public void ShouldThrowAnExceptionWhenAssigneeNameIsNullOrWhitespace(string value)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Task("Test title", value, DateTime.Parse("20-03-2030")));
        }

        [TestMethod]
        [DataRow("ivo")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ShouldThrowAnExceptionWhenInvalidAssigneeLength(string value)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Task("Test title", value, DateTime.Parse("20-03-2030")));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenTitleNameIsNull()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Task(null, "Assignee", DateTime.Now));
        }

        [TestMethod]
        [DataRow("ivo")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        public void ShouldThrowAnExceptionWhenInvalidTitleLength(string value)
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Task(value, "Assignee", DateTime.Parse("20-03-2030")));
        }

        [TestMethod]
        public void ShouldThrowAnExceptionWhenDueDateIsInThePast()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            new Task("Ala-bala", "Assignee", DateTime.Parse("20-03-2000")));
        }

        [TestMethod]
        public void TaskShouldDeriveFromBoardItem()
        {
            var type = typeof(Task);
            var isAssignable = typeof(BoardItem).IsAssignableFrom(type);

            Assert.IsTrue(isAssignable);
        }

        [TestMethod]
        public void ShouldAddToEventLogWhenStatusAtVerified()
        {
            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));
            task.AdvanceStatus();
            task.AdvanceStatus();
            task.AdvanceStatus();

            int logCount = task.EventLog.Count;
            task.AdvanceStatus();

            Assert.AreEqual(logCount + 1, task.EventLog.Count);
        }

        [TestMethod]
        public void ShouldAddToEventLogWhenAssigneeChanged()
        {
            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));
            int logCount = task.EventLog.Count;

            task.Assignee = "Changed Assignee";

            Assert.AreEqual(logCount + 1, task.EventLog.Count);
        }

        [TestMethod]
        public void ShouldAddToEventLogWhenStatusAtToDo()
        {
            Task task = new Task("Title", "Assignee", DateTime.Parse("20-03-2030"));
            int logCount = task.EventLog.Count;
            task.RevertStatus();

            Assert.AreEqual(logCount + 1, task.EventLog.Count);
        }
    }
}
