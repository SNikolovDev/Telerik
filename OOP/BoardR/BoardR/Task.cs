using System;

namespace BoardR
{
    public class Task : BoardItem
    {
        private string assignee;
        private const int ASSIGNE_NAME_MIN_VALUE = 5;
        private const int ASSIGNE_NAME_MAX_VALUE = 30;

        public Task(string title, string assignee, DateTime dueDate)
            : base(title, dueDate)
        {
            base.Status = Status.Todo;
            this.assignee = assignee;
            base.eventLogs.Add(new EventLog($"Created Task: {this.ViewInfo()}"));
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
                else if (value.Length < ASSIGNE_NAME_MIN_VALUE || value.Length > ASSIGNE_NAME_MAX_VALUE)
                {
                    throw new Exception("Name should be between 5 and 30 characters");
                }

                base.eventLogs.Add(new EventLog($"Assignee changed from {this.assignee} to {value}"));

                this.assignee = value;
            }
        }


        public override string ViewInfo()
        {
            return $"'{this.Title}', [{this.Status}|{DueDate:dd-MM-yyyy}]";
        }
    }
}
