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
            set
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

        public override string ViewInfo()
        {
            return $"{base.ViewInfo()} Description: { this.Description}";
        }
    }
}
