using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks_Management.Models.Contracts
{
    public interface IMember 
    {
        string FirstName { get; }
        string LastName { get; }
        public IList<ITask> Tasks { get; }
        public IActivityHistory History { get; }
    }
}
