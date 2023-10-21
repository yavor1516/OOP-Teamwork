using Tasks_Management.Models;

namespace TaskManagement.Tests
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void Constructor_Should_SetProperties()
        {
            // Arrange
            string firstName = "Mirkata";
            string lastName = "Pablo";

            // Act
            var member = new Member(firstName, lastName);

            // Assert
            Assert.AreEqual(firstName, member.FirstName);
            Assert.AreEqual(lastName, member.LastName);
            Assert.IsNotNull(member.Tasks);
            Assert.IsNotNull(member.History);
            Assert.AreEqual(0, member.Tasks.Count);
        }

        [TestMethod]
        public void IsNameValid_Should_ReturnTrue_WhenNameIsValid()
        {
            // Arrange
            var member = new Member("Mirkata", "Pablo");

            // Act
            bool isValid = member.IsNameValid("ValidName");

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsNameValid_Should_ReturnFalse_WhenNameIsInvalid()
        {
            // Arrange
            var member = new Member("Mirkata", "Pablo");

            // Act
            bool isInvalid = member.IsNameValid("Inv");

            // Assert
            Assert.IsFalse(isInvalid);
        }

        [TestMethod]
        public void IsLastNameValid_Should_ReturnTrue_WhenLastNameIsValid()
        {
            // Arrange
            var member = new Member("Mirkata", "Pablo");

            // Act
            bool isValid = member.IsLastNameValid("ValidName");

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void IsLastNameValid_Should_ReturnFalse_WhenLastNameIsInvalid()
        {
            // Arrange
            var member = new Member("Mirkata", "Pablo");

            // Act
            bool isInvalid = member.IsLastNameValid("Inv");

            // Assert
            Assert.IsFalse(isInvalid);
        }
    }
}