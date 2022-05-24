using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Services;
using EventManager.Services.Booking;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventManagerLib.model;
using EventManager.Services.EventServices;
using Microsoft.AspNetCore.Authorization;

namespace EventManager.Pages._Admin
{
    public class IndexModel : PageModel
    {
        private IEventService _eventService;
        private IUserService _userService;
        private IBookingService _bookingService;

        private static List<Event> _eventList;
        private static List<User> _userList;


        [BindProperty]
        public List<UserBooking> Bookings { get; set; }

        [BindProperty]
        public UserBooking UserBooking { get; set; }

        [BindProperty]
        public string CheckOption { get; set; }

        public List<Event> Events { get; private set; }

        public List<User> Users { get; private set; }

        public IndexModel(IEventService eventService, IUserService userService, IBookingService bookingService)
        {
            _eventService = eventService;
            _userService = userService;
            _bookingService = bookingService;
        }


        public void OnGet()
        {
            _eventList = _eventService.GetEvents();
            Events = new List<Event>(_eventList);

            _userList = _userService.GetAllUsers();
            Users = new List<User>(_userList);

            CheckOption = "";

            Bookings = _bookingService.GetAllBookings();
        }

        public void OnPost()
        {
            _eventList = _eventService.GetEvents();
            Events = new List<Event>(_eventList);

            _userList = _userService.GetAllUsers();
            Users = new List<User>(_userList);

            Bookings = _bookingService.GetAllBookings();
        }
    }
}