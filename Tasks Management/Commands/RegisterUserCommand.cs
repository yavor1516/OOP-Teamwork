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
    public class RegisterUserCommand : BaseCommand
    {
        public RegisterUserCommand(List<string> parameters , IRepository repository)
        :base(parameters,repository)
        {
            
        }

        protected override string ExecuteCommand()
        {
            //TODO
            if (this.CommandParameters.Count != 2)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }
            string firstName = this.CommandParameters[0];
            string lastName = this.CommandParameters[1];
            return this.RegisterUser(firstName, lastName);


        }
        public string RegisterUser(string firstName,string lastName)
        {
            //todo
            if (this.Repository.MemberExist(firstName, lastName ))
            {
                
                string errorMessage = $"User {firstName} {lastName} already exist. Choose a different username!";
                throw new AuthorizationException(errorMessage);
            }
            IMember member = this.Repository.CreateMember(firstName, lastName);
            this.Repository.AddMember(member);
            return string.Format("User {0} {1} registered successfully!", firstName, lastName);
        }
    }
}
