using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    internal class Story : Task ,IStory
    {
        public Story(int id,string Title, string Description, Status Status,
            IList<IComment> Comments, IList<IActiveHistory> History,Priority priority,Size size,IMember assignee) 
            : base(id,Title, Description, Status, Comments, History)
        {

        }

        public Priority Priority => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public IMember Assignee => throw new NotImplementedException();
    }
}
