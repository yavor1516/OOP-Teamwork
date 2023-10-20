using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    internal class Feedback : Task,IFeedBack
    {
       
        public Feedback(int id,string Title, string Description, FeedbackStatus feedbackStatus, int rating , IActivityHistory history) 
            :base(id,Title,Description, history)
        {
            ActivityHistory = history;
            Validator.ValidateFeedbackStatus(feedbackStatus, "Invalid feedback status.");
            FeedbackStatus = feedbackStatus;
           //todo   Validator.ValidateRating(priority, "Invalid priority.");
            Rating = rating;            
        }
        public FeedbackStatus FeedbackStatus { get; set; }
        public int Rating { get; }
        public IActivityHistory ActivityHistory { get; set; }
        public IMember Assignee { get; }
    }
}
