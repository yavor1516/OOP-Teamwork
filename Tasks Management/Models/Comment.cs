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

        public Comment(string content, string author)
        {
            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content), "Comment text cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(author))
            {
                throw new ArgumentNullException("Author name cannot be null or empty.", nameof(author));
            }

            Author = author;
            CommentText = content;
        }

        public string Author { get; }

        public string CommentText { get; }

    }
}
