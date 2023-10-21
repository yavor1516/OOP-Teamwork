using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    public class ChangeBugCommand : BaseCommand
    {
        public ChangeBugCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 3)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Usage: ChangeBug [TaskID] [Priority/Severity/Status] [NewValue]");
            }
            int id = int.Parse(this.CommandParameters[0]);
            string TargetParameter = this.CommandParameters[1];
            string ChangeValueOfTargetParameter = this.CommandParameters[2];

            switch (TargetParameter)
            {
                case "priority":
                    return this.ChangePriority(id, ParsePriorityType(ChangeValueOfTargetParameter));
                case "severity":
                    return this.ChangeSeverity(id, ParseSeverityType(ChangeValueOfTargetParameter));
                case "status":
                    return this.ChangeStatus(id, ParseStatusType(ChangeValueOfTargetParameter));

                default:
                    throw new NotImplementedException();
            }
            //Change the Priority/Severity/Status of a bug

        }
        private Priority ParsePriorityType(string priority)
        {

            Enum.TryParse(priority, true, out Priority result);
            return result;
        }
        private Severity ParseSeverityType(string severity)
        {

            Enum.TryParse(severity, true, out Severity result);
            return result;
        }
        public BugStatus ParseStatusType(string status)
        {
            Enum.TryParse(status, true, out BugStatus result);
            return result;
        }
        private string ChangePriority(int id, Priority priority)
        {
            IBug bug = this.Repository.GetBug(id);
            bug.History.Messages.Add($"Bug priority has been changed from {bug.Priority} to {priority}");
            bug.Priority = priority;
            return string.Format($"Bug priority changed successfully!");
        }
        private string ChangeSeverity(int id, Severity severity)
        {
            IBug bug = this.Repository.GetBug(id);
            bug.History.Messages.Add($"Bug severity has been changed from {bug.Severity} to {severity}");
            bug.Severity = severity;
            return string.Format($"Bug severity changed successfully!");
        }
        private string ChangeStatus(int id, BugStatus bugStatus)
        {
            IBug bug = this.Repository.GetBug(id);
            bug.History.Messages.Add($"Bug status has been changed from {bug.Status} to {bugStatus}");
            bug.Status = bugStatus;
            return string.Format($"Bug status changed successfully!");

        }
    }
}