using Boarder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boarder.Test
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Check_Member_AddItem_Should_Add_Item_When_Valid()
        {
            //Arrange
            Issue item = new Issue("xxxxxx","xxxxxxxxxxxxxxxxx",DateTime.Now.AddMonths(1));

            //Act
            Board.AddItem(item);

            //Assert
            Assert.AreEqual(1, Board.TotalItems);
        }

        [TestMethod]
        public void Check_Member_AddItem_Should_Throw_When_Item_Is_Not_Valid()
        {
            //Arrange
            Issue item = new Issue("xxxxxx", "xxxxxxxxxxxxxxxxx", DateTime.Now.AddMonths(1));
            Board.AddItem(item);



            //Act & Assert
            //Assert.ThrowsException<InvalidOperationException>(() => Board.AddItem(null));
            //Should add check if item is null
            Assert.ThrowsException<InvalidOperationException>(() => Board.AddItem(item));
        }
    }
}
