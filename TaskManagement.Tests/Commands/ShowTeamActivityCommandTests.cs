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
    public class ShowTeamActivityCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ShowNoTeamActivity_WhenNoActivityExists()
        {
            // Arrange
            var repository = new Repository();
            var teamName = "TeamA";
            var team = new Team(teamName);
            repository.AddTeam(team);

            var commandParameters = new List<string> { teamName };
            var command = new ShowTeamActivityCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual($"Team {teamName} has no activity.", result);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string>();
            var command = new ShowTeamActivityCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenTeamNotFound()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "TeamX" };
            var command = new ShowTeamActivityCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
    }
}
