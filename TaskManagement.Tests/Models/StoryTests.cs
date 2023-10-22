using Tasks_Management.Commands.Enums;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Models;

namespace TaskManagement.Tests
{
    [TestClass]
    public class StoryTests
    {
        [TestMethod]
        public void Constructor_Should_SetProperties()
        {
            // Arrange
            int id = 1;
            string title = "Sample Story";
            string description = "Story Description";
            StoryStatus status = StoryStatus.InProgress;
            Priority priority = Priority.Medium;
            Size size = Size.Large;
            IActivityHistory history = new ActivityHistory();

            // Act
            var story = new Story(id, title, description, status, priority, size, history);

            // Assert
            Assert.AreEqual(id, story.UniqueID);
            Assert.AreEqual(title, story.Title);
            Assert.AreEqual(description, story.Description);
            Assert.AreEqual(status, story.Status);
            Assert.AreEqual(priority, story.Priority); // ToDO
            Assert.AreEqual(size, story.Size);
        }

        [TestMethod]
        public void Constructor_Should_UpdatePriority()
        {
            // Arrange
            var story = new Story(1, "Sample Story", "Description", StoryStatus.InProgress, Priority.Medium, Size.Large, new ActivityHistory());
            Priority newPriority = Priority.High;

            // Act
            story.Priority = newPriority;

            // Assert
            Assert.AreEqual(newPriority, story.Priority);
        }

        [TestMethod]
        public void Constructor_Should_UpdateSize()
        {
            // Arrange
            var story = new Story(1, "Sample Story", "Description", StoryStatus.InProgress, Priority.Medium, Size.Large, new ActivityHistory());
            Size newSize = Size.Small;

            // Act
            story.Size = newSize;

            // Assert
            Assert.AreEqual(newSize, story.Size);
        }

        [TestMethod]
        public void Constructor_Should_UpdateStatus()
        {
            // Arrange
            var story = new Story(1, "Sample Story", "Description", StoryStatus.InProgress, Priority.Medium, Size.Large, new ActivityHistory());
            StoryStatus newStatus = StoryStatus.Done;

            // Act
            story.Status = newStatus;

            // Assert
            Assert.AreEqual(newStatus, story.Status);
        }

    }
}