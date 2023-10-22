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
    public class ChangeStoryCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ChangeRating()
        {
            // Arrange
            var repository = new Repository();
            var feedback = new Feedback(1, "Test Feedback", "Description", FeedbackStatus.New, 3, new ActivityHistory());
            repository.AddFeedBack(feedback);

            var commandParameters = new List<string> { "1", "rating", "5" };
            var command = new ChangeFeedBackCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Feedback status changed successfully!", result);
            Assert.AreEqual(5, feedback.Rating);
            Assert.IsTrue(feedback.History.Messages[0].Contains("Feedback rating has been changed from 3 to 5"));
        }

        [TestMethod]
        public void ExecuteCommand_Should_ChangeStatus()
        {
            // Arrange
            var repository = new Repository();
            var feedback = new Feedback(1, "Test Feedback", "Description", FeedbackStatus.New, 3, new ActivityHistory());
            repository.AddFeedBack(feedback);

            var commandParameters = new List<string> { "1", "status", "Done" };
            var command = new ChangeFeedBackCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Feedback status changed successfully!", result);
            Assert.AreEqual(FeedbackStatus.Done, feedback.Status);
            Assert.IsTrue(feedback.History.Messages[0].Contains("Feedback status has been changed from New to Done"));
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "1", "rating" };
            var command = new ChangeFeedBackCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidTargetParameter()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "1", "invalid", "5" };
            var command = new ChangeFeedBackCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<NotImplementedException>(() => command.Execute());
        }
    }
}
