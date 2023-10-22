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
    public class TaskHistoryCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidArgumentCount()
        {
            // Arrange
            var repository = new Repository();
            var command = new TaskHistoryCommand(new List<string>(), repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenTaskNotFound()
        {
            // Arrange
            var repository = new Repository();
            var command = new TaskHistoryCommand(new List<string> { "1" }, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
    }
}
