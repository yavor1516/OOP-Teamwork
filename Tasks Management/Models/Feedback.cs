using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    internal class Feedback : Task,IFeedBack
    {
        public Feedback(string Title, string Description, Enum Status,
            IList<IComment> Comments, IList<IActiveHistory> History , int rating) 
            : base(Title, Description, Status, Comments, History)
        {

        }

        public int Rating => throw new NotImplementedException();
    }
}
