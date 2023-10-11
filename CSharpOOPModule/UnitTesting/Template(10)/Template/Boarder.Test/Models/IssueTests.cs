using Boarder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Boarder.Test.Models
{
    [TestClass]
    public class IssueTests
    {
        [TestMethod]
        public void Constructur_Should_CreateInstance_With_Valid_Data()
        {
            //Arrange
            string testTitle = "test123";
            string description = "test123";
            DateTime dueDate = DateTime.Now.AddDays(2);
            //Act
            Issue testIssue = new Issue(testTitle, description, dueDate);

            //Assert
            Assert.IsNotNull(testIssue, "Issue could not be created with valid input.");
        }

        [TestMethod]
        public void Constructur_Should_Not_CreateInstance_With_Invalid_Title()
        {
            //Arrange
            string shortTitle = "";
            string longTitle = new string('1', 100);
            string nullTitle = null;
            string testAssignee = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Issue(shortTitle, testAssignee, testDate), "Should throw Agument Exception for title.");
            Assert.ThrowsException<ArgumentException>(() => new Issue(longTitle, testAssignee, testDate), "Should throw Agument Exception for title.");
            Assert.ThrowsException<ArgumentException>(() => new Issue(nullTitle, testAssignee, testDate), "Should throw Agument Exception for title.");
        }

        [TestMethod]
        public void Constructur_Should_Not_CreateInstance_With_Invalid_DueDate()
        {
            //Arrange
            string title = "test123";
            string description = "xsssssssssssssssssssssssss";

            DateTime testDate = new DateTime(2000,10,10);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Issue(title, description, testDate), "Should throw Agument Exception for dueDate.");
            
        }

        [TestMethod]
        public void Check_Property_Title_Should_Work_With_Valid_Data()
        {
            //Arrange
            string initilaTitle = "test123";
            string description = "test123";
            string newTitle = "NewTitle";
            DateTime testDate = DateTime.Now.AddDays(2);
            //Act
            Issue testTask = new Issue(initilaTitle, description, testDate);
            testTask.Title = newTitle;


            //Assert
            Assert.AreEqual(newTitle, testTask.Title, "Should change old title data with newTitle value");

        }

        [TestMethod]
        public void Check_Property_Title_Should_ThrowException_With_InValid_Data()
        {
            //Arrange
            string initialTitle = "test123";
            string description = "test123";
            string nullTitle = null;
            string shortTitle = "x";
            string longTitle = new string('x', 100);
            DateTime testDate = DateTime.Now.AddDays(2);

            Issue testTask = new Issue(initialTitle, description, testDate);


            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => testTask.Title = nullTitle, "Should throw Agument Exception for title when tried to be changed.");
            Assert.ThrowsException<ArgumentException>(() => testTask.Title = shortTitle, "Should throw Agument Exception for title when tried to be changed.");
            Assert.ThrowsException<ArgumentException>(() => testTask.Title = longTitle, "Should throw Agument Exception for title when tried to be changed.");

        }
        

        [TestMethod]
        public void Check_Member_AdvanceStatus_Should_Advance_Status_Of_Task()
        {
            //Arrange
            string testTitle = "test123";
            string description = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);
            Issue testTask = new Issue(testTitle, description, testDate);
            //Act
            testTask.AdvanceStatus();

            //Assert
            Assert.AreEqual(Status.Verified, testTask.Status, "Status should be changed from Open to Verified.");
        }

        [TestMethod]
        public void Check_Member_AdvanceStatus_Should_Not_Advance_Status_Past_Verified()
        {
            //Arrange
            string testTitle = "test123";
            string description = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);
            Issue testTask = new Issue(testTitle, description, testDate);
            //Act
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();

            //Assert
            Assert.AreEqual(Status.Verified, testTask.Status, "Status should be changed from Open to Verified and should not go past Verified.");
        }

        [TestMethod]
        public void Check_Member_RevertStatus_Should_Revert_Status_Of_Task()
        {
            //Arrange
            string testTitle = "test123";
            string description = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);
            Issue testTask = new Issue(testTitle, description, testDate);
            //Act
            testTask.AdvanceStatus();
            testTask.AdvanceStatus();
            testTask.RevertStatus();

            //Assert
            Assert.AreEqual(Status.Open, testTask.Status, "Status should be changed from Verified to Open.");
        }

        [TestMethod]
        public void Check_Member_RevertStatus_Should_Not_Revert_Status_Past_Open()
        {
            //Arrange
            string testTitle = "test123";
            string description = "test123";
            DateTime testDate = DateTime.Now.AddDays(2);
            Issue testTask = new Issue(testTitle, description, testDate);
            //Act
            testTask.RevertStatus();
            testTask.RevertStatus();

            //Assert
            Assert.AreEqual(Status.Open, testTask.Status, "Status should remain at Open.");
        }
    }
}
