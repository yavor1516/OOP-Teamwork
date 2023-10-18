﻿using System;
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
            string TaskName = this.CommandParameters[0];
            string MemberFirstName = this.CommandParameters[1];
            string MemberLastName = this.CommandParameters[2];
            return AssignTaskToMember(TaskName, MemberFirstName, MemberLastName);
        }

        private string AssignTaskToMember(string taskName,string firstNameMember,string lastNameMember)
        {
            ITask task = Repository.GetTask(taskName);
            IMember member = Repository.GetMember(firstNameMember, lastNameMember);
            task.History.Messages.Add($"Task of type {task.Tasktype} has been assigned to {member.FirstName} {member.LastName}");
            member.Tasks.Add(task);
            
            return string.Format($"Task: {task.Title} has been assigned to member: {member.FirstName} {member.LastName}");

        }
    }
}
