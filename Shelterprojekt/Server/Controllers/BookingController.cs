using Microsoft.AspNetCore.Mvc;
using Shelterprojekt.Server.Services;
using Shelterprojekt.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelterprojekt.Server.Controllers
{
    public class BookingController : Controller
    {

        BookingService service = new BookingService();

        [HttpGet]
        [Route("api/booking/index")]
        public async Task<IEnumerable<Booking>> Index()
        {
            return await service.GetAllBookingsAsync();
        }

        [HttpPost]
        [Route("api/booking/create")]
        public async Task Create([FromBody] Booking booking)
        {
            await service.CreateBookingAsync(booking);
        }

        [HttpGet]
        [Route("api/booking/details/{id}")]
        public async Task<Booking> Details(string id)
        {
            return await service.GetBookingByIdAsync(id);
        }

        [HttpPut]
        [Route("api/booking/edit")]
        public async Task Edit([FromBody] Booking booking)
        {
            await service.UpdateBookingAsync(booking);
        }

        [HttpDelete]
        [Route("api/booking/delete/{id}")]
        public async Task Delete(string id)
        {
            await service.DeleteBookingAsync(id);
        }

    }
}
