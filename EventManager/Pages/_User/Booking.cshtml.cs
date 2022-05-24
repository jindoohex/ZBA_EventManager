using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Services;
using EventManager.Services.Booking;
using EventManager.Services.EventServices;
using EventManagerLib.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;


namespace EventManager.Pages._User
{
    [Authorize(Roles = "RegUser, Admin")]
    public class BookingModel : PageModel
    {

        private IBookingService _bookingService;
        private IEventService _eventService;
        private IUserService _userService;


        public static User LoggedInUser { get; set; }

        [BindProperty]
        public UserBooking UserBooking { get; set; }

        [BindProperty]
        public List<UserBooking> Bookings { get; set; }

        [BindProperty]
        public Event Event { get; set; }

        [BindProperty]
        public List<int> Capacity { get; set; }


        [BindProperty]
        public List<int> AreChecked { get; set; }

        public BookingModel(IBookingService bookingService, IEventService eventService, IUserService userService)
        {
            _bookingService = bookingService;
            _eventService = eventService;
            _userService = userService;

            AreChecked = new List<int>();

            Capacity = new List<int>
            {
                1, 2, 3, 4, 5
            };

        }

        public void OnGet(int id)
        {
            Event = _eventService.GetById(id);

            LoggedInUser = _userService.GetUserById(_Login.IndexModel.LoggedInUser.UserId);

        }

        public IActionResult OnPost(int id)
        {
            UserBooking.EventId = id;

            UserBooking.UserId = _Login.IndexModel.LoggedInUser.UserId;

            UserBooking = _bookingService.Create(UserBooking);
            return RedirectToPage("/_User/Index");
        }
    }
}
