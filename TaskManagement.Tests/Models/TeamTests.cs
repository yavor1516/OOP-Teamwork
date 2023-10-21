using Tasks_Management.Exceptions;
using Tasks_Management.Models;

namespace TaskManagement.Tests
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void Constructor_Should_SetName()
        {
            // Arrange
            string teamName = "SampleTeam";

            // Act
            var team = new Team(teamName);

            // Assert
            Assert.AreEqual(teamName, team.Name);
        }

        [TestMethod]
        public void Constructor_Should_InitializeMembersAndBoards()
        {
            // Arrange
            string teamName = "SampleTeam";

            // Act
            var team = new Team(teamName);

            // Assert
            Assert.IsNotNull(team.Members);
            Assert.IsNotNull(team.Boards);
            Assert.AreEqual(0, team.Members.Count);
            Assert.AreEqual(0, team.Boards.Count);
        }

        [TestMethod]
        public void Name_Setter_Should_UpdateName()
        {
            // Arrange
            var team = new Team("SampleTeam");
            string newName = "NewTeamName";

            // Act
            team.Name = newName;

            // Assert
            Assert.AreEqual(newName, team.Name);
        }

        [TestMethod]
        public void Name_Setter_Should_ThrowException_WhenNameIsTooShort()
        {
            // Arrange
            var team = new Team("SampleTeam");
            string invalidName = "no";

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => team.Name = invalidName);
        }

        [TestMethod]
        public void Name_Setter_Should_ThrowException_WhenNameIsTooLong()
        {
            // Arrange
            var team = new Team("SampleTeam");
            string invalidName = "VeryLongTeamNameThatExceedsTheMaxLength";

            // Act & Assert
            Assert.ThrowsException<InvalidUserInputException>(() => team.Name = invalidName);
        }
    }
}