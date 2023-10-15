using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    internal class Team : ITeam
    {
        public const int TeamNameMinLength = 5;
        public const int TeamNameMaxLength = 15;
        public const string InvalidTeamNameError = "Team's name must be between 5 and 15 characters";
        public const string InvalidMemberNameError = "Member's name must be between 5 and 15 characters";
        public const int BoardMinLength = 5;
        public const int BoardMaxLength = 10;
        public const string InvalidBoardNameError = "Board's name must be between 5 and 10 characters";



        private string name;
        private string memberName;
        private string board;

        public Team(string name, string memberName, string board)
        {
            this.name = name;
            this.memberName = memberName;
            this.board = board;

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


        public string MemberName
        {
            get => memberName;
            set
            {
                Validator.ValidateIntRange(value.Length, TeamNameMinLength, TeamNameMaxLength, InvalidMemberNameError);
                memberName = value;

            }


        }

        public string Board
        {
            get => board;

            set
            {
                Validator.ValidateIntRange(value.Length, BoardMinLength, BoardMaxLength, InvalidBoardNameError);
                board = value;

            }


        }

        public IList<IMember> Members => throw new NotImplementedException();

        public IList<IBoard> Boards => throw new NotImplementedException();


    }
}