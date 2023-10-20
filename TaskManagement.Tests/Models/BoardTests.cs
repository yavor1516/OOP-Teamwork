using Tasks_Management.Commands.Enums;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Models;


namespace TaskManagement.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Constructor_Should_InitializeName_When_ValidArgumentsAreProvided()
        {
            // Arrange
            string validName = "MyBoard";

            // Act
            Board board = new Board(validName);

            // Assert
            Assert.AreEqual(validName, board.Name);
        }
        [TestMethod]
        public void Constructor_Should_Throw_When_NameIsTooShort()
        {
            // Arrange
            string invalidName = "no";

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Board(invalidName));
        }
        [TestMethod]
        public void Constructor_Should_Throw_When_NameIsTooLong()
        {
            // Arrange
            string invalidName = "VeryLongBoardName";

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => new Board(invalidName));
        }

    }
}