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
    public class AddCommentCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_AddCommentToTask()
        {
            // Arrange
            var repository = new Repository();
            var task = new TestTask(1, "TestTaskTitle", "Description", new ActivityHistory());
            repository.AddTask(task);

            var commandParameters = new List<string> { "1", "Pepi Kirow", "This is a comment" };
            var command = new AddCommentCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Comment added to task TestTaskTitle: This is a comment", result);

        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "1", "Pepi Kirow" };
            var command = new AddCommentCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenTaskNotFound()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "1", "Pepi Kirow", "This is a comment" };
            var command = new AddCommentCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
    }
}
