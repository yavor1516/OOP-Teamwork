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
    public class CreateTeamBoardCommand : BaseCommand
    {
        public CreateTeamBoardCommand(List<string> parameters, IRepository repository) : base(parameters, repository)
        {

        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 2) 
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Usage: CreateTeamBoard [TeamName] [BoardName]");
            }
            string teamName = this.CommandParameters[0];
            string boardName = this.CommandParameters[1];
            return CreateTeamBoard(teamName, boardName);
        }
        private string CreateTeamBoard (string teamName, string boardName)
        {
            ITeam team = Repository.GetTeam(teamName);
            if (team == null)
            {                
                throw new InvalidUserInputException($"Team {team} not found");
            }
            if (this.Repository.BoardExist(boardName))
            {
                throw new InvalidUserInputException($"Board {boardName} already exist. Choose a different name!");
            }
            IBoard board = this.Repository.CreateBoard(boardName);
            this.Repository.AddBoard(board);
            return string.Format($"Board {boardName} registered successfully!", boardName);
        }


    }
}
