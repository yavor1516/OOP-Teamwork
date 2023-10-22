using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;

namespace Tasks_Management.Commands
{
    internal class ShowTaskInfoCommand : BaseCommand
    {
        public ShowTaskInfoCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            int taskId = int.Parse(this.CommandParameters[0]);
            return this.ShowTask(taskId);
        }

        private string ShowTask(int taskId)
        {
           var task = this.Repository.GetTask(taskId);

           return string.Join(" ", task.steps);
        }
    }
}
