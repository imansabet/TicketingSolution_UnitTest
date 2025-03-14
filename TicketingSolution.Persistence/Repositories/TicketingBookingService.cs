using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSolution.Core.Data_Services;
using TicketingSolution.Core.Domain;

namespace TicketingSolution.Persistence.Repositories
{
    public class TicketingBookingService : ITicketBookingService
    {
        public IEnumerable<Ticket> GetAvailableTickets(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Save(TicketBooking ticketBooking)
        {
            throw new NotImplementedException();
        }
    }
}
