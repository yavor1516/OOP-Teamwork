using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Commands
{
    public class ShowAllTeamBoardsCommand : BaseCommand
    {
        public ShowAllTeamBoardsCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
            
        }
        protected override string ExecuteCommand()
        {
            return ShowAllTeamBoards();
        }
        private string ShowAllTeamBoards()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IBoard board in this.Repository.Boards)
            {
                sb.AppendLine(string.Format("{0}", board.Name.ToString()));

            }

            return sb.ToString().Trim();

        }


    }
}
