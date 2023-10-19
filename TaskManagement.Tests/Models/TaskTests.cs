using Tasks_Management.Commands.Enums;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Models;



namespace TaskManagement.Tests.Models
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void Constructor_Should_Throw_When_TitleIsTooLong()
        {
            // Arrange
            int id = 1;
            string longTitle = "ThisTitleIsWayTooLongToBeValidSoINeedToWriteSomethingMoreThan50DigitsAndIDontRealyKnowWhatToWriteToBeThisLong";
            Status status = Status.Done;
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                new Tasks_Management.Models.Task(id, longTitle, "Description", status, history);
                
            });
        }
        [TestMethod]
        public void Constructor_Should_Throw_When_TitleIsTooShort()
        {
            // Arrange
            int id = 1;
            string longTitle = "nope";
            Status status = Status.Done;
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                new Tasks_Management.Models.Task(id, longTitle, "Description", status, history);

            });
        }
        [TestMethod]
        public void Constructor_Should_Throw_When_DescriptionIsTooShort()
        {
            // Arrange
            int id = 1;
            string longTitle = "SomethingValid";
            Status status = Status.Done;
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                new Tasks_Management.Models.Task(id, longTitle, "Test", status, history);

            });
        }
        [TestMethod]
        public void Constructor_Should_Throw_When_DescriptionIsTooLong()
        {
            // Arrange
            int id = 1;
            string longTitle = "SomethingValid";
            Status status = Status.Done;
            string description = new string('w', 501);
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                new Tasks_Management.Models.Task(id, longTitle, description, status, history);

            });
        }
        [TestMethod]
        public void Constructor_Should_NotThrow_When_AllPropertiesAreValid()
        {
            // Arrange
            int id = 1;
            string validTitle = "ValidTitle";
            string validDescription = new string('a', 500);
            Status status = Status.InProgress;
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.AreEqual(validTitle, new Tasks_Management.Models.Task(id, validTitle, validDescription, status, history).Title);
            Assert.AreEqual(validDescription, new Tasks_Management.Models.Task(id, validTitle, validDescription, status, history).Description);
        }

        [TestMethod]
        public void AddComment_Should_AddComment_When_CommentIsNotNull()
        {
            // Arrange
            int id = 1;
            string validTitle = "ValidTitle";
            string validDescription = new string('a', 500);
            Status status = Status.InProgress;
            IActivityHistory history = new ActivityHistory();
            Tasks_Management.Models.Task task = new Tasks_Management.Models.Task(id, validTitle, validDescription, status, history);
            IComment comment = new Comment("Sample Comment" ,"TaskHere");

            // Act
            task.AddComment(comment);

            // Assert
            Assert.AreEqual(1, task.Comments.Count);
        }

        [TestMethod]
        public void AddComment_Should_Throw_When_CommentIsNull()
        {
            // Arrange
            int id = 1;
            string validTitle = "ValidTitle";
            string validDescription = new string('a', 500);
            Status status = Status.InProgress;
            IActivityHistory history = new ActivityHistory();
            Tasks_Management.Models.Task task = new Tasks_Management.Models.Task(id, validTitle, validDescription, status, history);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                task.AddComment(null);
            });
        }
    }
}