using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    internal class ListTaskCommand : BaseCommand
    {
        public ListTaskCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            string[] inputParts = this.CommandParameters.ToArray();
            string input = inputParts[0].ToLower();


            switch (input)
            {
                case "filter":
                    if (inputParts.Count() <2)
                    {
                        throw new ArgumentException("to filter tasks you need one more parameter");
                    }
                    return this.ListByFilter(inputParts[1]);
                case "order":
                    if (inputParts.Count() > 1)
                    {
                        throw new ArgumentException("order dont have any additional parameters");
                    }
                    return this.ListByOrder();


                default:
                    return this.ListAllTasks();
                    
            }
           
        }

        private string ListAllTasks()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ITask task in this.Repository.Tasks)
            {
                sb.Append(string.Format("-- {0}", task.UniqueID));
                sb.Append(string.Format(" ||{0}||", task.Tasktype));
                sb.Append(string.Format(" {0}", task.Title));
                sb.Append(string.Format("|| {0}", task.Description));
                switch (task.Tasktype)
                {
                    case TaskType.Bug:
                        sb.Append(string.Format("|| {0}", this.Repository.GetBug(task.UniqueID).Status));
                        sb.Append(string.Format("|| {0}", this.Repository.GetBug(task.UniqueID).Priority));
                        sb.AppendLine(string.Format("|| {0}", this.Repository.GetBug(task.UniqueID).Severity));
                        break;
                    case TaskType.Story:
                        sb.Append(string.Format("|| {0}", this.Repository.GetStory(task.UniqueID).Status));
                        sb.Append(string.Format("|| {0}", this.Repository.GetStory(task.UniqueID).Priority));
                        sb.AppendLine(string.Format("|| {0}", this.Repository.GetStory(task.UniqueID).Size));
                        break;
                    case TaskType.Feedback:
                        sb.Append(string.Format("|| {0}", this.Repository.GetFeedBack(task.UniqueID).Status));
                        sb.AppendLine(string.Format("|| {0}", this.Repository.GetFeedBack(task.UniqueID).Rating.ToString()));
                        break;
                    default:
                        break;
                }

            }
            return sb.ToString().Trim();
        }
        private string ListByOrder()
        {
            StringBuilder sb = new StringBuilder();
            var tasks = this.Repository.Tasks.OrderBy(x=>x.Title).ToList();
            foreach (ITask task in tasks)
            {
                sb.Append(string.Format("-- {0}", task.UniqueID));
                sb.Append(string.Format(" ||{0}||", task.Tasktype));
                sb.Append(string.Format(" {0}", task.Title));
                sb.Append(string.Format("|| {0}", task.Description));
                switch (task.Tasktype)
                {
                    case TaskType.Bug:
                        sb.Append(string.Format("|| {0}", this.Repository.GetBug(task.UniqueID).Status));
                        sb.Append(string.Format("|| {0}", this.Repository.GetBug(task.UniqueID).Priority));
                        sb.AppendLine(string.Format("|| {0}", this.Repository.GetBug(task.UniqueID).Severity));
                        break;
                    case TaskType.Story:
                        sb.Append(string.Format("|| {0}", this.Repository.GetStory(task.UniqueID).Status));
                        sb.Append(string.Format("|| {0}", this.Repository.GetStory(task.UniqueID).Priority));
                        sb.AppendLine(string.Format("|| {0}", this.Repository.GetStory(task.UniqueID).Size));
                        break;
                    case TaskType.Feedback:
                        sb.Append(string.Format("|| {0}", this.Repository.GetFeedBack(task.UniqueID).Status));
                        sb.AppendLine(string.Format("|| {0}", this.Repository.GetFeedBack(task.UniqueID).Rating.ToString()));
                        break;
                    default:
                        break;
                }

            }
            return sb.ToString().Trim();
        }
        private string ListByFilter(string filter)
        {
            StringBuilder sb = new StringBuilder();
            var tasks = this.Repository.Tasks.Where(x=>x.Title.Contains(filter.ToLower()));
            foreach (ITask task in tasks)
            {
                sb.Append(string.Format("-- {0}", task.UniqueID));
                sb.Append(string.Format(" ||{0}||", task.Tasktype));
                sb.Append(string.Format(" {0}", task.Title));
                sb.Append(string.Format("|| {0}", task.Description));
                switch (task.Tasktype)
                {
                    case TaskType.Bug:
                        sb.Append(string.Format("|| {0}", this.Repository.GetBug(task.UniqueID).Status));
                        sb.Append(string.Format("|| {0}", this.Repository.GetBug(task.UniqueID).Priority));
                        sb.AppendLine(string.Format("|| {0}", this.Repository.GetBug(task.UniqueID).Severity));
                        break;
                    case TaskType.Story:
                        sb.Append(string.Format("|| {0}", this.Repository.GetStory(task.UniqueID).Status));
                        sb.Append(string.Format("|| {0}", this.Repository.GetStory(task.UniqueID).Priority));
                        sb.AppendLine(string.Format("|| {0}", this.Repository.GetStory(task.UniqueID).Size));
                        break;
                    case TaskType.Feedback:
                        sb.Append(string.Format("|| {0}", this.Repository.GetFeedBack(task.UniqueID).Status));
                        sb.AppendLine(string.Format("|| {0}", this.Repository.GetFeedBack(task.UniqueID).Rating.ToString()));
                        break;
                    default:
                        break;
                }

            }
            return sb.ToString().Trim();
        }
    }
}
