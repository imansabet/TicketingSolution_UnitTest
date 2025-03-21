﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using TicketingSolution.Core.Enums;
using TicketingSolution.Core.Handler;
using TicketingSolution.Core.Model;
using TicketingSolution.WebApi.Controllers;

namespace TicketingSolution.Api.Test;

public class BookingControllerTest
{
    private Mock<ITicketBookingRequestHandler> _ticketBookingRequestHandler;
    private BookingController _controller;
    private TicketBookingRequest _request;
    private ServiceBookingResult _result;

    public BookingControllerTest()
    {
        _ticketBookingRequestHandler = new Mock<ITicketBookingRequestHandler>();
        _controller = new BookingController(_ticketBookingRequestHandler.Object);
        _request = new TicketBookingRequest();
        _result = new ServiceBookingResult();

        _ticketBookingRequestHandler.Setup(x => x.BookService(_request)).Returns(_result);
    }

    [Theory]
    [InlineData(1, true, typeof(OkObjectResult), BookingResultFlag.Success)]
    [InlineData(0, false, typeof(BadRequestObjectResult), BookingResultFlag.Failure)]
    public async Task Should_Call_Booking_Method_When_Valid(int expectedMethodCalls, bool isModelValid,
        Type expectedActionResultType, BookingResultFlag bookingResultFlag)
    {
        // Arrange
        if (!isModelValid)
        {
            _controller.ModelState.AddModelError("Key", "ErrorMessage");
        }

        _result.Flag = bookingResultFlag;


        // Act
        var result = await _controller.Book(_request);

        // Assert
        result.ShouldBeOfType(expectedActionResultType);
        _ticketBookingRequestHandler.Verify(x => x.BookService(_request), Times.Exactly(expectedMethodCalls));

    }
}
