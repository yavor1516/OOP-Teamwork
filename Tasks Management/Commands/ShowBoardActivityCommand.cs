using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;
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

        private string ShowBoardActivity(string boardName)
        {
            IBoard board = Repository.GetBoard(boardName);

            if (board == null)
            {
                throw new InvalidUserInputException($"Board {boardName} not found");
            }

            List<IActiveHistory> boardActivityHistory = new List<IActiveHistory>();

            foreach (ITask task in board.Tasks)
            {
                boardActivityHistory.AddRange(task.History);
            }

            if (boardActivityHistory.Count == 0)
            {
                return $"Board {boardName} has no activity.";
            }
            else
            {
                string activityList = string.Join(", ", boardActivityHistory.Select(activity => activity.Messages));
                return $"Board {boardName} includes {activityList}";
            }
        }
    }
}
