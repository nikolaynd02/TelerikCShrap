using AspNetCoreDemo.Controllers.Api;
using AspNetCoreDemo.Exceptions;
using AspNetCoreDemo.Helpers;
using AspNetCoreDemo.Models;
using AspNetCoreDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNetCoreDemo.Tests.Controllers.BeersController
{
    [TestClass]
    public class GetBeerById_Should
    {
        
        [TestMethod]
        public void ReturnNotFound_When_BeerNotFound()
        {
            // Arrange        
            var serviceMock = new Mock<IBeersService>();
            var authMock = new Mock<AuthManager>();
            var mapperMock = new Mock<ModelMapper>();

            serviceMock
                .Setup(service => service.GetById(It.IsAny<int>()))
                .Throws(new EntityNotFoundException("Beer doesn't exist."));

            var sut = new BeersApiController(serviceMock.Object,mapperMock.Object,authMock.Object);

            // Act
            var result = sut.GetBeerById(4);

            // Assert
            var objectResult = (ObjectResult)result;
            Assert.AreEqual(StatusCodes.Status404NotFound, objectResult.StatusCode);
        }


		[TestMethod]
		public void ReturnOk_When_BeerExists()
		{
			// Arrange        
			var serviceMock = new Mock<IBeersService>();
			var authMock = new Mock<AuthManager>();
			var mapperMock = new Mock<IModelMapper>();

			serviceMock
				.Setup(service => service.GetById(It.IsAny<int>()))
				.Returns(new Beer { Id = 1, Name = "Test Beer 1", Abv = 4.6});

            mapperMock
                .Setup(mapper => mapper.Map(It.IsAny<Beer>()))
                .Returns(TestHelper.GetTestBeerResponseDto());

			var sut = new BeersApiController(serviceMock.Object, mapperMock.Object, authMock.Object);

			// Act
			var result = sut.GetBeerById(1);

			// Assert
			var objectResult = (ObjectResult)result;
			Assert.AreEqual(StatusCodes.Status200OK, objectResult.StatusCode);
		}
	}
}
