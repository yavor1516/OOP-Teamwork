using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    internal class UnAssignTaskCommand : BaseCommand
    {
        public UnAssignTaskCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count < 3)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 3, Received: {this.CommandParameters.Count}");
            }
            int id = int.Parse(this.CommandParameters[0]);
            string memberFirstName = CommandParameters[1];
            string memberLastName = CommandParameters[2];
            return this.UnassigneTaskForMember(id, memberFirstName, memberLastName);
        }

        private string UnassigneTaskForMember(int id,string memberFirstName,string memberLastName)
        {
            ITask task = this.Repository.GetTask(id);
            IMember member = this.Repository.GetMember(memberFirstName, memberLastName);
            task.Assignee = null;
            member.Tasks.Remove(task);
            member.History.Messages.Add($"Task of type {task.Tasktype} has beeen unassigned");
            task.History.Messages.Add($"Task of type {task.Tasktype} has been unsassigned from {member.FirstName} {member.LastName}");
            return string.Format($"Task has been unsassigned from {member.FirstName} {member.LastName}!!");
        }
    }
}
