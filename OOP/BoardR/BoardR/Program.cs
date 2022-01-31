using System;

namespace BoardR
{
    class Program
    {
        static void Main(string[] args)
        {
            //var task = new Task("Test the application flow", "Pesho", DateTime.Now.AddDays(1));
            //task.AdvanceStatus();
            //task.AdvanceStatus();
            //task.Assignee = "Gosho";
            //Console.WriteLine(task.ViewHistory());


            var task2 = new Task("Test the application flow", "Pesho", DateTime.Now.AddDays(1));
            task2.AdvanceStatus();
            task2.AdvanceStatus();
            task2.Assignee = "Gosho";
            Console.WriteLine(task2.ViewHistory());

        }
    }
}
