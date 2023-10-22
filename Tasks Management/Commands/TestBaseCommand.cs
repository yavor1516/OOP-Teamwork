using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;

namespace Tasks_Management.Commands
{
    public class TestBaseCommand:BaseCommand
    {
        public TestBaseCommand(IList<string> commandParameters, IRepository repository)
        : base(commandParameters, repository)
        {
        }

        public override int ParseIntParameter(string value, string parameterName)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Invalid value for {parameterName}. Should be an integer number.");
        }

        protected override string ExecuteCommand()
        {
            return "Test result";
        }
    }
}
