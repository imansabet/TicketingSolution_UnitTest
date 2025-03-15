using System.ComponentModel.DataAnnotations;
using TicketingSolution.Domain.BaseModels;

namespace TicketingSolution.Core.Domain
{
    public class TicketBooking : ServiceBookingBase
    {
        public static int Id { get; set; }
        public int TicketId { get; set; }

        public Ticket Ticket { get; set; }
    }
}