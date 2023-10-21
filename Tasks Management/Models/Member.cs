using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Member : IMember
    {
        private string firstName;
        private string lastName;
        private IList<ITask> tasks;
        private ActivityHistory history;

        public Member(string firstName, string lastName)
        {
            //ToDO
            if (IsNameValid(firstName) && IsLastNameValid(lastName))
            {
                this.firstName = firstName;
                this.lastName = lastName;
                tasks = new List<ITask>();
                history = new ActivityHistory();
            }
            else
            {
                throw new ArgumentException("Invalid member name.");
            }
        
        }

        public IList<ITask> Tasks => tasks;

        public Contracts.IActivityHistory History => history;

        public string FirstName => firstName;

        public string LastName => lastName;


        public bool IsNameValid(string firstName)
        {
            return !string.IsNullOrEmpty(firstName) && firstName.Length >= 5 && firstName.Length <= 15;
        } 
        public bool IsLastNameValid(string lastName)
        {
            return !string.IsNullOrEmpty(lastName) && lastName.Length >= 5 && lastName.Length <= 15;
        } 
    }
}
