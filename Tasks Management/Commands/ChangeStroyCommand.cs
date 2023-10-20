using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Models;

namespace Tasks_Management.Commands
{
    internal class ChangeStroyCommand : BaseCommand
    {
        public ChangeStroyCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository)
        {
        }
     
     
      
        protected override string ExecuteCommand()
        {
            int id = int.Parse(this.CommandParameters[0]);
            string TargetParameter = CommandParameters[1];
            string ChangeValueOfTargetParameter = CommandParameters[2];

            switch (TargetParameter)
            {
                case "priority":
                    return this.ChangePriority(id, ParsePriorityType(ChangeValueOfTargetParameter));
                case "size":
                    return this.ChangeSize(id, ParseSizeType(ChangeValueOfTargetParameter));
                case "status":
                    return this.ChangeStatus(id, ParseStatusType(ChangeValueOfTargetParameter));

                default:
                    throw new NotImplementedException();
            }
            //Change the Priority/Size/Status of a story
        }
        private Priority ParsePriorityType(string priority)
        {
            Enum.TryParse(priority, true, out Priority result);
            return result;
        }
        private Size ParseSizeType(string size)
        {
            Enum.TryParse(size, true, out Size result);
            return result;
        }
        public StoryStatus ParseStatusType(string status)
        {
            Enum.TryParse(status, true, out StoryStatus result);
            return result;
        }
        private string ChangePriority(int id, Priority priority)
        {
            IStory story = this.Repository.GetStory(id);
            story.History.Messages.Add($"Story priority has been changed from {story.Priority} to {priority}");
            story.Priority = priority;
            return string.Format($"Story priority changed successfully!");
        }
        private string ChangeSize(int id, Size size)
        {
            IStory story = this.Repository.GetStory(id);
            story.History.Messages.Add($"Story size has been changed from {story.Size} to {size}");
            story.Size = size;
            return string.Format($"Story size changed successfully!");
        }
        private string ChangeStatus(int id, StoryStatus status)
        {
            IStory story = this.Repository.GetStory(id);
            story.History.Messages.Add($"Story status has been changed from {story.Status} to {status}");
            story.Status = status;
            return string.Format($"Bug status changed successfully!");

        }
    }
}
