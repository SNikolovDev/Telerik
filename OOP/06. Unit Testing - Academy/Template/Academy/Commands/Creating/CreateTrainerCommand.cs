using Academy.Core.Contracts;

using System;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateTrainerCommand : BaseCommand
    {
        public CreateTrainerCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 2)
            {
                throw new ArgumentException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }

            string username = this.CommandParameters[0];
            IList<string> technologies = this.CommandParameters[1].Split(',');

            if (this.Repository.UserExists(username))
            {
                throw new ArgumentException($"A user with the username {username} already exists!");
            }

            this.Repository.CreateTrainer(username, technologies);

            return $"Trainer with ID {this.Repository.Trainers.Count - 1} was created.";
        }
    }
}
