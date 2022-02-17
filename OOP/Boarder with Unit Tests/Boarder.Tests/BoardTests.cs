using Boarder.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Boarder.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void ShouldAddBoardItemToList()
        {
            BoardItem task = new Task("Title", "Assigne", DateTime.Parse("20-03-2030"));
            Board.AddItem(task);

            Assert.IsNotNull(Board.TotalItems);
        }

        [TestMethod]
        public void ShouldThrowAnExceptionIfItemAlreadyExicsts()
        {
            BoardItem task = new Task("Title", "Assigne", DateTime.Parse("20-03-2030"));
            Board.AddItem(task);

            Assert.ThrowsException<InvalidOperationException>(() =>
           Board.AddItem(task));
        }

        [TestMethod]
        public void PropertyShouldReturnTotalItemsCount()
        {
            BoardItem task = new Task("Title", "Assigne", DateTime.Parse("20-03-2030"));
            Board.AddItem(task);

            Assert.AreEqual(1, Board.TotalItems);
        }
        
        [TestMethod]
        public void ViewHistoryShouldReturnString()
        {
            BoardItem task = new Task("Title", "Assigne", DateTime.Parse("20-03-2030"));

            Assert.IsNotNull(task.ViewHistory());
        }

        [TestMethod]
        public void ShouldAddToLogWhenDueDateChanged()
        {
            BoardItem task = new Task("Title", "Assigne", DateTime.Parse("20-03-2030"));
            int logCount = task.EventLog.Count;
            task.DueDate = DateTime.Parse("21-03-2030");

            Assert.AreEqual(logCount + 1, task.EventLog.Count);
        }

        [TestMethod]
        public void ShouldAddToLogWhenTitleChanged()
        {
            BoardItem task = new Task("Title", "Assigne", DateTime.Parse("20-03-2030"));
            int logCount = task.EventLog.Count;
            task.Title = "Test Title";

            Assert.AreEqual(logCount + 1, task.EventLog.Count);
        }
    }
}
