using System;
using BoardR.Loggers;

namespace BoardR
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var tomorrow = DateTime.Now.AddDays(1);
            //BoardItem task = new Task("Write unit tests", "Pesho", tomorrow);
            Issue issue = new Issue("Review tests", null, tomorrow);

            //Console.WriteLine(task.ViewInfo());
            Console.WriteLine(issue.Description);

            Task task = new Task("lkjlkj", "lkjljlkj", DateTime.Now);
            task.EventLog.Add(new EventLog("lkjlj"));

        }
    }
}
