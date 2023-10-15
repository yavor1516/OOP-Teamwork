using System;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
   public abstract class Task : ITask
    {
        public int UniqueID => throw new NotImplementedException();

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


        public Task(int id, string Title,string Description , Status status)
        {
            this.Title = Title;
            this.Description = Description;
            this.Status = status;
           
            

        }
        public int Id
        {
            get => id;
            set => this.id = value;
        }
        public string Title
        {
            get => title;
            set
            {
                if (value.Length > NameMinLength && value.Length < NameMaxLength)
                {
                    this.title = value;
                }
            }
        }
        public string Description
        {
            get => description;
            set
            {
                if (value.Length >  DescriptionMinLength && value.Length < DescriptionMaxLength)
                { 
                    this.description = value;
                }
            }
        }


        public IList<IComment> Comments => throw new NotImplementedException();

        public IList<IActiveHistory> History => throw new NotImplementedException();

        public Status Status { get; }
    }
        

   
    
}
