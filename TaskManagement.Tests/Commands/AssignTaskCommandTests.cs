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
    public class AssignTaskCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_AssignTaskToMember()
        {
            // Arrange
            var repository = new Repository();
            var task = new TestTask(1, "TestoviTask", "Description", new ActivityHistory());
            repository.AddTask(task);
            var member = new Member("Vanko", "Vankov");
            repository.AddMember(member);

            var commandParameters = new List<string> { "1", "Vanko", "Vankov" };
            var command = new AssignTaskCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Task: TestoviTask has been assigned to member: Vanko Vankov", result);
            Assert.AreEqual(member, task.Assignee);
            Assert.AreEqual(1, task.History.Messages.Count);
            Assert.IsTrue(member.Tasks.Contains(task));
            Assert.AreEqual(1, member.History.Messages.Count);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "1", "Vanko" };
            var command = new AssignTaskCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenTaskNotFound()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "1", "Vanko", "Vankov" };
            var command = new AssignTaskCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenMemberNotFound()
        {
            // Arrange
            var repository = new Repository();
            var task = new TestTask(1, "TestoviTask", "Description", new ActivityHistory());
            repository.AddTask(task);
            var commandParameters = new List<string> { "1", "Vanko", "Vankov" };
            var command = new AssignTaskCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
    }
}
