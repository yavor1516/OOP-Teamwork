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
    public class CreateTeamBoardCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_CreateTeamBoard()
        {
            // Arrange
            var repository = new Repository();
            var team = new Team("Test Team");
            repository.AddTeam(team);

            var commandParameters = new List<string> { "Test Team", "Board 1" };
            var command = new CreateTeamBoardCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Board Board 1 registered successfully!", result);
            Assert.AreEqual(1, repository.Boards.Count);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Test Team" };
            var command = new CreateTeamBoardCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenTeamNotFound()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Test Team", "Board 1" };
            var command = new CreateTeamBoardCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenBoardAlreadyExists()
        {
            // Arrange
            var repository = new Repository();
            var team = new Team("Test Team");
            repository.AddTeam(team);
            var board = new Board("Board 1");
            repository.AddBoard(board);

            var commandParameters = new List<string> { "Test Team", "Board 1" };
            var command = new CreateTeamBoardCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }
    }
}
