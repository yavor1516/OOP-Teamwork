using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Teamwork.Models
{
    public class Member
    {
        public string Name { get; }
        public List<Task> Tasks { get; }
        public List<string> ActivityHistory { get; }

        public Member(string name)
        {
            Name = name;
            Tasks = new List<Task>();
            ActivityHistory = new List<string>();
        }
    }
}
