using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;

namespace Tasks_Management.Models.Contracts
{
    public interface IStory:ITask
    {
        Priority Priority { get; set; }
        Size Size { get; set;}
        IMember Assignee { get; }
        StoryStatus Status { get; set; }

    }
}
