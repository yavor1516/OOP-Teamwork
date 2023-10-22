using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;

namespace Tasks_Management.Commands
{
    internal class ListTaskWithAssignee : BaseCommand
    {
        public ListTaskWithAssignee(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            return this.AssigneeListing();
        }
        private string AssigneeListing()
        {
            var TaskList = this.Repository.Tasks.Where(x=>x.Assignee!=null).OrderBy(x=>x?.Assignee.FirstName).ThenBy(x=>x?.Assignee.LastName);
            StringBuilder sb = new StringBuilder();
            foreach (var item in TaskList)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0} ", item.Assignee?.FirstName));
                sb.AppendLine(string.Format(" {0}", item.Assignee?.LastName));

            }

            return sb.ToString().Trim();
        }
    }
 
}
