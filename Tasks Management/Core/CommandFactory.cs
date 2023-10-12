using System;
using System.Text.RegularExpressions;
using Tasks_Management.Commands.Contracts;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Core.Contracts;


namespace Tasks_Management.Core
{
    public class CommandFactory : ICommandFactory
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }
        public ICommand Create(string commandLine)
        {
          CommandType commandType = ParseCommandType(commandLine);
          List<string> commandParameters = this.ExtractCommandParameters(commandLine);

            switch (commandType)
            {
                case CommandType.RegisterUser:
                    throw new NotImplementedException();
                case CommandType.ShowUsers:
                    throw new NotImplementedException();
                case CommandType.ShowUserActivity:
                    throw new NotImplementedException();
                case CommandType.CreateNewItem: 
                    throw new NotImplementedException();
                case CommandType.ShowTeamActivity:
                    throw new NotImplementedException();
                case CommandType.AddUserToTeam:
                    throw new NotImplementedException();
                case CommandType.ShowAllTeamUsers:
                    throw new NotImplementedException();
                case CommandType.CreateTeamBoard:
                    throw new NotImplementedException();
                case CommandType.ShowAllTeamBoards:
                    throw new NotImplementedException();
                case CommandType.ShowBoardActivity:
                    throw new NotImplementedException();
                case CommandType.CreateBoardTask:
                    throw new NotImplementedException();
                case CommandType.ChangeBug:
                    throw new NotImplementedException();
                case CommandType.ChangeStory:
                    throw new NotImplementedException();
                case CommandType.ChangeFeedback:
                    throw new NotImplementedException();
                case CommandType.AssignTask:
                    throw new NotImplementedException();
                case CommandType.UnAssignTask:
                    throw new NotImplementedException();
                case CommandType.AddComment:
                    throw new NotImplementedException();

                default:
                    throw new ArgumentException($"Command with name: {commandType}  doesn't exist!");
                    //Change when Create Exception Foulder!!!!!!!!!
            }
        }

        private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];
            Enum.TryParse(commandName, true, out CommandType result);
            return result;
        }
        private List<string> ExtractCommandParameters(string commandLine)
        {
            List<string> parameters = new List<string>();

            var indexOfOpenComment = commandLine.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = commandLine.IndexOf(CommentCloseSymbol);
            if (indexOfOpenComment >= 0)
            {
                var commentStartIndex = indexOfOpenComment + CommentOpenSymbol.Length;
                var commentLength = indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment;
                string commentParameter = commandLine.Substring(commentStartIndex, commentLength);
                parameters.Add(commentParameter);

                Regex regex = new Regex("{{.+(?=}})}}");
                commandLine = regex.Replace(commandLine, string.Empty);
            }

            var indexOfFirstSeparator = commandLine.IndexOf(SplitCommandSymbol);
            parameters.AddRange(commandLine.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));

            return parameters;
        }
    }
}
