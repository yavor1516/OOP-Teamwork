using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    internal class Board : IBoard
    {
        private string name;
        private IList<ITask> tasks;
        private IList<Contracts.IActivityHistory> history;

        public Board(string name)
        {
            if (IsNameValid(name))
            {
                this.name = name;
                tasks = new List<ITask>();
                history = new List<Contracts.IActivityHistory>();
            }
            else
            {
                throw new ArgumentException("Invalid board name.");
            }
        }

        public IList<ITask> Tasks => tasks;

        public IList<Contracts.IActivityHistory> History => history;

        public string Name => name;

        private bool IsNameValid(string name)
        {
            return !string.IsNullOrEmpty(name) && name.Length >= 5 && name.Length <= 10;
        }
    }
}
