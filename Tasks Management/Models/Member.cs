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
        private string name;
        private IList<ITask> tasks;
        private IList<IActiveHistory> history;

        public Member(string name)
        {
            if (IsNameValid(name))
            {
                this.name = name;
                tasks = new List<ITask>();
                history = new List<IActiveHistory>();
            }
            else
            {
                throw new ArgumentException("Invalid member name.");
            }
        }

        public IList<ITask> Tasks => tasks;

        public IList<IActiveHistory> History => history;

        public string Name => name;

        private bool IsNameValid(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 5 && name.Length <= 15;
        } 
    }
}
