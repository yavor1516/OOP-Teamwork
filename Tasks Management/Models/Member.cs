using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    internal class Member : IMember
    {
        public IList<ITask> Tasks => throw new NotImplementedException();

        public IList<IActiveHistory> History => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();
    }
}
