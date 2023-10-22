using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;

namespace Tasks_Management.Models.Contracts
{
    public interface IFeedBack:ITask
    {
        int Rating { get; set; }
        FeedbackStatus Status { get; set; }


    }
}
