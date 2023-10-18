using System;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Commands.Enums;
using System.Threading.Tasks;

namespace Tasks_Management.Core
{
    public class Repository : IRepository
    {
        private readonly IList<IMember> members = new List<IMember>();
        private readonly IList<ITeam> teams = new List<ITeam>();
        private readonly IList<IBoard> boards = new List<IBoard>();
        private readonly IList<ITask> tasks = new List<ITask>();

        private readonly IList<IBug> bugs = new List<IBug>();
        private readonly IList<IStory> stories = new List<IStory>();
        private readonly IList<IFeedBack> feedbacks = new List<IFeedBack>();
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

        public IBug CreateBug(int id,string Title, string Description, Status Status,Priority priority,Severity severity,IActivityHistory history)
        {
            return new Bug(id,Title, Description, Status,priority,severity, history);
        }

        public IStory CreateStory(int id,string Title, string Description, Status Status,Priority priority,Size size , IActivityHistory history)
        {
            return new Story(id,Title, Description, Status,priority,size, history);
        }

        public IFeedBack CreateFeedBack(int id, string Title, string Description, Status Status, int Rating,IActivityHistory history)
        {
            return new Feedback(id, Title, Description,Status, Rating, history);
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
        public void AddTask(ITask task )
        {
            if (!tasks.Contains(task))
            {
                tasks.Add(task);
            }
        }
        public void AddBug(IBug bug)
        {
            if (!bugs.Contains(bug))
            {
                bugs.Add(bug);

            }
        }

        public void AddStory(IStory story)
        {
            if (!stories.Contains(story))
            {
                stories.Add(story);
            }
        }

        public void AddFeedBack(IFeedBack feedBack)
        {
            if (!feedbacks.Contains(feedBack))
            {
                feedbacks.Add(feedBack);
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

        public IList<ITask> Tasks
        {
            get
            {
                var tasksCopy = new List<ITask>(this.tasks);
                return tasksCopy;
            }
        }

        public IList<IBug> Bugs
        {
            get
            {
                var bugsCopy = new List<IBug>(this.bugs);
                return bugsCopy;
            }
        }
        public IList<IStory> Stories
        {
            get
            {
                var storyCopy = new List<IStory>(this.stories);
                return storyCopy;
            }
        }

        public IList<IFeedBack> FeedBacks
        {
            get
            {
                var feedBackCopy = new List<IFeedBack>(this.feedbacks);
                return feedBackCopy;
            }
        }

        public Models.Contracts.IActivityHistory GetMemberActivityHistory(IMember member)
        {
            return member.History;
        }
        public ITask GetTask(string taskName)
        {
            foreach (ITask task in tasks) // Assuming 'tasks' is your list of tasks
            {
                if (task.Title.Equals(taskName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return task;
                }
            }
            throw new ArgumentException($"There is no task with the name: {taskName}");
        }

    
    }
}
