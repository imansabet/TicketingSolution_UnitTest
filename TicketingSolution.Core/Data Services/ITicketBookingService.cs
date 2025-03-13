using TicketingSolution.Core.Domain;

namespace TicketingSolution.Core.Data_Services;
public interface ITicketBookingService
{
    void Save(TicketBooking ticketBooking);


    IEnumerable<Ticket> GetAvailableTickets(DateTime date);

}
