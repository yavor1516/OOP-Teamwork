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

        public Priority priority { get; set; }

        public Severity severity { get; set; }

        public Status status { get; set; }

        public IMember assignee { get; }

        public IActivityHistory activityHistory { get; }
    }
}
