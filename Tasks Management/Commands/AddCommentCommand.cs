using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Core;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Models;

namespace Tasks_Management.Commands
{
    internal class AddCommentCommand : BaseCommand
    {
        public AddCommentCommand(IList<string> commandParameters, IRepository repository) :
           base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 2)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }

            string content = this.CommandParameters[0];
            string task = this.CommandParameters[1];

            return AddComment(content, task);
        }

        private string AddComment(string content, string taskName)
        {
            ITask task = this.Repository.GetTask(taskName);

            if (task == null)
            {
                throw new InvalidUserInputException($"Task {taskName} not found");
            }

            IComment comment = new Comment(content, taskName);

            task.AddComment(comment);

            return $"Comment added to task {taskName}: {content}";
        }
    }

}
