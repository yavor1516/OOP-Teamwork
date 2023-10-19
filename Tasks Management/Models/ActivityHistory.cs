using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class ActivityHistory : Contracts.IActivityHistory
    {
        public ActivityHistory()
        {
            Messages = new List<string>();  
        }
        public IList<string> Messages { get; }
    }
}
