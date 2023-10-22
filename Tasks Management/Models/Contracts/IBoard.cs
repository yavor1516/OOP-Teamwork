using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks_Management.Models.Contracts
{
    public interface IBoard :IHasName
    {
        IList<ITask> Tasks { get; }
       IActivityHistory History { get; }
    }
}
