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
    internal class ShowUserActivityCommand:BaseCommand
    {
            public ShowUserActivityCommand(IList<string> commandParameters, IRepository repository) :
               base(commandParameters, repository)
            {

            }
            protected override string ExecuteCommand()
            {
                if (this.CommandParameters.Count != 2)
                {
                    throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
                }
                string firstName = this.CommandParameters[0];
                string lastName = this.CommandParameters[1];
                return ShowUserActivity(firstName,lastName);
            }

            private string ShowUserActivity(string firstName , string lastName)
            {
                IMember member = Repository.GetMember(firstName, lastName);
                

                if (member == null)
                {
                    throw new InvalidUserInputException($"User {firstName + ' ' + lastName} not found");
                }

            Models.Contracts.IActivityHistory activeHistory = member.History;

                if (activeHistory.Messages.Count == 0)
                {
                    return $"User {firstName + " " + lastName} has no activity.";
                }
                else
                {
                    string userList = string.Join(", ", activeHistory.Messages);
                    return $"{firstName+""+lastName} includes {userList}";
                }
            }

    }
}

