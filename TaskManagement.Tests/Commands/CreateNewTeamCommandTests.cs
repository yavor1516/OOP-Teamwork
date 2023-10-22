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
    public class CreateNewTeamCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_CreateNewTeam()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Team1" };
            var command = new CreateNewTeamCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Team Team1 registered successfully!", result);
            Assert.IsTrue(repository.TeamExist("Team1"));
            Assert.IsNotNull(repository.GetTeam("Team1"));
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Team1", "Team2" };
            var command = new CreateNewTeamCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenTeamNameAlreadyExists()
        {
            // Arrange
            var repository = new Repository();
            var team = new Team("Team1");
            repository.AddTeam(team);
            var commandParameters = new List<string> { "Team1" };
            var command = new CreateNewTeamCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<AuthorizationException>(() => command.Execute());
        }
    }
}
