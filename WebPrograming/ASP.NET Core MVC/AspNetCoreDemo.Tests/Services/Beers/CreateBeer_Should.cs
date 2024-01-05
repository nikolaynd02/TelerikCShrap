using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Repositories;
using AspNetCoreDemo.Services;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace AspNetCoreDemo.Tests.Services.Beers
{
	[TestClass]
	public class CreateBeer_Should
	{
		[TestMethod]
		public void ReturnCorrectBeer_When_ParamsAreValid()
		{
			// Arrange        
			Beer testBeer = TestHelper.GetTestBeer();
			User testUser = TestHelper.GetTestUser();

			var repositoryMock = new Mock<IBeersRepository>();

			repositoryMock
				.Setup(repo => repo.GetByName(It.IsAny<string>()))
				.Throws(new EntityNotFoundException($"Beer doesn't exist."));

			repositoryMock
				.Setup(repo => repo.Create(It.IsAny<Beer>()))
				.Returns(testBeer);

			var sut = new BeersService(repositoryMock.Object);

			// Act
			Beer actualBeer = sut.Create(testBeer, testUser);

            // Assert
            Assert.AreEqual(testBeer.Id, actualBeer.Id);
			Assert.AreEqual(testBeer.Name, actualBeer.Name);
			Assert.AreEqual(testBeer.Abv, actualBeer.Abv);
			Assert.AreEqual(testBeer.CreatedById, actualBeer.CreatedById);
			Assert.AreEqual(testBeer.StyleId, actualBeer.StyleId);
		}

        [TestMethod]
        public void Throw_When_BeernameAlreadyExists()
        {
            // Arrange        
            Beer testBeer = TestHelper.GetTestBeer();
            User testUser = TestHelper.GetTestUser();

            var repositoryMock = new Mock<IBeersRepository>();

            //Setup sequential calls
            repositoryMock.SetupSequence(x => x.Create(testBeer))
               .Returns(testBeer)
               .Throws(new DuplicateEntityException("Beer with that name already exists "));

            var sut = new BeersService(repositoryMock.Object);
            Beer actualBeer = sut.Create(testBeer, testUser);
            // Act & Assert
            Assert.ThrowsException<DuplicateEntityException>(()=>sut.Create(testBeer, testUser));
        }

        [TestMethod]
        public void CallBeerRepository()
        {
            // Arrange        
            Beer testBeer = TestHelper.GetTestBeer();
            User testUser = TestHelper.GetTestUser();

            var repositoryMock = new Mock<IBeersRepository>();

            repositoryMock.Setup(x => x.Create(testBeer)).Returns(testBeer);

            var sut = new BeersService(repositoryMock.Object);

            // Act
            Beer actualBeer = sut.Create(testBeer, testUser);

            // Assert
            // Verify that the Create method is called once with the correct parameters
            repositoryMock.Verify(x => x.Create(testBeer), Times.Once);

        }
    }
}
