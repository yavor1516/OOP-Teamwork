using Tasks_Management.Exceptions;
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
        public void FirstName_Should_SetValidName()
        {
            // Arrange
            var member = new Member("Mirkata", "Pablo");

            // Act
            member.FirstName = "ValidName";

            // Assert
            Assert.AreEqual("ValidName", member.FirstName);
        }

        [TestMethod]
        public void FirstName_Should_ThrowException_WhenInvalidName()
        {
            // Arrange
            var member = new Member("Mirkata", "Pablo");

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                member.FirstName = "Inv";
            });
        }

        [TestMethod]
        public void LastName_Should_SetValidName()
        {
            // Arrange
            var member = new Member("Mirkata", "Pablo");

            // Act
            member.LastName = "ValidName";

            // Assert
            Assert.AreEqual("ValidName", member.LastName);
        }

        [TestMethod]
        public void LastName_Should_ThrowException_WhenInvalidName()
        {
            // Arrange
            var member = new Member("Mirkata", "Pablo");

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() =>
            {
                member.LastName = "Inv";
            });
        }
    }

}