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
    }
}