﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;

namespace Tasks_Management.Models.Contracts
{
    public interface ITask
    {
        int UniqueID { get;}
        string Description { get; }

        string Title { get; set; }

        Status Status { get; }

        IList<IComment> Comments { get; }

        void AddComment(IComment comment);

        IList<IActiveHistory> History { get; }
    }
}
