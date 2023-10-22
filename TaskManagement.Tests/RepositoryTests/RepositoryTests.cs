using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tasks_Management.Core;
using Tasks_Management.Models;
using System;
using Tasks_Management.Commands.Enums;
using Tasks_Management.Core.Contracts;
using Tasks_Management.Models.Contracts;

namespace TaskManagement.Tests.RepositoryTests;
[TestClass]
public class RepositoryTests
{
    IRepository repository = new Repository();

    [TestInitialize]
    public void InitTest()
    {
        this.repository = new Repository();
    }

    [TestMethod]
    public void AddMember_AddsMemberToList()
    {
        // Arrange
        IMember member = new Member("Vankata", "Misho");

        // Act
        repository.AddMember(member);

        // Assert
        CollectionAssert.Contains((System.Collections.ICollection)repository.Members, member);
    }

    [TestMethod]
    public void AddTeam_AddsTeamToList()
    {
        // Arrange
        ITeam team = new Team("Bestteam Forsure");

        // Act
        repository.AddTeam(team);

        // Assert
        CollectionAssert.Contains((System.Collections.ICollection)repository.Teams, team);
    }

    [TestMethod]
    public void CreateMember_CreatesNewMember()
    {
        // Act
        IMember member = repository.CreateMember("Donatelo", "Kircho");

        // Assert
        Assert.IsNotNull(member);
        Assert.AreEqual("Donatelo", member.FirstName);
        Assert.AreEqual("Kircho", member.LastName);
    }

    [TestMethod]
    public void CreateTeam_CreatesNewTeam()
    {
        // Act
        ITeam team = repository.CreateTeam("Another Good Team");

        // Assert
        Assert.IsNotNull(team);
        Assert.AreEqual("Another Good Team", team.Name);
    }

    [TestMethod]
    public void GetMember_ReturnsExistingMember()
    {
        // Arrange
        IMember member = new Member("Milena", "Ivanowa");
        repository.AddMember(member);

        // Act
        IMember retrievedMember = repository.GetMember("Milena", "Ivanowa");

        // Assert
        Assert.IsNotNull(retrievedMember);
        Assert.AreEqual("Milena", retrievedMember.FirstName);
        Assert.AreEqual("Ivanowa", retrievedMember.LastName);
    }

