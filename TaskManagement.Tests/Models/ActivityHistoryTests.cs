using Tasks_Management.Models;

namespace TaskManagement.Tests.Models
{
    [TestClass]
    public class ActivityHistoryTests
    {
        [TestMethod]
        public void Constructor_Should_InitializeMessagesList()
        {
            // Arrange & Act
            var history = new ActivityHistory();

            // Assert
            Assert.IsNotNull(history.Messages);
            Assert.IsInstanceOfType(history.Messages, typeof(IList<string>));
            Assert.AreEqual(0, history.Messages.Count);
        }
    }
}