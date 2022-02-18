using Academy.Core.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Adding
{
    public class AddTrainerToSeasonCommand : BaseCommand
    {
        public AddTrainerToSeasonCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 2)
            {
                throw new ArgumentException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }

            string trainerUsername = this.CommandParameters[0];
            int seasonId = this.ParseIntParameter(this.CommandParameters[1], "seasonId");

            var trainer = this.Repository.GetTrainerByUsername(trainerUsername);
            var season = this.Repository.Seasons[seasonId];

            if (season.Trainers.Any(x => x.Username.ToLower() == trainerUsername.ToLower()))
            {
                throw new ArgumentException($"The Trainer {trainerUsername} is already a part of Season {seasonId}!");
            }
            season.Trainers.Add(trainer);

            return $"Trainer {trainerUsername} was assigned to Season {seasonId}.";
        }
    }
}
