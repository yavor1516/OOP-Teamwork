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
    internal class ShowBoardActivityCommand:BaseCommand
    {
            public ShowBoardActivityCommand(IList<string> commandParameters, IRepository repository) :
                  base(commandParameters, repository)
            {

            }
            protected override string ExecuteCommand()
            {
                if (this.CommandParameters.Count != 1)
                {
                    throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
                }
                string boardName = this.CommandParameters[0];

                return ShowBoardActivity(boardName);
            }

        public string ShowBoardActivity(string boardName)
        {
            IBoard board = Repository.GetBoard(boardName);

            if (board == null)
            {
                throw new InvalidUserInputException($"Board {boardName} not found");
            }

            board.History.Messages.Clear();
            
            foreach (ITask task in board.Tasks)
            {
                for (int i = 0; i < task.History.Messages.Count; i++)
                {
                    board.History.Messages.Add(task.History.Messages[i]);
                }
            }

            if (board.History.Messages.Count == 0)
            {
                return $"Board {boardName} has no activity.";
            }
            else
            {
                string activityList = string.Join(", ", board.History.Messages);
                return $"Board {boardName} includes {activityList}";
            }
        }
    }
}
