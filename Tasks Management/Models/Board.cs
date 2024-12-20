﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Board : IBoard
    {
        public const int NameMinLength = 5;
        public const int NameMaxLength = 10;
        public const string InvalidBoardError = "Board name must be between 5 and 10 characters";
        private string name;
        private IList<ITask> tasks;
        private IList<Contracts.IActivityHistory> history;

        public Board(string name)
        {
            Name = name;
            tasks = new List<ITask>();
            history = new List<Contracts.IActivityHistory>();
        }

        public IList<ITask> Tasks => tasks;

        public IList<Contracts.IActivityHistory> History => history;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, InvalidBoardError);
                name = value;
            }
        }


    }
}
