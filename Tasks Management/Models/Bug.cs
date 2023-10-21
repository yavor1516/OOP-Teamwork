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
            if (Title.Length < NameMinLength || Title.Length > NameMaxLength)
            {
                throw new InvalidUserInputException(InvalidNameError);
            }

            if (Description.Length < DescriptionMinLength || Description.Length > DescriptionMaxLength)
            {
                throw new InvalidUserInputException(InvalidDescriptionError);
            }
            this.Status = status;
            this.Priority = priority;
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
