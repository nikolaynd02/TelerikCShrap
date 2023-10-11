using Boarder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder.Test.Models
{
    [TestClass]
    public class EventLogTests
    {
        [TestMethod]
        public void Constructor_Should_Create_Instance_With_Valid_Data()
        {
            //Arrange
            string description = "xxxxxxxxxxxxx";

            //Act
            EventLog test = new EventLog(description);

            //Assert
            Assert.IsNotNull(test);
        }

        [TestMethod]
        public void Constructur_Should_Throw_When_Description_Is_Null()
        {
            //Arrange
            string description = null;

          
            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EventLog(description));
        }
    }
}
