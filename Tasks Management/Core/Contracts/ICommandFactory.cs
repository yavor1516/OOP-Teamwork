using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tasks_Management.Commands.Contracts;

namespace Tasks_Management.Core.Contracts
{
    public interface ICommandFactory
    {
        Commands.Contracts.ICommand Create(string commandLine);
    }
}