    [TestMethod]
    public void GetMember_ThrowsExceptionForNonExistentMember()
    {
        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => repository.GetMember("Not", "Posible"));
    }

    [TestMethod]
    public void AddTask_AddsTaskToList()
    {
        // Arrange
        int id = 1;
        IActivityHistory history = new ActivityHistory();
        Tasks_Management.Models.Task task = new TestTask(id,"ValidTitle", "Description", history);
        // Act
        repository.AddTask(task);

        // Assert
        CollectionAssert.Contains((System.Collections.ICollection)repository.Tasks, task);
    }

    [TestMethod]
    public void AddBug_AddsBugToList()
    {
        // Arrange
        IBug bug = new Bug(1, "Critical Bug", "This is a critical bug", BugStatus.Active, Priority.High, Severity.Critical, new ActivityHistory());

        // Act
        repository.AddBug(bug);

        // Assert
        CollectionAssert.Contains((System.Collections.ICollection)repository.Bugs, bug);
    }

    [TestMethod]
    public void AddStory_AddsStoryToList()
    {
        // Arrange
        IStory story = new Story(1, "User Story", "This is a user story", StoryStatus.Done, Priority.Medium, Size.Large, new ActivityHistory());

        // Act
        repository.AddStory(story);

        // Assert
        CollectionAssert.Contains((System.Collections.ICollection)repository.Stories, story);
    }

    [TestMethod]
    public void AddFeedBack_AddsFeedbackToList()
    {
        // Arrange
        IFeedBack feedback = new Feedback(1, "Feedback on Product", "This is a productfeedback", FeedbackStatus.Unscheduled, 5, new ActivityHistory());

        // Act
        repository.AddFeedBack(feedback);

        // Assert
        CollectionAssert.Contains((System.Collections.ICollection)repository.FeedBacks, feedback);
    }

    [TestMethod]
    public void GetBoard_ThrowsExceptionForNonExistentBoard()
    {
        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => repository.GetBoard("Nonexistent Board"));
    }

    [TestMethod]
    public void CreateComment_CreatesNewComment()
    {
        // Act
        IComment comment = repository.CreateComment("This is a comment", "Task 1");

        // Assert
        Assert.IsNotNull(comment);
        Assert.AreEqual("This is a comment", comment.CommentText);
    }

    [TestMethod]
    public void GetTask_ThrowsExceptionForNonExistentTask()
    {
        // Act and Assert
        Assert.ThrowsException<ArgumentException>(() => repository.GetTask(1));
    }

    [TestMethod]
    public void AddMember_DoesNotAddDuplicateMembers()
    {
        // Arrange
        IMember member = new Member("Vankata", "Misho");
        repository.AddMember(member);

        // Act
        repository.AddMember(member);

        // Assert
        Assert.AreEqual(1, repository.Members.Count);
    }

    [TestMethod]
    public void AddTeam_DoesNotAddDuplicateTeams()
    {
        // Arrange
        ITeam team = new Team("Dev Team");
        repository.AddTeam(team);

        // Act
        repository.AddTeam(team);

        // Assert
        Assert.AreEqual(1, repository.Teams.Count);
    }

    [TestMethod]
    public void CreateMember_DoesNotReturnNull()
    {
        // Act
        IMember member = repository.CreateMember("Vankata", "Misho");

        // Assert
        Assert.IsNotNull(member);
    }

    [TestMethod]
    public void CreateTeam_DoesNotReturnNull()
    {
        // Act
        ITeam team = repository.CreateTeam("Quality Assurance Team");

        // Assert
        Assert.IsNotNull(team);
    }

    [TestMethod]
    public void MemberExist_ReturnsTrueForExistingMember()
    {
        // Arrange
        IMember member = new Member("Vankata", "Misho");
        repository.AddMember(member);

        // Act
        bool exists = repository.MemberExist("Vankata", "Misho");

        // Assert
        Assert.IsTrue(exists);
    }

    [TestMethod]
    public void MemberExist_ReturnsFalseForNonExistentMember()
    {
        // Act
        bool exists = repository.MemberExist("Non", "Existent");

        // Assert
        Assert.IsFalse(exists);
    }

    [TestMethod]
    public void AddTask_DoesNotAddDuplicateTasks()
    {
        // Arrange
        int id = 1;
        IActivityHistory history = new ActivityHistory();
        ITask task = new TestTask(id, "ValidTitle", "Description", history);
        repository.AddTask(task);

        // Act
        repository.AddTask(task);

        // Assert
        Assert.AreEqual(1, repository.Tasks.Count);
    }

    [TestMethod]
    public void AddBug_DoesNotAddDuplicateBugs()
    {
        // Arrange
        IBug bug = new Bug(1, "Critical Bug", "This is a critical bug",BugStatus.Active, Priority.High, Severity.Critical, new ActivityHistory());
        repository.AddBug(bug);

        // Act
        repository.AddBug(bug);

        // Assert
        Assert.AreEqual(1, repository.Bugs.Count);
    }

    [TestMethod]
    public void AddStory_DoesNotAddDuplicateStories()
    {
        // Arrange
        IStory story = new Story(1, "User Story", "This is a user story", StoryStatus.InProgress, Priority.Medium, Size.Large, new ActivityHistory());
        repository.AddStory(story);

        // Act
        repository.AddStory(story);

        // Assert
        Assert.AreEqual(1, repository.Stories.Count);
    }

    [TestMethod]
    public void AddFeedBack_DoesNotAddDuplicateFeedbacks()
    {
        // Arrange
        IFeedBack feedback = new Feedback(1, "Feedback on Product", "This is a product feedback", FeedbackStatus.Scheduled, 5, new ActivityHistory());
        repository.AddFeedBack(feedback);

        // Act
        repository.AddFeedBack(feedback);

        // Assert
        Assert.AreEqual(1, repository.FeedBacks.Count);
    }

}

