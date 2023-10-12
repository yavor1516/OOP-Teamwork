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
        public string Author => throw new NotImplementedException();

        public string CommentText => throw new NotImplementedException();
    }
}
