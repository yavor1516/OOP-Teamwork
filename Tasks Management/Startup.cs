using Tasks_Management.Core;
using Tasks_Management.Core.Contracts;

namespace Tasks_Management
{
    public class Startup
    {
       public static void Main()
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine engine = new Core.Engine(commandFactory);
            engine.Start();
        }
    }
}