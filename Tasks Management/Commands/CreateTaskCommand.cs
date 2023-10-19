using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    public class CreateTaskCommand : BaseCommand
    {
        public CreateTaskCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
     
            int id = this.Repository.Tasks.Count;
            TaskType commandType = ParseTaskType(this.CommandParameters[0]);
            string Title = this.CommandParameters[1];
            string Description = this.CommandParameters[2];
            Status status = ParseStatusType(this.CommandParameters[3]);
            Priority priority = Priority.Low;
            
            switch (commandType)
            {
                case TaskType.Bug:
                    if (this.CommandParameters.Count != 6)
                    {
                        throw new InvalidUserInputException($"Invalid number of arguments. Expected: 6, Received: {this.CommandParameters.Count}");
                    }
                    priority = ParsePriorityType(this.CommandParameters[4]);
                    Severity severity = ParseSeverityType(this.CommandParameters[5]);
                    IActivityHistory history = new ActivityHistory();
                    Bug bug = new Bug(id, Title, Description, status, priority, severity,history);
                    bug.Tasktype = TaskType.Bug;
                    return this.CreateBug(bug);

                case TaskType.Story:
                    if (this.CommandParameters.Count != 6)
                    {
                        throw new InvalidUserInputException($"Invalid number of arguments. Expected: 6, Received: {this.CommandParameters.Count}");
                    }
                    priority = ParsePriorityType(this.CommandParameters[4]);
                    Size size = ParseSizeType(this.CommandParameters[5]);
                    history = new ActivityHistory();
                    Story story = new Story(id, Title, Description, status, priority, size, history);
                    story.Tasktype = TaskType.Story;
                    return this.CreateStory(story);
                     
                case TaskType.Feedback:
                    if (this.CommandParameters.Count != 5)
                    {
                        throw new InvalidUserInputException($"Invalid number of arguments. Expected: 5, Received: {this.CommandParameters.Count}");
                    }
                    int rating = int.Parse(this.CommandParameters[4]);
                    history = new ActivityHistory();
                    Feedback feedback = new Feedback(id, Title, Description, status, rating,history);
                    feedback.Tasktype = TaskType.Feedback;
                    return this.CreateFeedBack(feedback);
                 
                default:
                    throw new ArgumentException("Defoult");
            }
        }
        private TaskType ParseTaskType(string taskType)
        {

            Enum.TryParse(taskType, true, out TaskType result);
            return result;
        }
        private Priority ParsePriorityType(string priority)
        {

            Enum.TryParse(priority, true, out Priority result);
            return result;
        }
        private Severity ParseSeverityType(string severity)
        {

            Enum.TryParse(severity, true, out Severity result);
            return result;
        }
        public Status ParseStatusType(string status)
        {
            Enum.TryParse(status, true, out Status result);
            return result;
        }
        private Size ParseSizeType(string size)
        {
            Enum.TryParse(size, true, out Size result);
            return result;
        }


        private string CreateTask(ITask task)
        {
            this.Repository.AddTask(task);
            return string.Format($"Task {task.Title} created successfully!");
        }
        private string CreateBug(Bug bug)
        {
            bug.History.Messages.Add("Bug has been created");
            this.Repository.AddBug(bug);
            CreateTask(bug);
            return string.Format($"Bug with title: {bug.Title} created successfully!");
           
        }
        private string CreateStory (Story story)
        {
            story.History.Messages.Add("Story has been created");
            this.Repository.AddStory(story);
            CreateTask(story);
            return string.Format($"Story with title :{story.Title} created successfully!");
        }

        private string CreateFeedBack(Feedback feedback)
        {
            feedback.History.Messages.Add("Feedback has been created");
            this.Repository.AddFeedBack(feedback);
            CreateTask(feedback);
            return string.Format($"Feedback with title :{feedback.Title} created successfully!");
        }
    }
        
}
