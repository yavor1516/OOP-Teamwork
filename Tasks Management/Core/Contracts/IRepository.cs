﻿using Tasks_Management.Commands.Enums;
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

        public IMember CreateMember(string firstName, string lastName);

        public ITeam CreateTeam(string name);

        public IBoard CreateBoard(string name);

        void AddMember (IMember member);
        void AddTeam (ITeam team);

        void AddBoard (IBoard board);

        public bool MemberExist (string firstName, string lastName);
        public bool TeamExist (string name);

        public bool BoardExist (string name);

        IMember GetMember (string firstName, string lastName);

        ITeam GetTeam (string name);

        IBoard GetBoard (string name);

        ITask GetTask(string taskName);

        public IBug CreateBug (int id, string Title, string Description, Status Status, IList<IComment> Comments, IList<IActiveHistory> History,IList<string> steps, Priority priority,Severity severity, Status status,IMember assignee);
        public IStory CreateStory (int id, string Title, string Description, Status Status, IList<IComment> Comments, IList<IActiveHistory> History,Priority priority,Size size,IMember assignee);
        public IFeedBack CreateFeedBack (int id, string Title, string Description, Status Status, IList<IComment> Comments, IList<IActiveHistory> History , int rating);

        public IComment CreateComment(string content, string task);
    }
}
