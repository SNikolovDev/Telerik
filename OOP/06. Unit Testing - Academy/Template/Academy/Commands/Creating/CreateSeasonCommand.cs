using Academy.Core.Contracts;
using Academy.Models.Enums;

using System;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateSeasonCommand : BaseCommand
    {
        public CreateSeasonCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 3)
            {
                throw new ArgumentException($"Invalid number of arguments. Expected: 3, Received: {this.CommandParameters.Count}");
            }

            int startingYear = this.ParseIntParameter(this.CommandParameters[0], "startingYear");
            int endingYear = this.ParseIntParameter(this.CommandParameters[1], "endingYear");
            Initiative initiative = this.ParseInitiativeParameter(this.CommandParameters[2], "initiative");

            this.Repository.CreateSeason(startingYear, endingYear, initiative);

            return $"Season with ID {this.Repository.Seasons.Count - 1} was created.";
        }
    }
}
