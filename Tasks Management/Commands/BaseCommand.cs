using System;
using System.Globalization;
using Tasks_Management.Commands.Contracts;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;
namespace Tasks_Management.Commands
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
        protected IRepository Repository { get; }

        protected IList<string> CommandParameters { get; }

        protected abstract string ExecuteCommand();

        protected int ParseIntParameter(string value, string parameterName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be an integer number.");
        }

        protected decimal ParseDecimalParameter(string value, string parameterName)
        {
            if (decimal.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be a real number.");
        }

        protected bool ParseBoolParameter(string value, string parameterName)
        {
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be either true or false.");
        }

        public string Execute()
        {
            return this.ExecuteCommand();
        }
    }
}
