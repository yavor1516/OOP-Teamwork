using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    internal class AssignCriticalBugsCommand : BaseCommand
    {
        public AssignCriticalBugsCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            string firstName = CommandParameters[0];
            string lastName = CommandParameters[1];
           return this.AssignAllCriticalBugs(firstName, lastName);
        }

        private string AssignAllCriticalBugs(string firstName, string lastName)
        {
         
            AssignTaskCommand task = new AssignTaskCommand(this.CommandParameters,this.Repository);
            var bugs = Repository.Tasks.Where(x => x.Tasktype == Enums.TaskType.Bug).ToList();
            foreach (IBug bug in bugs)
            {
              
                if(bug.Severity == Enums.Severity.Critical)
                {
                        task.AssignTaskToMember(bug.UniqueID,firstName,lastName);
                }
            }
            return string.Format($"All tasks has been assigned to member: {firstName} {lastName}");

        }
    }
}
