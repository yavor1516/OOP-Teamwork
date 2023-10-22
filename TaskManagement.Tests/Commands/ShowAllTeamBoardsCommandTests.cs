using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands;
using Tasks_Management.Core;
using Tasks_Management.Exceptions;
using Tasks_Management.Models;

namespace TaskManagement.Tests.Commands
{
    [TestClass]
    public class ShowAllTeamBoardsCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ShowAllTeamBoards()
        {
            // Arrange
            var repository = new Repository();
            var team = new Team("TeamA");
            repository.AddTeam(team);
            var board1 = new Board("Board1");
            var board2 = new Board("Board2");
            var board3 = new Board("Board3");
            repository.AddBoard(board1);
            repository.AddBoard(board2);
            repository.AddBoard(board3);
            team.Boards.Add(board1);
            team.Boards.Add(board2);
            team.Boards.Add(board3);

            var commandParameters = new List<string> { "TeamA" };
            var command = new ShowAllTeamBoardsCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            string expected = "Boards for Team TeamA:\r\nBoard1\r\nBoard2\r\nBoard3\r\n";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ShowNoBoards_WhenTeamHasNoBoards()
        {
            // Arrange
            var repository = new Repository();
            var team = new Team("TeamA");
            repository.AddTeam(team);

            var commandParameters = new List<string> { "TeamA" };
            var command = new ShowAllTeamBoardsCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Team TeamA has no boards.", result);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "TeamA", "ExtraArgument" };
            var command = new ShowAllTeamBoardsCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenTeamNotFound()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "TeamA" };
            var command = new ShowAllTeamBoardsCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

    }
}
