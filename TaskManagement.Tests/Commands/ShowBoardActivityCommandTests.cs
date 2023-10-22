using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Commands;
using Tasks_Management.Core;
using Tasks_Management.Exceptions;
using Tasks_Management.Models;

namespace TaskManagement.Tests.Commands
{
    [TestClass]
    public class ShowBoardActivityCommandTests
    {
       
        [TestMethod]
        public void ExecuteCommand_Should_ShowNoBoardActivity_WhenNoActivityExists()
        {
            // Arrange
            var repository = new Repository();
            var boardName = "BoardA";
            var board = new Board(boardName);
            repository.AddBoard(board);

            var commandParameters = new List<string> { boardName };
            var command = new ShowBoardActivityCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual($"Board {boardName} has no activity.", result);
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenInvalidNumberOfArguments()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string>();
            var command = new ShowBoardActivityCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => command.Execute());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ThrowException_WhenBoardNotFound()
        {
            // Arrange
            var repository = new Repository();
            var commandParameters = new List<string> { "BoardX" };
            var command = new ShowBoardActivityCommand(commandParameters, repository);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => command.Execute());
        }
    }
}
