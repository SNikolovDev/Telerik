using System;
using System.Collections.Generic;

namespace BoardR
{
    public class EventLog
    {
        private DateTime time = DateTime.Now;
        private static List<EventLog> log = new List<EventLog>();

        public EventLog(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException("Value cannot be null!");
            }

            this.Description = description;
            this.Time = time;
        }
        //description: string; throw on null strings
        public string Description { get; }

        public DateTime Time { get; }

        public string ViewInfo()
        {
            return $"[{this.Time:yyyyMMdd|HH:mm:ss.ffff}]{this.Description}";
        }

        protected void Add(EventLog logItem)
        {
            log.Add(logItem);
        }
    }
}
