using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    internal class ListCommand : BaseCommand
    {
        public ListCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            string[] inputParts = this.CommandParameters.ToArray();
            string input = inputParts[0].ToLower();

            switch (input)
            {
                case "bug":
                    if (inputParts[1] == "status".ToLower())
                    {
                        return this.ListBugByStatus();
                    }
                    if (inputParts[1] == "assignee".ToLower())
                    {
                        return this.ListBugByAssignee();
                    }
                    if (inputParts[1] == "both".ToLower())
                    {
                        return this.ListBugBySatusAndAssignee();
                    }
                    if (inputParts[1] == "sortby".ToLower())
                    {
                        return this.BugSortBy(inputParts[2]);
                    }

                    break;
                 
                case "story":
                    if (inputParts[1] == "status".ToLower())
                    {
                        return this.ListStoryByStatus();
                    }
                    if (inputParts[1] == "assignee".ToLower())
                    {
                        return this.ListStoryByAssignee();
                    }
                    if (inputParts[1] == "both".ToLower())
                    {
                        return this.ListStoryBySatusAndAssignee();
                    }
                    if (inputParts[1] == "sortby".ToLower())
                    {
                        return this.StorytSortBy(inputParts[2]);
                    }
                    break;
                case "feedback":
                    if (inputParts[1] == "status".ToLower())
                    {
                        return this.ListFeedbackByStatus();
                    }
                    if (inputParts[1] == "assignee".ToLower())
                    {
                        return this.ListFeedbackByAssignee();
                    }
                    if (inputParts[1] == "both".ToLower())
                    {
                        return this.ListFeedbackBySatusAndAssignee();
                    }
                    if (inputParts[1] == "sortby".ToLower())
                    {
                        return this.FeedBacktSortBy(inputParts[2]);
                    }
                    break;
                default:
                    break;
            }
          throw new NotImplementedException();
        }
        private string ListBugByStatus()
        {

            var statusesOfBugs = this.Repository.Tasks
            .Where(x => x is Bug)
            .Cast<Bug>()
            .OrderBy(x => x.Status)
            .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in statusesOfBugs)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.AppendLine(string.Format("|| {0}", item.Status));
            }

            return sb.ToString().Trim();

        }
        private string ListBugByAssignee()
        {
            var statusesOfBugs = this.Repository.Tasks
        .Where(x => x is Bug && x.Assignee != null)
        .Cast<Bug>()
        .OrderBy(x => x.Assignee.FirstName).ThenBy(x=>x.Assignee.LastName)
        .ToList();
            
            StringBuilder sb = new StringBuilder();
            foreach (var item in statusesOfBugs)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.Append(string.Format("|| {0}", item.Assignee?.FirstName));
                sb.AppendLine(string.Format(" {0}", item.Assignee?.LastName));

            }

            return sb.ToString().Trim();
        }
        private string ListBugBySatusAndAssignee()
        {
            var statusesOfBugs = this.Repository.Tasks
        .Where(x => x is Bug)
        .Cast<Bug>()
        .OrderBy(x=>x.Status)
        .ThenBy(x => x.Assignee?.FirstName)
        .ThenBy(x => x.Assignee?.LastName)
        .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in statusesOfBugs)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.Append(string.Format("|| {0}", item.Status));
                sb.Append(string.Format("|| {0}", item.Assignee?.FirstName));
                sb.AppendLine(string.Format(" {0}", item.Assignee?.LastName));

            }

            return sb.ToString().Trim();
        }
        private string ListStoryByStatus()
        {

            var statusesOfBugs = this.Repository.Tasks
            .Where(x => x is Story)
            .Cast<Story>()
            .OrderBy(x => x.Status)
            .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in statusesOfBugs)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.AppendLine(string.Format("|| {0}", item.Status));
            }

            return sb.ToString().Trim();

        }
        private string ListStoryByAssignee()
        {
            var statusesOfBugs = this.Repository.Tasks
        .Where(x => x is Story && x.Assignee!=null)
       .Cast<Story>()
        .OrderBy(x => x.Assignee?.FirstName)
        .ThenBy(x => x.Assignee?.LastName)
        .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in statusesOfBugs)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.Append(string.Format("|| {0}", item.Assignee?.FirstName));
                sb.AppendLine(string.Format(" {0}", item.Assignee?.LastName));

            }

            return sb.ToString().Trim();
        }
        private string ListStoryBySatusAndAssignee()
        {
            var statusesOfBugs = this.Repository.Tasks
            .Where(x => x is Story)
            .Cast<Story>()
            .OrderBy(x => x.Status)
            .ThenBy(x => x.Assignee?.FirstName)
            .ThenBy(x => x.Assignee?.LastName)
            .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in statusesOfBugs)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.Append(string.Format("|| {0}", item.Status));
                sb.Append(string.Format("|| {0}", item.Assignee?.FirstName));
                sb.AppendLine(string.Format(" {0}", item.Assignee?.LastName));

            }

            return sb.ToString().Trim();
        }
        private string ListFeedbackByStatus()
        {

            var statusesOfBugs = this.Repository.Tasks
            .Where(x => x is Feedback)
            .Cast<Feedback>()
            .OrderBy(x => x.Status)
            .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var item in statusesOfBugs)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.AppendLine(string.Format("|| {0}", item.Status));
            }

            return sb.ToString().Trim();

        }
        private string ListFeedbackByAssignee()
        {
            var statusesOfBugs = this.Repository.Tasks
        .Where(x => x is Feedback && x.Assignee != null)
       .Cast<Feedback>()
        .OrderBy(x => x.Assignee?.FirstName)
        .ThenBy(x => x.Assignee?.LastName)
        .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in statusesOfBugs)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.Append(string.Format("|| {0}", item.Assignee?.FirstName));
                sb.AppendLine(string.Format(" {0}", item.Assignee?.LastName));

            }

            return sb.ToString().Trim();
        }
        private string ListFeedbackBySatusAndAssignee()
        {
            var statusesOfBugs = this.Repository.Tasks
            .Where(x => x is Feedback)
            .Cast<Feedback>()
            .OrderBy(x => x.Status)
            .ThenBy(x => x.Assignee?.FirstName)
            .ThenBy(x => x.Assignee?.LastName)
            .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var item in statusesOfBugs)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.Append(string.Format("|| {0}", item.Status));
                sb.Append(string.Format("|| {0}", item.Assignee?.FirstName));
                sb.AppendLine(string.Format(" {0}", item.Assignee?.LastName));

            }

            return sb.ToString().Trim();
        }

        private string BugSortBy(string sortBY)
        {
            var bugs = this.Repository.Tasks
          .Where(x => x is Bug)
          .Cast<Bug>().ToList();
            StringBuilder sb = new StringBuilder();
            switch (sortBY.ToLower())
            {
                case "title":
                    bugs = bugs.OrderBy(x=>x.Title).ToList();
                    break;
                case "status":
                   bugs = bugs.OrderBy(x => x.Status).ToList();
                    break;
                case "priority":
                    bugs = bugs.OrderBy(x => x.Priority).ToList();
                    break;
                case "severity":
                    bugs = bugs.OrderBy(x => x.Severity).ToList();
                    break;
                default:
                    break;
            }
            foreach (var item in bugs)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.Append(string.Format("|| {0}", item.Status));
                sb.Append(string.Format("|| {0}", item.Priority));
                sb.AppendLine(string.Format("|| {0}", item.Severity));

            }

            return sb.ToString().Trim();
        }
        private string StorytSortBy(string sortBY)
        {
            var stories = this.Repository.Tasks
          .Where(x => x is Story)
          .Cast<Story>().ToList();
            StringBuilder sb = new StringBuilder();
            switch (sortBY.ToLower())
            {
                case "title":
                    stories = stories.OrderBy(x => x.Title).ToList();
                    break;
                case "status":
                    stories = stories.OrderBy(x => x.Status).ToList();
                    break;
                case "priority":
                    stories = stories.OrderBy(x => x.Priority).ToList();
                    break;
                case "size":
                    stories = stories.OrderBy(x => x.Size).ToList();
                    break;
                default:
                    break;
            }
            foreach (var item in stories)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.Append(string.Format("|| {0}", item.Status));
                sb.Append(string.Format("|| {0}", item.Priority));
                sb.AppendLine(string.Format("|| {0}", item.Size));

            }

            return sb.ToString().Trim();
        }
        private string FeedBacktSortBy(string sortBY)
        {
            var stories = this.Repository.Tasks
          .Where(x => x is Feedback)
          .Cast<Feedback>().ToList();
            StringBuilder sb = new StringBuilder();
            switch (sortBY.ToLower())
            {
                case "title":
                    stories = stories.OrderBy(x => x.Title).ToList();
                    break;
                case "status":
                    stories = stories.OrderBy(x => x.Status).ToList();
                    break;
                case "rating":
                    stories = stories.OrderBy(x => x.Rating).ToList();
                    break;
                default:
                    break;
            }
            foreach (var item in stories)
            {
                sb.Append(string.Format("-- {0}", item.UniqueID));
                sb.Append(string.Format("|| {0}", item.Title));
                sb.Append(string.Format("|| {0}", item.Description));
                sb.Append(string.Format("|| {0}", item.Status));
                sb.AppendLine(string.Format("|| {0}", item.Rating));

            }

            return sb.ToString().Trim();
        }
    }
    }

