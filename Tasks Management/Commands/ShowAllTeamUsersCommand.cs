using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Core;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;
using System.Xml.Linq;
using Tasks_Management.Models;

namespace Tasks_Management.Commands
{
    public class ShowAllTeamUsersCommand:BaseCommand
    {
        public ShowAllTeamUsersCommand(IList<string> commandParameters, IRepository repository) :
           base(commandParameters, repository)
        {

        }
        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"This command expects 1 argument. Usage: ShowAllTeamUsers [team]");
            }
            string teamName = this.CommandParameters[0];
            return ShowTeamUsers(teamName);
        }

        private string ShowTeamUsers(string teamName)
        {
            ITeam team = Repository.GetTeam(teamName);

            if (team == null)
            {
                throw new InvalidUserInputException($"Team {teamName} not found");
            }

            IList<IMember> teamMembers = this.Repository.Members;

            if (teamMembers.Count == 0)
            {
                return $"Team {teamName} has no users.";
            }
            else
            {
                string userList = string.Join(", ", teamMembers.Select(member => member.FirstName + " " + member.LastName));
                return $"{teamName} includes {userList}";
            }
        }
    }
}

