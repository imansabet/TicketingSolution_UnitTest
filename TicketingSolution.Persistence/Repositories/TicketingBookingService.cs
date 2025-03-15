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
        private readonly TicketingSolutionDbContext _context;

        public TicketingBookingService(TicketingSolutionDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetAvailableTickets(DateTime date)
        {


            return _context.Tickets
                .Where(q => !q.TicketBooking.Any(x => x.Date == date))
                .ToList();

             ;
        }

        public void Save(TicketBooking ticketBooking)
        {
            _context.Add(ticketBooking);
            _context.SaveChanges();
        }
    }
}
