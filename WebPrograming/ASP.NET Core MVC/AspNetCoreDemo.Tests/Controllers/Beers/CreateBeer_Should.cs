using AspNetCoreDemo.Controllers.Api;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Models.DTO;
using AspNetCoreDemo.Services;
using AspNetCoreDemo.Tests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNetCoreDemo.Tests.Controllers.BeersController
{
    [TestClass]
    public class CreateBeer_Should
    {
        [TestMethod]
        public void ReturnCreated_When_ParamsAreValid()
        {
            // Arrange        
            User user = TestHelper.GetTestUser();
            Beer beer = TestHelper.GetTestBeer();
            BeerResponseDto beerResponseDto = TestHelper.GetTestBeerResponseDto();
            
            var serviceMock = new Mock<IBeersService>();
            var authMock = new Mock<AuthManager>();
            var mapperMock = new Mock<IModelMapper>();

            authMock.Setup(service => service.TryGetUser(It.IsAny<string>()))
                .Returns(user);
            mapperMock.Setup(mapper => mapper.Map(It.IsAny<BeerDto>()))
                .Returns(new Beer { Name = "TestBeer", StyleId = 1, Abv = 5});
            serviceMock.Setup(service => service.Create(It.IsAny<Beer>(), It.IsAny<User>()))
                .Returns(beer);
			mapperMock.Setup(mapper => mapper.Map(It.IsAny<Beer>()))
			   .Returns(beerResponseDto);

			var testDto = new BeerDto { Name = "TestBeer", StyleId = 1, Abv = 5 };

            var sut = new BeersApiController(serviceMock.Object, mapperMock.Object, authMock.Object);

            // Act
            var result = sut.CreateBeer("TestUser", testDto);

            // Assert
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(StatusCodes.Status201Created, objectResult.StatusCode);
        }
        [TestMethod]
        public void ReturnConflict_When_BeerAlreadyExists()
        {
            // Arrange        
            User user = TestHelper.GetTestUser();
            Beer beer = TestHelper.GetTestBeer();
            var serviceMock = new Mock<IBeersService>();
            var authMock = new Mock<AuthManager>();
            var mapperMock = new Mock<IModelMapper>();

            authMock.Setup(service => service.TryGetUser(It.IsAny<string>()))
                .Returns(user);
            mapperMock.Setup(service => service.Map(It.IsAny<BeerDto>()))
                .Returns(new Beer { Name = "TestBeer", StyleId = 1, Abv = 5 });
            serviceMock.Setup(service => service.Create(It.IsAny<Beer>(), It.IsAny<User>()))
                .Throws(new DuplicateEntityException("Beer with such name already exists"));
            
            var testDto = new BeerDto { Name = "TestBeer", StyleId = 1, Abv = 5 };

            var sut = new BeersApiController(serviceMock.Object, mapperMock.Object, authMock.Object);

            // Act
            var result = sut.CreateBeer("TestUser", testDto);

            // Assert
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(StatusCodes.Status409Conflict, objectResult.StatusCode);
        }

        [TestMethod]
        public void ReturnUnauthorized_When_CredentialsAreMissing()
        {
            // Arrange        
            User user = TestHelper.GetTestUser();
            Beer beer = TestHelper.GetTestBeer();
            var serviceMock = new Mock<IBeersService>();
            var authMock = new Mock<AuthManager>();
            var mapperMock = new Mock<ModelMapper>();

            authMock.Setup(service => service.TryGetUser(It.IsAny<string>()))
                .Throws(new UnauthorizedOperationException("Invalid credentials"));


            var testDto = new BeerDto { Name = "TestBeer", StyleId = 1, Abv = 5 };

            var sut = new BeersApiController(serviceMock.Object, mapperMock.Object, authMock.Object);

            // Act
            var result = sut.CreateBeer("TestUser", testDto);

            // Assert
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(StatusCodes.Status401Unauthorized, objectResult.StatusCode);
        }
    }
}
