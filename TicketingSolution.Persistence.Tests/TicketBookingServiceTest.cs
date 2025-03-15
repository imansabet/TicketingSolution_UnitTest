using Microsoft.EntityFrameworkCore;
using TicketingSolution.Core.Domain;
using TicketingSolution.Persistence.Repositories;
using Xunit;

namespace TicketingSolution.Persistence.Tests;

public class TicketBookingServiceTest
{
    [Fact]
    public void Should_Save_Ticket_Booking() 
    {
        //Arange
        var dbOptions = new DbContextOptionsBuilder<TicketingSolutionDbContext>()
       .UseInMemoryDatabase("ShouldSaveTest", b => b.EnableNullChecks(true))
       .Options;

        var ticketBooking = new TicketBooking { TicketId = 1, Date = new DateTime(2025, 03, 15) };

        //Act
        using var context = new TicketingSolutionDbContext(dbOptions);
        var ticketBookingService = new TicketingBookingService(context);
        ticketBookingService.Save(ticketBooking);


        //Assert
        var bookings = context.TicketBookings.ToList();
        var booking = Assert.Single(bookings);

        Assert.Equal(ticketBooking.Date, booking.Date);
        Assert.Equal(ticketBooking.TicketId, booking.TicketId);

    }


    [Fact]
    public void Should_Return_Available_Services() 
    {
        // Arange
        var date = new DateTime(2025, 03, 14);

        var dbOptions = new DbContextOptionsBuilder<TicketingSolutionDbContext>()
            .UseInMemoryDatabase("AvailableTicketTest", b => b.EnableNullChecks(true))
            .Options;

        using var context = new TicketingSolutionDbContext(dbOptions);
        context.Add(new Ticket { Id = 1, Name = "Ticket 1" });
        context.Add(new Ticket { Id = 2, Name = "Ticket 2" });
        context.Add(new Ticket { Id = 3, Name = "Ticket 3" });

        //context.Add(new TicketBooking { TicketId = 1, Name = "T1" , Family="T11", Email="T1@t1.com" ,Date = date });
        //context.Add(new TicketBooking { TicketId = 2, Name = "T2", Family = "T22", Email = "T2@t2.com", Date = date.AddDays(-1) });
       
        context.Add(new TicketBooking { TicketId = 1, Date = date });
        context.Add(new TicketBooking { TicketId = 2,  Date = date.AddDays(-1) });

        context.SaveChanges();

        var ticketBookingService = new TicketingBookingService(context);

        // Act
        var availableServices = ticketBookingService.GetAvailableTickets(date);

        Assert.Equal(2, availableServices.Count());
        Assert.Contains( availableServices , q => q.Id ==2);
        Assert.Contains( availableServices , q => q.Id ==3);
        Assert.DoesNotContain(availableServices , q => q.Id == 1);

    }
}
