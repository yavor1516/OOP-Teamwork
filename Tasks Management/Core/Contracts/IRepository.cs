using Tasks_Management.Commands.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Core.Contracts
{
    public interface IRepository
    {
        IList<IMember> Members { get; }
        
        IList<ITeam> Teams { get; }

        IList<IBoard> Boards { get; }
        IList<ITask> Tasks { get; }

        IList<IBug> Bugs { get; }
        IList<IStory> Stories { get; }

        IList<IFeedBack> FeedBacks { get; }

        public IMember CreateMember(string firstName, string lastName);

        public ITeam CreateTeam(string name);

        public IBoard CreateBoard(string name);

        void AddMember (IMember member);
        void AddTeam (ITeam team);

        void AddBoard (IBoard board);
        void AddTask(ITask task);

        void AddBug(IBug bug);
        void AddStory (IStory story);
        void AddFeedBack(IFeedBack feedBack);

        public bool MemberExist (string firstName, string lastName);
        public bool TeamExist (string name);

        public bool BoardExist (string name);

        IMember GetMember (string firstName, string lastName);

        ITeam GetTeam (string name);

        IBoard GetBoard (string name);

        ITask GetTask(string taskName);
        Bug GetBug (string bugName);
        IStory GetStory (string storyName);
        IFeedBack GetFeedBack (string feedBackName);

        public IBug CreateBug (int id, string Title, string Description, Status Status, Priority priority,Severity severity,IActivityHistory history);
        public IStory CreateStory (int id, string Title, string Description, Status Status,Priority priority,Size size,IActivityHistory history);
        public IFeedBack CreateFeedBack (int id, string Title, string Description, Status Status , int rating, IActivityHistory history);

        public IComment CreateComment(string content, string task);
    }
}
