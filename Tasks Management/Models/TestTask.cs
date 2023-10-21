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
                Validator.ValidateIntRange(value.Length, DescriptionMinLength, DescriptionMaxLength, InvalidDescriptionError);                                
                base.Description = value; }
        }
        public override string Title
        {
            get { return base.Title; }
            set
            {
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, InvalidNameError);                
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
