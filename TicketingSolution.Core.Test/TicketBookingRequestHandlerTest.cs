using Shouldly;

namespace TicketingSolution.Core;

public class Ticket_Booking_Request_Handler_Test
{
    [Fact]
    public void Should_Return_Ticket_Booking_Response_With_Request_Values() 
    {
        // Arrange
        var BookingRequest = new TicketBookingRequest
        {
            Name = "Test Name",
            Family = "Test Family",
            Email = "TestEmail"
        };

        var Handler = new TicketBookingRequestHandler();


        // Act
        ServiceBookingResult Result =  Handler.BookService(BookingRequest);


        // Assert
        Assert.NotNull(Result);
        Assert.Equal(Result.Name, BookingRequest.Name);
        Assert.Equal(Result.Family, BookingRequest.Family);
        Assert.Equal(Result.Email, BookingRequest.Email);

        // Assert By Shouldly
        Result.ShouldNotBeNull();
        Result.Name.ShouldBe(BookingRequest.Name);
        Result.Email.ShouldBe(BookingRequest.Email);
        Result.Family.ShouldBe(BookingRequest.Family);
    }

}
