using Tasks_Management.Commands.Enums;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Bug : Task ,IBug
    {
        public Bug(int id,string Title, string Description, BugStatus status, Priority priority, Severity severity , IActivityHistory history) 
            : base(id,Title,Description, history)
        {

            Validator.ValidateBugStatus(status, "Invalid bug status.");
            this.Status = status;
            Validator.ValidatePriority(priority, "Invalid priority.");
            this.Priority = priority;
            Validator.ValidateSeverity(severity, "Invalid severity.");
            this.Severity = severity;
            this.History = history;
            
        }

       


        public IList<string> Steps { get; }

        public Priority Priority { get; set; }

        public Severity Severity { get; set; }

        public BugStatus Status { get; set; }

        public IMember Assignee { get; }

       
    }
}
