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
        MainDbContext _dbContext = new MainDbContext();

        // GET     - hent listen over alle bookings
        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            try
            {
                return await _dbContext.BookingCollection.Find(_ => true).ToListAsync().ConfigureAwait(false);
            }
            catch 
            {
                throw;
            }
        }

        // GET     - find specifik booking
        public async Task<Booking> GetBookingByIdAsync(string id)
        {
            try
            {
                FilterDefinition<Booking> bookingFilter = Builders<Booking>.Filter.Eq("Id", id);
                return await _dbContext.BookingCollection.FindSync(bookingFilter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }

        // CREATE  - lav en ny booking
        public async Task CreateBookingAsync(Booking booking)
        {
            try
            {
                await _dbContext.BookingCollection.InsertOneAsync(booking);
            }
            catch
            {
                throw;
            }
        }

        // UPDATE  - opdater en eksisterende booking
        public async Task UpdateBookingAsync(Booking booking)
        {
            try
            {
                await _dbContext.BookingCollection.ReplaceOneAsync(filter: g => g.Id == booking.Id, replacement: booking);
            }
            catch
            {
                throw;
            }
        }

        // DELETE  - slet en booking
        public async Task DeleteBookingAsync(string id)
        {
            try
            {
                FilterDefinition<Booking> employeeData = Builders<Booking>.Filter.Eq("Id", id);
                await _dbContext.BookingCollection.DeleteOneAsync(employeeData);
            }
            catch
            {
                throw;
            }
        }

    }

}
