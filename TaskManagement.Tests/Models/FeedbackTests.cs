using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Models;

namespace TaskManagement.Tests
{
    [TestClass]
    public class FeedbackTests
    {
        [TestMethod]
        public void Constructor_Should_SetProperties()
        {
            // Arrange
            int id = 1;
            string title = "Sample Feedback";
            string description = "Feedback Description";
            FeedbackStatus status = FeedbackStatus.New;
            int rating = 4;
            IActivityHistory history = new ActivityHistory();

            // Act
            var feedback = new Feedback(id, title, description, status, rating, history);

            // Assert
            Assert.AreEqual(id, feedback.UniqueID);
            Assert.AreEqual(title, feedback.Title);
            Assert.AreEqual(description, feedback.Description);
            Assert.AreEqual(status, feedback.Status);
            Assert.AreEqual(rating, feedback.Rating);
        }

        [TestMethod]
        public void Rating_Setter_Should_UpdateRating()
        {
            // Arrange
            var feedback = new Feedback(1, "Sample Feedback", "Description", FeedbackStatus.Scheduled, 4, new ActivityHistory());
            int newRating = 5;

            // Act
            feedback.Rating = newRating;

            // Assert
            Assert.AreEqual(newRating, feedback.Rating);
        }

        [TestMethod]
        public void Status_Setter_Should_UpdateStatus()
        {
            // Arrange
            var feedback = new Feedback(1, "Sample Feedback", "Description", FeedbackStatus.Scheduled, 4, new ActivityHistory());
            FeedbackStatus newStatus = FeedbackStatus.Done;

            // Act
            feedback.Status = newStatus;

            // Assert
            Assert.AreEqual(newStatus, feedback.Status);
        }

       
    }
}