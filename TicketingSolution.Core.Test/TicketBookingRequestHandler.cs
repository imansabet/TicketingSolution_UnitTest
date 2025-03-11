
namespace TicketingSolution.Core
{
    internal class TicketBookingRequestHandler
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