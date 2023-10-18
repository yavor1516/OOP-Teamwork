using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public abstract class Task : ITask
    {
        public int UniqueID { get; }

        public const int NameMinLength = 10;
        public const int NameMaxLength = 50;
        public const string InvalidNameError = "Name must be between 10 and 50 characters";
        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 500;
        public const string InvalidDescriptionError = "Description must be between 10 and 500 characters";
        public const string CommentsHeader = "--COMMENTS--";
        public const string NoCommentsHeader = "--NO COMMENTS--";

        private int id;
        private string title;
        private string description;
        private List<Comment> comments;

        public Task(int id, string title, string description, Status status , IActivityHistory history)
        {
            UniqueID = id;
            Title = title;
            Description = description;
            Status = status;
            this.comments = comments != null ? comments.Cast<Comment>().ToList() : new List<Comment>();
            this.History = new ActivityHistory();
        }

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Title
        {
            get => title;
            set
            {
                if (value.Length >= NameMinLength && value.Length <= NameMaxLength)
                {
                    title = value;
                }
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (value.Length >= DescriptionMinLength && value.Length <= DescriptionMaxLength)
                {
                    description = value;
                }
            }
        }

        public IList<IComment> Comments => comments.Cast<IComment>().ToList();

        public IActivityHistory History { get; set; }

        public Status Status { get; }

        public TaskType Tasktype { get; set; }

        public void AddComment(IComment comment)
        {
            if (comment != null)
            {
                comments.Add((Comment)comment);
            }
        }
    }
}