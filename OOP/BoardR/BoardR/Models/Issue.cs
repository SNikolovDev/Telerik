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
            this.description = description;
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
                    eventLogs.Add(new EventLog(this.ViewInfo()));

                    this.description = value;
                }
            }
        }

        public override void AdvanceStatus()
        {
            if (this.Status == Status.Verified)
            {
                eventLogs.Add(new EventLog($"Issue status already {this.Status.ToString()}"));
            }
            else
            {
                eventLogs.Add(new EventLog($"Issue status set to {this.Status + 4}"));//mooving status from 0 to 4 position;
                this.Status = Status.Verified;
            }
        }


        //    string currentStatus = this.Status.ToString();
        //    this.Status = Status.Verified;

        //    this.eventLogs.Add(new EventLog($"Status changed from {currentStatus} to {this.Status.ToString()}"));
        //

        public override void RevertStatus()
        {
            if (this.Status == Status.Open)
            {
                eventLogs.Add(new EventLog($"Issue status already {this.Status.ToString()}"));
            }
            else
            {
                eventLogs.Add(new EventLog($"Issue status set to {this.Status - 4}"));//mooving status from 4 to 0 position;
                this.Status = Status.Open;
            }

            //string currentStatus = this.Status.ToString();

            //eventLogs.Add(new EventLog($"Status changed from {currentStatus} to {this.Status.ToString()}"));
        }

        public override string ViewInfo()
        {
            return $"{base.ViewInfo()} Description: { this.Description}";
        }
    }
}
