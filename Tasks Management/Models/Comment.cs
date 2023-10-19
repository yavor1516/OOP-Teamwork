using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Comment : IComment
    {

        public Comment(string content, string task)
        {
            
        }
        public string Author => throw new NotImplementedException();

        public string CommentText => throw new NotImplementedException();
    }
}
