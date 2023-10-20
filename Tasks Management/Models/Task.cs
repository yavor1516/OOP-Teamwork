using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public abstract class Task : ITask
    {
        public int UniqueID { get; }

        private static readonly int NameMinLength = 10;
        private static readonly int NameMaxLength = 50;
        private static readonly string InvalidNameError = "Name must be between 10 and 50 characters";
        private static readonly int DescriptionMinLength = 10;
        private static readonly int DescriptionMaxLength = 500;
        private static readonly string InvalidDescriptionError = "Description must be between 10 and 500 characters";
        private static readonly string CommentsHeader = "--COMMENTS--";
        private static readonly string NoCommentsHeader = "--NO COMMENTS--";

        private int id;
        private string title;
        private string description;
        private List<Comment> comments;

        public Task(int id, string title, string description, IActivityHistory history)
        {
            UniqueID = id;
            Title = title;
            Description = description;
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
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, InvalidNameError);
                    title = value;
                }
            }
        

        public string Description
        {
            get => description;
            set
            {
            Validator.ValidateIntRange(value.Length, DescriptionMinLength, DescriptionMaxLength, InvalidDescriptionError);
                    description = value;
                }
            }
        

        public IList<IComment> Comments => comments.Cast<IComment>().ToList();

        public IActivityHistory History { get; set; }


        public TaskType Tasktype { get; set; }

        public IMember Assignee { get; set; }

        public void AddComment(IComment comment)
        {
            if (comment != null)
            {
                comments.Add((Comment)comment);
            }
        }
    }
}