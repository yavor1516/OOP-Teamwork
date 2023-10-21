using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Story : Task,IStory
    {
        public Story(int id, string Title, string Description, StoryStatus status, Priority priority, Size size, IActivityHistory history)
            : base(id, Title, Description, history)
        {
            
            Validator.ValidateStoryStatus(Status, "Invalid story status.");
            this.Status = Status;
            Validator.ValidatePriority(priority, "Invalid priority.");
            Priority = priority;
            Validator.ValidateSize(size, "Invalid size.");
            Size = size;
        }

        public Priority Priority { get; set; }

        public Size Size {get;set;}

        public IMember Assignee { get; set;}

        public StoryStatus Status { get; set; }
    }
}
