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

        public Team(string Name)
        {
            
        }
        public IList<IMember> Members => throw new NotImplementedException();

        public IList<IBoard> Boards => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();
    }
}
