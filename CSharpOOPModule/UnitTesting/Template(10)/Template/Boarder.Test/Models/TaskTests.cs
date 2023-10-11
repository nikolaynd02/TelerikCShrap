using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boarder.Models;

namespace Boarder.Test.Models
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void Constructur_Should_CreateInstance_With_Valid_Data() 
        {
            //Arrange
            string testTitle = "test123";
            string testAssignee = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);
            //Act
            Boarder.Models.Task testTask = new Boarder.Models.Task(testTitle,testAssignee,testDate);

            //Assert
            Assert.IsNotNull(testTask,"Task could not be created with valid input.");
        }

        [TestMethod]
        public void Constructur_Should_Not_CreateInstance_With_Invalid_Title()
        {
            //Arrange
            string shortTitle = "";
            string longTitle = new string('1',100);
            string nullTitle = null;
            string testAssignee = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Boarder.Models.Task(shortTitle, testAssignee, testDate), "Should throw Agument Exception for title.");
            Assert.ThrowsException<ArgumentException>(() => new Boarder.Models.Task(longTitle, testAssignee, testDate), "Should throw Agument Exception for title.");
            Assert.ThrowsException<ArgumentException>(() => new Boarder.Models.Task(nullTitle, testAssignee, testDate), "Should throw Agument Exception for title.");
        }

        [TestMethod]
        public void Constructur_Should_Not_CreateInstance_With_Invalid_Assignee()
        {
            //Arrange
            string title = "test123";
            string shortAssignee = "x";
            string longAssignee = new string('1', 100);
            string nullAssignee = null;            
            DateTime testDate = DateTime.Now.AddDays(2);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Boarder.Models.Task(title, shortAssignee, testDate), "Should throw Agument Exception for assignee.");
            Assert.ThrowsException<ArgumentException>(() => new Boarder.Models.Task(title, longAssignee, testDate), "Should throw Agument Exception for assignee.");
            Assert.ThrowsException<ArgumentException>(() => new Boarder.Models.Task(title, nullAssignee, testDate), "Should throw Agument Exception for assignee.");
        }

        [TestMethod]
        public void Constructur_Should_Not_CreateInstance_With_Invalid_DueDate()
        {
            //Arrange
            string title = "test123";
            string assignee = "xsssssssssssssssssssssssss";

            DateTime testDate = new DateTime(2000, 10, 10);

            Boarder.Models.Task secondTest = new Boarder.Models.Task(title, assignee, DateTime.Now.AddDays(2));

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Boarder.Models.Task(title, assignee, testDate), "Should throw Agument Exception for dueDate.");
            Assert.ThrowsException<ArgumentException>(() => secondTest.DueDate = testDate, "Should throw Agument Exception for dueDate.");

        }

        [TestMethod]
        public void Check_Property_Title_Should_Work_With_Valid_Data()
        {
            //Arrange
            string initilaTitle = "test123";
            string assignee = "test123";
            string newTitle = "NewTitle";
            DateTime testDate = DateTime.Now.AddDays(2);
            //Act
            Boarder.Models.Task testTask = new Boarder.Models.Task(initilaTitle, assignee, testDate);
            testTask.Title = newTitle;


            //Assert
            Assert.AreEqual(newTitle, testTask.Title, "Should change old title data with newTitle value");

        }

        [TestMethod]
        public void Check_Property_Title_Should_ThrowException_With_InValid_Data()
        {
            //Arrange
            string initialTitle = "test123";
            string assignee = "test123";
            string nullTitle = null;
            string shortTitle = "x";
            string longTitle = new string('x', 100);
            DateTime testDate = DateTime.Now.AddDays(2);

            Boarder.Models.Task testTask = new Boarder.Models.Task(initialTitle, assignee, testDate);


            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => testTask.Title = nullTitle, "Should throw Agument Exception for title when tried to be changed.");
            Assert.ThrowsException<ArgumentException>(() => testTask.Title = shortTitle, "Should throw Agument Exception for title when tried to be changed.");
            Assert.ThrowsException<ArgumentException>(() => testTask.Title = longTitle, "Should throw Agument Exception for title when tried to be changed.");

        }

        [TestMethod]
        public void Check_Property_Assignee_Should_Work_With_Valid_Data()
        {
            //Arrange
            string testTitle = "test123";
            string InitialAssignee = "test123";
            string newAssignee = "NewAssignee";
            DateTime testDate = DateTime.Now.AddDays(2);
            //Act
            Boarder.Models.Task testTask = new Boarder.Models.Task(testTitle, InitialAssignee, testDate);
            testTask.Assignee = newAssignee;


            //Assert
            Assert.AreEqual(newAssignee, testTask.Assignee, "Should change old assagnee date with newAssignee value");

        }

        [TestMethod]
        public void Check_Property_Assignee_Should_ThrowException_With_InValid_Data()
        {
            //Arrange
            string testTitle = "test123";
            string InitialAssignee = "test123";
            string nullAssignee = null;
            string shortAssignee = "x";
            string longAssignee = new string('x', 100);
            DateTime testDate = DateTime.Now.AddDays(2);

            Boarder.Models.Task testTask = new Boarder.Models.Task(testTitle, InitialAssignee, testDate);


            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => testTask.Assignee = nullAssignee, "Should throw Agument Exception for assignee when tried to be changed.");
            Assert.ThrowsException<ArgumentException>(() => testTask.Assignee = shortAssignee, "Should throw Agument Exception for assignee when tried to be changed.");
            Assert.ThrowsException<ArgumentException>(() => testTask.Assignee = longAssignee, "Should throw Agument Exception for assignee when tried to be changed.");

        }

        [TestMethod]
        public void Check_Member_AdvanceStatus_Should_Advance_Status_Of_Task()
        {
            //Arrange
            string testTitle = "test123";
            string testAssignee = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);
            Boarder.Models.Task testTask = new Boarder.Models.Task(testTitle, testAssignee, testDate);
            //Act
            testTask.AdvanceStatus();

            //Assert
            Assert.AreEqual(Status.InProgress ,testTask.Status, "Status should be changed from Todo to InProgress.");
        }

        [TestMethod]
        public void Check_Member_AdvanceStatus_Should_Not_Advance_Status_Past_Verified()
        {
            //Arrange
            string testTitle = "test123";
            string testAssignee = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);
            Boarder.Models.Task testTask = new Boarder.Models.Task(testTitle, testAssignee, testDate);
            //Act
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();

            //Assert
            Assert.AreEqual(Status.Verified, testTask.Status, "Status should be changed from Todo to Verified and should not go past Verified.");
        }

        [TestMethod]
        public void Check_Member_RevertStatus_Should_Revert_Status_Of_Task()
        {
            //Arrange
            string testTitle = "test123";
            string testAssignee = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);
            Boarder.Models.Task testTask = new Boarder.Models.Task(testTitle, testAssignee, testDate);
            //Act
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.RevertStatus();

            //Assert
            Assert.AreEqual(Status.InProgress, testTask.Status, "Status should be changed from Todo to InProgress.");
        }

        [TestMethod]
        public void Check_Member_RevertStatus_Should_Not_Revert_Status_Past_Todo()
        {
            //Arrange
            string testTitle = "test123";
            string testAssignee = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);
            Boarder.Models.Task testTask = new Boarder.Models.Task(testTitle, testAssignee, testDate);
            //Act
            testTask.RevertStatus();
            testTask.RevertStatus();

            //Assert
            Assert.AreEqual(Status.Todo, testTask.Status, "Status should remain at Todo.");
        }

        [TestMethod]
        public void Check_Property_DueDate_Should_Change_Date_To_New_Valid_Date()
        {
            //Arrange
            string title = "test123";
            string assignee = "xsssssssssssssssssssssssss";

            DateTime testDate = new DateTime(2100, 10, 10);
            Boarder.Models.Task secondTest = new Boarder.Models.Task(title, assignee, DateTime.Now.AddDays(2));

            //Act
            secondTest.DueDate = testDate;
            //Assert
            Assert.AreEqual(testDate, secondTest.DueDate);
        }
    }
}
