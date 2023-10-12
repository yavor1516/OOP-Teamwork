using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks_Management.Models.Contracts
{
    public interface ITeam : IHasName
    {
        IList<IMember> Members { get; }
        IList<IBoard> Boards { get; }
    }
}
