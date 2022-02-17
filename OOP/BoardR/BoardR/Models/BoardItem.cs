using System;
using System.Text;
using System.Collections.Generic;

namespace BoardR
{
    public abstract class BoardItem
    {
        //title - describes what this item is about;
        //dueDate - by when it should be finished;
        //status - describes the state of this item - being worked on, being completed, etc..;
        private const string DateFormat = "dd-MM-yyyy";

        private string title;
        private DateTime dueDate;
        private Status status = Status.Open;
        protected List<EventLog> eventLogs = new List<EventLog>();

        public BoardItem(string title, DateTime dueDate)
        {
            //this.eventLogs = new List<EventLog>();
            this.Title = title;
            this.dueDate = dueDate;
            //this.Status = status;
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

                else if (value.Length < Constants.NAME_MIN_VALUE || value.Length > Constants.NAME_MAX_VALUE || string.IsNullOrEmpty(value))
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

        public List<EventLog> EventLog => new List<EventLog>(this.eventLogs);

        public DateTime DueDate
        {
            get => this.dueDate;
            set
            {   // Can't be in the past;
                if (value < DateTime.Now)
                {
                    throw new Exception("DueDate can't be in the past");
                }

                this.eventLogs.Add(new EventLog($"DueDate changed from '{this.dueDate.ToString()}' to '{value.ToString(DateFormat)}'"));

                this.dueDate = value;
            }
        }

        public Status Status => this.status;

        public abstract void RevertStatus();

        public abstract void AdvanceStatus();

        public virtual string ViewInfo()
        {
            return $"'{this.Title}', [{this.Status}|{this.DueDate:dd-MM-yyyy}]";
        }

        public string ViewHistory()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var log in this.eventLogs)
            {
                sb.AppendLine(log.ViewInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
