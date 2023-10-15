
using System.Text;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    public class ShowAllTeamsCommand : BaseCommand
    {

        public ShowAllTeamsCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        
            
        }
        protected override string ExecuteCommand()
        {
            return ShowAllTeams();

        }
        private string ShowAllTeams()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ITeam team in this.Repository.Teams)
            {
                sb.AppendLine(string.Format("{0}", team.Name.ToString()));

            }

            return sb.ToString().Trim();
        }

    }
}
