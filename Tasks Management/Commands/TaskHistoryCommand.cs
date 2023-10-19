﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    internal class TaskHistoryCommand : BaseCommand
    {
        public TaskHistoryCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count >1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }
            string name = this.CommandParameters[0];
            return ShowTaskHistory(name);

        }

        private string ShowTaskHistory(string name)
        {
            ITask task = Repository.GetTask(name);
            StringBuilder sb = new StringBuilder();
            foreach (string msg in task.History.Messages)
            {
                sb.AppendLine(string.Format("{0}", msg.ToString()));

            }

            return sb.ToString().Trim();
        }
    }
    
}