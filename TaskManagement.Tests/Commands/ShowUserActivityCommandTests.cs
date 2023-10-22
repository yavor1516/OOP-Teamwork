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
    public class ShowUserActivityCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ShowUserActivity()
        {
            // Arrange
            var repository = new Repository();
            var firstName = "Boris";
            var lastName = "Kirow";
            var member = new Member(firstName, lastName);
            member.History.Messages.Add("Boris created a task");
            repository.AddMember(member);

            var commandParameters = new List<string> { firstName, lastName };
            var command = new ShowUserActivityCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            string expected = "BorisKirow includes Boris created a task";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ShowNoUserActivity_WhenNoActivityExists()
        {
            // Arrange
            var repository = new Repository();
            var firstName = "Katrin";
            var lastName = "Petrowa";
            var member = new Member(firstName, lastName);
            repository.AddMember(member);

            var commandParameters = new List<string> { firstName, lastName };
            var command = new ShowUserActivityCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            string expected = $"{firstName + lastName} has no activity.";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Katrin" };
            var command = new ShowUserActivityCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenUserNotFound()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Boris", "Kirow" };
            var command = new ShowUserActivityCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
    }
}
