﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingSolution.Core.Handler;
using TicketingSolution.Core.Model;

namespace TicketingSolution.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private ITicketBookingRequestHandler  _ticketBookingRequestHandler;

        public BookingController(ITicketBookingRequestHandler ticketBookingRequestHandler)
        {
            _ticketBookingRequestHandler = ticketBookingRequestHandler;
        }

        public async Task<IActionResult> Book(TicketBookingRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _ticketBookingRequestHandler.BookService(request);
                if (result.Flag == Core.Enums.BookingResultFlag.Success)
                {
                    return Ok(result);
                }
                ModelState.AddModelError(nameof(TicketBookingRequest.Date), "No Ticket Available");
            }
            return BadRequest(ModelState);
        }
    }
}
