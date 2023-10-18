using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;

namespace Tasks_Management.Models.Contracts
{
    public interface IBug
    {
        IList<string> steps { get; }

        Priority priority { get; }

        Severity severity { get; }
        Status status { get; }
        IMember assignee { get; }
        IActivityHistory activityHistory{get;}

    }
}
