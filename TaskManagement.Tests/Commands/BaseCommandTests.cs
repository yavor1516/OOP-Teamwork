using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tasks_Management.Commands;
using Tasks_Management.Core;
using Tasks_Management.Exceptions;
using Tasks_Management.Models.Contracts;
using Tasks_Management.Models;

namespace TaskManagement.Tests.Commands
{
    [TestClass]
    public class BaseCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ReturnExpectedResult()
        {
            // Arrange
            var repository = new Repository(); 
            var commandParameters = new List<string> { "param1", "param2" };
            var command = new TestBaseCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Test result", result);
        }

        [TestMethod]
        public void ParseIntParameter_Should_ParseValidInt()
        {
            // Arrange
            var repository = new Repository();
            var command = new TestBaseCommand(new List<string>(), repository);

            // Act
            int parsedValue = command.ParseIntParameter("42", "paramName");

            // Assert
            Assert.AreEqual(42, parsedValue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidUserInputException))]
        public void ParseIntParameter_Should_ThrowExceptionForInvalidInt()
        {
            // Arrange
            var repository = new Repository();
            var command = new TestBaseCommand(new List<string>(), repository);

            // Act & Assert
            command.ParseIntParameter("invalidValue", "paramName");
        }

        // Similar tests for ParseDecimalParameter and ParseBoolParameter

        [TestMethod]
        public void Execute_Should_CallExecuteCommand()
        {
            // Arrange
            var repository = new Repository();
            var command = new TestBaseCommand(new List<string>(), repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual("Test result", result);
        }
    }
}
