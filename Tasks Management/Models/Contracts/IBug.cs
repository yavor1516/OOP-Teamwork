using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;

namespace Tasks_Management.Models.Contracts
{
    public interface IBug:ITask
    {
        IList<string> Steps { get; }

        Priority Priority { get; set; }

        Severity Severity { get; set; }
        BugStatus Status { get; set; }
        IMember Assignee { get; set; }
      

    }
}
