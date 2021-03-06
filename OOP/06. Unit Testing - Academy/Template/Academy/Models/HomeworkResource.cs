using System;
using System.Text;

namespace Academy.Models
{
    public class HomeworkResource : Resource
    {
        public HomeworkResource(string name, string url, DateTime dueDate) 
            : base(name, url)
        {            
            this.DueDate = dueDate;
        }

        public DateTime DueDate { get; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"     - Type: Homework");
            builder.AppendLine($"     - Due date: {this.DueDate}");
            return base.ToString() + builder.ToString().TrimEnd();
        }
    }
}
