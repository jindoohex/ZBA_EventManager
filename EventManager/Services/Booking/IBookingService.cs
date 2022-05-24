using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagerLib.model;

namespace EventManager.Services.Booking
{
    public interface IBookingService
    {
        List<UserBooking> GetAllBookings();
        UserBooking Create(UserBooking newUserBooking);
        UserBooking Delete(int bookingId);
        UserBooking GetById(int bookingId);
    }
}
