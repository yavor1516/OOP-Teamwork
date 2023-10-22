using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Commands;
using Tasks_Management.Core;
using Tasks_Management.Exceptions;
using Tasks_Management.Models;

namespace TaskManagement.Tests.Commands
{
    [TestClass]
    public class UnAssignTaskCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidArgumentCount()
        {
            // Arrange
            var repository = new Repository();
            var command = new UnAssignTaskCommand(new List<string> { "1", "Kircho" }, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenTaskNotFound()
        {
            // Arrange
            var repository = new Repository();
            var command = new UnAssignTaskCommand(new List<string> { "1", "Kircho", "Kirow" }, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenMemberNotFound()
        {
            // Arrange
            var repository = new Repository();
            var task = new TestTask(1,"Sample Task", "Description", new ActivityHistory());
            repository.AddTask(task);

            var command = new UnAssignTaskCommand(new List<string> { "1", "Kircho", "Kirow" }, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
    }
}
