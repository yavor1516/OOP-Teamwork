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
    public class ShowAllTeamUsersCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ShowTeamUsers()
        {
            // Arrange
            var repository = new Repository();
            var teamName = "TeamA";
            var team = new Team(teamName);
            repository.AddTeam(team);
            var user1 = new Member("Valentin", "Kirow");
            var user2 = new Member("Georgi", "Terziew");
            var user3 = new Member("Kristin", "Kirlewa");
            repository.AddMember(user1);
            repository.AddMember(user2);
            repository.AddMember(user3);

           
            var commandParameters = new List<string> { teamName };
            var command = new ShowAllTeamUsersCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            string expected = "TeamA includes Valentin Kirow, Georgi Terziew, Kristin Kirlewa";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ShowNoTeamUsers_WhenNoUsersExist()
        {
            // Arrange
            var repository = new Repository();
            var teamName = "TeamA";
            var team = new Team(teamName);
            repository.AddTeam(team);

            var commandParameters = new List<string> { teamName };
            var command = new ShowAllTeamUsersCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual($"Team {teamName} has no users.", result);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string>();
            var command = new ShowAllTeamUsersCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenTeamNotFound()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "TeamB" };
            var command = new ShowAllTeamUsersCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
    }
}
