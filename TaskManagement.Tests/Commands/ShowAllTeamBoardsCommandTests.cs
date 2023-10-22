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
