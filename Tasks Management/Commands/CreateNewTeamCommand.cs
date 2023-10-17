using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    public class CreateNewTeamCommand : BaseCommand
    {
    
        public CreateNewTeamCommand(List<string> parameters, IRepository repository) : base(parameters, repository)
        {
        
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }
            string name = this.CommandParameters[0];
            return this.CreateTeam(name);
        }

        public string CreateTeam(string name)
        {
            ValidateTeamName(name);
            if(this.Repository.TeamExist(name))
            {
                string errorMessage = $"Team {name} already exist. Choose a different name!";
                throw new AuthorizationException(errorMessage);
            }
            ITeam team = this.Repository.CreateTeam(name);
            this.Repository.AddTeam(team);
            return string.Format($"Team {name} registered successfully!", name);
        }

        private void ValidateTeamName(string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName) || teamName.Length < Team.TeamNameMinLength || teamName.Length > Team.TeamNameMaxLength)
            {
                throw new InvalidUserInputException($"Team name must be between {Team.TeamNameMinLength} and {Team.TeamNameMaxLength} characters.");
            }
        }
    }
}
