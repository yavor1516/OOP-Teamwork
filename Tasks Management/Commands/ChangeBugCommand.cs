using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    internal class ChangeBugCommand : BaseCommand
    {
        public ChangeBugCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            string BugName = CommandParameters[0];
            string TargetParameter = CommandParameters[1];
            string ChangeValueOfTargetParameter = CommandParameters[2];

            switch (TargetParameter)
            {
                case "priority":
                    return this.ChangePriority(BugName,ParsePriorityType(ChangeValueOfTargetParameter));
                case "severity":
                    return this.ChangeSeverity(BugName, ParseSeverityType(ChangeValueOfTargetParameter));
                case "status":
                    return this.ChangeStatus(BugName,ParseStatusType(ChangeValueOfTargetParameter));

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
        private string ChangePriority(string BugName,Priority priority)
        {
            Bug bug = this.Repository.GetBug(BugName);
            bug.activityHistory.Messages.Add($"Bug priority has been changed from {bug.priority} to {priority}");
            ITask task = this.Repository.GetTask(BugName);
            task.History.Messages.Add($"Bug priority has been changed from {bug.priority} to {priority}");
            bug.priority = priority;
            return string.Format($"Bug priority changed successfully!");
        }
        private string ChangeSeverity(string bugName, Severity severity)
        {
            Bug bug = this.Repository.GetBug(bugName);
            bug.activityHistory.Messages.Add($"Bug severity has been changed from {bug.severity} to {severity}");
            ITask task = this.Repository.GetTask(bugName);
            task.History.Messages.Add($"Bug severity has been changed from {bug.severity} to {severity}");
            bug.severity = severity;
            return string.Format($"Bug severity changed successfully!");
        }
        private string ChangeStatus(string BugName,BugStatus bugStatus)
        {
            Bug bug = this.Repository.GetBug(BugName);
            bug.activityHistory.Messages.Add($"Bug status has been changed from {bug.status} to {bugStatus}");
            ITask task = this.Repository.GetTask(BugName);
            task.History.Messages.Add($"Bug status has been changed from {bug.status} to {bugStatus}");
            bug.status = bugStatus;
            return string.Format($"Bug status changed successfully!");

        }
    }
}
