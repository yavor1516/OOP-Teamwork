using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands;
using Tasks_Management.Core;
using Tasks_Management.Exceptions;

namespace TaskManagement.Tests.Commands
{
    [TestClass]
    public class CreateTaskCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_CreateBug()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Bug", "TestoviBug", "Description", "Active", "High", "Major" };
            var command = new CreateTaskCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Bug with title: TestoviBug created successfully!", result);
            Assert.AreEqual(1, repository.Bugs.Count);
        }

        [TestMethod]
        public void ExecuteCommand_Should_CreateStory()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Story", "Test Story", "Description", "Done", "High", "Small" };
            var command = new CreateTaskCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Story with title :Test Story created successfully!", result);
            Assert.AreEqual(1, repository.Stories.Count);
        }

        [TestMethod]
        public void ExecuteCommand_Should_CreateFeedback()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Feedback", "Test Feedback", "Description", "New", "5" };
            var command = new CreateTaskCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Feedback with title :Test Feedback created successfully!", result);
            Assert.AreEqual(1, repository.FeedBacks.Count);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Bug", "Test Bug" };
            var command = new CreateTaskCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidPriority()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Bug", "Test Bug", "Description", "Active", "InvalidPriority", "Major" };
            var command = new CreateTaskCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidSeverity()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "Bug", "Test Bug", "Description", "Active", "High", "InvalidSeverity" };
            var command = new CreateTaskCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }
    }
}
