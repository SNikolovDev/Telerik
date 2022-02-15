using System;

namespace BoardR
{
    public class Task : BoardItem
    {
        private string assignee;

        public Task(string title, string assignee, DateTime dueDate)
            : base(title, dueDate)
        {
            base.Status = Status.Todo;
            this.assignee = assignee;
            base.eventLogs.Add(new EventLog($"Created Task: {base.ViewInfo()}"));
        }

        public string Assignee
        {
            get => this.assignee;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException("String shouldn't be null or empty!");
                }
                else if (value.Length < Constants.NAME_MIN_VALUE || value.Length > Constants.NAME_MAX_VALUE)
                {
                    throw new Exception("Name should be between 5 and 30 characters");
                }

                base.eventLogs.Add(new EventLog($"Assignee changed from {this.assignee} to {value}"));

                this.assignee = value;
            }
        }

        public override void AdvanceStatus()
        {
            if (this.Status == Status.Verified)
            {
                this.eventLogs.Add(new EventLog("Task status already {this.Status}"));
                return;
            }         

            string currentStatus = this.Status.ToString();
            this.Status++;

            this.eventLogs.Add(new EventLog($"Task changed from {currentStatus} to {this.Status.ToString()}"));
        }

        public override void RevertStatus()
        {
            if (this.Status == Status.Todo)
            {
                this.eventLogs.Add(new EventLog($"Task status already {this.Status}"));

                return;
            }

            string currentStatus = this.Status.ToString();
            this.Status--;

            eventLogs.Add(new EventLog($"Task changed from {currentStatus} to {this.Status.ToString()}"));
        }

        public override string ViewInfo()
        {
            return base.ViewInfo() + $" Assignee: {this.assignee}";
        }
    }
}
