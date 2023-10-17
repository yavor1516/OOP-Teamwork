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
    public class ShowAllTeamBoardsCommand : BaseCommand
    {
        public ShowAllTeamBoardsCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
            
        }
        protected override string ExecuteCommand()
        {
            //TODO ako se napishe showallteamboards ne pokazva Invalid number of arguments. Expected: 1, 
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }
            string teamName = this.CommandParameters[0];
            return ShowAllTeamBoards(teamName);
        }
        private string ShowAllTeamBoards(string teamName)
        {
            ITeam team = Repository.GetTeam(teamName);
            if (team == null)
            {
                throw new InvalidUserInputException($"Team {teamName} not found");
            }
            IList<IBoard> teamBoards = this.Repository.Boards;

            if (teamBoards.Count == 0)
            {
                return $"Team {teamName} has no boards.";
            }
            else
            {

                StringBuilder result = new StringBuilder();
                result.AppendLine($"Boards for Team {teamName}:");

                foreach (var board in teamBoards)
                {
                    result.AppendLine($"{board.Name}");
                }

                return result.ToString();
            }


        }


    }
}
