using Shelterprojekt.Shared.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelterprojekt.Server.Services
{
    public class BookingService
    {
        MainDbContext _db = new MainDbContext();


        // GET     - hent listen over alle bookings
        public async Task<List<Booking>> GetAllBookings()
        {
            try
            {
                return await _db.BookingCollection.Find(_ => true).ToListAsync().ConfigureAwait(false);
            }
            catch 
            {
                throw;
            }
        }

        // GET     - find specifik booking
        public async Task<Booking> GetBookingById(string id)
        {
            try
            {
                FilterDefinition<Booking> bookingFilter = Builders<Booking>.Filter.Eq("Id", id);
                return await _db.BookingCollection.FindSync(bookingFilter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        // CREATE  - lav en ny booking
        public async Task CreateBooking(Booking booking)
        {
            try
            {
                await _db.BookingCollection.InsertOneAsync(booking);
            }
            catch
            {
                throw;
            }
        }

        // UPDATE  - opdater en eksisterende booking
        public async Task UpdateBooking(Booking booking)
        {
            try
            {
                await _db.BookingCollection.ReplaceOneAsync(filter: g => g.Id == booking.Id, replacement: booking);
            }
            catch
            {
                throw;
            }
        }

        // DELETE  - slet en booking
        public async Task DeleteBooking(string id)
        {
            try
            {
                FilterDefinition<Booking> employeeData = Builders<Booking>.Filter.Eq("Id", id);
                await _db.BookingCollection.DeleteOneAsync(employeeData);
            }
            catch
            {
                throw;
            }
        }

    }

}
