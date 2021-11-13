using Shelterprojekt.Shared.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelterprojekt.Server.Services
{
    public class BookingService
    {
        ShelterDatabaseContext _db = new ShelterDatabaseContext();


        // GET     - hent listen over alle bookings
        public async Task<List<Booking>> GetAllBookings()
        {
            try
            {
                return await _db.BookingCollection
                    .Find(_ => true)
                    .Sort(Builders<Booking>                                     // Starter en sorterings-søgning
                        .Sort.Descending("shelterNavn").Ascending("dato"))      // Sorter efter bookingens shelternavn, derefter efter datoen for bookingen
                    .ToListAsync().ConfigureAwait(false);
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

        // GET     - check om et shelter er booket på en specifik dato
        public async Task<bool> GetBookingOnShelter(string shelterid, DateTime dato)
        {
            try
            {
                var filter1 = Builders<Booking>.Filter.Eq("shelterId", shelterid);          // filter, der finder bookings for den valgte shelter
                var filter2 = Builders<Booking>.Filter.Eq("dato", new BsonDateTime(dato));  // filter, der finder bookings der matcher den valgte dato


                FilterDefinition<Booking> bookingFilter = filter1 & filter2;                // sætter de to filtre sammen til et udtryk

                long count = _db.BookingCollection.CountDocuments(bookingFilter);           // laver en tællevariabel, der optæller antallet af bookings på den valgte shelter på den valgte dato


                if (count > 0) {
                    // Console.WriteLine("Service: true");
                    return true;                                                            // shelteren er booket på den valgte dato
                }
                else {
                    // Console.WriteLine("Service: false");
                    return false;                                                           // shelteren er IKKE booket på den valgte dato
                }
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
                FilterDefinition<Booking> booking = Builders<Booking>.Filter.Eq("Id", id);
                await _db.BookingCollection.DeleteOneAsync(booking);
            }
            catch
            {
                throw;
            }
        }

    }

}
