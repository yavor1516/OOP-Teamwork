using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class TestTask : Task
    {
        public TestTask(int id, string title, string description, IActivityHistory history)
            : base(id, title, description, history)
        {
        }
        public override string Description
        {
            get { return base.Description; }
            set 
            {
                if (value.Length < DescriptionMinLength || value.Length > DescriptionMaxLength)
                {
                    throw new InvalidUserInputException("Title length is invalid");
                }
                base.Description = value; }
        }
        public override string Title
        {
            get { return base.Title; }
            set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new InvalidUserInputException("Title length is invalid");
                }
                base.Title = value;
            }
        }
        public override int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
        public override IList<IComment> Comments
        {
            get { return base.Comments; }
        }

        public override TaskType Tasktype
        {
            get { return base.Tasktype; }
            set { base.Tasktype = value; }
        }

        public override IMember Assignee
        {
            get { return base.Assignee; }
            set { base.Assignee = value; }
        }
        public override void AddComment(IComment comment)
        {
            if (comment != null)
            {
                base.AddComment(comment);
            }
        }
    }
}
