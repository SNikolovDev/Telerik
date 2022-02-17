using System;

namespace BoardR
{
    public class Issue : BoardItem
    {
        private string description;

        public Issue(string title, string description, DateTime dueDate)
            : base(title, dueDate)
        {
            //base.Status = Status.Open;
            this.Description = description;
            this.eventLogs.Add(new EventLog($"Created Issue: {this.ViewInfo()}"));
        }

        public string Assignee { get; }

        public string Description
        {
            get => this.description;
            private set
            {
                if (value == null)
                {
                    this.description = "No description";
                }
                else
                {
                    this.eventLogs.Add(new EventLog(this.ViewInfo()));

                    this.description = value;
                }
            }
        }

        public override void AdvanceStatus()
        {
            if (this.Status == Status.Verified)
            {
                this.eventLogs.Add(new EventLog($"Issue status already {this.Status.ToString()}"));
            }
            else
            {
                this.eventLogs.Add(new EventLog($"Issue status set to {this.Status + 4}"));//mooving status from 0 to 4 position;
                this.Status = Status.Verified;
            }
        }

        public override void RevertStatus()
        {
            if (this.Status == Status.Open)
            {
                this.eventLogs.Add(new EventLog($"Issue status already {this.Status.ToString()}"));
            }
            else
            {
                this.eventLogs.Add(new EventLog($"Issue status set to {this.Status - 4}"));//mooving status from 4 to 0 position;
                this.Status = Status.Open;
            }
        }

        public override string ViewInfo()
        {
            return $"{base.ViewInfo()} Description: { this.Description}";
        }
    }
}
