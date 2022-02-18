using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Models.Enums;

using System;
using System.Collections.Generic;
using System.Globalization;

namespace Academy.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(IRepository repository)
            : this(new List<string>(), repository)
        {
        }

        protected BaseCommand(IList<string> commandParameters, IRepository repository)
        {
            this.CommandParameters = commandParameters;
            this.Repository = repository;
        }

        public abstract string Execute();

        protected IRepository Repository { get; }

        protected IList<string> CommandParameters { get; }

        protected int ParseIntParameter(string value, string parameterName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new ArgumentException($"Invalid value for {parameterName}. Should be an integer number.");
        }

        protected float ParseFloatParameter(string value, string parameterName)
        {
            if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
            {
                return result;
            }
            throw new ArgumentException($"Invalid value for {parameterName}. Should be a real number.");
        }

        protected bool ParseBoolParameter(string value, string parameterName)
        {
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            throw new ArgumentException($"Invalid value for {parameterName}. Should be either true or false.");
        }

        protected DateTime ParseDateTimeParameter(string value, string parameterName)
        {
            if (DateTime.TryParse(value, out DateTime result))
            {
                return result;
            }
            throw new ArgumentException($"Invalid value for {parameterName}. Should be a valid date.");
        }

        protected Initiative ParseInitiativeParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out Initiative result))
            {
                return result;
            }
            throw new ArgumentException($"Invalid value for {parameterName}. Should be a valid Initiative type.");
        }

        protected Track ParseTrackParameter(string value, string parameterName)
        {
            if (Enum.TryParse(value, true, out Track result))
            {
                return result;
            }
            throw new ArgumentException($"Invalid value for {parameterName}. Should be a valid Track type.");
        }
    }
}
