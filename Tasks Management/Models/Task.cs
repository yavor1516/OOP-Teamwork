using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
   public abstract class Task : ITask
    {
        public int UniqueID => throw new NotImplementedException();

        public Task(string Title,string Description, Enum Status,
            IList<IComment> Comments,IList<IActiveHistory> History)
        {
            this.Title = Title;
            this.Description = Description;
            this.Status = Status;
            this.Comments = Comments;
            this.History = History;

        }
        public virtual string Title { get; }

        public virtual string Description { get; }

        public virtual Enum Status { get; }

        public  IList<IComment> Comments { get; }

        public  IList<IActiveHistory> History { get; } 

    }
}
