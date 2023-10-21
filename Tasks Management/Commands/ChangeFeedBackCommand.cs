using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    public class ChangeFeedBackCommand : BaseCommand
    {
        public ChangeFeedBackCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count != 3)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Usage: ChangeFeedBack [TaskID] [Rating/Status] [NewValue]");
            }
            int id= int.Parse(this.CommandParameters[0]);
            string TargetParameter = CommandParameters[1];
            string ChangeValueOfTargetParameter = CommandParameters[2];

            switch (TargetParameter)
            {
                case "rating":
                    return this.ChangeRating(id, int.Parse(ChangeValueOfTargetParameter));
                case "status":
                    return this.ChangeStatus(id, ParseStatusType(ChangeValueOfTargetParameter));

                default:
                    throw new NotImplementedException();
            }
        }
        public FeedbackStatus ParseStatusType(string status)
        {
            Enum.TryParse(status, true, out FeedbackStatus result);
            return result;
        }
        private string ChangeStatus(int id, FeedbackStatus status)
        {
            IFeedBack feedback = this.Repository.GetFeedBack(id);
            feedback.History.Messages.Add($"Feedback status has been changed from {feedback.Status} to {status}");
            feedback.Status = status;
            return string.Format($"Feedback status changed successfully!");
            
        }
        private string ChangeRating(int id, int rating)
        {
            IFeedBack feedback = this.Repository.GetFeedBack(id);
            feedback.History.Messages.Add($"Feedback status has been changed from {feedback.Rating} to {rating}");
            feedback.Rating = rating;
            return string.Format($"Feedback status changed successfully!");

        }
    }
}
