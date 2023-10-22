using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks_Management.Commands;
using Tasks_Management.Core;
using Tasks_Management.Models;

namespace TaskManagement.Tests.Commands
{
    [TestClass]
    public class ShowUsersCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ShowAllUsers()
        {
            // Arrange
            var repository = new Repository();
            var member1 = new Member("Alexander", "Petrow");
            var member2 = new Member("Kristin", "Kirowa");
            repository.AddMember(member1);
            repository.AddMember(member2);

            var command = new ShowUsersCommand(new List<string>(), repository);

            // Act
            string result = command.Execute();

            // Assert
            string expected = "Alexander" + Environment.NewLine + "Petrow" + Environment.NewLine + "Kristin" + Environment.NewLine + "Kirowa";
            Assert.AreEqual(expected, result);
        }
    }
}
