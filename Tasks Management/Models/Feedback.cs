using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Feedback : Task, IFeedBack
    {
       
        public Feedback(int id,string Title, string Description, FeedbackStatus status, int rating , IActivityHistory history) 
            :base(id,Title,Description,history)
        {
            this.Rating = rating;
            Validator.ValidateFeedbackStatus(status, "Invalid feedback status.");
            this.Status = status;
        }

        public int Rating { get; set; }

        public FeedbackStatus Status { get; set; }
    }
}
