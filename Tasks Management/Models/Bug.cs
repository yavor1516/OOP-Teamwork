
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Bug : Task
    {
        public Bug(string Title, string Description, Enum Status,
            IList<IComment> Comments, IList<IActiveHistory> History) 
            : base(Title, Description, Status, Comments, History)
        {

        }
    }
}
