using System;
using System.Collections.Generic;
using System.Text;

namespace BoardR
{
    public class BoardItem
    {
        //title - describes what this item is about;
        //dueDate - by when it should be finished;
        //status - describes the state of this item - being worked on, being completed, etc..;

        private string title;
        private DateTime dueDate;
        private Status status = Status.Open;
        private List<EventLog> eventLogs;
        public BoardItem(string title, DateTime dueDate)
        {
            eventLogs = new List<EventLog>();
            this.title = title;
            this.dueDate = dueDate;
            this.Status = status;
            eventLogs.Add(new EventLog($"Item created: '{this.Title}', {this.ViewInfo()}"));

        }//Item created: 'Refactor this mess', [Open|25-01-2020]
        public string Title
        {
            get => this.title;
            set
            {   // non-empty, at least several characters -> [5-30];
                if (value == null)
                {
                    throw new NullReferenceException();
                }

                else if (value.Length < 5 || value.Length > 30 || string.IsNullOrEmpty(value))
                {
                    throw new Exception("Title length must be between 5 and 30 characters!");
                }

                if (this.title != string.Empty)
                {
                    eventLogs.Add(new EventLog($"Title changed from '{this.title}' to '{value}'"));
                }

                this.title = value;
            }
        }

        public DateTime DueDate
        {
            get => this.dueDate;
            set
            {   // must be in the future;
                if (value <= DateTime.Now)
                {
                    throw new Exception("Time and date must be in the future!");
                }

                eventLogs.Add(new EventLog($"DueDate changed from '{this.DueDate}' to '{value}'"));
                this.dueDate = value;
            }
        }

        public Status Status { get; set; }

        public void RevertStatus()
        {
            if (this.Status == Status.Open)
            {
                eventLogs.Add(new EventLog("Can't revert, already at Open"));
                return;
            }

            string currentStatus = Status.ToString();
            this.Status--;
            eventLogs.Add(new EventLog($"Status changed from {currentStatus} to {Status.ToString()}"));
        }

        public void AdvanceStatus()
        {
            if (this.Status == Status.Verified)
            {
                eventLogs.Add(new EventLog("Can't advance, already at Verified"));
                return;
            }

            string currentStatus = Status.ToString();
            this.Status++;
            eventLogs.Add(new EventLog($"Status changed from {currentStatus} to {Status.ToString()}"));
        }

        public string ViewInfo()
        {
            return $"'{this.Title}', [{this.Status}|{DueDate:dd-MM-yyyy}]";
        }

        public string ViewHistory()
        {
            StringBuilder builder = new StringBuilder();

            foreach (var log in eventLogs)
            {
                builder.AppendLine(log.ViewInfo());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
