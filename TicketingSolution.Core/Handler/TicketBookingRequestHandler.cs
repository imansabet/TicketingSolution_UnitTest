using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Handler
{
    public class TicketBookingRequestHandler
    {
        public TicketBookingRequestHandler()
        {
        }

        public ServiceBookingResult BookService(TicketBookingRequest bookingRequest)
        {
            return new ServiceBookingResult
            {
                Name = bookingRequest.Name,
                Email = bookingRequest.Email,
                Family = bookingRequest.Family
            };
        }
    }
}