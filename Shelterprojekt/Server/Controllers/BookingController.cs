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
            return await service.GetAllBookings();
        }

        [HttpGet]
        [Route("api/booking/details/{id}")]
        public async Task<Booking> Details(string id)
        {
            return await service.GetBookingById(id);
        }

        [HttpGet]
        [Route("api/booking/check/{id}/{date}")]
        public async Task<bool> Check(string id, string date)
        {

            DateTime dato = DateTime.Parse(date); 

            return await service.GetBookingOnShelter(id, dato);
        }

        [HttpPost]
        [Route("api/booking/create")]
        public async Task Create([FromBody] Booking booking)
        {
            await service.CreateBooking(booking);
        }

        [HttpPut]
        [Route("api/booking/edit")]
        public async Task Edit([FromBody] Booking booking)
        {
            await service.UpdateBooking(booking);
        }

        [HttpDelete]
        [Route("api/booking/delete/{id}")]
        public async Task Delete(string id)
        {
            await service.DeleteBooking(id);
        }

    }
}
