using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    public class ShowUsersCommand : BaseCommand
    {

        public ShowUsersCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {

        }

        protected override string ExecuteCommand()
        {
        
           return ShowAllUsers();
            
        }
        private string ShowAllUsers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IMember member in this.Repository.Members)
            {
                sb.AppendLine(string.Format("{0}", member.FirstName.ToString()));
                sb.AppendLine(string.Format("{0}", member.LastName.ToString()));
              
            }

            return sb.ToString().Trim();
        }
        }
    }

