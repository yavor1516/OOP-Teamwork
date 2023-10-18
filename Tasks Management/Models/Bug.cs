using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Bug : Task ,IBug
    {
        public Bug(int id,string Title, string Description, Status Status, Priority priority, Severity severity , IActivityHistory history) 
            : base(id,Title,Description, Status , history)
        {
            activityHistory = history;
        }

       


        public IList<string> steps { get; }

        public Priority priority { get; }

        public Severity severity { get; }

        public Status status { get; }

        public IMember assignee { get; }

        public IActivityHistory activityHistory { get; }
    }
}
