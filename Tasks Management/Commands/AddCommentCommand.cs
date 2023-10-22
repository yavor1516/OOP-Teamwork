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
    public class AddCommentCommand : BaseCommand
    {
        public AddCommentCommand(IList<string> commandParameters, IRepository repository) :
           base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 3)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }
            int task = int.Parse(this.CommandParameters[0]);
            string author = this.CommandParameters[1];
            string content = this.CommandParameters[2];
          
            
            return AddComment(content, task,author);
        }

        private string AddComment(string content, int id,string author)
        {
            ITask task = this.Repository.GetTask(id);

            if (task == null)
            {
                throw new InvalidUserInputException($"Task {task.Title} not found");
            }

            IComment comment = new Comment(content,author);

            task.AddComment(comment);
            task.History.Messages.Add($"{author} just a comment: {content}");

            return $"Comment added to task {task.Title}: {content}";
        }
    }

}
