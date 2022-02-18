using Academy.Core;
using Academy.Models;
using System.Linq;

namespace Academy
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var repository = new Repository();
            var commandFactory = new CommandFactory(repository);
            var engine = new Engine(commandFactory);
            engine.Start();
        }      
    }
}
