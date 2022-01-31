using System;
using System.Text;
using System.Collections.Generic;

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
        protected List<EventLog> eventLogs = new List<EventLog>();
        private const int TITLE_MIN_VALUE = 5;
        private const int TITLE_MAX_VALUE = 30;

        public BoardItem(string title, DateTime dueDate)
        {
            //this.eventLogs = new List<EventLog>();
            this.Title = title;
            this.dueDate = dueDate;
            this.Status = status;
        }

        public string Title
        {
            get => this.title;
            set
            {   // non-empty, at least several characters -> [5-30];
                if (value == null)
                {
                    throw new NullReferenceException();
                }

                else if (value.Length < TITLE_MIN_VALUE || value.Length > TITLE_MAX_VALUE || string.IsNullOrEmpty(value))
                {
                    throw new Exception("Title length must be between 5 and 30 characters!");
                }

                if (this.title != null)
                {
                    this.eventLogs.Add(new EventLog($"Title changed from '{this.title}' to '{value}'"));
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

                eventLogs.Add(new EventLog($"DueDate changed from '{this.dueDate}' to '{value}'"));

                this.dueDate = value;
            }
        }

        public Status Status { get; set; }

        public void RevertStatus()
        {
            if (this.Status == Status.Open)
            {
                this.eventLogs.Add(new EventLog("Can't revert, already at Open"));

                return;
            }

            string currentStatus = this.Status.ToString();
            this.Status--;

            eventLogs.Add(new EventLog($"Status changed from {currentStatus} to {this.Status.ToString()}"));
        }

        public void AdvanceStatus()
        {
            if (this.Status == Status.Verified)
            {
                this.eventLogs.Add(new EventLog("Can't advance, already at Verified"));
                return;
            }

            string currentStatus = this.Status.ToString();
            this.Status++;

            this.eventLogs.Add(new EventLog($"Status changed from {currentStatus} to {this.Status.ToString()}"));
        }

        public virtual string ViewInfo()
        {
            return $"'{this.Title}', [{this.Status}|{DueDate:dd-MM-yyyy}]";
        }

        public string ViewHistory()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var log in eventLogs)
            {
                sb.AppendLine(log.ViewInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
