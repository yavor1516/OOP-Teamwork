using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Team : ITeam
    {
        public const int TeamNameMinLength = 5;
        public const int TeamNameMaxLength = 15;
        public const string InvalidTeamNameError = "Team's name must be between 5 and 15 characters";
        public const string InvalidMemberNameError = "Member's name must be between 5 and 15 characters";
        public const int BoardMinLength = 5;
        public const int BoardMaxLength = 10;
        public const string InvalidBoardNameError = "Board's name must be between 5 and 10 characters";



        private string name;
        private List<IMember> members = new List<IMember>();
        private List<IBoard> boards = new List<IBoard>();
        private IActivityHistory history = new ActivityHistory();
        public Team(string name)
        {
            this.name = name;
            this.History = history;
            this.Boards = new List<IBoard>();
            this.Members = new List<IMember>();
        }

        public string Name
        {
            get => name;
            set
            {
                Validator.ValidateIntRange(value.Length, TeamNameMinLength, TeamNameMaxLength, InvalidTeamNameError);
                name = value;
            }
        }
        public IList<IMember> Members { get; set; }

        public IList<IBoard> Boards {get;set;}

        public IActivityHistory History {get;set;}
    }
}