using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    public class AddUserToTeamCommand : BaseCommand
    {
        public AddUserToTeamCommand(IList<string> commandParameters, IRepository repository) : 
            base(commandParameters, repository)
        {

        }
        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 3)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }
            string name = this.CommandParameters[0];
            string firstName= this.CommandParameters[1];
            string lastName = this.CommandParameters[2];
            return AddUserToTeam(name, firstName, lastName);
        }

        private string AddUserToTeam(string name ,string firstName, string lastName)
        {
            ITeam team = Repository.GetTeam(name);
            if (team == null) 
            {
                throw new InvalidUserInputException($"Team {team} not found");
            }
            IMember member = this.Repository.GetMember(firstName, lastName);
            team.History.Messages.Add($"{firstName} {lastName} just beeen assigned to the team");
            team.Members.Add(member);
           
            return string.Format($"User{firstName + lastName} added to team{name}!");
        }
    }
}
