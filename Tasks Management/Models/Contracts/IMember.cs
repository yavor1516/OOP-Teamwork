using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks_Management.Models.Contracts
{
    public interface IMember :IHasName
    {
        IList<ITask> Tasks { get; }
        IList<IActiveHistory> History { get; }
    }
}
