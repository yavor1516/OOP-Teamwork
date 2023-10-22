using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tasks_Management.Core.Contracts;

namespace Tasks_Management.Commands
{
    internal class AddStepsToCommand : BaseCommand
    {
        public AddStepsToCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            int id = int.Parse(this.CommandParameters[0]);
            List<string> steps = CommandParameters.ToList();
            return this.TaskSteps(id, steps);
        }
        private string TaskSteps(int id, List<string> steps)
        {
            this.Repository.GetTask(id).steps = steps;
            return string.Join(" ", steps);
        }
    }
}
