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
    public class ShowAllTeamsCommandTests
    {
        [TestMethod]
        public void ExecuteCommand_Should_ShowAllTeams()
        {
            // Arrange
            var repository = new Repository();
            var team1 = new Team("TeamA");
            var team2 = new Team("TeamB");
            var team3 = new Team("TeamC");
            repository.AddTeam(team1);
            repository.AddTeam(team2);
            repository.AddTeam(team3);

            var commandParameters = new List<string>();
            var command = new ShowAllTeamsCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            string expected = "TeamA\r\nTeamB\r\nTeamC";
            Assert.AreEqual(expected, result.Trim());
        }

        [TestMethod]
        public void ExecuteCommand_Should_ShowNoTeams_WhenNoTeamsExist()
        {
            // Arrange
            var repository = new Repository();

            var commandParameters = new List<string>();
            var command = new ShowAllTeamsCommand(commandParameters, repository);

            // Act
            string result = command.Execute();

            // Assert
            Assert.AreEqual(string.Empty, result);
        }
    }
}
