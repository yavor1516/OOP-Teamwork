using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tasks_Management.Commands;
using Tasks_Management.Core;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Models;


namespace TaskManagement.Tests.Commands
{
    [TestClass]
    public class AddUserToTeamCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_AddUserToTeam()
        {
            // Arrange
            var repository = new Repository();
            var team = new Team("TeamName");
            repository.AddTeam(team);
            var member = new Member("Pesho", "Sekirata");
            repository.AddMember(member);

            var commandParameters = new List<string> { "TeamName", "Pesho", "Sekirata" };
            var command = new AddUserToTeamCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("UserPeshoSekirata added to teamTeamName!", result);
            Assert.IsTrue(team.Members.Contains(member));
            Assert.AreEqual(1, team.History.Messages.Count);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "TeamName", "Pesho" };
            var command = new AddUserToTeamCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenTeamNotFound()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "TeamName", "Pesho", "Sekirata" };
            var command = new AddUserToTeamCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenUserNotFound()
        {
            // Arrange
            var repository = new Repository();
            var team = new Team("TeamName");
            repository.AddTeam(team);
            var commandParameters = new List<string> { "TeamName", "Pesho", "Sekirata" };
            var command = new AddUserToTeamCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
    }
}
