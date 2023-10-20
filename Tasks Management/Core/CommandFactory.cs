 using System;
using System.Text.RegularExpressions;
using Tasks_Management.Commands;
using Tasks_Management.Commands.Contracts;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Exceptions;


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
                    return new RegisterUserCommand(commandParameters,repository);
                case CommandType.ShowUsers:
                    return new ShowUsersCommand(commandParameters,repository);
                case CommandType.ShowUserActivity:
                    return new ShowUserActivityCommand(commandParameters, repository); //todo
                case CommandType.CreateNewTeam: 
                    return new CreateNewTeamCommand(commandParameters, repository);
                case CommandType.ShowAllTeams:
                    return new ShowAllTeamsCommand(commandParameters,repository);
                case CommandType.ShowTeamActivity:
                    return new ShowTeamActivityCommand(commandParameters,repository); //todo
                case CommandType.AddUserToTeam:
                    return new AddUserToTeamCommand(commandParameters,repository);
                case CommandType.ShowAllTeamUsers:
                    return new ShowAllTeamUsersCommand(commandParameters,repository);
                case CommandType.CreateTeamBoard:
                    return new CreateTeamBoardCommand(commandParameters, repository);
                case CommandType.ShowAllTeamBoards:
                    return new ShowAllTeamBoardsCommand(commandParameters, repository);
                case CommandType.ShowBoardActivity:
                    return new ShowBoardActivityCommand(commandParameters, repository); //todo
                case CommandType.CreateBoardTask:
                    throw new NotImplementedException();
                case CommandType.ChangeBug:
                    return new ChangeBugCommand(commandParameters, repository);
                case CommandType.ChangeStory:
                    return new ChangeStroyCommand(commandParameters, repository);
                case CommandType.ChangeFeedback:
                    return new ChangeFeedBackCommand(commandParameters, repository);
                case CommandType.AssignTask:
                    return new AssignTaskCommand(commandParameters, repository);
                case CommandType.UnAssignTask:
                    return new UnAssignTaskCommand(commandParameters, repository);
                case CommandType.AddComment:
                    return new AddCommentCommand(commandParameters, repository);
                case CommandType.CreateTask:
                    return new CreateTaskCommand(commandParameters, repository);
                case CommandType.ShowTaskHistory:
                    return new TaskHistoryCommand(commandParameters, repository);
                default:
                    throw new InvalidUserInputException($"Command with name: {commandType}  doesn't exist!");
            }
        }

        private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];

            bool commandIsValid = Enum.TryParse(commandName, true, out CommandType result);
            if(commandIsValid) { return result; }
            throw new ArgumentException("not valid command");
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
