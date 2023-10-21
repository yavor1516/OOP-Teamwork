using Tasks_Management.Commands.Enums;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Models;

namespace TaskManagement.Tests
{
   [TestClass]
    public class BugTests
    {
        [TestMethod]
        public void Constructor_Should_InitializeProperties_WenValidArguments() //problem with the severity!!!
        {
            // Arrange
            int id = 1;
            string title = "Test Title";
            string description = "Test Description";
            BugStatus status = BugStatus.Active;
            Priority priority = Priority.High;
            Severity severity = Severity.Major;
            IActivityHistory history = new ActivityHistory();

            // Act
            Bug bug = new Bug(id, title, description, status, priority, severity, history);

            // Assert
            Assert.AreEqual(id, bug.UniqueID);
            Assert.AreEqual(title, bug.Title);
            Assert.AreEqual(description, bug.Description);
            Assert.AreEqual(status, bug.Status);
            Assert.AreEqual(priority, bug.Priority);
            Assert.AreEqual(severity, bug.Severity);
            Assert.AreSame(history, bug.History);//ToDo
        }

        [TestMethod]
        public void Constructor_Should_Throw_WhenTitleIsTooShort()
        {
            // Arrange
            int id = 1;
            string invalidTitle = "no"; 
            string description = "Bug Description";
            BugStatus status = BugStatus.Active;
            Priority priority = Priority.High;
            Severity severity = Severity.Major;
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Bug(id, invalidTitle, description, status, priority, severity, history));
        }

        [TestMethod]
        public void Constructor_Should_Throw_WhenDescriptionIsTooShort()
        {
            // Arrange
            int id = 1;
            string title = "Bug Title";
            string invalidDescription = "no";
            BugStatus status = BugStatus.Active;
            Priority priority = Priority.High;
            Severity severity = Severity.Major;
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Bug(id, title, invalidDescription, status, priority, severity, history));
        }

        [TestMethod]
        public void Constructor_Should_Throw_WhenTitleIsTooLong()
        {
            // Arrange
            int id = 1;
            string invalidTitle = new string('A', 51);
            string description = "Bug Description";
            BugStatus status = BugStatus.Active;
            Priority priority = Priority.High;
            Severity severity = Severity.Major;
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Bug(id, invalidTitle, description, status, priority, severity, history));
        }

        [TestMethod]
        public void Constructor_Should_Throw_WhenDescriptionIsTooLong()
        {
            // Arrange
            int id = 1;
            string title = "Bug Title";
            string invalidDescription = new string('A', 501);
            BugStatus status = BugStatus.Active;
            Priority priority = Priority.High;
            Severity severity = Severity.Major;
            IActivityHistory history = new ActivityHistory();

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Bug(id, title, invalidDescription, status, priority, severity, history));
        }
    }
}