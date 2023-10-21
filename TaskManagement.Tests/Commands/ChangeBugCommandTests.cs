using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tasks_Management.Commands;
using Tasks_Management.Core;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Models;
using Tasks_Management.Commands.Enums;

namespace TaskManagement.Tests.Commands
{
    [TestClass]
    public class ChangeBugCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ChangePriority()
        {
            // Arrange
            var repository = new Repository();
            var bug = new Bug(1, "TestoviBug", "Description", BugStatus.Active, Priority.Low, Severity.Major, new ActivityHistory());
            repository.AddBug(bug);

            var commandParameters = new List<string> { "1", "priority", "High" };
            var command = new ChangeBugCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Bug priority changed successfully!", result);
            Assert.AreEqual(Priority.High, bug.Priority);
            Assert.IsTrue(bug.History.Messages[0].Contains("Bug priority has been changed from Low to High"));
        }

        [TestMethod]
        public void ExecuteCommand_Should_ChangeSeverity()
        {
            // Arrange
            var repository = new Repository();
            var bug = new Bug(1, "TestoviBug", "Description", BugStatus.Active, Priority.Low, Severity.Minor, new ActivityHistory());
            repository.AddBug(bug);

            var commandParameters = new List<string> { "1", "severity", "Major" };
            var command = new ChangeBugCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Bug severity changed successfully!", result);
            Assert.AreEqual(Severity.Major, bug.Severity);
            Assert.IsTrue(bug.History.Messages[0].Contains("Bug severity has been changed from Minor to Major"));
        }

        [TestMethod]
        public void ExecuteCommand_Should_ChangeStatus()
        {
            // Arrange
            var repository = new Repository();
            var bug = new Bug(1, "TestoviBug", "Description", BugStatus.Fixed, Priority.Low, Severity.Critical, new ActivityHistory());
            repository.AddBug(bug);

            var commandParameters = new List<string> { "1", "status", "Resolved" };
            var command = new ChangeBugCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Bug status changed successfully!", result);
            Assert.AreEqual(BugStatus.Active, bug.Status);
            Assert.IsTrue(bug.History.Messages[0].Contains("Bug status has been changed from Fixed to Active"));
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "1", "priority" };
            var command = new ChangeBugCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidTargetParameter()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "1", "invalid", "High" };
            var command = new ChangeBugCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<NotImplementedException>(() => command.Execute());
        }
    }
}
