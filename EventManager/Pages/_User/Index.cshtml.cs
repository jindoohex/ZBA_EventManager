using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Services;
using EventManager.Services.Booking;
using EventManager.Services.EventServices;
using EventManagerLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventManager.Pages._User
{
    public class IndexModel : PageModel
    {
        private IEventService _eventService;
        private IUserService _userService;
        private IBookingService _bookingService;

        private static List<Event> _EventList;
        private static List<User> _UserList;

        private static List<UserBooking> _bookingList;

        [BindProperty]
        public string CheckOption { get; set; }

        public User LoggedInUser { get; set; }

        public List<Event> Events { get; private set; }

        public List<User> Users { get; private set; }

        [BindProperty]
        public UserBooking UserBooking { get; set; }

        [BindProperty]
        public List<UserBooking> Bookings { get; set; }


        public IndexModel(IEventService eventService, IUserService userService, IBookingService bookingService)
        {
            _eventService = eventService;
            _userService = userService;
            _bookingService = bookingService;
        }


        public void OnGet()
        {

            LoggedInUser = _userService.GetUserById(_Login.IndexModel.LoggedInUser.UserId);
            
            //LoggedInUser = _Login.IndexModel.LoggedInUser;
            

            //User theUser = _userService.GetUserById();

            _EventList = _eventService.GetEvents();
            Events = new List<Event>(_EventList);

            _UserList = _userService.GetAllUsers();
            Users = new List<User>(_UserList);

            CheckOption = "";

            _bookingList = _bookingService.GetAllBookings();

        }

        public void OnPost()
        {
            LoggedInUser = _Login.IndexModel.LoggedInUser;

            _EventList = _eventService.GetEvents();
            Events = new List<Event>(_EventList);

        }
    }
}
