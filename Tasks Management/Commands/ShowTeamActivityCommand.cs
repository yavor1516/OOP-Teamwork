using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Core;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    internal class ShowTeamActivityCommand:BaseCommand
    {
        public ShowTeamActivityCommand(IList<string> commandParameters, IRepository repository) :
              base(commandParameters, repository)
        {

        }
        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 1)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 1, Received: {this.CommandParameters.Count}");
            }
            string teamName = this.CommandParameters[0];
            
            return ShowTeamActivity(teamName);
        }

        private string ShowTeamActivity(string teamName)
        {

            ITeam team = Repository.GetTeam(teamName);

            if (team == null)
            {
                throw new InvalidUserInputException($"Team {teamName} not found");
            }

            List<IActiveHistory> teamActivityHistory = new List<IActiveHistory>();

            foreach (IMember member in team.Members)
            {
                teamActivityHistory.AddRange(member.History);
            }

            if (teamActivityHistory.Count == 0)
            {
                return $"Team {teamName} has no activity.";
            }
            else
            {
                string activityList = string.Join(", ", teamActivityHistory.Select(activity => activity.Messages));
                return $"Team {teamName} includes {activityList}";
            }
        }

    }
}
