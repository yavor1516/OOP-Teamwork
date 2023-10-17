using System;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Commands.Enums;

namespace Tasks_Management.Core
{
    public class Repository : IRepository
    {
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<ITeam> teams = new List<ITeam>();
        private readonly IList<IBoard> boards = new List<IBoard>();
        public void AddMember(IMember member)
        {
            if (!members.Contains(member))
            {
                members.Add(member);
            }
        }

        public void AddTeam(ITeam team)
        {
            if (!teams.Contains(team))
            {
                teams.Add(team);
            }
        }

      

        public IMember CreateMember(string firstName, string lastName)
        {
          return new Member(firstName,lastName);
        }

 

        public ITeam CreateTeam(string name)
        {
            return new Team(name);
        }

        public IMember GetMember(string firstName, string lastName)
        {
           foreach(IMember member in this.members)
            {
                if(member.FirstName.Equals(firstName,StringComparison.InvariantCultureIgnoreCase) && member.LastName.Equals(lastName, StringComparison.InvariantCultureIgnoreCase)) 
                {
                    return member;
                }
            }
            throw new ArgumentException($"There is no member with name: {firstName} {lastName}!");
        }

        public ITeam GetTeam(string name)
        {
            foreach (ITeam team in this.teams)
            {
                if (team.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)) 
                {
                    return team;
                }
            }
            throw new ArgumentException($"There is no team with name: {name}!");
        }

        public bool MemberExist(string firstName, string lastName)
        {
            bool result = false;
            foreach (IMember member in this.members)
            {

                if (member.FirstName.Equals(firstName, StringComparison.InvariantCultureIgnoreCase) && member.LastName.Equals(lastName, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                }
            }
            return result;
        }

        public IList<IMember> Members
        {
            get
            {
                var memberCopy = new List<IMember>(this.members);
                return memberCopy;
            }
        }

        public bool TeamExist(string name)
        {
            bool result = false;
            foreach (ITeam team in this.teams)
            {
                if (team.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public IBug CreateBug(int id,string Title, string Description, Status Status, IList<IComment> Comments, IList<IActiveHistory> History,IList<string> steps,Priority priority,Severity severity,Status status,IMember assignee)
        {
            return new Bug(id,Title, Description, Status, Comments, History,steps,priority,severity,status,assignee);
        }

        public IStory CreateStory(int id,string Title, string Description, Status Status, IList<IComment> Comments, IList<IActiveHistory> History,Priority priority,Size size,IMember assignee)
        {
            return new Story(id,Title, Description, Status, Comments, History,priority,size,assignee);
        }

        public IFeedBack CreateFeedBack(int id, string Title, string Description, Status Status, IList<IComment> Comments, IList<IActiveHistory> History , int Rating)
        {
            return new Feedback(id, Title, Description,Status, Comments, History, Rating);
        }

        public IBoard CreateBoard(string name)
        {
            return new Board(name);
        }

        public void AddBoard(IBoard board)
        {
            if (!boards.Contains(board))
            {
                boards.Add(board);
            }
        }

        public bool BoardExist(string name)
        {
            bool result = false;
            foreach (IBoard board in this.boards)
            {
                if (board.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public IBoard GetBoard(string name)
        {

            foreach (IBoard board in this.boards)
            {
                if (board.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return board;
                }
            }
            throw new ArgumentException($"There is no board with name: {name}!");
        }

        public IComment CreateComment(string content, string task)
        {
            return new Comment(content, task);
        }

        public IList<ITeam> Teams
        {
            get
            {
                var teamsCopy = new List<ITeam>(this.teams);
                return teamsCopy;
            }

        }

        public IList<IBoard> Boards
        {
            get
            {
                var boardsCopy = new List<IBoard>(this.boards);
                return boardsCopy;
            }
        }
        public IList<IActiveHistory> GetMemberActivityHistory(IMember member)
        {
            return member.History;
        }
    }
}
