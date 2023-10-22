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
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                new TestTask(id, longTitle, "Description", history);

            });
        }
        [TestMethod]
        public void Constructor_Should_Throw_When_TitleIsTooShort()
        {
            // Arrange
            int id = 1;
            string longTitle = "nope";
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                new TestTask(id, longTitle, "Description", history);

            });
        }
        [TestMethod]
        public void Constructor_Should_Throw_When_DescriptionIsTooShort()
        {
            // Arrange
            int id = 1;
            string longTitle = "SomethingValid";
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                new TestTask(id, longTitle, "Test", history);

            });
        }
        [TestMethod]
        public void Constructor_Should_Throw_When_DescriptionIsTooLong()
        {
            // Arrange
            int id = 1;
            string longTitle = "SomethingValid";
            string description = new string('w', 501);
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                new TestTask(id, longTitle, description, history);

            });
        }
        [TestMethod]
        public void Constructor_Should_NotThrow_When_AllPropertiesAreValid()
        {
            // Arrange
            int id = 1;
            string validTitle = "ValidTitle";
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.AreEqual(validTitle, new TestTask(id, validTitle, "Description", history).Title);
            Assert.AreEqual("Description", new TestTask(id, validTitle, "Description", history).Description);
        }

        [TestMethod]
        public void AddComment_Should_AddComment_When_CommentIsNotNull()
        {
            // Arrange
            int id = 1;
            string validTitle = "ValidTitle";
            IActivityHistory history = new ActivityHistory();
            TestTask task = new TestTask(id, validTitle, "Description", history);
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
            IActivityHistory history = new ActivityHistory();
            TestTask task = new TestTask(id, validTitle, "Description", history);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                task.AddComment(null);
            });
        }
    }
}