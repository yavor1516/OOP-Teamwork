using Tasks_Management.Models;

namespace TaskManagement.Tests
{
    [TestClass]
    public class CommentTests
    {
        [TestMethod]
        public void Constructor_Should_SetAuthorAndCommentText()
        {
            // Arrange
            string author = "Kiril Petkov";
            string commentText = "This is a comment";

            // Act
            var comment = new Comment(commentText, author);

            // Assert
            Assert.AreEqual(author, comment.Author);
            Assert.AreEqual(commentText, comment.CommentText);
        }

        [TestMethod]
        public void CommentText_Should_NotBeNull()
        {
            // Arrange
            string author = "Kiril Petkov";
            string commentText = null;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Comment(commentText, author));
        }

        [TestMethod]
        public void CommentText_Should_NotBeEmpty()
        {
            // Arrange
            string author = "Kiril Petkov";
            string commentText = "";

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Comment(commentText, author));
        }

        [TestMethod]
        public void Author_Should_NotBeNull()
        {
            // Arrange
            string author = null;
            string commentText = "This is a comment";

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Comment(commentText, author));
        }

        [TestMethod]
        public void Author_Should_NotBeEmpty()
        {
            // Arrange
            string author = "";
            string commentText = "This is a comment";

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Comment(commentText, author));
        }
    }
}