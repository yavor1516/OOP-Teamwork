﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;

namespace Tasks_Management.Models
{
    public class Feedback : Task,IFeedBack
    {
       
        public Feedback(int id,string Title, string Description, Status Status, int rating , IActivityHistory history) 
            :base(id,Title,Description,Status,history)
        {

        }

        public int Rating { get; }
    }
}
