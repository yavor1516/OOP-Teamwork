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
    public class RegisterUserCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_RegisterUser()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Venko", "Venkov" };
            var command = new RegisterUserCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("User Venko Venkov registered successfully!", result);
            Assert.AreEqual(1, repository.Members.Count);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Venko" };
            var command = new RegisterUserCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenUserAlreadyExists()
        {
            // Arrange
            var repository = new Repository();
            var member = new Member("Venko", "Venkov");
            repository.AddMember(member);

            var commandParameters = new List<string> { "Venko", "Venkov" };
            var command = new RegisterUserCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<AuthorizationException>(() => command.Execute());
        }
    }
}
