using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    internal class Comment : IComment
    {

        public Comment(string content, string author)
        {
            this.Author = author;
            this.CommentText = content;
        }
        public string Author { get; }

        public string CommentText { get; }
    }
}
