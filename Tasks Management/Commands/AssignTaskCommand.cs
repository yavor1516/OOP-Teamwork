using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    internal class AssignTaskCommand : BaseCommand
    {
        public AssignTaskCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            int id = int.Parse(this.CommandParameters[0]);
            string MemberFirstName = this.CommandParameters[1];
            string MemberLastName = this.CommandParameters[2];
            return AssignTaskToMember(id, MemberFirstName, MemberLastName);
        }

        private string AssignTaskToMember(int id,string firstNameMember,string lastNameMember)
        {
            ITask task = Repository.GetTask(id);
            IMember member = Repository.GetMember(firstNameMember, lastNameMember);
            task.Assignee = member;
            task.History.Messages.Add($"Task of type {task.Tasktype} has been assigned to {member.FirstName} {member.LastName}");
            member.Tasks.Add(task);
            member.History.Messages.Add($"Task of type {task.Tasktype} with title {task.Title} been assigned");
            
            return string.Format($"Task: {task.Title} has been assigned to member: {member.FirstName} {member.LastName}");

        }
    }
}
