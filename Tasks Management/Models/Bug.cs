using System.ComponentModel.DataAnnotations;
using System;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Bug : Task, IBug
    {
        public Bug(int id, string title, string description, BugStatus bugStatus, Priority priority, Severity severity, IActivityHistory history)
            : base(id, title, description, history)
        {
            activityHistory = history;
            Validator.ValidateBugStatus(bugStatus, "Invalid bug status.");
            status = bugStatus;
            Validator.ValidatePriority(priority, "Invalid priority.");
            this.priority = priority;
            Validator.ValidateSeverity(severity, "Invalid severity.");
            this.severity = severity;
        }


        public IList<string> steps { get; }

        public Priority priority { get; set; }

        public Severity severity { get; set; }

        public BugStatus status { get; set; }

        public IMember assignee { get; }

        public IActivityHistory activityHistory { get; }
    }
}