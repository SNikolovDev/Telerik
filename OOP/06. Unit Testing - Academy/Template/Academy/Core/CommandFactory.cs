using Academy.Commands.Adding;
using Academy.Commands.Contracts;
using Academy.Commands.Creating;
using Academy.Core.Contracts;

using System;
using System.Collections.Generic;

namespace Academy.Core
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            // RemoveEmptyEntries makes sure no empty strings are added to the result of the split operation.
            string[] arguments = commandLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string commandName = this.ExtractCommandName(arguments);
            List<string> commandParameters = this.ExtractCommandParameters(arguments);

            ICommand command;
            switch (commandName.ToLower())
            {
                case "addstudenttocourse":
                    command = new AddStudentToCourseCommand(commandParameters, repository);
                    break;
                case "addstudenttoseason":
                    command = new AddStudentToSeasonCommand(commandParameters, repository);
                    break;
                case "addtrainertoseason":
                    command = new AddTrainerToSeasonCommand(commandParameters, repository);
                    break;
                case "createcourse":
                    command = new CreateCourseCommand(commandParameters, repository);
                    break;
                case "createcourseresult":
                    command = new CreateCourseResultCommand(commandParameters, repository);
                    break;
                case "createlecture":
                    command = new CreateLectureCommand(commandParameters, repository);
                    break;
                case "createlectureresource":
                    command = new CreateLectureResourceCommand(commandParameters, repository);
                    break;
                case "createseason":
                    command = new CreateSeasonCommand(commandParameters, repository);
                    break;
                case "createstudent":
                    command = new CreateStudentCommand(commandParameters, repository);
                    break;
                case "createtrainer":
                    command = new CreateTrainerCommand(commandParameters, repository);
                    break;
                default:
                    throw new InvalidOperationException($"Command with name: {commandName} doesn't exist!");
            }
            return command;
        }

        // Receives a full line and extracts the command to be executed from it.
        // For example, if the input line is "FilterBy Assignee John", the method will return "FilterBy".
        private string ExtractCommandName(string[] arguments)
        {
            string commandName = arguments[0];
            return commandName;
        }

        // Receives a full line and extracts the parameters that are needed for the command to execute.
        // For example, if the input line is "FilterBy Assignee John",
        // the method will return a list of ["Assignee", "John"].
        private List<String> ExtractCommandParameters(string[] arguments)
        {
            List<string> commandParameters = new List<string>();

            for (int i = 1; i < arguments.Length; i++)
            {
                commandParameters.Add(arguments[i]);
            }

            return commandParameters;
        }
    }
}
