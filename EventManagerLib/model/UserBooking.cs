using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagerLib.model
{
    public class UserBooking
    {
        private int _bookingId;
        private int _capacity;
        private bool _vip;
        private int _userId;
        private int _eventId;

        public UserBooking()
        {

        }

        public UserBooking(int bookingId, int capacity, bool vip, int userId)
        {
            _bookingId = bookingId;
            _capacity = capacity;
            _vip = vip;
            _userId = userId;
        }

        public int BookingId
        {
            get => _bookingId;
            set => _bookingId = value;
        }

        public int Capacity
        {
            get => _capacity;
            set => _capacity = value;
        }

        public bool Vip
        {
            get => _vip;
            set => _vip = value;
        }

        public int UserId
        {
            get => _userId;
            set => _userId = value;
        }

        public int EventId
        {
            get => _eventId;
            set => _eventId = value;
        }

        public override string ToString()
        {
            return $"{nameof(BookingId)}: {BookingId}, {nameof(Capacity)}: {Capacity}, {nameof(Vip)}: {Vip}, {nameof(UserId)}: {UserId}, {nameof(EventId)}: {EventId}";
        }
    }
}
