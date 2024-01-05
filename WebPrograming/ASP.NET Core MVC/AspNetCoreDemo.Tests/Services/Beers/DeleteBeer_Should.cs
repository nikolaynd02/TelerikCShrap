using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace AspNetCoreDemo.Tests.Services.Beers
{
	[TestClass]
	public class DeleteBeer_Should 
	{
		[TestMethod]
		public void ThrowException_When_UserNotCreator()
		{
			// Arrange
			var user = TestHelper.GetTestUser();
			var beer = TestHelper.GetTestBeer();
			
			var repositoryMock = new Mock<IBeersRepository>();

			repositoryMock
				.Setup(repo => repo.GetById(It.IsAny<int>()))
				.Returns(beer);

			var sut = new BeersService(repositoryMock.Object);
			
			Assert.ThrowsException<UnauthorizedOperationException>(() => sut.Delete(beer.Id, user));
		}

		[TestMethod]
        public void DeleteBeer_When_UserNotCreatorButIsAdmin()
        {
            // Arrange
            var user = TestHelper.GetTestUsers()[2];//Get an admin user
            var beer = TestHelper.GetTestBeers()[0];//Get a beer not created by an admin

            var repositoryMock = new Mock<IBeersRepository>();

            repositoryMock
                .Setup(repo => repo.GetById(It.IsAny<int>()))
                .Returns(beer);

            repositoryMock
                .Setup(repo => repo.Delete(It.IsAny<int>()))
				.Returns(true);

            var sut = new BeersService(repositoryMock.Object);
			//Act
			var success = sut.Delete(3, user);
			//Assert
            Assert.IsTrue(success);
        }
    }
}
