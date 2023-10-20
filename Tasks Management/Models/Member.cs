using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    internal class Member : IMember
    {
        private static readonly int NAME_MIN_LENGTH = 5;
        private static readonly int NAME_MAX_LENGTH = 15;
        private string firstName;
        private string lastName;
        private IList<ITask> tasks;
        private ActivityHistory history;

        public Member(string firstName, string lastName)
        {
            tasks = new List<ITask>();
            history = new ActivityHistory();
            FirstName = firstName;
            LastName = lastName;
        }

        public IList<ITask> Tasks => tasks;

        public Contracts.IActivityHistory History => history;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                Validator.ValidateString(value, "First name is invalid.");
                Validator.ValidateIntRange(value.Length, NAME_MIN_LENGTH, NAME_MAX_LENGTH,
                    $"First name length is not valid. Acceptable length between {NAME_MIN_LENGTH} and {NAME_MAX_LENGTH} characters.");
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                Validator.ValidateString(value, "Last name is invalid.");
                Validator.ValidateIntRange(value.Length, NAME_MIN_LENGTH, NAME_MAX_LENGTH,
                    $"Last name length is not valid. Acceptable length between {NAME_MIN_LENGTH} and {NAME_MAX_LENGTH} characters.");
                lastName = value;
            }
        }
    }
}
