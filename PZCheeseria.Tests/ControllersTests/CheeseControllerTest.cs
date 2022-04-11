using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PZCheeseria.Controllers;
using PZCheeseria.Model;
using PZCheeseria.Repository.Interface;
using System;
using Xunit;

namespace PZCheeseriaTest.ControllersTests
{
    public class CheeseControllerTest
    {
        [Fact]
        public void GetAllCheese_NoInternalServerError_ShouldReturnOkWithList()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var cheeseRepository = fixture.Freeze<Mock<ICheeseRepository>>();
            var logger = fixture.Freeze<ILogger<CheeseController>>();
            var mockCheeseList = fixture.CreateMany<Cheese>();
            cheeseRepository.Setup(r => r.GetAllCheese()).Returns(mockCheeseList);


            var sut = new CheeseController(logger,cheeseRepository.Object);

            //Act
            var response = sut.GetAll();

            //Assert
            cheeseRepository.Verify(cr => cr.GetAllCheese(), Times.Once);
            var result = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(mockCheeseList, result.Value);
           

        }

        [Fact]
        public void GetAllCheese_WithInternalServerError_ShouldReturnInternalServerError()
        {
            //Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var cheeseRepository = fixture.Freeze<Mock<ICheeseRepository>>();
            var logger = fixture.Freeze<Mock<ILogger<CheeseController>>>();
            var mockCheeseList = fixture.CreateMany<Cheese>();
            cheeseRepository.Setup(r => r.GetAllCheese()).Throws<Exception>();


            var sut = new CheeseController(logger.Object, cheeseRepository.Object);

            //Act
            var response = sut.GetAll();

            //Assert
            var result = Assert.IsType<ObjectResult>(response);
            Assert.Equal(500, result.StatusCode);


        }
    }
}
