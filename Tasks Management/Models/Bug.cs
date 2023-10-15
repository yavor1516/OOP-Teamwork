using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Bug : Task ,IBug
    {
        public Bug(int id,string Title, string Description, Status Status, IList<IComment> Comments, IList<IActiveHistory> History, IList<string> steps, Priority priority, Severity severity, Status status, IMember assignee) 
            : base(id,Title,Description,status,Comments,History)
        {

        }

       


        public IList<string> steps => throw new NotImplementedException();

        public Priority priority => throw new NotImplementedException();

        public Severity severity => throw new NotImplementedException();

        public Status status => throw new NotImplementedException();

        public IMember assignee => throw new NotImplementedException();
    }
}
