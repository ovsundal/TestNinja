using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null);
    }

    public class BookingRepository : IBookingRepository
    {
        //encapsulate query in method
        public IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Status != "Cancelled");

            if (excludedBookingId.HasValue)
            {
                bookings = bookings.Where(b => b.Id != excludedBookingId.Value);
            }

            return bookings;
        }
    }
}