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
            Priority priority = Priority.Low;
            
            switch (commandType)
            {
                case TaskType.Bug:
                    if (this.CommandParameters.Count != 6)
                    {
                        throw new InvalidUserInputException($"Invalid number of arguments. Usage:CreateTask Bug [title] [description] [status] [priority] [severity]");
                    }
                    BugStatus status = ParseBugStatusType(this.CommandParameters[3]);
                    priority = ParsePriorityType(this.CommandParameters[4]);
                    Severity severity = ParseSeverityType(this.CommandParameters[5]);
                    IActivityHistory history = new ActivityHistory();
                    Bug bug = new Bug(id, Title, Description, status, priority, severity,history);
                    bug.Tasktype = TaskType.Bug;
                    return this.CreateBug(bug);

                case TaskType.Story:
                    if (this.CommandParameters.Count != 6)
                    {
                        throw new InvalidUserInputException($"Invalid number of arguments. Usage:CreateTask Story [title] [description] [status] [priority] [size]");
                    }
                    StoryStatus storyStatus = ParseStoryStatusType(this.CommandParameters[3]);
                    priority = ParsePriorityType(this.CommandParameters[4]);
                    Size size = ParseSizeType(this.CommandParameters[5]);
                    history = new ActivityHistory();
                    Story story = new Story(id, Title, Description, storyStatus, priority, size, history);
                    story.Tasktype = TaskType.Story;
                    return this.CreateStory(story);
                     
                case TaskType.Feedback:
                    if (this.CommandParameters.Count != 5)
                    {
                        throw new InvalidUserInputException($"Invalid number of arguments. Usage:CreateTask Feedback [title] [description] [status] [rating]");
                    }
                    FeedbackStatus feedbackStatus = ParseFeedbackStatusType(this.CommandParameters[3]);
                    int rating = int.Parse(this.CommandParameters[4]);
                    history = new ActivityHistory();
                    Feedback feedback = new Feedback(id, Title, Description, feedbackStatus, rating,history);
                    feedback.Tasktype = TaskType.Feedback;
                    return this.CreateFeedBack(feedback);
                 
                default:
                    throw new ArgumentException("Default");
            }
        }
        private TaskType ParseTaskType(string taskType)
        {

            Enum.TryParse(taskType, true, out TaskType result);
            return result;
        }
        private Priority ParsePriorityType(string priority)
        {

            if (Enum.TryParse(priority, true, out Priority result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Unknown Priority {priority}. Options: {string.Join(", ", Enum.GetNames(typeof(Priority)).ToList())}");
        }

        private Severity ParseSeverityType(string severity)
        {
            if (Enum.TryParse(severity, true, out Severity result))
            { 
                return result;
            }
            throw new InvalidUserInputException($"Unknown Bug Severity {severity}. Options: {string.Join(", ", Enum.GetNames(typeof(Severity)).ToList())}");
        }
        public StoryStatus ParseStoryStatusType(string status)
        {
            if(Enum.TryParse(status, true, out StoryStatus result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Unknown Story Status {status}. Options: {string.Join(", ", Enum.GetNames(typeof(StoryStatus)).ToList())}");
        }
        public BugStatus ParseBugStatusType(string status)
        {
            if(Enum.TryParse(status, true, out BugStatus result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Unknown Bug Status {status}. Options: {string.Join(", ", Enum.GetNames(typeof(BugStatus)).ToList())}");
        }
        public FeedbackStatus ParseFeedbackStatusType(string status)
        {
            if(Enum.TryParse(status, true, out FeedbackStatus result))
            {
                return result;
            }
            throw new InvalidUserInputException($"Unknown Feedback Status: {status}. Options: {string.Join(", ", Enum.GetNames(typeof(FeedbackStatus)).ToList())}");
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
