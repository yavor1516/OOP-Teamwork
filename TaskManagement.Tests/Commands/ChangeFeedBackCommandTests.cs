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
    public class ChangeFeedBackCommandTests
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
        }

        [TestMethod]
        public void ExecuteCommand_Should_ChangeStatus()
        {
            // Arrange
            var repository = new Repository();
            var feedback = new Feedback(1, "Test Feedback", "Description", FeedbackStatus.New, 3, new ActivityHistory());
            repository.AddFeedBack(feedback);

            var commandParameters = new List<string> { "1", "status", "Scheduled"};
            var command = new ChangeFeedBackCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Feedback status changed successfully!", result);
            Assert.AreEqual(FeedbackStatus.Scheduled, feedback.Status);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var feedback = new Feedback(1, "Test Feedback", "Description", FeedbackStatus.New, 3, new ActivityHistory());
            var repository = new Repository();
            repository.AddFeedBack(feedback);
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
