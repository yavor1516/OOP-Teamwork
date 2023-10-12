using OOP_Teamwork.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Teamwork.Models
{
    public class Task
    {
        public string Title { get; }
        public TaskType Type { get; }

        public Task(string title, TaskType type)
        {
            Title = title;
            Type = type;
        }
    }
}
