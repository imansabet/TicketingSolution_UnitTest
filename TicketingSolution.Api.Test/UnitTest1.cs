﻿using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using TicketingSolution.WebApi.Controllers;

namespace TicketingSolution.Api.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Should_Return_ForeCast_Results()
        {
            //Arange 
            var loggerMock = new Mock<ILogger<WeatherForecastController>>();
            var controller = new WeatherForecastController(loggerMock.Object);


            //Act
            var result = controller.Get();
            //Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBeGreaterThan(1);

        }
    }
}
